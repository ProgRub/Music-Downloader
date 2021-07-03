
namespace Forms
{
    partial class GetYearAndLyricsScreen
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
			this.PictureBoxLabel = new System.Windows.Forms.PictureBox();
			this.RichTextBoxArtist = new System.Windows.Forms.RichTextBox();
			this.RichTextBoxAlbum = new System.Windows.Forms.RichTextBox();
			this.RichTextBoxTitle = new System.Windows.Forms.RichTextBox();
			this.LabelArtist = new System.Windows.Forms.Label();
			this.LabelAlbum = new System.Windows.Forms.Label();
			this.LabelTitle = new System.Windows.Forms.Label();
			this.LabelTimeElapsed = new System.Windows.Forms.Label();
			this.LabelThreadsStatus = new System.Windows.Forms.Label();
			this.TextBoxThreadsStatus = new System.Windows.Forms.TextBox();
			this.TextBoxCorrectArtist = new System.Windows.Forms.TextBox();
			this.TextBoxCorrectAlbum = new System.Windows.Forms.TextBox();
			this.TextBoxCorrectTitle = new System.Windows.Forms.TextBox();
			this.LabelGeniusUrl = new System.Windows.Forms.Label();
			this.LabelCorrectArtist = new System.Windows.Forms.Label();
			this.LabelCorrectAlbum = new System.Windows.Forms.Label();
			this.LabelCorrectTitle = new System.Windows.Forms.Label();
			this.ButtonTryAgain = new System.Windows.Forms.Button();
			this.ButtonSkipYear = new System.Windows.Forms.Button();
			this.ButtonSkipLyrics = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxLabel)).BeginInit();
			this.SuspendLayout();
			// 
			// ButtonBack
			// 
			this.ButtonBack.Enabled = false;
			this.ButtonBack.FlatAppearance.BorderSize = 0;
			this.ButtonBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.Visible = false;
			// 
			// PictureBoxLabel
			// 
			this.PictureBoxLabel.Image = global::Forms.Properties.Resources.image_removebg_preview__1_;
			this.PictureBoxLabel.Location = new System.Drawing.Point(1617, 152);
			this.PictureBoxLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PictureBoxLabel.Name = "PictureBoxLabel";
			this.PictureBoxLabel.Size = new System.Drawing.Size(251, 200);
			this.PictureBoxLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PictureBoxLabel.TabIndex = 6;
			this.PictureBoxLabel.TabStop = false;
			// 
			// RichTextBoxArtist
			// 
			this.RichTextBoxArtist.Location = new System.Drawing.Point(17, 49);
			this.RichTextBoxArtist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RichTextBoxArtist.Name = "RichTextBoxArtist";
			this.RichTextBoxArtist.ReadOnly = true;
			this.RichTextBoxArtist.Size = new System.Drawing.Size(316, 613);
			this.RichTextBoxArtist.TabIndex = 7;
			this.RichTextBoxArtist.Text = "";
			// 
			// RichTextBoxAlbum
			// 
			this.RichTextBoxAlbum.Location = new System.Drawing.Point(339, 49);
			this.RichTextBoxAlbum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RichTextBoxAlbum.Name = "RichTextBoxAlbum";
			this.RichTextBoxAlbum.ReadOnly = true;
			this.RichTextBoxAlbum.Size = new System.Drawing.Size(633, 613);
			this.RichTextBoxAlbum.TabIndex = 8;
			this.RichTextBoxAlbum.Text = "";
			// 
			// RichTextBoxTitle
			// 
			this.RichTextBoxTitle.Location = new System.Drawing.Point(978, 49);
			this.RichTextBoxTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RichTextBoxTitle.Name = "RichTextBoxTitle";
			this.RichTextBoxTitle.ReadOnly = true;
			this.RichTextBoxTitle.Size = new System.Drawing.Size(633, 613);
			this.RichTextBoxTitle.TabIndex = 9;
			this.RichTextBoxTitle.Text = "";
			// 
			// LabelArtist
			// 
			this.LabelArtist.AutoSize = true;
			this.LabelArtist.Location = new System.Drawing.Point(149, 31);
			this.LabelArtist.Name = "LabelArtist";
			this.LabelArtist.Size = new System.Drawing.Size(50, 17);
			this.LabelArtist.TabIndex = 10;
			this.LabelArtist.Text = "Artist";
			// 
			// LabelAlbum
			// 
			this.LabelAlbum.AutoSize = true;
			this.LabelAlbum.Location = new System.Drawing.Point(627, 31);
			this.LabelAlbum.Name = "LabelAlbum";
			this.LabelAlbum.Size = new System.Drawing.Size(57, 17);
			this.LabelAlbum.TabIndex = 11;
			this.LabelAlbum.Text = "Album";
			// 
			// LabelTitle
			// 
			this.LabelTitle.AutoSize = true;
			this.LabelTitle.Location = new System.Drawing.Point(1272, 31);
			this.LabelTitle.Name = "LabelTitle";
			this.LabelTitle.Size = new System.Drawing.Size(41, 17);
			this.LabelTitle.TabIndex = 12;
			this.LabelTitle.Text = "Title";
			// 
			// LabelTimeElapsed
			// 
			this.LabelTimeElapsed.AutoSize = true;
			this.LabelTimeElapsed.Location = new System.Drawing.Point(805, 9);
			this.LabelTimeElapsed.Name = "LabelTimeElapsed";
			this.LabelTimeElapsed.Size = new System.Drawing.Size(167, 17);
			this.LabelTimeElapsed.TabIndex = 13;
			this.LabelTimeElapsed.Text = "Time Elapsed: 00:00";
			// 
			// LabelThreadsStatus
			// 
			this.LabelThreadsStatus.AutoSize = true;
			this.LabelThreadsStatus.Location = new System.Drawing.Point(116, 669);
			this.LabelThreadsStatus.Name = "LabelThreadsStatus";
			this.LabelThreadsStatus.Size = new System.Drawing.Size(125, 17);
			this.LabelThreadsStatus.TabIndex = 14;
			this.LabelThreadsStatus.Text = "Threads Status";
			// 
			// TextBoxThreadsStatus
			// 
			this.TextBoxThreadsStatus.Location = new System.Drawing.Point(16, 695);
			this.TextBoxThreadsStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxThreadsStatus.Multiline = true;
			this.TextBoxThreadsStatus.Name = "TextBoxThreadsStatus";
			this.TextBoxThreadsStatus.Size = new System.Drawing.Size(316, 150);
			this.TextBoxThreadsStatus.TabIndex = 15;
			// 
			// TextBoxCorrectArtist
			// 
			this.TextBoxCorrectArtist.Enabled = false;
			this.TextBoxCorrectArtist.Location = new System.Drawing.Point(627, 696);
			this.TextBoxCorrectArtist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxCorrectArtist.Name = "TextBoxCorrectArtist";
			this.TextBoxCorrectArtist.Size = new System.Drawing.Size(526, 24);
			this.TextBoxCorrectArtist.TabIndex = 16;
			// 
			// TextBoxCorrectAlbum
			// 
			this.TextBoxCorrectAlbum.Enabled = false;
			this.TextBoxCorrectAlbum.Location = new System.Drawing.Point(627, 724);
			this.TextBoxCorrectAlbum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxCorrectAlbum.Name = "TextBoxCorrectAlbum";
			this.TextBoxCorrectAlbum.Size = new System.Drawing.Size(526, 24);
			this.TextBoxCorrectAlbum.TabIndex = 17;
			// 
			// TextBoxCorrectTitle
			// 
			this.TextBoxCorrectTitle.Enabled = false;
			this.TextBoxCorrectTitle.Location = new System.Drawing.Point(627, 752);
			this.TextBoxCorrectTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxCorrectTitle.Name = "TextBoxCorrectTitle";
			this.TextBoxCorrectTitle.Size = new System.Drawing.Size(526, 24);
			this.TextBoxCorrectTitle.TabIndex = 18;
			// 
			// LabelGeniusUrl
			// 
			this.LabelGeniusUrl.AutoSize = true;
			this.LabelGeniusUrl.Location = new System.Drawing.Point(627, 677);
			this.LabelGeniusUrl.Name = "LabelGeniusUrl";
			this.LabelGeniusUrl.Size = new System.Drawing.Size(96, 17);
			this.LabelGeniusUrl.TabIndex = 20;
			this.LabelGeniusUrl.Text = "Genius URL";
			// 
			// LabelCorrectArtist
			// 
			this.LabelCorrectArtist.AutoSize = true;
			this.LabelCorrectArtist.Location = new System.Drawing.Point(569, 697);
			this.LabelCorrectArtist.Name = "LabelCorrectArtist";
			this.LabelCorrectArtist.Size = new System.Drawing.Size(50, 17);
			this.LabelCorrectArtist.TabIndex = 21;
			this.LabelCorrectArtist.Text = "Artist";
			// 
			// LabelCorrectAlbum
			// 
			this.LabelCorrectAlbum.AutoSize = true;
			this.LabelCorrectAlbum.Location = new System.Drawing.Point(562, 728);
			this.LabelCorrectAlbum.Name = "LabelCorrectAlbum";
			this.LabelCorrectAlbum.Size = new System.Drawing.Size(57, 17);
			this.LabelCorrectAlbum.TabIndex = 22;
			this.LabelCorrectAlbum.Text = "Album";
			// 
			// LabelCorrectTitle
			// 
			this.LabelCorrectTitle.AutoSize = true;
			this.LabelCorrectTitle.Location = new System.Drawing.Point(578, 754);
			this.LabelCorrectTitle.Name = "LabelCorrectTitle";
			this.LabelCorrectTitle.Size = new System.Drawing.Size(41, 17);
			this.LabelCorrectTitle.TabIndex = 23;
			this.LabelCorrectTitle.Text = "Title";
			// 
			// ButtonTryAgain
			// 
			this.ButtonTryAgain.AutoSize = true;
			this.ButtonTryAgain.Enabled = false;
			this.ButtonTryAgain.Location = new System.Drawing.Point(848, 780);
			this.ButtonTryAgain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonTryAgain.Name = "ButtonTryAgain";
			this.ButtonTryAgain.Size = new System.Drawing.Size(101, 27);
			this.ButtonTryAgain.TabIndex = 25;
			this.ButtonTryAgain.Text = "Try Again";
			this.ButtonTryAgain.UseVisualStyleBackColor = true;
			this.ButtonTryAgain.Click += new System.EventHandler(this.ButtonTryAgain_Click);
			// 
			// ButtonSkipYear
			// 
			this.ButtonSkipYear.AutoSize = true;
			this.ButtonSkipYear.Enabled = false;
			this.ButtonSkipYear.Location = new System.Drawing.Point(858, 811);
			this.ButtonSkipYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonSkipYear.Name = "ButtonSkipYear";
			this.ButtonSkipYear.Size = new System.Drawing.Size(91, 27);
			this.ButtonSkipYear.TabIndex = 26;
			this.ButtonSkipYear.Text = "Skip Year";
			this.ButtonSkipYear.UseVisualStyleBackColor = true;
			this.ButtonSkipYear.Click += new System.EventHandler(this.ButtonSkipYear_Click);
			// 
			// ButtonSkipLyrics
			// 
			this.ButtonSkipLyrics.AutoSize = true;
			this.ButtonSkipLyrics.Enabled = false;
			this.ButtonSkipLyrics.Location = new System.Drawing.Point(848, 842);
			this.ButtonSkipLyrics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonSkipLyrics.Name = "ButtonSkipLyrics";
			this.ButtonSkipLyrics.Size = new System.Drawing.Size(101, 27);
			this.ButtonSkipLyrics.TabIndex = 27;
			this.ButtonSkipLyrics.Text = "Skip Lyrics";
			this.ButtonSkipLyrics.UseVisualStyleBackColor = true;
			this.ButtonSkipLyrics.Click += new System.EventHandler(this.ButtonSkipLyrics_Click);
			// 
			// GetYearAndLyricsScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ButtonSkipLyrics);
			this.Controls.Add(this.ButtonSkipYear);
			this.Controls.Add(this.ButtonTryAgain);
			this.Controls.Add(this.LabelCorrectTitle);
			this.Controls.Add(this.LabelCorrectAlbum);
			this.Controls.Add(this.LabelCorrectArtist);
			this.Controls.Add(this.LabelGeniusUrl);
			this.Controls.Add(this.TextBoxCorrectTitle);
			this.Controls.Add(this.TextBoxCorrectAlbum);
			this.Controls.Add(this.TextBoxCorrectArtist);
			this.Controls.Add(this.TextBoxThreadsStatus);
			this.Controls.Add(this.LabelThreadsStatus);
			this.Controls.Add(this.LabelTimeElapsed);
			this.Controls.Add(this.LabelTitle);
			this.Controls.Add(this.LabelAlbum);
			this.Controls.Add(this.LabelArtist);
			this.Controls.Add(this.RichTextBoxTitle);
			this.Controls.Add(this.RichTextBoxAlbum);
			this.Controls.Add(this.RichTextBoxArtist);
			this.Controls.Add(this.PictureBoxLabel);
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "GetYearAndLyricsScreen";
			this.Size = new System.Drawing.Size(1879, 871);
			this.Enter += new System.EventHandler(this.GetYearAndLyricsScreen_Enter);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.Controls.SetChildIndex(this.PictureBoxLabel, 0);
			this.Controls.SetChildIndex(this.RichTextBoxArtist, 0);
			this.Controls.SetChildIndex(this.RichTextBoxAlbum, 0);
			this.Controls.SetChildIndex(this.RichTextBoxTitle, 0);
			this.Controls.SetChildIndex(this.LabelArtist, 0);
			this.Controls.SetChildIndex(this.LabelAlbum, 0);
			this.Controls.SetChildIndex(this.LabelTitle, 0);
			this.Controls.SetChildIndex(this.LabelTimeElapsed, 0);
			this.Controls.SetChildIndex(this.LabelThreadsStatus, 0);
			this.Controls.SetChildIndex(this.TextBoxThreadsStatus, 0);
			this.Controls.SetChildIndex(this.TextBoxCorrectArtist, 0);
			this.Controls.SetChildIndex(this.TextBoxCorrectAlbum, 0);
			this.Controls.SetChildIndex(this.TextBoxCorrectTitle, 0);
			this.Controls.SetChildIndex(this.LabelGeniusUrl, 0);
			this.Controls.SetChildIndex(this.LabelCorrectArtist, 0);
			this.Controls.SetChildIndex(this.LabelCorrectAlbum, 0);
			this.Controls.SetChildIndex(this.LabelCorrectTitle, 0);
			this.Controls.SetChildIndex(this.ButtonTryAgain, 0);
			this.Controls.SetChildIndex(this.ButtonSkipYear, 0);
			this.Controls.SetChildIndex(this.ButtonSkipLyrics, 0);
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxLabel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxLabel;
        private System.Windows.Forms.RichTextBox RichTextBoxArtist;
        private System.Windows.Forms.RichTextBox RichTextBoxAlbum;
        private System.Windows.Forms.RichTextBox RichTextBoxTitle;
        private System.Windows.Forms.Label LabelArtist;
        private System.Windows.Forms.Label LabelAlbum;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelTimeElapsed;
        private System.Windows.Forms.Label LabelThreadsStatus;
        private System.Windows.Forms.TextBox TextBoxThreadsStatus;
        private System.Windows.Forms.TextBox TextBoxCorrectArtist;
        private System.Windows.Forms.TextBox TextBoxCorrectAlbum;
        private System.Windows.Forms.TextBox TextBoxCorrectTitle;
        private System.Windows.Forms.Label LabelGeniusUrl;
        private System.Windows.Forms.Label LabelCorrectArtist;
        private System.Windows.Forms.Label LabelCorrectAlbum;
        private System.Windows.Forms.Label LabelCorrectTitle;
        private System.Windows.Forms.Button ButtonTryAgain;
        private System.Windows.Forms.Button ButtonSkipYear;
        private System.Windows.Forms.Button ButtonSkipLyrics;
    }
}
