
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
            this.navigationPage_deviceTesting = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_deviceDeletion = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_deviceAddition = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_diagnosisManagement = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.diagnosisManagement1 = new CloudManage.DeviceManagement.DiagnosisManagement();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_deviceManagement)).BeginInit();
            this.navigationFrame_deviceManagement.SuspendLayout();
            this.navigationPage_diagnosisManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame_deviceManagement
            // 
            this.navigationFrame_deviceManagement.Controls.Add(this.navigationPage_deviceTesting);
            this.navigationFrame_deviceManagement.Controls.Add(this.navigationPage_deviceDeletion);
            this.navigationFrame_deviceManagement.Controls.Add(this.navigationPage_deviceAddition);
            this.navigationFrame_deviceManagement.Controls.Add(this.navigationPage_diagnosisManagement);
            this.navigationFrame_deviceManagement.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame_deviceManagement.Name = "navigationFrame_deviceManagement";
            this.navigationFrame_deviceManagement.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_deviceAddition,
            this.navigationPage_deviceDeletion,
            this.navigationPage_deviceTesting,
            this.navigationPage_diagnosisManagement});
            this.navigationFrame_deviceManagement.SelectedPage = this.navigationPage_diagnosisManagement;
            this.navigationFrame_deviceManagement.Size = new System.Drawing.Size(1920, 880);
            this.navigationFrame_deviceManagement.TabIndex = 0;
            this.navigationFrame_deviceManagement.Text = "navigationFrame1";
            this.navigationFrame_deviceManagement.TransitionAnimationProperties.FrameInterval = 3000;
            // 
            // navigationPage_deviceTesting
            // 
            this.navigationPage_deviceTesting.Caption = "navigationPage_deviceTesting";
            this.navigationPage_deviceTesting.Name = "navigationPage_deviceTesting";
            this.navigationPage_deviceTesting.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_deviceDeletion
            // 
            this.navigationPage_deviceDeletion.Caption = "navigationPage_deviceDeletion";
            this.navigationPage_deviceDeletion.Name = "navigationPage_deviceDeletion";
            this.navigationPage_deviceDeletion.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_deviceAddition
            // 
            this.navigationPage_deviceAddition.Caption = "navigationPage_deviceAddition";
            this.navigationPage_deviceAddition.Name = "navigationPage_deviceAddition";
            this.navigationPage_deviceAddition.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_diagnosisManagement
            // 
            this.navigationPage_diagnosisManagement.Controls.Add(this.diagnosisManagement1);
            this.navigationPage_diagnosisManagement.Name = "navigationPage_diagnosisManagement";
            this.navigationPage_diagnosisManagement.Size = new System.Drawing.Size(1920, 880);
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
            this.navigationPage_diagnosisManagement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_deviceManagement;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_deviceAddition;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_deviceDeletion;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_deviceTesting;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_diagnosisManagement;
        private DiagnosisManagement diagnosisManagement1;
    }
}
