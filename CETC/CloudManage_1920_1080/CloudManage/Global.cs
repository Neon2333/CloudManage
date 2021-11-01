using System;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace CloudManage
{
    class Global
    {
        public static void initDataTable()
        {
            Global._init_dtTestingDeviceName(); //初始化检测设备名称表
            Global._init_dtProductionLine();    //初始化产线名称表
            Global._init_dtFaults();         //初始化故障名称表
            Global._init_dtDeviceConfig();      //初始化检测设备使能表
            Global._init_dtFaultHistoryQuery(); //初始化标题栏故障表
            Global._init_dtSideTileBarWorkState();  //WorkState侧边栏初始化表

        }
        /*
         * MySQL表格：
         * device_config(dtDeviceConfig)——各产线的检测设备使能表：产线ID、检测设备使能标志
         * productionline(dtProductionLine)——产线名称表：产线ID、产线名称
         * device(dtTestingDeviceName)——检测设备名称表：检测设备ID、检测设备名称
         * faults(dtFaults)——各检测设备的所有故障名称表：检测设备ID、故障ID、故障名称、故障使能标志
         * faults_config——各产线对应设备的故障使能：产线ID、检测设备ID、故障ID、使能标志
         * faults_time——所有故障的发生时间：产线ID、设备ID、故障ID、故障时间
         * device_info——WorkState中各个产线对应检测设备的参数：检测设备ID、检测设备名称、检测设备状态（是否故障）、检测数、缺陷数、CPU温度、CPU利用率、内存利用率
         * 
         * 临时表，由查询得到：
         * dtSideTileBar（）——初始化侧边栏产线按钮的表：产线ID、产线名称、产线对应检测设备数量（由）
         * dtOverviewWorkState——WorkState中总览显示用表：产线名称、产线状态（是否故障）
         * dtEachProductionLineWorkState——WorkState中每条产线数据显示表
         * dtTitleGridShowMainForm——标题栏显示所有故障的最新若干条记录（由device_info得到）
         * dtHistoryQueryGridShow（faults_time）——HistoryQuery初始显示的所有故障：NO、产线名称、检测设备名称、故障名称、故障发生时间
         * dtHistoryQueryGridShowClickedQueryButton——HistoryQuery查询出来的故障
         * dtRightSideRealTimeData——RealTimeData中右侧显示表：参数名称、参数值
         * 
         * 
         * */


        public static DataTable dtDeviceConfig = new DataTable();         //产线Tag、检测设备使能标志

        public static DataTable dtProductionLine = new DataTable();       //产线Tag、产线名称（text）

        public static DataTable dtTestingDeviceName = new DataTable();    //检测设备ID、检测设备名称

        public static DataTable dtFaults = new DataTable();            //序号、检测设备ID、故障ID、故障名称、故障使能标志

        //从MySQL中查询数据初始化表
        public static bool _initDtMySQL(ref DataTable dt, string cmdDt)
        {
            MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            bool flag = mysqlHelper1._connectMySQL();
            mysqlHelper1._queryTableMySQL(cmdDt, ref dt);
            mysqlHelper1.conn.Close();
            return flag;
        }

        //初始化检测设备使能表
        public static void _init_dtDeviceConfig()
        {
            string cmdInitDtDeviceConfig = "SELECT * FROM device_config";
            _initDtMySQL(ref Global.dtDeviceConfig, cmdInitDtDeviceConfig);
        }

        //初始化产线名称表
        public static void _init_dtProductionLine()
        {
            string cmdInitDtDeviceConfig = "SELECT * FROM productionline";
            _initDtMySQL(ref Global.dtProductionLine, cmdInitDtDeviceConfig);
        }

        //初始化检测设备名称表
        public static void _init_dtTestingDeviceName()
        {
            string cmdInitDtDeviceConfig = "SELECT * FROM device";
            _initDtMySQL(ref Global.dtTestingDeviceName, cmdInitDtDeviceConfig);
        }

        //初始化故障表
        public static void _init_dtFaults()
        {
            string cmdInitDtDeviceConfig = "SELECT * FROM faults";
            _initDtMySQL(ref Global.dtFaults, cmdInitDtDeviceConfig);
        }

        /**********************************************************************************************************************************************/
        //共有
        public static DataTable dtSideTileBar = new DataTable();   //WorkState和HistoryQuery侧边栏菜单初始化表
        public static void _init_dtSideTileBarWorkState()
        {
            string cmdGetDeviceNO = "SELECT +`DeviceNO` FROM device";
            DataTable dtDeviceNOTemp = new DataTable();
            _initDtMySQL(ref dtDeviceNOTemp, cmdGetDeviceNO);
            string strT1 = "SELECT LineNo, DeviceStatus_" + dtDeviceNOTemp.Rows[0]["DeviceNO"].ToString();
            int rowNumDtdeviceNOTemp = dtDeviceNOTemp.Rows.Count;
            for (int i = 1; i < rowNumDtdeviceNOTemp; i++)
            {
                strT1 += "+DeviceStatus_" + dtDeviceNOTemp.Rows[i]["DeviceNO"].ToString();
            }
            strT1 += " AS DeviceTotalNum FROM device_config";
            string cmdInitDtDeviceConfig = "SELECT t1.LineNO,t2.LineName,t1.DeviceTotalNum " +
                                           "FROM (" + strT1 + ")AS t1 " +
                                           "INNER JOIN productionline AS t2 " +
                                           "ON t1.LineNO=t2.LineNO;";
            _initDtMySQL(ref Global.dtSideTileBar, cmdInitDtDeviceConfig);  //数据库查询时直接将"1"和"0"相加，导致dtSideTileBar中存储的DeviceTotalNum的类型是object(double)
        }

        /**********************************************************************************************************************************************/
        //MainForm
        public static DataTable dtTitleGridShowMainForm = new DataTable();    //主菜单标题表

        //初始化标题栏故障表
        public static void _init_dtFaultHistoryQuery()
        {
            if (dtTitleGridShowMainForm.Rows.Count == 0)
            {
                Global.dtTitleGridShowMainForm.Columns.Add("NO", typeof(String));
                Global.dtTitleGridShowMainForm.Columns.Add("LineName", typeof(String));
                Global.dtTitleGridShowMainForm.Columns.Add("DeviceName", typeof(String));
                Global.dtTitleGridShowMainForm.Columns.Add("FaultName", typeof(String));
                Global.dtTitleGridShowMainForm.Columns.Add("FaultTime", typeof(String));
            }
        }

        /**********************************************************************************************************************************************/
        //WorkStateControl
        public static DataTable dtOverviewWorkState = new DataTable();      //总览数据表

        public static DataTable dtEachProductionLineWorkState = new DataTable();    //每台产线的检测设备的数据

        //初始化WorkState总览表——产线Tag，产线Text（产线名称，查产线名称），产线中检测设备数num（检测设备使能）
        public static void _init_dtOverviewWorkState()
        {
            if (dtOverviewWorkState.Rows.Count == 0)
            {
                string cmdInitDTOverviewWorkState = "SELECT LineName, " +
                                                    "(CASE WHEN COUNT(FaultTime)>0 THEN '异常' " +
                                                    "WHEN COUNT(FaultTime)=0 THEN '正常' " +
                                                    "END) AS LineStatus " +
                                                    "FROM productionline AS t1 LEFT JOIN faults_time AS t2 " +
                                                    "ON t1.LineNO=t2.LineNO " +
                                                    "GROUP BY LineName " +
                                                    "ORDER BY t1.`NO`;";

                Global.dtOverviewWorkState.Columns.Add("LineName", typeof(String));     //先定义表头也可填充，表头不会填充两次
                Global.dtOverviewWorkState.Columns.Add("LineStatus", typeof(String));
                Global.dtOverviewWorkState.Columns.Add("DeviceImgTop", typeof(Image));
                Global.dtOverviewWorkState.Columns.Add("DeviceImgBottom", typeof(Image));
                _initDtMySQL(ref dtOverviewWorkState, cmdInitDTOverviewWorkState);
                
                int totalDeviceNum = dtOverviewWorkState.Rows.Count;
                int undefineTileNum = 0;
                if(totalDeviceNum <= 24)
                {
                    undefineTileNum = 24 - totalDeviceNum;
                }
                else if(totalDeviceNum > 24 && totalDeviceNum <= 48)
                {
                    undefineTileNum = 48 - totalDeviceNum;
                }
                else if(totalDeviceNum > 48 && totalDeviceNum <= 72)
                {
                    undefineTileNum = 72 - totalDeviceNum;
                }
                else if(totalDeviceNum > 72 && totalDeviceNum <= 96)
                {
                    undefineTileNum = 96 - totalDeviceNum;
                }

                //添加“未定义”Tile
                for (int i = 0; i < undefineTileNum; i++)
                {
                    DataRow dr = Global.dtOverviewWorkState.NewRow();
                    dr["LineName"] = "\\";
                    dr["LineStatus"] = "未定义";
                    dtOverviewWorkState.Rows.Add(dr);
                }

                DataRow drTemp = null;
                for(int i = 0; i < (totalDeviceNum + undefineTileNum); i++)
                {
                    drTemp = dtOverviewWorkState.Rows[i];
                    drTemp["deviceImgTop"]= global::CloudManage.Properties.Resources.ZJ17_PROTOS70_336x140; ;
                    drTemp["deviceImgBottom"]= global::CloudManage.Properties.Resources.ZB45_336x140;
                }
            }
        }

        public static void _init_dtEachProductionLineWorkState(string selectedItemTag)
        {
            if (dtEachProductionLineWorkState.Rows.Count == 0)
            {
                string cmdInitDtEachProductionLineWorkState = "SELECT t1.DeviceNO,t2.DeviceName, " +
                                                              "(CASE WHEN t1.DeviceStatus=1 THEN '正常' " +
                                                              "WHEN t1.DeviceStatus=0 THEN '异常' " +
                                                              "WHEN t1.DeviceStatus=-1 THEN '无效' " +
                                                              "END) AS DeviceStatus," +
                                                              "t1.TestingNum,t1.DefectNum, " +
                                                              "CONCAT(t1.CPUTemperature,'℃') AS CPUTemperature,CONCAT(t1.CPUUsage,'%') AS CPUUsage,CONCAT(t1.MemoryUsage,'%') AS MemoryUsage " +
                                                              "FROM device_info AS t1 INNER JOIN device AS t2 " +
                                                              "ON t1.DeviceNO=t2.DeviceNO " +
                                                              "WHERE t1.LineNO=" + selectedItemTag +
                                                              " ORDER BY t1.`NO`;";
                
                if (dtEachProductionLineWorkState.Columns.Count == 0)
                {
                    Global.dtEachProductionLineWorkState.Columns.Add("DeviceNO", typeof(String));
                    Global.dtEachProductionLineWorkState.Columns.Add("DeviceName", typeof(String));
                    Global.dtEachProductionLineWorkState.Columns.Add("DeviceStatus", typeof(String));
                    Global.dtEachProductionLineWorkState.Columns.Add("TestingNum", typeof(String));
                    Global.dtEachProductionLineWorkState.Columns.Add("DefectNum", typeof(String));
                    Global.dtEachProductionLineWorkState.Columns.Add("CPUTemperature", typeof(String));
                    Global.dtEachProductionLineWorkState.Columns.Add("CPUUsage", typeof(String));
                    Global.dtEachProductionLineWorkState.Columns.Add("MemoryUsage", typeof(String));
                    Global.dtEachProductionLineWorkState.Columns.Add("DeviceImg", typeof(Image));
                }

                _initDtMySQL(ref dtEachProductionLineWorkState, cmdInitDtEachProductionLineWorkState);

                for(int i=0;i< Global.dtEachProductionLineWorkState.Rows.Count; i++)
                {
                    if (dtEachProductionLineWorkState.Rows[i]["DeviceStatus"].ToString() == "无效")
                    {
                        dtEachProductionLineWorkState.Rows[i]["TestingNum"] = "\\";
                        dtEachProductionLineWorkState.Rows[i]["DefectNum"] = "\\";
                        dtEachProductionLineWorkState.Rows[i]["CPUTemperature"] = "\\";
                        dtEachProductionLineWorkState.Rows[i]["CPUUsage"] = "\\";
                        dtEachProductionLineWorkState.Rows[i]["MemoryUsage"] = "\\";
                        dtEachProductionLineWorkState.Rows[i]["DeviceImg"] = null;
                    }
                    else
                    {
                        switch (dtEachProductionLineWorkState.Rows[i]["DeviceNO"])    //更换检测设备图片
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
                        }
                    }
                }

            }
        }

        /**********************************************************************************************************************************************/
        //HistoryQueryControl

        public static DataTable dtHistoryQueryGridShow = new DataTable();        //grid初始化显示，所有故障与发生时间

        public static DataTable dtHistoryQueryGridShowClickedQueryButton = new DataTable();   //查询出来的故障表
        public static string excelPath_historyQueryGridShowClickedQueryButton = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\dtGridShowClickedQueryButtonHistoryQuery.xlsx";

        public static void _init_dtHistoryQueryGridShow()
        {
            string cmdInitDtDeviceConfig =  "SELECT t1.`NO`,t2.LineName,t3.DeviceName,t4.FaultName,t1.FaultTime " +
                                            "FROM faults_time AS t1 " +
                                            "INNER JOIN productionline AS t2 " +
                                            "INNER JOIN device AS t3 " +
                                            "INNER JOIN faults AS t4 " +
                                            "ON t1.LineNO=t2.LineNO " +
                                            "AND t1.DeviceNO=t3.DeviceNO " +
                                            "AND t1.DeviceNO=t4.DeviceNO " +
                                            "AND t1.FaultNO=t4.FaultNO " +
                                            "ORDER BY t1.`NO`;";
            _initDtMySQL(ref Global.dtHistoryQueryGridShow, cmdInitDtDeviceConfig);
        }

        public static void _init_dtHistoryQueryGridShowClickedQueryButton()
        {
            if (dtHistoryQueryGridShowClickedQueryButton.Rows.Count == 0)
            {
                Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("NO", typeof(String));
                Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("LineName", typeof(String));
                Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("DeviceName", typeof(String));
                Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("FaultName", typeof(String));
                Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("FaultTime", typeof(String));

                FileStream fsFaultDataTimeQuery = File.OpenRead(excelPath_historyQueryGridShowClickedQueryButton);
                IWorkbook workbookFaultDataTimeQuery = null;
                workbookFaultDataTimeQuery = new XSSFWorkbook(fsFaultDataTimeQuery);
                ISheet sheetFaultDataTimeQuery = workbookFaultDataTimeQuery.GetSheetAt(0);
                int totalRowsFaultDataTimeQuery = sheetFaultDataTimeQuery.LastRowNum + 1;
                IRow rowFaultDataTimeQuery = null;

                //DateTime faultOccurTemp;
                for (int i = 1; i < totalRowsFaultDataTimeQuery; i++)
                {
                    rowFaultDataTimeQuery = sheetFaultDataTimeQuery.GetRow(i);
                    ICell cellFaultDataTimeQuery0 = rowFaultDataTimeQuery.GetCell(0);
                    ICell cellFaultDataTimeQuery1 = rowFaultDataTimeQuery.GetCell(1);
                    ICell cellFaultDataTimeQuery2 = rowFaultDataTimeQuery.GetCell(2);
                    ICell cellFaultDataTimeQuery3 = rowFaultDataTimeQuery.GetCell(3);
                    ICell cellFaultDataTimeQuery4 = rowFaultDataTimeQuery.GetCell(4);

                    string numFaultDataTimeQuery = Convert.ToString(getCellValue(cellFaultDataTimeQuery0));
                    string nameProductionLineFaultDataTime = Convert.ToString(getCellValue(cellFaultDataTimeQuery1));
                    string nameTestingDeviceFaultDataTime = Convert.ToString(getCellValue(cellFaultDataTimeQuery2));
                    string nameFaultFaultDataTime = Convert.ToString(getCellValue(cellFaultDataTimeQuery3));
                    DateTime tempTimeFaultOccurFaultDataTime = Convert.ToDateTime(getCellValue(cellFaultDataTimeQuery4));
                    string timeFaultOccurFaultDataTime = tempTimeFaultOccurFaultDataTime.ToString("yyyy-MM-dd HH:mm:ss");

                    DataRow drFaultDataTimeQuery = Global.dtHistoryQueryGridShowClickedQueryButton.NewRow();
                    drFaultDataTimeQuery["NO"] = numFaultDataTimeQuery;
                    drFaultDataTimeQuery["LineName"] = nameProductionLineFaultDataTime;
                    drFaultDataTimeQuery["DeviceName"] = nameTestingDeviceFaultDataTime;
                    drFaultDataTimeQuery["FaultName"] = nameFaultFaultDataTime;
                    drFaultDataTimeQuery["FaultTime"] = timeFaultOccurFaultDataTime;

                    Global.dtHistoryQueryGridShowClickedQueryButton.Rows.Add(drFaultDataTimeQuery);
                }
                fsFaultDataTimeQuery.Close();
            }
        }

        /*************************************************************************************************************/

        //RealTimeDataControl
        public static DataTable dtRightSideRealTimeData = new DataTable();

        public static void _init_dtRightSideRealTimeData()
        {
            if (Global.dtRightSideRealTimeData.Rows.Count == 0)
            {
                Global.dtRightSideRealTimeData.Columns.Add("paraName", typeof(String));
                Global.dtRightSideRealTimeData.Columns.Add("paraVal", typeof(String));

                DataRow drRightSide1 = Global.dtRightSideRealTimeData.NewRow();
                drRightSide1["paraName"] = "检测数量";
                drRightSide1["paraVal"] = "533";
                Global.dtRightSideRealTimeData.Rows.Add(drRightSide1);

                DataRow drRightSide2 = Global.dtRightSideRealTimeData.NewRow();
                drRightSide2["paraName"] = "缺陷数量";
                drRightSide2["paraVal"] = "55";
                Global.dtRightSideRealTimeData.Rows.Add(drRightSide2);

                DataRow drRightSide3 = Global.dtRightSideRealTimeData.NewRow();
                drRightSide3["paraName"] = "处理时间";
                drRightSide3["paraVal"] = "20" + "ms";
                Global.dtRightSideRealTimeData.Rows.Add(drRightSide3);

                DataRow drRightSide4 = Global.dtRightSideRealTimeData.NewRow();
                drRightSide4["paraName"] = "CPU温度";
                drRightSide4["paraVal"] = "60" + "℃";
                Global.dtRightSideRealTimeData.Rows.Add(drRightSide4);

                DataRow drRightSide5 = Global.dtRightSideRealTimeData.NewRow();
                drRightSide5["paraName"] = "CPU利用率";
                drRightSide5["paraVal"] = "40" + "%";
                Global.dtRightSideRealTimeData.Rows.Add(drRightSide5);

                DataRow drRightSide6 = Global.dtRightSideRealTimeData.NewRow();
                drRightSide6["paraName"] = "内存利用率";
                drRightSide6["paraVal"] = "20".ToString() + "%";
                Global.dtRightSideRealTimeData.Rows.Add(drRightSide6);
            }
        }



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



    }   
}
