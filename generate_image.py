import sys
import json
from diffusers import StableDiffusionPipeline
import torch
import os
import re

def sanitize_filename(prompt):
    """Convert prompt to a safe filename by removing invalid characters."""
    return re.sub(r'[^\w\s-]', '', prompt.lower().replace(' ', '_'))[:50]

def main():
    if len(sys.argv) < 2:
        print("Usage: generate_image.exe <json_file>")
        sys.exit(1)

    json_file = sys.argv[1]

    if not os.path.isfile(json_file):
        print(f"Error: JSON file '{json_file}' not found")
        sys.exit(1)

    # When packaged with Nuitka --onefile, sys._MEIPASS does not exist like PyInstaller.
    # Instead, sys.argv[0] gives the EXE location.
    exe_dir = os.path.dirname(os.path.abspath(sys.argv[0]))
    output_dir = os.path.join(exe_dir, "output", "image")
    os.makedirs(output_dir, exist_ok=True)

    with open(json_file, 'r', encoding='utf-8') as f:
        data = json.load(f)
        prompt = data.get('prompt', 'A default object')

    filename = sanitize_filename(prompt) + ".png"
    output_path = os.path.join(output_dir, filename)

    device = "cpu"
    model_id = "runwayml/stable-diffusion-v1-5"
    pipe = StableDiffusionPipeline.from_pretrained(model_id, torch_dtype=torch.float32, use_safetensors=True)
    pipe = pipe.to(device)

    image = pipe(
        prompt,
        negative_prompt="blurry, low-quality, background clutter, multiple objects, distorted",
        num_inference_steps=50,
        guidance_scale=7.5,
        height=512,
        width=512
    ).images[0]

    image.save(output_path)
    print(f"Generated image: {output_path}")

if __name__ == "__main__":
    main()
