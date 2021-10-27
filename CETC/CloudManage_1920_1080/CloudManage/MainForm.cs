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
        DateTime now = new DateTime();  //当前时间
        int[][] itemIndex = new int[6][];
        enum StatusMonitorPages { workStatePage = 0, realtimePage, historyQueryPage };
        enum DataAnalysisPages { LateralAnalysisPage = 0, VerticalAnalysisPage, ParameterOptimizationPage };
        enum TwinDetectionPages { paraSynPage, intelligentReasoningPage, paraUpdatePage };
        enum DeepLearningPages { datapreParationPage, modelTrainingPage, modelTestingPage, modelUpdatePage };
        enum DeviceManagementPages { deviceAdditionPage, deviceDeletionPage, deviceTestingPage };

        int iSelectedIndex = 0; //默认显示第一页
        public MainForm()
        {
            InitializeComponent();
            this.navigationFrame_mainMenu.Location = new System.Drawing.Point(0, 200);
            this.panelControl_faultHistoryQuery.Visible = false;
            this.gridControl_faultHistoryQuery.DataSource = Global.dtTitleGridShowMainForm;
        }

        private void timer_datetime_Tick(object sender, EventArgs e)
        {
            now = DateTime.Now;
            this.labelControl_datetime.Text = now.ToString("yyyy-MM-dd  HH:mm:ss");

            //if (this.statusMonitorControl1.faultNumStatusMonitor != 0)
            //{
            //    this.sidePanel_title.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
            //}
            if (this.panelControl_faultHistoryQuery.Visible == false)
            {
                if (Global.dtTitleGridShowMainForm.Rows.Count != 0)
                {
                    //this.sidePanel_title.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
                    this.labelControl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
                    DataRow rowFirstLine = Global.dtTitleGridShowMainForm.Rows[0];
                    //this.labelControl_title.Text = "序号：" + (string)rowFirstLine["序号"] + ",产线名称：" + (string)rowFirstLine["产线名称"] + "检测设备名称：" + (string)rowFirstLine["检测设备名称"] + "故障名称：" + (string)rowFirstLine["故障名称"] + "故障发生时间："+ (string)rowFirstLine["故障发生时间"];
                    this.labelControl_title.Text = (string)rowFirstLine["LineName"] + " " + (string)rowFirstLine["DeviceName"] + " " + (string)rowFirstLine["FaultName"];
                }
                else
                {
                    this.labelControl_title.Text = "检测设备数字化平台";
                    this.labelControl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                }
            }
            else
            {
                this.labelControl_title.Text = "检测设备数字化平台";
                this.labelControl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            }
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
        }

        private void tileBar_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
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
            iSelectedIndex = (int)StatusMonitorPages.workStatePage;
            this.statusMonitorControl1.setSelectedFramePage(iSelectedIndex);

        }

        private void tileBarItem_statusMonitoring_realTimeData_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
            iSelectedIndex = (int)StatusMonitorPages.realtimePage;
            this.statusMonitorControl1.setSelectedFramePage(iSelectedIndex);
        }

        private void tileBarItem_statusMonitoring_historyQuery_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
            iSelectedIndex = (int)StatusMonitorPages.historyQueryPage;
            this.statusMonitorControl1.selectedFramePage = iSelectedIndex;
        }


        private void tileBarItem_dataAnalysis_HorizontalAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = (int)DataAnalysisPages.LateralAnalysisPage;
            
        }

        private void tileBarItem_dataAnalysis_VerticalAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = (int)DataAnalysisPages.VerticalAnalysisPage;
        }

        private void tileBarItem_dataAnalysis_paraOptimization_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = (int)DataAnalysisPages.ParameterOptimizationPage;

        }

        private void tileBarItem_twinDetection_paraSyn_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
            iSelectedIndex = (int)TwinDetectionPages.paraSynPage;

        }

        private void tileBarItem_twinDetection_intelligentReasoning_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
            iSelectedIndex = (int)TwinDetectionPages.intelligentReasoningPage;
        }

        private void tileBarItem_twinDetection_paraUpdate_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
            iSelectedIndex = (int)TwinDetectionPages.paraUpdatePage;

        }


        private void tileBarItem_dataPreparation_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = (int)DeepLearningPages.datapreParationPage;

        }

        private void tileBarItem_modelTraining_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = (int)DeepLearningPages.modelTrainingPage;

        }

        private void tileBarItem_modelTesting_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = (int)DeepLearningPages.modelTestingPage;
        }

        private void tileBarItem_modelUpdate_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = (int)DeepLearningPages.modelUpdatePage;
        }


        private void tileBarItem_deviceAddition_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            iSelectedIndex = (int)DeviceManagementPages.deviceAdditionPage;
        }

        private void tileBarItem_deviceDeletion_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            iSelectedIndex = (int)DeviceManagementPages.deviceDeletionPage;
        }

        private void tileBarItem_deviceTesting_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            iSelectedIndex = (int)DeviceManagementPages.deviceTestingPage;
        }

        private void labelControl_title_Click(object sender, EventArgs e)
        {
            this.panelControl_faultHistoryQuery.Visible = true;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(Global.dtTitleGridShowMainForm.Rows.Count > 0)
            {
                Global.dtTitleGridShowMainForm.Rows.RemoveAt(0);
            }
        }

        private void simpleButtonfaultHistoryQuery_Click(object sender, EventArgs e)
        {
            this.panelControl_faultHistoryQuery.Visible = false;
        }

    }
}
