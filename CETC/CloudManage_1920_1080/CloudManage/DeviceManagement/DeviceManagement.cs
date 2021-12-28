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

namespace CloudManage.DeviceManagement
{
    public partial class DeviceManagement : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_deviceAdditionDeletion;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_diagnosisManagement;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_monitorThreshold;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_reserve1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_reserve2;
        private NavigationPage[] deviceManagementPages = new NavigationPage[5];


        public DeviceManagement()
        {
            InitializeComponent();
            initDeviceManagementPage();
            SplashScreenManager.Default.SendCommand(SplashScreen1.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);

        }

        public Boolean frameVisible
        {
            get
            {
                return this.navigationFrame_deviceManagement.Visible;
            }
            set
            {
                this.navigationFrame_deviceManagement.Visible = value;
            }
        }

        private void initDeviceManagementPage()
        {
            deviceManagementPages[0] = navigationPage_deviceAdditionDeletion;
            deviceManagementPages[1] = navigationPage_monitorThreshold;
            deviceManagementPages[2] = navigationPage_diagnosisManagement;
            deviceManagementPages[3] = navigationPage_reserve1;
            deviceManagementPages[4] = navigationPage_reserve2;
        }

        public int selectedFramePage
        {
            get
            {
                //return (NavigationPage)this.navigationFrame_statusMonitor.SelectedPage; //SelectedPage是InavigationPage，时NavigationPage的父类
                for (int i = 0; i < deviceManagementPages.Length; i++)
                {
                    if (this.navigationFrame_deviceManagement.SelectedPage == deviceManagementPages[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
            set
            {
                this.navigationFrame_deviceManagement.SelectedPage = deviceManagementPages[value];
            }
        }

        public void setSelectedFramePage(int pageIndex)
        {
            this.navigationFrame_deviceManagement.SelectedPage = deviceManagementPages[pageIndex];
        }
    }
}
