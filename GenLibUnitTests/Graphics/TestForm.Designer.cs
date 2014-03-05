using GenLib.Graphics;

namespace GenLibUnitTests.Graphics
{
    partial class TestForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserCtrl = new UserCtrl();
            this.SuspendLayout();
            // 
            // UserCtrl
            // 
            this.UserCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserCtrl.Location = new System.Drawing.Point(0, 0);
            this.UserCtrl.Name = "UserCtrl";
            this.UserCtrl.Renderer = null;
            this.UserCtrl.Size = new System.Drawing.Size(284, 262);
            this.UserCtrl.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.UserCtrl);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        public UserCtrl UserCtrl;

    }
}