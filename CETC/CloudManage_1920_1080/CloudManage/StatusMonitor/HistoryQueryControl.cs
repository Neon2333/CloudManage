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
            test();
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
                rowShowTemp["序号"] = Global.dtHistoryQueryGridShow.Rows[i]["序号"];
                rowShowTemp["产线名称"] = Global.dtHistoryQueryGridShow.Rows[i]["产线名称"];
                rowShowTemp["检测设备名称"] = Global.dtHistoryQueryGridShow.Rows[i]["检测设备名称"];
                rowShowTemp["故障名称"] = Global.dtHistoryQueryGridShow.Rows[i]["故障名称"];
                rowShowTemp["故障发生时间"] = Global.dtHistoryQueryGridShow.Rows[i]["故障发生时间"];
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
        void _init_sideTileBarSub(ArrayList showDeviceNum)
        {
            //添加检测设备按钮
            this.sideTileBarControlWithSub1.dataTableTileBarSubTestingDevice = Global.dtDeviceEnable;
            for (int i = 0; i < Global.dtTestingDeviceName.Rows.Count; i++)
            {
                string tagTemp = (string)Global.dtTestingDeviceName.Rows[i]["检测设备ID"];
                string nameTemp = (string)Global.dtTestingDeviceName.Rows[i]["检测设备名称"];
                bool flag = this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), tagTemp, "tileBarItem_sub" + (i + 1).ToString(), nameTemp, Encoding.Default.GetBytes(nameTemp).Length / 2);
            }

            //添加产线按钮tileBarItem
            string tag = String.Empty;
            string name = String.Empty;
            string text = String.Empty;
            string num = String.Empty;

            for (int i = 0; i < Global.dtDeviceEnable.Rows.Count; i++)
            {
                tag = (string)Global.dtDeviceEnable.Rows[i]["产线Tag"];
                name = "tileBarItem" + (i + 1).ToString();   //总览是tileBarItem0
                for (int j = 0; j < Global.dtProductionLine.Rows.Count; j++)
                {
                    if (tag == (string)Global.dtProductionLine.Rows[j]["产线Tag"])
                    {
                        text = (string)Global.dtProductionLine.Rows[j]["产线名称"];
                    }
                }
                num = Convert.ToString(showDeviceNum[i]);

                this.sideTileBarControlWithSub1._addSideTileBarItem(new TileBarItem(), tag, name, text, num);   //添加item
            } //添加item

            this.sideTileBarControlWithSub1._showSubItemHideRedundantItem();
        }

        //初始化基础信息表格
        public void _initHistoryQuery()
        {
            Global._init_dtTestingDeviceName(Global.excelPath_testingDeviceName);
            Global._init_dtProductionLine(Global.excelPath_productionLineName);
            Global._init_dtAllFaults(Global.excelPath_allFaults);
            ArrayList showDeviceNum = Global._init_dtDeviceEnable();
            _init_sideTileBarSub(showDeviceNum);
            Global._init_dtHistoryQueryGridShow(Global.excelPath_historyQueryGridShow);    //grid显示
            Global._init_dtHistoryQueryGridShowClickedQueryButton(Global.excelPath_historyQueryGridShowClickedQueryButton);   //点击查询后grid显示
            Global._init_dtFaultHistoryQuery();
        }

        //测试函数
        void test()
        {
            _initHistoryQuery();
            _refreshTitleGridShow(10);
            this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShow;

        }

        private string _getProductionLineNameByTag(string tagProductionLine)
        {
            //dtProductionLine中没有Tag==0的记录
            if (tagProductionLine == "0")
            {
                return "总览";
            }

            string temp = "产线Tag=" + "'" + tagProductionLine + "'";
            DataRow[] rowPL = Global.dtProductionLine.Select(temp);
            if (rowPL.Length == 1)
            {
                return (string)rowPL[0]["产线名称"];
            }
            else
            {
                return "产线名称查询错误...";
            }
        }

        private string _getTestingDeviceNameByTag(string tagTestingDeviceName)
        {
            if (tagTestingDeviceName == "0")
            {
                return "所有设备";
            }

            string temp = "检测设备ID=" + "'" + tagTestingDeviceName + "'";
            DataRow[] rowTD = Global.dtTestingDeviceName.Select(temp);
            if (rowTD.Length == 1)
            {
                return (string)rowTD[0]["检测设备名称"];
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
            //查询改变grid绑定的表
            this.gridControl_faultDataTime.DataSource = Global.dtHistoryQueryGridShowClickedQueryButton;

        }

        private void simpleButton_startTimeModify_Click(object sender, EventArgs e)
        {
            this.timeEdit_startTime.ShowPopup();
        }

        private void simpleButton_endTimeModify_Click(object sender, EventArgs e)
        {
            this.timeEdit_endTime.ShowPopup();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //grid绑定的表不变，dtHistoryQueryGridShow，但dtHistoryQueryGridShow中内容发生了改变
            Global.dtHistoryQueryGridShow = new DataTable();
            Global._init_dtHistoryQueryGridShow(@"D:\WorkSpace\DevExpressDemo\CETC\ExcelFile\historyQueryGridShowTest.xlsx");    //该表是用来测试的
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
