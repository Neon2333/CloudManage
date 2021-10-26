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
         * historyQueryGridShow——grid显示的表。表示已发生的所有故障。
         * historyQueryGridShowClickedQueryButton——根据车号、检测设备、时间，查出来的某些故障
         * historyQueryGridShowTest——用于测试的表。当historyQueryGridShow发生改变时显示的表
         * 
         * DTTitleGridShow——从dtHistoryQueryGridShow中提取前若干条故障（故障的使能标志为1，故障使能在表dtAllFaluts中），临时表，通过“忽略一次”按钮可删除第一条记录
         * 
         * dtAllFaults——所有车、检测设备可能发生的所有的故障的名称、使能标志（只有被使能==1的故障才能被提取到DTTitleGridShow中）
         * */

        public static DataTable dtDeviceEnable = new DataTable();         //产线Tag、检测设备使能标志
        public static string excelPath_deviceEnable = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\deviceConfig.xlsx";
        /*************************************************************************************************************/

        //MainForm
        public static DataTable dtTitleGridShowMainForm = new DataTable();    //主菜单标题表

        /*************************************************************************************************************/

        //WorkStateControl

        public static DataTable dtSideTileBarWorkState = new DataTable();   //WorkState侧边栏菜单初始化表
        public static string excelPath_sideTileBarWorkState = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\dtSideTileBarWorkState.xlsx";

        public static DataTable dtOverviewWorkState = new DataTable();      //总览数据表
        public static string excelPath_overviewWorkState = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\dtOverviewWorkState.xlsx";

        public static DataTable dtEachProductionLineWorkState = new DataTable();    //每台产线的检测设备的数据
        public static string excelPath_EachProductionLineWorkState = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\dtEachProductionLineWorkState.xlsx";


        public static void _init_dtSideTileBarWorkState()
        {
            //临时表
            Global.dtSideTileBarWorkState.Columns.Add("LineNO", typeof(String));
            Global.dtSideTileBarWorkState.Columns.Add("LineName", typeof(String));
            Global.dtSideTileBarWorkState.Columns.Add("DeviceTotalNum", typeof(String));


            FileStream fs = File.OpenRead(excelPath_sideTileBarWorkState);    //关联流打开文件
            IWorkbook workbook = null;
            workbook = new XSSFWorkbook(fs);    //XSSF打开xlsx
            ISheet sheet = null;
            sheet = workbook.GetSheetAt(0); //获取第1个sheet
            int totalRows = sheet.LastRowNum + 1;
            IRow row = null;
            for (int i = 1; i < totalRows; i++)
            {
                row = sheet.GetRow(i);	//获取第i行
                ICell cellLineNo = row.GetCell(0);	//获取row行的第i列的数据
                ICell cellLineName = row.GetCell(1);
                ICell deviceTotalNum = row.GetCell(2);
                cellLineName.SetCellType(CellType.String);  //为防止Excel自动将数字视为Double类型，造成无法强转为string，在读取cell后先将其转换为string类型
                cellLineName.SetCellType(CellType.String);
                deviceTotalNum.SetCellType(CellType.String);

                string tempName = (string)Global.getCellValue(cellLineNo);
                string tempStatus = (string)Global.getCellValue(cellLineName);
                String tempDeviceTotalNum = (string)Global.getCellValue(deviceTotalNum);

                DataRow dr = Global.dtSideTileBarWorkState.NewRow();
                dr["LineNO"] = tempName;
                dr["LineName"] = tempStatus;
                dr["DeviceTotalNum"] = tempDeviceTotalNum;
                Global.dtSideTileBarWorkState.Rows.Add(dr);
            }
            fs.Close();

        }

        //初始化WorkState总览表——产线Tag，产线Text（产线名称，查产线名称），产线中检测设备数num（检测设备使能）
        public static void _init_dtOverviewWorkState()
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
                row = sheet.GetRow(i);	//获取第i行
                ICell cellName = row.GetCell(0);	//获取row行的第i列的数据
                ICell cellStatus = row.GetCell(1);
                cellName.SetCellType(CellType.String);
                cellStatus.SetCellType(CellType.String);

                string tempName = (string)Global.getCellValue(cellName);
                string tempStatus = String.Empty;
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

        public static void _init_dtEachProductionLineWorkState()
        {
            //临时表，由deviceData查询得到，将ID替换为Name
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
                row = sheet.GetRow(i);	//获取第i行
                ICell cellDeviceName = row.GetCell(0);	//获取row行的第i列的数据
                ICell cellDeviceStatus = row.GetCell(1);
                ICell cellDeviceTestingNum = row.GetCell(2);
                ICell cellDeviceDefectNum = row.GetCell(3);
                ICell cellDeviceCPUTemperature = row.GetCell(4);
                ICell cellDeviceCPUUsage = row.GetCell(5);
                ICell cellDeviceMemoryUsage = row.GetCell(6);
                //ICell cellDeviceShift = row.GetCell(7);
                cellDeviceName.SetCellType(CellType.String);
                cellDeviceStatus.SetCellType(CellType.String);
                cellDeviceTestingNum.SetCellType(CellType.String);
                cellDeviceDefectNum.SetCellType(CellType.String);
                cellDeviceCPUTemperature.SetCellType(CellType.String);
                cellDeviceCPUUsage.SetCellType(CellType.String);
                cellDeviceMemoryUsage.SetCellType(CellType.String);
                //cellDeviceShift.SetCellType(CellType.String);

                string tempName = (string)Global.getCellValue(cellDeviceName);
                string tempStatus = (string)Global.getCellValue(cellDeviceStatus);
                string tempDeviceTestingNum = (string)Global.getCellValue(cellDeviceTestingNum);
                string tempDeviceDefectNum = (string)Global.getCellValue(cellDeviceDefectNum);
                string tempDeviceCPUTemperature= (string)Global.getCellValue(cellDeviceCPUTemperature);
                string tempDeviceCPUUsage = (string)Global.getCellValue(cellDeviceCPUUsage);
                string tempDeviceMemoryUsage = (string)Global.getCellValue(cellDeviceMemoryUsage);
                //string tempDeviceShift = (string)Global.getCellValue(cellDeviceShift);

                DataRow dr = Global.dtEachProductionLineWorkState.NewRow();
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
                dr["Img"]= global::CloudManage.Properties.Resources.ZB45_336x140;
                //dr["Shift"] = tempDeviceShift;

                Global.dtEachProductionLineWorkState.Rows.Add(dr);
            }
            fs.Close();
        }

        /*************************************************************************************************************/

        //HistoryQueryControl
        public static DataTable dtProductionLine = new DataTable();       //产线Tag、产线名称（text）
        public static string excelPath_productionLineName = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\productionLineName.xlsx";
        
        public static DataTable dtTestingDeviceName = new DataTable();    //检测设备ID、检测设备名称
        public static string excelPath_testingDeviceName = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\testingDeviceName.xlsx";
        
        public static DataTable dtAllFaults = new DataTable();            //序号、检测设备ID、故障ID、故障名称、故障使能标志
        public static string excelPath_allFaults = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\allFaults.xlsx";

        public static DataTable dtSideTileBarWithSubHistoryQuery = new DataTable(); //HistoryQuery侧边栏菜单初始化表

        public static DataTable dtSideTileBarWithSubSubHistoryQuery = new DataTable();  //HistoryQuery侧边栏子菜单初始化表

        public static DataTable dtHistoryQueryGridShow = new DataTable();        //序号、产线名称、检测设备名称、故障名称、故障发生时间。grid显示
        public static string excelPath_historyQueryGridShow = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\historyQueryGridShow.xlsx";
        
        public static DataTable dtHistoryQueryGridShowClickedQueryButton = new DataTable();   //查询出来的数据的表，该Excel用作测试用，后续用MySQL查询前面4张表，得出该表
        public static string excelPath_historyQueryGridShowClickedQueryButton = @"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\historyQueryGridShowClickedQueryButton.xlsx";

        /*************************************************************************************************************/


        //RealTimeDataControl
        public static DataTable dtRightSideRealTimeData = new DataTable();

        /*************************************************************************************************************/


        public static void _init_dtFaultHistoryQuery()
        {
            Global.dtTitleGridShowMainForm.Columns.Add("序号", typeof(String));
            Global.dtTitleGridShowMainForm.Columns.Add("产线名称", typeof(String));
            Global.dtTitleGridShowMainForm.Columns.Add("检测设备名称", typeof(String));
            Global.dtTitleGridShowMainForm.Columns.Add("故障名称", typeof(String));
            Global.dtTitleGridShowMainForm.Columns.Add("故障发生时间", typeof(String));



        }

       


        public static void _init_dtSideTileBarWithSubHistoryQuery()
        {

        }

        public static void _init_dtSideTileBarWithSubSubHistoryQuery()
        {

        }

       

        //public static void _init_dtCigarettePackagingWorkState()
        //{
        //    FileStream fsEach = File.OpenRead(excelPath_cigarettePackaging_CigaretteMakingWorkState);    //关联流打开文件
        //    IWorkbook workbook = null;
        //    workbook = new XSSFWorkbook(fsEach);    //XSSF打开xlsx
        //    ISheet sheetCigarettePackaging = null;
        //    ISheet sheetCigaretteMaking = null;
        //    sheetCigarettePackaging = workbook.GetSheetAt(0); //获取第1个sheet
        //    sheetCigaretteMaking = workbook.GetSheetAt(1); //获取第2个sheet

        //    //两个Datatable，分别读取Excel的sheet0和sheet1
        //    Global.dtCigarettePackagingWorkState.Columns.Add("nameCigarette", typeof(String));  //这里设定的表的字段，要和设计器的Column的fieldName保持一致
        //    Global.dtCigarettePackagingWorkState.Columns.Add("detection", typeof(Double));
        //    Global.dtCigarettePackagingWorkState.Columns.Add("missingBranch", typeof(Double));
        //    Global.dtCigarettePackagingWorkState.Columns.Add("CPUtemperature", typeof(String));
        //    Global.dtCigarettePackagingWorkState.Columns.Add("CPUusage", typeof(String));
        //    Global.dtCigarettePackagingWorkState.Columns.Add("memoryUsage", typeof(String));
        //    Global.dtCigarettePackagingWorkState.Columns.Add("state", typeof(String));
        //    Global.dtCigarettePackagingWorkState.Columns.Add("img", typeof(Image));

        //    Global.dtCigaretteMakingWorkState.Columns.Add("nameCigarette", typeof(String));
        //    Global.dtCigaretteMakingWorkState.Columns.Add("detection", typeof(Double));
        //    Global.dtCigaretteMakingWorkState.Columns.Add("missingBranch", typeof(Double));
        //    Global.dtCigaretteMakingWorkState.Columns.Add("CPUtemperature", typeof(String));
        //    Global.dtCigaretteMakingWorkState.Columns.Add("CPUusage", typeof(String));
        //    Global.dtCigaretteMakingWorkState.Columns.Add("memoryUsage", typeof(String));
        //    Global.dtCigaretteMakingWorkState.Columns.Add("state", typeof(String));
        //    Global.dtCigaretteMakingWorkState.Columns.Add("img", typeof(Image));

        //    int totalRowsCigarettePackaging = sheetCigarettePackaging.LastRowNum + 1;   //总行数，因行号从0开始
        //    IRow rowCigarettePackaging = null;
        //    for (int i = 1; i < totalRowsCigarettePackaging; i++)
        //    {
        //        rowCigarettePackaging = sheetCigarettePackaging.GetRow(i);	//获取第i行

        //        ICell cellNameCigarettePackaging = rowCigarettePackaging.GetCell(0);	//获取row行的第i列的数据
        //        ICell cellDetectionCigarettePackaging = rowCigarettePackaging.GetCell(1);
        //        ICell cellMissingBranchCigarettePackaging = rowCigarettePackaging.GetCell(2);
        //        ICell cellCPUtemperatureCigarettePackaging = rowCigarettePackaging.GetCell(3);
        //        ICell cellCPUusageCigarettePackaging = rowCigarettePackaging.GetCell(4);
        //        ICell cellMemoryUsageCigarettePackaging = rowCigarettePackaging.GetCell(5);
        //        ICell cellStateCigarettePackaging = rowCigarettePackaging.GetCell(6);
        //        //ICell cellImgFlagCigarettePackaging = rowCigarettePackaging.GetCell(7);

        //        string tempNameCigarettePackaging = (string)Global.getCellValue(cellNameCigarettePackaging);
        //        double tempDetectionCigarettePackaging = (double)Global.getCellValue(cellDetectionCigarettePackaging);
        //        double tempMissingBranchMackaging = (double)Global.getCellValue(cellMissingBranchCigarettePackaging);
        //        double tempCPUtemperatureCigarettePackaging = (double)Global.getCellValue(cellCPUtemperatureCigarettePackaging);
        //        double tempCPUusageCigarettePackaging = (double)Global.getCellValue(cellCPUusageCigarettePackaging);
        //        double tempMemoryUsageCigarettePackaging = (double)Global.getCellValue(cellMemoryUsageCigarettePackaging);
        //        string tempStateCigarettePacking = (string)Global.getCellValue(cellStateCigarettePackaging);
        //        //string tempImgFlagCigarettePackaging = (string)GetCellValue(cellImgFlagCigarettePackaging);

        //        DataRow drCigarettePackaging = Global.dtCigarettePackagingWorkState.NewRow();
        //        drCigarettePackaging["nameCigarette"] = tempNameCigarettePackaging;
        //        drCigarettePackaging["detection"] = tempDetectionCigarettePackaging;
        //        drCigarettePackaging["missingBranch"] = tempMissingBranchMackaging;
        //        drCigarettePackaging["CPUtemperature"] = tempCPUtemperatureCigarettePackaging + "℃";
        //        drCigarettePackaging["CPUusage"] = tempCPUusageCigarettePackaging + "%";
        //        drCigarettePackaging["memoryUsage"] = tempMemoryUsageCigarettePackaging + "%";
        //        drCigarettePackaging["state"] = tempStateCigarettePacking;

        //        //“未定义”时不显示图片，dr不添加图片
        //        if (tempStateCigarettePacking != "未定义")
        //        {
        //            drCigarettePackaging["img"] = global::CloudManage.Properties.Resources.neichen;
        //        }
        //        else
        //        {
        //            drCigarettePackaging["img"] = null;
        //        }
        //        Global.dtCigarettePackagingWorkState.Rows.Add(drCigarettePackaging);
        //    }


        //    int totalRowsCigaretteMaking = sheetCigaretteMaking.LastRowNum + 1;
        //    IRow rowCigaretteMaking = null;
        //    for (int i = 1; i < totalRowsCigaretteMaking; i++)
        //    {
        //        rowCigaretteMaking = sheetCigaretteMaking.GetRow(i);	//获取第i行
        //        ICell cellNameCigaretteMaking = rowCigaretteMaking.GetCell(0);	//获取row行的第i列的数据
        //        ICell cellDetectionCigaretteMaking = rowCigaretteMaking.GetCell(1);
        //        ICell cellMissingBranchCigaretteMaking = rowCigaretteMaking.GetCell(2);
        //        ICell cellCPUtemperatureCigaretteMaking = rowCigaretteMaking.GetCell(3);
        //        ICell cellCPUusageCigaretteMaking = rowCigaretteMaking.GetCell(4);
        //        ICell cellMemoryUsageCigaretteMaking = rowCigaretteMaking.GetCell(5);
        //        ICell cellStateCigaretteMaking = rowCigaretteMaking.GetCell(6);
        //        //ICell cellImgFlagCigaretteMaking = rowCigaretteMaking.GetCell(7);

        //        string tempNameCigaretteMaking = (string)Global.getCellValue(cellNameCigaretteMaking);
        //        double tempDetectionCigaretteMaking = (double)Global.getCellValue(cellDetectionCigaretteMaking);
        //        double tempMissingBranchCigaretteMaking = (double)Global.getCellValue(cellMissingBranchCigaretteMaking);
        //        double tempCPUtemperatureCigaretteMaking = (double)Global.getCellValue(cellCPUtemperatureCigaretteMaking);
        //        double tempCPUusageCigaretteMaking = (double)Global.getCellValue(cellCPUusageCigaretteMaking);
        //        double tempMemoryUsageCigaretteMaking = (double)Global.getCellValue(cellMemoryUsageCigaretteMaking);
        //        string tempStateCigaretteMaking = (string)Global.getCellValue(cellStateCigaretteMaking);
        //        //string tempImgFlagCigaretteMaking = (string)GetCellValue(cellImgFlagCigaretteMaking);

        //        DataRow drCigaretteMaking = Global.dtCigaretteMakingWorkState.NewRow();
        //        drCigaretteMaking["nameCigarette"] = tempNameCigaretteMaking;
        //        drCigaretteMaking["detection"] = tempDetectionCigaretteMaking;
        //        drCigaretteMaking["missingBranch"] = tempMissingBranchCigaretteMaking;
        //        drCigaretteMaking["CPUtemperature"] = tempCPUtemperatureCigaretteMaking + "℃";
        //        drCigaretteMaking["CPUusage"] = tempCPUusageCigaretteMaking + "%";
        //        drCigaretteMaking["memoryUsage"] = tempMemoryUsageCigaretteMaking + "%";
        //        drCigaretteMaking["state"] = tempStateCigaretteMaking;

        //        if (tempStateCigaretteMaking != "未定义")
        //        {
        //            drCigaretteMaking["img"] = global::CloudManage.Properties.Resources.neichen;
        //        }
        //        else
        //        {
        //            drCigaretteMaking["img"] = null;
        //        }

        //        Global.dtCigaretteMakingWorkState.Rows.Add(drCigaretteMaking);
        //    }
        //    fsEach.Close();
        //}

        //初始化检测设备使能表deviceEnable。返回值：各产线显示的检测设备个数
        public static ArrayList _init_dtDeviceEnable()
        {
            ArrayList numShowDeviceOfEachProductionLine = new ArrayList();  //记录各个产线对应的检测设备数量.

            //读各车设备使能标志表
            Global.dtDeviceEnable.Columns.Add("产线Tag", typeof(String));
            Global.dtDeviceEnable.Columns.Add("烟库乱烟检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("烟支空头检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("模盒缺支检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("一号轮缺支检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("三号轮铝箔纸检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("四号轮铝箔纸检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("五号轮内框纸检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("小包外观检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("烟包外观复检", typeof(int));
            Global.dtDeviceEnable.Columns.Add("小包拉线检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("散包视觉检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("散包光电检测", typeof(int));
            Global.dtDeviceEnable.Columns.Add("条盒拉线检测", typeof(int));

            FileStream fsDeviceEnable = File.OpenRead(excelPath_deviceEnable);    //关联流打开文件
            IWorkbook workbookDeviceEnable = null;
            workbookDeviceEnable = new XSSFWorkbook(fsDeviceEnable);    //XSSF打开xlsx
            ISheet sheetDeviceEnable = null;
            sheetDeviceEnable = workbookDeviceEnable.GetSheetAt(0); //获取第1个sheet
            int totalRowsDeviceEnable = sheetDeviceEnable.LastRowNum + 1;
            IRow rowDeviceEnable = null;

            int totalColmnsDtDeviceEnable = Global.dtDeviceEnable.Columns.Count;
            for (int i = 1; i < totalRowsDeviceEnable; i++) //表头不读
            {
                int numShowDevice = 0;
                rowDeviceEnable = sheetDeviceEnable.GetRow(i);	//获取第i行
                ICell cellDeviceEnable = null;
                int flagDevice = 0;
                DataRow drDeviceEnable = Global.dtDeviceEnable.NewRow();
                cellDeviceEnable = rowDeviceEnable.GetCell(0);
                drDeviceEnable[0] = Convert.ToString(getCellValue(cellDeviceEnable));   //产线Tag

                for (int j = 1; j < totalColmnsDtDeviceEnable; j++)
                {
                    cellDeviceEnable = rowDeviceEnable.GetCell(j);
                    flagDevice = Convert.ToInt32(getCellValue(cellDeviceEnable));
                    if (flagDevice == 1)
                    {
                        numShowDevice++;
                    }
                    drDeviceEnable[j] = flagDevice;
                }
                numShowDeviceOfEachProductionLine.Add(numShowDevice);

                //ICell cellDeviceEnable0 = rowDeviceEnable.GetCell(0);	//获取设备Tag
                //ICell cellDeviceEnable1 = rowDeviceEnable.GetCell(1);
                //ICell cellDeviceEnable2 = rowDeviceEnable.GetCell(2);
                //ICell cellDeviceEnable3 = rowDeviceEnable.GetCell(3);
                //ICell cellDeviceEnable4 = rowDeviceEnable.GetCell(4);
                //ICell cellDeviceEnable5 = rowDeviceEnable.GetCell(5);
                //ICell cellDeviceEnable6 = rowDeviceEnable.GetCell(6);
                //ICell cellDeviceEnable7 = rowDeviceEnable.GetCell(7);
                //ICell cellDeviceEnable8 = rowDeviceEnable.GetCell(8);
                //ICell cellDeviceEnable9 = rowDeviceEnable.GetCell(9);
                //ICell cellDeviceEnable10 = rowDeviceEnable.GetCell(10);
                //ICell cellDeviceEnable11 = rowDeviceEnable.GetCell(11);
                //ICell cellDeviceEnable12 = rowDeviceEnable.GetCell(12);
                //ICell cellDeviceEnable13 = rowDeviceEnable.GetCell(13);

                //string tagSideBarItem = Convert.ToString(GetCellValue(cellDeviceEnable0));
                //int flagDevice1 = Convert.ToInt32(GetCellValue(cellDeviceEnable1));
                //int flagDevice2 = Convert.ToInt32(GetCellValue(cellDeviceEnable2));
                //int flagDevice3 = Convert.ToInt32(GetCellValue(cellDeviceEnable3));
                //int flagDevice4 = Convert.ToInt32(GetCellValue(cellDeviceEnable4));
                //int flagDevice5 = Convert.ToInt32(GetCellValue(cellDeviceEnable5));
                //int flagDevice6 = Convert.ToInt32(GetCellValue(cellDeviceEnable6));
                //int flagDevice7 = Convert.ToInt32(GetCellValue(cellDeviceEnable7));
                //int flagDevice8 = Convert.ToInt32(GetCellValue(cellDeviceEnable8));
                //int flagDevice9 = Convert.ToInt32(GetCellValue(cellDeviceEnable9));
                //int flagDevice10 = Convert.ToInt32(GetCellValue(cellDeviceEnable10));
                //int flagDevice11 = Convert.ToInt32(GetCellValue(cellDeviceEnable11));
                //int flagDevice12 = Convert.ToInt32(GetCellValue(cellDeviceEnable12));
                //int flagDevice13 = Convert.ToInt32(GetCellValue(cellDeviceEnable13));

                //DataRow drDeviceEnable = dtDeviceEnable.NewRow();
                //drDeviceEnable["产线Tag"] = tagSideBarItem;
                //drDeviceEnable["烟库乱烟检测"] = flagDevice1;
                //drDeviceEnable["烟支空头检测"] = flagDevice2;
                //drDeviceEnable["模盒缺支检测"] = flagDevice3;
                //drDeviceEnable["一号轮缺支检测"] = flagDevice4;
                //drDeviceEnable["三号轮铝箔纸检测"] = flagDevice5;
                //drDeviceEnable["四号轮铝箔纸检测"] = flagDevice6;
                //drDeviceEnable["五号轮内框纸检测"] = flagDevice7;
                //drDeviceEnable["小包外观检测"] = flagDevice8;
                //drDeviceEnable["烟包外观复检"] = flagDevice9;
                //drDeviceEnable["小包拉线检测"] = flagDevice10;
                //drDeviceEnable["散包视觉检测"] = flagDevice11;
                //drDeviceEnable["散包光电检测"] = flagDevice12;
                //drDeviceEnable["条盒拉线检测"] = flagDevice13;

                Global.dtDeviceEnable.Rows.Add(drDeviceEnable);
            }
            fsDeviceEnable.Close();
            return numShowDeviceOfEachProductionLine;
        }

        //初始化产线名称表
        public static void _init_dtProductionLine(string excelPath)
        {
            FileStream fsProductionLine = File.OpenRead(Global.excelPath_productionLineName);
            Global.dtProductionLine.Columns.Add("产线Tag", typeof(String));
            Global.dtProductionLine.Columns.Add("产线名称", typeof(String));

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
                drProductionLine["产线Tag"] = tagProductionLine;
                drProductionLine["产线名称"] = nameProductionLine;

                Global.dtProductionLine.Rows.Add(drProductionLine);
            }
            fsProductionLine.Close();
        }

        //初始化检测设备名称表
        public static void _init_dtTestingDeviceName(string excelPath)
        {
            Global.dtTestingDeviceName.Columns.Add("检测设备ID", typeof(String));
            Global.dtTestingDeviceName.Columns.Add("检测设备名称", typeof(String));

            FileStream fsTestingDeviceName = File.OpenRead(excelPath);
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
                drTestingDevice["检测设备ID"] = tagTestingDevice;
                drTestingDevice["检测设备名称"] = nameTestingDevice;

                Global.dtTestingDeviceName.Rows.Add(drTestingDevice);
            }
            fsTestingDeviceName.Close();
        }

        //所有故障
        public static void _init_dtAllFaults(string excelPath)
        {
            Global.dtAllFaults.Columns.Add("序号", typeof(String));
            Global.dtAllFaults.Columns.Add("检测设备ID", typeof(String));
            Global.dtAllFaults.Columns.Add("故障ID", typeof(String));
            Global.dtAllFaults.Columns.Add("故障名称", typeof(String));
            Global.dtAllFaults.Columns.Add("故障使能标志", typeof(int));

            FileStream fsFaultName = File.OpenRead(excelPath);
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


        public static void _init_dtHistoryQueryGridShow(string excelPath)
        {
            Global.dtHistoryQueryGridShow.Columns.Add("序号", typeof(String));
            Global.dtHistoryQueryGridShow.Columns.Add("产线名称", typeof(String));
            Global.dtHistoryQueryGridShow.Columns.Add("检测设备名称", typeof(String));
            Global.dtHistoryQueryGridShow.Columns.Add("故障名称", typeof(String));
            Global.dtHistoryQueryGridShow.Columns.Add("故障发生时间", typeof(String));

            FileStream fsFaultDataTime = File.OpenRead(excelPath);
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
                drFaultDataTime["序号"] = numFaultDataTime;
                drFaultDataTime["产线名称"] = nameProductionLineFaultDataTime;
                drFaultDataTime["检测设备名称"] = nameTestingDeviceFaultDataTime;
                drFaultDataTime["故障名称"] = nameFaultFaultDataTime;
                drFaultDataTime["故障发生时间"] = timeFaultOccurFaultDataTime;

                Global.dtHistoryQueryGridShow.Rows.Add(drFaultDataTime);
            }
            fsFaultDataTime.Close();

        }

        public static void _init_dtHistoryQueryGridShowClickedQueryButton(string excelPath)
        {
            Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("序号", typeof(String));
            Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("产线名称", typeof(String));
            Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("检测设备名称", typeof(String));
            Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("故障名称", typeof(String));
            Global.dtHistoryQueryGridShowClickedQueryButton.Columns.Add("故障发生时间", typeof(String));

            FileStream fsFaultDataTimeQuery = File.OpenRead(excelPath);
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
                drFaultDataTimeQuery["序号"] = numFaultDataTimeQuery;
                drFaultDataTimeQuery["产线名称"] = nameProductionLineFaultDataTime;
                drFaultDataTimeQuery["检测设备名称"] = nameTestingDeviceFaultDataTime;
                drFaultDataTimeQuery["故障名称"] = nameFaultFaultDataTime;
                drFaultDataTimeQuery["故障发生时间"] = timeFaultOccurFaultDataTime;

                Global.dtHistoryQueryGridShowClickedQueryButton.Rows.Add(drFaultDataTimeQuery);
            }
            fsFaultDataTimeQuery.Close();
        }



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
