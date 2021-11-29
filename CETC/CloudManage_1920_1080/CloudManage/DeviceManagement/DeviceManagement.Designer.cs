
namespace CloudManage.DeviceManagement
{
    partial class DeviceManagement
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
            this.navigationFrame_deviceManagement = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_deviceAdditionDeletion = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_monitorThreshold = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_diagnosisManagement = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_reserve1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_reserve2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.monitorThreshold1 = new CloudManage.DeviceManagement.MonitorThreshold();
            this.diagnosisManagement1 = new CloudManage.DeviceManagement.DiagnosisManagement();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_deviceManagement)).BeginInit();
            this.navigationFrame_deviceManagement.SuspendLayout();
            this.navigationPage_monitorThreshold.SuspendLayout();
            this.navigationPage_diagnosisManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame_deviceManagement
            // 
            this.navigationFrame_deviceManagement.Controls.Add(this.navigationPage_deviceAdditionDeletion);
            this.navigationFrame_deviceManagement.Controls.Add(this.navigationPage_monitorThreshold);
            this.navigationFrame_deviceManagement.Controls.Add(this.navigationPage_diagnosisManagement);
            this.navigationFrame_deviceManagement.Controls.Add(this.navigationPage_reserve1);
            this.navigationFrame_deviceManagement.Controls.Add(this.navigationPage_reserve2);
            this.navigationFrame_deviceManagement.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame_deviceManagement.Name = "navigationFrame_deviceManagement";
            this.navigationFrame_deviceManagement.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_deviceAdditionDeletion,
            this.navigationPage_monitorThreshold,
            this.navigationPage_diagnosisManagement,
            this.navigationPage_reserve1,
            this.navigationPage_reserve2});
            this.navigationFrame_deviceManagement.SelectedPage = this.navigationPage_deviceAdditionDeletion;
            this.navigationFrame_deviceManagement.Size = new System.Drawing.Size(1920, 880);
            this.navigationFrame_deviceManagement.TabIndex = 0;
            this.navigationFrame_deviceManagement.Text = "navigationFrame1";
            this.navigationFrame_deviceManagement.TransitionAnimationProperties.FrameInterval = 3000;
            // 
            // navigationPage_deviceAdditionDeletion
            // 
            this.navigationPage_deviceAdditionDeletion.Name = "navigationPage_deviceAdditionDeletion";
            this.navigationPage_deviceAdditionDeletion.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_monitorThreshold
            // 
            this.navigationPage_monitorThreshold.Controls.Add(this.monitorThreshold1);
            this.navigationPage_monitorThreshold.Name = "navigationPage_monitorThreshold";
            this.navigationPage_monitorThreshold.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_diagnosisManagement
            // 
            this.navigationPage_diagnosisManagement.Controls.Add(this.diagnosisManagement1);
            this.navigationPage_diagnosisManagement.Name = "navigationPage_diagnosisManagement";
            this.navigationPage_diagnosisManagement.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_reserve1
            // 
            this.navigationPage_reserve1.Caption = "navigationPage_reserve1";
            this.navigationPage_reserve1.Name = "navigationPage_reserve1";
            this.navigationPage_reserve1.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_reserve2
            // 
            this.navigationPage_reserve2.Caption = "navigationPage_reserve2";
            this.navigationPage_reserve2.Name = "navigationPage_reserve2";
            this.navigationPage_reserve2.Size = new System.Drawing.Size(1920, 880);
            // 
            // monitorThreshold1
            // 
            this.monitorThreshold1.Location = new System.Drawing.Point(0, 0);
            this.monitorThreshold1.Name = "monitorThreshold1";
            this.monitorThreshold1.Size = new System.Drawing.Size(1920, 880);
            this.monitorThreshold1.TabIndex = 0;
            // 
            // diagnosisManagement1
            // 
            this.diagnosisManagement1.Location = new System.Drawing.Point(0, 0);
            this.diagnosisManagement1.Name = "diagnosisManagement1";
            this.diagnosisManagement1.Size = new System.Drawing.Size(1920, 880);
            this.diagnosisManagement1.TabIndex = 0;
            // 
            // DeviceManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame_deviceManagement);
            this.Name = "DeviceManagement";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_deviceManagement)).EndInit();
            this.navigationFrame_deviceManagement.ResumeLayout(false);
            this.navigationPage_monitorThreshold.ResumeLayout(false);
            this.navigationPage_diagnosisManagement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_deviceManagement;
        private MonitorThreshold monitorThreshold1;
        private DiagnosisManagement diagnosisManagement1;
    }
}
