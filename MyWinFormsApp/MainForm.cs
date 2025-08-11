//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Text.Json;
//using System.Windows.Forms;
//using NAudio.Wave;

//namespace ShapE_GUI
//{
//    public partial class MainForm : Form
//    {
//        private WaveInEvent waveIn;
//        private WaveFileWriter writer;
//        private string recordedFilePath;

//        public MainForm()
//        {
//            InitializeComponent();
//            ApplyTheme();
//        }

//        private void ApplyTheme()
//        {
//            this.BackColor = System.Drawing.Color.Black;
//            txtPrompt.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
//            txtPrompt.ForeColor = System.Drawing.Color.White;
//            txtPrompt.BorderStyle = BorderStyle.FixedSingle;

//            btnGenerate.BackColor = System.Drawing.Color.MediumPurple;
//            btnGenerate.ForeColor = System.Drawing.Color.White;
//            btnGenerate.FlatStyle = FlatStyle.Flat;
//            btnGenerate.FlatAppearance.BorderSize = 0;

//            btnTranscribe.BackColor = System.Drawing.Color.Teal;
//            btnTranscribe.ForeColor = System.Drawing.Color.White;
//            btnTranscribe.FlatStyle = FlatStyle.Flat;
//            btnTranscribe.FlatAppearance.BorderSize = 0;

//            btnRecord.BackColor = System.Drawing.Color.IndianRed;
//            btnRecord.ForeColor = System.Drawing.Color.White;
//            btnRecord.FlatStyle = FlatStyle.Flat;
//            btnRecord.FlatAppearance.BorderSize = 0;
//        }


//        private void SetButtonsEnabled(bool enabled)
//        {
//            btnGenerate.Enabled = enabled;
//            btnTranscribe.Enabled = enabled;
//            btnRecord.Enabled = enabled;
//        }

//        private void btnRecord_Click(object sender, EventArgs e)
//        {
//            recordedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "recorded.wav");

//            waveIn = new WaveInEvent();
//            waveIn.WaveFormat = new WaveFormat(44100, 1); // mono, 44.1kHz
//            waveIn.DataAvailable += OnDataAvailable;
//            waveIn.RecordingStopped += OnRecordingStopped;

//            writer = new WaveFileWriter(recordedFilePath, waveIn.WaveFormat);
//            waveIn.StartRecording();

//            btnRecord.Text = "Stop Recording";
//            btnRecord.Click -= btnRecord_Click;
//            btnRecord.Click += btnStop_Click;
//        }

//        private void btnStop_Click(object sender, EventArgs e)
//        {
//            waveIn.StopRecording();
//        }

//        private void OnDataAvailable(object sender, WaveInEventArgs e)
//        {
//            if (writer != null)
//            {
//                writer.Write(e.Buffer, 0, e.BytesRecorded);
//                writer.Flush();
//            }
//        }

//        private void OnRecordingStopped(object sender, StoppedEventArgs e)
//        {
//            writer?.Dispose();
//            writer = null;
//            waveIn.Dispose();

//            btnRecord.Text = "Record from Mic";
//            btnRecord.Click -= btnStop_Click;
//            btnRecord.Click += btnRecord_Click;

//            TranscribeAudio(recordedFilePath);
//        }

//        private void btnTranscribe_Click(object sender, EventArgs e)
//        {
//            string recordedFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "recorded.wav");

//            if (!File.Exists(recordedFile))
//            {
//                MessageBox.Show("No recorded audio found. Please record first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            TranscribeAudio(recordedFile);
//        }

//        private void TranscribeAudio(string audioPath)
//        {
//            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "transcribe_audio.exe");

//            if (!File.Exists(exePath))
//            {
//                MessageBox.Show("transcribe_audio.exe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            SetButtonsEnabled(false);
//            lblStatus.Text = "Transcribing...";

//            ProcessStartInfo psi = new ProcessStartInfo
//            {
//                FileName = exePath,
//                Arguments = $"\"{audioPath}\"",
//                UseShellExecute = false,
//                CreateNoWindow = true
//            };

//            try
//            {
//                using (var process = Process.Start(psi))
//                {
//                    process.WaitForExit();
//                }

//                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "speech_text.json");

//                if (File.Exists(jsonPath))
//                {
//                    string jsonContent = File.ReadAllText(jsonPath);
//                    var jsonDoc = JsonDocument.Parse(jsonContent);
//                    string transcript = jsonDoc.RootElement.GetProperty("transcript").GetString();

//                    txtPrompt.Text = transcript;
//                    MessageBox.Show("Transcription successful!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                else
//                {
//                    MessageBox.Show("speech_text.json not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error during transcription: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            finally
//            {
//                SetButtonsEnabled(true);
//                lblStatus.Text = "";
//            }
//        }

//        private void btnGenerate_Click(object sender, EventArgs e)
//        {
//            string prompt = txtPrompt.Text.Trim();

//            if (string.IsNullOrWhiteSpace(prompt))
//            {
//                MessageBox.Show("Please enter a valid prompt.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            var settings = new { prompt = prompt };
//            string json = JsonSerializer.Serialize(settings);
//            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.json");
//            File.WriteAllText(jsonPath, json);

//            SetButtonsEnabled(false);
//            lblStatus.Text = "Generating...";

//            try
//            {
//                string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "generate_model.exe");

//                var psi = new ProcessStartInfo
//                {
//                    FileName = exePath,
//                    Arguments = "input.json",
//                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
//                    UseShellExecute = false,
//                    CreateNoWindow = true
//                };

//                var process = Process.Start(psi);
//                process.WaitForExit();

//                MessageBox.Show("3D model generated successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Failed to run model generator: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            finally
//            {
//                SetButtonsEnabled(true);
//                lblStatus.Text = "";
//            }
//        }
//    }
//}




using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace ParadiseDesignerAI
{
    public partial class MainForm : Form
    {
        private WaveInEvent waveIn;
        private WaveFileWriter writer;
        private string recordedFilePath;

        private AppSettings settings;
        private System.Windows.Forms.Timer statusTimer;
        private Stopwatch stopwatch;

        public MainForm()
        {
            InitializeComponent();

            // Load settings
            settings = SettingsManager.Load();

            ApplyTheme();
            LoadMicrophones();
            LoadSettingsToUI();

            SetupEvents();
            SetupTimer();
        }

        private void ApplyTheme()
        {
            // Form and controls already styled in Designer, so minimal here
            // You can add any runtime styling here if needed
        }

        private void LoadMicrophones()
        {
            cmbMicrophones.Items.Clear();

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var caps = WaveIn.GetCapabilities(i);
                cmbMicrophones.Items.Add(caps.ProductName);
            }

            if (!string.IsNullOrEmpty(settings.Microphone))
            {
                int index = cmbMicrophones.Items.IndexOf(settings.Microphone);
                if (index >= 0) cmbMicrophones.SelectedIndex = index;
                else cmbMicrophones.SelectedIndex = 0;
            }
            else if (cmbMicrophones.Items.Count > 0)
            {
                cmbMicrophones.SelectedIndex = 0;
            }
        }

        private void LoadSettingsToUI()
        {
            txtPrompt.Text = settings.prompt ?? "";
            txtFileName.Text = "";
            lblStatus.Text = "";
            lblTimer.Text = "";
        }

        private void SetupEvents()
        {
            cmbMicrophones.SelectedIndexChanged += CmbMicrophones_SelectedIndexChanged;

            btnRecordMic.Click += BtnRecordMic_Click;
            btnGenerate3D.Click += BtnGenerate3D_Click;
            btnGenerateImage.Click += BtnGenerateImage_Click;

            btnOpenImageFolder.Click += BtnOpenImageFolder_Click;
            btnOpen3DFolder.Click += BtnOpen3DFolder_Click;
            btnImportToGame.Click += BtnImportToGame_Click;
            btnViewObjects.Click += BtnViewObjects_Click;

            btnAbout.Click += BtnAbout_Click;
            btnHelp.Click += BtnHelp_Click;
        }

        private void SetupTimer()
        {
            stopwatch = new Stopwatch();
            statusTimer = new System.Windows.Forms.Timer();
            statusTimer.Interval = 1000; // 1 second
            statusTimer.Tick += StatusTimer_Tick;
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            var elapsed = stopwatch.Elapsed;
            lblTimer.Text = $"{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
        }

        private void UpdateStatus(string message, bool startTimer = true)
        {
            lblStatus.Text = message;
            if (startTimer)
            {
                stopwatch.Restart();
                statusTimer.Start();
            }
            else
            {
                statusTimer.Stop();
                stopwatch.Reset();
                lblTimer.Text = "";
            }
        }

        private void CmbMicrophones_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.Microphone = cmbMicrophones.SelectedItem?.ToString() ?? "";
            SettingsManager.Save(settings);
        }

        private void BtnRecordMic_Click(object sender, EventArgs e)
        {
            if (waveIn != null)
            {
                StopRecording();
                return;
            }

            StartRecording();
        }

        private void StartRecording()
        {
            if (cmbMicrophones.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a microphone first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int deviceNumber = cmbMicrophones.SelectedIndex;
            recordedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "recorded.wav");
            Directory.CreateDirectory(Path.GetDirectoryName(recordedFilePath));

            waveIn = new WaveInEvent
            {
                DeviceNumber = deviceNumber,
                WaveFormat = new WaveFormat(44100, 1) // mono, 44.1kHz
            };
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;

            writer = new WaveFileWriter(recordedFilePath, waveIn.WaveFormat);
            waveIn.StartRecording();

            btnRecordMic.Text = "Stop Recording";
            SetButtonsEnabled(false, exceptRecord: true);

            UpdateStatus("Recording Audio...");
        }

        private void StopRecording()
        {
            waveIn?.StopRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            writer?.Write(e.Buffer, 0, e.BytesRecorded);
            writer?.Flush();
        }

        private async void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            writer?.Dispose();
            writer = null;

            waveIn.Dispose();
            waveIn = null;

            btnRecordMic.Text = "Record from Microphone";
            SetButtonsEnabled(true);

            UpdateStatus("Transcribing your Speech...");

            await Task.Run(() => TranscribeAudio(recordedFilePath));

            UpdateStatus("", false);
        }

        private void SetButtonsEnabled(bool enabled, bool exceptRecord = false)
        {
            if (!exceptRecord) btnRecordMic.Enabled = enabled;
            btnGenerate3D.Enabled = enabled;
            btnGenerateImage.Enabled = enabled;
            btnOpenImageFolder.Enabled = enabled;
            btnOpen3DFolder.Enabled = enabled;
            btnImportToGame.Enabled = enabled;
            btnViewObjects.Enabled = enabled;
            btnAbout.Enabled = enabled;
            btnHelp.Enabled = enabled;
        }

        private void TranscribeAudio(string audioPath)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings.Speech_AI_Model_path, settings.Speech_AI_Model_filename);

            if (!File.Exists(exePath))
            {
                MessageBox.Show("Speech AI model executable not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = $"\"{audioPath}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(psi))
                {
                    process.WaitForExit();
                }

                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "speech_text.json");
                if (File.Exists(jsonPath))
                {
                    string jsonContent = File.ReadAllText(jsonPath);
                    dynamic jsonObj = JsonConvert.DeserializeObject(jsonContent);
                    string transcript = jsonObj?.transcript ?? "";

                    settings.transcript = transcript;
                    settings.prompt = transcript;
                    SettingsManager.Save(settings);

                    // Update UI in UI thread
                    this.Invoke(() => txtPrompt.Text = transcript);

                    MessageBox.Show("Transcription successful!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Transcription output file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during transcription: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerate3D_Click(object sender, EventArgs e)
        {
            RunGeneration(true);
        }

        private void BtnGenerateImage_Click(object sender, EventArgs e)
        {
            RunGeneration(false);
        }

        private async void RunGeneration(bool is3D)
        {
            string prompt = txtPrompt.Text.Trim();
            string fileName = txtFileName.Text.Trim();

            if (string.IsNullOrWhiteSpace(prompt))
            {
                MessageBox.Show("Please enter a valid prompt.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                MessageBox.Show("Please enter a valid file name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save prompt and file name to settings
            settings.prompt = prompt;
            SettingsManager.Save(settings);

            string modelPath = is3D ? settings._3D_AI_Model_path : settings.Image_AI_Model_path;
            string exeName = is3D ? settings._3D_AI_Model_filename : settings.Image_AI_Model_filename;

            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, modelPath, exeName);
            if (!File.Exists(exePath))
            {
                MessageBox.Show($"AI model executable not found:\n{exePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string inputJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.json");

            var inputObj = new
            {
                prompt = prompt,
                fileName = fileName
            };

            string jsonText = JsonConvert.SerializeObject(inputObj, Formatting.Indented);
            File.WriteAllText(inputJsonPath, jsonText);

            SetButtonsEnabled(false, exceptRecord: true);

            UpdateStatus(is3D ? "Generating 3D Object now..." : "Generating Image now...");

            await Task.Run(() =>
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = exePath,
                        Arguments = $"\"{inputJsonPath}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WorkingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, modelPath)
                    };

                    using (var process = Process.Start(psi))
                    {
                        process.WaitForExit();
                    }

                    // Copy output folders contents to permanent folders without overwriting
                    if (is3D)
                    {
                        string output3DDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output", "3d", "3d");
                        string outputObjDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output", "3d", "obj");
                        string permanent3DDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "3D");
                        string permanentObjDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "objects");

                        FileHelper.CopyFolderWithoutOverwriting(output3DDir, permanent3DDir);
                        FileHelper.CopyFolderWithoutOverwriting(outputObjDir, permanentObjDir);
                    }
                    else
                    {
                        string outputImageDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output", "image");
                        string permanentImageDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                        FileHelper.CopyFolderWithoutOverwriting(outputImageDir, permanentImageDir);
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(() => MessageBox.Show("Error during generation:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
            });

            SetButtonsEnabled(true);
            UpdateStatus("", false);

            MessageBox.Show(is3D ? "3D model generated successfully!" : "Image generated successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnOpenImageFolder_Click(object sender, EventArgs e)
        {
            string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
            FileHelper.OpenFolder(imagesDir);
        }

        private void BtnOpen3DFolder_Click(object sender, EventArgs e)
        {
            string objectsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "objects");
            FileHelper.OpenFolder(objectsDir);
        }

        private void BtnImportToGame_Click(object sender, EventArgs e)
        {
            string objectsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "3D");
            string importDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "import");

            FileHelper.Import3DModelToGame(objectsDir, importDir);
        }

        private void BtnViewObjects_Click(object sender, EventArgs e)
        {
            string objectsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "objects");
            FileHelper.OpenFolder(objectsDir);

            MessageBox.Show("Redirecting to a website to view the 3D object. Drag and drop your object.", "3D Viewer", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start(new ProcessStartInfo
            {
                FileName = "https://3dviewer.net/",
                UseShellExecute = true
            });
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Paradise Designer AI Images and Models\nVersion 1.0\n© 2025 Your Company", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            string helpFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.html");

            if (File.Exists(helpFilePath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = helpFilePath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to open help file:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Help file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
