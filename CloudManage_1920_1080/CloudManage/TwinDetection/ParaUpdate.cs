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
    public partial class ParaUpdate : DevExpress.XtraEditors.XtraUserControl
    {
        public static ushort currentPageIndex = 8;        //WorkState页面在所有页面中的index，供SetBitValueInt64使用

        public ParaUpdate()
        {
            InitializeComponent();
            initParaUpdate();
            MainForm.deviceOrLineAdditionDeletionReinitParaUpdate += reInitParaUpdate;
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);

        }

        private void initParaUpdate()
        {
            this.sideTileBarControlWithSub_paraUpdate.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_paraUpdate.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_paraUpdate.colTextDT = "LineName";
            this.sideTileBarControlWithSub_paraUpdate.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_paraUpdate.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_paraUpdate.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_paraUpdate.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_paraUpdate._initSideTileBarWithSub();
        }

        private void reInitParaUpdate(object sender, EventArgs e)
        {
            initParaUpdate();
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
