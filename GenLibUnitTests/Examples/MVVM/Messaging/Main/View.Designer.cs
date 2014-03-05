namespace GenLibUnitTests.Examples.MVVM.Messaging.Main
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
            this.TxBxDisplayedText = new System.Windows.Forms.TextBox();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxBxNewText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxBxNewTitleViaReactive = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxBxUpdated = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxBxCopiedText = new System.Windows.Forms.TextBox();
            this.BtnCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TxBxDisplayedText
            // 
            this.TxBxDisplayedText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "DisplayedText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TxBxDisplayedText.Location = new System.Drawing.Point(139, 117);
            this.TxBxDisplayedText.Name = "TxBxDisplayedText";
            this.TxBxDisplayedText.ReadOnly = true;
            this.TxBxDisplayedText.Size = new System.Drawing.Size(100, 20);
            this.TxBxDisplayedText.TabIndex = 3;
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(ViewModel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Displayed text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "New displayed text";
            // 
            // TxBxNewText
            // 
            this.TxBxNewText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "NewDisplayedText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TxBxNewText.Location = new System.Drawing.Point(139, 49);
            this.TxBxNewText.Name = "TxBxNewText";
            this.TxBxNewText.Size = new System.Drawing.Size(100, 20);
            this.TxBxNewText.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "New title via reactive";
            // 
            // TxBxNewTitleViaReactive
            // 
            this.TxBxNewTitleViaReactive.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "TitleTextViaReactive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TxBxNewTitleViaReactive.Location = new System.Drawing.Point(139, 23);
            this.TxBxNewTitleViaReactive.Name = "TxBxNewTitleViaReactive";
            this.TxBxNewTitleViaReactive.Size = new System.Drawing.Size(100, 20);
            this.TxBxNewTitleViaReactive.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Update count";
            // 
            // TxBxUpdated
            // 
            this.TxBxUpdated.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "UpdatedText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TxBxUpdated.Location = new System.Drawing.Point(139, 143);
            this.TxBxUpdated.Name = "TxBxUpdated";
            this.TxBxUpdated.ReadOnly = true;
            this.TxBxUpdated.Size = new System.Drawing.Size(100, 20);
            this.TxBxUpdated.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Copied text";
            // 
            // TxBxCopiedText
            // 
            this.TxBxCopiedText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "CopiedText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TxBxCopiedText.Location = new System.Drawing.Point(139, 169);
            this.TxBxCopiedText.Name = "TxBxCopiedText";
            this.TxBxCopiedText.ReadOnly = true;
            this.TxBxCopiedText.Size = new System.Drawing.Size(100, 20);
            this.TxBxCopiedText.TabIndex = 11;
            // 
            // BtnCopy
            // 
            this.BtnCopy.Location = new System.Drawing.Point(75, 80);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(137, 23);
            this.BtnCopy.TabIndex = 12;
            this.BtnCopy.Text = "Copy new displayed text";
            this.BtnCopy.UseVisualStyleBackColor = true;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 209);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxBxCopiedText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxBxUpdated);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxBxNewTitleViaReactive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxBxNewText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxBxDisplayedText);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BasicExampleWithMessaging";
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxBxDisplayedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxBxNewText;
        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxBxNewTitleViaReactive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxBxUpdated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxBxCopiedText;
        private System.Windows.Forms.Button BtnCopy;
    }
}

