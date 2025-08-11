using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;

namespace ParadiseDesignerAI
{
    public class AppSettings
    {
        public string Microphone { get; set; }
        public string _3D_AI_Model_path { get; set; }
        public string Image_AI_Model_path { get; set; }
        public string Speech_AI_Model_path { get; set; }
        public string _3D_AI_Model_filename { get; set; }
        public string Image_AI_Model_filename { get; set; }
        public string Speech_AI_Model_filename { get; set; }
        public string prompt { get; set; }
        public string transcript { get; set; }
    }

    public static class SettingsManager
    {
        private static readonly string settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        public static AppSettings Load()
        {
            if (!File.Exists(settingsFilePath))
            {
                var defaultSettings = new AppSettings
                {
                    Microphone = "",
                    _3D_AI_Model_path = "dist/",
                    Image_AI_Model_path = "dist/",
                    Speech_AI_Model_path = "dist/",
                    _3D_AI_Model_filename = "generate_model.exe",
                    Image_AI_Model_filename = "generate_image.exe",
                    Speech_AI_Model_filename = "transcribe_audio.exe",
                    prompt = "",
                    transcript = ""
                };
                Save(defaultSettings);
                return defaultSettings;
            }

            var json = File.ReadAllText(settingsFilePath);
            return JsonConvert.DeserializeObject<AppSettings>(json);
        }

        public static void Save(AppSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(settingsFilePath, json);
        }
    }
}
