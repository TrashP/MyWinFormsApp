import whisper
import sys
import json
import os
import shutil

def patch_ffmpeg_path():
    """
    Temporarily modify PATH so whisper uses the local ffmpeg.exe bundled with the app.
    """
    exe_dir = os.path.dirname(os.path.abspath(sys.argv[0]))
    ffmpeg_path = os.path.join(exe_dir, "ffmpeg.exe")

    if not os.path.exists(ffmpeg_path):
        print(f"Error: ffmpeg.exe not found in {exe_dir}")
        sys.exit(1)

    os.environ["PATH"] = exe_dir + os.pathsep + os.environ["PATH"]

def transcribe(audio_path):
    model = whisper.load_model("base")  # Use "small" or "medium" for better accuracy
    result = model.transcribe(audio_path)
    return result["text"]

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Usage: transcribe_audio.exe path_to_audio.wav")
        sys.exit(1)

    patch_ffmpeg_path()  # ensure ffmpeg is accessible from the local folder

    text = transcribe(sys.argv[1])
    with open("speech_text.json", "w") as f:
        json.dump({"transcript": text}, f)
