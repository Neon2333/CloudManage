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
        }

        void initRealTime()
        {
            _initSideTileBarWithSub();  //初始化侧边栏
            Global._init_dtDeviceInfoThresholdAndLocation();
            initDataSource();
            initImgSlider();

            DeviceManagement.MonitorThreshold.paraLimitsChangedExists += new CloudManage.DeviceManagement.MonitorThreshold.ParaLimitsChangedHanlder(monitorThreshold_paraLimitsChanged);
        }

        private void initDataSource()
        {
            string DeviceNOTemp = String.Empty;
            string firstLineNO = String.Empty;
            if (Global.dtDeviceConfig.Rows.Count != 0)  //防止单独打开StatusMonitor设计器时，Global.dtDeviceConfig未初始化，导致出错
            {
                firstLineNO = Global.dtDeviceConfig.Rows[0]["LineNO"].ToString();
            }
            string[] cols = Global.GetColumnsByDataTable(Global.dtDeviceConfig);
            for(int i = 2; i < Global.dtDeviceConfig.Columns.Count; i++)
            {
                if(Global.dtDeviceConfig.Rows[0][i].ToString() == "1")
                {
                    DeviceNOTemp = cols[i];
                    break;
                }
            }
            string firstDeviceNO = String.Empty;
            for(int i = 0; i < DeviceNOTemp.Length; i++)
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

        private void getDataSource(string selectedItemTag, string selectedItemSubTag)
        {
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

            this.dtGridDataSource.Rows.Clear();

            if (this.dtGridDataSource.Columns.Count == 0)
            {
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
                    this.dtGridDataSource.Rows.Add(drrPara);
                }
            }
            
        }

        //刷新目录
        void refreshLabelDir()
        {
            //实时页面的侧边栏没有总览、全部设备，默认是000-000，初始化时不刷新导航栏
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2 + labelDirImgType;
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
                    this.paraThresholdList[i].lowerLimit = this.drParaThreshold[6 + 2 * i].ToString();
                    this.paraThresholdList[i].upperLimit = this.drParaThreshold[7 + 2 * i].ToString();
                }

            }
        }

        //强制触发itemCustomize刷新
        public void refreshGrid()
        {
            if (this.dtGridDataSource.Rows.Count != 0)
            {
                for(int i = 0; i < this.dtGridDataSource.Rows.Count; i++)
                {
                    string colTemp = this.dtGridDataSource.Rows[i]["ParaName"].ToString();
                    //this.dtGridDataSource.Rows[0]["ParaName"] = "强制刷新grid";
                    this.dtGridDataSource.Rows[i]["ParaName"] = colTemp;
                }
            }
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

        private string _getProductionLineNameByTag(string tagProductionLine)
        {
            //dtProductionLine中没有Tag==0的记录
            if (tagProductionLine == "000")
            {
                return "总览";
            }

            string temp = "LineNO=" + "'" + tagProductionLine + "'";
            DataRow[] rowPL = Global.dtProductionLine.Select(temp);
            if (rowPL.Length == 1)
            {
                return (string)rowPL[0]["LineName"];
            }
            else
            {
                return "产线名称查询错误...";
            }
        }

        private string _getTestingDeviceNameByTag(string tagTestingDeviceName)
        {
            if (tagTestingDeviceName == "000")
            {
                return "所有设备";
            }

            string temp = "DeviceNO=" + "'" + tagTestingDeviceName + "'";
            DataRow[] rowTD = Global.dtTestingDeviceName.Select(temp);
            if (rowTD.Length == 1)
            {
                return (string)rowTD[0]["DeviceName"];
            }
            else
            {
                return "产线名称查询错误...";
            }
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

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedItem_1(object sender, EventArgs e)
        {
            //refreshLabelDir();
        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            refreshLabelDir();
            this.getDataSource(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem, this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);    //改變rightGrid綁定的dtGridDataSource
            refreshParaLimits(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem, this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);     //刷新對應設備的閾值
            setPicDeviceLocation(); //根据选中的设备设定位置
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
            refreshLabelDir();
        }

        //给右侧数据上色，绑定gridcontrol的表发生改变时自动对每条记录执行一次
        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;

            int paraIndex = e.RowHandle;
            string parameterVal = this.dtParaVal.Rows[0]["Para" + (paraIndex + 1).ToString()].ToString();
            if (Convert.ToInt32(parameterVal) < Convert.ToInt32(paraThresholdList[paraIndex].lowerLimit) || Convert.ToInt32(parameterVal) > Convert.ToInt32(paraThresholdList[paraIndex].upperLimit))
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
            refreshGrid();
        }

    }
}
