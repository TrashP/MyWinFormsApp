//namespace ShapE_GUI
//{
//    partial class MainForm
//    {
//        private System.ComponentModel.IContainer components = null;
//        private System.Windows.Forms.Button btnTranscribe;
//        private System.Windows.Forms.Button btnRecord;
//        private System.Windows.Forms.TextBox txtPrompt;
//        private System.Windows.Forms.Button btnGenerate;
//        private System.Windows.Forms.Label lblPrompt;
//        private System.Windows.Forms.Label lblStatus;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.txtPrompt = new System.Windows.Forms.TextBox();
//            this.btnGenerate = new System.Windows.Forms.Button();
//            this.btnTranscribe = new System.Windows.Forms.Button();
//            this.btnRecord = new System.Windows.Forms.Button();
//            this.SuspendLayout();

//            // lblPrompt
//            this.lblPrompt = new System.Windows.Forms.Label();
//            this.lblPrompt.AutoSize = true;
//            this.lblPrompt.Location = new System.Drawing.Point(20, 20);
//            this.lblPrompt.Name = "lblPrompt";
//            this.lblPrompt.Size = new System.Drawing.Size(250, 15);
//            this.lblPrompt.Text = "Enter a prompt or Record your speech:";
//            this.lblPrompt.ForeColor = System.Drawing.Color.White;
//            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

//            // txtPrompt
//            this.txtPrompt.Location = new System.Drawing.Point(20, 40);
//            this.txtPrompt.Multiline = true;  // Must be true for height > 25
//            this.txtPrompt.Size = new System.Drawing.Size(540, 80);  // Increased height
//            this.txtPrompt.Name = "txtPrompt";
//            this.txtPrompt.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
//            this.txtPrompt.ForeColor = System.Drawing.Color.White;
//            this.txtPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.txtPrompt.WordWrap = true;

//            // lblStatus
//            this.lblStatus = new System.Windows.Forms.Label();
//            this.lblStatus.AutoSize = true;
//            this.lblStatus.Location = new System.Drawing.Point(20, 150); // Adjust Y based on layout
//            this.lblStatus.Name = "lblStatus";
//            this.lblStatus.Size = new System.Drawing.Size(100, 15);
//            this.lblStatus.Text = "";
//            this.lblStatus.ForeColor = System.Drawing.Color.LightGray;
//            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);

//            // btnGenerate
//            this.btnGenerate.Location = new System.Drawing.Point(400, 200);
//            this.btnGenerate.Size = new System.Drawing.Size(160, 40);
//            this.btnGenerate.Name = "btnGenerate";
//            this.btnGenerate.Text = "Generate";
//            this.btnGenerate.UseVisualStyleBackColor = false;
//            this.btnGenerate.BackColor = System.Drawing.Color.MediumPurple;
//            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btnGenerate.ForeColor = System.Drawing.Color.White;
//            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnGenerate.FlatAppearance.BorderSize = 0;
//            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

//            // btnTranscribe
//            this.btnTranscribe.Location = new System.Drawing.Point(210, 200);
//            this.btnTranscribe.Size = new System.Drawing.Size(160, 40);
//            this.btnTranscribe.Name = "btnTranscribe";
//            this.btnTranscribe.Text = "Transcribe Audio File";
//            this.btnTranscribe.UseVisualStyleBackColor = false;
//            this.btnTranscribe.BackColor = System.Drawing.Color.Teal;
//            this.btnTranscribe.ForeColor = System.Drawing.Color.White;
//            this.btnTranscribe.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btnTranscribe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnTranscribe.FlatAppearance.BorderSize = 0;
//            this.btnTranscribe.Click += new System.EventHandler(this.btnTranscribe_Click);

//            // btnRecord
//            this.btnRecord.Location = new System.Drawing.Point(20, 200);
//            this.btnRecord.Size = new System.Drawing.Size(160, 40);
//            this.btnRecord.Name = "btnRecord";
//            this.btnRecord.Text = "Record from Mic";
//            this.btnRecord.UseVisualStyleBackColor = false;
//            this.btnRecord.BackColor = System.Drawing.Color.IndianRed;
//            this.btnRecord.ForeColor = System.Drawing.Color.White;
//            this.btnRecord.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnRecord.FlatAppearance.BorderSize = 0;
//            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);

//            // MainForm
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(600, 400);
//            this.BackColor = System.Drawing.Color.Black;
//            this.Controls.Add(this.lblPrompt);
//            this.Controls.Add(this.txtPrompt);
//            this.Controls.Add(this.lblStatus);
//            this.Controls.Add(this.btnGenerate);
//            this.Controls.Add(this.btnTranscribe);
//            this.Controls.Add(this.btnRecord);
//            this.Name = "MainForm";
//            this.Text = "Shap-E Model Generator";
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }
//    }
//}




namespace ParadiseDesignerAI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblExamplePrompt;

        private System.Windows.Forms.Label lblMic;
        private System.Windows.Forms.ComboBox cmbMicrophones;

        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtPrompt;

        private System.Windows.Forms.Button btnRecordMic;
        private System.Windows.Forms.Button btnGenerate3D;
        private System.Windows.Forms.Button btnGenerateImage;
        private System.Windows.Forms.Button btnOpenImageFolder;
        private System.Windows.Forms.Button btnOpen3DFolder;
        private System.Windows.Forms.Button btnImportToGame;
        private System.Windows.Forms.Button btnViewObjects;

        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnHelp;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTimer;

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
            this.components = new System.ComponentModel.Container();

            // Form
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Text = "Paradise Designer AI Images and Models";
            this.BackColor = System.Drawing.Color.LightGray;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblTitle
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.Text = "Welcome to Paradise Designers AI Images and 3D Model maker application";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 40;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // lblSubtitle
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblSubtitle.Text = "You can create 3D Models for your game by typing into this chat window or speaking to it. Here are some examples you can say:";
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitle.Height = 40;
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);

            // lblExamplePrompt
            this.lblExamplePrompt = new System.Windows.Forms.Label();
            this.lblExamplePrompt.Text = "\"Make a grey bunny rabbit with cute anime eyes, and a black top hat\"";
            this.lblExamplePrompt.AutoSize = false;
            this.lblExamplePrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExamplePrompt.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExamplePrompt.Height = 30;
            this.lblExamplePrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblExamplePrompt.ForeColor = System.Drawing.Color.DimGray;

            // Layout offset variables
            int leftMargin = 20;
            int topStart = 160;
            int controlHeight = 25;
            int labelWidth = 150;
            int spacingY = 35;
            int textBoxWidth = 760;

            // lblMic
            this.lblMic = new System.Windows.Forms.Label();
            this.lblMic.Text = "Choose your Microphone:";
            this.lblMic.Location = new System.Drawing.Point(leftMargin, topStart);
            this.lblMic.Size = new System.Drawing.Size(labelWidth, controlHeight);
            this.lblMic.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // cmbMicrophones
            this.cmbMicrophones = new System.Windows.Forms.ComboBox();
            this.cmbMicrophones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMicrophones.Location = new System.Drawing.Point(leftMargin + labelWidth + 10, topStart - 2);
            this.cmbMicrophones.Size = new System.Drawing.Size(300, controlHeight + 4);

            // lblFileName
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFileName.Text = "Enter your file name:";
            this.lblFileName.Location = new System.Drawing.Point(leftMargin, topStart + spacingY);
            this.lblFileName.Size = new System.Drawing.Size(labelWidth, controlHeight);
            this.lblFileName.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // txtFileName
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFileName.Location = new System.Drawing.Point(leftMargin + labelWidth + 10, topStart + spacingY - 2);
            this.txtFileName.Size = new System.Drawing.Size(300, controlHeight + 4);

            // lblPrompt
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblPrompt.Text = "Enter prompt or use your speech:";
            this.lblPrompt.Location = new System.Drawing.Point(leftMargin, topStart + spacingY * 2);
            this.lblPrompt.Size = new System.Drawing.Size(580, controlHeight);
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // txtPrompt
            this.txtPrompt = new System.Windows.Forms.TextBox();
            this.txtPrompt.Location = new System.Drawing.Point(leftMargin, topStart + spacingY * 2 + controlHeight);
            this.txtPrompt.Multiline = true;
            this.txtPrompt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrompt.Size = new System.Drawing.Size(textBoxWidth, 100);
            this.txtPrompt.BackColor = System.Drawing.Color.White;
            this.txtPrompt.ForeColor = System.Drawing.Color.Black;
            this.txtPrompt.WordWrap = true;

            // Buttons top row Y position
            int buttonsTop = topStart + spacingY * 2 + 140;

            // btnRecordMic
            this.btnRecordMic = new System.Windows.Forms.Button();
            this.btnRecordMic.Text = "Record from Microphone";
            this.btnRecordMic.Location = new System.Drawing.Point(leftMargin, buttonsTop);
            this.btnRecordMic.Size = new System.Drawing.Size(250, 40);
            this.btnRecordMic.BackColor = System.Drawing.Color.IndianRed;
            this.btnRecordMic.ForeColor = System.Drawing.Color.White;
            this.btnRecordMic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecordMic.FlatAppearance.BorderSize = 0;
            this.btnRecordMic.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnGenerate3D
            this.btnGenerate3D = new System.Windows.Forms.Button();
            this.btnGenerate3D.Text = "Generate 3D Object";
            this.btnGenerate3D.Location = new System.Drawing.Point(leftMargin + 260, buttonsTop);
            this.btnGenerate3D.Size = new System.Drawing.Size(240, 40);
            this.btnGenerate3D.BackColor = System.Drawing.Color.MediumPurple;
            this.btnGenerate3D.ForeColor = System.Drawing.Color.White;
            this.btnGenerate3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate3D.FlatAppearance.BorderSize = 0;
            this.btnGenerate3D.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnGenerateImage
            this.btnGenerateImage = new System.Windows.Forms.Button();
            this.btnGenerateImage.Text = "Generate Image";
            this.btnGenerateImage.Location = new System.Drawing.Point(leftMargin + 510, buttonsTop);
            this.btnGenerateImage.Size = new System.Drawing.Size(250, 40);
            this.btnGenerateImage.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGenerateImage.ForeColor = System.Drawing.Color.White;
            this.btnGenerateImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateImage.FlatAppearance.BorderSize = 0;
            this.btnGenerateImage.Cursor = System.Windows.Forms.Cursors.Hand;

            // Buttons second row Y position
            int buttons2Top = buttonsTop + 50;

            // btnOpenImageFolder
            this.btnOpenImageFolder = new System.Windows.Forms.Button();
            this.btnOpenImageFolder.Text = "Open Image Folder";
            this.btnOpenImageFolder.Location = new System.Drawing.Point(leftMargin + 510, buttons2Top);
            this.btnOpenImageFolder.Size = new System.Drawing.Size(250, 40);
            this.btnOpenImageFolder.BackColor = System.Drawing.Color.Teal;
            this.btnOpenImageFolder.ForeColor = System.Drawing.Color.White;
            this.btnOpenImageFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenImageFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenImageFolder.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnOpen3DFolder
            this.btnOpen3DFolder = new System.Windows.Forms.Button();
            this.btnOpen3DFolder.Text = "Open 3D Folder";
            this.btnOpen3DFolder.Location = new System.Drawing.Point(leftMargin + 260, buttons2Top);
            this.btnOpen3DFolder.Size = new System.Drawing.Size(240, 40);
            this.btnOpen3DFolder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnOpen3DFolder.ForeColor = System.Drawing.Color.White;
            this.btnOpen3DFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen3DFolder.FlatAppearance.BorderSize = 0;
            this.btnOpen3DFolder.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnViewObjects
            this.btnViewObjects = new System.Windows.Forms.Button();
            this.btnViewObjects.Text = "View Objects";
            this.btnViewObjects.Location = new System.Drawing.Point(leftMargin, buttons2Top);
            this.btnViewObjects.Size = new System.Drawing.Size(250, 40);
            this.btnViewObjects.BackColor = System.Drawing.Color.FromArgb(178, 34, 34);
            this.btnViewObjects.ForeColor = System.Drawing.Color.White;
            this.btnViewObjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewObjects.FlatAppearance.BorderSize = 0;
            this.btnViewObjects.Cursor = System.Windows.Forms.Cursors.Hand;

            // Buttons second row Y position
            int buttons3Top = buttons2Top + 70;

            // btnImportToGame
            this.btnImportToGame = new System.Windows.Forms.Button();
            this.btnImportToGame.Text = "Import to Game";
            this.btnImportToGame.Location = new System.Drawing.Point(leftMargin + 230, buttons3Top);
            this.btnImportToGame.Size = new System.Drawing.Size(300, 40);
            this.btnImportToGame.BackColor = System.Drawing.Color.DarkOrange;
            this.btnImportToGame.ForeColor = System.Drawing.Color.White;
            this.btnImportToGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportToGame.FlatAppearance.BorderSize = 0;
            this.btnImportToGame.Cursor = System.Windows.Forms.Cursors.Hand;

            // Status and Timer Labels
            int statusY = buttons3Top + 60;
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatus.Text = "";
            this.lblStatus.Location = new System.Drawing.Point(leftMargin, statusY);
            this.lblStatus.Size = new System.Drawing.Size(400, 25);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);

            this.lblTimer = new System.Windows.Forms.Label();
            this.lblTimer.Text = "";
            this.lblTimer.Location = new System.Drawing.Point(620, statusY);
            this.lblTimer.Size = new System.Drawing.Size(60, 25);
            this.lblTimer.ForeColor = System.Drawing.Color.DimGray;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);

            // Bottom row Y position for About & Help
            int bottomY = this.ClientSize.Height - 40;

            // btnAbout
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnAbout.Text = "About";
            this.btnAbout.Location = new System.Drawing.Point(leftMargin, bottomY);
            this.btnAbout.Size = new System.Drawing.Size(80, 30);
            this.btnAbout.BackColor = System.Drawing.Color.SlateGray;
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnHelp
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnHelp.Text = "Help";
            this.btnHelp.Location = new System.Drawing.Point(leftMargin + 100, bottomY);
            this.btnHelp.Size = new System.Drawing.Size(80, 30);
            this.btnHelp.BackColor = System.Drawing.Color.SlateGray;
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;

            cmbMicrophones.TabIndex = 0;
            txtFileName.TabIndex = 1;
            txtPrompt.TabIndex = 2;
            btnRecordMic.TabIndex = 3;
            btnGenerate3D.TabIndex = 4;
            btnGenerateImage.TabIndex = 5;
            btnViewObjects.TabIndex = 6;
            btnOpen3DFolder.TabIndex = 7;
            btnOpenImageFolder.TabIndex = 8;
            btnImportToGame.TabIndex = 9;           
            btnAbout.TabIndex = 10;
            btnHelp.TabIndex = 11;

            // Add controls in proper order (top to bottom)
            this.Controls.Add(lblExamplePrompt);
            this.Controls.Add(lblSubtitle);
            this.Controls.Add(lblTitle);

            this.Controls.Add(this.lblMic);
            this.Controls.Add(this.cmbMicrophones);

            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFileName);

            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtPrompt);

            this.Controls.Add(this.btnRecordMic);
            this.Controls.Add(this.btnGenerate3D);
            this.Controls.Add(this.btnGenerateImage);

            this.Controls.Add(this.btnOpenImageFolder);
            this.Controls.Add(this.btnOpen3DFolder);
            this.Controls.Add(this.btnImportToGame);
            this.Controls.Add(this.btnViewObjects);

            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTimer);

            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnHelp);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
