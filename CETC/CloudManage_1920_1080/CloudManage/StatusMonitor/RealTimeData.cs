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
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace CloudManage
{
    public partial class RealTimeDataControl : DevExpress.XtraEditors.XtraUserControl
    {
        string labelDirImgType = "——实时";    //imageSlider当前图片类型：实时、缺陷
        Color colorNormal = Color.Gray;
        Color colorAlert = Color.FromArgb(208, 49, 68);
        private DataTable dtParaVal = new DataTable();              //从device_info中查出的一行的原始数据，参数值
        private DataTable dtParaNameAndSuffix = new DataTable();    //参数名、参数单位
        private DataTable dtGridDataSource = new DataTable();       //改变数据显示形式，将一行变为若干行，最终绑定到grid上的dt
        private DataRow drParaThreshold;                            //某台设备的参数阈值
        string lineNO_deviceNONotChanged = String.Empty;            //防止timer_devicePara_Tick中刷新dtGridDataSource时，lineNO改变了但是DeviceNO还未变，导致dtGridDataSource为空
        string deviceNO_deviceNONotChanged = String.Empty;

        struct paraThreshold
        {
            public string lowerLimit;
            public string upperLimit;
        }
        paraThreshold[] paraThresholdList = new paraThreshold[64];

        public RealTimeDataControl()
        {
            InitializeComponent();
            initRealTime();
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal+=5);

        }

        void initRealTime()
        {
            _initSideTileBarWithSub();  //初始化侧边栏
            Global._init_dtDeviceInfoThresholdAndLocation();
            initDataSource();
            initImgSlider();
            lineNO_deviceNONotChanged = this.sideTileBarControlWithSub_realTimeData.tagSelectedItem;
            deviceNO_deviceNONotChanged = this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub;
            DeviceManagement.MonitorThreshold.paraLimitsChangedExists += new CloudManage.DeviceManagement.MonitorThreshold.ParaLimitsChangedHanlder(monitorThreshold_paraLimitsChanged);
            StatusMonitor.WorkState.DoubleClickTileViewEach += new StatusMonitor.WorkState.TileViewEachDoubleClick(workStateDoubleClickTileViewEach);
        }

        private void initDataSource()
        {
            if (Global.dtDeviceConfig.Rows.Count != 0)
            {
                string DeviceNOTemp = String.Empty;
                string firstLineNO = String.Empty;
                firstLineNO = Global.dtDeviceConfig.Rows[0]["LineNO"].ToString();
                string[] cols = Global.GetColumnsByDataTable(Global.dtDeviceConfig);

                for (int i = 2; i < Global.dtDeviceConfig.Columns.Count; i++)
                {
                    if (Global.dtDeviceConfig.Rows[0][i].ToString() == "1")
                    {
                        DeviceNOTemp = cols[i];
                        break;
                    }
                }
                string firstDeviceNO = String.Empty;
                for (int i = 0; i < DeviceNOTemp.Length; i++)
                {
                    if (DeviceNOTemp.ElementAt(i) >= '0' && DeviceNOTemp.ElementAt(i) <= '9')
                    {
                        firstDeviceNO += DeviceNOTemp.ElementAt(i);
                    }
                }
                getDataSource(firstLineNO, firstDeviceNO);
                refreshParaLimits(firstLineNO, firstDeviceNO);
                this.gridControl_rightSide.DataSource = this.dtGridDataSource;
            }
        }

        private void getDataSource(string selectedItemTag, string selectedItemSubTag)
        {
            this.dtGridDataSource.Rows.Clear();

            //查询设备参数值
            string cmdInitDtParaVal = "SELECT * FROM device_info " +
                                                 "WHERE LineNO='" + selectedItemTag + "' AND " +
                                                 "DeviceNO='" + selectedItemSubTag + "';";
            Global._initDtMySQL(ref this.dtParaVal, cmdInitDtParaVal);
            //查询设备参数名称、单位
            string cmdInitDtParaNameAndSuffix = "SELECT * FROM device_info_paranameandsuffix " +
                                                "WHERE LineNO='" + selectedItemTag + "' AND " +
                                                "DeviceNO='" + selectedItemSubTag + "';";
            Global._initDtMySQL(ref this.dtParaNameAndSuffix, cmdInitDtParaNameAndSuffix);


            if (this.dtGridDataSource.Columns.Count == 0)
            {
                this.dtGridDataSource.Columns.Add("NO", typeof(String));    //NO字段是为了在refreshGrid通过Global.reorderDt更新NO从而触发ItemCustomize
                this.dtGridDataSource.Columns.Add("paraName", typeof(String));
                this.dtGridDataSource.Columns.Add("paraVal", typeof(String));
            }

            if (this.dtParaVal.Rows.Count == 1 && this.dtParaNameAndSuffix.Rows.Count == 1)
            {
                int validParaCount = Convert.ToInt32(this.dtParaVal.Rows[0]["ValidParaCount"]);
                for (int i = 0; i < validParaCount; i++)
                {
                    DataRow drrPara = this.dtGridDataSource.NewRow();
                    string paraCol = "Para" + (i + 1).ToString();
                    string paraNameCol = "Para" + (i + 1).ToString() + "Name";
                    string paraSuffixCol = "Para" + (i + 1).ToString() + "Suffix";
                    drrPara["paraVal"] = this.dtParaVal.Rows[0][paraCol].ToString() + this.dtParaNameAndSuffix.Rows[0][paraSuffixCol].ToString();               //赋值参数值，含有单位
                    drrPara["paraName"] = this.dtParaNameAndSuffix.Rows[0][paraNameCol].ToString();    //赋值参数名
                    drrPara["NO"] = i + 1;
                    this.dtGridDataSource.Rows.Add(drrPara);
                }
            }
            
        }

        ////刷新目录：产线
        //void refreshLabelDirLine()
        //{
        //    string str1 = Global._getProductionLineNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem);
        //    if (str1 == "总览")
        //        str1 = "";
        //    this.labelControl_dir.Text = "   " + str1;
        //}

        ////刷新目录：设备
        //public void refreshLabelDirDevice()
        //{
        //    DataRow[] dr = Global.dtSideTileBar.Select("LineNO='" + this.sideTileBarControlWithSub_realTimeData.tagSelectedItem + "'");
        //    if (dr.Length == 1)
        //    {
        //        if (Convert.ToInt32(dr[0]["DeviceTotalNum"]) != 0)
        //        {
        //            string str2 = Global._getTestingDeviceNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);
        //            this.labelControl_dir.Text += "——" + str2;
        //        }
        //    }
        //}

        void _refreshLabelDir()
        {
            string str1 = Global._getProductionLineNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem);
            string str2 = Global._getTestingDeviceNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);
            if(str1 == "总览" && str2 == "所有设备")
            {
                this.labelControl_dir.Text = "";
            }
            else
            {
                this.labelControl_dir.Text = "   " + str1 + "——" + str2 + labelDirImgType;
            }
        }

        //刷新选中设备的阈值
        public void refreshParaLimits(string selectedItemTag, string selectedItemSubTag)
        {
            Global._init_dtDeviceInfoThresholdAndLocation();

            DataRow[] drr = Global.dtDeviceInfoThresholdAndLocation.Select("LineNO='" + selectedItemTag + "' AND DeviceNO='" + selectedItemSubTag + "'");
            int validParaCount = 0;
            if (this.dtParaNameAndSuffix.Rows.Count == 1)
            {
                validParaCount = Convert.ToInt32(this.dtParaNameAndSuffix.Rows[0]["ValidParaCount"]);
            }
            if (drr.Length == 1)
            {
                this.drParaThreshold = drr[0];
                for(int i=0;i< validParaCount; i++)
                {
                    this.paraThresholdList[i].lowerLimit = this.drParaThreshold[7 + 2 * i].ToString();
                    this.paraThresholdList[i].upperLimit = this.drParaThreshold[8 + 2 * i].ToString();
                }

            }
        }


        //强制触发itemCustomize刷新
        public void refreshGrid()
        {
            //if (this.dtGridDataSource.Rows.Count != 0)
            //{
            //    for(int i = 0; i < this.dtGridDataSource.Rows.Count; i++)
            //    {
            //        string colTemp = this.dtGridDataSource.Rows[i]["ParaName"].ToString();
            //        //this.dtGridDataSource.Rows[0]["ParaName"] = "强制刷新grid";
            //        this.dtGridDataSource.Rows[i]["ParaName"] = colTemp;
            //    }
            //}
            Global.reorderDt(ref this.dtGridDataSource);
        }

        //初始化子菜单
        void _initSideTileBarWithSub()
        {
            this.sideTileBarControlWithSub_realTimeData.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_realTimeData.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_realTimeData.colTextDT = "LineName";
            this.sideTileBarControlWithSub_realTimeData.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_realTimeData.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_realTimeData.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_realTimeData.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_realTimeData._initSideTileBarWithSub();
        }

        //设定圆点位置
        void setPicDeviceLocation()
        {
            int posX = Convert.ToInt32(this.drParaThreshold["LocationX"]);
            int posY = Convert.ToInt32(this.drParaThreshold["LocationY"]);
            this.pictureEdit_deviceLocation.Location = new System.Drawing.Point(posX, posY);
        }

        void initImgSlider()
        {
            this.imageSlider_camera.Images.Add(global::CloudManage.Properties.Resources.camera0);
            this.imageSlider_camera.Images.Add(global::CloudManage.Properties.Resources.camera1);
        }

        //没有所有设备，所有点击产线不默认选中子菜单
        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedItem_1(object sender, EventArgs e)
        {
        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            lineNO_deviceNONotChanged = this.sideTileBarControlWithSub_realTimeData.tagSelectedItem;    //选中device后，将tagSelectedItemSub改变后，才更新表
            deviceNO_deviceNONotChanged = this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub;
            if (lineNO_deviceNONotChanged != "000")
            {
                //refreshLabelDirDevice();
                _refreshLabelDir();
                this.getDataSource(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem, this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);    //改變rightGrid綁定的dtGridDataSource
                refreshParaLimits(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem, this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);     //刷新對應設備的閾值
                setPicDeviceLocation(); //根据选中的设备设定位置
            }
        }

        private void imageSlider_camera_ImageChanged(object sender, DevExpress.XtraEditors.Controls.ImageChangedEventArgs e)
        {
            if (this.imageSlider_camera.CurrentImageIndex == 0)
            {
                this.labelDirImgType = "——实时";
            }
            else if (this.imageSlider_camera.CurrentImageIndex == 1)
            {
                this.labelDirImgType = "——缺陷";
            }
            _refreshLabelDir();
        }

        //给右侧数据上色，绑定gridcontrol的表发生改变时自动对每条记录执行一次
        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;

            int paraIndex = e.RowHandle;
            string parameterVal = this.dtParaVal.Rows[0]["Para" + (paraIndex + 1).ToString()].ToString();
            if (Convert.ToDouble(parameterVal) < Convert.ToDouble(paraThresholdList[paraIndex].lowerLimit) || Convert.ToDouble(parameterVal) > Convert.ToDouble(paraThresholdList[paraIndex].upperLimit))
            {
                e.Item.AppearanceItem.Normal.BackColor = colorAlert;
                e.Item.AppearanceItem.Focused.BackColor = colorAlert;
            }
            else
            {
                e.Item.AppearanceItem.Normal.BackColor = colorNormal;
                e.Item.AppearanceItem.Focused.BackColor = colorNormal;
            }
        }

        private void timer_deviceLocation_Tick(object sender, EventArgs e)
        {
            this.pictureEdit_deviceLocation.Visible = !this.pictureEdit_deviceLocation.Visible;
        }


        private void monitorThreshold_paraLimitsChanged(object sender, EventArgs e)
        {
            refreshParaLimits(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem, this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);     //刷新對應設備的閾值
            refreshGrid();      //dtGridDataSource未变所以需要强制刷新
        }

        private void workStateDoubleClickTileViewEach(object sender, EventArgs e)
        {
            sideTileBarControlWithSub1_sideTileBarItemWithSubClickedSubItem(sender, e);
        }

        private void timer_devicePara_Tick(object sender, EventArgs e)
        {
            //选中产线、未选中设备时不刷新表。选中产线且选中设备时才刷新表
            this.getDataSource(lineNO_deviceNONotChanged, deviceNO_deviceNONotChanged);    
        }

    }
}
