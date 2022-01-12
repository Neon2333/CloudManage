using System;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Collections.Generic;

namespace CloudManage
{
    class Global
    {
        public static MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");

        public static void initDataTable()
        {
            if (!mysqlHelper1._connectMySQL())
            {
                MessageBox.Show("数据库连接失败");
            }

            Global._init_dtTestingDeviceName(); //初始化检测设备名称表
            Global._init_dtProductionLine();    //初始化产线名称表
            Global._init_dtFaults();         //初始化故障名称表
            Global._init_dtDeviceConfig();      //初始化检测设备使能表
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 10);
            Global._init_dtDeviceInfoThresholdAndLocation();   //初始化设备参数上下限、坐标表
            Global._refreshTitleGridShow();
            Global._writeFaultsHistory();
            Global._init_dtSideTileBarWorkState();  //WorkState侧边栏初始化表
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 10);
        }
        /*
         * MySQL表格：
         * device_config(dtDeviceConfig)——各产线的检测设备使能表：产线ID、检测设备使能标志
         * productionline(dtProductionLine)——产线名称表：产线ID、产线名称
         * device(dtTestingDeviceName)——检测设备名称表：检测设备ID、检测设备名称
         * faults(dtFaults)——各检测设备的所有故障名称表：检测设备ID、故障ID、故障名称、故障使能标志
         * faults_config——各产线对应设备的故障使能：产线ID、检测设备ID、故障ID、使能标志
         * faults_history——所有故障的发生时间：产线ID、设备ID、故障ID、故障时间
         * device_info——WorkState中各个产线对应检测设备的参数：产线ID、检测设备ID、检测设备状态（是否故障）、有效参数个数、Para1(检测数)、Para2(缺陷数)、Para3(CPU温度)、Para4(CPU利用率)、Para5(内存利用率)
         * 
         * datatable，由查询得到：
         * dtSideTileBar（）——初始化侧边栏产线按钮的表：产线ID、产线名称、产线对应检测设备数量
         * dtOverviewWorkState——WorkState中总览显示用表：产线名称、产线状态（是否故障）
         * dtEachProductionLineWorkState——WorkState中每条产线数据显示表
         * dtTitleGridShowMainForm——标题栏显示所有故障的最新若干条记录（由device_info得到）
         * dtHistoryQueryGridShow（faults_history）——HistoryQuery初始显示的所有故障：NO、产线名称、检测设备名称、故障名称、故障发生时间
         * dtHistoryQueryGridShowClickedQueryButton——HistoryQuery查询出来的故障
         * dtRightSideRealTimeData——RealTimeData中右侧显示表：参数名称、参数值
         * 
         * 
         * */


        public static DataTable dtDeviceConfig = new DataTable();         //产线Tag、检测设备使能标志

        public static DataTable dtProductionLine = new DataTable();       //产线Tag、产线名称（text）

        public static DataTable dtTestingDeviceName = new DataTable();    //DeviceNO、DeviceName、MachineNO、LocationX、LocationY、ValidParaCount

        public static DataTable dtFaults = new DataTable();               //序号、检测设备ID、故障ID、故障名称、故障使能标志

        //从MySQL中查询数据初始化表
        public static bool _initDtMySQL(ref DataTable dt, string cmdDt)
        {
            bool flag = mysqlHelper1._queryTableMySQL(cmdDt, ref dt);
            return flag;
        }

        //初始化检测设备使能表
        public static void _init_dtDeviceConfig()
        {
            string cmdInitDtDeviceConfig = "CALL initDtDeviceConfig();";   //21ms
            _initDtMySQL(ref Global.dtDeviceConfig, cmdInitDtDeviceConfig);
        }

        //初始化产线名称表
        public static void _init_dtProductionLine()
        {
            string cmdInitDtProductionLine = "CALL initDtProductionLine();";    //19ms
            _initDtMySQL(ref Global.dtProductionLine, cmdInitDtProductionLine);
        }

        //初始化检测设备名称表
        public static void _init_dtTestingDeviceName()
        {
            string cmdInitDtTestingDeviceName = "CALL initDtTestingDeviceName();";    //19ms
            _initDtMySQL(ref Global.dtTestingDeviceName, cmdInitDtTestingDeviceName);
        }

        //初始化故障表
        public static void _init_dtFaults()
        {
            string cmdInitDtFaults = "CALL initDtFaults();";    //25ms
            _initDtMySQL(ref Global.dtFaults, cmdInitDtFaults);
        }

        /**********************************************************************************************************************************************/
        //共有
        public static DataTable dtSideTileBar = new DataTable();   //WorkState和HistoryQuery侧边栏菜单初始化表
        public static void _init_dtSideTileBarWorkState()
        {
            string cmdInitDtSideTileBar = "CALL initDtSideTileBar();";
            _initDtMySQL(ref Global.dtSideTileBar, cmdInitDtSideTileBar);  //数据库查询时直接将"1"和"0"相加，导致dtSideTileBar中存储的DeviceTotalNum的类型是object(double)
        }

        /**********************************************************************************************************************************************/
        //MainForm
        public static DataTable dtTitleGridShowMainForm = new DataTable();    //主菜单标题显示表
        public static DataTable dtHistoryValid = new DataTable();
        //刷新标题栏故障表
        public static void _refreshTitleGridShow()
        {
            string cmdQueryDtTitleGridShowMainForm = "CALL queryDtTitleGridShowMainForm();";  //查询当前故障表中所有使能故障，并按照grid要求显示名称 
            _initDtMySQL(ref dtTitleGridShowMainForm, cmdQueryDtTitleGridShowMainForm);
            Global.reorderDt(ref dtTitleGridShowMainForm);

            string cmdQueryDtHistoryValid = "CALL queryDtHistoryValid();";   //查询当前故障表中所有使能的故障故障,LineNO等
            _initDtMySQL(ref dtHistoryValid, cmdQueryDtHistoryValid);
        }

        public static void _writeFaultsHistory()
        {
            //判断当前故障表中使能的故障在历史故障表中是否存在，若不存在则将其插入到历史表中
            string cmdInsertFaultsHistory = String.Empty;
            string cmdJudgeIfExistInFaultHistory = String.Empty;

            string valLineNO = String.Empty;
            string valDeviceNO = String.Empty;
            string valFaultNO = String.Empty;
            //string valFaultTime = String.Empty;
            DateTime valFaultTime = new DateTime();

            for (int i = 0; i < dtHistoryValid.Rows.Count; i++)
            {
                valLineNO = Global.dtHistoryValid.Rows[i]["LineNO"].ToString();
                valDeviceNO = Global.dtHistoryValid.Rows[i]["DeviceNO"].ToString();
                valFaultNO = Global.dtHistoryValid.Rows[i]["FaultNO"].ToString();
                //valFaultTime = Global.dtHistoryValid.Rows[i]["FaultTime"].ToString();
                valFaultTime = (DateTime)Global.dtHistoryValid.Rows[i]["FaultTime"];

                cmdJudgeIfExistInFaultHistory = "CALL judgeIfExistInFaultHistory('" + valLineNO + "','" + valDeviceNO + "','" + valFaultNO + "','" + valFaultTime +"');";
                DataTable dtJudgeIfExistInFaultHistory = new DataTable();
                _initDtMySQL(ref dtJudgeIfExistInFaultHistory, cmdJudgeIfExistInFaultHistory);
                if(dtJudgeIfExistInFaultHistory.Columns.Count!=0 && dtJudgeIfExistInFaultHistory.Rows.Count != 0)
                {
                    if (Convert.ToInt32(dtJudgeIfExistInFaultHistory.Rows[0][0]) == 0)
                    {
                        //cmdInsertFaultsHistory = "INSERT INTO faults_history (LineNO, DeviceNO, FaultNO, FaultTime) VALUES (" +
                        //                       "'" + valLineNO + "', " + "'" + valDeviceNO + "', " + "'" + valFaultNO + "', " + "'" + valFaultTime + "');";

                        cmdInsertFaultsHistory = "CALL insertFaultsHistory('" + valLineNO + "','" + valDeviceNO + "','" + valFaultNO + "','" + valFaultTime + "');";  

                        bool flag1 = mysqlHelper1._connectMySQL();
                        bool flag2 = mysqlHelper1._insertMySQL(cmdInsertFaultsHistory);
                        //mysqlHelper1.conn.Close();
                    }
                }
            }
        }

        /**********************************************************************************************************************************************/

        //WorkStateControl
        public static bool[,] flagLineStatus = new bool[1000, 1000];                //下位机长传设备实时故障代表的设备状态标志

        public static DataTable dtOverviewWorkState = new DataTable();              //总览数据表

        public static DataTable dtEachProductionLineWorkState = new DataTable();    //每台产线的检测设备的数据

        public static DataTable dtEachProductionLineSuffix = new DataTable();       //存设备数据的单位
        //初始化WorkState总览表——产线Tag，产线Text（产线名称，查产线名称），产线中检测设备数num（检测设备使能）
        public static void _init_dtOverviewWorkState()
        {
            if (dtOverviewWorkState.Rows.Count == 0)
            {
                //string cmdInitDTOverviewWorkState = "SELECT LineName, " +
                //                                    "(CASE WHEN COUNT(FaultTime)>0 THEN '异常' " +
                //                                    "WHEN COUNT(FaultTime)=0 THEN '正常' " +
                //                                    "END) AS LineStatus " +
                //                                    "FROM productionline AS t1 LEFT JOIN faults_history AS t2 " +
                //                                    "ON t1.LineNO=t2.LineNO " +
                //                                    "GROUP BY LineName " +
                //                                    "ORDER BY t1.`NO`;";
                string cmdInitDTOverviewWorkState = "SELECT LineName, " +
                                                    "(CASE WHEN COUNT(FaultTime)>0 THEN '异常' " +
                                                    "WHEN COUNT(FaultTime)=0 THEN '正常' " +
                                                    "END) AS LineStatus " +
                                                    "FROM productionline AS t1 LEFT JOIN faults_current AS t2 " +
                                                    "ON t1.LineNO=t2.LineNO " +
                                                    "GROUP BY LineName " +
                                                    "ORDER BY t1.`NO`;";    //20ms
                if (dtOverviewWorkState.Columns.Count == 0)
                {
                    //Global.dtOverviewWorkState.Columns.Add("LineName", typeof(String));     //先定义表头也可填充，表头不会填充两次
                    //Global.dtOverviewWorkState.Columns.Add("LineStatus", typeof(String));
                    Global.dtOverviewWorkState.Columns.Add("DeviceImgTop", typeof(Image));
                    Global.dtOverviewWorkState.Columns.Add("DeviceImgBottom", typeof(Image));
                }
                _initDtMySQL(ref dtOverviewWorkState, cmdInitDTOverviewWorkState);

                int totalDeviceNum = dtOverviewWorkState.Rows.Count;
                int undefineTileNum = 0;
                if (totalDeviceNum <= 24)
                {
                    undefineTileNum = 24 - totalDeviceNum;
                }
                else if (totalDeviceNum > 24 && totalDeviceNum <= 48)
                {
                    undefineTileNum = 48 - totalDeviceNum;
                }
                else if (totalDeviceNum > 48 && totalDeviceNum <= 72)
                {
                    undefineTileNum = 72 - totalDeviceNum;
                }
                else if (totalDeviceNum > 72 && totalDeviceNum <= 96)
                {
                    undefineTileNum = 96 - totalDeviceNum;
                }

                //添加“未定义”Tile
                for (int i = 0; i < undefineTileNum; i++)
                {
                    DataRow dr = Global.dtOverviewWorkState.NewRow();
                    dr["LineName"] = "未定义";
                    dr["LineStatus"] = "";
                    dtOverviewWorkState.Rows.Add(dr);
                }

                DataRow drTemp = null;
                for (int i = 0; i < (totalDeviceNum + undefineTileNum); i++)
                {
                    drTemp = dtOverviewWorkState.Rows[i];
                    drTemp["deviceImgTop"] = global::CloudManage.Properties.Resources.ZJ17_PROTOS70_336x140; ;
                    drTemp["deviceImgBottom"] = global::CloudManage.Properties.Resources.ZB45_336x140;
                }
            }
        }

        public static void _init_dtEachProductionLineWorkState(string selectedItemTag)
        {
            if (dtEachProductionLineWorkState.Rows.Count == 0)
            {
                string cmdInitDtEachProductionLineWorkState = "SELECT DISTINCT t1.DeviceNO,t1.ValidParaCount, t2.DeviceName, " +
                                                              "(CASE WHEN t1.DeviceStatus=1 THEN '正常' " +
                                                              "WHEN t1.DeviceStatus=0 THEN '异常' " +
                                                              "END) AS DeviceStatus," +
                                                              "t3.Para1Name, t1.Para1, " +
                                                              "t3.Para2Name, t1.Para2, " +
                                                              "t3.Para3Name, t1.Para3, " +
                                                              "t3.Para4Name, t1.Para4, " +
                                                              "t3.Para5Name, t1.Para5 "  +
                                                              "FROM device_info AS t1 INNER JOIN device AS t2 ON t1.DeviceNO=t2.DeviceNO " +
                                                              "INNER JOIN device_info_paranameandsuffix AS t3 ON t1.DeviceNO=t3.DeviceNO " +
                                                              "WHERE t1.LineNO='" + selectedItemTag +
                                                              "' ORDER BY t1.`NO`;";    //19ms
                if (dtEachProductionLineWorkState.Columns.Count == 0)
                {
                    Global.dtEachProductionLineWorkState.Columns.Add("DeviceImg", typeof(Image));
                }
                _initDtMySQL(ref Global.dtEachProductionLineWorkState, cmdInitDtEachProductionLineWorkState);  //不含单位

                string cmdInitDtEachProductionLineSuffix = "SELECT * FROM device_info_paranameandsuffix " +
                                                           "WHERE device_info_paranameandsuffix.LineNO='" + selectedItemTag + "';";
                _initDtMySQL(ref Global.dtEachProductionLineSuffix, cmdInitDtEachProductionLineSuffix);    //参数单位表

                for(int i = 0; i < Global.dtEachProductionLineWorkState.Rows.Count; i++)
                {
                    int paraCount = Convert.ToInt32(Global.dtEachProductionLineWorkState.Rows[i]["ValidParaCount"]);
                    for(int j = 0; j < paraCount; j++)
                    {
                        string paraCol = "Para" + (j + 1).ToString();
                        string paraSuffixCol = "Para" + (j + 1).ToString() + "Suffix";
                        Global.dtEachProductionLineWorkState.Rows[i][paraCol] += dtEachProductionLineSuffix.Rows[i][paraSuffixCol].ToString();
                    }

                }

                int totalDeviceNum = dtEachProductionLineWorkState.Rows.Count;
                int undefineTileNum = 0;
                if (totalDeviceNum <= 10)
                {
                    undefineTileNum = 10 - totalDeviceNum;
                }
                else if (totalDeviceNum > 10 && totalDeviceNum <= 20)
                {
                    undefineTileNum = 20 - totalDeviceNum;
                }
                else if (totalDeviceNum > 20 && totalDeviceNum <= 30)
                {
                    undefineTileNum = 30 - totalDeviceNum;
                }
                else if (totalDeviceNum > 30 && totalDeviceNum <= 40)
                {
                    undefineTileNum = 40 - totalDeviceNum;
                }
                else if (totalDeviceNum > 40 && totalDeviceNum <= 50)
                {
                    undefineTileNum = 50 - totalDeviceNum;
                }
                else if (totalDeviceNum > 50 && totalDeviceNum <= 60)
                {
                    undefineTileNum = 60 - totalDeviceNum;
                }
                else if (totalDeviceNum > 60 && totalDeviceNum <= 70)
                {
                    undefineTileNum = 70 - totalDeviceNum;
                }
                else if (totalDeviceNum > 70 && totalDeviceNum <= 80)
                {
                    undefineTileNum = 80 - totalDeviceNum;
                }
                else if (totalDeviceNum > 80 && totalDeviceNum <= 90)
                {
                    undefineTileNum = 90 - totalDeviceNum;
                }
                else if (totalDeviceNum > 90 && totalDeviceNum <= 100)
                {
                    undefineTileNum = 100 - totalDeviceNum;
                }

                //添加“无效”Tile
                for (int i = 0; i < undefineTileNum; i++)
                {
                    DataRow dr = Global.dtEachProductionLineWorkState.NewRow();
                    dr["DeviceNO"] = "";
                    dr["DeviceName"] = "未定义";
                    dr["DeviceStatus"] = "";
                    dr["Para1"] = "";
                    dr["Para2"] = "";
                    dr["Para3"] = "";
                    dr["Para4"] = "";
                    dr["Para5"] = "";

                    dtEachProductionLineWorkState.Rows.Add(dr);
                }

                for (int i = 0; i < (totalDeviceNum + undefineTileNum); i++)
                {
                    switch (dtEachProductionLineWorkState.Rows[i]["DeviceNO"].ToString())    //更换检测设备图片
                    {
                        case "001":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "002":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "003":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "004":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "005":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "006":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "007":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "008":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "009":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "010":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "011":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "012":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "013":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "101":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "102":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "103":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "104":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                        case "105":
                            dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = global::CloudManage.Properties.Resources.neichen;
                            break;
                    }
                }


            }
        }

        /**********************************************************************************************************************************************/
       
        //HistoryQueryControl

        public static DataTable dtHistoryQueryGridShow = new DataTable();        //grid初始化显示，所有故障与发生时间

        //public static DataTable dtHistoryQueryGridShowClickedQueryButton = new DataTable();   //查询出来的故障表
        public static string excelPath_historyQueryGridShowClickedQueryButton = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\dtGridShowClickedQueryButtonHistoryQuery";

        public static void _init_dtHistoryQueryGridShow()
        {
            string cmdInitDtHistoryQueryGridShow = "SELECT t1.`NO`,t2.LineName,t3.DeviceName,t4.FaultName,t1.FaultTime " +
                                            "FROM faults_history AS t1 " +
                                            "INNER JOIN productionline AS t2 " +
                                            "INNER JOIN device AS t3 " +
                                            "INNER JOIN faults AS t4 " +
                                            "ON t1.LineNO=t2.LineNO " +
                                            "AND t1.DeviceNO=t3.DeviceNO " +
                                            "AND t1.DeviceNO=t4.DeviceNO " +
                                            "AND t1.FaultNO=t4.FaultNO " +
                                            "ORDER BY t1.`NO`;";
            _initDtMySQL(ref Global.dtHistoryQueryGridShow, cmdInitDtHistoryQueryGridShow);
            Global.reorderDt(ref Global.dtHistoryQueryGridShow);
        }

        public static void _init_dtHistoryQueryGridShow(string timeStart, string timeEnd)
        {
            string cmdQueryDtHistoryQueryGridShowClickedQueryButton = "SELECT t1.`NO`,t2.LineName,t3.DeviceName,t4.FaultName,t1.FaultTime " +
                                            "FROM faults_history AS t1 " +
                                            "INNER JOIN productionline AS t2 " +
                                            "INNER JOIN device AS t3 " +
                                            "INNER JOIN faults AS t4 " +
                                            "ON t1.LineNO=t2.LineNO " +
                                            "AND t1.DeviceNO=t3.DeviceNO " +
                                            "AND t1.DeviceNO=t4.DeviceNO " +
                                            "AND t1.FaultNO=t4.FaultNO " +
                                            "WHERE t1.FaultTime BETWEEN " +
                                            "'" + timeStart + "'" + " AND " + "'" + timeEnd + "' " +
                                            "ORDER BY t1.`NO`;";
            //_initDtMySQL(ref dtHistoryQueryGridShowClickedQueryButton, cmdQueryDtHistoryQueryGridShowClickedQueryButton);
            _initDtMySQL(ref Global.dtHistoryQueryGridShow, cmdQueryDtHistoryQueryGridShowClickedQueryButton);
            Global.reorderDt(ref Global.dtHistoryQueryGridShow);

        }

        /*************************************************************************************************************/

        //RealTimeData
        public static DataTable dtDeviceInfoThresholdAndLocation = new DataTable();

        public static void _init_dtDeviceInfoThresholdAndLocation()
        {
            string cmdInitDtDeviceInfoThresholdAndLocation = "SELECT * FROM device_info_threshold;"; 
            mysqlHelper1._connectMySQL();
            mysqlHelper1._queryTableMySQL(cmdInitDtDeviceInfoThresholdAndLocation, ref Global.dtDeviceInfoThresholdAndLocation);
            mysqlHelper1.conn.Close();
        }

        /*************************************************************************************************************/

        //DiagnosisManagement
        public static DataTable dtFaultsConfig = new DataTable();

        public static void _init_dtFaultsConfig()
        {
            string cmdInitDtFaultsConfig = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO ORDER BY t1.`NO`;";

            _initDtMySQL(ref dtFaultsConfig, cmdInitDtFaultsConfig);

        }

        /*************************************************************************************************************/

        //MonitorThreshold
        public static DataTable dtDeviceInfoThresholdGridShowTemp = new DataTable();
        public static DataTable dtDeviceInfoThresholdGridShow = new DataTable();
        public static void _init_dtDeviceInfoThresholdGridShowTemp()
        {
            string cmdInitDtDeviceInfoThresholdGridShowTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(0, '000', '000');";
            _initDtMySQL(ref dtDeviceInfoThresholdGridShowTemp, cmdInitDtDeviceInfoThresholdGridShowTemp);
        }
        
        //将设备有若干参数共用一行，转化为每个参数作为一行的表格形式
        public static void transformDtDeviceInfoThresholdGridTemp(ref DataTable dtTemp, ref DataTable dt)
        {
            int no = 1;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                int validParaCount = Convert.ToInt32(dtTemp.Rows[i]["ValidParaCount"]);
                for (int j = 0; j < validParaCount; j++)
                {
                    DataRow dr = dt.NewRow();
                    dr["NO"] = no++;
                    dr["RowHandle"] = i.ToString();
                    dr["LineNO"] = dtTemp.Rows[i]["LineNO"];
                    dr["LineName"] = dtTemp.Rows[i]["LineName"];
                    dr["DeviceNO"] = dtTemp.Rows[i]["DeviceNO"];
                    dr["DeviceName"] = dtTemp.Rows[i]["DeviceName"];
                    dr["ParaNO"] = j + 1;
                    dr["ParaName"] = dtTemp.Rows[i]["Para" + (j + 1).ToString() + "Name"];
                    dr["ParaSuffix"] = dtTemp.Rows[i]["Para" + (j + 1).ToString() + "Suffix"];
                    dr["LowerLimit"] = dtTemp.Rows[i]["Para" + (j + 1).ToString() + "Min"].ToString() + dr["ParaSuffix"].ToString();
                    dr["UpperLimit"] = dtTemp.Rows[i]["Para" + (j + 1).ToString() + "Max"].ToString() + dr["ParaSuffix"].ToString();
                    dt.Rows.Add(dr);
                }
            }
        }

        public static void _init_dtDeviceInfoThresholdGridShow()
        {
            _init_dtDeviceInfoThresholdGridShowTemp();

            if (dtDeviceInfoThresholdGridShow.Columns.Count == 0)
            {
                dtDeviceInfoThresholdGridShow.Columns.Add("NO");
                dtDeviceInfoThresholdGridShow.Columns.Add("RowHandle");
                dtDeviceInfoThresholdGridShow.Columns.Add("LineNO");    //有些grid用不到的col也可以放到dt中，虽然不显示，但是可以方便数据的处理，不再需要查表
                dtDeviceInfoThresholdGridShow.Columns.Add("LineName");
                dtDeviceInfoThresholdGridShow.Columns.Add("DeviceNO");
                dtDeviceInfoThresholdGridShow.Columns.Add("DeviceName");
                dtDeviceInfoThresholdGridShow.Columns.Add("ParaNO");
                dtDeviceInfoThresholdGridShow.Columns.Add("ParaName");
                dtDeviceInfoThresholdGridShow.Columns.Add("ParaSuffix");
                dtDeviceInfoThresholdGridShow.Columns.Add("UpperLimit");
                dtDeviceInfoThresholdGridShow.Columns.Add("LowerLimit");
            }
            transformDtDeviceInfoThresholdGridTemp(ref dtDeviceInfoThresholdGridShowTemp, ref dtDeviceInfoThresholdGridShow);
        }

        /*************************************************************************************************************/

        //DeviceAdditionDeletion
        public static DataTable dtDeviceCanDeleteEachLine = new DataTable();
        public static void initDtDeviceCanDeleteEachLine()
        {
            if (Global.dtDeviceCanDeleteEachLine.Columns.Count == 0)
            {
                dtDeviceCanDeleteEachLine.Columns.Add("NO");
                dtDeviceCanDeleteEachLine.Columns.Add("LineNO");
                dtDeviceCanDeleteEachLine.Columns.Add("LineName");
                dtDeviceCanDeleteEachLine.Columns.Add("DeviceNO");
                dtDeviceCanDeleteEachLine.Columns.Add("DeviceName");
                dtDeviceCanDeleteEachLine.Columns.Add("ValidParaCount");
                dtDeviceCanDeleteEachLine.Columns.Add("DeviceFaultsCount");
                dtDeviceCanDeleteEachLine.Columns.Add("DeviceFaultsEnableCount");
            }
        }


        public static DataTable dtDeviceCanAddEachLine = new DataTable();
        public static void initDtDeviceCanAddEachLine()
        {
            if (Global.dtDeviceCanAddEachLine.Columns.Count == 0)
            {
                dtDeviceCanAddEachLine.Columns.Add("NO");
                dtDeviceCanAddEachLine.Columns.Add("DeviceNO");
                dtDeviceCanAddEachLine.Columns.Add("DeviceName");
            }
        }

        public static DataTable dtMachineCanSelectEachDevice = new DataTable();
        public static void initDtMachineCanSelectEachDevice()
        {
            if (Global.dtMachineCanSelectEachDevice.Columns.Count == 0)
            {
                dtMachineCanSelectEachDevice.Columns.Add("NO");
                dtMachineCanSelectEachDevice.Columns.Add("MachineNO");
                dtMachineCanSelectEachDevice.Columns.Add("MachineName");
                dtMachineCanSelectEachDevice.Columns.Add("LocationX");
                dtMachineCanSelectEachDevice.Columns.Add("LocationY");
            }
        }

        public static bool ifDeviceAdditionOrDeletion = false;  //设备是否发生了增删
        /*************************************************************************************************************/

        //productionLineAdditionDeletion
        public static DataTable dtProductionLineSystemConfig = new DataTable();

        public static void initDtProductionLineExists()
        {
            dtProductionLineSystemConfig = dtSideTileBar;
            Global.reorderDt(ref Global.dtProductionLineSystemConfig);
        }

        public static bool ifLineAdditionOrDeletion = false;    //产线是否发生了增删

        /*************************************************************************************************************/

        //获取Excel单元格数据
        public static object getCellValue(ICell cell)
        {
            object value = null;
            try
            {
                if (cell.CellType != CellType.Blank)
                {
                    switch (cell.CellType)
                    {
                        case CellType.Numeric:
                            //判断单元格内数据是否是DateTime
                            if (DateUtil.IsCellDateFormatted(cell))
                            {
                                value = cell.DateCellValue;	//若是日期格式，则用DateCellValue获取DateTime
                            }
                            else
                            {
                                // Numeric type
                                value = cell.NumericCellValue;
                            }
                            break;
                        case CellType.Boolean:
                            // Boolean type
                            value = cell.BooleanCellValue;
                            break;
                        case CellType.Formula:
                            value = cell.CellFormula;
                            break;
                        default:
                            // String type
                            value = cell.StringCellValue;
                            break;
                    }
                }
            }
            catch (Exception)
            {
                value = "";
            }

            return value;
        }

        /*************************************************************************************************************/

        //获取表的所有字段名
        public static string[] GetColumnsByDataTable(DataTable dt)
        {
            if (dt != null)
            {
                string[] strColumns = null;
                if (dt.Columns.Count > 0)
                {
                    int columnNum = 0;
                    columnNum = dt.Columns.Count;
                    strColumns = new string[columnNum];
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        strColumns[i] = dt.Columns[i].ColumnName;
                    }
                }
                return strColumns;
            }
            else
            {
                return null;
            }
        }

        /*************************************************************************************************************/

        //grid中显示的数据的NO重新排序/填充，不按照数据库中NO的数值显示
        public static void reorderDt(ref DataTable dt)
        {
            int lenDt = dt.Rows.Count;
            for (int i = 0; i < lenDt; i++)
            {
                dt.Rows[i]["NO"] = (i + 1).ToString();
            }
        }
        /*************************************************************************************************************/
        //生成表中按未使用的按数字顺序的第一个NO
        //private string createNO(ref DataTable dt, string col)
        //{
        //    string lNO = String.Empty;
        //    List<string> ll = new List<string>();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ll.Add(dt.Rows[i]["LineNO"].ToString());
        //    }

        //    for (int i = 0; i < 999; i++)
        //    {
        //        if (ll.Contains(lineNOVec[i]) == false)
        //        {
        //            lNO = lineNOVec[i];
        //            break;
        //        }
        //    }
        //    return lNO;
        //}



        /***************************************************************************************************************/

        //通过产线LineNO获取LineName
        public static string _getProductionLineNameByTag(string LineNO)
        {
            //dtProductionLine中没有Tag==0的记录
            if (LineNO == "000")
            {
                return "总览";
            }

            string temp = "LineNO=" + "'" + LineNO + "'";
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

        /*************************************************************************************************************/

        //通过设备DeviceNO获取DeviceName
        public static string _getTestingDeviceNameByTag(string DeviceNO)
        {
            if (DeviceNO == "000")
            {
                return "所有设备";
            }

            string temp = "DeviceNO=" + "'" + DeviceNO + "'";
            DataRow[] rowTD = Global.dtTestingDeviceName.Select(temp);
            if (rowTD.Length == 1)
            {
                return (string)rowTD[0]["DeviceName"];
            }
            else
            {
                return "设备名称查询错误...";
            }
        }

        /***************************************************************************************************************/
        public static Int32 SetBitValueInt32(Int32 value, ushort index, bool bitValue)
        {
            if (index > 31) throw new ArgumentOutOfRangeException("index"); //索引超出范围
            var val = 1 << index;
            return bitValue ? (value | val) : (value & ~val);   //1和0/1位或都是1,0和0/1位与都是0
        }

        public static Int64 SetBitValueInt64(Int64 value, ushort index, bool bitValue)
        {
            if (index > 60) throw new ArgumentOutOfRangeException("index"); //索引超出范围
            var val = 1 << index;
            return bitValue ? (value | val) : (value & ~val);   //1和0/1位或都是1,0和0/1位与都是0
        }

        //位为1返回true
        public static bool GetBitValueInt32(Int32 value, ushort index)
        {
            if (index > 31) throw new ArgumentOutOfRangeException("index"); //索引出错
            var val = 1 << index;
            return (value & val) == val;
        }

        public static bool GetBitValueInt64(Int64 value, ushort index)
        {
            if (index > 60) throw new ArgumentOutOfRangeException("index"); //索引出错
            var val = 1 << index;
            return (value & val) == val;
        }
        /***************************************************************************************************************/



    }
}
