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
        private DataTable dtGridDataSourceTemp = new DataTable();
        private DataTable dtGridDataSource = new DataTable();
        private DataRow drParaLimits;

        string testingNumMin = String.Empty;
        string testingNumMax = String.Empty;
        string defectNumMin = String.Empty;
        string defectNumMax = String.Empty;
        string CPUTemperatureMin = String.Empty;
        string CPUTemperatureMax = String.Empty;
        string CPUUsageMin = String.Empty;
        string CPUUsageMax = String.Empty;
        string memoryUsageMin = String.Empty;
        string memoryUsageMax = String.Empty;


        public RealTimeDataControl()
        {
            InitializeComponent();
            initRealTime();
        }

        void initRealTime()
        {
            _initSideTileBarWithSub();  //初始化侧边栏
            Global._init_dtDeviceInfoLimitsAndLocation();
            initDataSource();
            initImgSlider();
        }

        private void initDataSource()
        {
            string DeviceNOTemp = String.Empty;
            string firstLineNO = Global.dtDeviceConfig.Rows[0]["LineNO"].ToString();
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
            string cmdInitDtEachProductionLineWorkState = "SELECT t1.DeviceNO,t2.DeviceName, " +
                                                          "(CASE WHEN t1.DeviceStatus=1 THEN '正常' " +
                                                          "WHEN t1.DeviceStatus=0 THEN '异常' " +
                                                          "END) AS DeviceStatus," +
                                                          "t1.TestingNum,t1.DefectNum, " +
                                                          "CONCAT(t1.CPUTemperature,'℃') AS CPUTemperature,CONCAT(t1.CPUUsage,'%') AS CPUUsage,CONCAT(t1.MemoryUsage,'%') AS MemoryUsage " +
                                                          "FROM device_info AS t1 INNER JOIN device AS t2 " +
                                                          "ON t1.DeviceNO=t2.DeviceNO " +
                                                          "WHERE t1.LineNO='" + selectedItemTag +
                                                          "' AND t1.DeviceNO='" + selectedItemSubTag +
                                                          "' ORDER BY t1.`NO`;";
            Global._initDtMySQL(ref this.dtGridDataSourceTemp, cmdInitDtEachProductionLineWorkState);
            
            this.dtGridDataSource.Rows.Clear();

            if (this.dtGridDataSource.Columns.Count == 0)
            {
                this.dtGridDataSource.Columns.Add("paraName", typeof(String));
                this.dtGridDataSource.Columns.Add("paraVal", typeof(String));
            }

            DataRow drrTestingNum = this.dtGridDataSource.NewRow();
            drrTestingNum["paraName"] = "检测数量";
            drrTestingNum["paraVal"] = this.dtGridDataSourceTemp.Rows[0]["TestingNum"];
            this.dtGridDataSource.Rows.Add(drrTestingNum);

            DataRow drrDefectNum = this.dtGridDataSource.NewRow();
            drrDefectNum["paraName"] = "缺陷数量";
            drrDefectNum["paraVal"] = this.dtGridDataSourceTemp.Rows[0]["DefectNum"];
            this.dtGridDataSource.Rows.Add(drrDefectNum);

            DataRow drrCPUTemperature = this.dtGridDataSource.NewRow();
            drrCPUTemperature["paraName"] = "CPU温度";
            drrCPUTemperature["paraVal"] = this.dtGridDataSourceTemp.Rows[0]["CPUTemperature"];
            this.dtGridDataSource.Rows.Add(drrCPUTemperature);

            DataRow drrCPUUsage = this.dtGridDataSource.NewRow();
            drrCPUUsage["paraName"] = "CPU利用率";
            drrCPUUsage["paraVal"] = this.dtGridDataSourceTemp.Rows[0]["CPUUsage"];
            this.dtGridDataSource.Rows.Add(drrCPUUsage);

            DataRow drrMemoryUsage = this.dtGridDataSource.NewRow();
            drrMemoryUsage["paraName"] = "内存利用率";
            drrMemoryUsage["paraVal"] = this.dtGridDataSourceTemp.Rows[0]["MemoryUsage"];
            this.dtGridDataSource.Rows.Add(drrMemoryUsage);
        }

        //刷新目录
        void refreshLabelDir()
        {
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2 + labelDirImgType;
        }

        void refreshParaLimits(string selectedItemTag, string selectedItemSubTag)
        {
            DataRow[] drr = Global.dtDeviceInfoLimitsAndLocation.Select("LineNO='" + selectedItemTag + "' AND DeviceNO='" + selectedItemSubTag + "'");
            if (drr.Length == 1)
            {
                this.drParaLimits = drr[0];
                this.testingNumMin = drParaLimits["TestingNumMin"].ToString();
                this.testingNumMax = drParaLimits["TestingNumMax"].ToString();
                this.defectNumMin = drParaLimits["DefectNumMin"].ToString();
                this.defectNumMax = drParaLimits["DefectNumMax"].ToString();
                this.CPUTemperatureMin = drParaLimits["CPUTemperatureMin"].ToString();
                this.CPUTemperatureMax = drParaLimits["CPUTemperatureMax"].ToString();
                this.CPUUsageMin = drParaLimits["CPUUsageMin"].ToString();
                this.CPUUsageMax = drParaLimits["CPUUsageMax"].ToString();
                this.memoryUsageMin = drParaLimits["MemoryUsageMin"].ToString();
                this.memoryUsageMax = drParaLimits["MemoryUsageMax"].ToString();
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
            //DataRow[] drr = Global.dtDeviceInfoLimitsAndLocation.Select("LineNO='" + this.sideTileBarControlWithSub_realTimeData.tagSelectedItem + "' AND DeviceNO='" + this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub + "'");
            //posX += this.pictureEdit_device.Location.X;
            //posY += this.pictureEdit_device.Location.Y;
            int posX = Convert.ToInt32(this.drParaLimits["LocationX"]);
            int posY = Convert.ToInt32(this.drParaLimits["LocationY"]);
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
            this.getDataSource(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem, this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);
            refreshParaLimits(this.sideTileBarControlWithSub_realTimeData.tagSelectedItem, this.sideTileBarControlWithSub_realTimeData.tagSelectedItemSub);
            setPicDeviceLocation();
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

        //给右侧数据上色，自动对绑定gridcontrol的每条记录执行一遍
        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;

            string parameterName = (string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["paraName"]);
            string parameterVal = (string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["paraVal"]);

            if(parameterName == "检测数量")
            {
                if(Convert.ToInt32(parameterVal) < Convert.ToInt32(testingNumMin) || Convert.ToInt32(parameterVal) > Convert.ToInt32(testingNumMax))
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorAlert;
                    e.Item.AppearanceItem.Focused.BackColor = colorAlert;
                }
                else
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorNormal;
                }
            }

            if (parameterName == "缺陷数量")
            {
                if (Convert.ToInt32(parameterVal) < Convert.ToInt32(defectNumMin) || Convert.ToInt32(parameterVal) > Convert.ToInt32(defectNumMax))
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorAlert;
                    e.Item.AppearanceItem.Focused.BackColor = colorAlert;
                }
                else
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorNormal;
                }
            }

            if (parameterName == "CPU温度")
            {
                string parameterValTemp = String.Empty;
                for(int i = 0; i < parameterVal.Length; i++)
                {
                    if (parameterVal.ElementAt(i) >= '0' && parameterVal.ElementAt(i) <= '9')
                    {
                        parameterValTemp += parameterVal.ElementAt(i);
                    }
                }
                parameterVal = parameterValTemp;

                if (Convert.ToInt32(parameterVal) < Convert.ToInt32(CPUTemperatureMin) || Convert.ToInt32(parameterVal) > Convert.ToInt32(CPUTemperatureMax))
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorAlert;
                    e.Item.AppearanceItem.Focused.BackColor = colorAlert;
                }
                else
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorNormal;
                }
            }

            if (parameterName == "CPU利用率")
            {
                string parameterValTemp = String.Empty;
                for (int i = 0; i < parameterVal.Length; i++)
                {
                    if (parameterVal.ElementAt(i) >= '0' && parameterVal.ElementAt(i) <= '9')
                    {
                        parameterValTemp += parameterVal.ElementAt(i);
                    }
                }
                parameterVal = parameterValTemp;

                if (Convert.ToInt32(parameterVal) < Convert.ToInt32(CPUUsageMin) || Convert.ToInt32(parameterVal) > Convert.ToInt32(CPUUsageMax))
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorAlert;
                    e.Item.AppearanceItem.Focused.BackColor = colorAlert;
                }
                else
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorNormal;
                }
            }

            if (parameterName == "内存利用率")
            {
                string parameterValTemp = String.Empty;
                for (int i = 0; i < parameterVal.Length; i++)
                {
                    if (parameterVal.ElementAt(i) >= '0' && parameterVal.ElementAt(i) <= '9')
                    {
                        parameterValTemp += parameterVal.ElementAt(i);
                    }
                }
                parameterVal = parameterValTemp;

                if (Convert.ToInt32(parameterVal) < Convert.ToInt32(memoryUsageMin) || Convert.ToInt32(parameterVal) > Convert.ToInt32(memoryUsageMax))
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorAlert;
                    e.Item.AppearanceItem.Focused.BackColor = colorAlert;
                }
                else
                {
                    e.Item.AppearanceItem.Normal.BackColor = colorNormal;
                }
            }

        }

        private void timer_deviceLocation_Tick(object sender, EventArgs e)
        {
            this.pictureEdit_deviceLocation.Visible = !this.pictureEdit_deviceLocation.Visible;
        }

       
    }
}
