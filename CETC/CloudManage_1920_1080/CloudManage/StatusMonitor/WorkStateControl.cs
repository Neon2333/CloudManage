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
                return global::CloudManage.Properties.Resources.packagingMachineGroup_120x58;
            }else if (index == "B")
            {
                return global::CloudManage.Properties.Resources.packagingMachine_120_34;
            }else
            {
                return global::CloudManage.Properties.Resources.technology_32x32;
            }
        }

        //由imgIndex获取下方的图片
        private Image getImgBottomByIndex(string index)
        {
            if (index == "A")
            {
                return global::CloudManage.Properties.Resources.packagingMachineGroup_120x58;
            }
            else if (index == "B")
            {
                return global::CloudManage.Properties.Resources.packagingMachine_120_34;
            }
            else
            {
                return global::CloudManage.Properties.Resources.technology_32x32;
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
        Color colorPanelReady = Color.FromArgb(58, 166, 101);
        Color colorPanelSold = Color.FromArgb(158, 158, 158);
        Color colorCaptionReady = Color.FromArgb(193, 222, 204);
        Color colorCaptionSold = Color.FromArgb(219, 219, 219);

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;
            bool normalOrError = ((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["status"])) == "正常";

            var statusCaption = e.Item.GetElementByName("elementStatus");
            //var statusCaption = e.Item.Elements[1];

            e.Item.AppearanceItem.Normal.BackColor = normalOrError ? colorPanelSold : colorPanelReady;
            statusCaption.Appearance.Normal.BackColor = normalOrError ? colorCaptionSold : colorCaptionReady;
            //yearCaption.Appearance.Normal.ForeColor = normalOrError ? colorCaptionSold : colorCaptionReady;
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dt.Rows[0][1] = "异常";
        }
    }
}
