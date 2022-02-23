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
using DevExpress.XtraSplashScreen;
using Microsoft.Win32;

namespace CloudManage.StatusMonitor
{
    public partial class HistoryQuery : DevExpress.XtraEditors.XtraUserControl
    {
        string cmdQueryFaultsHistory = String.Empty;
        string startTime = String.Empty;
        string endTime = String.Empty;
        int excelFileNameIndex = 1;

        private int[] selectRowFaultCurrent = { 0 };   

        public HistoryQuery()
        {
            InitializeComponent();
            initHistoryQuery();
            MainForm.deviceOrLineAdditionDeletionReinitHistoryQuery += reInitHistoryQuery;
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);
        }

        public void reInitHistoryQuery(object sender, EventArgs e)
        {
            //MessageBox.Show("重新刷新HistoryQuery页面");
            initHistoryQuery();
        }


        void initHistoryQuery()
        {
            _initSideTileBarWithSub();  //初始化侧边栏
            //Global._init_dtHistoryQueryGridShow();    //初始化历史故障表，默认显示全部故障历史
            _initTimeEditStartAndEnd();
            //初始化显示一个月的历史
            Global._init_dtHistoryQueryGridShow(startTime, endTime);

            this.gridControl_faultHistory.DataSource = Global.dtHistoryQueryGridShow;
            _initWindowsUIButtonPanel();
        }

        void _refreshLabelDir()
        {
            string str1 = Global._getProductionLineNameByTag(this.sideTileBarControlWithSub_historyQuery.tagSelectedItem);
            string str2 = Global._getTestingDeviceNameByTag(this.sideTileBarControlWithSub_historyQuery.tagSelectedItemSub);
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
            startTime = timeEdit_startTime.Time.ToString("yyyy-MM-dd HH:mm:ss");
            endTime = this.timeEdit_endTime.Time.ToString("yyyy-MM-dd HH:mm:ss");
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

        private string defaultFolder = String.Empty;
        private void exportExcelDtHistoryQueryGridShow()
        {
            DataTable dtGrid = (DataTable)this.gridControl_faultHistory.DataSource;
            string path = String.Empty;

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            //注册表法记录上次打开路径（软件重开后仍然有效）
            try
            {

                RegistryKey testKey = Registry.CurrentUser.OpenSubKey("TestKey");
                if (testKey == null)
                {
                    testKey = Registry.CurrentUser.CreateSubKey("TestKey");
                    testKey.SetValue("OpenFolderDir", "");
                    testKey.Close();
                    Registry.CurrentUser.Close();
                }
                else
                {
                    defaultFolder = testKey.GetValue("OpenFolderDir").ToString();
                    testKey.Close();
                    Registry.CurrentUser.Close();
                }
            }
            catch (Exception e)
            {
            }

            //folderDlg.SelectedPath = defaultFolder;     //由上次打开的路径处打开
            if (defaultFolder != "")
            {
                //设置此次默认目录为上一次选中目录                  
                folderDlg.SelectedPath = defaultFolder;
            }

            DialogResult drs = folderDlg.ShowDialog();
            if (drs == DialogResult.OK)
            {
                if (defaultFolder != folderDlg.SelectedPath)
                {
                    defaultFolder = folderDlg.SelectedPath;
                    RegistryKey testKey = Registry.CurrentUser.OpenSubKey("TestKey", true);  //true表示可写，false表示只读
                    testKey.SetValue("OpenFolderDir", defaultFolder);
                    testKey.Close();
                    Registry.CurrentUser.Close();
                }

                //defaultFolder = folderDlg.SelectedPath;      //更新默认路径为上次打开的路径
                path = defaultFolder + "\\faultsHistory";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string excelFileName = path + "\\faultsHistory" + excelFileNameIndex++.ToString() + ".xlsx";
                FileStream filestream = new FileStream(excelFileName, FileMode.OpenOrCreate);

                XSSFWorkbook wk = new XSSFWorkbook();
                ISheet isheet = wk.CreateSheet("Sheet1");

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
                    row = isheet.CreateRow(i);
                    for (int j = 0; j < 5; j++)
                    {
                        cell = row.CreateCell(j);
                        cell.SetCellValue(dtGrid.Rows[i - 1][j].ToString());
                    }

                }

                wk.Write(filestream);   //通过流filestream将表wk写入文件
                filestream.Close(); //关闭文件流filestream
                wk.Close(); //关闭Excel表对象wk
                MessageBox.Show("Excel导出");
            }
            else if(drs == DialogResult.Cancel)
            {
                folderDlg.Dispose();
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
                                            "WHERE t1.FaultTime BETWEEN " +
                                            "'" + startTime.ToString() + "'" + " AND " + "'" + endTime.ToString() + "' " +
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
                                            "WHERE t1.FaultTime BETWEEN " +
                                            "'" + startTime.ToString() + "'" + " AND " + "'" + endTime.ToString() + "' " +
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
                                            "WHERE t1.FaultTime BETWEEN " +
                                            "'" + startTime.ToString() + "'" + " AND " + "'" + endTime.ToString() + "' " +
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
                                            "WHERE t1.FaultTime BETWEEN " +
                                            "'" + startTime.ToString() + "'" + " AND " + "'" + endTime.ToString() + "' " +
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
                startTime = this.timeEdit_startTime.Time.ToString("yyyy-MM-dd HH:mm:ss");
                endTime = this.timeEdit_endTime.Time.ToString("yyyy-MM-dd HH:mm:ss");
                //查询改变grid绑定的表
                Global._init_dtHistoryQueryGridShow(startTime, endTime);   //点击查询显示时间段内的故障
                keepSelectRowWhenDataSourceRefresh();
                //this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
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

        private void refreshGridSourceSideTileBarPressed()
        {
            initCmdQueryFaultsHistory(); //初始化查询命令，4种

            bool flag = Global.mysqlHelper1._queryTableMySQL(cmdQueryFaultsHistory, ref Global.dtHistoryQueryGridShow);
            Global.reorderDt(ref Global.dtHistoryQueryGridShow);
        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            _refreshLabelDir();
            refreshGridSourceSideTileBarPressed();
        }

        private void keepSelectRowWhenDataSourceRefresh()
        {
            if (selectRowFaultCurrent.Length == 1)
            {
                if (selectRowFaultCurrent[0] < this.tileView_1.DataRowCount)
                    this.tileView_1.FocusedRowHandle = selectRowFaultCurrent[0];     //在DataSource发生改变后，手动修改被选中的row
                else
                {
                    this.tileView_1.FocusedRowHandle = 0;
                    selectRowFaultCurrent[0] = 0;
                }
            }
        }

        private void gridControl_faultHistory_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_faultHistory.DataSource).Rows.Count > 0)
                selectRowFaultCurrent = this.tileView_1.GetSelectedRows();  //手动记录被按下按钮
            if (selectRowFaultCurrent.Length > 1)
            {
                MessageBox.Show("当前选中不止一行");
            }
        }

        private void simpleButton_query1Week_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss");
            endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Global._init_dtHistoryQueryGridShow(startTime, endTime);   //点击查询显示时间段内的故障
            keepSelectRowWhenDataSourceRefresh();

            //this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
        }

        private void simpleButton_query1Months_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss");
            endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Global._init_dtHistoryQueryGridShow(startTime, endTime);   //点击查询显示时间段内的故障
            keepSelectRowWhenDataSourceRefresh();

            //this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
        }

        private void simpleButton_query3Months_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd HH:mm:ss");
            endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Global._init_dtHistoryQueryGridShow(startTime, endTime);   //点击查询显示时间段内的故障
            keepSelectRowWhenDataSourceRefresh();

            //this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
        }

        private void simpleButton_query6Months_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd HH:mm:ss");
            endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Global._init_dtHistoryQueryGridShow(startTime, endTime);   //点击查询显示时间段内的故障
            keepSelectRowWhenDataSourceRefresh();

            //this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
        }
        private void simpleButton_exportData_Click(object sender, EventArgs e)
        {
            exportExcelDtHistoryQueryGridShow();
        }

        void windowsUIButtonPanel_historyQuery_buttonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();    //checkedbutton通过tag获取选中的按钮
            switch (tag)
            {
                case "exportXLSX":
                    //exportExcelDtHistoryQueryGridShow();
                    break;

            }
            e.Button.Properties.Checked = false;
        }

        private void timer_refreshDtHistoryQueryGridShow_Tick(object sender, EventArgs e)
        {
            Global._init_dtHistoryQueryGridShow(startTime, endTime);    //初始化历史故障表，默认显示全部故障历史
            keepSelectRowWhenDataSourceRefresh();
        }

    }
}
