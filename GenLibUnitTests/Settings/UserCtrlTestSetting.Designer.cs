using GenLibUnitTests.Config;

namespace GenLibUnitTests.Settings
{
    partial class UserCtrlTestSetting
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
            this.components = new System.ComponentModel.Container();
            this.LblInt = new System.Windows.Forms.Label();
            this.LblBool = new System.Windows.Forms.Label();
            this.LblString = new System.Windows.Forms.Label();
            this.TxBxInt = new System.Windows.Forms.TextBox();
            this.TxBxBool = new System.Windows.Forms.TextBox();
            this.TxBxString = new System.Windows.Forms.TextBox();
            this.testSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testSettingBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.testSettingBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.testSettingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSettingBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSettingBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInt
            // 
            this.LblInt.AutoSize = true;
            this.LblInt.Location = new System.Drawing.Point(28, 18);
            this.LblInt.Name = "LblInt";
            this.LblInt.Size = new System.Drawing.Size(19, 13);
            this.LblInt.TabIndex = 0;
            this.LblInt.Text = "Int";
            // 
            // LblBool
            // 
            this.LblBool.AutoSize = true;
            this.LblBool.Location = new System.Drawing.Point(21, 44);
            this.LblBool.Name = "LblBool";
            this.LblBool.Size = new System.Drawing.Size(28, 13);
            this.LblBool.TabIndex = 1;
            this.LblBool.Text = "Bool";
            // 
            // LblString
            // 
            this.LblString.AutoSize = true;
            this.LblString.Location = new System.Drawing.Point(15, 70);
            this.LblString.Name = "LblString";
            this.LblString.Size = new System.Drawing.Size(34, 13);
            this.LblString.TabIndex = 2;
            this.LblString.Text = "String";
            // 
            // TxBxInt
            // 
            this.TxBxInt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testSettingBindingSource, "IntValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TxBxInt.Location = new System.Drawing.Point(55, 15);
            this.TxBxInt.Name = "TxBxInt";
            this.TxBxInt.Size = new System.Drawing.Size(100, 20);
            this.TxBxInt.TabIndex = 3;
            // 
            // TxBxBool
            // 
            this.TxBxBool.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testSettingBindingSource1, "BoolValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TxBxBool.Location = new System.Drawing.Point(55, 41);
            this.TxBxBool.Name = "TxBxBool";
            this.TxBxBool.Size = new System.Drawing.Size(100, 20);
            this.TxBxBool.TabIndex = 4;
            // 
            // TxBxString
            // 
            this.TxBxString.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testSettingBindingSource2, "StringValue", true));
            this.TxBxString.Location = new System.Drawing.Point(55, 67);
            this.TxBxString.Name = "TxBxString";
            this.TxBxString.Size = new System.Drawing.Size(100, 20);
            this.TxBxString.TabIndex = 5;
            // 
            // testSettingBindingSource
            // 
            this.testSettingBindingSource.DataSource = typeof(TestSetting);
            // 
            // testSettingBindingSource1
            // 
            this.testSettingBindingSource1.DataSource = typeof(TestSetting);
            // 
            // testSettingBindingSource2
            // 
            this.testSettingBindingSource2.DataSource = typeof(TestSetting);
            // 
            // UserCtrlTestSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxBxString);
            this.Controls.Add(this.TxBxBool);
            this.Controls.Add(this.TxBxInt);
            this.Controls.Add(this.LblString);
            this.Controls.Add(this.LblBool);
            this.Controls.Add(this.LblInt);
            this.Name = "UserCtrlTestSetting";
            this.Size = new System.Drawing.Size(177, 104);
            ((System.ComponentModel.ISupportInitialize)(this.testSettingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSettingBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSettingBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblInt;
        private System.Windows.Forms.Label LblBool;
        private System.Windows.Forms.Label LblString;
        private System.Windows.Forms.TextBox TxBxInt;
        private System.Windows.Forms.TextBox TxBxBool;
        private System.Windows.Forms.TextBox TxBxString;
        private System.Windows.Forms.BindingSource testSettingBindingSource;
        private System.Windows.Forms.BindingSource testSettingBindingSource1;
        private System.Windows.Forms.BindingSource testSettingBindingSource2;
    }
}
