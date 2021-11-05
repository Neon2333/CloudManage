
namespace CloudManage.DataAnalysis
{
    partial class LateralAnalysis
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions7 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LateralAnalysis));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions8 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions9 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.sideTileBarControl_lateralAnalysis = new CloudManage.CommonControl.SideTileBarControl();
            this.windowsUIButtonPanel_historyQuery = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.panelControl_rightSide = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_endTimeModify = new DevExpress.XtraEditors.SimpleButton();
            this.timeEdit_endTime = new DevExpress.XtraEditors.TimeEdit();
            this.simpleButton_startTimeModify = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_query = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_endTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_startTime = new DevExpress.XtraEditors.LabelControl();
            this.timeEdit_startTime = new DevExpress.XtraEditors.TimeEdit();
            this.panelControl_chromeBrowser = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_rightSide)).BeginInit();
            this.panelControl_rightSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_endTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_startTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_chromeBrowser)).BeginInit();
            this.SuspendLayout();
            // 
            // sideTileBarControl_lateralAnalysis
            // 
            this.sideTileBarControl_lateralAnalysis.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.sideTileBarControl_lateralAnalysis.Appearance.Options.UseBackColor = true;
            this.sideTileBarControl_lateralAnalysis.colNumDT = "";
            this.sideTileBarControl_lateralAnalysis.colTagDT = "";
            this.sideTileBarControl_lateralAnalysis.colTextDT = "";
            this.sideTileBarControl_lateralAnalysis.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControl_lateralAnalysis.Name = "sideTileBarControl_lateralAnalysis";
            this.sideTileBarControl_lateralAnalysis.showOverview = false;
            this.sideTileBarControl_lateralAnalysis.Size = new System.Drawing.Size(240, 800);
            this.sideTileBarControl_lateralAnalysis.TabIndex = 0;
            this.sideTileBarControl_lateralAnalysis.useDtInitSideTileBar = true;
            this.sideTileBarControl_lateralAnalysis.sideTileBarItemSelectedChanged += new CloudManage.CommonControl.SideTileBarControl.TileItemSelectedChangedHanlder(this.sideTileBarControl_lateralAnalysis_sideTileBarItemSelectedChanged);
            // 
            // windowsUIButtonPanel_historyQuery
            // 
            this.windowsUIButtonPanel_historyQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.windowsUIButtonPanel_historyQuery.ButtonInterval = 20;
            windowsUIButtonImageOptions7.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions7.Image")));
            windowsUIButtonImageOptions8.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions8.SvgImage")));
            windowsUIButtonImageOptions9.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions9.SvgImage")));
            this.windowsUIButtonPanel_historyQuery.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("New", true, windowsUIButtonImageOptions7, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Edit", true, windowsUIButtonImageOptions8, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Filter", true, windowsUIButtonImageOptions9, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel_historyQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_historyQuery.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_historyQuery.Location = new System.Drawing.Point(0, 800);
            this.windowsUIButtonPanel_historyQuery.Name = "windowsUIButtonPanel_historyQuery";
            this.windowsUIButtonPanel_historyQuery.Size = new System.Drawing.Size(1920, 80);
            this.windowsUIButtonPanel_historyQuery.TabIndex = 5;
            this.windowsUIButtonPanel_historyQuery.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel_historyQuery.UseButtonBackgroundImages = false;
            // 
            // panelControl_rightSide
            // 
            this.panelControl_rightSide.Controls.Add(this.simpleButton_endTimeModify);
            this.panelControl_rightSide.Controls.Add(this.timeEdit_endTime);
            this.panelControl_rightSide.Controls.Add(this.simpleButton_startTimeModify);
            this.panelControl_rightSide.Controls.Add(this.simpleButton_query);
            this.panelControl_rightSide.Controls.Add(this.labelControl_endTime);
            this.panelControl_rightSide.Controls.Add(this.labelControl_startTime);
            this.panelControl_rightSide.Controls.Add(this.timeEdit_startTime);
            this.panelControl_rightSide.Location = new System.Drawing.Point(1358, 0);
            this.panelControl_rightSide.Name = "panelControl_rightSide";
            this.panelControl_rightSide.Size = new System.Drawing.Size(562, 800);
            this.panelControl_rightSide.TabIndex = 7;
            // 
            // simpleButton_endTimeModify
            // 
            this.simpleButton_endTimeModify.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_endTimeModify.Appearance.Options.UseFont = true;
            this.simpleButton_endTimeModify.Location = new System.Drawing.Point(336, 180);
            this.simpleButton_endTimeModify.Name = "simpleButton_endTimeModify";
            this.simpleButton_endTimeModify.Size = new System.Drawing.Size(219, 46);
            this.simpleButton_endTimeModify.TabIndex = 21;
            this.simpleButton_endTimeModify.Text = "更改";
            // 
            // timeEdit_endTime
            // 
            this.timeEdit_endTime.EditValue = "2021/10/8 0:00:00";
            this.timeEdit_endTime.Location = new System.Drawing.Point(6, 180);
            this.timeEdit_endTime.Name = "timeEdit_endTime";
            this.timeEdit_endTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeEdit_endTime.Properties.Appearance.Options.UseFont = true;
            this.timeEdit_endTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_endTime.Properties.Mask.EditMask = "G";
            this.timeEdit_endTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.timeEdit_endTime.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_endTime.Size = new System.Drawing.Size(324, 46);
            this.timeEdit_endTime.TabIndex = 20;
            // 
            // simpleButton_startTimeModify
            // 
            this.simpleButton_startTimeModify.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_startTimeModify.Appearance.Options.UseFont = true;
            this.simpleButton_startTimeModify.Location = new System.Drawing.Point(336, 56);
            this.simpleButton_startTimeModify.Name = "simpleButton_startTimeModify";
            this.simpleButton_startTimeModify.Size = new System.Drawing.Size(219, 46);
            this.simpleButton_startTimeModify.TabIndex = 19;
            this.simpleButton_startTimeModify.Text = "更改";
            // 
            // simpleButton_query
            // 
            this.simpleButton_query.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_query.Appearance.Options.UseFont = true;
            this.simpleButton_query.Location = new System.Drawing.Point(6, 232);
            this.simpleButton_query.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.simpleButton_query.Name = "simpleButton_query";
            this.simpleButton_query.Size = new System.Drawing.Size(549, 118);
            this.simpleButton_query.TabIndex = 17;
            this.simpleButton_query.Text = "查询";
            this.simpleButton_query.Click += new System.EventHandler(this.simpleButton_query_Click);
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
            this.labelControl_endTime.Location = new System.Drawing.Point(0, 124);
            this.labelControl_endTime.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_endTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_endTime.Name = "labelControl_endTime";
            this.labelControl_endTime.Size = new System.Drawing.Size(562, 50);
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
            this.labelControl_startTime.Size = new System.Drawing.Size(562, 50);
            this.labelControl_startTime.TabIndex = 13;
            this.labelControl_startTime.Text = "起始时间";
            // 
            // timeEdit_startTime
            // 
            this.timeEdit_startTime.EditValue = "2021/10/8 0:00:00";
            this.timeEdit_startTime.Location = new System.Drawing.Point(6, 56);
            this.timeEdit_startTime.Name = "timeEdit_startTime";
            this.timeEdit_startTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeEdit_startTime.Properties.Appearance.Options.UseFont = true;
            this.timeEdit_startTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_startTime.Properties.Mask.EditMask = "G";
            this.timeEdit_startTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.timeEdit_startTime.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_startTime.Size = new System.Drawing.Size(324, 46);
            this.timeEdit_startTime.TabIndex = 13;
            // 
            // panelControl_chromeBrowser
            // 
            this.panelControl_chromeBrowser.Location = new System.Drawing.Point(240, 0);
            this.panelControl_chromeBrowser.Name = "panelControl_chromeBrowser";
            this.panelControl_chromeBrowser.Size = new System.Drawing.Size(1118, 800);
            this.panelControl_chromeBrowser.TabIndex = 8;
            // 
            // LateralAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl_chromeBrowser);
            this.Controls.Add(this.panelControl_rightSide);
            this.Controls.Add(this.windowsUIButtonPanel_historyQuery);
            this.Controls.Add(this.sideTileBarControl_lateralAnalysis);
            this.Name = "LateralAnalysis";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_rightSide)).EndInit();
            this.panelControl_rightSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_endTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_startTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_chromeBrowser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControl.SideTileBarControl sideTileBarControl_lateralAnalysis;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_historyQuery;
        private DevExpress.XtraEditors.PanelControl panelControl_rightSide;
        private DevExpress.XtraEditors.SimpleButton simpleButton_endTimeModify;
        private DevExpress.XtraEditors.TimeEdit timeEdit_endTime;
        private DevExpress.XtraEditors.SimpleButton simpleButton_startTimeModify;
        private DevExpress.XtraEditors.SimpleButton simpleButton_query;
        private DevExpress.XtraEditors.LabelControl labelControl_endTime;
        private DevExpress.XtraEditors.LabelControl labelControl_startTime;
        private DevExpress.XtraEditors.TimeEdit timeEdit_startTime;
        private DevExpress.XtraEditors.PanelControl panelControl_chromeBrowser;
    }
}
