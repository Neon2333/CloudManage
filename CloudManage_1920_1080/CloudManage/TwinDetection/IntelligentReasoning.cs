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


namespace CloudManage.TwinDetection
{
    public partial class IntelligentReasoning : DevExpress.XtraEditors.XtraUserControl
    {
        public static ushort currentPageIndex = 7;        //WorkState页面在所有页面中的index，供SetBitValueInt64使用

        public IntelligentReasoning()
        {
            InitializeComponent();
            initIntelligentReasoning();
            MainForm.deviceOrLineAdditionDeletionReinitIntelligentReasoning += reInitIntelligentReasoning;
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);

        }

        private void initIntelligentReasoning()
        {
            this.sideTileBarControlWithSub_intelligentReasoning.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_intelligentReasoning.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_intelligentReasoning.colTextDT = "LineName";
            this.sideTileBarControlWithSub_intelligentReasoning.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_intelligentReasoning.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_intelligentReasoning.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_intelligentReasoning.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_intelligentReasoning._initSideTileBarWithSub();
        }

        private void reInitIntelligentReasoning(object sender, EventArgs e)
        {
            initIntelligentReasoning();
            Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = Global.SetBitValueInt32(Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion, currentPageIndex, false);  //刷新页面后将该页面的标志位重置

        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {

        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {

        }


    }
}
