
namespace CloudManage.DataAnalysis
{
    partial class DataAnalysis
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
            this.navigationFrame_dataAnalysis = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_LateralAnalysis = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.lateralAnalysis1 = new CloudManage.DataAnalysis.LateralAnalysis();
            this.navigationPage_VerticalAnalysis = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_paraOptimization = new DevExpress.XtraBars.Navigation.NavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_dataAnalysis)).BeginInit();
            this.navigationFrame_dataAnalysis.SuspendLayout();
            this.navigationPage_LateralAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame_dataAnalysis
            // 
            this.navigationFrame_dataAnalysis.Controls.Add(this.navigationPage_LateralAnalysis);
            this.navigationFrame_dataAnalysis.Controls.Add(this.navigationPage_VerticalAnalysis);
            this.navigationFrame_dataAnalysis.Controls.Add(this.navigationPage_paraOptimization);
            this.navigationFrame_dataAnalysis.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame_dataAnalysis.Name = "navigationFrame_dataAnalysis";
            this.navigationFrame_dataAnalysis.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_LateralAnalysis,
            this.navigationPage_VerticalAnalysis,
            this.navigationPage_paraOptimization});
            this.navigationFrame_dataAnalysis.SelectedPage = this.navigationPage_LateralAnalysis;
            this.navigationFrame_dataAnalysis.Size = new System.Drawing.Size(1920, 880);
            this.navigationFrame_dataAnalysis.TabIndex = 0;
            this.navigationFrame_dataAnalysis.Text = "navigationFrame1";
            this.navigationFrame_dataAnalysis.TransitionAnimationProperties.FrameInterval = 3000;
            // 
            // navigationPage_LateralAnalysis
            // 
            this.navigationPage_LateralAnalysis.Caption = "navigationPage_LateralAnalysis";
            this.navigationPage_LateralAnalysis.Controls.Add(this.lateralAnalysis1);
            this.navigationPage_LateralAnalysis.Name = "navigationPage_LateralAnalysis";
            this.navigationPage_LateralAnalysis.Size = new System.Drawing.Size(1920, 880);
            // 
            // lateralAnalysis1
            // 
            this.lateralAnalysis1.Location = new System.Drawing.Point(0, 0);
            this.lateralAnalysis1.Name = "lateralAnalysis1";
            this.lateralAnalysis1.Size = new System.Drawing.Size(1920, 880);
            this.lateralAnalysis1.TabIndex = 0;
            // 
            // navigationPage_VerticalAnalysis
            // 
            this.navigationPage_VerticalAnalysis.Caption = "navigationPage_VerticalAnalysis";
            this.navigationPage_VerticalAnalysis.Name = "navigationPage_VerticalAnalysis";
            this.navigationPage_VerticalAnalysis.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_paraOptimization
            // 
            this.navigationPage_paraOptimization.Caption = "navigationPage_paraOptimization";
            this.navigationPage_paraOptimization.Name = "navigationPage_paraOptimization";
            this.navigationPage_paraOptimization.Size = new System.Drawing.Size(1920, 880);
            // 
            // DataAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame_dataAnalysis);
            this.Name = "DataAnalysis";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_dataAnalysis)).EndInit();
            this.navigationFrame_dataAnalysis.ResumeLayout(false);
            this.navigationPage_LateralAnalysis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_dataAnalysis;
        private LateralAnalysis lateralAnalysis1;
    }
}
