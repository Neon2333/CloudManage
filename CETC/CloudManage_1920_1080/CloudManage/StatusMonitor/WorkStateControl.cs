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
        //状态颜色
        Color colorNormal = Color.FromArgb(56, 152, 83);
        Color colorAbnormal = Color.FromArgb(208, 49, 68);
        Color colorDisable = Color.FromArgb(120, 120, 120);

        public WorkStateControl()
        {
            InitializeComponent();
            initWorkState();
        }

        void initWorkState()
        {
            initDataTable();
            initSideTileBarWorkState(); //初始化侧边栏
            initDataOverviewWorkState();    //初始化总览数据表
            initDataEachWorkState();    //初始化检测设备数据表
        }

        void initDataTable()
        {
            Global._init_dtTestingDeviceName(); //初始化检测设备名称表
            Global._init_dtProductionLine();    //初始化产线名称表
            Global._init_dtAllFaults();         //初始化故障名称表
            Global._init_dtDeviceConfig();      //初始化检测设备使能表
            Global._init_dtFaultHistoryQuery(); //初始化标题栏故障表

            Global._init_dtSideTileBarWorkState();  //WorkState侧边栏初始化表

        }

        private void initSideTileBarWorkState()
        {
            this.sideTileBarControl_workState.dtInitSideTileBar = Global.dtSideTileBar;
            this.sideTileBarControl_workState._initSideTileBar("LineNO", "LineName", "DeviceTotalNum");
            this.sideTileBarControl_workState._setNum("000", "20");
        }

        //总览数据源绑定表
        public void initDataOverviewWorkState()
        {
            Global._init_dtOverviewWorkState();
            gridControl_overview.DataSource = Global.dtOverviewWorkState;   //绑定总览的数据表
        }

        //每条产线数据源绑定表
        public void initDataEachWorkState()
        {
            Global._init_dtEachProductionLineWorkState();
            gridControl_each.DataSource = Global.dtEachProductionLineWorkState; //绑定每条产线的数据表
        }

        //该事件可自定义tileView中所有tile
        //根据数据修改每条记录的颜色
        private void tileView_overview_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;
            //e为tileview，RowHandle为选中的tile的index，每个tile是表格的一行
            //GetRowCellValue返回tileView绑定的数据源的某一列的值，类型object
            if ((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["LineStatus"]) == "正常")
            {
                e.Item.AppearanceItem.Normal.BackColor = colorNormal;
            }
            else if((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["LineStatus"]) == "异常")
            {
                e.Item.AppearanceItem.Normal.BackColor = colorAbnormal;
            }
            else if((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["LineStatus"]) == "无效")
            {
                e.Item.AppearanceItem.Normal.BackColor = colorDisable;
            }

        }

        //总览页面内双击tile，侧边栏对应按钮被选中，跳转到对应产线页面
        private void tileView_overview_DoubleClick(object sender, EventArgs e)
        {
            int[] index = this.tileView_overview.GetSelectedRows(); //返回被选中tile的index
            foreach(var i in index)
            {
                this.sideTileBarControl_workState._selectedItem(i + 1);
            }
        }

        //由选择的产线ID更新dtEachProductionLineWorkState，使得选中不同产线显示对应数据
        private void _refreshDtEachProductionLineWorkState(string ProductionLineTag)
        {

        }

        //按下侧边栏显示相应产线的数据
        private void sideTileBarControl1_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            _refreshDtEachProductionLineWorkState(this.sideTileBarControl_workState.tagSelectedItem);
            string selectedPageTag = this.sideTileBarControl_workState.tagSelectedItem;  //选中侧边栏哪个按钮
            if (selectedPageTag == "0")
            {
                this.navigationFrame_workState.SelectedPage = this.navigationPage_overview; //若当前选中的是总览按钮则显示Page_overview
            }
            else
            {
                this.navigationFrame_workState.SelectedPage = this.navigationPage_each; //若当前选中的不是总览按钮则显示Page_each
            }
        }

        ////imageSlider滑动图片更改each页面GridControl绑定的datatable
        //private void imageSlider_each_ImageChanged(object sender, DevExpress.XtraEditors.Controls.ImageChangedEventArgs e)
        //{
        //    if (this.imageSlider_each.CurrentImageIndex == 0)
        //    {
        //        gridControl_each.DataSource = Global.dtEachProductionLineWorkState;
        //    }else if (this.imageSlider_each.CurrentImageIndex == 1)
        //    {
        //        gridControl_each.DataSource = Global.dtEachProductionLineWorkState;
        //    }
        //}

        //更改each页面每个tile的颜色
        private void tileView_each_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;

            if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["DeviceStatus"]) == "正常")
            {
                e.Item.AppearanceItem.Normal.BackColor = colorNormal;

            }
            else if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["DeviceStatus"]) == "异常")
            {
                e.Item.AppearanceItem.Normal.BackColor = colorAbnormal;


            }
            else if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["DeviceStatus"]) == "无效")
            {
                e.Item.AppearanceItem.Normal.BackColor = colorDisable;
            }

        }

    }
}
