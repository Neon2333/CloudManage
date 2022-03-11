
namespace CloudManage.TwinDetection
{
    partial class ParaSynchronize
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
            this.sideTileBarControlWithSub_paraSyn = new CloudManage.CommonControl.SideTileBarControlWithSub();
            this.windowsUIButtonPanel_paraSyn = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // sideTileBarControlWithSub_paraSyn
            // 
            this.sideTileBarControlWithSub_paraSyn.colNumDT = "";
            this.sideTileBarControlWithSub_paraSyn.colTagDT = "";
            this.sideTileBarControlWithSub_paraSyn.colTagDTSUB = "";
            this.sideTileBarControlWithSub_paraSyn.colTextDT = "";
            this.sideTileBarControlWithSub_paraSyn.colTextDTSUB = "";
            this.sideTileBarControlWithSub_paraSyn.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControlWithSub_paraSyn.Name = "sideTileBarControlWithSub_paraSyn";
            this.sideTileBarControlWithSub_paraSyn.showAllDevices = true;
            this.sideTileBarControlWithSub_paraSyn.showOverview = true;
            this.sideTileBarControlWithSub_paraSyn.Size = new System.Drawing.Size(510, 800);
            this.sideTileBarControlWithSub_paraSyn.TabIndex = 0;
            this.sideTileBarControlWithSub_paraSyn.useDtInitSideTileBarWithSub = true;
            this.sideTileBarControlWithSub_paraSyn.sideTileBarItemWithSubClickedItem += new CloudManage.CommonControl.SideTileBarControlWithSub.TileItemWithSubClickedItemHanlder(this.sideTileBarControlWithSub_paraSyn_sideTileBarItemWithSubClickedItem);
            this.sideTileBarControlWithSub_paraSyn.sideTileBarItemWithSubClickedSubItem += new CloudManage.CommonControl.SideTileBarControlWithSub.TileItemWithSubClickedSubItemHanlder(this.sideTileBarControlWithSub_paraSyn_sideTileBarItemWithSubClickedSubItem);
            // 
            // windowsUIButtonPanel_paraSyn
            // 
            this.windowsUIButtonPanel_paraSyn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.windowsUIButtonPanel_paraSyn.ButtonInterval = 20;
            this.windowsUIButtonPanel_paraSyn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_paraSyn.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_paraSyn.Location = new System.Drawing.Point(0, 800);
            this.windowsUIButtonPanel_paraSyn.Name = "windowsUIButtonPanel_paraSyn";
            this.windowsUIButtonPanel_paraSyn.Size = new System.Drawing.Size(1920, 80);
            this.windowsUIButtonPanel_paraSyn.TabIndex = 6;
            this.windowsUIButtonPanel_paraSyn.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel_paraSyn.UseButtonBackgroundImages = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(536, 251);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "参数同步";
            // 
            // ParaSynchronize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.windowsUIButtonPanel_paraSyn);
            this.Controls.Add(this.sideTileBarControlWithSub_paraSyn);
            this.Name = "ParaSynchronize";
            this.Size = new System.Drawing.Size(1920, 880);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonControl.SideTileBarControlWithSub sideTileBarControlWithSub_paraSyn;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_paraSyn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
