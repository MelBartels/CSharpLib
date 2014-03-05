using GenLib.Extensions;

namespace GenLib.Graphics
{
    partial class UserCtrl
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
            // protect Dispose from cross-threading
            this.InvokeExt(_ => ProcessDispose(disposing));
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // UserCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserCtrl";
            this.Load += new System.EventHandler(this.UserCtrl_Load);
            this.VisibleChanged += new System.EventHandler(this.UserCtrl_VisibleChanged);
            this.MouseEnter += new System.EventHandler(this.UserCtrl_MouseEnter);
            this.Resize += new System.EventHandler(this.UserCtrl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip ToolTip;
    }
}
