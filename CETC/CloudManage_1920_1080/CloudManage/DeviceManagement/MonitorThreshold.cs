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
    public partial class MonitorThreshold : DevExpress.XtraEditors.XtraUserControl
    {
        private int[] selectRow = { 0 };
        string cmdQueryDeviceInfoThresholdTemp = String.Empty;

        public MonitorThreshold()
        {
            InitializeComponent();

            _initSideTileBarWithSub();
            Global._init_dtDeviceInfoThresholdGridShow();
            Global.reorderDtFaultsConfigNO(ref Global.dtDeviceInfoThresholdGridShow);
            this.gridControl_deviceInfoThreshold.DataSource = Global.dtDeviceInfoThresholdGridShow;

            if (((DataTable)this.gridControl_deviceInfoThreshold.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRow[0]; //默认选中第一行
            }
        }

        private void _initSideTileBarWithSub()
        {
            this.sideTileBarControlWithSub_monitorThreshold.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_monitorThreshold.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_monitorThreshold.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_monitorThreshold.colTextDT = "LineName";
            this.sideTileBarControlWithSub_monitorThreshold.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_monitorThreshold.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_monitorThreshold.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_monitorThreshold._initSideTileBarWithSub();
        }

        void _refreshLabelDir()
        {
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub);
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

        //根据选中行刷新《更改状态》按钮的颜色
        private void refreshColorButtonStatusChange()
        {
            if (((DataTable)this.gridControl_deviceInfoThreshold.DataSource).Rows.Count != 0)
            {
                DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);
            }
        }

        private void gridControl_deviceInfoThreshold_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_deviceInfoThreshold.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRow = this.tileView1.GetSelectedRows();   //记录选中的行
                refreshColorButtonStatusChange();
            }
        }

        //点击侧边栏查询的命令
        private void initCmdQueryDeviceInfoThresholdTemp()
        {
            if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem == "000")
            {
                if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub == "000")
                {
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(0, '000', '000')";
                }
                else
                {
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(1, '000', '" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub + "');";
                }
            }
            else
            {
                if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub == "000")
                {
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(2,'" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem + "', '000');";
                }
                else
                {
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(2,'" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem + "', '" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub + "');";
                }
            }
        }

        private void sideTileBarControlWithSub_monitorThreshold_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
            //_refreshLabelDir();
        }

        private void sideTileBarControlWithSub_monitorThreshold_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

            initCmdQueryDeviceInfoThresholdTemp();

            MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            mysqlHelper1._connectMySQL();

            //更新dtFaultsConfig
            bool flag = mysqlHelper1._queryTableMySQL(cmdQueryDeviceInfoThresholdTemp, ref Global.dtDeviceInfoThresholdGridShowTemp);
            Global.dtDeviceInfoThresholdGridShow.Rows.Clear();
            Global.transformDtDeviceInfoThresholdGridTemp(ref Global.dtDeviceInfoThresholdGridShowTemp, ref Global.dtDeviceInfoThresholdGridShow);
            Global.reorderDtFaultsConfigNO(ref Global.dtDeviceInfoThresholdGridShow);

        }







    }
}
