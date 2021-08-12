namespace CloudManage.StatusMonitor
{
    partial class WorkStateControl
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkStateControl));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.windowsUIButtonPanel_workState = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sideTileBarControl1 = new CloudManage.CommonControl.SideTileBarControl();
            this.SuspendLayout();
            // 
            // windowsUIButtonPanel_workState
            // 
            this.windowsUIButtonPanel_workState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.windowsUIButtonPanel_workState.ButtonInterval = 20;
            windowsUIButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions1.Image")));
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            windowsUIButtonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions3.SvgImage")));
            this.windowsUIButtonPanel_workState.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("New", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Edit", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Filter", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel_workState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_workState.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_workState.Location = new System.Drawing.Point(0, 800);
            this.windowsUIButtonPanel_workState.Name = "windowsUIButtonPanel_workState";
            this.windowsUIButtonPanel_workState.Size = new System.Drawing.Size(1920, 80);
            this.windowsUIButtonPanel_workState.TabIndex = 1;
            this.windowsUIButtonPanel_workState.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel_workState.UseButtonBackgroundImages = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(657, 193);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(192, 62);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "状态监测";
            // 
            // sideTileBarControl1
            // 
            this.sideTileBarControl1.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControl1.Name = "sideTileBarControl1";
            this.sideTileBarControl1.showOverview = true;
            this.sideTileBarControl1.Size = new System.Drawing.Size(250, 800);
            this.sideTileBarControl1.TabIndex = 3;
            // 
            // WorkStateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sideTileBarControl1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.windowsUIButtonPanel_workState);
            this.Name = "WorkStateControl";
            this.Size = new System.Drawing.Size(1920, 880);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_workState;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private CommonControl.SideTileBarControl sideTileBarControl1;
    }
}
