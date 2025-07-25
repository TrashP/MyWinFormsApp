//namespace ShapE_GUI
//{
//    partial class MainForm
//    {
//        private System.ComponentModel.IContainer components = null;
//        private System.Windows.Forms.Button btnTranscribe;
//        private System.Windows.Forms.Button btnRecord;
//        private System.Windows.Forms.TextBox txtPrompt;
//        private System.Windows.Forms.Button btnGenerate;
//        private System.Windows.Forms.ProgressBar progressBar;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.txtPrompt = new System.Windows.Forms.TextBox();
//            this.progressBar = new System.Windows.Forms.ProgressBar();
//            this.btnGenerate = new System.Windows.Forms.Button();
//            this.btnTranscribe = new System.Windows.Forms.Button();
//            this.btnRecord = new System.Windows.Forms.Button();

//            this.SuspendLayout();

//            // txtPrompt
//            this.txtPrompt.Location = new System.Drawing.Point(30, 30);
//            this.txtPrompt.Multiline = true;
//            this.txtPrompt.Size = new System.Drawing.Size(740, 100);
//            this.txtPrompt.Name = "txtPrompt";

//            // progressBar
//            this.progressBar.Location = new System.Drawing.Point(30, 140);
//            this.progressBar.Size = new System.Drawing.Size(740, 15);
//            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
//            this.progressBar.MarqueeAnimationSpeed = 0;
//            this.progressBar.Visible = false;
//            this.progressBar.Name = "progressBar";

//            // btnRecord
//            this.btnRecord.Location = new System.Drawing.Point(30, 180);
//            this.btnRecord.Size = new System.Drawing.Size(180, 40);
//            this.btnRecord.Name = "btnRecord";
//            this.btnRecord.Text = "Record from Mic";
//            this.btnRecord.UseVisualStyleBackColor = true;
//            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);

//            // btnTranscribe
//            this.btnTranscribe.Location = new System.Drawing.Point(240, 180);
//            this.btnTranscribe.Size = new System.Drawing.Size(220, 40);
//            this.btnTranscribe.Name = "btnTranscribe";
//            this.btnTranscribe.Text = "Transcribe Audio File";
//            this.btnTranscribe.UseVisualStyleBackColor = true;
//            this.btnTranscribe.Click += new System.EventHandler(this.btnTranscribe_Click);

//            // btnGenerate
//            this.btnGenerate.Location = new System.Drawing.Point(490, 180);
//            this.btnGenerate.Size = new System.Drawing.Size(280, 40);
//            this.btnGenerate.Name = "btnGenerate";
//            this.btnGenerate.Text = "Generate 3D Model";
//            this.btnGenerate.UseVisualStyleBackColor = true;
//            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

//            // MainForm
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(800, 260);
//            this.Controls.Add(this.txtPrompt);
//            this.Controls.Add(this.progressBar);
//            this.Controls.Add(this.btnRecord);
//            this.Controls.Add(this.btnTranscribe);
//            this.Controls.Add(this.btnGenerate);
//            this.Name = "MainForm";
//            this.Text = "Shap-E Model Generator";
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }
//    }
//}



namespace ShapE_GUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnTranscribe;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.TextBox txtPrompt;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtPrompt = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnTranscribe = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblPrompt
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(20, 20);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(250, 15);
            this.lblPrompt.Text = "Enter a prompt or Record your speech:";
            this.lblPrompt.ForeColor = System.Drawing.Color.White;
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            // txtPrompt
            this.txtPrompt.Location = new System.Drawing.Point(20, 40);
            this.txtPrompt.Multiline = true;  // Must be true for height > 25
            this.txtPrompt.Size = new System.Drawing.Size(540, 80);  // Increased height
            this.txtPrompt.Name = "txtPrompt";
            this.txtPrompt.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtPrompt.ForeColor = System.Drawing.Color.White;
            this.txtPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrompt.WordWrap = true;

            // lblStatus
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 150); // Adjust Y based on layout
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 15);
            this.lblStatus.Text = "";
            this.lblStatus.ForeColor = System.Drawing.Color.LightGray;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);

            // btnGenerate
            this.btnGenerate.Location = new System.Drawing.Point(400, 200);
            this.btnGenerate.Size = new System.Drawing.Size(160, 40);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.BackColor = System.Drawing.Color.MediumPurple;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            // btnTranscribe
            this.btnTranscribe.Location = new System.Drawing.Point(210, 200);
            this.btnTranscribe.Size = new System.Drawing.Size(160, 40);
            this.btnTranscribe.Name = "btnTranscribe";
            this.btnTranscribe.Text = "Transcribe Audio File";
            this.btnTranscribe.UseVisualStyleBackColor = false;
            this.btnTranscribe.BackColor = System.Drawing.Color.Teal;
            this.btnTranscribe.ForeColor = System.Drawing.Color.White;
            this.btnTranscribe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTranscribe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranscribe.FlatAppearance.BorderSize = 0;
            this.btnTranscribe.Click += new System.EventHandler(this.btnTranscribe_Click);

            // btnRecord
            this.btnRecord.Location = new System.Drawing.Point(20, 200);
            this.btnRecord.Size = new System.Drawing.Size(160, 40);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Text = "Record from Mic";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.BackColor = System.Drawing.Color.IndianRed;
            this.btnRecord.ForeColor = System.Drawing.Color.White;
            this.btnRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.FlatAppearance.BorderSize = 0;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtPrompt);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnTranscribe);
            this.Controls.Add(this.btnRecord);
            this.Name = "MainForm";
            this.Text = "Shap-E Model Generator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


