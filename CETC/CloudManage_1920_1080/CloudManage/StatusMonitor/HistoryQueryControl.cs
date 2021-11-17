using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using System.IO;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Diagnostics;
using System.Collections;
using DevExpress.XtraEditors.Popup;

namespace CloudManage.StatusMonitor
{
    public partial class HistoryQueryControl : DevExpress.XtraEditors.XtraUserControl
    {
        string cmdQueryFaultsHistory = String.Empty;

        public HistoryQueryControl()
        {
            InitializeComponent();
            initHistoryQuery();
        }

        void initHistoryQuery()
        {
            _initSideTileBarWithSub();  //初始化侧边栏
            Global._init_dtHistoryQueryGridShow();    //初始化历史故障表，默认显示全部故障历史
            _initTimeEditStartAndEnd();
            //初始化显示一个月的历史
            Global.queryDtHistoryQueryGridShowClickedQueryButton(this.timeEdit_startTime.Time.ToString("yyyy-MM-dd HH:mm:ss"), this.timeEdit_endTime.Time.ToString("yyyy-MM-dd HH:mm:ss"));   
            this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShow;
        }

        //刷新目录
        void _refreshLabelDir()
        {
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub_historyQuery.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub_historyQuery.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2;
        }

        //初始化子菜单
        void _initSideTileBarWithSub()
        {
            this.sideTileBarControlWithSub_historyQuery.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_historyQuery.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_historyQuery.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_historyQuery.colTextDT = "LineName";
            this.sideTileBarControlWithSub_historyQuery.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_historyQuery.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_historyQuery.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_historyQuery._initSideTileBarWithSub();
        }

        void _initTimeEditStartAndEnd()
        {
            DateTime nowdt = DateTime.Now;
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);  //当前日期的一个月前日期
            this.timeEdit_startTime.Time = oneMonthAgo;
            this.timeEdit_endTime.Time = nowdt;
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

        private bool _timeInterValIllegal()
        {
            if (this.timeEdit_endTime.Time <= this.timeEdit_startTime.Time)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void initCmdQueryFaultsHistory()
        {
            if (this.sideTileBarControlWithSub_historyQuery.tagSelectedItem == "000")
            {
                if (this.sideTileBarControlWithSub_historyQuery.tagSelectedItemSub == "000")
                {
                    cmdQueryFaultsHistory = "SELECT t1.`NO`,t2.LineName,t3.DeviceName,t4.FaultName,t1.FaultTime " +
                                            "FROM faults_history AS t1 " +
                                            "INNER JOIN productionline AS t2 " +
                                            "INNER JOIN device AS t3 " +
                                            "INNER JOIN faults AS t4 " +
                                            "ON t1.LineNO=t2.LineNO " +
                                            "AND t1.DeviceNO=t3.DeviceNO " +
                                            "AND t1.DeviceNO=t4.DeviceNO " +
                                            "AND t1.FaultNO=t4.FaultNO " +
                                            "ORDER BY t1.`NO`;";
                }
                else
                {
                    cmdQueryFaultsHistory = "SELECT t1.`NO`,t2.LineName,t3.DeviceName,t4.FaultName,t1.FaultTime " +
                                            "FROM faults_history AS t1 " +
                                            "INNER JOIN productionline AS t2 " +
                                            "INNER JOIN device AS t3 " +
                                            "INNER JOIN faults AS t4 " +
                                            "ON t1.LineNO=t2.LineNO " +
                                            "AND t1.DeviceNO=t3.DeviceNO " +
                                            "AND t1.DeviceNO=t4.DeviceNO " +
                                            "AND t1.FaultNO=t4.FaultNO " +
                                            //"AND t1.LineNO='" + this.sideTileBarControlWithSub_historyQuery.tagSelectedItem + "' " +
                                            "AND t1.DeviceNO='" + this.sideTileBarControlWithSub_historyQuery.tagSelectedItemSub + "' " + 
                                            "ORDER BY t1.`NO`;";
                }
            }
            else
            {
                if (this.sideTileBarControlWithSub_historyQuery.tagSelectedItemSub == "000")
                {
                    cmdQueryFaultsHistory = "SELECT t1.`NO`,t2.LineName,t3.DeviceName,t4.FaultName,t1.FaultTime " +
                                            "FROM faults_history AS t1 " +
                                            "INNER JOIN productionline AS t2 " +
                                            "INNER JOIN device AS t3 " +
                                            "INNER JOIN faults AS t4 " +
                                            "ON t1.LineNO=t2.LineNO " +
                                            "AND t1.DeviceNO=t3.DeviceNO " +
                                            "AND t1.DeviceNO=t4.DeviceNO " +
                                            "AND t1.FaultNO=t4.FaultNO " +
                                            "AND t1.LineNO='" + this.sideTileBarControlWithSub_historyQuery.tagSelectedItem + "' " +
                                            //"AND t1.DeviceNO='" + this.sideTileBarControlWithSub_historyQuery.tagSelectedItemSub + "' " +
                                            "ORDER BY t1.`NO`;";
                }
                else
                {
                    cmdQueryFaultsHistory = "SELECT t1.`NO`,t2.LineName,t3.DeviceName,t4.FaultName,t1.FaultTime " +
                                            "FROM faults_history AS t1 " +
                                            "INNER JOIN productionline AS t2 " +
                                            "INNER JOIN device AS t3 " +
                                            "INNER JOIN faults AS t4 " +
                                            "ON t1.LineNO=t2.LineNO " +
                                            "AND t1.DeviceNO=t3.DeviceNO " +
                                            "AND t1.DeviceNO=t4.DeviceNO " +
                                            "AND t1.FaultNO=t4.FaultNO " +
                                            "AND t1.LineNO='" + this.sideTileBarControlWithSub_historyQuery.tagSelectedItem + "' " +
                                            "AND t1.DeviceNO='" + this.sideTileBarControlWithSub_historyQuery.tagSelectedItemSub + "' " +
                                            "ORDER BY t1.`NO`;";
                }
            }
        }


        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            if (_timeInterValIllegal() == true)
            {
                MessageBox.Show("无效时间区间，请重新选择...");
            }
            else
            {
                //查询改变grid绑定的表
                Global.queryDtHistoryQueryGridShowClickedQueryButton(this.timeEdit_startTime.Time.ToString("yyyy-MM-dd HH:mm:ss"), this.timeEdit_endTime.Time.ToString("yyyy-MM-dd HH:mm:ss"));   //点击查询显示时间段内的故障
                this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
            }


        }

        private void simpleButton_startTimeModify_Click(object sender, EventArgs e)
        {
            this.timeEdit_startTime.ShowPopup();
        }

        private void simpleButton_endTimeModify_Click(object sender, EventArgs e)
        {
            this.timeEdit_endTime.ShowPopup();
        }


        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
            _refreshLabelDir();
        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

            initCmdQueryFaultsHistory(); //初始化查询命令，4种

            MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            mysqlHelper1._connectMySQL();
            bool flag = mysqlHelper1._queryTableMySQL(cmdQueryFaultsHistory, ref Global.dtHistoryQueryGridShow);
            Global.reorderDtFaultsConfigNO(Global.dtHistoryQueryGridShow);

        }

        private void simpleButton_query3Months_Click(object sender, EventArgs e)
        {
            Global.queryDtHistoryQueryGridShowClickedQueryButton(DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));   //点击查询显示时间段内的故障
            this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
        }

        private void simpleButton_query6Months_Click(object sender, EventArgs e)
        {
            Global.queryDtHistoryQueryGridShowClickedQueryButton(DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));   //点击查询显示时间段内的故障
            this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
        }
    }
}
