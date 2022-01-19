namespace DevExpressDemo1
{
    partial class Control_RadioGroup
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
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(229, 54);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(110, "这是11"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(220, "这是22"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("这是一个字符串", "这是33"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new System.DateTime(2021, 7, 14, 9, 45, 28, 205), "这是44"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "55"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "66"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "77"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "88"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "99"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "1"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "2"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "3"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "4"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "5"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "6"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "7"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "8"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ww", "9")});
            this.radioGroup1.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Column;
            this.radioGroup1.Size = new System.Drawing.Size(418, 141);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            this.radioGroup1.EditValueChanged += new System.EventHandler(this.radioGroup1_EditValueChanged);
            // 
            // Control_RadioGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 740);
            this.Controls.Add(this.radioGroup1);
            this.Name = "Control_RadioGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control_RadioGroup";
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}