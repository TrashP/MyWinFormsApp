//using Newtonsoft.Json;
//using System;
//using System.IO;
//using System.Xml;

//namespace ParadiseDesignerAI
//{
//    public class AppSettings
//    {
//        public string Microphone { get; set; }
//        public string _3D_AI_Model_path { get; set; }
//        public string Image_AI_Model_path { get; set; }
//        public string Speech_AI_Model_path { get; set; }
//        public string _3D_AI_Model_filename { get; set; }
//        public string Image_AI_Model_filename { get; set; }
//        public string Speech_AI_Model_filename { get; set; }
//        public string prompt { get; set; }
//        public string transcript { get; set; }
//    }

//    public static class SettingsManager
//    {
//        private static readonly string settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

//        public static AppSettings Load()
//        {
//            if (!File.Exists(settingsFilePath))
//            {
//                var defaultSettings = new AppSettings
//                {
//                    Microphone = "",
//                    _3D_AI_Model_path = "dist/",
//                    Image_AI_Model_path = "dist/",
//                    Speech_AI_Model_path = "dist/",
//                    _3D_AI_Model_filename = "generate_model.exe",
//                    Image_AI_Model_filename = "generate_image.exe",
//                    Speech_AI_Model_filename = "transcribe_audio.exe",
//                    prompt = "",
//                    transcript = ""
//                };
//                Save(defaultSettings);
//                return defaultSettings;
//            }

//            var json = File.ReadAllText(settingsFilePath);
//            return JsonConvert.DeserializeObject<AppSettings>(json);
//        }

//        public static void Save(AppSettings settings)
//        {
//            var json = JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
//            File.WriteAllText(settingsFilePath, json);
//        }
//    }
//}



//using Newtonsoft.Json;
//using System;
//using System.IO;

//namespace ParadiseDesignerAI
//{
//    public class AppSettings
//    {
//        public string Microphone { get; set; }

//        // Model names
//        public string _3D_AI_Model_name { get; set; }
//        public string Image_AI_Model_name { get; set; }
//        public string Speech_AI_Model_name { get; set; }

//        // Paths
//        public string _3D_AI_Model_path { get; set; }
//        public string Image_AI_Model_path { get; set; }
//        public string Speech_AI_Model_path { get; set; }

//        // Filenames
//        public string _3D_AI_Model_filename { get; set; }
//        public string Image_AI_Model_filename { get; set; }
//        public string Speech_AI_Model_filename { get; set; }

//        // User input / output
//        public string prompt { get; set; }
//        public string transcript { get; set; }
//    }

//    public static class SettingsManager
//    {
//        private static readonly string settingsFilePath =
//            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

//        public static AppSettings Load()
//        {
//            if (!File.Exists(settingsFilePath))
//            {
//                var defaultSettings = new AppSettings
//                {
//                    Microphone = "",

//                    _3D_AI_Model_name = "TripoSR",
//                    Image_AI_Model_name = "Stable Diffusion",
//                    Speech_AI_Model_name = "Whisper",

//                    _3D_AI_Model_path = "dist",
//                    Image_AI_Model_path = "dist",
//                    Speech_AI_Model_path = "dist",

//                    _3D_AI_Model_filename = "generate_model.exe",
//                    Image_AI_Model_filename = "generate_image.exe",
//                    Speech_AI_Model_filename = "transcribe_audio.exe",

//                    prompt = "",
//                    transcript = ""
//                };

//                Save(defaultSettings);
//                return defaultSettings;
//            }

//            var json = File.ReadAllText(settingsFilePath);
//            return JsonConvert.DeserializeObject<AppSettings>(json);
//        }

//        public static void Save(AppSettings settings)
//        {
//            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
//            File.WriteAllText(settingsFilePath, json);
//        }
//    }
//}



//using System;
//using System.IO;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//public class AppSettings
//{
//    // Editable by user
//    public string Microphone { get; set; }
//    public string prompt { get; set; }
//    public string transcript { get; set; }

//    // Read-only to UI, writable internally
//    public string _3D_AI_Model_name { get; internal set; }
//    public string Image_AI_Model_name { get; internal set; }
//    public string Speech_AI_Model_name { get; internal set; }

//    public string _3D_AI_Model_path { get; internal set; }
//    public string Image_AI_Model_path { get; internal set; }
//    public string Speech_AI_Model_path { get; internal set; }

//    public string _3D_AI_Model_filename { get; internal set; }
//    public string Image_AI_Model_filename { get; internal set; }
//    public string Speech_AI_Model_filename { get; internal set; }
//}

//public static class SettingsManager
//{
//    private static readonly string SettingsFile = "settings.json";
//    public static AppSettings Current { get; private set; }

//    // Load settings.json
//    public static void Load()
//    {
//        if (!File.Exists(SettingsFile))
//        {
//            Current = new AppSettings();
//            Save();
//            return;
//        }

//        string json = File.ReadAllText(SettingsFile);
//        dynamic raw = JsonConvert.DeserializeObject(json);

//        Current = new AppSettings
//        {
//            Microphone = raw["Microphone"],
//            prompt = raw["prompt"],
//            transcript = raw["transcript"],

//            _3D_AI_Model_name = raw["3D_AI_Model_name"],
//            Image_AI_Model_name = raw["Image_AI_Model_name"],
//            Speech_AI_Model_name = raw["Speech_AI_Model_name"],

//            _3D_AI_Model_path = raw["3D_AI_Model_path"],
//            Image_AI_Model_path = raw["Image_AI_Model_path"],
//            Speech_AI_Model_path = raw["Speech_AI_Model_path"],

//            _3D_AI_Model_filename = raw["3D_AI_Model_filename"],
//            Image_AI_Model_filename = raw["Image_AI_Model_filename"],
//            Speech_AI_Model_filename = raw["Speech_AI_Model_filename"]
//        };
//    }

//    // Save only affected fields
//    public static void Save()
//    {
//        JObject jsonObj;

//        if (File.Exists(SettingsFile))
//        {
//            string existing = File.ReadAllText(SettingsFile);
//            jsonObj = JObject.Parse(existing);
//        }
//        else
//        {
//            jsonObj = new JObject();
//        }

//        // update only editable fields
//        jsonObj["Microphone"] = Current.Microphone;
//        jsonObj["prompt"] = Current.prompt;
//        jsonObj["transcript"] = Current.transcript;

//        // leave AI model fields untouched

//        File.WriteAllText(SettingsFile, jsonObj.ToString(Formatting.Indented));
//    }
//}




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
