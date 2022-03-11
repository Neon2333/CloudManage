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

namespace CloudManage.TwinDetection
{
    public partial class ParaSynchronize : DevExpress.XtraEditors.XtraUserControl
    {
        public static ushort currentPageIndex = 6;        //WorkState页面在所有页面中的index，供SetBitValueInt64使用

        public ParaSynchronize()
        {
            InitializeComponent();
            initParaSynchronize();
            MainForm.deviceOrLineAdditionDeletionReinitParaSynchronize += reInitParaSynchronize;

        }

        private void initParaSynchronize()
        {

        }

        private void reInitParaSynchronize(object sender, EventArgs e)
        {
            MessageBox.Show("页面重刷");
            Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = Global.SetBitValueInt32(Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion, currentPageIndex, false);  //刷新页面后将该页面的标志位重置

        }

        private void sideTileBarControlWithSub_paraSyn_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {

        }

        private void sideTileBarControlWithSub_paraSyn_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {

        }


    }
}
