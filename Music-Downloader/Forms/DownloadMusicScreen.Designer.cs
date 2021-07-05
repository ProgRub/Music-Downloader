
namespace Forms
{
    partial class DownloadMusicScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.ListBoxBeforeFiles = new System.Windows.Forms.ListBox();
			this.TextBoxAfterFiles = new System.Windows.Forms.TextBox();
			this.LabelFilename = new System.Windows.Forms.Label();
			this.TextBoxRenameFile = new System.Windows.Forms.TextBox();
			this.ButtonRenameFile = new System.Windows.Forms.Button();
			this.ButtonMoveFilesGetLyrics = new System.Windows.Forms.Button();
			this.ButtonUndo = new System.Windows.Forms.Button();
			this.ButtonRedo = new System.Windows.Forms.Button();
			this.LabelNumberOfFiles = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ButtonBack
			// 
			this.ButtonBack.FlatAppearance.BorderSize = 0;
			this.ButtonBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			// 
			// ListBoxBeforeFiles
			// 
			this.ListBoxBeforeFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.ListBoxBeforeFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ListBoxBeforeFiles.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ListBoxBeforeFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.ListBoxBeforeFiles.FormattingEnabled = true;
			this.ListBoxBeforeFiles.ItemHeight = 16;
			this.ListBoxBeforeFiles.Location = new System.Drawing.Point(3, 53);
			this.ListBoxBeforeFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBoxBeforeFiles.Name = "ListBoxBeforeFiles";
			this.ListBoxBeforeFiles.Size = new System.Drawing.Size(813, 658);
			this.ListBoxBeforeFiles.TabIndex = 6;
			this.ListBoxBeforeFiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxBeforeFiles_SelectedIndexChanged);
			this.ListBoxBeforeFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxBeforeFiles_KeyDown);
			// 
			// TextBoxAfterFiles
			// 
			this.TextBoxAfterFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxAfterFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxAfterFiles.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxAfterFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxAfterFiles.Location = new System.Drawing.Point(822, 53);
			this.TextBoxAfterFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxAfterFiles.Multiline = true;
			this.TextBoxAfterFiles.Name = "TextBoxAfterFiles";
			this.TextBoxAfterFiles.ReadOnly = true;
			this.TextBoxAfterFiles.Size = new System.Drawing.Size(813, 658);
			this.TextBoxAfterFiles.TabIndex = 7;
			// 
			// LabelFilename
			// 
			this.LabelFilename.AutoSize = true;
			this.LabelFilename.Location = new System.Drawing.Point(512, 762);
			this.LabelFilename.Name = "LabelFilename";
			this.LabelFilename.Size = new System.Drawing.Size(76, 17);
			this.LabelFilename.TabIndex = 8;
			this.LabelFilename.Text = "Filename";
			// 
			// TextBoxRenameFile
			// 
			this.TextBoxRenameFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxRenameFile.Enabled = false;
			this.TextBoxRenameFile.Location = new System.Drawing.Point(592, 760);
			this.TextBoxRenameFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxRenameFile.Name = "TextBoxRenameFile";
			this.TextBoxRenameFile.Size = new System.Drawing.Size(433, 24);
			this.TextBoxRenameFile.TabIndex = 9;
			// 
			// ButtonRenameFile
			// 
			this.ButtonRenameFile.AutoSize = true;
			this.ButtonRenameFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonRenameFile.FlatAppearance.BorderSize = 0;
			this.ButtonRenameFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonRenameFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonRenameFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonRenameFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonRenameFile.Location = new System.Drawing.Point(1030, 760);
			this.ButtonRenameFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonRenameFile.Name = "ButtonRenameFile";
			this.ButtonRenameFile.Size = new System.Drawing.Size(80, 27);
			this.ButtonRenameFile.TabIndex = 10;
			this.ButtonRenameFile.Text = "Rename";
			this.ButtonRenameFile.UseVisualStyleBackColor = true;
			this.ButtonRenameFile.Click += new System.EventHandler(this.ButtonRenameFile_Click);
			// 
			// ButtonMoveFilesGetLyrics
			// 
			this.ButtonMoveFilesGetLyrics.AutoSize = true;
			this.ButtonMoveFilesGetLyrics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonMoveFilesGetLyrics.FlatAppearance.BorderSize = 0;
			this.ButtonMoveFilesGetLyrics.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonMoveFilesGetLyrics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonMoveFilesGetLyrics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonMoveFilesGetLyrics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonMoveFilesGetLyrics.Location = new System.Drawing.Point(775, 798);
			this.ButtonMoveFilesGetLyrics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonMoveFilesGetLyrics.Name = "ButtonMoveFilesGetLyrics";
			this.ButtonMoveFilesGetLyrics.Size = new System.Drawing.Size(98, 27);
			this.ButtonMoveFilesGetLyrics.TabIndex = 11;
			this.ButtonMoveFilesGetLyrics.Text = "Move Files";
			this.ButtonMoveFilesGetLyrics.UseVisualStyleBackColor = true;
			this.ButtonMoveFilesGetLyrics.Click += new System.EventHandler(this.ButtonMoveFilesGetLyrics_Click);
			// 
			// ButtonUndo
			// 
			this.ButtonUndo.AutoSize = true;
			this.ButtonUndo.Enabled = false;
			this.ButtonUndo.FlatAppearance.BorderSize = 0;
			this.ButtonUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonUndo.Image = global::Forms.Properties.Resources.Undo;
			this.ButtonUndo.Location = new System.Drawing.Point(779, 717);
			this.ButtonUndo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonUndo.Name = "ButtonUndo";
			this.ButtonUndo.Size = new System.Drawing.Size(37, 29);
			this.ButtonUndo.TabIndex = 12;
			this.ButtonUndo.UseVisualStyleBackColor = true;
			this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
			// 
			// ButtonRedo
			// 
			this.ButtonRedo.AutoSize = true;
			this.ButtonRedo.Enabled = false;
			this.ButtonRedo.FlatAppearance.BorderSize = 0;
			this.ButtonRedo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonRedo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonRedo.Image = global::Forms.Properties.Resources.Redo;
			this.ButtonRedo.Location = new System.Drawing.Point(822, 717);
			this.ButtonRedo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonRedo.Name = "ButtonRedo";
			this.ButtonRedo.Size = new System.Drawing.Size(37, 29);
			this.ButtonRedo.TabIndex = 13;
			this.ButtonRedo.UseVisualStyleBackColor = true;
			this.ButtonRedo.Click += new System.EventHandler(this.ButtonRedo_Click);
			// 
			// LabelNumberOfFiles
			// 
			this.LabelNumberOfFiles.AutoSize = true;
			this.LabelNumberOfFiles.Location = new System.Drawing.Point(762, 20);
			this.LabelNumberOfFiles.Name = "LabelNumberOfFiles";
			this.LabelNumberOfFiles.Size = new System.Drawing.Size(111, 17);
			this.LabelNumberOfFiles.TabIndex = 14;
			this.LabelNumberOfFiles.Text = "0 Files Found";
			// 
			// DownloadMusicScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.LabelNumberOfFiles);
			this.Controls.Add(this.ButtonRedo);
			this.Controls.Add(this.ButtonUndo);
			this.Controls.Add(this.ButtonMoveFilesGetLyrics);
			this.Controls.Add(this.ButtonRenameFile);
			this.Controls.Add(this.TextBoxRenameFile);
			this.Controls.Add(this.LabelFilename);
			this.Controls.Add(this.TextBoxAfterFiles);
			this.Controls.Add(this.ListBoxBeforeFiles);
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "DownloadMusicScreen";
			this.Size = new System.Drawing.Size(1638, 827);
			this.Enter += new System.EventHandler(this.DownloadMusicScreen_Enter);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.Controls.SetChildIndex(this.ListBoxBeforeFiles, 0);
			this.Controls.SetChildIndex(this.TextBoxAfterFiles, 0);
			this.Controls.SetChildIndex(this.LabelFilename, 0);
			this.Controls.SetChildIndex(this.TextBoxRenameFile, 0);
			this.Controls.SetChildIndex(this.ButtonRenameFile, 0);
			this.Controls.SetChildIndex(this.ButtonMoveFilesGetLyrics, 0);
			this.Controls.SetChildIndex(this.ButtonUndo, 0);
			this.Controls.SetChildIndex(this.ButtonRedo, 0);
			this.Controls.SetChildIndex(this.LabelNumberOfFiles, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxBeforeFiles;
        private System.Windows.Forms.TextBox TextBoxAfterFiles;
        private System.Windows.Forms.Label LabelFilename;
        private System.Windows.Forms.TextBox TextBoxRenameFile;
        private System.Windows.Forms.Button ButtonRenameFile;
        private System.Windows.Forms.Button ButtonMoveFilesGetLyrics;
        private System.Windows.Forms.Button ButtonUndo;
        private System.Windows.Forms.Button ButtonRedo;
        private System.Windows.Forms.Label LabelNumberOfFiles;
    }
}
