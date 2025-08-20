The Paradise Designer AI Images and Models app can be used to create images and 3D objects with generative AI. To use the app, create executables for the python scripts with Nuitka and place them in the dist folder in AI3DModelMaker. Also place the ffmpeg, ffplay, and ffprobe executables in the dist folder.

Nuitka command for transcribe_audio.py

nuitka --standalone ^
  --onefile ^
  --msvc=14.3 ^
  --show-progress ^
  --follow-imports ^
  --enable-plugin=torch ^
  --include-package=whisper ^
  --include-package=requests ^
  --include-package=transformers ^
  --include-package=tokenizers ^
  --include-package=ffmpeg ^
  --include-data-dir=%VIRTUAL_ENV%\Lib\site-packages\whisper=whisper ^
  --include-data-dir=%VIRTUAL_ENV%\Lib\site-packages\torch=torch ^
  transcribe_audio.py

Nuitka command for generate_model.py

nuitka --standalone ^
  --onefile ^
  --msvc=14.3 ^
  --show-progress ^
  --follow-imports ^
  --include-package=requests ^
  --include-package=diffusers ^
  --include-package=transformers ^
  --include-package=filelock ^
  --include-package=importlib_metadata ^
  --include-package=safetensors ^
  --include-package=packaging ^
  --include-package=tqdm ^
  --include-package=regex ^
  --include-package=numpy ^
  --include-package=torchaudio ^
  --include-package=matplotlib ^
  --include-package=trimesh ^
  --include-package=PIL ^
  --include-package=transformers.models ^
  --include-package=transformers.models.clip ^
  --include-package=transformers.models.clip.processing_clip ^
  --include-package=transformers.models.clip.image_processing_clip ^
  --include-package=transformers.image_processing_utils ^
  --include-package-data=PIL ^
  --include-package-data=requests ^
  --include-package-data=diffusers ^
  --include-package-data=transformers ^
  --include-package-data=filelock ^
  --include-package-data=importlib_metadata ^
  --include-package-data=safetensors ^
  --include-package-data=packaging ^
  --include-package-data=tqdm ^
  --include-package-data=regex ^
  --include-package-data=numpy ^
  --include-package-data=torchaudio ^
  --include-package-data=matplotlib ^
  --include-package-data=trimesh ^
  --include-distribution-metadata=requests,diffusers,transformers,filelock,importlib_metadata,safetensors,packaging,tqdm,regex,numpy,torchaudio,matplotlib,trimesh,Pillow ^
  --include-data-files=input.json=input.json ^
  --include-module=transformers.models.clip.image_processing_clip ^
  --include-module=transformers.image_processing_utils ^
  --enable-plugin=numpy ^
  --enable-plugin=torch ^
  --include-package=tsr ^
  --include-package=tsr.models ^
  --include-package=tsr.models.tokenizers ^
  --include-package=tsr.models.transformer ^
  --include-module=tsr.models.isosurface ^
  --include-module=tsr.models.nerf_renderer ^
  --include-module=tsr.models.network_utils ^
  --include-package=tsr.utils ^
  --nofollow-import-to=transformers.utils._lazy_module ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\requests-2.32.4.dist-info"=requests-2.32.4.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\diffusers-0.34.0.dist-info"=diffusers-0.34.0.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\transformers-4.53.2.dist-info"=transformers-4.53.2.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\filelock-3.13.1.dist-info"=filelock-3.13.1.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\importlib_metadata-8.7.0.dist-info"=importlib_metadata-8.7.0.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\safetensors-0.5.3.dist-info"=safetensors-0.5.3.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\packaging-25.0.dist-info"=packaging-25.0.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\tqdm-4.67.1.dist-info"=tqdm-4.67.1.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\regex-2024.11.6.dist-info"=regex-2024.11.6.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\numpy-2.1.2.dist-info"=numpy-2.1.2.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\torchaudio-2.7.1+cpu.dist-info"=torchaudio-2.7.1+cpu.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\matplotlib-3.10.3.dist-info"=matplotlib-3.10.3.dist-info ^
  --include-data-dir="C:\Users\Arnab\Repos\TripoSR\sr-venv\Lib\site-packages\pillow-11.0.0.dist-info"=pillow-11.0.0.dist-info ^
  generate_model.py

  Nuitka command for generate_image.py

  nuitka --standalone ^
  --onefile ^
  --msvc=14.3 ^
  --show-progress ^
  --follow-imports ^
  --include-package=requests ^
  --include-package=diffusers ^
  --include-package=transformers ^
  --include-package=filelock ^
  --include-package=importlib_metadata ^
  --include-package=safetensors ^
  --include-package=packaging ^
  --include-package=tqdm ^
  --include-package=regex ^
  --include-package=numpy ^
  --include-package=torchaudio ^
  --include-package=matplotlib ^
  --include-package=trimesh ^
  --include-package=PIL ^
  --include-package=transformers.models ^
  --include-package=transformers.models.clip ^
  --include-package=transformers.models.clip.processing_clip ^
  --include-package=transformers.models.clip.image_processing_clip ^
  --include-package=transformers.image_processing_utils ^
  --include-package-data=PIL ^
  --include-package-data=requests ^
  --include-package-data=diffusers ^
  --include-package-data=transformers ^
  --include-package-data=filelock ^
  --include-package-data=importlib_metadata ^
  --include-package-data=safetensors ^
  --include-package-data=packaging ^
  --include-package-data=tqdm ^
  --include-package-data=regex ^
  --include-package-data=numpy ^
  --include-package-data=torchaudio ^
  --include-package-data=matplotlib ^
  --include-package-data=trimesh ^
  --include-distribution-metadata=requests,diffusers,transformers,filelock,importlib_metadata,safetensors,packaging,tqdm,regex,numpy,torchaudio,matplotlib,trimesh,Pillow ^
  --include-module=transformers.models.clip.image_processing_clip ^
  --include-module=transformers.image_processing_utils ^
  --enable-plugin=numpy ^
  --enable-plugin=torch ^
  --nofollow-import-to=transformers.utils._lazy_module ^
  generate_image.py

