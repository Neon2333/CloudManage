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
            dt.Columns.Add("showSubItem", typeof(String));

            string excelPath = @"historyQueryDevices\historyQueryDevices.xlsx";
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

                string tagSideBarItem = (string)GetCellValue(cell0);
                string nameSideBarItem = (string)GetCellValue(cell1);
                string textSideBarItem = (string)GetCellValue(cell2);
                string numSideBarItem = (string)GetCellValue(cell3);
                string showSubItem = (string)GetCellValue(cell4);

                DataRow dr = dt.NewRow();
                dr["tagSideBarItem"] = tagSideBarItem;
                dr["nameSideBarItem"] = nameSideBarItem;
                dr["textSideBarItem"] = textSideBarItem;
                dr["numSideBarItem"] = numSideBarItem;
                dr["showSubItem"] = showSubItem;
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
            string tag = String.Empty;
            string name = String.Empty;
            string text = String.Empty;
            string num = String.Empty;
            string showSubItem = String.Empty;
            string[] showItems = new string[99];

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                tag = (string)dt.Rows[i]["tagSideBarItem"];
                name = (string)dt.Rows[i]["nameSideBarItem"];
                text = (string)dt.Rows[i]["textSideBarItem"];
                num = (string)dt.Rows[i]["numSideBarItem"];
                showSubItem = (string)dt.Rows[i]["showSubItem"];
                showItems[i] = showSubItem;

                this.sideTileBarControlWithSub1._addSideTileBarItem(new TileBarItem(), tag, name, text, num);
            }

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

            this.sideTileBarControlWithSub1._showSubItemHideRedundantItem(showItems);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.sideTileBarControlWithSub1._deleteButtonSub(this.textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] a = { "1", "3", "5" };
            this.sideTileBarControlWithSub1._showSubItemHideRedundantItem(a);
        }



    }
}