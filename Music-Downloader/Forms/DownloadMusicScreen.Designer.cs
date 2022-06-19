
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
			this.tableLayoutPanelRenameFiles = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelRenameFiles.SuspendLayout();
			this.tableLayoutPanelMain.SuspendLayout();
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
			this.ListBoxBeforeFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListBoxBeforeFiles.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ListBoxBeforeFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.ListBoxBeforeFiles.FormattingEnabled = true;
			this.ListBoxBeforeFiles.ItemHeight = 16;
			this.ListBoxBeforeFiles.Location = new System.Drawing.Point(3, 32);
			this.ListBoxBeforeFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBoxBeforeFiles.Name = "ListBoxBeforeFiles";
			this.ListBoxBeforeFiles.Size = new System.Drawing.Size(435, 370);
			this.ListBoxBeforeFiles.TabIndex = 6;
			this.ListBoxBeforeFiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxBeforeFiles_SelectedIndexChanged);
			this.ListBoxBeforeFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxBeforeFiles_KeyDown);
			// 
			// TextBoxAfterFiles
			// 
			this.TextBoxAfterFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxAfterFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxAfterFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TextBoxAfterFiles.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxAfterFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxAfterFiles.Location = new System.Drawing.Point(444, 32);
			this.TextBoxAfterFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxAfterFiles.Multiline = true;
			this.TextBoxAfterFiles.Name = "TextBoxAfterFiles";
			this.TextBoxAfterFiles.ReadOnly = true;
			this.TextBoxAfterFiles.Size = new System.Drawing.Size(435, 370);
			this.TextBoxAfterFiles.TabIndex = 7;
			// 
			// LabelFilename
			// 
			this.LabelFilename.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.LabelFilename.AutoSize = true;
			this.LabelFilename.Location = new System.Drawing.Point(8, 13);
			this.LabelFilename.Name = "LabelFilename";
			this.LabelFilename.Size = new System.Drawing.Size(76, 17);
			this.LabelFilename.TabIndex = 8;
			this.LabelFilename.Text = "Filename";
			// 
			// TextBoxRenameFile
			// 
			this.TextBoxRenameFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxRenameFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxRenameFile.Enabled = false;
			this.TextBoxRenameFile.Location = new System.Drawing.Point(90, 10);
			this.TextBoxRenameFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxRenameFile.Name = "TextBoxRenameFile";
			this.TextBoxRenameFile.Size = new System.Drawing.Size(694, 24);
			this.TextBoxRenameFile.TabIndex = 9;
			// 
			// ButtonRenameFile
			// 
			this.ButtonRenameFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.ButtonRenameFile.AutoSize = true;
			this.ButtonRenameFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonRenameFile.FlatAppearance.BorderSize = 0;
			this.ButtonRenameFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonRenameFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonRenameFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonRenameFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonRenameFile.Location = new System.Drawing.Point(790, 8);
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
			this.ButtonMoveFilesGetLyrics.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ButtonMoveFilesGetLyrics.AutoSize = true;
			this.ButtonMoveFilesGetLyrics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonMoveFilesGetLyrics.FlatAppearance.BorderSize = 0;
			this.ButtonMoveFilesGetLyrics.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonMoveFilesGetLyrics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonMoveFilesGetLyrics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonMoveFilesGetLyrics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonMoveFilesGetLyrics.Location = new System.Drawing.Point(388, 46);
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
			this.ButtonUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonUndo.AutoSize = true;
			this.ButtonUndo.Enabled = false;
			this.ButtonUndo.FlatAppearance.BorderSize = 0;
			this.ButtonUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonUndo.Image = global::Forms.Properties.Resources.Undo;
			this.ButtonUndo.Location = new System.Drawing.Point(401, 406);
			this.ButtonUndo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonUndo.Name = "ButtonUndo";
			this.ButtonUndo.Size = new System.Drawing.Size(37, 22);
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
			this.ButtonRedo.Location = new System.Drawing.Point(444, 406);
			this.ButtonRedo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonRedo.Name = "ButtonRedo";
			this.ButtonRedo.Size = new System.Drawing.Size(37, 22);
			this.ButtonRedo.TabIndex = 13;
			this.ButtonRedo.UseVisualStyleBackColor = true;
			this.ButtonRedo.Click += new System.EventHandler(this.ButtonRedo_Click);
			// 
			// LabelNumberOfFiles
			// 
			this.LabelNumberOfFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.LabelNumberOfFiles.AutoSize = true;
			this.tableLayoutPanelMain.SetColumnSpan(this.LabelNumberOfFiles, 2);
			this.LabelNumberOfFiles.Location = new System.Drawing.Point(385, 6);
			this.LabelNumberOfFiles.Name = "LabelNumberOfFiles";
			this.LabelNumberOfFiles.Size = new System.Drawing.Size(111, 17);
			this.LabelNumberOfFiles.TabIndex = 14;
			this.LabelNumberOfFiles.Text = "0 Files Found";
			// 
			// tableLayoutPanelRenameFiles
			// 
			this.tableLayoutPanelRenameFiles.ColumnCount = 3;
			this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanelRenameFiles, 2);
			this.tableLayoutPanelRenameFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelRenameFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanelRenameFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelRenameFiles.Controls.Add(this.ButtonRenameFile, 2, 0);
			this.tableLayoutPanelRenameFiles.Controls.Add(this.TextBoxRenameFile, 1, 0);
			this.tableLayoutPanelRenameFiles.Controls.Add(this.LabelFilename, 0, 0);
			this.tableLayoutPanelRenameFiles.Controls.Add(this.ButtonMoveFilesGetLyrics, 1, 1);
			this.tableLayoutPanelRenameFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelRenameFiles.Location = new System.Drawing.Point(3, 437);
			this.tableLayoutPanelRenameFiles.MinimumSize = new System.Drawing.Size(876, 69);
			this.tableLayoutPanelRenameFiles.Name = "tableLayoutPanelRenameFiles";
			this.tableLayoutPanelRenameFiles.RowCount = 2;
			this.tableLayoutPanelRenameFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelRenameFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelRenameFiles.Size = new System.Drawing.Size(876, 88);
			this.tableLayoutPanelRenameFiles.TabIndex = 0;
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.ColumnCount = 2;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelMain.Controls.Add(this.ListBoxBeforeFiles, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.TextBoxAfterFiles, 1, 1);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelRenameFiles, 0, 3);
			this.tableLayoutPanelMain.Controls.Add(this.LabelNumberOfFiles, 0, 0);
			this.tableLayoutPanelMain.Controls.Add(this.ButtonRedo, 1, 2);
			this.tableLayoutPanelMain.Controls.Add(this.ButtonUndo, 0, 2);
			this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelMain.MinimumSize = new System.Drawing.Size(882, 528);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 4;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(882, 528);
			this.tableLayoutPanelMain.TabIndex = 15;
			// 
			// DownloadMusicScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = false;
			this.Controls.Add(this.tableLayoutPanelMain);
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "DownloadMusicScreen";
			this.Size = new System.Drawing.Size(882, 528);
			this.Enter += new System.EventHandler(this.DownloadMusicScreen_Enter);
			this.Controls.SetChildIndex(this.tableLayoutPanelMain, 0);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.tableLayoutPanelRenameFiles.ResumeLayout(false);
			this.tableLayoutPanelRenameFiles.PerformLayout();
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
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
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRenameFiles;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
	}
}
