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

namespace CloudManage.SystemConfig
{
    public partial class SystemConfig : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_productionLineAdditionDeletion;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_reserve1;
        private NavigationPage[] systemConfigPages = new NavigationPage[2];

        public SystemConfig()
        {
            InitializeComponent();
            initSystemConfigPage();

            SplashScreenManager.Default.SendCommand(SplashScreen1.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);

        }

        public Boolean frameVisible
        {
            get
            {
                return this.navigationFrame_systemConfig.Visible;
            }
            set
            {
                this.navigationFrame_systemConfig.Visible = value;
            }
        }

        private void initSystemConfigPage()
        {
            systemConfigPages[0] = navigationPage_productionLineAdditionDeletion;
            systemConfigPages[1] = navigationPage_reserve1;
        }

        public int selectedFramePage
        {
            get
            {
                for (int i = 0; i < systemConfigPages.Length; i++)
                {
                    if (this.navigationFrame_systemConfig.SelectedPage == systemConfigPages[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
            set
            {
                this.navigationFrame_systemConfig.SelectedPage = systemConfigPages[value];
            }
        }

        public void setSelectedFramePage(int pageIndex)
        {
            this.navigationFrame_systemConfig.SelectedPage = systemConfigPages[pageIndex];
        }
    }
}
