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
using System.IO;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Diagnostics;
using System.Collections;
using DevExpress.XtraEditors.Popup;

namespace CloudManage.StatusMonitor
{
    public partial class HistoryQueryControl : DevExpress.XtraEditors.XtraUserControl
    {
        public HistoryQueryControl()
        {
            InitializeComponent();
            initHistoryQuery();
        }

        void initHistoryQuery()
        {
            initDataTable();
            _initSideTileBarWithSub();  //初始化侧边栏
            Global._init_dtHistoryQueryGridShow();    //显示所有故障
            Global._init_dtHistoryQueryGridShowClickedQueryButton();   //点击查询显示时间段内的故障
            this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShow;
            _refreshTitleGridShow(10);
        }

        void initDataTable()
        {
            Global._init_dtTestingDeviceName(); //初始化检测设备名称表
            Global._init_dtProductionLine();    //初始化产线名称表
            Global._init_dtAllFaults();         //初始化故障名称表
            Global._init_dtDeviceConfig();      //初始化检测设备使能表
            Global._init_dtFaultHistoryQuery(); //初始化标题栏故障表
        }

        //更新标题栏的若干行（共numRowShow行）
        public void _refreshTitleGridShow(int numRowShow)
        {
            Global.dtTitleGridShowMainForm.Rows.Clear();

            int numRowsHistoryQueryGridShow = Global.dtHistoryQueryGridShow.Rows.Count;
            if (numRowShow > numRowsHistoryQueryGridShow)
            {
                numRowShow = numRowsHistoryQueryGridShow;
            }

            for (int i = 0; i < numRowShow; i++)
            {
                DataRow rowShowTemp = Global.dtTitleGridShowMainForm.NewRow();
                rowShowTemp["NO"] = Global.dtHistoryQueryGridShow.Rows[i]["NO"];
                rowShowTemp["LineName"] = Global.dtHistoryQueryGridShow.Rows[i]["LineName"];
                rowShowTemp["DeviceName"] = Global.dtHistoryQueryGridShow.Rows[i]["DeviceName"];
                rowShowTemp["FaultName"] = Global.dtHistoryQueryGridShow.Rows[i]["FaultName"];
                rowShowTemp["FaultTime"] = Global.dtHistoryQueryGridShow.Rows[i]["FaultTime"];
                Global.dtTitleGridShowMainForm.Rows.Add(rowShowTemp);
            }
        }

        //刷新目录
        void _refreshLabelDir()
        {
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub1.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub1.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2;
        }

        //初始化子菜单
        void _initSideTileBarWithSub()
        {
            //添加产线按钮
            string tag = String.Empty;
            string name = String.Empty;
            string text = String.Empty;
            string num = String.Empty;

            for (int i = 0; i < Global.dtSideTileBar.Rows.Count; i++)
            {
                tag = (string)Global.dtSideTileBar.Rows[i]["LineNO"];
                name = "tileBarItem" + (i + 1).ToString();   //总览是tileBarItem0
                text = (string)Global.dtSideTileBar.Rows[i]["LineName"];
                num = (string)Global.dtSideTileBar.Rows[i]["DeviceTotalNum"];
                this.sideTileBarControlWithSub1._addSideTileBarItem(new TileBarItem(), tag, name, text, num);   //添加item
            } 

            //添加所有检测设备按钮
            for (int i = 0; i < Global.dtTestingDeviceName.Rows.Count; i++)
            {
                string tagTemp = (string)Global.dtTestingDeviceName.Rows[i]["DeviceNO"];
                string nameTemp = (string)Global.dtTestingDeviceName.Rows[i]["DeviceName"];
                bool flag = this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), tagTemp, "tileBarItem_sub" + (i + 1).ToString(), nameTemp, Encoding.Default.GetBytes(nameTemp).Length / 2);
            }
            this.sideTileBarControlWithSub1._showSubItemHideRedundantItem();
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

        private bool _timeInterValIllegal()
        {
            if (this.timeEdit_endTime.Time <= this.timeEdit_startTime.Time)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            if (_timeInterValIllegal() == true)
            {
                MessageBox.Show("无效时间区间，请重新选择...");
            }
            else
            {
                //查询改变grid绑定的表
                this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;
            }
            

        }

        private void simpleButton_startTimeModify_Click(object sender, EventArgs e)
        {
            this.timeEdit_startTime.ShowPopup();
        }

        private void simpleButton_endTimeModify_Click(object sender, EventArgs e)
        {
            this.timeEdit_endTime.ShowPopup();
        }


        //grid绑定的表不变，dtHistoryQueryGridShow，但dtHistoryQueryGridShow中内容发生了改变时的操作
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Global.dtHistoryQueryGridShow = new DataTable();
            Global._init_dtHistoryQueryGridShow();    //该表是用来测试的
            this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShow;
            this._refreshTitleGridShow(10);
        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
            _refreshLabelDir();
        }

        private void sideTileBarControlWithSub1_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            _refreshLabelDir();
        }

    }
}
