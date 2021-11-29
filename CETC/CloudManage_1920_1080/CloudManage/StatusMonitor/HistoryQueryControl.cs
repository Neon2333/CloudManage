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
using DevExpress.XtraBars.Docking2010;

namespace CloudManage.StatusMonitor
{
    public partial class HistoryQueryControl : DevExpress.XtraEditors.XtraUserControl
    {
        string cmdQueryFaultsHistory = String.Empty;

        int excelFileNameIndex = 1;
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
            _initWindowsUIButtonPanel();
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

        private void _initWindowsUIButtonPanel()
        {
            windowsUIButtonPanel_historyQuery.ButtonChecked += windowsUIButtonPanel_historyQuery_buttonChecked;
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

        private void exportExcelDtHistoryQueryGridShow(string path)
        {
            DataTable dtGrid = (DataTable)this.gridControl_faultDataTime.DataSource;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string excelFileName = path + "\\faultsHistory" + excelFileNameIndex++.ToString() + ".xlsx";
            FileStream filestream = new FileStream(excelFileName, FileMode.OpenOrCreate);

            XSSFWorkbook wk = new XSSFWorkbook();   //创建表对象wk
            ISheet isheet = wk.CreateSheet("Sheet1");   //在wk中创建sheet1

            IRow row = null;
            ICell cell = null;
            //加表头
            row = isheet.CreateRow(0);
            cell = row.CreateCell(0);
            cell.SetCellValue("序号");
            cell = row.CreateCell(1);
            cell.SetCellValue("产线名称");
            cell = row.CreateCell(2);
            cell.SetCellValue("设备名称");
            cell = row.CreateCell(3);
            cell.SetCellValue("故障名称");
            cell = row.CreateCell(4);
            cell.SetCellValue("故障时间");

            for (int i = 1; i < dtGrid.Rows.Count + 1; i++)
            {
                row = isheet.CreateRow(i); //创建index=j的行
                for (int j = 0; j < 5; j++)
                {
                    cell = row.CreateCell(j);      //在index=j的行中创建index=0的单元格
                    cell.SetCellValue(dtGrid.Rows[i - 1][j].ToString());     //给创建的单元格赋值string
                }
                
            }

            wk.Write(filestream);   //通过流filestream将表wk写入文件
            filestream.Close(); //关闭文件流filestream
            wk.Close();	//关闭Excel表对象wk
            MessageBox.Show("Excel导出");
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
            Global.reorderDt(ref Global.dtHistoryQueryGridShow);

        }

        private void simpleButton_query1Week_Click(object sender, EventArgs e)
        {
            Global.queryDtHistoryQueryGridShowClickedQueryButton(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));   //点击查询显示时间段内的故障
            this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
        }

        private void simpleButton_query1Months_Click(object sender, EventArgs e)
        {
            Global.queryDtHistoryQueryGridShowClickedQueryButton(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));   //点击查询显示时间段内的故障
            this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
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

        void windowsUIButtonPanel_historyQuery_buttonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "exportXLSX":
                    exportExcelDtHistoryQueryGridShow("C:\\Users\\eivision\\Desktop\\FaultsHistoryExportExcel");
                    break;

            }
            e.Button.Properties.Checked = false;
        }
    }
}
