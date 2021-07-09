
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
			this.LabelArtist = new System.Windows.Forms.Label();
			this.LabelAlbum = new System.Windows.Forms.Label();
			this.LabelTitle = new System.Windows.Forms.Label();
			this.LabelTimeElapsed = new System.Windows.Forms.Label();
			this.LabelThreadsStatus = new System.Windows.Forms.Label();
			this.TextBoxThreadsStatus = new System.Windows.Forms.TextBox();
			this.TextBoxCorrectArtist = new System.Windows.Forms.TextBox();
			this.TextBoxCorrectAlbum = new System.Windows.Forms.TextBox();
			this.TextBoxCorrectTitle = new System.Windows.Forms.TextBox();
			this.LabelUrl = new System.Windows.Forms.Label();
			this.LabelCorrectArtist = new System.Windows.Forms.Label();
			this.LabelCorrectAlbum = new System.Windows.Forms.Label();
			this.LabelCorrectTitle = new System.Windows.Forms.Label();
			this.ButtonTryAgain = new System.Windows.Forms.Button();
			this.ButtonSkipYear = new System.Windows.Forms.Button();
			this.ButtonSkipLyrics = new System.Windows.Forms.Button();
			this.CheckBoxScrollToEnd = new System.Windows.Forms.CheckBox();
			this.SyncRichTextBoxArtist = new Forms.SyncRichTextBox();
			this.SyncRichTextBoxAlbum = new Forms.SyncRichTextBox();
			this.SyncRichTextBoxTitle = new Forms.SyncRichTextBox();
			this.SyncRichTextBoxThreadIdStartEndTimes = new Forms.SyncRichTextBox();
			this.LabelThreadIdStartAndEnd = new System.Windows.Forms.Label();
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
			this.PictureBoxLabel.Location = new System.Drawing.Point(1620, 179);
			this.PictureBoxLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PictureBoxLabel.Name = "PictureBoxLabel";
			this.PictureBoxLabel.Size = new System.Drawing.Size(251, 200);
			this.PictureBoxLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PictureBoxLabel.TabIndex = 6;
			this.PictureBoxLabel.TabStop = false;
			// 
			// LabelArtist
			// 
			this.LabelArtist.AutoSize = true;
			this.LabelArtist.Location = new System.Drawing.Point(315, 55);
			this.LabelArtist.Name = "LabelArtist";
			this.LabelArtist.Size = new System.Drawing.Size(50, 17);
			this.LabelArtist.TabIndex = 10;
			this.LabelArtist.Text = "Artist";
			// 
			// LabelAlbum
			// 
			this.LabelAlbum.AutoSize = true;
			this.LabelAlbum.Location = new System.Drawing.Point(736, 55);
			this.LabelAlbum.Name = "LabelAlbum";
			this.LabelAlbum.Size = new System.Drawing.Size(57, 17);
			this.LabelAlbum.TabIndex = 11;
			this.LabelAlbum.Text = "Album";
			// 
			// LabelTitle
			// 
			this.LabelTitle.AutoSize = true;
			this.LabelTitle.Location = new System.Drawing.Point(1317, 55);
			this.LabelTitle.Name = "LabelTitle";
			this.LabelTitle.Size = new System.Drawing.Size(41, 17);
			this.LabelTitle.TabIndex = 12;
			this.LabelTitle.Text = "Title";
			// 
			// LabelTimeElapsed
			// 
			this.LabelTimeElapsed.AutoSize = true;
			this.LabelTimeElapsed.Location = new System.Drawing.Point(899, 8);
			this.LabelTimeElapsed.Name = "LabelTimeElapsed";
			this.LabelTimeElapsed.Size = new System.Drawing.Size(193, 17);
			this.LabelTimeElapsed.TabIndex = 13;
			this.LabelTimeElapsed.Text = "Time Elapsed: 00:00:00";
			// 
			// LabelThreadsStatus
			// 
			this.LabelThreadsStatus.AutoSize = true;
			this.LabelThreadsStatus.Location = new System.Drawing.Point(114, 796);
			this.LabelThreadsStatus.Name = "LabelThreadsStatus";
			this.LabelThreadsStatus.Size = new System.Drawing.Size(125, 17);
			this.LabelThreadsStatus.TabIndex = 14;
			this.LabelThreadsStatus.Text = "Threads Status";
			// 
			// TextBoxThreadsStatus
			// 
			this.TextBoxThreadsStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxThreadsStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxThreadsStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxThreadsStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxThreadsStatus.Location = new System.Drawing.Point(20, 815);
			this.TextBoxThreadsStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxThreadsStatus.Multiline = true;
			this.TextBoxThreadsStatus.Name = "TextBoxThreadsStatus";
			this.TextBoxThreadsStatus.Size = new System.Drawing.Size(316, 150);
			this.TextBoxThreadsStatus.TabIndex = 15;
			// 
			// TextBoxCorrectArtist
			// 
			this.TextBoxCorrectArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxCorrectArtist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxCorrectArtist.Enabled = false;
			this.TextBoxCorrectArtist.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxCorrectArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxCorrectArtist.Location = new System.Drawing.Point(736, 815);
			this.TextBoxCorrectArtist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxCorrectArtist.Name = "TextBoxCorrectArtist";
			this.TextBoxCorrectArtist.Size = new System.Drawing.Size(526, 24);
			this.TextBoxCorrectArtist.TabIndex = 16;
			// 
			// TextBoxCorrectAlbum
			// 
			this.TextBoxCorrectAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxCorrectAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxCorrectAlbum.Enabled = false;
			this.TextBoxCorrectAlbum.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxCorrectAlbum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxCorrectAlbum.Location = new System.Drawing.Point(736, 843);
			this.TextBoxCorrectAlbum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxCorrectAlbum.Name = "TextBoxCorrectAlbum";
			this.TextBoxCorrectAlbum.Size = new System.Drawing.Size(526, 24);
			this.TextBoxCorrectAlbum.TabIndex = 17;
			// 
			// TextBoxCorrectTitle
			// 
			this.TextBoxCorrectTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxCorrectTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxCorrectTitle.Enabled = false;
			this.TextBoxCorrectTitle.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxCorrectTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxCorrectTitle.Location = new System.Drawing.Point(736, 871);
			this.TextBoxCorrectTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextBoxCorrectTitle.Name = "TextBoxCorrectTitle";
			this.TextBoxCorrectTitle.Size = new System.Drawing.Size(526, 24);
			this.TextBoxCorrectTitle.TabIndex = 18;
			// 
			// LabelUrl
			// 
			this.LabelUrl.AutoSize = true;
			this.LabelUrl.Location = new System.Drawing.Point(736, 796);
			this.LabelUrl.Name = "LabelUrl";
			this.LabelUrl.Size = new System.Drawing.Size(39, 17);
			this.LabelUrl.TabIndex = 20;
			this.LabelUrl.Text = "URL";
			// 
			// LabelCorrectArtist
			// 
			this.LabelCorrectArtist.AutoSize = true;
			this.LabelCorrectArtist.Location = new System.Drawing.Point(678, 816);
			this.LabelCorrectArtist.Name = "LabelCorrectArtist";
			this.LabelCorrectArtist.Size = new System.Drawing.Size(50, 17);
			this.LabelCorrectArtist.TabIndex = 21;
			this.LabelCorrectArtist.Text = "Artist";
			// 
			// LabelCorrectAlbum
			// 
			this.LabelCorrectAlbum.AutoSize = true;
			this.LabelCorrectAlbum.Location = new System.Drawing.Point(671, 847);
			this.LabelCorrectAlbum.Name = "LabelCorrectAlbum";
			this.LabelCorrectAlbum.Size = new System.Drawing.Size(57, 17);
			this.LabelCorrectAlbum.TabIndex = 22;
			this.LabelCorrectAlbum.Text = "Album";
			// 
			// LabelCorrectTitle
			// 
			this.LabelCorrectTitle.AutoSize = true;
			this.LabelCorrectTitle.Location = new System.Drawing.Point(687, 873);
			this.LabelCorrectTitle.Name = "LabelCorrectTitle";
			this.LabelCorrectTitle.Size = new System.Drawing.Size(41, 17);
			this.LabelCorrectTitle.TabIndex = 23;
			this.LabelCorrectTitle.Text = "Title";
			// 
			// ButtonTryAgain
			// 
			this.ButtonTryAgain.AutoSize = true;
			this.ButtonTryAgain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonTryAgain.BackColor = System.Drawing.Color.Transparent;
			this.ButtonTryAgain.Enabled = false;
			this.ButtonTryAgain.FlatAppearance.BorderSize = 0;
			this.ButtonTryAgain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonTryAgain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonTryAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonTryAgain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonTryAgain.Location = new System.Drawing.Point(957, 899);
			this.ButtonTryAgain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonTryAgain.Name = "ButtonTryAgain";
			this.ButtonTryAgain.Size = new System.Drawing.Size(93, 27);
			this.ButtonTryAgain.TabIndex = 25;
			this.ButtonTryAgain.Text = "Try Again";
			this.ButtonTryAgain.UseVisualStyleBackColor = false;
			this.ButtonTryAgain.Click += new System.EventHandler(this.ButtonTryAgain_Click);
			// 
			// ButtonSkipYear
			// 
			this.ButtonSkipYear.AutoSize = true;
			this.ButtonSkipYear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonSkipYear.Enabled = false;
			this.ButtonSkipYear.FlatAppearance.BorderSize = 0;
			this.ButtonSkipYear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonSkipYear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonSkipYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonSkipYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonSkipYear.Location = new System.Drawing.Point(957, 930);
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
			this.ButtonSkipLyrics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonSkipLyrics.Enabled = false;
			this.ButtonSkipLyrics.FlatAppearance.BorderSize = 0;
			this.ButtonSkipLyrics.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonSkipLyrics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonSkipLyrics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonSkipLyrics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonSkipLyrics.Location = new System.Drawing.Point(957, 961);
			this.ButtonSkipLyrics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonSkipLyrics.Name = "ButtonSkipLyrics";
			this.ButtonSkipLyrics.Size = new System.Drawing.Size(101, 27);
			this.ButtonSkipLyrics.TabIndex = 27;
			this.ButtonSkipLyrics.Text = "Skip Lyrics";
			this.ButtonSkipLyrics.UseVisualStyleBackColor = true;
			this.ButtonSkipLyrics.Click += new System.EventHandler(this.ButtonSkipLyrics_Click);
			// 
			// CheckBoxScrollToEnd
			// 
			this.CheckBoxScrollToEnd.AutoSize = true;
			this.CheckBoxScrollToEnd.Checked = true;
			this.CheckBoxScrollToEnd.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxScrollToEnd.FlatAppearance.BorderSize = 0;
			this.CheckBoxScrollToEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.CheckBoxScrollToEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.CheckBoxScrollToEnd.ForeColor = System.Drawing.Color.Green;
			this.CheckBoxScrollToEnd.Location = new System.Drawing.Point(1616, 76);
			this.CheckBoxScrollToEnd.Name = "CheckBoxScrollToEnd";
			this.CheckBoxScrollToEnd.Size = new System.Drawing.Size(255, 21);
			this.CheckBoxScrollToEnd.TabIndex = 29;
			this.CheckBoxScrollToEnd.Text = "Scroll To the End on Addition";
			this.CheckBoxScrollToEnd.UseVisualStyleBackColor = true;
			this.CheckBoxScrollToEnd.CheckedChanged += new System.EventHandler(this.CheckBoxScrollToEnd_CheckedChanged);
			// 
			// SyncRichTextBoxArtist
			// 
			this.SyncRichTextBoxArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.SyncRichTextBoxArtist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SyncRichTextBoxArtist.Buddies = null;
			this.SyncRichTextBoxArtist.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SyncRichTextBoxArtist.ForeColor = System.Drawing.Color.Yellow;
			this.SyncRichTextBoxArtist.Location = new System.Drawing.Point(193, 75);
			this.SyncRichTextBoxArtist.Name = "SyncRichTextBoxArtist";
			this.SyncRichTextBoxArtist.ReadOnly = true;
			this.SyncRichTextBoxArtist.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.SyncRichTextBoxArtist.Size = new System.Drawing.Size(281, 711);
			this.SyncRichTextBoxArtist.TabIndex = 30;
			this.SyncRichTextBoxArtist.Text = "";
			// 
			// SyncRichTextBoxAlbum
			// 
			this.SyncRichTextBoxAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.SyncRichTextBoxAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SyncRichTextBoxAlbum.Buddies = null;
			this.SyncRichTextBoxAlbum.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SyncRichTextBoxAlbum.ForeColor = System.Drawing.Color.Yellow;
			this.SyncRichTextBoxAlbum.Location = new System.Drawing.Point(480, 75);
			this.SyncRichTextBoxAlbum.Name = "SyncRichTextBoxAlbum";
			this.SyncRichTextBoxAlbum.ReadOnly = true;
			this.SyncRichTextBoxAlbum.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.SyncRichTextBoxAlbum.Size = new System.Drawing.Size(562, 711);
			this.SyncRichTextBoxAlbum.TabIndex = 31;
			this.SyncRichTextBoxAlbum.Text = "";
			// 
			// SyncRichTextBoxTitle
			// 
			this.SyncRichTextBoxTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.SyncRichTextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SyncRichTextBoxTitle.Buddies = null;
			this.SyncRichTextBoxTitle.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SyncRichTextBoxTitle.ForeColor = System.Drawing.Color.Yellow;
			this.SyncRichTextBoxTitle.Location = new System.Drawing.Point(1048, 75);
			this.SyncRichTextBoxTitle.Name = "SyncRichTextBoxTitle";
			this.SyncRichTextBoxTitle.ReadOnly = true;
			this.SyncRichTextBoxTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.SyncRichTextBoxTitle.Size = new System.Drawing.Size(562, 712);
			this.SyncRichTextBoxTitle.TabIndex = 32;
			this.SyncRichTextBoxTitle.Text = "";
			// 
			// SyncRichTextBoxThreadIdStartEndTimes
			// 
			this.SyncRichTextBoxThreadIdStartEndTimes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.SyncRichTextBoxThreadIdStartEndTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SyncRichTextBoxThreadIdStartEndTimes.Buddies = null;
			this.SyncRichTextBoxThreadIdStartEndTimes.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SyncRichTextBoxThreadIdStartEndTimes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.SyncRichTextBoxThreadIdStartEndTimes.Location = new System.Drawing.Point(20, 75);
			this.SyncRichTextBoxThreadIdStartEndTimes.Name = "SyncRichTextBoxThreadIdStartEndTimes";
			this.SyncRichTextBoxThreadIdStartEndTimes.ReadOnly = true;
			this.SyncRichTextBoxThreadIdStartEndTimes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.SyncRichTextBoxThreadIdStartEndTimes.Size = new System.Drawing.Size(167, 711);
			this.SyncRichTextBoxThreadIdStartEndTimes.TabIndex = 33;
			this.SyncRichTextBoxThreadIdStartEndTimes.Text = "";
			// 
			// LabelThreadIdStartAndEnd
			// 
			this.LabelThreadIdStartAndEnd.Location = new System.Drawing.Point(20, 33);
			this.LabelThreadIdStartAndEnd.Name = "LabelThreadIdStartAndEnd";
			this.LabelThreadIdStartAndEnd.Size = new System.Drawing.Size(167, 39);
			this.LabelThreadIdStartAndEnd.TabIndex = 34;
			this.LabelThreadIdStartAndEnd.Text = "Thread Id,Start Time and End Time";
			// 
			// GetYearAndLyricsScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.LabelThreadIdStartAndEnd);
			this.Controls.Add(this.SyncRichTextBoxThreadIdStartEndTimes);
			this.Controls.Add(this.SyncRichTextBoxTitle);
			this.Controls.Add(this.SyncRichTextBoxAlbum);
			this.Controls.Add(this.SyncRichTextBoxArtist);
			this.Controls.Add(this.CheckBoxScrollToEnd);
			this.Controls.Add(this.ButtonSkipLyrics);
			this.Controls.Add(this.ButtonSkipYear);
			this.Controls.Add(this.ButtonTryAgain);
			this.Controls.Add(this.LabelCorrectTitle);
			this.Controls.Add(this.LabelCorrectAlbum);
			this.Controls.Add(this.LabelCorrectArtist);
			this.Controls.Add(this.LabelUrl);
			this.Controls.Add(this.TextBoxCorrectTitle);
			this.Controls.Add(this.TextBoxCorrectAlbum);
			this.Controls.Add(this.TextBoxCorrectArtist);
			this.Controls.Add(this.TextBoxThreadsStatus);
			this.Controls.Add(this.LabelThreadsStatus);
			this.Controls.Add(this.LabelTimeElapsed);
			this.Controls.Add(this.LabelTitle);
			this.Controls.Add(this.LabelAlbum);
			this.Controls.Add(this.LabelArtist);
			this.Controls.Add(this.PictureBoxLabel);
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "GetYearAndLyricsScreen";
			this.Size = new System.Drawing.Size(1879, 990);
			this.Enter += new System.EventHandler(this.GetYearAndLyricsScreen_Enter);
			this.Controls.SetChildIndex(this.PictureBoxLabel, 0);
			this.Controls.SetChildIndex(this.LabelArtist, 0);
			this.Controls.SetChildIndex(this.LabelAlbum, 0);
			this.Controls.SetChildIndex(this.LabelTitle, 0);
			this.Controls.SetChildIndex(this.LabelTimeElapsed, 0);
			this.Controls.SetChildIndex(this.LabelThreadsStatus, 0);
			this.Controls.SetChildIndex(this.TextBoxThreadsStatus, 0);
			this.Controls.SetChildIndex(this.TextBoxCorrectArtist, 0);
			this.Controls.SetChildIndex(this.TextBoxCorrectAlbum, 0);
			this.Controls.SetChildIndex(this.TextBoxCorrectTitle, 0);
			this.Controls.SetChildIndex(this.LabelUrl, 0);
			this.Controls.SetChildIndex(this.LabelCorrectArtist, 0);
			this.Controls.SetChildIndex(this.LabelCorrectAlbum, 0);
			this.Controls.SetChildIndex(this.LabelCorrectTitle, 0);
			this.Controls.SetChildIndex(this.ButtonTryAgain, 0);
			this.Controls.SetChildIndex(this.ButtonSkipYear, 0);
			this.Controls.SetChildIndex(this.ButtonSkipLyrics, 0);
			this.Controls.SetChildIndex(this.CheckBoxScrollToEnd, 0);
			this.Controls.SetChildIndex(this.SyncRichTextBoxArtist, 0);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.Controls.SetChildIndex(this.SyncRichTextBoxAlbum, 0);
			this.Controls.SetChildIndex(this.SyncRichTextBoxTitle, 0);
			this.Controls.SetChildIndex(this.SyncRichTextBoxThreadIdStartEndTimes, 0);
			this.Controls.SetChildIndex(this.LabelThreadIdStartAndEnd, 0);
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxLabel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxLabel;
        private System.Windows.Forms.Label LabelArtist;
        private System.Windows.Forms.Label LabelAlbum;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelTimeElapsed;
        private System.Windows.Forms.Label LabelThreadsStatus;
        private System.Windows.Forms.TextBox TextBoxThreadsStatus;
        private System.Windows.Forms.TextBox TextBoxCorrectArtist;
        private System.Windows.Forms.TextBox TextBoxCorrectAlbum;
        private System.Windows.Forms.TextBox TextBoxCorrectTitle;
        private System.Windows.Forms.Label LabelUrl;
        private System.Windows.Forms.Label LabelCorrectArtist;
        private System.Windows.Forms.Label LabelCorrectAlbum;
        private System.Windows.Forms.Label LabelCorrectTitle;
        private System.Windows.Forms.Button ButtonTryAgain;
        private System.Windows.Forms.Button ButtonSkipYear;
        private System.Windows.Forms.Button ButtonSkipLyrics;
		private System.Windows.Forms.CheckBox CheckBoxScrollToEnd;
		private SyncRichTextBox SyncRichTextBoxArtist;
		private SyncRichTextBox SyncRichTextBoxAlbum;
		private SyncRichTextBox SyncRichTextBoxTitle;
		private SyncRichTextBox SyncRichTextBoxThreadIdStartEndTimes;
		private System.Windows.Forms.Label LabelThreadIdStartAndEnd;
	}
}
