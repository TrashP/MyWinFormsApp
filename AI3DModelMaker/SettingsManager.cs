using Newtonsoft.Json;
using System;
using System.IO;

namespace ParadiseDesignerAI
{
    public class AppSettings
    {
        public string Microphone { get; set; }
        public string prompt { get; set; }
        public string transcript { get; set; }

        // Read-only properties for AI models
        public string _3D_AI_Model_name { get; } = "TripoSR";
        public string Image_AI_Model_name { get; } = "Stable Diffusion";
        public string Speech_AI_Model_name { get; } = "Whisper";

        public string _3D_AI_Model_path { get; } = "dist";
        public string Image_AI_Model_path { get; } = "dist";
        public string Speech_AI_Model_path { get; } = "dist";

        public string _3D_AI_Model_filename { get; } = "generate_model.exe";
        public string Image_AI_Model_filename { get; } = "generate_image.exe";
        public string Speech_AI_Model_filename { get; } = "transcribe_audio.exe";
    }

    public static class SettingsManager
    {
        private static readonly string settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");
        public static AppSettings Current { get; private set; }

        public static void Load()
        {
            if (!File.Exists(settingsFilePath))
            {
                Current = new AppSettings();
                Save(); // create default file
                return;
            }

            try
            {
                var json = File.ReadAllText(settingsFilePath);
                var loadedSettings = JsonConvert.DeserializeObject<AppSettings>(json);

                if (loadedSettings == null)
                    loadedSettings = new AppSettings();

                // Only assign editable fields
                Current = new AppSettings
                {
                    Microphone = loadedSettings.Microphone,
                    prompt = loadedSettings.prompt,
                    transcript = loadedSettings.transcript
                };
            }
            catch
            {
                Current = new AppSettings();
                Save();
            }
        }

        public static void Save()
        {
            if (Current == null)
                Current = new AppSettings();

            // Only save editable fields, keep read-only fields intact
            var jsonObj = new
            {
                Microphone = Current.Microphone,
                prompt = Current.prompt,
                transcript = Current.transcript,
                _3D_AI_Model_name = Current._3D_AI_Model_name,
                Image_AI_Model_name = Current.Image_AI_Model_name,
                Speech_AI_Model_name = Current.Speech_AI_Model_name,
                _3D_AI_Model_path = Current._3D_AI_Model_path,
                Image_AI_Model_path = Current.Image_AI_Model_path,
                Speech_AI_Model_path = Current.Speech_AI_Model_path,
                _3D_AI_Model_filename = Current._3D_AI_Model_filename,
                Image_AI_Model_filename = Current.Image_AI_Model_filename,
                Speech_AI_Model_filename = Current.Speech_AI_Model_filename
            };

            var json = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(settingsFilePath, json);
        }
    }
}
