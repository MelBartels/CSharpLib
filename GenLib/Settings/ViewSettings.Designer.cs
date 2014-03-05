namespace GenLib.Settings
{
    partial class ViewSettings
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
            this.userCtrlSettings1 = new UserCtrlSettings();
            this.SuspendLayout();
            // 
            // userCtrlSettings1
            // 
            this.userCtrlSettings1.Location = new System.Drawing.Point(13, 13);
            this.userCtrlSettings1.Name = "userCtrlSettings1";
            this.userCtrlSettings1.Size = new System.Drawing.Size(567, 240);
            this.userCtrlSettings1.TabIndex = 0;
            // 
            // ViewSettings
            // 
            this.ClientSize = new System.Drawing.Size(592, 264);
            this.Controls.Add(this.userCtrlSettings1);
            this.Name = "ViewSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private UserCtrlSettings userCtrlSettings1;



    }
}