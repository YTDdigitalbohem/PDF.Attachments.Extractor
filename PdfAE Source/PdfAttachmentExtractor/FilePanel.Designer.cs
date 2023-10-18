namespace PdfAttachmentExtractor
{
    partial class FilePanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilePanel));
            this.lvDropzone = new System.Windows.Forms.ListView();
            this.btnScan = new System.Windows.Forms.Button();
            this.lvAttachments = new System.Windows.Forms.ListView();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvDropzone
            // 
            this.lvDropzone.AllowDrop = true;
            this.lvDropzone.HideSelection = false;
            this.lvDropzone.LargeImageList = this.imageList1;
            this.lvDropzone.Location = new System.Drawing.Point(0, 4);
            this.lvDropzone.Name = "lvDropzone";
            this.lvDropzone.Size = new System.Drawing.Size(396, 210);
            this.lvDropzone.SmallImageList = this.imageList1;
            this.lvDropzone.TabIndex = 0;
            this.lvDropzone.UseCompatibleStateImageBehavior = false;
            this.lvDropzone.View = System.Windows.Forms.View.List;
            this.lvDropzone.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvDropzone_DragDrop);
            this.lvDropzone.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvDropzone_DragEnter);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnScan.Location = new System.Drawing.Point(0, 246);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(396, 30);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Get Attachments";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lvAttachments
            // 
            this.lvAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAttachments.HideSelection = false;
            this.lvAttachments.LargeImageList = this.imageList1;
            this.lvAttachments.Location = new System.Drawing.Point(0, 327);
            this.lvAttachments.Name = "lvAttachments";
            this.lvAttachments.Size = new System.Drawing.Size(396, 219);
            this.lvAttachments.SmallImageList = this.imageList1;
            this.lvAttachments.TabIndex = 2;
            this.lvAttachments.UseCompatibleStateImageBehavior = false;
            this.lvAttachments.View = System.Windows.Forms.View.List;
            this.lvAttachments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAttachments_MouseDoubleClick);
            // 
            // txtDestination
            // 
            this.txtDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestination.Location = new System.Drawing.Point(0, 220);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(396, 20);
            this.txtDestination.TabIndex = 3;
            this.txtDestination.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtDestination_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenFolder.Location = new System.Drawing.Point(0, 282);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(396, 30);
            this.btnOpenFolder.TabIndex = 4;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click_1);
            // 
            // FilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 544);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.lvAttachments);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lvDropzone);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilePanel";
            this.Text = "PDFAE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvDropzone;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListView lvAttachments;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtDestination;
    }
}