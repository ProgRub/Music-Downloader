
namespace Forms
{
	partial class ManageExceptionsScreen
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
			this.LabelExceptionType = new System.Windows.Forms.Label();
			this.ComboBoxExceptionTypes = new System.Windows.Forms.ComboBox();
			this.ListBoxExceptions = new System.Windows.Forms.ListBox();
			this.ButtonRedo = new System.Windows.Forms.Button();
			this.ButtonUndo = new System.Windows.Forms.Button();
			this.LabelOriginalArtist = new System.Windows.Forms.Label();
			this.TextBoxOriginalArtist = new System.Windows.Forms.TextBox();
			this.TextBoxOriginalAlbum = new System.Windows.Forms.TextBox();
			this.LabelOriginalAlbum = new System.Windows.Forms.Label();
			this.TextBoxOriginalTitle = new System.Windows.Forms.TextBox();
			this.LabelOriginalTitle = new System.Windows.Forms.Label();
			this.TextBoxNewArtist = new System.Windows.Forms.TextBox();
			this.LabelNewArtist = new System.Windows.Forms.Label();
			this.TextBoxNewAlbum = new System.Windows.Forms.TextBox();
			this.LabelNewAlbum = new System.Windows.Forms.Label();
			this.TextBoxNewTitle = new System.Windows.Forms.TextBox();
			this.LabelNewTitle = new System.Windows.Forms.Label();
			this.ButtonAddChange = new System.Windows.Forms.Button();
			this.ButtonDeleteSelected = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ButtonBack
			// 
			this.ButtonBack.FlatAppearance.BorderSize = 0;
			this.ButtonBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			// 
			// LabelExceptionType
			// 
			this.LabelExceptionType.AutoSize = true;
			this.LabelExceptionType.Location = new System.Drawing.Point(15, 45);
			this.LabelExceptionType.Name = "LabelExceptionType";
			this.LabelExceptionType.Size = new System.Drawing.Size(133, 17);
			this.LabelExceptionType.TabIndex = 6;
			this.LabelExceptionType.Text = "Exception Type:";
			this.LabelExceptionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ComboBoxExceptionTypes
			// 
			this.ComboBoxExceptionTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.ComboBoxExceptionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxExceptionTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ComboBoxExceptionTypes.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ComboBoxExceptionTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.ComboBoxExceptionTypes.FormattingEnabled = true;
			this.ComboBoxExceptionTypes.Items.AddRange(new object[] {
            "Change Details For Album Year",
            "Change Details For Lyrics",
            "Skip Year",
            "Skip Lyrics"});
			this.ComboBoxExceptionTypes.Location = new System.Drawing.Point(154, 42);
			this.ComboBoxExceptionTypes.Name = "ComboBoxExceptionTypes";
			this.ComboBoxExceptionTypes.Size = new System.Drawing.Size(483, 24);
			this.ComboBoxExceptionTypes.TabIndex = 7;
			this.ComboBoxExceptionTypes.TextChanged += new System.EventHandler(this.ComboBoxExceptionTypes_TextChanged);
			// 
			// ListBoxExceptions
			// 
			this.ListBoxExceptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.ListBoxExceptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ListBoxExceptions.Enabled = false;
			this.ListBoxExceptions.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ListBoxExceptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.ListBoxExceptions.FormattingEnabled = true;
			this.ListBoxExceptions.ItemHeight = 16;
			this.ListBoxExceptions.Location = new System.Drawing.Point(643, 42);
			this.ListBoxExceptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBoxExceptions.Name = "ListBoxExceptions";
			this.ListBoxExceptions.Size = new System.Drawing.Size(813, 434);
			this.ListBoxExceptions.TabIndex = 8;
			this.ListBoxExceptions.SelectedIndexChanged += new System.EventHandler(this.ListBoxExceptions_SelectedIndexChanged);
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
			this.ButtonRedo.Location = new System.Drawing.Point(1076, 480);
			this.ButtonRedo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonRedo.Name = "ButtonRedo";
			this.ButtonRedo.Size = new System.Drawing.Size(37, 29);
			this.ButtonRedo.TabIndex = 15;
			this.ButtonRedo.UseVisualStyleBackColor = true;
			this.ButtonRedo.Click += new System.EventHandler(this.ButtonRedo_Click);
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
			this.ButtonUndo.Location = new System.Drawing.Point(1033, 480);
			this.ButtonUndo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonUndo.Name = "ButtonUndo";
			this.ButtonUndo.Size = new System.Drawing.Size(37, 29);
			this.ButtonUndo.TabIndex = 14;
			this.ButtonUndo.UseVisualStyleBackColor = true;
			this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
			// 
			// LabelOriginalArtist
			// 
			this.LabelOriginalArtist.AutoSize = true;
			this.LabelOriginalArtist.Location = new System.Drawing.Point(27, 74);
			this.LabelOriginalArtist.Name = "LabelOriginalArtist";
			this.LabelOriginalArtist.Size = new System.Drawing.Size(121, 17);
			this.LabelOriginalArtist.TabIndex = 16;
			this.LabelOriginalArtist.Text = "Original Artist:";
			this.LabelOriginalArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LabelOriginalArtist.Visible = false;
			// 
			// TextBoxOriginalArtist
			// 
			this.TextBoxOriginalArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxOriginalArtist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxOriginalArtist.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxOriginalArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxOriginalArtist.Location = new System.Drawing.Point(154, 72);
			this.TextBoxOriginalArtist.Name = "TextBoxOriginalArtist";
			this.TextBoxOriginalArtist.Size = new System.Drawing.Size(483, 24);
			this.TextBoxOriginalArtist.TabIndex = 17;
			this.TextBoxOriginalArtist.Visible = false;
			// 
			// TextBoxOriginalAlbum
			// 
			this.TextBoxOriginalAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxOriginalAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxOriginalAlbum.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxOriginalAlbum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxOriginalAlbum.Location = new System.Drawing.Point(154, 102);
			this.TextBoxOriginalAlbum.Name = "TextBoxOriginalAlbum";
			this.TextBoxOriginalAlbum.Size = new System.Drawing.Size(483, 24);
			this.TextBoxOriginalAlbum.TabIndex = 19;
			this.TextBoxOriginalAlbum.Visible = false;
			// 
			// LabelOriginalAlbum
			// 
			this.LabelOriginalAlbum.AutoSize = true;
			this.LabelOriginalAlbum.Location = new System.Drawing.Point(20, 104);
			this.LabelOriginalAlbum.Name = "LabelOriginalAlbum";
			this.LabelOriginalAlbum.Size = new System.Drawing.Size(128, 17);
			this.LabelOriginalAlbum.TabIndex = 18;
			this.LabelOriginalAlbum.Text = "Original Album:";
			this.LabelOriginalAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LabelOriginalAlbum.Visible = false;
			// 
			// TextBoxOriginalTitle
			// 
			this.TextBoxOriginalTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxOriginalTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxOriginalTitle.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxOriginalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxOriginalTitle.Location = new System.Drawing.Point(154, 132);
			this.TextBoxOriginalTitle.Name = "TextBoxOriginalTitle";
			this.TextBoxOriginalTitle.Size = new System.Drawing.Size(483, 24);
			this.TextBoxOriginalTitle.TabIndex = 21;
			this.TextBoxOriginalTitle.Visible = false;
			// 
			// LabelOriginalTitle
			// 
			this.LabelOriginalTitle.AutoSize = true;
			this.LabelOriginalTitle.Location = new System.Drawing.Point(36, 134);
			this.LabelOriginalTitle.Name = "LabelOriginalTitle";
			this.LabelOriginalTitle.Size = new System.Drawing.Size(112, 17);
			this.LabelOriginalTitle.TabIndex = 20;
			this.LabelOriginalTitle.Text = "Original Title:";
			this.LabelOriginalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LabelOriginalTitle.Visible = false;
			// 
			// TextBoxNewArtist
			// 
			this.TextBoxNewArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxNewArtist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxNewArtist.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxNewArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxNewArtist.Location = new System.Drawing.Point(154, 162);
			this.TextBoxNewArtist.Name = "TextBoxNewArtist";
			this.TextBoxNewArtist.Size = new System.Drawing.Size(483, 24);
			this.TextBoxNewArtist.TabIndex = 23;
			this.TextBoxNewArtist.Visible = false;
			// 
			// LabelNewArtist
			// 
			this.LabelNewArtist.AutoSize = true;
			this.LabelNewArtist.Location = new System.Drawing.Point(53, 164);
			this.LabelNewArtist.Name = "LabelNewArtist";
			this.LabelNewArtist.Size = new System.Drawing.Size(95, 17);
			this.LabelNewArtist.TabIndex = 22;
			this.LabelNewArtist.Text = "New Artist:";
			this.LabelNewArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LabelNewArtist.Visible = false;
			// 
			// TextBoxNewAlbum
			// 
			this.TextBoxNewAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxNewAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxNewAlbum.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxNewAlbum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxNewAlbum.Location = new System.Drawing.Point(154, 192);
			this.TextBoxNewAlbum.Name = "TextBoxNewAlbum";
			this.TextBoxNewAlbum.Size = new System.Drawing.Size(483, 24);
			this.TextBoxNewAlbum.TabIndex = 25;
			this.TextBoxNewAlbum.Visible = false;
			// 
			// LabelNewAlbum
			// 
			this.LabelNewAlbum.AutoSize = true;
			this.LabelNewAlbum.Location = new System.Drawing.Point(46, 194);
			this.LabelNewAlbum.Name = "LabelNewAlbum";
			this.LabelNewAlbum.Size = new System.Drawing.Size(102, 17);
			this.LabelNewAlbum.TabIndex = 24;
			this.LabelNewAlbum.Text = "New Album:";
			this.LabelNewAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LabelNewAlbum.Visible = false;
			// 
			// TextBoxNewTitle
			// 
			this.TextBoxNewTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxNewTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxNewTitle.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxNewTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxNewTitle.Location = new System.Drawing.Point(154, 222);
			this.TextBoxNewTitle.Name = "TextBoxNewTitle";
			this.TextBoxNewTitle.Size = new System.Drawing.Size(483, 24);
			this.TextBoxNewTitle.TabIndex = 27;
			this.TextBoxNewTitle.Visible = false;
			// 
			// LabelNewTitle
			// 
			this.LabelNewTitle.AutoSize = true;
			this.LabelNewTitle.Location = new System.Drawing.Point(62, 224);
			this.LabelNewTitle.Name = "LabelNewTitle";
			this.LabelNewTitle.Size = new System.Drawing.Size(86, 17);
			this.LabelNewTitle.TabIndex = 26;
			this.LabelNewTitle.Text = "New Title:";
			this.LabelNewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LabelNewTitle.Visible = false;
			// 
			// ButtonAddChange
			// 
			this.ButtonAddChange.AutoSize = true;
			this.ButtonAddChange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonAddChange.Enabled = false;
			this.ButtonAddChange.FlatAppearance.BorderSize = 0;
			this.ButtonAddChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonAddChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonAddChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonAddChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonAddChange.Location = new System.Drawing.Point(332, 252);
			this.ButtonAddChange.Name = "ButtonAddChange";
			this.ButtonAddChange.Size = new System.Drawing.Size(118, 27);
			this.ButtonAddChange.TabIndex = 28;
			this.ButtonAddChange.Text = "Add/Change";
			this.ButtonAddChange.UseVisualStyleBackColor = true;
			this.ButtonAddChange.Visible = false;
			this.ButtonAddChange.Click += new System.EventHandler(this.ButtonAddChange_Click);
			// 
			// ButtonDeleteSelected
			// 
			this.ButtonDeleteSelected.AutoSize = true;
			this.ButtonDeleteSelected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonDeleteSelected.Enabled = false;
			this.ButtonDeleteSelected.FlatAppearance.BorderSize = 0;
			this.ButtonDeleteSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonDeleteSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonDeleteSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonDeleteSelected.Location = new System.Drawing.Point(323, 285);
			this.ButtonDeleteSelected.Name = "ButtonDeleteSelected";
			this.ButtonDeleteSelected.Size = new System.Drawing.Size(136, 27);
			this.ButtonDeleteSelected.TabIndex = 29;
			this.ButtonDeleteSelected.Text = "Delete Selected";
			this.ButtonDeleteSelected.UseVisualStyleBackColor = true;
			this.ButtonDeleteSelected.Visible = false;
			this.ButtonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteSelected_Click);
			// 
			// ManageExceptionsScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ButtonDeleteSelected);
			this.Controls.Add(this.ButtonAddChange);
			this.Controls.Add(this.TextBoxNewTitle);
			this.Controls.Add(this.LabelNewTitle);
			this.Controls.Add(this.TextBoxNewAlbum);
			this.Controls.Add(this.LabelNewAlbum);
			this.Controls.Add(this.TextBoxNewArtist);
			this.Controls.Add(this.LabelNewArtist);
			this.Controls.Add(this.TextBoxOriginalTitle);
			this.Controls.Add(this.LabelOriginalTitle);
			this.Controls.Add(this.TextBoxOriginalAlbum);
			this.Controls.Add(this.LabelOriginalAlbum);
			this.Controls.Add(this.TextBoxOriginalArtist);
			this.Controls.Add(this.LabelOriginalArtist);
			this.Controls.Add(this.ButtonRedo);
			this.Controls.Add(this.ButtonUndo);
			this.Controls.Add(this.ListBoxExceptions);
			this.Controls.Add(this.ComboBoxExceptionTypes);
			this.Controls.Add(this.LabelExceptionType);
			this.Name = "ManageExceptionsScreen";
			this.Size = new System.Drawing.Size(1541, 549);
			this.Enter += new System.EventHandler(this.ManageExceptionsScreen_Enter);
			this.Controls.SetChildIndex(this.LabelExceptionType, 0);
			this.Controls.SetChildIndex(this.ComboBoxExceptionTypes, 0);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.Controls.SetChildIndex(this.ListBoxExceptions, 0);
			this.Controls.SetChildIndex(this.ButtonUndo, 0);
			this.Controls.SetChildIndex(this.ButtonRedo, 0);
			this.Controls.SetChildIndex(this.LabelOriginalArtist, 0);
			this.Controls.SetChildIndex(this.TextBoxOriginalArtist, 0);
			this.Controls.SetChildIndex(this.LabelOriginalAlbum, 0);
			this.Controls.SetChildIndex(this.TextBoxOriginalAlbum, 0);
			this.Controls.SetChildIndex(this.LabelOriginalTitle, 0);
			this.Controls.SetChildIndex(this.TextBoxOriginalTitle, 0);
			this.Controls.SetChildIndex(this.LabelNewArtist, 0);
			this.Controls.SetChildIndex(this.TextBoxNewArtist, 0);
			this.Controls.SetChildIndex(this.LabelNewAlbum, 0);
			this.Controls.SetChildIndex(this.TextBoxNewAlbum, 0);
			this.Controls.SetChildIndex(this.LabelNewTitle, 0);
			this.Controls.SetChildIndex(this.TextBoxNewTitle, 0);
			this.Controls.SetChildIndex(this.ButtonAddChange, 0);
			this.Controls.SetChildIndex(this.ButtonDeleteSelected, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelExceptionType;
		private System.Windows.Forms.ComboBox ComboBoxExceptionTypes;
		private System.Windows.Forms.ListBox ListBoxExceptions;
		private System.Windows.Forms.Button ButtonRedo;
		private System.Windows.Forms.Button ButtonUndo;
		private System.Windows.Forms.Label LabelOriginalArtist;
		private System.Windows.Forms.TextBox TextBoxOriginalArtist;
		private System.Windows.Forms.TextBox TextBoxOriginalAlbum;
		private System.Windows.Forms.Label LabelOriginalAlbum;
		private System.Windows.Forms.TextBox TextBoxOriginalTitle;
		private System.Windows.Forms.Label LabelOriginalTitle;
		private System.Windows.Forms.TextBox TextBoxNewArtist;
		private System.Windows.Forms.Label LabelNewArtist;
		private System.Windows.Forms.TextBox TextBoxNewAlbum;
		private System.Windows.Forms.Label LabelNewAlbum;
		private System.Windows.Forms.TextBox TextBoxNewTitle;
		private System.Windows.Forms.Label LabelNewTitle;
		private System.Windows.Forms.Button ButtonAddChange;
		private System.Windows.Forms.Button ButtonDeleteSelected;
	}
}
