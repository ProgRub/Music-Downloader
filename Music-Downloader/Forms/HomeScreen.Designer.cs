
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
            this.SuspendLayout();
            // 
            // ButtonBack
            // 
            this.ButtonBack.Enabled = false;
            this.ButtonBack.FlatAppearance.BorderSize = 0;
            this.ButtonBack.Visible = false;
            // 
            // ButtonDownloadMusic
            // 
            this.ButtonDownloadMusic.AutoSize = true;
            this.ButtonDownloadMusic.FlatAppearance.BorderSize = 0;
            this.ButtonDownloadMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDownloadMusic.ForeColor = System.Drawing.Color.White;
            this.ButtonDownloadMusic.Location = new System.Drawing.Point(161, 71);
            this.ButtonDownloadMusic.Name = "ButtonDownloadMusic";
            this.ButtonDownloadMusic.Size = new System.Drawing.Size(151, 39);
            this.ButtonDownloadMusic.TabIndex = 6;
            this.ButtonDownloadMusic.Text = "Download Music";
            this.ButtonDownloadMusic.UseVisualStyleBackColor = true;
            this.ButtonDownloadMusic.Click += new System.EventHandler(this.ButtonDownloadMusic_Click);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonDownloadMusic);
            this.Name = "HomeScreen";
            this.Controls.SetChildIndex(this.ButtonBack, 0);
            this.Controls.SetChildIndex(this.ButtonDownloadMusic, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonDownloadMusic;
    }
}
