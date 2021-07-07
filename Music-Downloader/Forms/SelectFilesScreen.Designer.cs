
namespace Forms
{
	partial class SelectFilesScreen
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
			this.ListViewSongFiles = new System.Windows.Forms.ListView();
			this.ColumnHeaderSongTitle = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeaderLastModified = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeaderAlbumArtist = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeaderAlbum = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeaderGenre = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeaderYear = new System.Windows.Forms.ColumnHeader();
			this.ButtonGetYearAndLyrics = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ButtonBack
			// 
			this.ButtonBack.FlatAppearance.BorderSize = 0;
			this.ButtonBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			// 
			// ListViewSongFiles
			// 
			this.ListViewSongFiles.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.ListViewSongFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ListViewSongFiles.CheckBoxes = true;
			this.ListViewSongFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderSongTitle,
            this.ColumnHeaderLastModified,
            this.ColumnHeaderAlbumArtist,
            this.ColumnHeaderAlbum,
            this.ColumnHeaderGenre,
            this.ColumnHeaderYear});
			this.ListViewSongFiles.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ListViewSongFiles.FullRowSelect = true;
			this.ListViewSongFiles.GridLines = true;
			this.ListViewSongFiles.HideSelection = false;
			this.ListViewSongFiles.Location = new System.Drawing.Point(3, 36);
			this.ListViewSongFiles.Name = "ListViewSongFiles";
			this.ListViewSongFiles.Size = new System.Drawing.Size(1648, 884);
			this.ListViewSongFiles.TabIndex = 6;
			this.ListViewSongFiles.UseCompatibleStateImageBehavior = false;
			this.ListViewSongFiles.View = System.Windows.Forms.View.Details;
			this.ListViewSongFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewSongFiles_ColumnClick);
			this.ListViewSongFiles.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewSongFiles_ItemSelectionChanged);
			// 
			// ColumnHeaderSongTitle
			// 
			this.ColumnHeaderSongTitle.Text = "Song Title";
			this.ColumnHeaderSongTitle.Width = 480;
			// 
			// ColumnHeaderLastModified
			// 
			this.ColumnHeaderLastModified.Text = "Last Modified";
			this.ColumnHeaderLastModified.Width = 127;
			// 
			// ColumnHeaderAlbumArtist
			// 
			this.ColumnHeaderAlbumArtist.Text = "Album Artist";
			this.ColumnHeaderAlbumArtist.Width = 290;
			// 
			// ColumnHeaderAlbum
			// 
			this.ColumnHeaderAlbum.Text = "Album";
			this.ColumnHeaderAlbum.Width = 390;
			// 
			// ColumnHeaderGenre
			// 
			this.ColumnHeaderGenre.Text = "Genre";
			this.ColumnHeaderGenre.Width = 80;
			// 
			// ColumnHeaderYear
			// 
			this.ColumnHeaderYear.Text = "Year";
			this.ColumnHeaderYear.Width = 44;
			// 
			// ButtonGetYearAndLyrics
			// 
			this.ButtonGetYearAndLyrics.AutoSize = true;
			this.ButtonGetYearAndLyrics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonGetYearAndLyrics.FlatAppearance.BorderSize = 0;
			this.ButtonGetYearAndLyrics.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonGetYearAndLyrics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonGetYearAndLyrics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonGetYearAndLyrics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonGetYearAndLyrics.Location = new System.Drawing.Point(1353, 4);
			this.ButtonGetYearAndLyrics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonGetYearAndLyrics.Name = "ButtonGetYearAndLyrics";
			this.ButtonGetYearAndLyrics.Size = new System.Drawing.Size(298, 27);
			this.ButtonGetYearAndLyrics.TabIndex = 17;
			this.ButtonGetYearAndLyrics.Text = "Get Year and Lyrics of Selected Files";
			this.ButtonGetYearAndLyrics.UseVisualStyleBackColor = true;
			this.ButtonGetYearAndLyrics.Click += new System.EventHandler(this.ButtonGetYearAndLyrics_Click);
			// 
			// SelectFilesScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ButtonGetYearAndLyrics);
			this.Controls.Add(this.ListViewSongFiles);
			this.Name = "SelectFilesScreen";
			this.Size = new System.Drawing.Size(1925, 923);
			this.Enter += new System.EventHandler(this.SelectFilesScreen_Enter);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.Controls.SetChildIndex(this.ListViewSongFiles, 0);
			this.Controls.SetChildIndex(this.ButtonGetYearAndLyrics, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView ListViewSongFiles;
		private System.Windows.Forms.ColumnHeader ColumnHeaderLastModified;
		private System.Windows.Forms.ColumnHeader ColumnHeaderSongTitle;
		private System.Windows.Forms.ColumnHeader ColumnHeaderAlbumArtist;
		private System.Windows.Forms.ColumnHeader ColumnHeaderGenre;
		private System.Windows.Forms.ColumnHeader ColumnHeaderYear;
		private System.Windows.Forms.Button ButtonGetYearAndLyrics;
		private System.Windows.Forms.ColumnHeader ColumnHeaderAlbum;
	}
}
