﻿
namespace Forms
{
    partial class BaseControl
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
            this.ButtonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonBack
            // 
            this.ButtonBack.AutoSize = true;
            this.ButtonBack.BackColor = System.Drawing.Color.Transparent;
            this.ButtonBack.FlatAppearance.BorderSize = 0;
            this.ButtonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonBack.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonBack.Location = new System.Drawing.Point(0, 16);
            this.ButtonBack.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(59, 39);
            this.ButtonBack.TabIndex = 5;
            this.ButtonBack.Text = "Back";
            this.ButtonBack.UseVisualStyleBackColor = false;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // BaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ButtonBack);
            this.Font = new System.Drawing.Font("Myanmar Text", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(179)))), ((int)(((byte)(174)))));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "BaseControl";
            this.Size = new System.Drawing.Size(739, 754);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button ButtonBack;
    }
}
