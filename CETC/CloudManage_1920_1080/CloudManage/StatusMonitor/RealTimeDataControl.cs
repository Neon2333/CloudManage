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
        //DataTable dtRightSideRealTimeData = new DataTable();
        string labelDirImgType = "——实时";    //imageSlider当前图片类型：实时、缺陷
        Color colorNormal = Color.Gray;
        Color colorAlert = Color.FromArgb(208, 49, 68);

        int numOfTests = 533;
        int numOfMissingBranch = 55;
        int processingTime = 20;
        int temperatureCPU = 90;
        int usageCPU = 60;
        int usageMemory = 70;

        public RealTimeDataControl()
        {
            InitializeComponent();
            initRealTime();
        }

        void initRealTime()
        {
            _initSideTileBarWithSub();  //初始化侧边栏

            initdtRightSideRealTimeData();
            initImgSlider();
        }


        //刷新目录
        void refreshLabelDir()
        {
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2 + labelDirImgType;
        }

        //初始化子菜单
        void _initSideTileBarWithSub()
        {
            this.sideTileBarControlWithSub_realTimeData.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_realTimeData.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
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
        void setPicDeviceLocation(int posX,int posY)
        {
            posX += this.pictureEdit_device.Location.X;
            posY += this.pictureEdit_device.Location.Y;
            this.pictureEdit_deviceLocation.Location = new System.Drawing.Point(posX, posY);
        }

        void initdtRightSideRealTimeData()
        {
            Global.dtRightSideRealTimeData.Columns.Add("参数名", typeof(String));
            Global.dtRightSideRealTimeData.Columns.Add("值", typeof(String));

            DataRow drRightSide1 = Global.dtRightSideRealTimeData.NewRow();
            drRightSide1[0] = "检测数量";
            drRightSide1[1] = numOfTests.ToString();
            Global.dtRightSideRealTimeData.Rows.Add(drRightSide1);

            DataRow drRightSide2 = Global.dtRightSideRealTimeData.NewRow();
            drRightSide2[0] = "缺陷数量";
            drRightSide2[1] = numOfMissingBranch.ToString();
            Global.dtRightSideRealTimeData.Rows.Add(drRightSide2);

            DataRow drRightSide3 = Global.dtRightSideRealTimeData.NewRow();
            drRightSide3[0] = "处理时间";
            drRightSide3[1] = processingTime.ToString() + "ms";
            Global.dtRightSideRealTimeData.Rows.Add(drRightSide3);

            DataRow drRightSide4 = Global.dtRightSideRealTimeData.NewRow();
            drRightSide4[0] = "CPU温度";
            drRightSide4[1] = temperatureCPU.ToString() + "℃";
            Global.dtRightSideRealTimeData.Rows.Add(drRightSide4);

            DataRow drRightSide5 = Global.dtRightSideRealTimeData.NewRow();
            drRightSide5[0] = "CPU利用率";
            drRightSide5[1] = usageCPU.ToString() + "%";
            Global.dtRightSideRealTimeData.Rows.Add(drRightSide5);
            
            DataRow drRightSide6 = Global.dtRightSideRealTimeData.NewRow();
            drRightSide6[0] = "内存利用率";
            drRightSide6[1] = usageMemory.ToString() + "%";
            Global.dtRightSideRealTimeData.Rows.Add(drRightSide6);
            
            this.gridControl_rightSide.DataSource = Global.dtRightSideRealTimeData;
        }

        void initImgSlider()
        {
            this.imageSlider_camera.Images.Add(global::CloudManage.Properties.Resources.camera0);
            this.imageSlider_camera.Images.Add(global::CloudManage.Properties.Resources.camera1);
        }


        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedItem_1(object sender, EventArgs e)
        {
            //refreshLabelDir();
            setPicDeviceLocation(100, 200);
        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            refreshLabelDir();
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

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;

            string parameterName = (string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["参数名"]);
            string parameterVal = (string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["值"]);

            if (parameterName == "CPU温度" && temperatureCPU <= 80)   //设定参数超出阈值变色报警
            {
                e.Item.AppearanceItem.Normal.BackColor = colorNormal;
            }
            else if (parameterName == "CPU温度" && temperatureCPU > 80)
            {
                e.Item.AppearanceItem.Normal.BackColor = colorAlert;
                e.Item.AppearanceItem.Focused.BackColor = colorAlert;
            }
           
        }

        private void timer_deviceLocation_Tick(object sender, EventArgs e)
        {
            this.pictureEdit_deviceLocation.Visible = !this.pictureEdit_deviceLocation.Visible;
        }

       
    }
}
