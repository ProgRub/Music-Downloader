
namespace Forms
{
	partial class ManageUrlReplacementsScreen
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
			this.ListBoxUrlReplacements = new System.Windows.Forms.ListBox();
			this.TextBoxReplacement = new System.Windows.Forms.TextBox();
			this.LabelTheReplacement = new System.Windows.Forms.Label();
			this.TextBoxWhatToReplace = new System.Windows.Forms.TextBox();
			this.LabelWhatToReplace = new System.Windows.Forms.Label();
			this.ButtonRedo = new System.Windows.Forms.Button();
			this.ButtonUndo = new System.Windows.Forms.Button();
			this.ButtonDeleteSelected = new System.Windows.Forms.Button();
			this.ButtonAddNewUrlReplacement = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ButtonBack
			// 
			this.ButtonBack.FlatAppearance.BorderSize = 0;
			this.ButtonBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			// 
			// ListBoxUrlReplacements
			// 
			this.ListBoxUrlReplacements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.ListBoxUrlReplacements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ListBoxUrlReplacements.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ListBoxUrlReplacements.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.ListBoxUrlReplacements.FormattingEnabled = true;
			this.ListBoxUrlReplacements.ItemHeight = 16;
			this.ListBoxUrlReplacements.Location = new System.Drawing.Point(648, 43);
			this.ListBoxUrlReplacements.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBoxUrlReplacements.Name = "ListBoxUrlReplacements";
			this.ListBoxUrlReplacements.Size = new System.Drawing.Size(418, 610);
			this.ListBoxUrlReplacements.TabIndex = 9;
			this.ListBoxUrlReplacements.SelectedIndexChanged += new System.EventHandler(this.ListBoxUrlReplacements_SelectedIndexChanged);
			// 
			// TextBoxReplacement
			// 
			this.TextBoxReplacement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxReplacement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxReplacement.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxReplacement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxReplacement.Location = new System.Drawing.Point(159, 73);
			this.TextBoxReplacement.Name = "TextBoxReplacement";
			this.TextBoxReplacement.PlaceholderText = "Specify the replacement between quotes";
			this.TextBoxReplacement.Size = new System.Drawing.Size(483, 24);
			this.TextBoxReplacement.TabIndex = 23;
			// 
			// LabelTheReplacement
			// 
			this.LabelTheReplacement.AutoSize = true;
			this.LabelTheReplacement.Location = new System.Drawing.Point(10, 75);
			this.LabelTheReplacement.Name = "LabelTheReplacement";
			this.LabelTheReplacement.Size = new System.Drawing.Size(143, 17);
			this.LabelTheReplacement.TabIndex = 22;
			this.LabelTheReplacement.Text = "The replacement:";
			this.LabelTheReplacement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TextBoxWhatToReplace
			// 
			this.TextBoxWhatToReplace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(91)))));
			this.TextBoxWhatToReplace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxWhatToReplace.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextBoxWhatToReplace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.TextBoxWhatToReplace.Location = new System.Drawing.Point(159, 43);
			this.TextBoxWhatToReplace.Name = "TextBoxWhatToReplace";
			this.TextBoxWhatToReplace.PlaceholderText = "Specify what should be replaced between quotes";
			this.TextBoxWhatToReplace.Size = new System.Drawing.Size(483, 24);
			this.TextBoxWhatToReplace.TabIndex = 21;
			// 
			// LabelWhatToReplace
			// 
			this.LabelWhatToReplace.AutoSize = true;
			this.LabelWhatToReplace.Location = new System.Drawing.Point(16, 45);
			this.LabelWhatToReplace.Name = "LabelWhatToReplace";
			this.LabelWhatToReplace.Size = new System.Drawing.Size(137, 17);
			this.LabelWhatToReplace.TabIndex = 20;
			this.LabelWhatToReplace.Text = "What to replace:";
			this.LabelWhatToReplace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.ButtonRedo.Location = new System.Drawing.Point(391, 102);
			this.ButtonRedo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonRedo.Name = "ButtonRedo";
			this.ButtonRedo.Size = new System.Drawing.Size(37, 29);
			this.ButtonRedo.TabIndex = 25;
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
			this.ButtonUndo.Location = new System.Drawing.Point(348, 102);
			this.ButtonUndo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ButtonUndo.Name = "ButtonUndo";
			this.ButtonUndo.Size = new System.Drawing.Size(37, 29);
			this.ButtonUndo.TabIndex = 24;
			this.ButtonUndo.UseVisualStyleBackColor = true;
			this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
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
			this.ButtonDeleteSelected.Location = new System.Drawing.Point(323, 169);
			this.ButtonDeleteSelected.Name = "ButtonDeleteSelected";
			this.ButtonDeleteSelected.Size = new System.Drawing.Size(136, 27);
			this.ButtonDeleteSelected.TabIndex = 31;
			this.ButtonDeleteSelected.Text = "Delete Selected";
			this.ButtonDeleteSelected.UseVisualStyleBackColor = true;
			this.ButtonDeleteSelected.Visible = false;
			this.ButtonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteSelected_Click);
			// 
			// ButtonAddNewUrlReplacement
			// 
			this.ButtonAddNewUrlReplacement.AutoSize = true;
			this.ButtonAddNewUrlReplacement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ButtonAddNewUrlReplacement.FlatAppearance.BorderSize = 0;
			this.ButtonAddNewUrlReplacement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ButtonAddNewUrlReplacement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.ButtonAddNewUrlReplacement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonAddNewUrlReplacement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ButtonAddNewUrlReplacement.Location = new System.Drawing.Point(280, 136);
			this.ButtonAddNewUrlReplacement.Name = "ButtonAddNewUrlReplacement";
			this.ButtonAddNewUrlReplacement.Size = new System.Drawing.Size(228, 27);
			this.ButtonAddNewUrlReplacement.TabIndex = 30;
			this.ButtonAddNewUrlReplacement.Text = "Add New URL Replacement";
			this.ButtonAddNewUrlReplacement.UseVisualStyleBackColor = true;
			this.ButtonAddNewUrlReplacement.Click += new System.EventHandler(this.ButtonAddChange_Click);
			// 
			// ManageUrlReplacementsScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ButtonDeleteSelected);
			this.Controls.Add(this.ButtonAddNewUrlReplacement);
			this.Controls.Add(this.ButtonRedo);
			this.Controls.Add(this.ButtonUndo);
			this.Controls.Add(this.TextBoxReplacement);
			this.Controls.Add(this.LabelTheReplacement);
			this.Controls.Add(this.TextBoxWhatToReplace);
			this.Controls.Add(this.LabelWhatToReplace);
			this.Controls.Add(this.ListBoxUrlReplacements);
			this.Name = "ManageUrlReplacementsScreen";
			this.Size = new System.Drawing.Size(1181, 655);
			this.Enter += new System.EventHandler(this.ManageUrlReplacementsScreen_Enter);
			this.Controls.SetChildIndex(this.ListBoxUrlReplacements, 0);
			this.Controls.SetChildIndex(this.LabelWhatToReplace, 0);
			this.Controls.SetChildIndex(this.TextBoxWhatToReplace, 0);
			this.Controls.SetChildIndex(this.LabelTheReplacement, 0);
			this.Controls.SetChildIndex(this.TextBoxReplacement, 0);
			this.Controls.SetChildIndex(this.ButtonUndo, 0);
			this.Controls.SetChildIndex(this.ButtonRedo, 0);
			this.Controls.SetChildIndex(this.ButtonBack, 0);
			this.Controls.SetChildIndex(this.ButtonAddNewUrlReplacement, 0);
			this.Controls.SetChildIndex(this.ButtonDeleteSelected, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox ListBoxUrlReplacements;
		private System.Windows.Forms.TextBox TextBoxReplacement;
		private System.Windows.Forms.Label LabelTheReplacement;
		private System.Windows.Forms.TextBox TextBoxWhatToReplace;
		private System.Windows.Forms.Label LabelWhatToReplace;
		private System.Windows.Forms.Button ButtonRedo;
		private System.Windows.Forms.Button ButtonUndo;
		private System.Windows.Forms.Button ButtonDeleteSelected;
		private System.Windows.Forms.Button ButtonAddNewUrlReplacement;
	}
}
