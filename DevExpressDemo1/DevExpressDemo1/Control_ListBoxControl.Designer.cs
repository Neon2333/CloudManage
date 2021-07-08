
namespace DevExpressDemo1
{
    partial class Control_ListBoxControl
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
            DevExpress.Utils.SimpleContextButton simpleContextButton1 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton2 = new DevExpress.Utils.SimpleContextButton();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.listBoxControl2 = new DevExpress.XtraEditors.ListBoxControl();
            this.listBoxControl3 = new DevExpress.XtraEditors.ListBoxControl();
            this.listBoxControl4 = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl4)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Items.AddRange(new object[] {
            "张三",
            "李四",
            "王五",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.listBoxControl1.Location = new System.Drawing.Point(38, 27);
            this.listBoxControl1.LookAndFeel.SkinName = "Glass Oceans";
            this.listBoxControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.listBoxControl1.MultiColumn = true;
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(155, 88);
            this.listBoxControl1.TabIndex = 0;
            // 
            // listBoxControl2
            // 
            this.listBoxControl2.Items.AddRange(new object[] {
            "张三",
            "李四",
            "王五",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.listBoxControl2.Location = new System.Drawing.Point(246, 27);
            this.listBoxControl2.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.listBoxControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.listBoxControl2.Name = "listBoxControl2";
            this.listBoxControl2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxControl2.Size = new System.Drawing.Size(147, 88);
            this.listBoxControl2.TabIndex = 1;
            // 
            // listBoxControl3
            // 
            this.listBoxControl3.Items.AddRange(new object[] {
            "张三",
            "李四",
            "王五",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.listBoxControl3.Location = new System.Drawing.Point(458, 27);
            this.listBoxControl3.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.listBoxControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.listBoxControl3.Name = "listBoxControl3";
            this.listBoxControl3.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxControl3.Size = new System.Drawing.Size(147, 88);
            this.listBoxControl3.TabIndex = 2;
            // 
            // listBoxControl4
            // 
            simpleContextButton1.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton1.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton1.Caption = "simpleContextButton1";
            simpleContextButton1.Id = new System.Guid("4e4fc002-f9e5-44a9-a38a-f066755dcadd");
            simpleContextButton1.Name = "simpleContextButton1";
            simpleContextButton2.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton2.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton2.Caption = "simpleContextButton2";
            simpleContextButton2.Id = new System.Guid("6a5010f7-7315-4b04-812c-d0029e3fb730");
            simpleContextButton2.Name = "simpleContextButton2";
            this.listBoxControl4.ContextButtons.Add(simpleContextButton1);
            this.listBoxControl4.ContextButtons.Add(simpleContextButton2);
            this.listBoxControl4.Location = new System.Drawing.Point(38, 167);
            this.listBoxControl4.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.listBoxControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.listBoxControl4.Name = "listBoxControl4";
            this.listBoxControl4.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxControl4.Size = new System.Drawing.Size(147, 88);
            this.listBoxControl4.TabIndex = 3;
            // 
            // Control_ListBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 759);
            this.Controls.Add(this.listBoxControl4);
            this.Controls.Add(this.listBoxControl3);
            this.Controls.Add(this.listBoxControl2);
            this.Controls.Add(this.listBoxControl1);
            this.Name = "Control_ListBoxControl";
            this.Text = "Control_ListBoxControl";
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl2;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl3;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl4;
    }
}