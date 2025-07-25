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

//            try
//            {
//                string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "generate_model.exe");

//                var psi = new ProcessStartInfo
//                {
//                    FileName = exePath,
//                    Arguments = "input.json",  // Pass input.json as an argument
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
//        }

//    }
//}



using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using NAudio.Wave;

namespace ShapE_GUI
{
    public partial class MainForm : Form
    {
        private WaveInEvent waveIn;
        private WaveFileWriter writer;
        private string recordedFilePath;

        public MainForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            this.BackColor = System.Drawing.Color.Black;
            txtPrompt.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            txtPrompt.ForeColor = System.Drawing.Color.White;
            txtPrompt.BorderStyle = BorderStyle.FixedSingle;

            btnGenerate.BackColor = System.Drawing.Color.MediumPurple;
            btnGenerate.ForeColor = System.Drawing.Color.White;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.FlatAppearance.BorderSize = 0;

            btnTranscribe.BackColor = System.Drawing.Color.Teal;
            btnTranscribe.ForeColor = System.Drawing.Color.White;
            btnTranscribe.FlatStyle = FlatStyle.Flat;
            btnTranscribe.FlatAppearance.BorderSize = 0;

            btnRecord.BackColor = System.Drawing.Color.IndianRed;
            btnRecord.ForeColor = System.Drawing.Color.White;
            btnRecord.FlatStyle = FlatStyle.Flat;
            btnRecord.FlatAppearance.BorderSize = 0;
        }


        private void SetButtonsEnabled(bool enabled)
        {
            btnGenerate.Enabled = enabled;
            btnTranscribe.Enabled = enabled;
            btnRecord.Enabled = enabled;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            recordedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "recorded.wav");

            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(44100, 1); // mono, 44.1kHz
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;

            writer = new WaveFileWriter(recordedFilePath, waveIn.WaveFormat);
            waveIn.StartRecording();

            btnRecord.Text = "Stop Recording";
            btnRecord.Click -= btnRecord_Click;
            btnRecord.Click += btnStop_Click;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            waveIn.StopRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (writer != null)
            {
                writer.Write(e.Buffer, 0, e.BytesRecorded);
                writer.Flush();
            }
        }

        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            writer?.Dispose();
            writer = null;
            waveIn.Dispose();

            btnRecord.Text = "Record from Mic";
            btnRecord.Click -= btnStop_Click;
            btnRecord.Click += btnRecord_Click;

            TranscribeAudio(recordedFilePath);
        }

        private void btnTranscribe_Click(object sender, EventArgs e)
        {
            string recordedFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "recorded.wav");

            if (!File.Exists(recordedFile))
            {
                MessageBox.Show("No recorded audio found. Please record first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TranscribeAudio(recordedFile);
        }

        private void TranscribeAudio(string audioPath)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "transcribe_audio.exe");

            if (!File.Exists(exePath))
            {
                MessageBox.Show("transcribe_audio.exe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetButtonsEnabled(false);
            lblStatus.Text = "Transcribing...";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = $"\"{audioPath}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (var process = Process.Start(psi))
                {
                    process.WaitForExit();
                }

                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "speech_text.json");

                if (File.Exists(jsonPath))
                {
                    string jsonContent = File.ReadAllText(jsonPath);
                    var jsonDoc = JsonDocument.Parse(jsonContent);
                    string transcript = jsonDoc.RootElement.GetProperty("transcript").GetString();

                    txtPrompt.Text = transcript;
                    MessageBox.Show("Transcription successful!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("speech_text.json not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during transcription: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonsEnabled(true);
                lblStatus.Text = "";
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string prompt = txtPrompt.Text.Trim();

            if (string.IsNullOrWhiteSpace(prompt))
            {
                MessageBox.Show("Please enter a valid prompt.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var settings = new { prompt = prompt };
            string json = JsonSerializer.Serialize(settings);
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.json");
            File.WriteAllText(jsonPath, json);

            SetButtonsEnabled(false);
            lblStatus.Text = "Generating...";

            try
            {
                string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "generate_model.exe");

                var psi = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = "input.json",
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(psi);
                process.WaitForExit();

                MessageBox.Show("3D model generated successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run model generator: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonsEnabled(true);
                lblStatus.Text = "";
            }
        }
    }
}
