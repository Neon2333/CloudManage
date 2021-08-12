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
            this.navigationFrame_statusMonitor = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_workState = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.workStateControl1 = new CloudManage.StatusMonitor.WorkStateControl();
            this.navigationPage_realTimeData = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.realTimeDataControl1 = new CloudManage.RealTimeDataControl();
            this.navigationPage_historyQuery = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.historyQueryControl1 = new CloudManage.StatusMonitor.HistoryQueryControl();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_statusMonitor)).BeginInit();
            this.navigationFrame_statusMonitor.SuspendLayout();
            this.navigationPage_workState.SuspendLayout();
            this.navigationPage_realTimeData.SuspendLayout();
            this.navigationPage_historyQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame_statusMonitor
            // 
            this.navigationFrame_statusMonitor.Controls.Add(this.navigationPage_workState);
            this.navigationFrame_statusMonitor.Controls.Add(this.navigationPage_realTimeData);
            this.navigationFrame_statusMonitor.Controls.Add(this.navigationPage_historyQuery);
            this.navigationFrame_statusMonitor.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame_statusMonitor.Name = "navigationFrame_statusMonitor";
            this.navigationFrame_statusMonitor.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_workState,
            this.navigationPage_realTimeData,
            this.navigationPage_historyQuery});
            this.navigationFrame_statusMonitor.SelectedPage = this.navigationPage_workState;
            this.navigationFrame_statusMonitor.Size = new System.Drawing.Size(1920, 880);
            this.navigationFrame_statusMonitor.TabIndex = 0;
            // 
            // navigationPage_workState
            // 
            this.navigationPage_workState.Caption = "navigationPage_workState";
            this.navigationPage_workState.Controls.Add(this.workStateControl1);
            this.navigationPage_workState.Name = "navigationPage_workState";
            this.navigationPage_workState.Size = new System.Drawing.Size(1920, 880);
            // 
            // workStateControl1
            // 
            this.workStateControl1.Location = new System.Drawing.Point(0, 0);
            this.workStateControl1.Name = "workStateControl1";
            this.workStateControl1.Size = new System.Drawing.Size(1920, 880);
            this.workStateControl1.TabIndex = 0;
            // 
            // navigationPage_realTimeData
            // 
            this.navigationPage_realTimeData.Caption = "navigationPage_realTimeData";
            this.navigationPage_realTimeData.Controls.Add(this.realTimeDataControl1);
            this.navigationPage_realTimeData.Name = "navigationPage_realTimeData";
            this.navigationPage_realTimeData.Size = new System.Drawing.Size(1920, 880);
            // 
            // realTimeDataControl1
            // 
            this.realTimeDataControl1.Location = new System.Drawing.Point(0, 0);
            this.realTimeDataControl1.Name = "realTimeDataControl1";
            this.realTimeDataControl1.Size = new System.Drawing.Size(1920, 880);
            this.realTimeDataControl1.TabIndex = 0;
            // 
            // navigationPage_historyQuery
            // 
            this.navigationPage_historyQuery.Caption = "navigationPage_historyQuery";
            this.navigationPage_historyQuery.Controls.Add(this.historyQueryControl1);
            this.navigationPage_historyQuery.Name = "navigationPage_historyQuery";
            this.navigationPage_historyQuery.Size = new System.Drawing.Size(1920, 880);
            // 
            // historyQueryControl1
            // 
            this.historyQueryControl1.Location = new System.Drawing.Point(0, 0);
            this.historyQueryControl1.Name = "historyQueryControl1";
            this.historyQueryControl1.Size = new System.Drawing.Size(1920, 880);
            this.historyQueryControl1.TabIndex = 0;
            // 
            // StatusMonitorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame_statusMonitor);
            this.Name = "StatusMonitorControl";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_statusMonitor)).EndInit();
            this.navigationFrame_statusMonitor.ResumeLayout(false);
            this.navigationPage_workState.ResumeLayout(false);
            this.navigationPage_realTimeData.ResumeLayout(false);
            this.navigationPage_historyQuery.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_statusMonitor;
        //private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_workState;
        //private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_realTimeData;
        //private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_historyQuery;
        private WorkStateControl workStateControl1;
        private RealTimeDataControl realTimeDataControl1;
        private HistoryQueryControl historyQueryControl1;
    }
}
