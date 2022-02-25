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
        public static ushort currentPageIndex = 0;        //WorkState页面在所有页面中的index，供SetBitValueInt64使用

        //状态颜色
        Color colorNormal = Color.FromArgb(56, 152, 83);
        Color colorAbnormal = Color.FromArgb(208, 49, 68);
        Color colorDisable = Color.FromArgb(120, 120, 120);

        private int[] selectRowGridControlEach = { 0 };   //手动记录Each中被选中tile
        private int[] selectRowGridControlOverview = { 0 }; //手动记录总览中被选中的tile

        public WorkState()
        {
            InitializeComponent();
            initWorkState();
            MainForm.deviceOrLineAdditionDeletionReinitWorkState += reInitWorkState;
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);
        }

        void initWorkState()
        {
            initSideTileBarWorkState();     //初始化侧边栏
            initDataOverviewWorkState();    //初始化总览数据表
            initDataEachWorkState();        //初始化检测设备数据表
        }

        public void reInitWorkState(object sender, EventArgs e)
        {
            MessageBox.Show("重新刷新WorkState页面");
            initWorkState();
            Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = Global.SetBitValueInt32(Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion, currentPageIndex, false);  //刷新页面后将该页面的标志位重置
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

        private void refreshSelectRowControlOverview()
        {
            if (selectRowGridControlOverview.Length == 1)
            {
                this.tileView_overview.FocusedRowHandle = selectRowGridControlOverview[0];
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
            selectRowGridControlOverview = this.tileView_overview.GetSelectedRows();    //双击时更新当前选中Tile
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

        //总览页面单击tile
        private void tileView_overview_Click(object sender, EventArgs e)
        {
            selectRowGridControlOverview = this.tileView_overview.GetSelectedRows();    //双击时更新当前选中Tile
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
            if (drGridEach["DeviceName"].ToString()!="未定义")
            {
                doubleClickTileViewEach = new DoubleClickTileViewEach(this.sideTileBarControl_workState.tagSelectedItem, drGridEach["DeviceNO"].ToString());    //创建事件对象
                doubleClickTileViewEach_(sender, new EventArgs());
                //doubleClickTileViewEach.MyDoubleClickTileViewEach += workStateDoubleClickTileViewEach;

                doubleClickTileViewEach.AckEvent();
            }
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
                Global._init_dtEachProductionLineWorkState(this.sideTileBarControl_workState.tagSelectedItem);  //重新查询，刷新每台设备的状态
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

        //private void refreshDeviceStatus()
        //{
        //    string lineNO = String.Empty;
        //    string deviceNO = String.Empty;
        //    string cmdDeviceHasFault = String.Empty;
        //    DataTable dtDeviceHasFault = new DataTable();

        //    for (int i = 0; i < dtDeviceInfo.Rows.Count; i++)
        //    {
        //        lineNO = dtDeviceInfo.Rows[i]["LineNO"].ToString();
        //        deviceNO = dtDeviceInfo.Rows[i]["DeviceNO"].ToString();

        //        cmdDeviceHasFault = "SELECT COUNT(*) AS faultsCount FROM faults_current WHERE LineNO='" + lineNO + "' AND DeviceNO='" + deviceNO + "';";
        //        Global.mysqlHelper1._queryTableMySQL(cmdDeviceHasFault, ref dtDeviceHasFault);
        //        if (dtDeviceHasFault.Rows.Count == 1)
        //        {
        //            if (Convert.ToInt32(dtDeviceHasFault.Rows[0]["faultsCount"]) == 0 && dtDeviceInfo.Rows[i]["DeviceStatus"].ToString() == "0")
        //            {
        //                string cmdUpdateDeviceInfo = "UPDATE device_info SET DeviceStatus='1' WHERE LineNO='" + lineNO + "' AND DeviceNO='" + deviceNO + "';";
        //                Global.mysqlHelper1._updateMySQL(cmdUpdateDeviceInfo);
        //            }
        //            else if (Convert.ToInt32(dtDeviceHasFault.Rows[0]["faultsCount"]) > 0 && dtDeviceInfo.Rows[i]["DeviceStatus"].ToString() == "1")
        //            {
        //                string cmdUpdateDeviceInfo = "UPDATE device_info SET DeviceStatus='0' WHERE LineNO='" + lineNO + "' AND DeviceNO='" + deviceNO + "';";
        //                Global.mysqlHelper1._updateMySQL(cmdUpdateDeviceInfo);
        //            }
        //        }

        //    }
        //}

        //刷新实时数据
        private void timer_devicePara_Tick(object sender, EventArgs e)
        {
            Global.dtOverviewWorkState.Rows.Clear();    //清空产线表
            Global._init_dtOverviewWorkState();         //刷新产线状态
            refreshSelectRowControlOverview();          //令tileview_overview中选中的tile不因绑定dt的变化而变化

            Global.dtEachProductionLineWorkState.Rows.Clear();  //清空表数据
            Global._init_dtEachProductionLineWorkState(this.sideTileBarControl_workState.tagSelectedItem);  //刷新每台设备的状态
            refreshSelectRowControlEach();  //令tileview_each中选中的tile不因绑定dt的变化而变化
        }

        
    }
}
