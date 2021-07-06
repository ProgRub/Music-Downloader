
namespace Forms
{
	partial class ManageGrimeArtistsScreen
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
			this.ButtonDeleteSelected = new System.Windows.Forms.Button();
			this.ButtonAddNewGrimeArtist = new System.Windows.Forms.Button();
			this.ButtonRedo = new System.Windows.Forms.Button();
			this.ButtonUndo = new System.Windows.Forms.Button();
			this.TextBoxGrimeArtist = new System.Windows.Forms.TextBox();
			this.LabelNewGrimeArtist = new System.Windows.Forms.Label();
			this.ListBoxGrimeArtists = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// ButtonBack
			// 
			this.ButtonBack.FlatAppearance.BorderSize = 0;
			this.ButtonBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
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
			this.ButtonDeleteSelected.Location = new System.Drawing.Point(328, 127);
			this.ButtonDeleteSelected.Name = "ButtonDeleteSelected";
			this.ButtonDeleteSelected.Size = new System.Drawing.Size(136, 27);
			this.ButtonDeleteSelected.TabIndex = 38;
			this.ButtonDeleteSelected.Text = "Delete Selected";
			this.ButtonDeleteSelected.UseVisualStyleBackColor = true;
			this.ButtonDeleteSelected.Visible = false;
			this.ButtonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteSelected_Click);
			// 
			// ButtonAddNewGrimeArtist
			// 
			this.ButtonAddNewGrimeArtist.AutoSize = true;
			this.ButtonAddNewGrimeArtist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonAddNewGrimeArtist.FlatAppearance.BorderSize = 0;
			this.ButtonAddNewGrimeArtist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonAddNewGrimeArtist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonAddNewGrimeArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonAddNewGrimeArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonAddNewGrimeArtist.Location = new System.Drawing.Point(301, 94);
			this.ButtonAddNewGrimeArtist.Name = "ButtonAddNewGrimeArtist";
			this.ButtonAddNewGrimeArtist.Size = new System.Drawing.Size(185, 27);
			this.ButtonAddNewGrimeArtist.TabIndex = 37;
			this.ButtonAddNewGrimeArtist.Text = "Add New Grime Artist";
			this.ButtonAddNewGrimeArtist.UseVisualStyleBackColor = true;
			this.ButtonAddNewGrimeArtist.Click += new System.EventHandler(this.ButtonAddNewGrimeArtist_Click);
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
			this.ButtonRedo.Location = new System.Drawing.Point(396, 60);
			this.ButtonRedo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonRedo.Name = "ButtonRedo";
			this.ButtonRedo.Size = new System.Drawing.Size(37, 29);
			this.ButtonRedo.TabIndex = 36;
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
			this.ButtonUndo.Location = new System.Drawing.Point(353, 60);
			this.ButtonUndo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonUndo.Name = "ButtonUndo";
			this.ButtonUndo.Size = new System.Drawing.Size(37, 29);
			this.ButtonUndo.TabIndex = 35;
			this.ButtonUndo.UseVisualStyleBackColor = true;
			this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
			// 
			// TextBoxGrimeArtist
			// 
			this.TextBoxGrimeArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxGrimeArtist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxGrimeArtist.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxGrimeArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxGrimeArtist.Location = new System.Drawing.Point(165, 31);
			this.TextBoxGrimeArtist.Name = "TextBoxGrimeArtist";
			this.TextBoxGrimeArtist.Size = new System.Drawing.Size(483, 24);
			this.TextBoxGrimeArtist.TabIndex = 34;
			// 
			// LabelNewGrimeArtist
			// 
			this.LabelNewGrimeArtist.AutoSize = true;
			this.LabelNewGrimeArtist.Location = new System.Drawing.Point(14, 33);
			this.LabelNewGrimeArtist.Name = "LabelNewGrimeArtist";
			this.LabelNewGrimeArtist.Size = new System.Drawing.Size(145, 17);
			this.LabelNewGrimeArtist.TabIndex = 33;
			this.LabelNewGrimeArtist.Text = "New Grime Artist:";
			this.LabelNewGrimeArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ListBoxGrimeArtists
			// 
			this.ListBoxGrimeArtists.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.ListBoxGrimeArtists.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ListBoxGrimeArtists.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ListBoxGrimeArtists.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.ListBoxGrimeArtists.FormattingEnabled = true;
			this.ListBoxGrimeArtists.ItemHeight = 16;
			this.ListBoxGrimeArtists.Location = new System.Drawing.Point(654, 31);
			this.ListBoxGrimeArtists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBoxGrimeArtists.Name = "ListBoxGrimeArtists";
			this.ListBoxGrimeArtists.Size = new System.Drawing.Size(418, 610);
			this.ListBoxGrimeArtists.TabIndex = 32;
			this.ListBoxGrimeArtists.SelectedIndexChanged += new System.EventHandler(this.ListBoxGrimeArtists_SelectedIndexChanged);
			// 
			// ManageGrimeArtistsScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ButtonDeleteSelected);
			this.Controls.Add(this.ButtonAddNewGrimeArtist);
			this.Controls.Add(this.ButtonRedo);
			this.Controls.Add(this.ButtonUndo);
			this.Controls.Add(this.TextBoxGrimeArtist);
			this.Controls.Add(this.LabelNewGrimeArtist);
			this.Controls.Add(this.ListBoxGrimeArtists);
			this.Name = "ManageGrimeArtistsScreen";
			this.Size = new System.Drawing.Size(1075, 643);
			this.Enter += new System.EventHandler(this.ManageGrimeArtistsScreen_Enter);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.Controls.SetChildIndex(this.ListBoxGrimeArtists, 0);
			this.Controls.SetChildIndex(this.LabelNewGrimeArtist, 0);
			this.Controls.SetChildIndex(this.TextBoxGrimeArtist, 0);
			this.Controls.SetChildIndex(this.ButtonUndo, 0);
			this.Controls.SetChildIndex(this.ButtonRedo, 0);
			this.Controls.SetChildIndex(this.ButtonAddNewGrimeArtist, 0);
			this.Controls.SetChildIndex(this.ButtonDeleteSelected, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ButtonDeleteSelected;
		private System.Windows.Forms.Button ButtonAddNewGrimeArtist;
		private System.Windows.Forms.Button ButtonRedo;
		private System.Windows.Forms.Button ButtonUndo;
		private System.Windows.Forms.TextBox TextBoxGrimeArtist;
		private System.Windows.Forms.Label LabelNewGrimeArtist;
		private System.Windows.Forms.ListBox ListBoxGrimeArtists;
	}
}
