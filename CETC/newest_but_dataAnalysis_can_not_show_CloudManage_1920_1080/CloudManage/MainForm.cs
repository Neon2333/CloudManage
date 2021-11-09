﻿using DevExpress.XtraBars.Docking2010;
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

        private int[] selectRowFaultCurrent = { -1 };

        public MainForm()
        {
            Global.initDataTable();
            InitializeComponent();
            this.navigationFrame_mainMenu.Location = new System.Drawing.Point(0, 200);
            this.panelControl_faultsCurrent.Visible = false;
            this.gridControl_faultsCurrent.DataSource = Global.dtTitleGridShowMainForm;

        }

        private void timer_datetime_Tick(object sender, EventArgs e)
        {
            now = DateTime.Now;
            this.labelControl_datetime.Text = now.ToString("yyyy-MM-dd  HH:mm:ss");

            if (this.panelControl_faultsCurrent.Visible == false)
            {
                if (Global.dtTitleGridShowMainForm.Rows.Count != 0)
                {
                    this.labelControl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
                    DataRow rowFirstLine = Global.dtTitleGridShowMainForm.Rows[0];
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
            this.dataAnalysis1.selectedFramePage = iSelectedIndex;
        }

        private void tileBarItem_dataAnalysis_VerticalAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = (int)DataAnalysisPages.VerticalAnalysisPage;
            this.dataAnalysis1.selectedFramePage = iSelectedIndex;

        }

        private void tileBarItem_dataAnalysis_paraOptimization_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = (int)DataAnalysisPages.ParameterOptimizationPage;
            this.dataAnalysis1.selectedFramePage = iSelectedIndex;

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
            this.panelControl_faultsCurrent.Visible = true;
        }

        private void simpleButtonfaultHistoryQuery_Click(object sender, EventArgs e)
        {
            this.panelControl_faultsCurrent.Visible = false;
        }

        private void timer_refreshDtTitleGridShowMainForm_Tick(object sender, EventArgs e)
        {
            Global._refreshTitleGridShow();
            Global._writeFaultsHistory();

            if (selectRowFaultCurrent.Length == 1)
            {
                this.tileView_1.FocusedRowHandle = selectRowFaultCurrent[0];     //手动设置被选中的行
            }
            else
            {
                MessageBox.Show("所选行数大于1");
            }
            MessageBox.Show("3s");
        }

        private void simpleButton_ignoreOnce_Click(object sender, EventArgs e)
        {
            if (Global.dtTitleGridShowMainForm.Rows.Count > 0)
            {
                DataRow drSelected = this.tileView_1.GetFocusedDataRow();

                string valLineName = drSelected["LineName"].ToString();
                string valDeviceName = drSelected["DeviceName"].ToString();
                string valFaultName = drSelected["FaultName"].ToString();

                //dtTitleGridShowMainForm中存储的是名称，而faults_current中是ID
                string cmdTransfrom = "SELECT t1.LineNO,t2.DeviceNO,t3.FaultNO " +
                                      "FROM productionline AS t1, device AS t2, faults AS t3 " +
                                      "WHERE t1.LineName=" + "'" + valLineName + "'" + " AND t2.DeviceName=" + "'" + valDeviceName + "'" + " AND t3.FaultName=" + "'" + valFaultName + "';";
                DataTable dtTemp = new DataTable();
                MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
                mysqlHelper1._connectMySQL();
                bool flag1 = mysqlHelper1._queryTableMySQL(cmdTransfrom, ref dtTemp);
                if (flag1 == true)
                {
                    string valLineNO = dtTemp.Rows[0]["LineNO"].ToString();
                    string valDeviceNO = dtTemp.Rows[0]["DeviceNO"].ToString();
                    string valFaultNO = dtTemp.Rows[0]["FaultNO"].ToString();
                    string valFaultTime = drSelected["FaultTime"].ToString();

                    string cmdIgnoreOnce = "DELETE FROM faults_current WHERE " +
                                         "LineNO=" + "'" + valLineNO + "'" + " AND DeviceNO=" + "'" + valDeviceNO + "'" + " AND FaultNO=" +
                                         "'" + valFaultNO + "'" + " AND FaultTime=" + "'" + valFaultTime + "';";

                    MySQL.MySQLHelper mysqlHelper2 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
                    mysqlHelper1._connectMySQL();
                    bool flag2 = mysqlHelper1._deleteMySQL(cmdIgnoreOnce);
                    mysqlHelper1.conn.Close();
                    if (flag2 == true)
                    {
                        Global._refreshTitleGridShow();
                    }
                }
            }
        }

        private void simpleButton_ignoreFaults_Click(object sender, EventArgs e)
        {
            if (Global.dtTitleGridShowMainForm.Rows.Count > 0)
            {
                MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
                mysqlHelper1._connectMySQL();
                
                DataRow drSelected = this.tileView_1.GetFocusedDataRow();

                string valLineName = drSelected["LineName"].ToString();
                string valDeviceName = drSelected["DeviceName"].ToString();
                string valFaultName = drSelected["FaultName"].ToString();

                //dtTitleGridShowMainForm中存储的是名称，而faults_current中是ID
                string cmdTransfrom = "SELECT t1.LineNO,t2.DeviceNO,t3.FaultNO " +
                                      "FROM productionline AS t1, device AS t2, faults AS t3 " +
                                      "WHERE t1.LineName=" + "'" + valLineName + "'" + " AND t2.DeviceName=" + "'" + valDeviceName + "'" + " AND t3.FaultName=" + "'" + valFaultName + "';";
                DataTable dtTemp = new DataTable();
                bool flag1 = mysqlHelper1._queryTableMySQL(cmdTransfrom, ref dtTemp);
                if (flag1 == true)
                {
                    string valLineNO = dtTemp.Rows[0]["LineNO"].ToString();
                    string valDeviceNO = dtTemp.Rows[0]["DeviceNO"].ToString();
                    string valFaultNO = dtTemp.Rows[0]["FaultNO"].ToString();
                    string valFaultTime = drSelected["FaultTime"].ToString();

                    string cmdIgnoreOnce = "DELETE FROM faults_current WHERE " +
                                            "LineNO=" + "'" + valLineNO + "'" + " AND DeviceNO=" + "'" + valDeviceNO + "'" + " AND FaultNO=" +
                                            "'" + valFaultNO + "'" + " AND FaultTime=" + "'" + valFaultTime + "';";

                    string cmdUpdateFaultConfig = "UPDATE faults_config SET FaultEnable='0' "
                                                 + "WHERE LineNO=" + "'" + valLineNO + "'" + " AND DeviceNO=" + "'" + valDeviceNO + "'" + " AND FaultNO=" + "'" + valFaultNO + "';";

                    bool flag2 = mysqlHelper1._deleteMySQL(cmdIgnoreOnce);
                    bool flag3 = mysqlHelper1._updateMysql(cmdUpdateFaultConfig);
                    mysqlHelper1.conn.Close();

                    if (flag2 == true)
                    {
                        Global._refreshTitleGridShow();
                    }


                }
            }

        }

        private void tileView_1_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            selectRowFaultCurrent = this.tileView_1.GetSelectedRows();

        }


        //private void tileView_1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        //{

        //    try
        //    {
        //        MessageBox.Show("ItemCustomize");
        //        //if (this.panelControl_faultsCurrent.Visible == true)
        //        //{
        //        //    if (e.Item == null || e.Item.Elements.Count == 0)
        //        //        return;
        //        //    if (selectRowFaultCurrent.Length == 1)
        //        //    {
        //        //        if (rowIndexTemp == selectRowFaultCurrent[0])
        //        //        {
        //        //            //e.Item.AppearanceItem.Normal.BackColor = Color.FromArgb(255, 128, 0);
        //        //            //e.Item.AppearanceItem.Normal.BorderColor = Color.White;
        //        //            //e.Item.AppearanceItem.Normal.ForeColor = Color.White;
        //        //            //MessageBox.Show("changed" + rowIndexTemp.ToString());
        //        //        }
        //        //    }
        //        //    rowIndexTemp++;
        //        //}
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());

        //    }

        //}


    }
}