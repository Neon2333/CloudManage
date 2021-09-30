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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryQueryControl));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.windowsUIButtonPanel_historyQuery = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.sideTileBarControlWithSub1 = new CloudManage.CommonControl.SideTileBarControlWithSub();
            this.SuspendLayout();
            // 
            // windowsUIButtonPanel_historyQuery
            // 
            this.windowsUIButtonPanel_historyQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.windowsUIButtonPanel_historyQuery.ButtonInterval = 20;
            windowsUIButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions1.Image")));
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            windowsUIButtonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions3.SvgImage")));
            this.windowsUIButtonPanel_historyQuery.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("New", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Edit", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Filter", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel_historyQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_historyQuery.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_historyQuery.Location = new System.Drawing.Point(0, 800);
            this.windowsUIButtonPanel_historyQuery.Name = "windowsUIButtonPanel_historyQuery";
            this.windowsUIButtonPanel_historyQuery.Size = new System.Drawing.Size(1920, 80);
            this.windowsUIButtonPanel_historyQuery.TabIndex = 4;
            this.windowsUIButtonPanel_historyQuery.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel_historyQuery.UseButtonBackgroundImages = false;
            // 
            // sideTileBarControlWithSub1
            // 
            this.sideTileBarControlWithSub1.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControlWithSub1.Name = "sideTileBarControlWithSub1";
            this.sideTileBarControlWithSub1.showOverview = true;
            this.sideTileBarControlWithSub1.Size = new System.Drawing.Size(510, 800);
            this.sideTileBarControlWithSub1.TabIndex = 5;
            // 
            // HistoryQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sideTileBarControlWithSub1);
            this.Controls.Add(this.windowsUIButtonPanel_historyQuery);
            this.Name = "HistoryQueryControl";
            this.Size = new System.Drawing.Size(1920, 880);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_historyQuery;
        private CommonControl.SideTileBarControlWithSub sideTileBarControlWithSub1;
    }
}
