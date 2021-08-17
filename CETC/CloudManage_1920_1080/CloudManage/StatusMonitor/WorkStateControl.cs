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
        DataTable dtOverview = new DataTable();
        DataTable dtPackagingPachine = new DataTable();
        DataTable dtWindlass = new DataTable();


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
            initDataOverview();
            initDataEach();
        }

        //总览数据绑定
        public void initDataOverview()
        {
            //读取Excel，将数据添加到DataSet的DataTable中
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            dtOverview.Columns.Add("name", typeof(String));
            dtOverview.Columns.Add("status", typeof(String));
            dtOverview.Columns.Add("deviceImgTop", typeof(Image));
            dtOverview.Columns.Add("deviceImgBottom", typeof(Image));

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

                DataRow dr = dtOverview.NewRow();
                dr["name"] = tempName;
                dr["status"] = tempStatus;
                dr["deviceImgTop"] = getImgTopByIndex(tempImgIndex);
                dr["deviceImgBottom"] = getImgBottomByIndex(tempImgIndex);

                dtOverview.Rows.Add(dr);
            }
            //ds.Tables.Add(dt);
            fs.Close();
            gridControl_overview.DataSource = dtOverview;   //将dt绑定到GridControl
        }

        //每台车数据绑定
        public void initDataEach()
        {
            dtPackagingPachine.Columns.Add("name1", typeof(String));
            dtPackagingPachine.Columns.Add("status1", typeof(String));
            dtPackagingPachine.Columns.Add("deviceImgTop1", typeof(Image));
            dtPackagingPachine.Columns.Add("deviceImgBottom1", typeof(Image));

            dtWindlass.Columns.Add("name1", typeof(String));
            dtWindlass.Columns.Add("status1", typeof(String));
            dtWindlass.Columns.Add("deviceImgTop1", typeof(Image));
            dtWindlass.Columns.Add("deviceImgBottom1", typeof(Image));

            string excelPath = @"C:\Users\Administrator\Desktop\devicesDataEach.xlsx";
            FileStream fs = File.OpenRead(excelPath);    //关联流打开文件
            IWorkbook workbook = null;
            workbook = new XSSFWorkbook(fs);    //XSSF打开xlsx
            ISheet sheetPackagingPachine = null;
            ISheet sheetWindlass = null;
            sheetPackagingPachine = workbook.GetSheetAt(0); //获取第1个sheet
            sheetWindlass = workbook.GetSheetAt(1); //获取第2个sheet
            
            int totalRowsPackagingPachine = sheetPackagingPachine.LastRowNum + 1;   //总行数，因行号从0开始
            int totalRowsWindlass = sheetWindlass.LastRowNum + 1;

            IRow rowPackagingPachine = null;
            IRow rowWindlass = null;
            for (int i = 1; i < totalRowsPackagingPachine; i++)
            {
                rowPackagingPachine = sheetPackagingPachine.GetRow(i);	//获取第i行
                ICell cellName = rowPackagingPachine.GetCell(0);	//获取row行的第i列的数据
                ICell cellStatus = rowPackagingPachine.GetCell(1);
                ICell cellDeviceImg = rowPackagingPachine.GetCell(2);

                string tempNamePackagingPachine = (string)GetCellValue(cellName);
                string tempStatusPackagingPachine = (string)GetCellValue(cellStatus);
                //int tempImgIndex = (int)GetCellValue(cellDeviceImg);
                string tempImgIndexPackagingPachine = (string)GetCellValue(cellDeviceImg);

                DataRow drPackagingPachine = dtPackagingPachine.NewRow();
                drPackagingPachine["name1"] = tempNamePackagingPachine;
                drPackagingPachine["status1"] = tempStatusPackagingPachine;
                drPackagingPachine["deviceImgTop1"] = getImgTopByIndex(tempImgIndexPackagingPachine);
                drPackagingPachine["deviceImgBottom1"] = getImgBottomByIndex(tempImgIndexPackagingPachine);

                dtPackagingPachine.Rows.Add(drPackagingPachine);
            }

            for (int i = 1; i < totalRowsWindlass; i++)
            {
                rowWindlass = sheetPackagingPachine.GetRow(i);	//获取第i行
                ICell cellName = rowWindlass.GetCell(0);	//获取row行的第i列的数据
                ICell cellStatus = rowWindlass.GetCell(1);
                ICell cellDeviceImg = rowWindlass.GetCell(2);

                string tempNameWindlass = (string)GetCellValue(cellName);
                string tempStatusWindlass = (string)GetCellValue(cellStatus);
                //int tempImgIndex = (int)GetCellValue(cellDeviceImg);
                string tempImgIndexWindlass = (string)GetCellValue(cellDeviceImg);

                DataRow drWindlass = dtWindlass.NewRow();
                drWindlass["name1"] = tempNameWindlass;
                drWindlass["status1"] = tempStatusWindlass;
                drWindlass["deviceImgTop1"] = getImgTopByIndex(tempImgIndexWindlass);
                drWindlass["deviceImgBottom1"] = getImgBottomByIndex(tempImgIndexWindlass);

                dtWindlass.Rows.Add(drWindlass);
            }
            fs.Close();
        }


        private void setView()
        {
            
        }

        //状态颜色
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
            if ((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["status"]) == "正常"){
                stateTile = 0;
            }
            else if((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["status"]) == "异常")
            {
                stateTile = 1;

            }
            else if((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["status"]) == "无效")
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
            int[] index = this.tileView_overview.GetSelectedRows(); //返回被选中tile的index
            foreach(var i in index)
            {
                this.sideTileBarControl1._selectedItem(i + 1);
            }
        }
         
        
        private void tileView1_itemClick(object sender, EventArgs e)
        {
            string selectedPageTag = this.sideTileBarControl1.tagSelectedItem;
            if (selectedPageTag == "0")
            {
                this.navigationFrame_workState.SelectedPage = this.navigationPage_overview;
            }
            else
            {
                this.navigationFrame_workState.SelectedPage = this.navigationPage_each;
            }
        }

        private void imageSlider_each_ImageChanged(object sender, DevExpress.XtraEditors.Controls.ImageChangedEventArgs e)
        {
            if (this.imageSlider_each.CurrentImageIndex == 1)
            {
                gridControl_each.DataSource = dtPackagingPachine;
            }else if (this.imageSlider_each.CurrentImageIndex == 0)
            {
                gridControl_each.DataSource = dtWindlass;
            }

        }


    }
}
