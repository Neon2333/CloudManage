namespace CloudManage.StatusMonitor
{
    partial class HistoryQueryControl
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions31 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryQueryControl));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions32 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions33 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.windowsUIButtonPanel_historyQuery = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_endTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_startTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_dir = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_NO = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_productionLineID = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_testingDeviceID = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_faultID = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_faultTime = new DevExpress.XtraEditors.LabelControl();
            this.sideTileBarControlWithSub1 = new CloudManage.CommonControl.SideTileBarControlWithSub();
            this.timeEdit_startTime = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit_endTime = new DevExpress.XtraEditors.TimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_startTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_endTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // windowsUIButtonPanel_historyQuery
            // 
            this.windowsUIButtonPanel_historyQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.windowsUIButtonPanel_historyQuery.ButtonInterval = 20;
            windowsUIButtonImageOptions31.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions31.Image")));
            windowsUIButtonImageOptions32.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions32.SvgImage")));
            windowsUIButtonImageOptions33.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions33.SvgImage")));
            this.windowsUIButtonPanel_historyQuery.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("New", true, windowsUIButtonImageOptions31, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Edit", true, windowsUIButtonImageOptions32, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Filter", true, windowsUIButtonImageOptions33, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel_historyQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_historyQuery.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_historyQuery.Location = new System.Drawing.Point(0, 800);
            this.windowsUIButtonPanel_historyQuery.Name = "windowsUIButtonPanel_historyQuery";
            this.windowsUIButtonPanel_historyQuery.Size = new System.Drawing.Size(1920, 80);
            this.windowsUIButtonPanel_historyQuery.TabIndex = 4;
            this.windowsUIButtonPanel_historyQuery.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel_historyQuery.UseButtonBackgroundImages = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.timeEdit_endTime);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl_endTime);
            this.panelControl1.Controls.Add(this.labelControl_startTime);
            this.panelControl1.Controls.Add(this.timeEdit_startTime);
            this.panelControl1.Location = new System.Drawing.Point(1370, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(550, 800);
            this.panelControl1.TabIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(0, 697);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(192, 97);
            this.simpleButton1.TabIndex = 17;
            this.simpleButton1.Text = "查询";
            // 
            // labelControl_endTime
            // 
            this.labelControl_endTime.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl_endTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_endTime.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_endTime.Appearance.Options.UseBackColor = true;
            this.labelControl_endTime.Appearance.Options.UseFont = true;
            this.labelControl_endTime.Appearance.Options.UseForeColor = true;
            this.labelControl_endTime.Appearance.Options.UseTextOptions = true;
            this.labelControl_endTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_endTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_endTime.Location = new System.Drawing.Point(0, 347);
            this.labelControl_endTime.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_endTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_endTime.Name = "labelControl_endTime";
            this.labelControl_endTime.Size = new System.Drawing.Size(550, 60);
            this.labelControl_endTime.TabIndex = 14;
            this.labelControl_endTime.Text = "终止时间";
            // 
            // labelControl_startTime
            // 
            this.labelControl_startTime.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl_startTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_startTime.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_startTime.Appearance.Options.UseBackColor = true;
            this.labelControl_startTime.Appearance.Options.UseFont = true;
            this.labelControl_startTime.Appearance.Options.UseForeColor = true;
            this.labelControl_startTime.Appearance.Options.UseTextOptions = true;
            this.labelControl_startTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_startTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_startTime.Location = new System.Drawing.Point(0, 0);
            this.labelControl_startTime.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_startTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_startTime.Name = "labelControl_startTime";
            this.labelControl_startTime.Size = new System.Drawing.Size(550, 60);
            this.labelControl_startTime.TabIndex = 13;
            this.labelControl_startTime.Text = "起始时间";
            // 
            // labelControl_dir
            // 
            this.labelControl_dir.Appearance.BackColor = System.Drawing.Color.Gray;
            this.labelControl_dir.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_dir.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_dir.Appearance.Options.UseBackColor = true;
            this.labelControl_dir.Appearance.Options.UseFont = true;
            this.labelControl_dir.Appearance.Options.UseForeColor = true;
            this.labelControl_dir.Appearance.Options.UseTextOptions = true;
            this.labelControl_dir.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_dir.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_dir.Location = new System.Drawing.Point(240, 0);
            this.labelControl_dir.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_dir.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_dir.Name = "labelControl_dir";
            this.labelControl_dir.Size = new System.Drawing.Size(1130, 60);
            this.labelControl_dir.TabIndex = 7;
            this.labelControl_dir.Text = "目录信息";
            // 
            // labelControl_NO
            // 
            this.labelControl_NO.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl_NO.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_NO.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_NO.Appearance.Options.UseBackColor = true;
            this.labelControl_NO.Appearance.Options.UseFont = true;
            this.labelControl_NO.Appearance.Options.UseForeColor = true;
            this.labelControl_NO.Appearance.Options.UseTextOptions = true;
            this.labelControl_NO.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_NO.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_NO.Location = new System.Drawing.Point(240, 60);
            this.labelControl_NO.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_NO.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_NO.Name = "labelControl_NO";
            this.labelControl_NO.Size = new System.Drawing.Size(108, 60);
            this.labelControl_NO.TabIndex = 8;
            this.labelControl_NO.Text = "序号";
            // 
            // labelControl_productionLineID
            // 
            this.labelControl_productionLineID.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl_productionLineID.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_productionLineID.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_productionLineID.Appearance.Options.UseBackColor = true;
            this.labelControl_productionLineID.Appearance.Options.UseFont = true;
            this.labelControl_productionLineID.Appearance.Options.UseForeColor = true;
            this.labelControl_productionLineID.Appearance.Options.UseTextOptions = true;
            this.labelControl_productionLineID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_productionLineID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_productionLineID.Location = new System.Drawing.Point(354, 60);
            this.labelControl_productionLineID.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_productionLineID.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_productionLineID.Name = "labelControl_productionLineID";
            this.labelControl_productionLineID.Size = new System.Drawing.Size(133, 60);
            this.labelControl_productionLineID.TabIndex = 9;
            this.labelControl_productionLineID.Text = "产线ID";
            // 
            // labelControl_testingDeviceID
            // 
            this.labelControl_testingDeviceID.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl_testingDeviceID.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_testingDeviceID.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_testingDeviceID.Appearance.Options.UseBackColor = true;
            this.labelControl_testingDeviceID.Appearance.Options.UseFont = true;
            this.labelControl_testingDeviceID.Appearance.Options.UseForeColor = true;
            this.labelControl_testingDeviceID.Appearance.Options.UseTextOptions = true;
            this.labelControl_testingDeviceID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_testingDeviceID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_testingDeviceID.Location = new System.Drawing.Point(493, 60);
            this.labelControl_testingDeviceID.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_testingDeviceID.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_testingDeviceID.Name = "labelControl_testingDeviceID";
            this.labelControl_testingDeviceID.Size = new System.Drawing.Size(169, 60);
            this.labelControl_testingDeviceID.TabIndex = 10;
            this.labelControl_testingDeviceID.Text = "检测设备ID";
            // 
            // labelControl_faultID
            // 
            this.labelControl_faultID.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl_faultID.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_faultID.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_faultID.Appearance.Options.UseBackColor = true;
            this.labelControl_faultID.Appearance.Options.UseFont = true;
            this.labelControl_faultID.Appearance.Options.UseForeColor = true;
            this.labelControl_faultID.Appearance.Options.UseTextOptions = true;
            this.labelControl_faultID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_faultID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_faultID.Location = new System.Drawing.Point(693, 60);
            this.labelControl_faultID.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_faultID.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_faultID.Name = "labelControl_faultID";
            this.labelControl_faultID.Size = new System.Drawing.Size(207, 60);
            this.labelControl_faultID.TabIndex = 11;
            this.labelControl_faultID.Text = "故障ID";
            // 
            // labelControl_faultTime
            // 
            this.labelControl_faultTime.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl_faultTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_faultTime.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_faultTime.Appearance.Options.UseBackColor = true;
            this.labelControl_faultTime.Appearance.Options.UseFont = true;
            this.labelControl_faultTime.Appearance.Options.UseForeColor = true;
            this.labelControl_faultTime.Appearance.Options.UseTextOptions = true;
            this.labelControl_faultTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_faultTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_faultTime.Location = new System.Drawing.Point(906, 60);
            this.labelControl_faultTime.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_faultTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_faultTime.Name = "labelControl_faultTime";
            this.labelControl_faultTime.Size = new System.Drawing.Size(207, 60);
            this.labelControl_faultTime.TabIndex = 12;
            this.labelControl_faultTime.Text = "故障时间";
            // 
            // sideTileBarControlWithSub1
            // 
            this.sideTileBarControlWithSub1.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControlWithSub1.Name = "sideTileBarControlWithSub1";
            this.sideTileBarControlWithSub1.showOverview = true;
            this.sideTileBarControlWithSub1.Size = new System.Drawing.Size(510, 800);
            this.sideTileBarControlWithSub1.TabIndex = 13;
            this.sideTileBarControlWithSub1.sideTileBarItemWithSubClicked += new CloudManage.CommonControl.SideTileBarControlWithSub.TileItemWithSubClickedHanlder(this.sideTileBarControlWithSub1_sideTileBarItemWithSubClicked);
            // 
            // timeEdit_startTime
            // 
            this.timeEdit_startTime.EditValue = "2021/10/8 0:00:00";
            this.timeEdit_startTime.Location = new System.Drawing.Point(0, 60);
            this.timeEdit_startTime.Name = "timeEdit_startTime";
            this.timeEdit_startTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeEdit_startTime.Properties.Appearance.Options.UseFont = true;
            this.timeEdit_startTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_startTime.Properties.Mask.EditMask = "G";
            this.timeEdit_startTime.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_startTime.Size = new System.Drawing.Size(276, 38);
            this.timeEdit_startTime.TabIndex = 13;
            // 
            // timeEdit_endTime
            // 
            this.timeEdit_endTime.EditValue = "2021/10/8 0:00:00";
            this.timeEdit_endTime.Location = new System.Drawing.Point(0, 407);
            this.timeEdit_endTime.Name = "timeEdit_endTime";
            this.timeEdit_endTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeEdit_endTime.Properties.Appearance.Options.UseFont = true;
            this.timeEdit_endTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_endTime.Properties.Mask.EditMask = "G";
            this.timeEdit_endTime.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_endTime.Size = new System.Drawing.Size(276, 38);
            this.timeEdit_endTime.TabIndex = 18;
            // 
            // HistoryQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl_faultTime);
            this.Controls.Add(this.labelControl_faultID);
            this.Controls.Add(this.labelControl_testingDeviceID);
            this.Controls.Add(this.labelControl_productionLineID);
            this.Controls.Add(this.labelControl_NO);
            this.Controls.Add(this.labelControl_dir);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.windowsUIButtonPanel_historyQuery);
            this.Controls.Add(this.sideTileBarControlWithSub1);
            this.Name = "HistoryQueryControl";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_startTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_endTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_historyQuery;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl_dir;
        private DevExpress.XtraEditors.LabelControl labelControl_NO;
        private DevExpress.XtraEditors.LabelControl labelControl_productionLineID;
        private DevExpress.XtraEditors.LabelControl labelControl_testingDeviceID;
        private DevExpress.XtraEditors.LabelControl labelControl_faultID;
        private DevExpress.XtraEditors.LabelControl labelControl_faultTime;
        private DevExpress.XtraEditors.LabelControl labelControl_endTime;
        private DevExpress.XtraEditors.LabelControl labelControl_startTime;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private CommonControl.SideTileBarControlWithSub sideTileBarControlWithSub1;
        private DevExpress.XtraEditors.TimeEdit timeEdit_startTime;
        private DevExpress.XtraEditors.TimeEdit timeEdit_endTime;
    }
}
