using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ParadiseDesignerAI
{
    public static class FileHelper
    {
        public static void CopyFolderKeepAll(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(sourceDir))
                return;

            Directory.CreateDirectory(targetDir);

            foreach (var filePath in Directory.GetFiles(sourceDir))
            {
                var originalName = Path.GetFileName(filePath);
                var destFile = Path.Combine(targetDir, originalName);

                if (File.Exists(destFile))
                    destFile = GetUniqueDestinationPath(targetDir, originalName);

                File.Copy(filePath, destFile, overwrite: false);
            }

            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                var subFolderName = Path.GetFileName(dir);
                var destSubDir = Path.Combine(targetDir, subFolderName);
                CopyFolderKeepAll(dir, destSubDir);
            }
        }


        public static string GetUniqueDestinationPath(string targetDir, string fileName)
        {
            string name = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            int counter = 2;

            string candidate = Path.Combine(targetDir, $"{name} ({counter}){ext}");
            while (File.Exists(candidate))
            {
                counter++;
                candidate = Path.Combine(targetDir, $"{name} ({counter}){ext}");
            }
            return candidate;
        }

        public static void OpenFolder(string folderPath)
        {
            Directory.CreateDirectory(folderPath); // ensure it exists
            Process.Start(new ProcessStartInfo()
            {
                FileName = folderPath,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        public static void Import3DModelToGame(string sourceFolder, string importFolder, IWin32Window owner = null)
        {
            if (!Directory.Exists(sourceFolder))
            {
                MessageBox.Show(owner, $"3D folder not found:\n{sourceFolder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Path.GetFullPath(sourceFolder);

                // Default to .txt as requested, but allow other common 3D formats too.
                dialog.Filter =
                    "Text 3D Objects (*.txt)|*.txt|" +
                    "3D Model Files (*.obj;*.fbx;*.glb;*.gltf)|*.obj;*.fbx;*.glb;*.gltf|" +
                    "All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.Title = "Select 3D Model to Import";

                if (dialog.ShowDialog(owner) == DialogResult.OK)
                {
                    Directory.CreateDirectory(importFolder);

                    string extension = Path.GetExtension(dialog.FileName);
                    string destFileName;

                    // If it's a .txt file, rename to model.txt
                    if (extension.Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        destFileName = "model.txt";
                    }
                    else
                    {
                        destFileName = Path.GetFileName(dialog.FileName);
                    }

                    string destFile = Path.Combine(importFolder, destFileName);

                    try
                    {
                        File.Copy(dialog.FileName, destFile, true);
                        MessageBox.Show(owner,
                            $"Imported:\n{Path.GetFileName(dialog.FileName)}\ninto the import folder as {destFileName}.",
                            "Import Successful",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(owner, "Failed to import model:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
