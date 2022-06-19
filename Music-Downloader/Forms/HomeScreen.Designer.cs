
namespace Forms
{
    partial class HomeScreen
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
			this.ButtonDownloadMusic = new System.Windows.Forms.Button();
			this.LabelMusicFrom = new System.Windows.Forms.Label();
			this.LabelMusicTo = new System.Windows.Forms.Label();
			this.TextBoxMusicFromDirectory = new System.Windows.Forms.TextBox();
			this.TextBoxMusicToDirectory = new System.Windows.Forms.TextBox();
			this.ButtonChooseMusicFromDirectory = new System.Windows.Forms.Button();
			this.ButtonChooseMusicToDirectory = new System.Windows.Forms.Button();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.ButtonManageExceptions = new System.Windows.Forms.Button();
			this.ButtonManageUrlReplacements = new System.Windows.Forms.Button();
			this.ButtonManageGrimeArtists = new System.Windows.Forms.Button();
			this.ButtonAllFilesYearAndLyrics = new System.Windows.Forms.Button();
			this.ButtonSelectFiles = new System.Windows.Forms.Button();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonBack
			// 
			this.ButtonBack.Enabled = false;
			this.ButtonBack.FlatAppearance.BorderSize = 0;
			this.ButtonBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.Location = new System.Drawing.Point(44, 196);
			this.ButtonBack.Visible = false;
			// 
			// ButtonDownloadMusic
			// 
			this.ButtonDownloadMusic.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ButtonDownloadMusic.AutoSize = true;
			this.ButtonDownloadMusic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonDownloadMusic.FlatAppearance.BorderSize = 0;
			this.ButtonDownloadMusic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonDownloadMusic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonDownloadMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonDownloadMusic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonDownloadMusic.Location = new System.Drawing.Point(505, 64);
			this.ButtonDownloadMusic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonDownloadMusic.Name = "ButtonDownloadMusic";
			this.ButtonDownloadMusic.Size = new System.Drawing.Size(144, 27);
			this.ButtonDownloadMusic.TabIndex = 6;
			this.ButtonDownloadMusic.Text = "Download Music";
			this.ButtonDownloadMusic.UseVisualStyleBackColor = true;
			this.ButtonDownloadMusic.Click += new System.EventHandler(this.ButtonDownloadMusic_Click);
			// 
			// LabelMusicFrom
			// 
			this.LabelMusicFrom.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.LabelMusicFrom.AutoSize = true;
			this.LabelMusicFrom.Location = new System.Drawing.Point(4, 7);
			this.LabelMusicFrom.Name = "LabelMusicFrom";
			this.LabelMusicFrom.Size = new System.Drawing.Size(326, 17);
			this.LabelMusicFrom.TabIndex = 7;
			this.LabelMusicFrom.Text = "Directory where Music is downloaded to:";
			// 
			// LabelMusicTo
			// 
			this.LabelMusicTo.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.LabelMusicTo.AutoSize = true;
			this.LabelMusicTo.Location = new System.Drawing.Point(23, 38);
			this.LabelMusicTo.Name = "LabelMusicTo";
			this.LabelMusicTo.Size = new System.Drawing.Size(307, 17);
			this.LabelMusicTo.TabIndex = 8;
			this.LabelMusicTo.Text = "Directory where you store your Music:";
			// 
			// TextBoxMusicFromDirectory
			// 
			this.TextBoxMusicFromDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxMusicFromDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxMusicFromDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxMusicFromDirectory.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxMusicFromDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxMusicFromDirectory.Location = new System.Drawing.Point(336, 3);
			this.TextBoxMusicFromDirectory.Name = "TextBoxMusicFromDirectory";
			this.TextBoxMusicFromDirectory.ReadOnly = true;
			this.TextBoxMusicFromDirectory.Size = new System.Drawing.Size(482, 24);
			this.TextBoxMusicFromDirectory.TabIndex = 9;
			// 
			// TextBoxMusicToDirectory
			// 
			this.TextBoxMusicToDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxMusicToDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxMusicToDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxMusicToDirectory.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxMusicToDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxMusicToDirectory.Location = new System.Drawing.Point(336, 34);
			this.TextBoxMusicToDirectory.Name = "TextBoxMusicToDirectory";
			this.TextBoxMusicToDirectory.ReadOnly = true;
			this.TextBoxMusicToDirectory.Size = new System.Drawing.Size(482, 24);
			this.TextBoxMusicToDirectory.TabIndex = 10;
			// 
			// ButtonChooseMusicFromDirectory
			// 
			this.ButtonChooseMusicFromDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.ButtonChooseMusicFromDirectory.AutoSize = true;
			this.ButtonChooseMusicFromDirectory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonChooseMusicFromDirectory.FlatAppearance.BorderSize = 0;
			this.ButtonChooseMusicFromDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonChooseMusicFromDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonChooseMusicFromDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonChooseMusicFromDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonChooseMusicFromDirectory.Location = new System.Drawing.Point(824, 2);
			this.ButtonChooseMusicFromDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonChooseMusicFromDirectory.Name = "ButtonChooseMusicFromDirectory";
			this.ButtonChooseMusicFromDirectory.Size = new System.Drawing.Size(59, 27);
			this.ButtonChooseMusicFromDirectory.TabIndex = 11;
			this.ButtonChooseMusicFromDirectory.Text = "Open";
			this.ButtonChooseMusicFromDirectory.UseVisualStyleBackColor = true;
			this.ButtonChooseMusicFromDirectory.Click += new System.EventHandler(this.ButtonChooseMusicFromDirectory_Click);
			// 
			// ButtonChooseMusicToDirectory
			// 
			this.ButtonChooseMusicToDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.ButtonChooseMusicToDirectory.AutoSize = true;
			this.ButtonChooseMusicToDirectory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonChooseMusicToDirectory.FlatAppearance.BorderSize = 0;
			this.ButtonChooseMusicToDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonChooseMusicToDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonChooseMusicToDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonChooseMusicToDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonChooseMusicToDirectory.Location = new System.Drawing.Point(824, 33);
			this.ButtonChooseMusicToDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonChooseMusicToDirectory.Name = "ButtonChooseMusicToDirectory";
			this.ButtonChooseMusicToDirectory.Size = new System.Drawing.Size(59, 27);
			this.ButtonChooseMusicToDirectory.TabIndex = 12;
			this.ButtonChooseMusicToDirectory.Text = "Open";
			this.ButtonChooseMusicToDirectory.UseVisualStyleBackColor = true;
			this.ButtonChooseMusicToDirectory.Click += new System.EventHandler(this.ButtonChooseMusicToDirectory_Click);
			// 
			// FolderBrowserDialog
			// 
			this.FolderBrowserDialog.UseDescriptionForTitle = true;
			// 
			// ButtonManageExceptions
			// 
			this.ButtonManageExceptions.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ButtonManageExceptions.AutoSize = true;
			this.ButtonManageExceptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonManageExceptions.FlatAppearance.BorderSize = 0;
			this.ButtonManageExceptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonManageExceptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonManageExceptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonManageExceptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonManageExceptions.Location = new System.Drawing.Point(493, 157);
			this.ButtonManageExceptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonManageExceptions.Name = "ButtonManageExceptions";
			this.ButtonManageExceptions.Size = new System.Drawing.Size(167, 27);
			this.ButtonManageExceptions.TabIndex = 13;
			this.ButtonManageExceptions.Text = "Manage Exceptions";
			this.ButtonManageExceptions.UseVisualStyleBackColor = true;
			this.ButtonManageExceptions.Click += new System.EventHandler(this.ButtonManageExceptions_Click);
			// 
			// ButtonManageUrlReplacements
			// 
			this.ButtonManageUrlReplacements.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ButtonManageUrlReplacements.AutoSize = true;
			this.ButtonManageUrlReplacements.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonManageUrlReplacements.FlatAppearance.BorderSize = 0;
			this.ButtonManageUrlReplacements.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonManageUrlReplacements.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonManageUrlReplacements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonManageUrlReplacements.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonManageUrlReplacements.Location = new System.Drawing.Point(464, 188);
			this.ButtonManageUrlReplacements.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonManageUrlReplacements.Name = "ButtonManageUrlReplacements";
			this.ButtonManageUrlReplacements.Size = new System.Drawing.Size(226, 27);
			this.ButtonManageUrlReplacements.TabIndex = 14;
			this.ButtonManageUrlReplacements.Text = "Manage URL Replacements";
			this.ButtonManageUrlReplacements.UseVisualStyleBackColor = true;
			this.ButtonManageUrlReplacements.Click += new System.EventHandler(this.ButtonManageUrlReplacements_Click);
			// 
			// ButtonManageGrimeArtists
			// 
			this.ButtonManageGrimeArtists.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ButtonManageGrimeArtists.AutoSize = true;
			this.ButtonManageGrimeArtists.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonManageGrimeArtists.FlatAppearance.BorderSize = 0;
			this.ButtonManageGrimeArtists.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonManageGrimeArtists.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonManageGrimeArtists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonManageGrimeArtists.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonManageGrimeArtists.Location = new System.Drawing.Point(485, 219);
			this.ButtonManageGrimeArtists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonManageGrimeArtists.Name = "ButtonManageGrimeArtists";
			this.ButtonManageGrimeArtists.Size = new System.Drawing.Size(183, 27);
			this.ButtonManageGrimeArtists.TabIndex = 15;
			this.ButtonManageGrimeArtists.Text = "Manage Grime Artists";
			this.ButtonManageGrimeArtists.UseVisualStyleBackColor = true;
			this.ButtonManageGrimeArtists.Click += new System.EventHandler(this.ButtonManageGrimeArtists_Click);
			// 
			// ButtonAllFilesYearAndLyrics
			// 
			this.ButtonAllFilesYearAndLyrics.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ButtonAllFilesYearAndLyrics.AutoSize = true;
			this.ButtonAllFilesYearAndLyrics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonAllFilesYearAndLyrics.FlatAppearance.BorderSize = 0;
			this.ButtonAllFilesYearAndLyrics.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonAllFilesYearAndLyrics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonAllFilesYearAndLyrics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonAllFilesYearAndLyrics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonAllFilesYearAndLyrics.Location = new System.Drawing.Point(422, 95);
			this.ButtonAllFilesYearAndLyrics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonAllFilesYearAndLyrics.Name = "ButtonAllFilesYearAndLyrics";
			this.ButtonAllFilesYearAndLyrics.Size = new System.Drawing.Size(309, 27);
			this.ButtonAllFilesYearAndLyrics.TabIndex = 16;
			this.ButtonAllFilesYearAndLyrics.Text = "Get Year and Lyrics of All Stored Files";
			this.ButtonAllFilesYearAndLyrics.UseVisualStyleBackColor = true;
			this.ButtonAllFilesYearAndLyrics.Click += new System.EventHandler(this.ButtonAllFilesYearAndLyrics_Click);
			// 
			// ButtonSelectFiles
			// 
			this.ButtonSelectFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ButtonSelectFiles.AutoSize = true;
			this.ButtonSelectFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonSelectFiles.FlatAppearance.BorderSize = 0;
			this.ButtonSelectFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonSelectFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonSelectFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonSelectFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonSelectFiles.Location = new System.Drawing.Point(428, 126);
			this.ButtonSelectFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonSelectFiles.Name = "ButtonSelectFiles";
			this.ButtonSelectFiles.Size = new System.Drawing.Size(298, 27);
			this.ButtonSelectFiles.TabIndex = 17;
			this.ButtonSelectFiles.Text = "Get Year and Lyrics of Selected Files";
			this.ButtonSelectFiles.UseVisualStyleBackColor = true;
			this.ButtonSelectFiles.Click += new System.EventHandler(this.ButtonSelectFiles_Click);
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.AutoSize = true;
			this.tableLayoutPanel.ColumnCount = 3;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
			this.tableLayoutPanel.Controls.Add(this.LabelMusicFrom, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.ButtonManageGrimeArtists, 1, 7);
			this.tableLayoutPanel.Controls.Add(this.ButtonSelectFiles, 1, 4);
			this.tableLayoutPanel.Controls.Add(this.ButtonManageUrlReplacements, 1, 6);
			this.tableLayoutPanel.Controls.Add(this.LabelMusicTo, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.ButtonManageExceptions, 1, 5);
			this.tableLayoutPanel.Controls.Add(this.ButtonAllFilesYearAndLyrics, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.TextBoxMusicFromDirectory, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.TextBoxMusicToDirectory, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.ButtonChooseMusicFromDirectory, 2, 0);
			this.tableLayoutPanel.Controls.Add(this.ButtonChooseMusicToDirectory, 2, 1);
			this.tableLayoutPanel.Controls.Add(this.ButtonDownloadMusic, 1, 2);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.MinimumSize = new System.Drawing.Size(888, 249);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 8;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(888, 249);
			this.tableLayoutPanel.TabIndex = 18;
			// 
			// HomeScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanel);
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "HomeScreen";
			this.Size = new System.Drawing.Size(888, 249);
			this.Enter += new System.EventHandler(this.HomeScreen_Enter);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonDownloadMusic;
		private System.Windows.Forms.Label LabelMusicFrom;
		private System.Windows.Forms.Label LabelMusicTo;
		private System.Windows.Forms.TextBox TextBoxMusicFromDirectory;
		private System.Windows.Forms.TextBox TextBoxMusicToDirectory;
		private System.Windows.Forms.Button ButtonChooseMusicFromDirectory;
		private System.Windows.Forms.Button ButtonChooseMusicToDirectory;
		private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		private System.Windows.Forms.Button ButtonManageExceptions;
		private System.Windows.Forms.Button ButtonManageUrlReplacements;
		private System.Windows.Forms.Button ButtonManageGrimeArtists;
		private System.Windows.Forms.Button ButtonAllFilesYearAndLyrics;
		private System.Windows.Forms.Button ButtonSelectFiles;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
	}
}
