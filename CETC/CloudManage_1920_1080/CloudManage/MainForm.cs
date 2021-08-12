using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudManage
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        int[][] itemIndex = new int[6][];
        int iSelectedIndex = 0; //默认显示第一页

        public MainForm()
        {
            InitializeComponent();
            this.navigationFrame_mainMenu.Location = new System.Drawing.Point(0, 200);
            _InitItemIndex();
        }

        private void _InitItemIndex()
        {
            itemIndex[0] = new int[] { 0, 1, 2 };
            itemIndex[1] = new int[] { 0, 1, 2 };
            itemIndex[2] = new int[] { 0, 1, 2 };
            itemIndex[3] = new int[] { 0, 1, 2, 3 };
            itemIndex[4] = new int[] { 0, 1, 2 };
            //itemIndex[5] = new int[] { 0, 1, 2 };

        }

        private void timer_datetime_Tick(object sender, EventArgs e)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            this.labelControl_datetime.Text = now.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        /**
        **********************************************点击磁贴，显示二级子菜单按钮***********************************************************
        */

        private void tileBarItem_statusMonitoring_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_statusMonitor);
        }

        private void tileBarItem_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_dataAnalysis);
        }

        private void tileBarItem_twinDetection_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_twinDetection);
        }

        private void tileBarItem_deepLearning_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_deepLearning);
        }

        private void tileBarItem_deviceManagement_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_deviceManagement);
        }

        private void tileBarItem_systemConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_systemConfig);
        }


        /**
        **********************************************点击二级子菜单按钮后，子菜单按钮隐藏***********************************************************
        */

        private void tileBar_statusMonitoring_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
            MessageBox.Show("传参：" + iSelectedIndex);
        }

        private void tileBar_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
            MessageBox.Show("传参：" + iSelectedIndex);

        }

        private void tileBar_twinDetection_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
            MessageBox.Show("传参：" + iSelectedIndex);

        }
        private void tileBar_deepLearning_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
            MessageBox.Show("传参：" + iSelectedIndex);

        }

        private void tileBar_deviceManagement_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
            MessageBox.Show("传参：" + iSelectedIndex);

        }

        /**
        *******************************************************二级子菜单显示***************************************************************
        */

        private void tileBarItem_statusMonitoring_workState_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
            iSelectedIndex = itemIndex[0][0];
            this.statusMonitorControl1.setSelectedFramePage(iSelectedIndex);

        }

        private void tileBarItem_statusMonitoring_realTimeData_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
            iSelectedIndex = itemIndex[0][1];
            this.statusMonitorControl1.setSelectedFramePage(iSelectedIndex);
        }

        private void tileBarItem_statusMonitoring_historyQuery_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
            iSelectedIndex = itemIndex[0][2];
            //this.statusMonitorControl1.setSelectedFramePage(iSelectedIndex);
            this.statusMonitorControl1.selectedFramePage = iSelectedIndex;
        }


        private void tileBarItem_dataAnalysis_HorizontalAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = itemIndex[1][0];

        }

        private void tileBarItem_dataAnalysis_VerticalAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = itemIndex[1][1];

        }

        private void tileBarItem_dataAnalysis_paraOptimization_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = itemIndex[1][2];

        }


        private void tileBarItem_twinDetection_paraSyn_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
            iSelectedIndex = itemIndex[2][0];

        }

        private void tileBarItem_statusWatch_intelligentReasoning_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
            iSelectedIndex = itemIndex[2][1];

        }

        private void tileBarItem_twinDetection_paraUpdate_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
            iSelectedIndex = itemIndex[2][2];

        }


        private void tileBarItem_dataPreparation_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = itemIndex[3][0];

        }

        private void tileBarItem_modelTraining_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = itemIndex[3][1];

        }

        private void tileBarItem_modelTesting_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = itemIndex[3][2];

        }

        private void tileBarItem_modelUpdate_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = itemIndex[3][3];

        }


        private void tileBarItem_deviceAddition_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            iSelectedIndex = itemIndex[4][0];

        }

        private void tileBarItem_deviceDeletion_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            iSelectedIndex = itemIndex[4][1];

        }

        private void tileBarItem_deviceTesting_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            iSelectedIndex = itemIndex[4][2];

        }


    }
}
