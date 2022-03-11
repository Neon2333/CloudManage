
namespace CloudManage.TwinDetection
{
    partial class ParaUpdate
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
            this.sideTileBarControlWithSub_paraUpdate = new CloudManage.CommonControl.SideTileBarControlWithSub();
            this.windowsUIButtonPanel_paraUpdate = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // sideTileBarControlWithSub_paraUpdate
            // 
            this.sideTileBarControlWithSub_paraUpdate.colNumDT = "";
            this.sideTileBarControlWithSub_paraUpdate.colTagDT = "";
            this.sideTileBarControlWithSub_paraUpdate.colTagDTSUB = "";
            this.sideTileBarControlWithSub_paraUpdate.colTextDT = "";
            this.sideTileBarControlWithSub_paraUpdate.colTextDTSUB = "";
            this.sideTileBarControlWithSub_paraUpdate.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControlWithSub_paraUpdate.Name = "sideTileBarControlWithSub_paraUpdate";
            this.sideTileBarControlWithSub_paraUpdate.showAllDevices = true;
            this.sideTileBarControlWithSub_paraUpdate.showOverview = true;
            this.sideTileBarControlWithSub_paraUpdate.Size = new System.Drawing.Size(510, 800);
            this.sideTileBarControlWithSub_paraUpdate.TabIndex = 0;
            this.sideTileBarControlWithSub_paraUpdate.useDtInitSideTileBarWithSub = true;
            this.sideTileBarControlWithSub_paraUpdate.sideTileBarItemWithSubClickedItem += new CloudManage.CommonControl.SideTileBarControlWithSub.TileItemWithSubClickedItemHanlder(this.sideTileBarControlWithSub_paraUpdate_sideTileBarItemWithSubClickedItem);
            this.sideTileBarControlWithSub_paraUpdate.sideTileBarItemWithSubClickedSubItem += new CloudManage.CommonControl.SideTileBarControlWithSub.TileItemWithSubClickedSubItemHanlder(this.sideTileBarControlWithSub_paraUpdate_sideTileBarItemWithSubClickedSubItem);
            // 
            // windowsUIButtonPanel_paraUpdate
            // 
            this.windowsUIButtonPanel_paraUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.windowsUIButtonPanel_paraUpdate.ButtonInterval = 20;
            this.windowsUIButtonPanel_paraUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_paraUpdate.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_paraUpdate.Location = new System.Drawing.Point(0, 800);
            this.windowsUIButtonPanel_paraUpdate.Name = "windowsUIButtonPanel_paraUpdate";
            this.windowsUIButtonPanel_paraUpdate.Size = new System.Drawing.Size(1920, 80);
            this.windowsUIButtonPanel_paraUpdate.TabIndex = 7;
            this.windowsUIButtonPanel_paraUpdate.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel_paraUpdate.UseButtonBackgroundImages = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(473, 196);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "参数更新";
            // 
            // ParaUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.windowsUIButtonPanel_paraUpdate);
            this.Controls.Add(this.sideTileBarControlWithSub_paraUpdate);
            this.Name = "ParaUpdate";
            this.Size = new System.Drawing.Size(1920, 880);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonControl.SideTileBarControlWithSub sideTileBarControlWithSub_paraUpdate;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_paraUpdate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
