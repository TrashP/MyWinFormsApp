using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ParadiseDesignerAI
{
    public static class FileHelper
    {
        public static void CopyFolderWithoutOverwriting(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(sourceDir))
                return;

            Directory.CreateDirectory(targetDir);

            foreach (var filePath in Directory.GetFiles(sourceDir))
            {
                var fileName = Path.GetFileName(filePath);
                var destFile = Path.Combine(targetDir, fileName);
                if (!File.Exists(destFile))
                {
                    File.Copy(filePath, destFile);
                }
            }
        }

        public static void OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = folderPath,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            else
            {
                MessageBox.Show($"Folder not found:\n{folderPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Import3DModelToGame(string sourceFolder, string importFolder)
        {
            if (!Directory.Exists(sourceFolder))
            {
                MessageBox.Show($"3D folder not found:\n{sourceFolder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Path.GetFullPath(sourceFolder);
                dialog.Filter = "3D Model Files (*.obj;*.fbx;*.glb;*.gltf)|*.obj;*.fbx;*.glb;*.gltf|All files (*.*)|*.*";
                dialog.Title = "Select 3D Model to Import";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Directory.CreateDirectory(importFolder);

                    string destFile = Path.Combine(importFolder, Path.GetFileName(dialog.FileName));

                    try
                    {
                        File.Copy(dialog.FileName, destFile, true);
                        MessageBox.Show($"Imported:\n{Path.GetFileName(dialog.FileName)}\nto import folder.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to import model:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
