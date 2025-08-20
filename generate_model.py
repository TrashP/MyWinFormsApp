import os
import sys
import json
import torch
import logging
import numpy as np
from PIL import Image
from diffusers import StableDiffusionPipeline
import rembg
import transformers

# Eagerly load CLIPImageProcessor to prevent lazy loading issues with Nuitka
from transformers.models.clip.image_processing_clip import CLIPImageProcessor
from transformers.models.clip import CLIPTokenizer, CLIPVisionModel

from tsr.system import TSR
from tsr.utils import remove_background, resize_foreground


def generate_image(prompt, output_dir, device="cpu"):
    model_id = "runwayml/stable-diffusion-v1-5"
    pipe = StableDiffusionPipeline.from_pretrained(
        model_id, torch_dtype=torch.float32, use_safetensors=True
    ).to(device)

    image = pipe(
        prompt,
        negative_prompt="blurry, low-quality, background clutter, multiple objects, distorted",
        num_inference_steps=50,
        guidance_scale=7.5,
        height=512,
        width=512
    ).images[0]

    os.makedirs(output_dir, exist_ok=True)
    image_path = os.path.join(output_dir, "input.png")
    image.save(image_path)
    return image_path


def load_prompt(json_path):
    with open(json_path, 'r') as f:
        return json.load(f)["prompt"]


def run_triposr(image_path, output_dir, device="cuda:0", resolution=256):
    if not torch.cuda.is_available():
        device = "cpu"

    logging.info("Loading TripoSR model...")
    model = TSR.from_pretrained("stabilityai/TripoSR", config_name="config.yaml", weight_name="model.ckpt")
    model.renderer.set_chunk_size(8192)
    model.to(device)

    logging.info("Removing background and preprocessing image...")
    rembg_session = rembg.new_session()
    image = remove_background(Image.open(image_path), rembg_session)
    image = resize_foreground(image, 0.85)
    image = np.array(image).astype(np.float32) / 255.0
    image = image[:, :, :3] * image[:, :, 3:4] + (1 - image[:, :, 3:4]) * 0.5
    image = Image.fromarray((image * 255.0).astype(np.uint8))

    logging.info("Running TripoSR inference...")
    with torch.no_grad():
        scene_codes = model([image], device=device)

    logging.info("Extracting mesh...")
    meshes = model.extract_mesh(scene_codes, True, resolution=resolution)
    mesh = meshes[0]

    vertices = mesh.vertices
    faces = mesh.faces

    # === Extract vertex colors ===
    from trimesh.visual.color import ColorVisuals

    colors = None
    if isinstance(mesh.visual, ColorVisuals):
        raw_colors = mesh.visual.vertex_colors
        if raw_colors is not None and len(raw_colors) == len(vertices):
            colors = raw_colors[:, :3]  # Drop alpha
            if colors.max() > 1.0:
                colors = colors / 255.0
        else:
            logging.warning("Mismatch in vertex color count or missing colors.")
            colors = None

    if colors is None:
        logging.warning("No valid vertex colors found. Using default grey color.")
        colors = np.ones((len(vertices), 3), dtype=np.float32) * 0.5

    # === Save .txt format ===
    txt_dir = os.path.join(output_dir, "3d")
    os.makedirs(txt_dir, exist_ok=True)
    txt_path = os.path.join(txt_dir, "model.txt")

    with open(txt_path, 'w') as f:
        f.write("# Vertices (x y z r g b)\n")
        for v, c in zip(vertices, colors):
            f.write(f"v {v[0]:.6f} {v[1]:.6f} {v[2]:.6f} {c[0]:.6f} {c[1]:.6f} {c[2]:.6f}\n")

        f.write("\n# Faces\n")
        for face in faces:
            f.write(f"f {face[0]+1} {face[1]+1} {face[2]+1}\n")

    logging.info(f"Saved model.txt to: {txt_path}")

    # === Save .obj format ===
    obj_dir = os.path.join(output_dir, "obj")
    os.makedirs(obj_dir, exist_ok=True)
    obj_path = os.path.join(obj_dir, "model.obj")
    mesh.export(obj_path)
    logging.info(f"Saved model.obj to: {obj_path}")




if __name__ == "__main__":
    print(transformers.models.clip.image_processing_clip)
    logging.basicConfig(format="%(asctime)s - %(levelname)s - %(message)s", level=logging.INFO)

    if len(sys.argv) != 2:
        print("Usage: python combined_pipeline.py input.json")
        sys.exit(1)

    json_file = sys.argv[1]
    prompt = load_prompt(json_file)

    out_dir = "output"
    image_output_dir = os.path.join(out_dir, "image")
    tripo_output_dir = os.path.join(out_dir, "3d")

    logging.info(f"Generating image from prompt: '{prompt}'")
    image_path = generate_image(prompt, image_output_dir, device="cpu")

    logging.info("Running 3D reconstruction...")
    run_triposr(image_path, tripo_output_dir, device="cuda:0")
