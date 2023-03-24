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

namespace CloudManage.TwinDetection
{
    public partial class TwinDetection : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_paraSynchronize;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_intelligentReasoning;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_paraUpdate;
        private NavigationPage[] twinDetectionPages = new NavigationPage[3];

        public TwinDetection()
        {
            InitializeComponent();
            initDeviceManagementPage();
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);

        }

        public Boolean frameVisible
        {
            get
            {
                return this.navigationFrame_twinDetection.Visible;
            }
            set
            {
                this.navigationFrame_twinDetection.Visible = value;
            }
        }

        private void initDeviceManagementPage()
        {
            twinDetectionPages[0] = navigationPage_paraSynchronize;
            twinDetectionPages[1] = navigationPage_intelligentReasoning;
            twinDetectionPages[2] = navigationPage_paraUpdate;
        }

        public int selectedFramePage
        {
            get
            {
                //return (NavigationPage)this.navigationFrame_statusMonitor.SelectedPage; //SelectedPage是InavigationPage，时NavigationPage的父类
                for (int i = 0; i < twinDetectionPages.Length; i++)
                {
                    if (this.navigationFrame_twinDetection.SelectedPage == twinDetectionPages[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
            set
            {
                this.navigationFrame_twinDetection.SelectedPage = twinDetectionPages[value];
            }
        }

        public void setSelectedFramePage(int pageIndex)
        {
            this.navigationFrame_twinDetection.SelectedPage = twinDetectionPages[pageIndex];
        }


    }
}
