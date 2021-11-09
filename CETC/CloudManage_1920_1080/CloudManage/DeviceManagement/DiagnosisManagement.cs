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
    public partial class DiagnosisManagement : DevExpress.XtraEditors.XtraUserControl
    {
        public DiagnosisManagement()
        {
            InitializeComponent();

            _initSideTileBarWithSub();  //初始化侧边栏
            Global._init_dtFaultsConfig();    //初始化故障配置表
            this.gridControl_faultDataTime.DataSource = Global.dtFaultsConfig;
        }

        private void _initSideTileBarWithSub()
        {
            this.sideTileBarControlWithSub_diagnosisManagement.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_diagnosisManagement.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_diagnosisManagement.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_diagnosisManagement.colTextDT = "LineName";
            this.sideTileBarControlWithSub_diagnosisManagement.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_diagnosisManagement.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_diagnosisManagement.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_diagnosisManagement._initSideTileBarWithSub();
        }

        void _refreshLabelDir()
        {
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2;
        }

        private string _getProductionLineNameByTag(string tagProductionLine)
        {
            //dtProductionLine中没有Tag==0的记录
            if (tagProductionLine == "000")
            {
                return "总览";
            }

            string temp = "LineNO=" + "'" + tagProductionLine + "'";
            DataRow[] rowPL = Global.dtProductionLine.Select(temp);
            if (rowPL.Length == 1)
            {
                return (string)rowPL[0]["LineName"];
            }
            else
            {
                return "产线名称查询错误...";
            }
        }

        private string _getTestingDeviceNameByTag(string tagTestingDeviceName)
        {
            if (tagTestingDeviceName == "000")
            {
                return "所有设备";
            }

            string temp = "DeviceNO=" + "'" + tagTestingDeviceName + "'";
            DataRow[] rowTD = Global.dtTestingDeviceName.Select(temp);
            if (rowTD.Length == 1)
            {
                return (string)rowTD[0]["DeviceName"];
            }
            else
            {
                return "产线名称查询错误...";
            }
        }

        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

        }

        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

        }


    }
}
