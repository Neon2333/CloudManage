using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Collections;
using System.IO;
using System.Drawing;

namespace CloudManage
{
    class Global
    {
        /*
         * 表格说明：
         * dtDeviceConfig——各产线的检测设备使能表：产线ID、检测设备使能标志
         * dtProductionLine——产线名称表：产线ID、产线名称
         * dtTestingDeviceName——检测设备名称表：检测设备ID、检测设备名称
         * dtAllFaults——各检测设备的所有故障名称表：检测设备ID、故障ID、故障名称、故障使能标志
         * dtHistoryQueryGridShow——HistoryQuery初始显示的所有故障：NO、产线名称、检测设备名称、故障名称、故障发生时间
         * 
         * 临时表，由查询得到：
         * dtSideTileBar——初始化侧边栏产线按钮的表：产线ID、产线名称、产线对应检测设备数量（由）
         * dtTitleGridShowMainForm——标题栏显示所有故障的最新若干条记录（由dtHistoryQueryGridShow得到）
         * dtOverviewWorkState——WorkState中总览显示用表：产线名称、产线状态（是否故障）
         * dtEachProductionLineWorkState——WorkState中各个产线对应检测设备的参数：检测设备ID、检测设备名称、检测设备状态（是否故障）、检测数、缺陷数、CPU温度、CPU利用率、内存利用率
         * dtHistoryQueryGridShowClickedQueryButton——HistoryQuery查询出来的故障（由产线ID、检测设备ID、时间段从dtHistoryQueryGridShow查询出来）
         * dtRightSideRealTimeData——RealTimeData中右侧显示表：参数名称、参数值
         * 
         * 
         * */

        public static DataTable dtDeviceConfig = new DataTable();         //产线Tag、检测设备使能标志
        public static string excelPath_deviceConfig = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\deviceConfig.xlsx";

        public static DataTable dtProductionLine = new DataTable();       //产线Tag、产线名称（text）
        public static string excelPath_productionLineName = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\productionLineName.xlsx";

        public static DataTable dtTestingDeviceName = new DataTable();    //检测设备ID、检测设备名称
        public static string excelPath_testingDeviceName = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\testingDeviceName.xlsx";

        public static DataTable dtAllFaults = new DataTable();            //序号、检测设备ID、故障ID、故障名称、故障使能标志
        public static string excelPath_allFaults = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\allFaults.xlsx";

        //初始化检测设备使能表
        public static void _init_dtDeviceConfig()
        {
            if (dtDeviceConfig.Rows.Count == 0)
            {
                //读各车设备使能标志表
                Global.dtDeviceConfig.Columns.Add("LineNO", typeof(String));
                Global.dtDeviceConfig.Columns.Add("DeviceState_001", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_002", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_003", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_004", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_005", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_006", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_007", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_008", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_009", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_010", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_011", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_012", typeof(int));
                Global.dtDeviceConfig.Columns.Add("DeviceState_013", typeof(int));

                FileStream fs = File.OpenRead(excelPath_deviceConfig);    //关联流打开文件
                IWorkbook workbook = null;
                workbook = new XSSFWorkbook(fs);    //XSSF打开xlsx
                ISheet sheet = null;
                sheet = workbook.GetSheetAt(0); //获取第1个sheet
                int totalRows = sheet.LastRowNum + 1;
                IRow row = null;
                for (int i = 1; i < totalRows; i++)
                {
                    row = sheet.GetRow(i);
                    ICell cellLineNO = row.GetCell(0);
                    ICell cellDeviceState_001 = row.GetCell(1);
                    ICell cellDeviceState_002 = row.GetCell(2);
                    ICell cellDeviceState_003 = row.GetCell(3);
                    ICell cellDeviceState_004 = row.GetCell(4);
                    ICell cellDeviceState_005 = row.GetCell(5);
                    ICell cellDeviceState_006 = row.GetCell(6);
                    ICell cellDeviceState_007 = row.GetCell(7);
                    ICell cellDeviceState_008 = row.GetCell(8);
                    ICell cellDeviceState_009 = row.GetCell(9);
                    ICell cellDeviceState_010 = row.GetCell(10);
                    ICell cellDeviceState_011 = row.GetCell(11);
                    ICell cellDeviceState_012 = row.GetCell(12);
                    ICell cellDeviceState_013 = row.GetCell(13);

                    cellLineNO.SetCellType(CellType.String);
                    cellDeviceState_001.SetCellType(CellType.String);
                    cellDeviceState_002.SetCellType(CellType.String);
                    cellDeviceState_003.SetCellType(CellType.String);
                    cellDeviceState_004.SetCellType(CellType.String);
                    cellDeviceState_005.SetCellType(CellType.String);
                    cellDeviceState_006.SetCellType(CellType.String);
                    cellDeviceState_007.SetCellType(CellType.String);
                    cellDeviceState_008.SetCellType(CellType.String);
                    cellDeviceState_009.SetCellType(CellType.String);
                    cellDeviceState_010.SetCellType(CellType.String);
                    cellDeviceState_011.SetCellType(CellType.String);
                    cellDeviceState_012.SetCellType(CellType.String);
                    cellDeviceState_013.SetCellType(CellType.String);

                    string tempLineNO = (string)Global.getCellValue(cellLineNO);
                    string tempDeviceState_001 = (string)Global.getCellValue(cellDeviceState_001);
                    string tempDeviceState_002 = (string)Global.getCellValue(cellDeviceState_002);
                    string tempDeviceState_003 = (string)Global.getCellValue(cellDeviceState_003);
                    string tempDeviceState_004 = (string)Global.getCellValue(cellDeviceState_004);
                    string tempDeviceState_005 = (string)Global.getCellValue(cellDeviceState_005);
                    string tempDeviceState_006 = (string)Global.getCellValue(cellDeviceState_006);
                    string tempDeviceState_007 = (string)Global.getCellValue(cellDeviceState_007);
                    string tempDeviceState_008 = (string)Global.getCellValue(cellDeviceState_008);
                    string tempDeviceState_009 = (string)Global.getCellValue(cellDeviceState_009);
                    string tempDeviceState_010 = (string)Global.getCellValue(cellDeviceState_010);
                    string tempDeviceState_011 = (string)Global.getCellValue(cellDeviceState_011);
                    string tempDeviceState_012 = (string)Global.getCellValue(cellDeviceState_012);
                    string tempDeviceState_013 = (string)Global.getCellValue(cellDeviceState_013);

                    DataRow dr = Global.dtDeviceConfig.NewRow();
                    dr["LineNO"] = tempLineNO;
                    dr["DeviceState_001"] = tempDeviceState_001;
                    dr["DeviceState_002"] = tempDeviceState_002;
                    dr["DeviceState_003"] = tempDeviceState_003;
                    dr["DeviceState_004"] = tempDeviceState_004;
                    dr["DeviceState_005"] = tempDeviceState_005;
                    dr["DeviceState_006"] = tempDeviceState_006;
                    dr["DeviceState_007"] = tempDeviceState_007;
                    dr["DeviceState_008"] = tempDeviceState_008;
                    dr["DeviceState_009"] = tempDeviceState_009;
                    dr["DeviceState_010"] = tempDeviceState_010;
                    dr["DeviceState_011"] = tempDeviceState_011;
                    dr["DeviceState_012"] = tempDeviceState_012;
                    dr["DeviceState_013"] = tempDeviceState_013;
                    Global.dtDeviceConfig.Rows.Add(dr);
                }
                fs.Close();
            }
        }

        //初始化产线名称表
        public static void _init_dtProductionLine()
        {
            if (dtProductionLine.Rows.Count == 0)
            {
                Global.dtProductionLine.Columns.Add("LineNO", typeof(String));
                Global.dtProductionLine.Columns.Add("LineName", typeof(String));

                FileStream fsProductionLine = File.OpenRead(Global.excelPath_productionLineName);
                IWorkbook workbookProductionLine = null;
                workbookProductionLine = new XSSFWorkbook(fsProductionLine);
                ISheet sheetProductionLine = null;
                sheetProductionLine = workbookProductionLine.GetSheetAt(0);
                int totalRowsProductionLine = sheetProductionLine.LastRowNum + 1;
                IRow rowProductionLine = null;

                for (int i = 1; i < totalRowsProductionLine; i++)
                {
                    rowProductionLine = sheetProductionLine.GetRow(i);
                    ICell cell0 = rowProductionLine.GetCell(0);
                    ICell cell1 = rowProductionLine.GetCell(1);

                    string tagProductionLine = Convert.ToString(getCellValue(cell0));
                    string nameProductionLine = Convert.ToString(getCellValue(cell1));
                    DataRow drProductionLine = Global.dtProductionLine.NewRow();
                    drProductionLine["LineNO"] = tagProductionLine;
                    drProductionLine["LineName"] = nameProductionLine;

                    Global.dtProductionLine.Rows.Add(drProductionLine);
                }
                fsProductionLine.Close();
            }
        }

        //初始化检测设备名称表
        public static void _init_dtTestingDeviceName()
        {
            if (dtTestingDeviceName.Rows.Count == 0)
            {
                Global.dtTestingDeviceName.Columns.Add("DeviceNO", typeof(String));
                Global.dtTestingDeviceName.Columns.Add("DeviceName", typeof(String));

                FileStream fsTestingDeviceName = File.OpenRead(excelPath_testingDeviceName);
                IWorkbook workbookTestingDeviceName = null;
                workbookTestingDeviceName = new XSSFWorkbook(fsTestingDeviceName);
                ISheet sheetTestingDeviceName = null;
                sheetTestingDeviceName = workbookTestingDeviceName.GetSheetAt(0);
                int totalRowsTestingDeviceName = sheetTestingDeviceName.LastRowNum + 1;
                IRow rowTestingDeviceName = null;

                for (int i = 1; i < totalRowsTestingDeviceName; i++)
                {
                    rowTestingDeviceName = sheetTestingDeviceName.GetRow(i);
                    ICell cellTestingDeviceName0 = rowTestingDeviceName.GetCell(0);
                    ICell cellTestingDeviceName1 = rowTestingDeviceName.GetCell(1);

                    string tagTestingDevice = Convert.ToString(getCellValue(cellTestingDeviceName0));
                    string nameTestingDevice = Convert.ToString(getCellValue(cellTestingDeviceName1));

                    DataRow drTestingDevice = Global.dtTestingDeviceName.NewRow();
                    drTestingDevice["DeviceNO"] = tagTestingDevice;
                    drTestingDevice["DeviceName"] = nameTestingDevice;

                    Global.dtTestingDeviceName.Rows.Add(drTestingDevice);
                }
                fsTestingDeviceName.Close();
            }
        }

        //初始化故障表
        public static void _init_dtAllFaults()
        {
            if (dtAllFaults.Rows.Count == 0)
            {
                Global.dtAllFaults.Columns.Add("序号", typeof(String));
                Global.dtAllFaults.Columns.Add("检测设备ID", typeof(String));
                Global.dtAllFaults.Columns.Add("故障ID", typeof(String));
                Global.dtAllFaults.Columns.Add("故障名称", typeof(String));
                Global.dtAllFaults.Columns.Add("故障使能标志", typeof(int));

                FileStream fsFaultName = File.OpenRead(excelPath_allFaults);
                IWorkbook workbookFaultName = new XSSFWorkbook(fsFaultName);
                ISheet sheetFaultName = workbookFaultName.GetSheetAt(0);
                int totalRowsFaultName = sheetFaultName.LastRowNum + 1;
                IRow rowFaultName = null;

                for (int i = 1; i < totalRowsFaultName; i++)
                {
                    rowFaultName = sheetFaultName.GetRow(i);
                    ICell cellFaultName0 = rowFaultName.GetCell(0);
                    ICell cellFaultName1 = rowFaultName.GetCell(1);
                    ICell cellFaultName2 = rowFaultName.GetCell(2);
                    ICell cellFaultName3 = rowFaultName.GetCell(3);
                    ICell cellFaultName4 = rowFaultName.GetCell(4);


                    string numFaultName = Convert.ToString(getCellValue(cellFaultName0));
                    string tagTestingDevice = Convert.ToString(getCellValue(cellFaultName1));
                    string tagFault = Convert.ToString(getCellValue(cellFaultName2));
                    string nameFault = Convert.ToString(getCellValue(cellFaultName3));
                    int flagEnable = Convert.ToInt32(getCellValue(cellFaultName4));

                    DataRow drFaultName = Global.dtAllFaults.NewRow();
                    drFaultName["序号"] = numFaultName;
                    drFaultName["检测设备ID"] = tagTestingDevice;
                    drFaultName["故障ID"] = tagFault;
                    drFaultName["故障名称"] = nameFault;
                    drFaultName["故障使能标志"] = flagEnable;

                    Global.dtAllFaults.Rows.Add(drFaultName);
                }
                fsFaultName.Close();
            }
        }

        /**********************************************************************************************************************************************/
        //共有
        public static DataTable dtSideTileBar = new DataTable();   //WorkState和HistoryQuery侧边栏菜单初始化表
        public static string excelPath_sideTileBarWorkState = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\dtSideTileBar.xlsx";
        public static void _init_dtSideTileBarWorkState()
        {
            if (dtSideTileBar.Rows.Count == 0)
            {
                //临时表
                Global.dtSideTileBar.Columns.Add("LineNO", typeof(String));
                Global.dtSideTileBar.Columns.Add("LineName", typeof(String));
                Global.dtSideTileBar.Columns.Add("DeviceTotalNum", typeof(String));


                FileStream fs = File.OpenRead(excelPath_sideTileBarWorkState);    //关联流打开文件
                IWorkbook workbook = null;
                workbook = new XSSFWorkbook(fs);    //XSSF打开xlsx
                ISheet sheet = null;
                sheet = workbook.GetSheetAt(0); //获取第1个sheet
                int totalRows = sheet.LastRowNum + 1;
                IRow row = null;
                for (int i = 1; i < totalRows; i++)
                {
                    row = sheet.GetRow(i);  //获取第i行
                    ICell cellLineNo = row.GetCell(0);  //获取row行的第i列的数据
                    ICell cellLineName = row.GetCell(1);
                    ICell deviceTotalNum = row.GetCell(2);
                    cellLineName.SetCellType(CellType.String);  //为防止Excel自动将数字视为Double类型，造成无法强转为string，在读取cell后先将其转换为string类型
                    cellLineName.SetCellType(CellType.String);
                    deviceTotalNum.SetCellType(CellType.String);

                    string tempName = (string)Global.getCellValue(cellLineNo);
                    string tempStatus = (string)Global.getCellValue(cellLineName);
                    String tempDeviceTotalNum = (string)Global.getCellValue(deviceTotalNum);

                    DataRow dr = Global.dtSideTileBar.NewRow();
                    dr["LineNO"] = tempName;
                    dr["LineName"] = tempStatus;
                    dr["DeviceTotalNum"] = tempDeviceTotalNum;
                    Global.dtSideTileBar.Rows.Add(dr);
                }
                fs.Close();
            }
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
        public static string excelPath_overviewWorkState = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\dtOverviewWorkState.xlsx";

        public static DataTable dtEachProductionLineWorkState = new DataTable();    //每台产线的检测设备的数据
        public static string excelPath_EachProductionLineWorkState = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\dtEachProductionLineWorkState.xlsx";

        //初始化WorkState总览表——产线Tag，产线Text（产线名称，查产线名称），产线中检测设备数num（检测设备使能）
        public static void _init_dtOverviewWorkState()
        {
            if (dtOverviewWorkState.Rows.Count == 0)
            {
                //临时表
                Global.dtOverviewWorkState.Columns.Add("LineName", typeof(String));
                Global.dtOverviewWorkState.Columns.Add("LineStatus", typeof(String));
                Global.dtOverviewWorkState.Columns.Add("DeviceImgTop", typeof(Image));
                Global.dtOverviewWorkState.Columns.Add("DeviceImgBottom", typeof(Image));



                FileStream fsOverview = File.OpenRead(excelPath_overviewWorkState);    //关联流打开文件
                IWorkbook workbook = null;
                workbook = new XSSFWorkbook(fsOverview);    //XSSF打开xlsx
                ISheet sheet = null;
                sheet = workbook.GetSheetAt(0); //获取第1个sheet
                int totalRows = sheet.LastRowNum + 1;
                IRow row = null;
                for (int i = 1; i < totalRows; i++)
                {
                    row = sheet.GetRow(i);  //获取第i行
                    ICell cellName = row.GetCell(0);    //获取row行的第i列的数据
                    ICell cellStatus = row.GetCell(1);
                    cellName.SetCellType(CellType.String);
                    cellStatus.SetCellType(CellType.String);

                    string tempName = (string)Global.getCellValue(cellName);
                    string tempStatus = (string)Global.getCellValue(cellStatus);
                    DataRow dr = Global.dtOverviewWorkState.NewRow();
                    dr["LineName"] = tempName;
                    if (tempStatus == "1")
                    {
                        dr["LineStatus"] = "正常";
                    }
                    else if (tempStatus == "0")
                    {
                        dr["LineStatus"] = "异常";
                    }
                    else if (tempStatus == "-1")
                    {
                        dr["LineStatus"] = "无效";
                    }

                    dr["deviceImgTop"] = global::CloudManage.Properties.Resources.ZJ17_PROTOS70_336x140;
                    dr["deviceImgBottom"] = global::CloudManage.Properties.Resources.ZB45_336x140;

                    Global.dtOverviewWorkState.Rows.Add(dr);
                }
                fsOverview.Close();
            }
        }

        public static void _init_dtEachProductionLineWorkState()
        {
            if (dtEachProductionLineWorkState.Rows.Count == 0)
            {
                //临时表，由deviceData查询得到，将ID替换为Name
                Global.dtEachProductionLineWorkState.Columns.Add("DeviceNO", typeof(String));
                Global.dtEachProductionLineWorkState.Columns.Add("DeviceName", typeof(String));
                Global.dtEachProductionLineWorkState.Columns.Add("DeviceStatus", typeof(String));
                Global.dtEachProductionLineWorkState.Columns.Add("TestingNum", typeof(String));
                Global.dtEachProductionLineWorkState.Columns.Add("DefectNum", typeof(String));
                Global.dtEachProductionLineWorkState.Columns.Add("CPUTemperature", typeof(String));
                Global.dtEachProductionLineWorkState.Columns.Add("CPUUsage", typeof(String));
                Global.dtEachProductionLineWorkState.Columns.Add("MemoryUsage", typeof(String));
                Global.dtEachProductionLineWorkState.Columns.Add("Img", typeof(Image));
                //Global.dtEachProductionLineWorkState.Columns.Add("Shift", typeof(String));


                FileStream fs = File.OpenRead(excelPath_EachProductionLineWorkState);    //关联流打开文件
                IWorkbook workbook = null;
                workbook = new XSSFWorkbook(fs);    //XSSF打开xlsx
                ISheet sheet = null;
                sheet = workbook.GetSheetAt(0); //获取第1个sheet
                int totalRows = sheet.LastRowNum + 1;
                IRow row = null;
                for (int i = 1; i < totalRows; i++)
                {
                    row = sheet.GetRow(i);  //获取第i行
                    ICell cellDeviceNO = row.GetCell(0);
                    ICell cellDeviceName = row.GetCell(1);  //获取row行的第i列的数据
                    ICell cellDeviceStatus = row.GetCell(2);
                    ICell cellDeviceTestingNum = row.GetCell(3);
                    ICell cellDeviceDefectNum = row.GetCell(4);
                    ICell cellDeviceCPUTemperature = row.GetCell(5);
                    ICell cellDeviceCPUUsage = row.GetCell(6);
                    ICell cellDeviceMemoryUsage = row.GetCell(7);
                    //ICell cellDeviceShift = row.GetCell(8);
                    cellDeviceNO.SetCellType(CellType.String);
                    cellDeviceName.SetCellType(CellType.String);
                    cellDeviceStatus.SetCellType(CellType.String);
                    cellDeviceTestingNum.SetCellType(CellType.String);
                    cellDeviceDefectNum.SetCellType(CellType.String);
                    cellDeviceCPUTemperature.SetCellType(CellType.String);
                    cellDeviceCPUUsage.SetCellType(CellType.String);
                    cellDeviceMemoryUsage.SetCellType(CellType.String);
                    //cellDeviceShift.SetCellType(CellType.String);

                    string tempDeviceNO = (string)Global.getCellValue(cellDeviceNO);
                    string tempName = (string)Global.getCellValue(cellDeviceName);
                    string tempStatus = (string)Global.getCellValue(cellDeviceStatus);
                    string tempDeviceTestingNum = (string)Global.getCellValue(cellDeviceTestingNum);
                    string tempDeviceDefectNum = (string)Global.getCellValue(cellDeviceDefectNum);
                    string tempDeviceCPUTemperature = (string)Global.getCellValue(cellDeviceCPUTemperature);
                    string tempDeviceCPUUsage = (string)Global.getCellValue(cellDeviceCPUUsage);
                    string tempDeviceMemoryUsage = (string)Global.getCellValue(cellDeviceMemoryUsage);
                    //string tempDeviceShift = (string)Global.getCellValue(cellDeviceShift);

                    DataRow dr = Global.dtEachProductionLineWorkState.NewRow();
                    dr["DeviceNO"] = tempDeviceNO;
                    dr["DeviceName"] = tempName;
                    if (tempStatus == "1")
                    {
                        dr["DeviceStatus"] = "正常";
                    }
                    else if (tempStatus == "0")
                    {
                        dr["DeviceStatus"] = "异常";
                    }
                    else if (tempStatus == "-1")
                    {
                        dr["DeviceStatus"] = "无效";
                    }
                    dr["TestingNum"] = tempDeviceTestingNum;
                    dr["DefectNum"] = tempDeviceDefectNum;
                    dr["CPUTemperature"] = tempDeviceCPUTemperature + "℃";
                    dr["CPUUsage"] = tempDeviceCPUUsage + "%";
                    dr["MemoryUsage"] = tempDeviceMemoryUsage + "%";
                    if (tempStatus == "-1")
                    {
                        dr["Img"] = null;

                    }
                    else
                    {
                        switch (tempDeviceNO)    //检测设备图片
                        {
                            case "001":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "002":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "003":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "004":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "005":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "006":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "007":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "008":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "009":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "010":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "011":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "012":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                            case "013":
                                dr["Img"] = global::CloudManage.Properties.Resources.neichen;
                                break;
                        }
                    }
                    //dr["Shift"] = tempDeviceShift;

                    Global.dtEachProductionLineWorkState.Rows.Add(dr);
                }
                fs.Close();
            }
        }

        /**********************************************************************************************************************************************/

        //HistoryQueryControl

        public static DataTable dtHistoryQueryGridShow = new DataTable();        //grid初始化显示，所有故障与发生时间
        public static string excelPath_historyQueryGridShow = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\dtGridShowHistoryQuery.xlsx";
        
        public static DataTable dtHistoryQueryGridShowClickedQueryButton = new DataTable();   //查询出来的故障表
        public static string excelPath_historyQueryGridShowClickedQueryButton = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\dtGridShowClickedQueryButtonHistoryQuery.xlsx";

        public static void _init_dtHistoryQueryGridShow()
        {
            if (dtHistoryQueryGridShow.Rows.Count == 0)
            {
                Global.dtHistoryQueryGridShow.Columns.Add("NO", typeof(String));
                Global.dtHistoryQueryGridShow.Columns.Add("LineName", typeof(String));
                Global.dtHistoryQueryGridShow.Columns.Add("DeviceName", typeof(String));
                Global.dtHistoryQueryGridShow.Columns.Add("FaultName", typeof(String));
                Global.dtHistoryQueryGridShow.Columns.Add("FaultTime", typeof(String));

                FileStream fsFaultDataTime = File.OpenRead(excelPath_historyQueryGridShow);
                IWorkbook workbookFaultDataTime = new XSSFWorkbook(fsFaultDataTime);
                ISheet sheetFaultDataTime = workbookFaultDataTime.GetSheetAt(0);
                int totalRowsFaultDataTime = sheetFaultDataTime.LastRowNum + 1;
                IRow rowFaultDataTime = null;
                //DateTime faultOccurTemp;
                for (int i = 1; i < totalRowsFaultDataTime; i++)
                {
                    rowFaultDataTime = sheetFaultDataTime.GetRow(i);
                    ICell cellFaultDataTime0 = rowFaultDataTime.GetCell(0);
                    ICell cellFaultDataTime1 = rowFaultDataTime.GetCell(1);
                    ICell cellFaultDataTime2 = rowFaultDataTime.GetCell(2);
                    ICell cellFaultDataTime3 = rowFaultDataTime.GetCell(3);
                    ICell cellFaultDataTime4 = rowFaultDataTime.GetCell(4);

                    string numFaultDataTime = Convert.ToString(getCellValue(cellFaultDataTime0));
                    string nameProductionLineFaultDataTime = Convert.ToString(getCellValue(cellFaultDataTime1));
                    string nameTestingDeviceFaultDataTime = Convert.ToString(getCellValue(cellFaultDataTime2));
                    string nameFaultFaultDataTime = Convert.ToString(getCellValue(cellFaultDataTime3));
                    DateTime tempTimeFaultOccurFaultDataTime = Convert.ToDateTime(getCellValue(cellFaultDataTime4));
                    string timeFaultOccurFaultDataTime = tempTimeFaultOccurFaultDataTime.ToString("yyyy-MM-dd HH:mm:ss");

                    DataRow drFaultDataTime = Global.dtHistoryQueryGridShow.NewRow();
                    drFaultDataTime["NO"] = numFaultDataTime;
                    drFaultDataTime["LineName"] = nameProductionLineFaultDataTime;
                    drFaultDataTime["DeviceName"] = nameTestingDeviceFaultDataTime;
                    drFaultDataTime["FaultName"] = nameFaultFaultDataTime;
                    drFaultDataTime["FaultTime"] = timeFaultOccurFaultDataTime;

                    Global.dtHistoryQueryGridShow.Rows.Add(drFaultDataTime);
                }
                fsFaultDataTime.Close();
            }
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
