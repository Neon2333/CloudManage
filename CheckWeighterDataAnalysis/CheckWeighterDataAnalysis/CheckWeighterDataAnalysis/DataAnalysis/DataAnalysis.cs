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
using DevExpress.XtraBars.Navigation;

namespace CheckWeighterDataAnalysis.DataAnalysis
{
    public partial class DataAnalysis : DevExpress.XtraEditors.XtraUserControl
    {
        private NavigationPage navigationPage_timeDomainAnalysis;
        private NavigationPage navigationPage_frequencyDomainAnalysis;
        private NavigationPage[] dataAnalysisPages = new NavigationPage[2];



        public DataAnalysis()
        {
            InitializeComponent();
            initDataAnalysisPages();
        }

        private void initDataAnalysisPages()
        {
            dataAnalysisPages[0] = navigationPage_timeDomainAnalysis;
            dataAnalysisPages[1] = navigationPage_frequencyDomainAnalysis;
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
