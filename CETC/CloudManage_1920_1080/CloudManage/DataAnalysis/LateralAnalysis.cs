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
            this.sideTileBarControl_lateralAnalysis.dtInitSideTileBar = Global.dtTestingDeviceName;
            this.sideTileBarControl_lateralAnalysis.colTagDT = "DeviceNO";
            this.sideTileBarControl_lateralAnalysis.colTextDT = "DeviceName";
            this.sideTileBarControl_lateralAnalysis.colNumDT = null;
            this.sideTileBarControl_lateralAnalysis._initSideTileBar();
        }

        private void sideTileBarControl_lateralAnalysis_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.sideTileBarControl_lateralAnalysis.tagSelectedItem.ToString());
        }
    }
}
