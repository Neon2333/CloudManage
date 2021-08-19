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
        //DataSet ds = new DataSet();
        DataTable dtOverview = new DataTable();
        DataTable dtCigarettePackaging = new DataTable();   //包装机
        DataTable dtCigaretteMaking = new DataTable();  //卷接机

        //状态颜色
        Color colorNormal = Color.FromArgb(56, 152, 83);
        Color colorAbnormal = Color.FromArgb(208, 49, 68);
        Color colorDisable = Color.FromArgb(120, 120, 120);

        public WorkStateControl()
        {
            InitializeComponent();
            init();
            initDataOverview();
            initDataEach();
            //setView();

        }

        //初始化SideTileBar按钮10个
        private void init()
        {
            bool flag;
            //侧边栏默认初始添加10个按钮
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

        //由imgIndex获取总览按钮的上半的图片
        private Image getImgTopByIndexOverview(string index)
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

        //由imgIndex获取总览按钮的下半的图片
        private Image getImgBottomByIndexOverview(string index)
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

        //总览数据绑定
        public void initDataOverview()
        {
            //读取Excel，将数据添加到DataSet的DataTable中
            dtOverview.Columns.Add("name", typeof(String));
            dtOverview.Columns.Add("status", typeof(String));
            dtOverview.Columns.Add("deviceImgTop", typeof(Image));
            dtOverview.Columns.Add("deviceImgBottom", typeof(Image));

            string excelPath = @"C:\Users\Administrator\Desktop\devicesData.xlsx";
            FileStream fsOverview = File.OpenRead(excelPath);    //关联流打开文件
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
                ICell cellDeviceImg = row.GetCell(2);

                string tempName = (string)GetCellValue(cellName);
                string tempStatus = (string)GetCellValue(cellStatus);
                string tempImgIndex = (string)GetCellValue(cellDeviceImg);

                DataRow dr = dtOverview.NewRow();
                dr["name"] = tempName;
                dr["status"] = tempStatus;
                dr["deviceImgTop"] = getImgTopByIndexOverview(tempImgIndex);
                dr["deviceImgBottom"] = getImgBottomByIndexOverview(tempImgIndex);

                dtOverview.Rows.Add(dr);
            }
            //ds.Tables.Add(dt);
            fsOverview.Close();
            gridControl_overview.DataSource = dtOverview;   //将dt绑定到GridControl
        }

        //每台车数据绑定
        public void initDataEach()
        {
            string excelPath = @"C:\Users\Administrator\Desktop\devicesDataEach.xlsx";
            FileStream fsEach = File.OpenRead(excelPath);    //关联流打开文件
            IWorkbook workbook = null;
            workbook = new XSSFWorkbook(fsEach);    //XSSF打开xlsx
            ISheet sheetCigarettePackaging = null;
            ISheet sheetCigaretteMaking = null;
            sheetCigarettePackaging = workbook.GetSheetAt(0); //获取第1个sheet
            sheetCigaretteMaking = workbook.GetSheetAt(1); //获取第2个sheet

            //两个Datatable，分别读取Excel的sheet0和sheet1
            dtCigarettePackaging.Columns.Add("nameCigarette", typeof(String));  //这里设定的表的字段，要和设计器的Column的fieldName保持一致
            dtCigarettePackaging.Columns.Add("detection", typeof(Double));
            dtCigarettePackaging.Columns.Add("missingBranch", typeof(Double));
            dtCigarettePackaging.Columns.Add("CPUtemperature", typeof(String));
            dtCigarettePackaging.Columns.Add("CPUusage", typeof(String));
            dtCigarettePackaging.Columns.Add("memoryUsage", typeof(String));
            dtCigarettePackaging.Columns.Add("state", typeof(String));
            dtCigarettePackaging.Columns.Add("img", typeof(Image));

            dtCigaretteMaking.Columns.Add("nameCigarette", typeof(String));
            dtCigaretteMaking.Columns.Add("detection", typeof(Double));
            dtCigaretteMaking.Columns.Add("missingBranch", typeof(Double));
            dtCigaretteMaking.Columns.Add("CPUtemperature", typeof(String));
            dtCigaretteMaking.Columns.Add("CPUusage", typeof(String));
            dtCigaretteMaking.Columns.Add("memoryUsage", typeof(String));
            dtCigaretteMaking.Columns.Add("state", typeof(String));
            dtCigaretteMaking.Columns.Add("img", typeof(Image));
            
            int totalRowsCigarettePackaging = sheetCigarettePackaging.LastRowNum + 1;   //总行数，因行号从0开始
            IRow rowCigarettePackaging = null;
            for (int i = 1; i < totalRowsCigarettePackaging; i++)
            {
                rowCigarettePackaging = sheetCigarettePackaging.GetRow(i);	//获取第i行

                ICell cellNameCigarettePackaging = rowCigarettePackaging.GetCell(0);	//获取row行的第i列的数据
                ICell cellDetectionCigarettePackaging = rowCigarettePackaging.GetCell(1);
                ICell cellMissingBranchCigarettePackaging = rowCigarettePackaging.GetCell(2);
                ICell cellCPUtemperatureCigarettePackaging = rowCigarettePackaging.GetCell(3);
                ICell cellCPUusageCigarettePackaging = rowCigarettePackaging.GetCell(4);
                ICell cellMemoryUsageCigarettePackaging = rowCigarettePackaging.GetCell(5);
                ICell cellStateCigarettePackaging = rowCigarettePackaging.GetCell(6);
                //ICell cellImgFlagCigarettePackaging = rowCigarettePackaging.GetCell(7);

                string tempNameCigarettePackaging = (string)GetCellValue(cellNameCigarettePackaging);
                double tempDetectionCigarettePackaging = (double)GetCellValue(cellDetectionCigarettePackaging);
                double tempMissingBranchMackaging = (double)GetCellValue(cellMissingBranchCigarettePackaging);
                double tempCPUtemperatureCigarettePackaging = (double)GetCellValue(cellCPUtemperatureCigarettePackaging);
                double tempCPUusageCigarettePackaging = (double)GetCellValue(cellCPUusageCigarettePackaging);
                double tempMemoryUsageCigarettePackaging = (double)GetCellValue(cellMemoryUsageCigarettePackaging);
                string tempStateCigarettePacking = (string)GetCellValue(cellStateCigarettePackaging);
                //string tempImgFlagCigarettePackaging = (string)GetCellValue(cellImgFlagCigarettePackaging);

                DataRow drCigarettePackaging = dtCigarettePackaging.NewRow();
                drCigarettePackaging["nameCigarette"] = tempNameCigarettePackaging;
                drCigarettePackaging["detection"] = tempDetectionCigarettePackaging;
                drCigarettePackaging["missingBranch"] = tempMissingBranchMackaging;
                drCigarettePackaging["CPUtemperature"] = tempCPUtemperatureCigarettePackaging + "℃";
                drCigarettePackaging["CPUusage"] = tempCPUusageCigarettePackaging + "%";
                drCigarettePackaging["memoryUsage"] = tempMemoryUsageCigarettePackaging + "%";
                drCigarettePackaging["state"] = tempStateCigarettePacking;
                
                //“未定义”时不显示图片，dr不添加图片
                if (tempStateCigarettePacking != "未定义")
                {
                    drCigarettePackaging["img"] = global::CloudManage.Properties.Resources.neichen;
                }
                else
                {
                    drCigarettePackaging["img"] = null;
                }
                dtCigarettePackaging.Rows.Add(drCigarettePackaging);
            }


            int totalRowsCigaretteMaking = sheetCigaretteMaking.LastRowNum + 1;
            IRow rowCigaretteMaking = null;
            for (int i = 1; i < totalRowsCigaretteMaking; i++)
            {
                rowCigaretteMaking = sheetCigaretteMaking.GetRow(i);	//获取第i行
                ICell cellNameCigaretteMaking = rowCigaretteMaking.GetCell(0);	//获取row行的第i列的数据
                ICell cellDetectionCigaretteMaking = rowCigaretteMaking.GetCell(1);
                ICell cellMissingBranchCigaretteMaking = rowCigaretteMaking.GetCell(2);
                ICell cellCPUtemperatureCigaretteMaking = rowCigaretteMaking.GetCell(3);
                ICell cellCPUusageCigaretteMaking = rowCigaretteMaking.GetCell(4);
                ICell cellMemoryUsageCigaretteMaking = rowCigaretteMaking.GetCell(5);
                ICell cellStateCigaretteMaking = rowCigaretteMaking.GetCell(6);
                //ICell cellImgFlagCigaretteMaking = rowCigaretteMaking.GetCell(7);

                string tempNameCigaretteMaking = (string)GetCellValue(cellNameCigaretteMaking);
                double tempDetectionCigaretteMaking = (double)GetCellValue(cellDetectionCigaretteMaking);
                double tempMissingBranchCigaretteMaking = (double)GetCellValue(cellMissingBranchCigaretteMaking);
                double tempCPUtemperatureCigaretteMaking = (double)GetCellValue(cellCPUtemperatureCigaretteMaking);
                double tempCPUusageCigaretteMaking = (double)GetCellValue(cellCPUusageCigaretteMaking);
                double tempMemoryUsageCigaretteMaking = (double)GetCellValue(cellMemoryUsageCigaretteMaking);
                string tempStateCigaretteMaking = (string)GetCellValue(cellStateCigaretteMaking);
                //string tempImgFlagCigaretteMaking = (string)GetCellValue(cellImgFlagCigaretteMaking);

                DataRow drCigaretteMaking = dtCigaretteMaking.NewRow();
                drCigaretteMaking["nameCigarette"] = tempNameCigaretteMaking;
                drCigaretteMaking["detection"] = tempDetectionCigaretteMaking;
                drCigaretteMaking["missingBranch"] = tempMissingBranchCigaretteMaking;
                drCigaretteMaking["CPUtemperature"] = tempCPUtemperatureCigaretteMaking + "℃";
                drCigaretteMaking["CPUusage"] = tempCPUusageCigaretteMaking + "%";
                drCigaretteMaking["memoryUsage"] = tempMemoryUsageCigaretteMaking + "%";
                drCigaretteMaking["state"] = tempStateCigaretteMaking;

                if (tempStateCigaretteMaking != "未定义")
                {
                    drCigaretteMaking["img"] = global::CloudManage.Properties.Resources.neichen;
                }
                else
                {
                    drCigaretteMaking["img"] = null;
                }

                dtCigaretteMaking.Rows.Add(drCigaretteMaking);
            }
            fsEach.Close();
        }

        private void setView()
        {
        }

        //该事件可自定义tileView中所有tile
        private void tileView_overview_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;
            int stateTile = 0;  //由status判断颜色显示
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

        //总览页面，双击tile，侧边栏对应按钮被选中
        private void tileView_overview_DoubleClick(object sender, EventArgs e)
        {
            int[] index = this.tileView_overview.GetSelectedRows(); //返回被选中tile的index
            foreach(var i in index)
            {
                this.sideTileBarControl1._selectedItem(i + 1);
            }
        }

        //按下侧边栏翻页
        private void sideTileBarControl1_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            string selectedPageTag = this.sideTileBarControl1.tagSelectedItem;  //选中侧边栏哪个按钮
            if (selectedPageTag == "0")
            {
                this.navigationFrame_workState.SelectedPage = this.navigationPage_overview; //若当前选中的是总览按钮则显示Page_overview
            }
            else
            {
                this.navigationFrame_workState.SelectedPage = this.navigationPage_each; //若当前选中的不是总览按钮则显示Page_each
            }
        }

        //imageSlider滑动图片更改each页面GridControl绑定的datatable
        private void imageSlider_each_ImageChanged(object sender, DevExpress.XtraEditors.Controls.ImageChangedEventArgs e)
        {
            if (this.imageSlider_each.CurrentImageIndex == 0)
            {
                gridControl_each.DataSource = dtCigarettePackaging;
            }else if (this.imageSlider_each.CurrentImageIndex == 1)
            {
                gridControl_each.DataSource = dtCigaretteMaking;
            }
        }

        //更改each页面每个tile的颜色
        private void tileView_each_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;

            int stateTile = 0;
            if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["state"]) == "正常")
            {
                stateTile = 0;
            }
            else if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["state"]) == "异常")
            {
                stateTile = 1;

            }
            else if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["state"]) == "无效")
            {
                stateTile = 2;
            }else if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["state"]) == "未定义")
            {
                stateTile = 2;
            }

            //var statusCaption = e.Item.GetElementByName("elementStatus");
            //var statusCaption = e.Item.Elements[1];
            if (stateTile == 0)
            {
                e.Item.AppearanceItem.Normal.BackColor = colorNormal;
            }
            else if (stateTile == 1)
            {
                e.Item.AppearanceItem.Normal.BackColor = colorAbnormal;
            }
            else if (stateTile == 2)
            {
                e.Item.AppearanceItem.Normal.BackColor = colorDisable;
            }
        }
    }
}
