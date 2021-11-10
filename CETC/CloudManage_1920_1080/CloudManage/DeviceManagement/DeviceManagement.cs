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

namespace CloudManage.DeviceManagement
{
    public partial class DeviceManagement : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_deviceAddition;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_deviceDeletion;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_deviceTesting;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_diagnosisManagement;
        private NavigationPage[] deviceManagementPages = new NavigationPage[4];


        public DeviceManagement()
        {
            InitializeComponent();
            initDeviceManagementPage();
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
            deviceManagementPages[0] = navigationPage_deviceAddition;
            deviceManagementPages[1] = navigationPage_deviceDeletion;
            deviceManagementPages[2] = navigationPage_deviceTesting;
            deviceManagementPages[3] = navigationPage_diagnosisManagement;
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
