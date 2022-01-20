using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckWeighterDataAnalysis
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        DateTime now = new DateTime();

        StatusMonitor.StatusMonitor statusMonitor1;

        private CommonControl.ConfirmationBox confirmationBox_applicationClose;

        enum modulePage { statusMonitor = 0, dataAnalysis, exportExcel, sysConfig};
        private NavigationPage[] modulePages = new NavigationPage[4];



        public MainForm()
        {
            InitializeComponent();
            _initMainForm();
        }

        private void timer_datetime_Tick(object sender, EventArgs e)
        {
            now = DateTime.Now;
            this.labelControl_datetime.Text = now.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        private void _initMainForm()
        {
            _loadModules();
            _initPages();

        }

        private void _loadModules()
        {
            //statusMonitor
            statusMonitor1 = new StatusMonitor.StatusMonitor();
            this.statusMonitor1.Location = new System.Drawing.Point(0, 0);
            this.statusMonitor1.Name = "statusMonitor2";
            this.statusMonitor1.Size = new System.Drawing.Size(1024, 617);
            this.statusMonitor1.TabIndex = 0;
            this.navigationPage_statusMonitor.Controls.Add(statusMonitor1);
            //
        }

        private void _initPages()
        {
            modulePages[0] = navigationPage_statusMonitor;
            modulePages[1] = navigationPage_dataAnalysis;
            modulePages[2] = navigationPage_exportExcel;
            modulePages[3] = navigationPage_sysConfig;
        }

        private void _createConfirmBox(string title, string typeConfirmationBox)
        {
            if (this.confirmationBox_applicationClose != null)
                this.confirmationBox_applicationClose.Dispose();

            this.confirmationBox_applicationClose = new CommonControl.ConfirmationBox();
            this.confirmationBox_applicationClose.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox_applicationClose.Appearance.Options.UseBackColor = true;
            this.confirmationBox_applicationClose.Name = "confirmationBox_applicationClose";
            this.confirmationBox_applicationClose.Size = new System.Drawing.Size(350, 150);
            this.confirmationBox_applicationClose.TabIndex = 29;
            this.confirmationBox_applicationClose.titleConfirmationBox = title;
            this.confirmationBox_applicationClose.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_applicationRestart_closeOK);
            this.confirmationBox_applicationClose.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_applicationRestart_closeCancel);
            this.Controls.Add(this.confirmationBox_applicationClose);
            this.confirmationBox_applicationClose.Visible = true;
            this.confirmationBox_applicationClose.BringToFront();
        }

        private void confirmationBox_applicationRestart_closeOK(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void confirmationBox_applicationRestart_closeCancel(object sender, EventArgs e)
        {
        }

        private void tileBarItem_statusMonitor_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.statusMonitor];
        }

        private void tileBarItem_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.dataAnalysis];
        }

        private void tileBarItem_exportExcel_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.exportExcel];
        }

        private void tileBarItem_sysConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.sysConfig];
        }

        private void pictureEdit_CETC_DoubleClick(object sender, EventArgs e)
        {
            _createConfirmBox("确认关闭软件？", "close");
        }



    }
}