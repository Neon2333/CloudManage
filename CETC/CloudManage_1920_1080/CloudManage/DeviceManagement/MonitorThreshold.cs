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
        string cmdQueryDeviceInfoThreshold = String.Empty;

        public MonitorThreshold()
        {
            InitializeComponent();

            _initSideTileBarWithSub();
            Global._init_dtDeviceInfoThresholdGridShow();
            Global.reorderDtFaultsConfigNO(Global.dtDeviceInfoThresholdGridShow);
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
        private void initCmdQueryDeviceInfoThreshold()
        {
            if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem == "000")
            {
                if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub == "000")
                {
                    cmdQueryDeviceInfoThreshold = "CALL initDtDeviceInfoThresholdGridShowTemp()";
                }
                else
                {
                    cmdQueryDeviceInfoThreshold = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO " +
                                           "AND t3.DeviceNO='" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub + "' ORDER BY t1.`NO`;";
                }
            }
            else
            {
                if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub == "000")
                {
                    cmdQueryDeviceInfoThreshold = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO " +
                                           "AND t2.LineNO='" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem + "' ORDER BY t1.`NO`;";
                }
                else
                {
                    cmdQueryDeviceInfoThreshold = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO " +
                                           "AND t2.LineNO='" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem + "' " +
                                           "AND t3.DeviceNO='" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub + "' " +
                                           "ORDER BY t1.`NO`;";
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

            initCmdQueryDeviceInfoThreshold();

            


        }

        





    }
}
