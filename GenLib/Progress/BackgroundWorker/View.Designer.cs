namespace GenLib.Progress.BackgroundWorker
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
            this.DisplayText = new System.Windows.Forms.TextBox();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnAction = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.LblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayText
            // 
            this.DisplayText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "DisplayText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisplayText.Location = new System.Drawing.Point(0, 40);
            this.DisplayText.Multiline = true;
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.ReadOnly = true;
            this.DisplayText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DisplayText.Size = new System.Drawing.Size(440, 93);
            this.DisplayText.TabIndex = 0;
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(ViewModel);
            // 
            // BtnAction
            // 
            this.BtnAction.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnAction.Location = new System.Drawing.Point(186, 161);
            this.BtnAction.Name = "BtnAction";
            this.BtnAction.Size = new System.Drawing.Size(75, 23);
            this.BtnAction.TabIndex = 1;
            this.BtnAction.Text = "Cancel";
            this.BtnAction.UseVisualStyleBackColor = true;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.viewModelBindingSource, "ProgressBarValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProgressBar.Location = new System.Drawing.Point(12, 139);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(416, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 2;
            // 
            // LblDescription
            // 
            this.LblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDescription.Location = new System.Drawing.Point(0, -1);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(440, 38);
            this.LblDescription.TabIndex = 3;
            this.LblDescription.Text = "Description";
            this.LblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // View
            // 
            this.ClientSize = new System.Drawing.Size(440, 194);
            this.ControlBox = false;
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.BtnAction);
            this.Controls.Add(this.DisplayText);
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DisplayText;
        private System.Windows.Forms.Button BtnAction;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private System.Windows.Forms.Label LblDescription;
    }
}