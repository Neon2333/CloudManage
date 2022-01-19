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
using DevExpress.XtraSplashScreen;

namespace CloudManage.DeepLearning
{
    public partial class DeepLearning : DevExpress.XtraEditors.XtraUserControl
    {
        private NavigationPage navigationPage_dataPreparation;
        private NavigationPage navigationPage_modelTraining;
        private NavigationPage navigationPage_modelTest;
        private NavigationPage navigationPage_modelUpdate;
        private NavigationPage[] deepLearningPages = new NavigationPage[4];

        public DeepLearning()
        {
            InitializeComponent();
            initDeepLearningPage();

            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 0);
        }

        private void initDeepLearningPage()
        {
            deepLearningPages[0] = navigationPage_dataPreparation;
            deepLearningPages[1] = navigationPage_modelTraining;
            deepLearningPages[2] = navigationPage_modelTest;
            deepLearningPages[3] = navigationPage_modelUpdate;
        }

        public int selectedFramePage
        {
            get
            {
                //return (NavigationPage)this.navigationFrame_statusMonitor.SelectedPage; //SelectedPage是InavigationPage，时NavigationPage的父类
                for (int i = 0; i < deepLearningPages.Length; i++)
                {
                    if (this.navigationFrame_deepLearning.SelectedPage == deepLearningPages[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
            set
            {
                this.navigationFrame_deepLearning.SelectedPage = deepLearningPages[value];
            }
        }

        public void setSelectedFramePage(int pageIndex)
        {
            this.navigationFrame_deepLearning.SelectedPage = deepLearningPages[pageIndex];
        }

    }
}
