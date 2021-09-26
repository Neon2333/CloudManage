using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


namespace CloudManage.test
{
    public partial class testSideTileBarWithSubControl : DevExpress.XtraEditors.XtraForm
    {

        DataTable dt = new DataTable();

        public testSideTileBarWithSubControl()
        {
            InitializeComponent();
            initData();
        }

        public void initData()
        {
            dt.Columns.Add("tagSideBarItem", typeof(String));
            dt.Columns.Add("nameSideBarItem", typeof(String));
            dt.Columns.Add("textSideBarItem", typeof(String));
            dt.Columns.Add("numSideBarItem", typeof(String));
            dt.Columns.Add("烟库乱烟检测", typeof(int));
            dt.Columns.Add("烟支空头检测", typeof(int));
            dt.Columns.Add("模盒缺支检测", typeof(int));
            dt.Columns.Add("一号轮缺支检测", typeof(int));
            dt.Columns.Add("二号轮铝箔纸检测", typeof(int));
            dt.Columns.Add("三号轮铝箔纸检测", typeof(int));
            dt.Columns.Add("五号轮内框纸检测", typeof(int));
            dt.Columns.Add("小包外观检测", typeof(int));
            dt.Columns.Add("烟包外观复检", typeof(int));
            dt.Columns.Add("小包拉线检测", typeof(int));
            dt.Columns.Add("散包视觉检测", typeof(int));
            dt.Columns.Add("散包光电检测", typeof(int));
            dt.Columns.Add("条盒拉线检测", typeof(int));

            string excelPath = @"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\historyQueryDevices.xlsx";
            FileStream fs = File.OpenRead(excelPath);    //关联流打开文件
            IWorkbook workbook = null;
            workbook = new XSSFWorkbook(fs);    //XSSF打开xlsx
            ISheet sheet = null;
            sheet = workbook.GetSheetAt(0); //获取第1个sheet
            int totalRows = sheet.LastRowNum + 1;
            IRow row = null;
            for (int i = 1; i < totalRows; i++)
            {
                row = sheet.GetRow(i);	//获取第i行
                ICell cell0 = row.GetCell(0);	//获取row行的第i列的数据
                ICell cell1 = row.GetCell(1);
                ICell cell2 = row.GetCell(2);
                ICell cell3 = row.GetCell(3);

                ICell cell4 = row.GetCell(4);
                ICell cell5 = row.GetCell(5);
                ICell cell6 = row.GetCell(6);
                ICell cell7 = row.GetCell(7);
                ICell cell8 = row.GetCell(8);
                ICell cell9 = row.GetCell(9);
                ICell cell10 = row.GetCell(10);
                ICell cell11 = row.GetCell(11);
                ICell cell12 = row.GetCell(12);
                ICell cell13 = row.GetCell(13);
                ICell cell14 = row.GetCell(14);
                ICell cell15 = row.GetCell(15);
                ICell cell16 = row.GetCell(16);


                string tagSideBarItem = Convert.ToString(GetCellValue(cell0));
                string nameSideBarItem = Convert.ToString(GetCellValue(cell1));
                string textSideBarItem = Convert.ToString(GetCellValue(cell2));
                string numSideBarItem = Convert.ToString(GetCellValue(cell3));

                int flagEquip0 = Convert.ToInt32(GetCellValue(cell4));
                int flagEquip1 = Convert.ToInt32(GetCellValue(cell5));
                int flagEquip2 = Convert.ToInt32(GetCellValue(cell6));
                int flagEquip3 = Convert.ToInt32(GetCellValue(cell7));
                int flagEquip4 = Convert.ToInt32(GetCellValue(cell8));
                int flagEquip5 = Convert.ToInt32(GetCellValue(cell9));
                int flagEquip6 = Convert.ToInt32(GetCellValue(cell10));
                int flagEquip7 = Convert.ToInt32(GetCellValue(cell11));
                int flagEquip8 = Convert.ToInt32(GetCellValue(cell12));
                int flagEquip9 = Convert.ToInt32(GetCellValue(cell13));
                int flagEquip10 = Convert.ToInt32(GetCellValue(cell4));
                int flagEquip11 = Convert.ToInt32(GetCellValue(cell5));
                int flagEquip12 = Convert.ToInt32(GetCellValue(cell6));


                DataRow dr = dt.NewRow();
                dr["tagSideBarItem"] = tagSideBarItem;
                dr["nameSideBarItem"] = nameSideBarItem;
                dr["textSideBarItem"] = textSideBarItem;
                dr["numSideBarItem"] = numSideBarItem;
                dr["烟库乱烟检测"] = flagEquip0;
                dr["烟支空头检测"] = flagEquip1;
                dr["模盒缺支检测"] = flagEquip2;
                dr["一号轮缺支检测"] = flagEquip3;
                dr["二号轮铝箔纸检测"] = flagEquip4;
                dr["三号轮铝箔纸检测"] = flagEquip5;
                dr["五号轮内框纸检测"] = flagEquip6;
                dr["小包外观检测"] = flagEquip7;
                dr["烟包外观复检"] = flagEquip8;
                dr["小包拉线检测"] = flagEquip9;
                dr["散包视觉检测"] = flagEquip10;
                dr["散包光电检测"] = flagEquip11;
                dr["条盒拉线检测"] = flagEquip12;


                dt.Rows.Add(dr);
            }
            fs.Close();
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


        private void button1_Click(object sender, EventArgs e)
        {
            this.sideTileBarControlWithSub1.dt = this.dt;

            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "1", "tileBarItem_sub1", "烟库乱烟检测", Encoding.Default.GetBytes("烟库乱烟检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "2", "tileBarItem_sub2", "烟支空头检测", Encoding.Default.GetBytes("烟支空头检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "3", "tileBarItem_sub3", "模盒缺支检测", Encoding.Default.GetBytes("模盒缺支检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "4", "tileBarItem_sub4", "一号轮缺支检测", Encoding.Default.GetBytes("一号轮缺支检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "5", "tileBarItem_sub5", "三号轮铝箔纸检测", Encoding.Default.GetBytes("三号轮铝箔纸检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "6", "tileBarItem_sub6", "三号轮铝箔纸检测", Encoding.Default.GetBytes("三号轮铝箔纸检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "7", "tileBarItem_sub7", "五号轮内框纸检测", Encoding.Default.GetBytes("五号轮内框纸检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "8", "tileBarItem_sub8", "小包外观检测", Encoding.Default.GetBytes("小包外观检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "9", "tileBarItem_sub9", "烟包外观复检", Encoding.Default.GetBytes("烟包外观复检").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "10", "tileBarItem_sub10", "小包拉线检测", Encoding.Default.GetBytes("小包拉线检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "11", "tileBarItem_sub11", "散包视觉检测", Encoding.Default.GetBytes("散包视觉检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "12", "tileBarItem_sub12", "散包光电检测", Encoding.Default.GetBytes("散包光电检测").Length / 2);
            this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), "13", "tileBarItem_sub13", "条盒拉线检测", Encoding.Default.GetBytes("条盒拉线检测").Length / 2);

            string tag = String.Empty;
            string name = String.Empty;
            string text = String.Empty;
            string num = String.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tag = (string)dt.Rows[i]["tagSideBarItem"];
                name = (string)dt.Rows[i]["nameSideBarItem"];
                text = (string)dt.Rows[i]["textSideBarItem"];
                num = (string)dt.Rows[i]["numSideBarItem"];

                this.sideTileBarControlWithSub1._addSideTileBarItem(new TileBarItem(), tag, name, text, num);
            }

            this.sideTileBarControlWithSub1._showSubItemHideRedundantItem();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.sideTileBarControlWithSub1._deleteButtonSub(this.textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }



    }
}