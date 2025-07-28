import os
import sys
import json
import torch
import logging
import time
import numpy as np
from PIL import Image
from diffusers import StableDiffusionPipeline
import rembg
import xatlas

from tsr.system import TSR
from tsr.utils import remove_background, resize_foreground, save_video
from tsr.bake_texture import bake_texture

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

def run_triposr(image_path, output_dir, device="cuda:0", resolution=256, bake_texture=False):
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
    meshes = model.extract_mesh(scene_codes, not bake_texture, resolution=resolution)

    mesh_path = os.path.join(output_dir, f"mesh.{'obj' if not bake_texture else 'glb'}")
    os.makedirs(output_dir, exist_ok=True)

    if bake_texture:
        out_texture_path = os.path.join(output_dir, "texture.png")
        bake_output = bake_texture(meshes[0], model, scene_codes[0], 2048)
        xatlas.export(
            mesh_path,
            meshes[0].vertices[bake_output["vmapping"]],
            bake_output["indices"],
            bake_output["uvs"],
            meshes[0].vertex_normals[bake_output["vmapping"]]
        )
        Image.fromarray((bake_output["colors"] * 255.0).astype(np.uint8)).transpose(Image.FLIP_TOP_BOTTOM).save(out_texture_path)
    else:
        meshes[0].export(mesh_path)

    logging.info(f"Mesh saved to: {mesh_path}")

if __name__ == "__main__":
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
    run_triposr(image_path, tripo_output_dir, device="cuda:0", bake_texture=False)
