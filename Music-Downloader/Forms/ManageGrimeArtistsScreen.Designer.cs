
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
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelMain.SuspendLayout();
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
			this.ButtonDeleteSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ButtonDeleteSelected.AutoSize = true;
			this.ButtonDeleteSelected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelMain.SetColumnSpan(this.ButtonDeleteSelected, 2);
			this.ButtonDeleteSelected.Enabled = false;
			this.ButtonDeleteSelected.FlatAppearance.BorderSize = 0;
			this.ButtonDeleteSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonDeleteSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonDeleteSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonDeleteSelected.Location = new System.Drawing.Point(312, 123);
			this.ButtonDeleteSelected.Name = "ButtonDeleteSelected";
			this.ButtonDeleteSelected.Size = new System.Drawing.Size(136, 24);
			this.ButtonDeleteSelected.TabIndex = 38;
			this.ButtonDeleteSelected.Text = "Delete Selected";
			this.ButtonDeleteSelected.UseVisualStyleBackColor = true;
			this.ButtonDeleteSelected.Visible = false;
			this.ButtonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteSelected_Click);
			// 
			// ButtonAddNewGrimeArtist
			// 
			this.ButtonAddNewGrimeArtist.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ButtonAddNewGrimeArtist.AutoSize = true;
			this.ButtonAddNewGrimeArtist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelMain.SetColumnSpan(this.ButtonAddNewGrimeArtist, 2);
			this.ButtonAddNewGrimeArtist.FlatAppearance.BorderSize = 0;
			this.ButtonAddNewGrimeArtist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonAddNewGrimeArtist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonAddNewGrimeArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonAddNewGrimeArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonAddNewGrimeArtist.Location = new System.Drawing.Point(287, 93);
			this.ButtonAddNewGrimeArtist.Name = "ButtonAddNewGrimeArtist";
			this.ButtonAddNewGrimeArtist.Size = new System.Drawing.Size(185, 24);
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
			this.ButtonRedo.Location = new System.Drawing.Point(383, 62);
			this.ButtonRedo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonRedo.Name = "ButtonRedo";
			this.ButtonRedo.Size = new System.Drawing.Size(37, 26);
			this.ButtonRedo.TabIndex = 36;
			this.ButtonRedo.UseVisualStyleBackColor = true;
			this.ButtonRedo.Click += new System.EventHandler(this.ButtonRedo_Click);
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
			this.ButtonUndo.Location = new System.Drawing.Point(340, 62);
			this.ButtonUndo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonUndo.Name = "ButtonUndo";
			this.ButtonUndo.Size = new System.Drawing.Size(37, 26);
			this.ButtonUndo.TabIndex = 35;
			this.ButtonUndo.UseVisualStyleBackColor = true;
			this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
			// 
			// TextBoxGrimeArtist
			// 
			this.TextBoxGrimeArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxGrimeArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxGrimeArtist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanelMain.SetColumnSpan(this.TextBoxGrimeArtist, 2);
			this.TextBoxGrimeArtist.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxGrimeArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxGrimeArtist.Location = new System.Drawing.Point(155, 33);
			this.TextBoxGrimeArtist.Name = "TextBoxGrimeArtist";
			this.TextBoxGrimeArtist.Size = new System.Drawing.Size(450, 24);
			this.TextBoxGrimeArtist.TabIndex = 34;
			// 
			// LabelNewGrimeArtist
			// 
			this.LabelNewGrimeArtist.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.LabelNewGrimeArtist.AutoSize = true;
			this.LabelNewGrimeArtist.Location = new System.Drawing.Point(4, 36);
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
			this.ListBoxGrimeArtists.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListBoxGrimeArtists.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ListBoxGrimeArtists.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.ListBoxGrimeArtists.FormattingEnabled = true;
			this.ListBoxGrimeArtists.ItemHeight = 16;
			this.ListBoxGrimeArtists.Location = new System.Drawing.Point(611, 32);
			this.ListBoxGrimeArtists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBoxGrimeArtists.Name = "ListBoxGrimeArtists";
			this.tableLayoutPanelMain.SetRowSpan(this.ListBoxGrimeArtists, 5);
			this.ListBoxGrimeArtists.Size = new System.Drawing.Size(402, 233);
			this.ListBoxGrimeArtists.TabIndex = 32;
			this.ListBoxGrimeArtists.SelectedIndexChanged += new System.EventHandler(this.ListBoxGrimeArtists_SelectedIndexChanged);
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.ColumnCount = 4;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanelMain.Controls.Add(this.LabelNewGrimeArtist, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.ListBoxGrimeArtists, 3, 1);
			this.tableLayoutPanelMain.Controls.Add(this.ButtonDeleteSelected, 1, 4);
			this.tableLayoutPanelMain.Controls.Add(this.TextBoxGrimeArtist, 1, 1);
			this.tableLayoutPanelMain.Controls.Add(this.ButtonAddNewGrimeArtist, 1, 3);
			this.tableLayoutPanelMain.Controls.Add(this.ButtonUndo, 1, 2);
			this.tableLayoutPanelMain.Controls.Add(this.ButtonRedo, 2, 2);
			this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelMain.MinimumSize = new System.Drawing.Size(1009, 256);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 6;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(1016, 267);
			this.tableLayoutPanelMain.TabIndex = 39;
			// 
			// ManageGrimeArtistsScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanelMain);
			this.Name = "ManageGrimeArtistsScreen";
			this.Size = new System.Drawing.Size(1016, 267);
			this.Enter += new System.EventHandler(this.ManageGrimeArtistsScreen_Enter);
			this.Controls.SetChildIndex(this.tableLayoutPanelMain, 0);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
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
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
	}
}
