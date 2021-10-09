namespace DevExpressDemo1
{
    partial class Control_TimeEdit
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timeEdit6 = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit5 = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit4 = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit3 = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit2 = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.timeSpanEdit2 = new DevExpress.XtraEditors.TimeSpanEdit();
            this.timeSpanEdit1 = new DevExpress.XtraEditors.TimeSpanEdit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1055, 651);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.timeEdit6);
            this.tabPage1.Controls.Add(this.timeEdit5);
            this.tabPage1.Controls.Add(this.timeEdit4);
            this.tabPage1.Controls.Add(this.timeEdit3);
            this.tabPage1.Controls.Add(this.timeEdit2);
            this.tabPage1.Controls.Add(this.timeEdit1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1047, 624);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TimeEdit";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timeEdit6
            // 
            this.timeEdit6.EditValue = new System.DateTime(2021, 7, 13, 0, 0, 0, 0);
            this.timeEdit6.Location = new System.Drawing.Point(241, 287);
            this.timeEdit6.Name = "timeEdit6";
            this.timeEdit6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit6.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.TimeSpan;
            this.timeEdit6.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit6.Size = new System.Drawing.Size(100, 20);
            this.timeEdit6.TabIndex = 10;
            this.timeEdit6.ToolTipTitle = "触控面板";
            // 
            // timeEdit5
            // 
            this.timeEdit5.EditValue = new System.DateTime(2021, 7, 13, 0, 0, 0, 0);
            this.timeEdit5.Location = new System.Drawing.Point(503, 40);
            this.timeEdit5.Name = "timeEdit5";
            this.timeEdit5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit5.Properties.Mask.EditMask = "G";
            this.timeEdit5.Size = new System.Drawing.Size(150, 20);
            this.timeEdit5.TabIndex = 9;
            this.timeEdit5.Tag = "设置Mask";
            // 
            // timeEdit4
            // 
            this.timeEdit4.EditValue = new System.DateTime(2021, 7, 13, 0, 0, 0, 0);
            this.timeEdit4.Location = new System.Drawing.Point(344, 40);
            this.timeEdit4.Name = "timeEdit4";
            this.timeEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit4.Size = new System.Drawing.Size(96, 20);
            this.timeEdit4.TabIndex = 8;
            this.timeEdit4.ToolTipTitle = "代码设定时间，未设置显示格式";
            // 
            // timeEdit3
            // 
            this.timeEdit3.EditValue = new System.DateTime(2021, 7, 13, 0, 0, 0, 0);
            this.timeEdit3.Location = new System.Drawing.Point(180, 40);
            this.timeEdit3.Name = "timeEdit3";
            this.timeEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit3.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit3.Size = new System.Drawing.Size(100, 20);
            this.timeEdit3.TabIndex = 7;
            this.timeEdit3.ToolTipTitle = "触控面板";
            // 
            // timeEdit2
            // 
            this.timeEdit2.EditValue = new System.DateTime(2021, 7, 13, 0, 0, 0, 0);
            this.timeEdit2.Location = new System.Drawing.Point(26, 287);
            this.timeEdit2.Name = "timeEdit2";
            this.timeEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit2.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal;
            this.timeEdit2.Size = new System.Drawing.Size(100, 20);
            this.timeEdit2.TabIndex = 6;
            // 
            // timeEdit1
            // 
            this.timeEdit1.EditValue = new System.DateTime(2021, 7, 13, 0, 0, 0, 0);
            this.timeEdit1.Location = new System.Drawing.Point(26, 40);
            this.timeEdit1.Name = "timeEdit1";
            this.timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit1.Size = new System.Drawing.Size(100, 20);
            this.timeEdit1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.simpleButton1);
            this.tabPage2.Controls.Add(this.labelControl1);
            this.tabPage2.Controls.Add(this.timeSpanEdit2);
            this.tabPage2.Controls.Add(this.timeSpanEdit1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1033, 611);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TimeSpanEdit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(295, 81);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(106, 23);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "refresh";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(608, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "labelControl1";
            // 
            // timeSpanEdit2
            // 
            this.timeSpanEdit2.EditValue = System.TimeSpan.Parse("00:00:00");
            this.timeSpanEdit2.Location = new System.Drawing.Point(295, 35);
            this.timeSpanEdit2.Name = "timeSpanEdit2";
            this.timeSpanEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeSpanEdit2.Properties.DisplayFormat.FormatString = "\"{0:dd} days, {0:hh} hours, {0:mm} minutes and {0:ss} seconds\"";
            this.timeSpanEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeSpanEdit2.Properties.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.timeSpanEdit2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.timeSpanEdit2.Properties.Mask.EditMask = "\"dd:HH:mm:ss\"";
            this.timeSpanEdit2.Properties.ReadOnly = true;
            this.timeSpanEdit2.Size = new System.Drawing.Size(383, 20);
            this.timeSpanEdit2.TabIndex = 11;
            this.timeSpanEdit2.ToolTipTitle = "这是一个timespanedit控件";
            // 
            // timeSpanEdit1
            // 
            this.timeSpanEdit1.EditValue = System.TimeSpan.Parse("00:00:00");
            this.timeSpanEdit1.Location = new System.Drawing.Point(25, 35);
            this.timeSpanEdit1.Name = "timeSpanEdit1";
            this.timeSpanEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeSpanEdit1.Properties.Mask.EditMask = "G";
            this.timeSpanEdit1.Size = new System.Drawing.Size(157, 20);
            this.timeSpanEdit1.TabIndex = 10;
            this.timeSpanEdit1.ToolTipTitle = "这是一个timespanedit控件";
            // 
            // Control_TimeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 651);
            this.Controls.Add(this.tabControl1);
            this.Name = "Control_TimeEdit";
            this.Text = "Control_TimeEdit";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraEditors.TimeEdit timeEdit4;
        private DevExpress.XtraEditors.TimeEdit timeEdit3;
        private DevExpress.XtraEditors.TimeEdit timeEdit2;
        private DevExpress.XtraEditors.TimeEdit timeEdit1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraEditors.TimeSpanEdit timeSpanEdit1;
        private DevExpress.XtraEditors.TimeEdit timeEdit5;
        private DevExpress.XtraEditors.TimeSpanEdit timeSpanEdit2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TimeEdit timeEdit6;
    }
}