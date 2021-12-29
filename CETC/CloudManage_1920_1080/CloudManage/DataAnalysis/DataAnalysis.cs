using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManage.DataAnalysis
{

    public partial class DataAnalysis : DevExpress.XtraEditors.XtraUserControl
    {
        private LateralAnalysis lateralAnalysis1;
        private VerticalAnalysis verticalAnalysis1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_LateralAnalysis;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_VerticalAnalysis;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_paraOptimization;
        private NavigationPage[] dataAnalysisPages = new NavigationPage[3];

        public DataAnalysis()
        {
            InitializeComponent();
            initDataAnalysisPage();
            loadModules();
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);

        }

        private void loadModules()
        {
            this.lateralAnalysis1 = new CloudManage.DataAnalysis.LateralAnalysis();
            this.navigationPage_LateralAnalysis.Controls.Add(this.lateralAnalysis1);
            this.lateralAnalysis1.Location = new System.Drawing.Point(0, 0);
            this.lateralAnalysis1.Name = "lateralAnalysis1";
            this.lateralAnalysis1.Size = new System.Drawing.Size(1920, 880);
            this.lateralAnalysis1.TabIndex = 0;

            this.verticalAnalysis1 = new CloudManage.DataAnalysis.VerticalAnalysis();
            this.navigationPage_VerticalAnalysis.Controls.Add(this.verticalAnalysis1);
            this.verticalAnalysis1.Location = new System.Drawing.Point(0, 0);
            this.verticalAnalysis1.Name = "verticalAnalysis1";
            this.verticalAnalysis1.Size = new System.Drawing.Size(1920, 880);
            this.verticalAnalysis1.TabIndex = 0;
        }

        public Boolean frameVisible
        {
            get
            {
                return this.navigationFrame_dataAnalysis.Visible;
            }
            set
            {
                this.navigationFrame_dataAnalysis.Visible = value;
            }
        }

        private void initDataAnalysisPage()
        {
            dataAnalysisPages[0] = navigationPage_LateralAnalysis;
            dataAnalysisPages[1] = navigationPage_VerticalAnalysis;
            dataAnalysisPages[2] = navigationPage_paraOptimization;
        }

        public int selectedFramePage
        {
            get
            {
                //return (NavigationPage)this.navigationFrame_statusMonitor.SelectedPage; //SelectedPage是InavigationPage，时NavigationPage的父类
                for (int i = 0; i < dataAnalysisPages.Length; i++)
                {
                    if (this.navigationFrame_dataAnalysis.SelectedPage == dataAnalysisPages[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
            set
            {
                this.navigationFrame_dataAnalysis.SelectedPage = dataAnalysisPages[value];
            }
        }

        public void setSelectedFramePage(int pageIndex)
        {
            this.navigationFrame_dataAnalysis.SelectedPage = dataAnalysisPages[pageIndex];
        }

    }
}
