
namespace Forms
{
    partial class Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
			this.homeScreen1 = new Forms.HomeScreen();
			this.SuspendLayout();
			// 
			// homeScreen1
			// 
			this.homeScreen1.AutoSize = true;
			this.homeScreen1.BackColor = System.Drawing.Color.Transparent;
			this.homeScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.homeScreen1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.homeScreen1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
			this.homeScreen1.Location = new System.Drawing.Point(0, 0);
			this.homeScreen1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.homeScreen1.Name = "homeScreen1";
			this.homeScreen1.Size = new System.Drawing.Size(1131, 450);
			this.homeScreen1.TabIndex = 0;
			// 
			// Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(41)))));
			this.ClientSize = new System.Drawing.Size(1131, 450);
			this.Controls.Add(this.homeScreen1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Window";
			this.Text = "MusicDownloader";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private HomeScreen homeScreen1;
	}
}

