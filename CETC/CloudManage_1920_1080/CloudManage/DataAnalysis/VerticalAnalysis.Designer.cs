
namespace CloudManage.DataAnalysis
{
    partial class VerticalAnalysis
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
            this.sideTileBarControlWithSub_verticalAnalysis = new CloudManage.CommonControl.SideTileBarControlWithSub();
            this.panelControl_rightSide = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_endTimeModify = new DevExpress.XtraEditors.SimpleButton();
            this.timeEdit_endTime = new DevExpress.XtraEditors.TimeEdit();
            this.simpleButton_startTimeModify = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_query = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_endTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_startTime = new DevExpress.XtraEditors.LabelControl();
            this.timeEdit_startTime = new DevExpress.XtraEditors.TimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_rightSide)).BeginInit();
            this.panelControl_rightSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_endTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_startTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sideTileBarControlWithSub_verticalAnalysis
            // 
            this.sideTileBarControlWithSub_verticalAnalysis.colNumDT = "";
            this.sideTileBarControlWithSub_verticalAnalysis.colTagDT = "";
            this.sideTileBarControlWithSub_verticalAnalysis.colTagDTSUB = "";
            this.sideTileBarControlWithSub_verticalAnalysis.colTextDT = "";
            this.sideTileBarControlWithSub_verticalAnalysis.colTextDTSUB = "";
            this.sideTileBarControlWithSub_verticalAnalysis.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControlWithSub_verticalAnalysis.Name = "sideTileBarControlWithSub_verticalAnalysis";
            this.sideTileBarControlWithSub_verticalAnalysis.showAllDevices = false;
            this.sideTileBarControlWithSub_verticalAnalysis.showOverview = false;
            this.sideTileBarControlWithSub_verticalAnalysis.Size = new System.Drawing.Size(510, 800);
            this.sideTileBarControlWithSub_verticalAnalysis.TabIndex = 0;
            this.sideTileBarControlWithSub_verticalAnalysis.useDtInitSideTileBarWithSub = true;
            this.sideTileBarControlWithSub_verticalAnalysis.sideTileBarItemWithSubClickedSubItem += new CloudManage.CommonControl.SideTileBarControlWithSub.TileItemWithSubClickedSubItemHanlder(this.sideTileBarControlWithSub_verticalAnalysis_sideTileBarItemWithSubClickedSubItem);
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
            this.panelControl_rightSide.TabIndex = 8;
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
            // VerticalAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl_rightSide);
            this.Controls.Add(this.sideTileBarControlWithSub_verticalAnalysis);
            this.Name = "VerticalAnalysis";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_rightSide)).EndInit();
            this.panelControl_rightSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_endTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_startTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControl.SideTileBarControlWithSub sideTileBarControlWithSub_verticalAnalysis;
        private DevExpress.XtraEditors.PanelControl panelControl_rightSide;
        private DevExpress.XtraEditors.SimpleButton simpleButton_endTimeModify;
        private DevExpress.XtraEditors.TimeEdit timeEdit_endTime;
        private DevExpress.XtraEditors.SimpleButton simpleButton_startTimeModify;
        private DevExpress.XtraEditors.SimpleButton simpleButton_query;
        private DevExpress.XtraEditors.LabelControl labelControl_endTime;
        private DevExpress.XtraEditors.LabelControl labelControl_startTime;
        private DevExpress.XtraEditors.TimeEdit timeEdit_startTime;
    }
}
