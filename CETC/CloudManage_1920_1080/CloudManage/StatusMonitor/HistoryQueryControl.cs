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
        private DataTable dtDeviceEnable = new DataTable();         //产线Tag、检测设备使能标志
        string excelPath_deviceEnable = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\deviceEnable.xlsx";
        private DataTable dtProductionLine = new DataTable();       //产线Tag、产线名称（text）
        string excelPath_productionLineName = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\productionLineName.xlsx";
        private  DataTable dtTestingDeviceName = new DataTable();    //检测设备ID、检测设备名称
        string excelPath_testingDeviceName = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\testingDeviceName.xlsx";
        private DataTable dtAllFaults = new DataTable();            //序号、检测设备ID、故障ID、故障名称、故障使能标志
        string excelPath_allFaults = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\allFaults.xlsx";

        /*
         * 表格说明：
         * historyQueryGridShow——grid显示的表。表示已发生的所有故障。
         * historyQueryGridShowClickedQueryButton——根据车号、检测设备、时间，查出来的某些故障
         * historyQueryGridShowTest——用于测试的表。当historyQueryGridShow发生改变时显示的表
         * 
         * DTTitleGridShow——从dtHistoryQueryGridShow中提取前若干条故障（故障的使能标志为1，故障使能在表dtAllFaluts中），临时表，通过“忽略一次”按钮可删除第一条记录
         * 
         * dtAllFaults——所有车、检测设备可能发生的所有的故障的名称、使能标志（只有被使能==1的故障才能被提取到DTTitleGridShow中）
         * **/
        private DataTable dtHistoryQueryGridShow = new DataTable();        //序号、产线名称、检测设备名称、故障名称、故障发生时间。grid显示
        string excelPath_historyQueryGridShow = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\historyQueryGridShow.xlsx";    
        private DataTable dtHistoryQueryGridShowClickedQueryButton = new DataTable();   //查询出来的数据的表，该Excel用作测试用，后续用MySQL查询前面4张表，得出该表
        string excelPath_historyQueryGridShowClickedQueryButton = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\historyQueryGridShowClickedQueryButton.xlsx";

        private DataTable DTTitleGridShow = new DataTable();    //主菜单标题的表
        private int FaultNumHistoryQuery = 0;    //故障发生数量

        public HistoryQueryControl()
        {
            InitializeComponent();
            test();
        }

        public DataTable dtTitleGridShow
        {
            set
            {
                this.DTTitleGridShow = value;
            }
            get
            {
                return this.DTTitleGridShow;
            }
        }

        public int faultNumHistoryQuery
        {
            set
            {
                this.FaultNumHistoryQuery = value;   
            }
            get
            {
                return this.FaultNumHistoryQuery;
            }
        }


        public object GetCellValue(ICell cell)
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

        //更新标题栏的若干行
        public void _refreshTitleGridShow(int numRowShow)
        {
            this.DTTitleGridShow.Rows.Clear();

            int numRowsHistoryQueryGridShow = dtHistoryQueryGridShow.Rows.Count;
            if(numRowShow > numRowsHistoryQueryGridShow)
            {
                numRowShow = numRowsHistoryQueryGridShow;
            }

            for(int i = 0; i < numRowShow; i++)
            {
                DataRow rowShowTemp = DTTitleGridShow.NewRow();
                rowShowTemp["序号"] = dtHistoryQueryGridShow.Rows[i]["序号"];
                rowShowTemp["产线名称"] = dtHistoryQueryGridShow.Rows[i]["产线名称"];
                rowShowTemp["检测设备名称"] = dtHistoryQueryGridShow.Rows[i]["检测设备名称"];
                rowShowTemp["故障名称"] = dtHistoryQueryGridShow.Rows[i]["故障名称"];
                rowShowTemp["故障发生时间"] = dtHistoryQueryGridShow.Rows[i]["故障发生时间"];
                this.DTTitleGridShow.Rows.Add(rowShowTemp);
            }
        }

        //初始化标题栏的表
        public void _init_dtFaultHistoryQuery()
        {
            DTTitleGridShow.Columns.Add("序号", typeof(String));
            DTTitleGridShow.Columns.Add("产线名称", typeof(String));
            DTTitleGridShow.Columns.Add("检测设备名称", typeof(String));
            DTTitleGridShow.Columns.Add("故障名称", typeof(String));
            DTTitleGridShow.Columns.Add("故障发生时间", typeof(String));

        }

        //初始化检测设备使能表deviceEnable。返回值：各产线显示的检测设备个数
        ArrayList _init_dtDeviceEnable(string excelPath)
        {
            ArrayList numShowDeviceOfEachProductionLine = new ArrayList();  //记录各个产线对应的检测设备数量.

            //读各车设备使能标志表
            dtDeviceEnable.Columns.Add("产线Tag", typeof(String));
            dtDeviceEnable.Columns.Add("烟库乱烟检测", typeof(int));
            dtDeviceEnable.Columns.Add("烟支空头检测", typeof(int));
            dtDeviceEnable.Columns.Add("模盒缺支检测", typeof(int));
            dtDeviceEnable.Columns.Add("一号轮缺支检测", typeof(int));
            dtDeviceEnable.Columns.Add("三号轮铝箔纸检测", typeof(int));
            dtDeviceEnable.Columns.Add("四号轮铝箔纸检测", typeof(int));
            dtDeviceEnable.Columns.Add("五号轮内框纸检测", typeof(int));
            dtDeviceEnable.Columns.Add("小包外观检测", typeof(int));
            dtDeviceEnable.Columns.Add("烟包外观复检", typeof(int));
            dtDeviceEnable.Columns.Add("小包拉线检测", typeof(int));
            dtDeviceEnable.Columns.Add("散包视觉检测", typeof(int));
            dtDeviceEnable.Columns.Add("散包光电检测", typeof(int));
            dtDeviceEnable.Columns.Add("条盒拉线检测", typeof(int));

            FileStream fsDeviceEnable = File.OpenRead(excelPath);    //关联流打开文件
            IWorkbook workbookDeviceEnable = null;
            workbookDeviceEnable = new XSSFWorkbook(fsDeviceEnable);    //XSSF打开xlsx
            ISheet sheetDeviceEnable = null;
            sheetDeviceEnable = workbookDeviceEnable.GetSheetAt(0); //获取第1个sheet
            int totalRowsDeviceEnable = sheetDeviceEnable.LastRowNum + 1;
            IRow rowDeviceEnable = null;

            int totalColmnsDtDeviceEnable = dtDeviceEnable.Columns.Count;
            for (int i = 1; i < totalRowsDeviceEnable; i++) //表头不读
            {
                int numShowDevice = 0;
                rowDeviceEnable = sheetDeviceEnable.GetRow(i);	//获取第i行
                ICell cellDeviceEnable = null;
                int flagDevice = 0;
                DataRow drDeviceEnable = dtDeviceEnable.NewRow();
                cellDeviceEnable = rowDeviceEnable.GetCell(0);
                drDeviceEnable[0] = Convert.ToString(GetCellValue(cellDeviceEnable));   //产线Tag

                for (int j = 1; j < totalColmnsDtDeviceEnable; j++)
                {
                    cellDeviceEnable = rowDeviceEnable.GetCell(j);
                    flagDevice = Convert.ToInt32(GetCellValue(cellDeviceEnable));
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

                dtDeviceEnable.Rows.Add(drDeviceEnable);
            }
            fsDeviceEnable.Close();
            return numShowDeviceOfEachProductionLine;
        }

        //初始化产线名称表
        void _init_dtProductionLine(string excelPath)
        {
            FileStream fsProductionLine = File.OpenRead(excelPath_productionLineName);
            dtProductionLine.Columns.Add("产线Tag", typeof(String));
            dtProductionLine.Columns.Add("产线名称", typeof(String));

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

                string tagProductionLine = Convert.ToString(GetCellValue(cell0));
                string nameProductionLine = Convert.ToString(GetCellValue(cell1));
                DataRow drProductionLine = dtProductionLine.NewRow();
                drProductionLine["产线Tag"] = tagProductionLine;
                drProductionLine["产线名称"] = nameProductionLine;

                dtProductionLine.Rows.Add(drProductionLine);
            }
            fsProductionLine.Close();
        }

        //初始化检测设备名称表
        void _init_dtTestingDeviceName(string excelPath)
        {
            dtTestingDeviceName.Columns.Add("检测设备ID", typeof(String));
            dtTestingDeviceName.Columns.Add("检测设备名称", typeof(String));

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

                string tagTestingDevice = Convert.ToString(GetCellValue(cellTestingDeviceName0));
                string nameTestingDevice = Convert.ToString(GetCellValue(cellTestingDeviceName1));

                DataRow drTestingDevice = dtTestingDeviceName.NewRow();
                drTestingDevice["检测设备ID"] = tagTestingDevice;
                drTestingDevice["检测设备名称"] = nameTestingDevice;

                dtTestingDeviceName.Rows.Add(drTestingDevice);
            }
            fsTestingDeviceName.Close();
        }

        //所有故障
        void _init_dtAllFaults(string excelPath)
        {
            dtAllFaults.Columns.Add("序号", typeof(String));
            dtAllFaults.Columns.Add("检测设备ID", typeof(String));
            dtAllFaults.Columns.Add("故障ID", typeof(String));
            dtAllFaults.Columns.Add("故障名称", typeof(String));
            dtAllFaults.Columns.Add("故障使能标志", typeof(int));

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


                string numFaultName = Convert.ToString(GetCellValue(cellFaultName0));
                string tagTestingDevice = Convert.ToString(GetCellValue(cellFaultName1));
                string tagFault = Convert.ToString(GetCellValue(cellFaultName2));
                string nameFault = Convert.ToString(GetCellValue(cellFaultName3));
                int flagEnable = Convert.ToInt32(GetCellValue(cellFaultName4));

                DataRow drFaultName = dtAllFaults.NewRow();
                drFaultName["序号"] = numFaultName;
                drFaultName["检测设备ID"] = tagTestingDevice;
                drFaultName["故障ID"] = tagFault;
                drFaultName["故障名称"] = nameFault;
                drFaultName["故障使能标志"] = flagEnable;

                dtAllFaults.Rows.Add(drFaultName);
            }
            fsFaultName.Close();
        }

        /**
         *问题：复制的Excel表，虽然把数据删除了，但单元格行数不变，单元格内存Null。导致显示时出现空白行。
         */
        void _init_dtHistoryQueryGridShow(string excelPath)
        {
            dtHistoryQueryGridShow.Columns.Add("序号", typeof(String));
            dtHistoryQueryGridShow.Columns.Add("产线名称", typeof(String));
            dtHistoryQueryGridShow.Columns.Add("检测设备名称", typeof(String));
            dtHistoryQueryGridShow.Columns.Add("故障名称", typeof(String));
            dtHistoryQueryGridShow.Columns.Add("故障发生时间", typeof(String));

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

                string numFaultDataTime = Convert.ToString(GetCellValue(cellFaultDataTime0));
                string nameProductionLineFaultDataTime = Convert.ToString(GetCellValue(cellFaultDataTime1));
                string nameTestingDeviceFaultDataTime = Convert.ToString(GetCellValue(cellFaultDataTime2));
                string nameFaultFaultDataTime = Convert.ToString(GetCellValue(cellFaultDataTime3));
                string timeFaultOccurFaultDataTime = Convert.ToString(GetCellValue(cellFaultDataTime4));
                //faultOccurTemp = (DateTime)GetCellValue(cellFaultDataTime4);
                //string timeFaultOccurFaultDataTime = faultOccurTemp.ToString("yyyy-MM-dd HH:mm:ss");

                DataRow drFaultDataTime = dtHistoryQueryGridShow.NewRow();
                drFaultDataTime["序号"] = numFaultDataTime;
                drFaultDataTime["产线名称"] = nameProductionLineFaultDataTime;
                drFaultDataTime["检测设备名称"] = nameTestingDeviceFaultDataTime;
                drFaultDataTime["故障名称"] = nameFaultFaultDataTime;
                drFaultDataTime["故障发生时间"] = timeFaultOccurFaultDataTime;

                dtHistoryQueryGridShow.Rows.Add(drFaultDataTime);
            }
            fsFaultDataTime.Close();

        }

        void _init_dtHistoryQueryGridShowClickedQueryButton(string excelPath)
        {
            dtHistoryQueryGridShowClickedQueryButton.Columns.Add("序号", typeof(String));
            dtHistoryQueryGridShowClickedQueryButton.Columns.Add("产线名称", typeof(String));
            dtHistoryQueryGridShowClickedQueryButton.Columns.Add("检测设备名称", typeof(String));
            dtHistoryQueryGridShowClickedQueryButton.Columns.Add("故障名称", typeof(String));
            dtHistoryQueryGridShowClickedQueryButton.Columns.Add("故障发生时间", typeof(String));

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

                string numFaultDataTimeQuery = Convert.ToString(GetCellValue(cellFaultDataTimeQuery0));
                string nameProductionLineFaultDataTime = Convert.ToString(GetCellValue(cellFaultDataTimeQuery1));
                string nameTestingDeviceFaultDataTime = Convert.ToString(GetCellValue(cellFaultDataTimeQuery2));
                string nameFaultFaultDataTime = Convert.ToString(GetCellValue(cellFaultDataTimeQuery3));
                string timeFaultOccurFaultDataTime = Convert.ToString(GetCellValue(cellFaultDataTimeQuery4));
                //faultOccurTemp = (DateTime)GetCellValue(cellFaultDataTime4);
                //string timeFaultOccurFaultDataTime = faultOccurTemp.ToString("yyyy-MM-dd HH:mm:ss");

                DataRow drFaultDataTimeQuery = dtHistoryQueryGridShowClickedQueryButton.NewRow();
                drFaultDataTimeQuery["序号"] = numFaultDataTimeQuery;
                drFaultDataTimeQuery["产线名称"] = nameProductionLineFaultDataTime;
                drFaultDataTimeQuery["检测设备名称"] = nameTestingDeviceFaultDataTime;
                drFaultDataTimeQuery["故障名称"] = nameFaultFaultDataTime;
                drFaultDataTimeQuery["故障发生时间"] = timeFaultOccurFaultDataTime;

                dtHistoryQueryGridShowClickedQueryButton.Rows.Add(drFaultDataTimeQuery);
            }
            fsFaultDataTimeQuery.Close();
        }

        //初始化子菜单
        void _init_sideTileBarSub(ArrayList showDeviceNum)
        {
            this.sideTileBarControlWithSub1.dataTableTileBarSub = this.dtDeviceEnable;
            for (int i = 0; i < dtTestingDeviceName.Rows.Count; i++)
            {
                string tagTemp = (string)dtTestingDeviceName.Rows[i]["检测设备ID"];
                string nameTemp = (string)dtTestingDeviceName.Rows[i]["检测设备名称"];
                bool flag = this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), tagTemp, "tileBarItem_sub" + (i + 1).ToString(), nameTemp, Encoding.Default.GetBytes(nameTemp).Length / 2);
            }
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "1", "tileBarItem_sub1", "烟库乱烟检测", Encoding.Default.GetBytes("烟库乱烟检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "2", "tileBarItem_sub2", "烟支空头检测", Encoding.Default.GetBytes("烟支空头检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "3", "tileBarItem_sub3", "模盒缺支检测", Encoding.Default.GetBytes("模盒缺支检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "4", "tileBarItem_sub4", "一号轮缺支检测", Encoding.Default.GetBytes("一号轮缺支检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "5", "tileBarItem_sub5", "三号轮铝箔纸检测", Encoding.Default.GetBytes("三号轮铝箔纸检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "6", "tileBarItem_sub6", "四号轮铝箔纸检测", Encoding.Default.GetBytes("四号轮铝箔纸检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "7", "tileBarItem_sub7", "五号轮内框纸检测", Encoding.Default.GetBytes("五号轮内框纸检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "8", "tileBarItem_sub8", "小包外观检测", Encoding.Default.GetBytes("小包外观检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "9", "tileBarItem_sub9", "烟包外观复检", Encoding.Default.GetBytes("烟包外观复检").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "10", "tileBarItem_sub10", "小包拉线检测", Encoding.Default.GetBytes("小包拉线检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "11", "tileBarItem_sub11", "散包视觉检测", Encoding.Default.GetBytes("散包视觉检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "12", "tileBarItem_sub12", "散包光电检测", Encoding.Default.GetBytes("散包光电检测").Length / 2);
            //this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "13", "tileBarItem_sub13", "条盒拉线检测", Encoding.Default.GetBytes("条盒拉线检测").Length / 2);

            //drProductionLine["产线名称"] = nameProductionLine;
            //drProductionLine["按钮显示数字"] = Convert.ToString(numShowDevices[i - 1]); //dtDeviceEnable.Rows.Count == totalRowsProductionLine - 1


            //添加产线按钮tileBarItem
            string tag = String.Empty;
            string name = String.Empty;
            string text = String.Empty;
            string num = String.Empty;

            for (int i = 0; i < dtDeviceEnable.Rows.Count; i++)
            {
                tag = (string)dtDeviceEnable.Rows[i]["产线Tag"];
                name = "tileBarItem" + (i + 1).ToString();   //总览是tileBarItem0
                for(int j = 0; j < dtProductionLine.Rows.Count; j++)
                {
                    if (tag == (string)dtProductionLine.Rows[j]["产线Tag"])
                    {
                        text = (string)dtProductionLine.Rows[j]["产线名称"];
                    }
                }
                num = Convert.ToString(showDeviceNum[i]);

                this.sideTileBarControlWithSub1._addSideTileBarItem(new TileBarItem(), tag, name, text, num);   //添加item
            } //添加item

            this.sideTileBarControlWithSub1._showSubItemHideRedundantItem();
        }

        //初始化基础信息表格
        public void _initHistoryQuery()
        {
            _init_dtTestingDeviceName(excelPath_testingDeviceName);
            _init_dtProductionLine(excelPath_productionLineName);
            _init_dtAllFaults(excelPath_allFaults);
            ArrayList showDeviceNum = _init_dtDeviceEnable(excelPath_deviceEnable);
            _init_sideTileBarSub(showDeviceNum);

        }

        //测试函数
        void test()
        {
            _initHistoryQuery();
            _init_dtHistoryQueryGridShow(excelPath_historyQueryGridShow);    //grid显示
            _init_dtHistoryQueryGridShowClickedQueryButton(excelPath_historyQueryGridShowClickedQueryButton);   //点击查询后grid显示
            _init_dtFaultHistoryQuery();    
            _refreshTitleGridShow(10); 
            this.gridControl_faultDataTime.DataSource = dtHistoryQueryGridShow;

        }

        private string _getProductionLineNameByTag(string tagProductionLine)
        {
            //dtProductionLine中没有Tag==0的记录
            if(tagProductionLine == "0")
            {
                return "总览";
            }

            string temp = "产线Tag=" + "'" + tagProductionLine + "'";
            DataRow[] rowPL = dtProductionLine.Select(temp);
            if (rowPL.Length == 1)
            {
                return (string)rowPL[0]["产线名称"];
            }
            else
            {
                return "产线名称查询错误...";
            }
        }

        private string _getTestingDeviceNameByTag(string tagTestingDeviceName)
        {
            if (tagTestingDeviceName == "0")
            {
                return "所有设备";
            }

            string temp = "检测设备ID=" + "'" + tagTestingDeviceName + "'";
            DataRow[] rowTD = dtTestingDeviceName.Select(temp);
            if (rowTD.Length == 1)
            {
                return (string)rowTD[0]["检测设备名称"];
            }
            else
            {
                return "产线名称查询错误...";
            }
        }

        private bool _timeInterVaIllegal()
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

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClicked(object sender, EventArgs e)
        {
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub1.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub1.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2;

        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            if(_timeInterVaIllegal() == true)
            {
                MessageBox.Show("无效时间区间，请重新选择...");
            }
            //查询改变grid绑定的表
            this.gridControl_faultDataTime.DataSource = dtHistoryQueryGridShowClickedQueryButton;

        }

        private void simpleButton_startTimeModify_Click(object sender, EventArgs e)
        {
            this.timeEdit_startTime.ShowPopup();
        }

        private void simpleButton_endTimeModify_Click(object sender, EventArgs e)
        {
            this.timeEdit_endTime.ShowPopup();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //grid绑定的表不变，dtHistoryQueryGridShow，但dtHistoryQueryGridShow中内容发生了改变
            this.dtHistoryQueryGridShow = new DataTable();
            _init_dtHistoryQueryGridShow(@"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\historyQueryGridShowTest.xlsx");    //该表是用来测试的
            this.gridControl_faultDataTime.DataSource = dtHistoryQueryGridShow;
            this._refreshTitleGridShow(10);
        }

    }
}
