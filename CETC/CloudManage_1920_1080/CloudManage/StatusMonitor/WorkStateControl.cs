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
using DevExpress.XtraGrid.Views.Tile;

using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Diagnostics;
using System.IO;

namespace CloudManage.StatusMonitor
{
    public partial class WorkStateControl : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable dt = new DataTable();
        public WorkStateControl()
        {
            InitializeComponent();
            init();
            initData();
            setView();

        }

        //初始化SideTileBar按钮10个
        private void init()
        {
            bool flag;
           flag = this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "2", "tileBarItem3", "2车", "51");
           flag = this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "3", "tileBarItem4", "3车", "51");
           flag = this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "4", "tileBarItem5", "4车", "51");
           flag = this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "5", "tileBarItem6", "5车", "51");
           flag = this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "6", "tileBarItem7", "6车", "51");
           flag = this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "7", "tileBarItem8", "7车", "51");
           flag = this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "8", "tileBarItem9", "8车", "51");
           flag = this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "9", "tileBarItem10", "9车", "51");
           flag = this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "10", "tileBarItem11", "10车", "51");

        }

        //获取Excel单元格数据
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

        //由imgIndex获取上方的图片
        private Image getImgTopByIndex(string index)
        {
            if (index == "A")
            {
                return global::CloudManage.Properties.Resources.ZJ17_PROTOS70_336x140;
            }else if (index == "B")
            {
                return global::CloudManage.Properties.Resources.ZJ17_PROTOS70_336x140;
            }else
            {
                return global::CloudManage.Properties.Resources.ZJ17_PROTOS70_336x140;
            }
        }

        //由imgIndex获取下方的图片
        private Image getImgBottomByIndex(string index)
        {
            if (index == "A")
            {
                return global::CloudManage.Properties.Resources.ZB45_336x140;
            }
            else if (index == "B")
            {
                return global::CloudManage.Properties.Resources.ZB45_336x140;
            }
            else
            {
                return global::CloudManage.Properties.Resources.ZB45_336x140;
            }
        }

        private void initData()
        {
            //读取Excel，将数据添加到DataSet的DataTable中
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(String));
            dt.Columns.Add("status", typeof(String));
            dt.Columns.Add("deviceImgTop", typeof(Image));
            dt.Columns.Add("deviceImgBottom", typeof(Image));

            string excelPath = @"C:\Users\Administrator\Desktop\devicesData.xlsx";
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
                ICell cellName = row.GetCell(0);	//获取row行的第i列的数据
                ICell cellStatus = row.GetCell(1);
                ICell cellDeviceImg = row.GetCell(2);

                string tempName = (string)GetCellValue(cellName);
                string tempStatus = (string)GetCellValue(cellStatus);
                //int tempImgIndex = (int)GetCellValue(cellDeviceImg);
                string tempImgIndex = (string)GetCellValue(cellDeviceImg);

                DataRow dr = dt.NewRow();
                dr["name"] = tempName;
                dr["status"] = tempStatus;
                dr["deviceImgTop"] = getImgTopByIndex(tempImgIndex);
                dr["deviceImgBottom"] = getImgBottomByIndex(tempImgIndex);

                dt.Rows.Add(dr);
            }
            //ds.Tables.Add(dt);

            //将dt绑定到GridControl
            gridControl1.DataSource = dt;

        }

        private void setView()
        {
            
        }

        //按钮颜色
        Color colorNormal = Color.FromArgb(56, 152, 83);
        Color colorAbnormal = Color.FromArgb(208, 49, 68);
        Color colorDisable = Color.FromArgb(120,120,120);

        //该事件可customize所有tile
        private void tileView1_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;
            int stateTile = 0;
            //e为tileview，RowHandle为选中的tile的index，每个tile是表格的一行
            //GetRowCellValue返回tileView绑定的数据源的某一列的值，类型object
            if ((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["status"]) == "正常"){
                stateTile = 0;
            }
            else if((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["status"]) == "异常")
            {
                stateTile = 1;

            }
            else if((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["status"]) == "无效")
            {
                stateTile = 2;
            }

            //var statusCaption = e.Item.GetElementByName("elementStatus");
            //var statusCaption = e.Item.Elements[1];
            if (stateTile == 0)
            {
                e.Item.AppearanceItem.Normal.BackColor = colorNormal;
            }
            else if(stateTile == 1)
            {
                e.Item.AppearanceItem.Normal.BackColor = colorAbnormal;
            }
            else if(stateTile == 2)
            {
                e.Item.AppearanceItem.Normal.BackColor = colorDisable;
            }
            //statusCaption.Appearance.Normal.BackColor = normalOrError ? colorCaptionSold : colorCaptionReady;
            //yearCaption.Appearance.Normal.ForeColor = normalOrError ? colorCaptionSold : colorCaptionReady;

        }

        private void tileView1_DoubleClick(object sender, EventArgs e)
        {
            int[] index = this.tileView1.GetSelectedRows(); //返回被选中tile的index
            foreach(var i in index)
            {
                this.sideTileBarControl1._selectedItem(i + 1);
            }


        }
    }
}
