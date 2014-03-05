namespace AstroLib.ObjectLibrary
{
    partial class View
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.ViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridControlObjects = new DevExpress.XtraGrid.GridControl();
            this.GridViewObjects = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ToolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcApertureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewObjects)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridControlObjects
            // 
            this.GridControlObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlObjects.Location = new System.Drawing.Point(13, 40);
            this.GridControlObjects.MainView = this.GridViewObjects;
            this.GridControlObjects.Name = "GridControlObjects";
            this.GridControlObjects.Size = new System.Drawing.Size(958, 510);
            this.GridControlObjects.TabIndex = 0;
            this.GridControlObjects.ToolTipController = this.ToolTipController;
            this.GridControlObjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewObjects});
            // 
            // GridViewObjects
            // 
            this.GridViewObjects.GridControl = this.GridControlObjects;
            this.GridViewObjects.Name = "GridViewObjects";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.calcApertureToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(984, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // calcApertureToolStripMenuItem
            // 
            this.calcApertureToolStripMenuItem.Name = "CalcAperture";
            this.calcApertureToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.calcApertureToolStripMenuItem.Text = "Calc aperture";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.GridControlObjects);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "View";
            this.Text = "Select Object From Saguaro Library";
            ((System.ComponentModel.ISupportInitialize)(this.ViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewObjects)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource ViewModelBindingSource;
        private DevExpress.XtraGrid.GridControl GridControlObjects;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewObjects;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private DevExpress.Utils.ToolTipController ToolTipController;
        private System.Windows.Forms.ToolStripMenuItem calcApertureToolStripMenuItem;
    }
}