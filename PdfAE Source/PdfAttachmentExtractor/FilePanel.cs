using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PdfAttachmentExtractor
{
    public partial class FilePanel : Form
    {
        public FilePanel()
        {
            InitializeComponent();

            // Assuming you have an ImageList control named imageList1
            imageList1.ImageSize = new Size(16, 16);
            lvDropzone.SmallImageList = imageList1;

            // Find the drive with the most free space
            DriveInfo[] drives = DriveInfo.GetDrives();
            DriveInfo driveWithMostFreeSpace = drives.OrderByDescending(d => d.AvailableFreeSpace).FirstOrDefault();

            if (driveWithMostFreeSpace != null)
            {
                string destinationDrive = driveWithMostFreeSpace.Name;
                string outputDirectory = Path.Combine(destinationDrive, "Attachments");

                try
                {
                    Directory.CreateDirectory(outputDirectory);

                    // Set the text box with the path to the "Attachments" folder
                    txtDestination.Text = outputDirectory;
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur when creating the directory
                    MessageBox.Show($"Error creating directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No drives found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void lvDropzone_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lvDropzone_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                // Get the file name.
                string fileName = Path.GetFullPath(file);

                // Get the system icon for the file.
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(file);
                lvDropzone.SmallImageList.Images.Add(icon);

                // Get the index of the icon in the image list.
                int iconIndex = lvDropzone.SmallImageList.Images.Count - 1;

                // Create a ListViewItem with the file name.
                ListViewItem item = new ListViewItem(new[] { fileName, "N/A" }, iconIndex);

                // Add the item to the ListView.
                lvDropzone.Items.Add(item);
            }
        }

        private void lvAttachments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvAttachments.SelectedItems.Count > 0)
            {
                string fileName = lvAttachments.SelectedItems[0].Text;

                // Assuming the file is in the same directory as the executable.
                string filePath = Path.Combine(txtDestination.Text, fileName);

                try
                {
                    System.Diagnostics.Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string folderPath = txtDestination.Text;

            if (Directory.Exists(folderPath))
            {
                System.Diagnostics.Process.Start(folderPath);
            }
            else
            {
                MessageBox.Show("The specified folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            lvAttachments.Clear();

            string outputDirectory = txtDestination.Text;

            if (!Directory.Exists(outputDirectory))
            {
                MessageBox.Show("Output directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (ListViewItem item in lvDropzone.Items)
            {
                string filePath = item.Text; // Assuming the file path is in the first column

                try
                {
                    List<string> attachmentfiles = PdfAttachmentExtractorClass.ExtractAttachments(filePath, outputDirectory);

                    foreach (string file in attachmentfiles)
                    {

                        lvAttachments.Items.Add(file);

                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during extraction
                    MessageBox.Show($"Error extracting attachments from {filePath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (lvAttachments.Items.Count == 0)
            {
                MessageBox.Show($"No attachments found in the documents.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Success! " + lvAttachments.Items.Count + " attachments found.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOpenFolder_Click_1(object sender, EventArgs e)
        {
            string folderPath = txtDestination.Text;

            if (Directory.Exists(folderPath))
            {
                System.Diagnostics.Process.Start(folderPath);
            }
            else
            {
                MessageBox.Show("The specified folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDestination_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtDestination.Text = folderDialog.SelectedPath;
            }
        }
    }
}
