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
using DevExpress.XtraSplashScreen;

namespace CloudManage.StatusMonitor
{
    public partial class WorkState : DevExpress.XtraEditors.XtraUserControl
    {
        //状态颜色
        Color colorNormal = Color.FromArgb(56, 152, 83);
        Color colorAbnormal = Color.FromArgb(208, 49, 68);
        Color colorDisable = Color.FromArgb(120, 120, 120);

        private int[] selectRowGridControlEach = { 0 };   //手动记录Each中被选中tile


        public WorkState()
        {
            InitializeComponent();
            initWorkState();
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);
        }

        void initWorkState()
        {
            initSideTileBarWorkState();     //初始化侧边栏
            initDataOverviewWorkState();    //初始化总览数据表
            initDataEachWorkState();        //初始化检测设备数据表
        }

        public void initSideTileBarWorkState()
        {
            this.sideTileBarControl_workState.dtInitSideTileBar = Global.dtSideTileBar;
            this.sideTileBarControl_workState.colTagDT = "LineNO";
            this.sideTileBarControl_workState.colTextDT = "LineName";
            this.sideTileBarControl_workState.colNumDT = "DeviceTotalNum";
            this.sideTileBarControl_workState._initSideTileBar();
        }

        //使tileview中被选中的Tile不被表数据发生更改影响
        private void refreshSelectRowControlEach()
        {
            if (selectRowGridControlEach.Length == 1)
            {
                this.tileView_each.FocusedRowHandle = selectRowGridControlEach[0];
            }
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
            Global._init_dtEachProductionLineWorkState("001");   
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
            if((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["LineName"]) == "未定义")
            {
                e.Item.AppearanceItem.Normal.BackColor = colorDisable;
            }
            else
            {
                if ((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["LineStatus"]) == "正常")
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorNormal;
                }
                else if ((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["LineStatus"]) == "异常")
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorAbnormal;
                }
                //else if ((string)tileView_overview.GetRowCellValue(e.RowHandle, tileView_overview.Columns["LineStatus"]) == "未定义")
                //{
                //    e.Item.AppearanceItem.Normal.BackColor = colorDisable;
                //}
            }
        }

        //总览页面内双击tile，侧边栏对应按钮被选中，跳转到对应产线页面
        private void tileView_overview_DoubleClick(object sender, EventArgs e)
        {
            int[] index = { 0 };
            if (((DataTable)this.gridControl_overview.DataSource).Rows.Count > 0)
            {
                index = this.tileView_overview.GetSelectedRows(); //返回被选中tile的index
            }
            foreach(var i in index)
            {
                this.sideTileBarControl_workState._selectedItem(i + 1);
            }
        }


        /**************************************************************双击TileEach跳转RealTime并显示对应设备的实时参数*******************************************************/
        //封装要传递的参数，可传递多个参数
        public class LineNOAndDeviceNO
        {
            public string LineNO { get; set; }
            public string DeviceNO { get; set; }
        }

        //事件参数类MyTEventArgs，泛型，
        public class MyTEventArgs<T> : EventArgs
        {
            public T param;
            public MyTEventArgs(T t)
            {
                param = t;
            }
        }

        //封装事件、事件触发函数
        public class DoubleClickTileViewEach
        {
            public string lineNO { get; set; }
            public string deviceNO { get; set; }

            public DoubleClickTileViewEach(string ln, string dn)
            {
                this.lineNO = ln;
                this.deviceNO = dn;
            }

            public event Action<object, MyTEventArgs<LineNOAndDeviceNO>> MyDoubleClickTileViewEach;

            //public void setMyDoubleClickTileViewEachHandler(System.Action<object, Global.MyTEventArgs<Global.LineNOAndDeviceNO>> action)  //将函数作为实参传入
            //{
            //    this.MyDoubleClickTileViewEach += action;
            //}
            public void AckEvent()
            {
                //激发事件
                MyDoubleClickTileViewEach.Invoke(this, new MyTEventArgs<LineNOAndDeviceNO>(new LineNOAndDeviceNO() { LineNO = this.lineNO, DeviceNO = this.deviceNO }));
            }
        }

        public static DoubleClickTileViewEach doubleClickTileViewEach;  //传参
        public delegate void DoubleClickTileViewEach_(object sender, EventArgs e);
        public static event DoubleClickTileViewEach_ doubleClickTileViewEach_;  //传双击事件
        //Each页面内双击设备对应tile，跳转到实时页面并显示对应的设备的参数
        public void tileView_each_DoubleClick(object sender, EventArgs e)
        {
            selectRowGridControlEach = this.tileView_each.GetSelectedRows();    //双击时更新当前选中Tile
            DataRow drGridEach = this.tileView_each.GetDataRow(this.tileView_each.FocusedRowHandle);    //获取被选中EachTile对应设备的在表dtEachProductionLineWorkState中的数据

            doubleClickTileViewEach = new DoubleClickTileViewEach(this.sideTileBarControl_workState.tagSelectedItem, drGridEach["DeviceNO"].ToString());    //创建事件对象
            doubleClickTileViewEach_(sender, new EventArgs());
            //doubleClickTileViewEach.MyDoubleClickTileViewEach += workStateDoubleClickTileViewEach;

            doubleClickTileViewEach.AckEvent();
        }

        private void tileView_each_Click(object sender, EventArgs e)
        {
            selectRowGridControlEach = this.tileView_each.GetSelectedRows();     //单击时更新当前选中Tile
        }

        /******************************************************************************************************************************************************************/
        
        
        //按下侧边栏显示相应产线的数据
        private void sideTileBarControl1_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            string selectedPageTag = this.sideTileBarControl_workState.tagSelectedItem;  //选中侧边栏哪个按钮
            if (selectedPageTag == "000")
            {
                this.navigationFrame_workState.SelectedPage = this.navigationPage_overview; //若当前选中的是总览按钮则显示Page_overview
            }
            else
            {
                object o = this.tileView_each.FocusedValue;

                Global.dtEachProductionLineWorkState.Rows.Clear();  //清空表数据
                Global._init_dtEachProductionLineWorkState(this.sideTileBarControl_workState.tagSelectedItem);  //重新查询
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

            if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["DeviceName"]) == "未定义")
            {
                e.Item.AppearanceItem.Normal.BackColor = colorDisable;
            }
            else
            {
                if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["DeviceStatus"]) == "正常")
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorNormal;

                }
                else if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["DeviceStatus"]) == "异常")
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorAbnormal;
                }
                //else if ((string)tileView_each.GetRowCellValue(e.RowHandle, tileView_each.Columns["DeviceStatus"]) == "无效")
                //{
                //    e.Item.AppearanceItem.Normal.BackColor = colorDisable;
                //}
            }
        }

        //刷新实时数据
        private void timer_devicePara_Tick(object sender, EventArgs e)
        {
            //使用触发器？但是从表中读生成dtEachProductionLineWorkState的过程挺复杂，写成存储过程，通过触发器调用可能也比较耗费资源、而且把问题复杂化了
            Global.dtEachProductionLineWorkState.Rows.Clear();  //清空表数据
            Global._init_dtEachProductionLineWorkState(this.sideTileBarControl_workState.tagSelectedItem);  //重新查询
            refreshSelectRowControlEach();  //更新了表dtEachProductionLineWorkState，重新选中selectedTile
        }

        
    }
}
