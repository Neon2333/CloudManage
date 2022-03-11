
namespace CloudManage.TwinDetection
{
    partial class IntelligentReasoning
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
            this.sideTileBarControlWithSub_intelligentReasoning = new CloudManage.CommonControl.SideTileBarControlWithSub();
            this.windowsUIButtonPanel_intelligentReasoning = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // sideTileBarControlWithSub_intelligentReasoning
            // 
            this.sideTileBarControlWithSub_intelligentReasoning.colNumDT = "";
            this.sideTileBarControlWithSub_intelligentReasoning.colTagDT = "";
            this.sideTileBarControlWithSub_intelligentReasoning.colTagDTSUB = "";
            this.sideTileBarControlWithSub_intelligentReasoning.colTextDT = "";
            this.sideTileBarControlWithSub_intelligentReasoning.colTextDTSUB = "";
            this.sideTileBarControlWithSub_intelligentReasoning.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControlWithSub_intelligentReasoning.Name = "sideTileBarControlWithSub_intelligentReasoning";
            this.sideTileBarControlWithSub_intelligentReasoning.showAllDevices = true;
            this.sideTileBarControlWithSub_intelligentReasoning.showOverview = true;
            this.sideTileBarControlWithSub_intelligentReasoning.Size = new System.Drawing.Size(510, 800);
            this.sideTileBarControlWithSub_intelligentReasoning.TabIndex = 0;
            this.sideTileBarControlWithSub_intelligentReasoning.useDtInitSideTileBarWithSub = true;
            this.sideTileBarControlWithSub_intelligentReasoning.sideTileBarItemWithSubClickedItem += new CloudManage.CommonControl.SideTileBarControlWithSub.TileItemWithSubClickedItemHanlder(this.sideTileBarControlWithSub_intelligentReasoning_sideTileBarItemWithSubClickedItem);
            this.sideTileBarControlWithSub_intelligentReasoning.sideTileBarItemWithSubClickedSubItem += new CloudManage.CommonControl.SideTileBarControlWithSub.TileItemWithSubClickedSubItemHanlder(this.sideTileBarControlWithSub_intelligentReasoning_sideTileBarItemWithSubClickedSubItem);
            // 
            // windowsUIButtonPanel_intelligentReasoning
            // 
            this.windowsUIButtonPanel_intelligentReasoning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.windowsUIButtonPanel_intelligentReasoning.ButtonInterval = 20;
            this.windowsUIButtonPanel_intelligentReasoning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_intelligentReasoning.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_intelligentReasoning.Location = new System.Drawing.Point(0, 800);
            this.windowsUIButtonPanel_intelligentReasoning.Name = "windowsUIButtonPanel_intelligentReasoning";
            this.windowsUIButtonPanel_intelligentReasoning.Size = new System.Drawing.Size(1920, 80);
            this.windowsUIButtonPanel_intelligentReasoning.TabIndex = 7;
            this.windowsUIButtonPanel_intelligentReasoning.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel_intelligentReasoning.UseButtonBackgroundImages = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(542, 210);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "智能推理";
            // 
            // IntelligentReasoning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.windowsUIButtonPanel_intelligentReasoning);
            this.Controls.Add(this.sideTileBarControlWithSub_intelligentReasoning);
            this.Name = "IntelligentReasoning";
            this.Size = new System.Drawing.Size(1920, 880);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonControl.SideTileBarControlWithSub sideTileBarControlWithSub_intelligentReasoning;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_intelligentReasoning;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
