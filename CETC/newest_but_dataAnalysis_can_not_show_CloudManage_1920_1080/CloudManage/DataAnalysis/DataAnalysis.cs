using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
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
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_LateralAnalysis;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_VerticalAnalysis;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_paraOptimization;
        private NavigationPage[] dataAnalysisPages = new NavigationPage[3];

        public DataAnalysis()
        {
            InitializeComponent();
            initDataAnalysisPage();
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
