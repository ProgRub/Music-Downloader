
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
			this.ButtonDownloadMusic.AutoSize = true;
			this.ButtonDownloadMusic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonDownloadMusic.FlatAppearance.BorderSize = 0;
			this.ButtonDownloadMusic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonDownloadMusic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonDownloadMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonDownloadMusic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonDownloadMusic.Location = new System.Drawing.Point(374, 92);
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
			this.LabelMusicFrom.AutoSize = true;
			this.LabelMusicFrom.Location = new System.Drawing.Point(12, 19);
			this.LabelMusicFrom.Name = "LabelMusicFrom";
			this.LabelMusicFrom.Size = new System.Drawing.Size(326, 17);
			this.LabelMusicFrom.TabIndex = 7;
			this.LabelMusicFrom.Text = "Directory where Music is downloaded to:";
			// 
			// LabelMusicTo
			// 
			this.LabelMusicTo.AutoSize = true;
			this.LabelMusicTo.Location = new System.Drawing.Point(31, 50);
			this.LabelMusicTo.Name = "LabelMusicTo";
			this.LabelMusicTo.Size = new System.Drawing.Size(307, 17);
			this.LabelMusicTo.TabIndex = 8;
			this.LabelMusicTo.Text = "Directory where you store your Music:";
			// 
			// TextBoxMusicFromDirectory
			// 
			this.TextBoxMusicFromDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxMusicFromDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxMusicFromDirectory.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxMusicFromDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxMusicFromDirectory.Location = new System.Drawing.Point(344, 17);
			this.TextBoxMusicFromDirectory.Name = "TextBoxMusicFromDirectory";
			this.TextBoxMusicFromDirectory.ReadOnly = true;
			this.TextBoxMusicFromDirectory.Size = new System.Drawing.Size(504, 24);
			this.TextBoxMusicFromDirectory.TabIndex = 9;
			// 
			// TextBoxMusicToDirectory
			// 
			this.TextBoxMusicToDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxMusicToDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxMusicToDirectory.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxMusicToDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxMusicToDirectory.Location = new System.Drawing.Point(344, 48);
			this.TextBoxMusicToDirectory.Name = "TextBoxMusicToDirectory";
			this.TextBoxMusicToDirectory.ReadOnly = true;
			this.TextBoxMusicToDirectory.Size = new System.Drawing.Size(504, 24);
			this.TextBoxMusicToDirectory.TabIndex = 10;
			// 
			// ButtonChooseMusicFromDirectory
			// 
			this.ButtonChooseMusicFromDirectory.AutoSize = true;
			this.ButtonChooseMusicFromDirectory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonChooseMusicFromDirectory.FlatAppearance.BorderSize = 0;
			this.ButtonChooseMusicFromDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonChooseMusicFromDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonChooseMusicFromDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonChooseMusicFromDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonChooseMusicFromDirectory.Location = new System.Drawing.Point(854, 14);
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
			this.ButtonChooseMusicToDirectory.AutoSize = true;
			this.ButtonChooseMusicToDirectory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonChooseMusicToDirectory.FlatAppearance.BorderSize = 0;
			this.ButtonChooseMusicToDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonChooseMusicToDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonChooseMusicToDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonChooseMusicToDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonChooseMusicToDirectory.Location = new System.Drawing.Point(854, 45);
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
			// HomeScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ButtonChooseMusicToDirectory);
			this.Controls.Add(this.ButtonChooseMusicFromDirectory);
			this.Controls.Add(this.TextBoxMusicToDirectory);
			this.Controls.Add(this.TextBoxMusicFromDirectory);
			this.Controls.Add(this.LabelMusicTo);
			this.Controls.Add(this.LabelMusicFrom);
			this.Controls.Add(this.ButtonDownloadMusic);
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "HomeScreen";
			this.Size = new System.Drawing.Size(916, 447);
			this.Enter += new System.EventHandler(this.HomeScreen_Enter);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.Controls.SetChildIndex(this.ButtonDownloadMusic, 0);
			this.Controls.SetChildIndex(this.LabelMusicFrom, 0);
			this.Controls.SetChildIndex(this.LabelMusicTo, 0);
			this.Controls.SetChildIndex(this.TextBoxMusicFromDirectory, 0);
			this.Controls.SetChildIndex(this.TextBoxMusicToDirectory, 0);
			this.Controls.SetChildIndex(this.ButtonChooseMusicFromDirectory, 0);
			this.Controls.SetChildIndex(this.ButtonChooseMusicToDirectory, 0);
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
	}
}
