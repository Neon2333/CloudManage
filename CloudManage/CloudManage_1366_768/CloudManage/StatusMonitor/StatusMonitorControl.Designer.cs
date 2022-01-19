namespace CloudManage.StatusMonitor
{
    partial class StatusMonitorControl
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
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_workState = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_realTimeStatistics = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_historyQuery = new DevExpress.XtraBars.Navigation.NavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPage_workState);
            this.navigationFrame1.Controls.Add(this.navigationPage_realTimeStatistics);
            this.navigationFrame1.Controls.Add(this.navigationPage_historyQuery);
            this.navigationFrame1.Location = new System.Drawing.Point(51, 73);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_workState,
            this.navigationPage_realTimeStatistics,
            this.navigationPage_historyQuery});
            this.navigationFrame1.SelectedPage = this.navigationPage_realTimeStatistics;
            this.navigationFrame1.Size = new System.Drawing.Size(1366, 618);
            this.navigationFrame1.TabIndex = 0;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage_workState
            // 
            this.navigationPage_workState.Name = "navigationPage_workState";
            this.navigationPage_workState.Size = new System.Drawing.Size(1366, 618);
            // 
            // navigationPage_realTimeStatistics
            // 
            this.navigationPage_realTimeStatistics.Name = "navigationPage_realTimeStatistics";
            this.navigationPage_realTimeStatistics.Size = new System.Drawing.Size(1366, 618);
            // 
            // navigationPage_historyQuery
            // 
            this.navigationPage_historyQuery.Name = "navigationPage_historyQuery";
            this.navigationPage_historyQuery.Size = new System.Drawing.Size(1366, 618);
            // 
            // StatusMonitorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame1);
            this.Name = "StatusMonitorControl";
            this.Size = new System.Drawing.Size(1366, 618);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_workState;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_realTimeStatistics;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_historyQuery;
    }
}
