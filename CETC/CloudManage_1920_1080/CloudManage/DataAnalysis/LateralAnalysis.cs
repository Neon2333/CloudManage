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
    public partial class LateralAnalysis : DevExpress.XtraEditors.XtraUserControl
    {
        public LateralAnalysis()
        {
            InitializeComponent();
            initLateralAnalysis();
        }

        void initLateralAnalysis()
        {
            Global._init_dtTestingDeviceName();
            this.sideTileBarControl_lateralAnalysis.dtInitSideTileBar = Global.dtTestingDeviceName;
            this.sideTileBarControl_lateralAnalysis._initSideTileBar("DeviceNO", "DeviceName", null);
        }

        private void sideTileBarControl_lateralAnalysis_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.sideTileBarControl_lateralAnalysis.tagSelectedItem.ToString());
        }
    }
}
