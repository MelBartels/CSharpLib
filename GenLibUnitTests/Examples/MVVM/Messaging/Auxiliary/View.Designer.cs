namespace GenLibUnitTests.Examples.MVVM.Messaging.Auxiliary
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxBxCopiedText = new System.Windows.Forms.TextBox();
            this.TxBxMirroredText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copied text";
            // 
            // TxBxCopiedText
            // 
            this.TxBxCopiedText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "CopiedText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TxBxCopiedText.Location = new System.Drawing.Point(125, 51);
            this.TxBxCopiedText.Name = "TxBxCopiedText";
            this.TxBxCopiedText.ReadOnly = true;
            this.TxBxCopiedText.Size = new System.Drawing.Size(100, 20);
            this.TxBxCopiedText.TabIndex = 1;
            // 
            // TxBxMirroredText
            // 
            this.TxBxMirroredText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "MirroredText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TxBxMirroredText.Location = new System.Drawing.Point(125, 21);
            this.TxBxMirroredText.Name = "TxBxMirroredText";
            this.TxBxMirroredText.ReadOnly = true;
            this.TxBxMirroredText.Size = new System.Drawing.Size(100, 20);
            this.TxBxMirroredText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mirrored text";
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(ViewModel);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 92);
            this.Controls.Add(this.TxBxMirroredText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxBxCopiedText);
            this.Controls.Add(this.label1);
            this.Name = "View";
            this.Text = "Auxiliary";
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxBxCopiedText;
        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private System.Windows.Forms.TextBox TxBxMirroredText;
        private System.Windows.Forms.Label label2;
    }
}