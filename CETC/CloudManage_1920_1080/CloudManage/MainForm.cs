using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudManage
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        int currentPage = (int)StatusMonitorPages.workStatePage;    //全局记录当前页面
        private CommonControl.ConfirmationBox confirmationBox_applicationRestartOrClose;

        public delegate void DeviceOrLineAdditionDeletionReinit(object sender, EventArgs e);
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitWorkState;  //设备或产线增删时传递事件
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitRealTime;
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitHistoryQuery;

        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitLateralAnalysis;
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitVerticalAnalysis;
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitParameterOptimization;

        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitDeviceAdditionDeletion;
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitMonitorThreshold;
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitdiagnosisManagement;
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitDeviceManagementReserve1;
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitDeviceManagementReserve2;

        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitproductionAdditionDeletion;
        public static event DeviceOrLineAdditionDeletionReinit deviceOrLineAdditionDeletionReinitSystemConfigReserve1;

        DateTime now = new DateTime();  //当前时间
        //int[][] itemIndex = new int[6][];
        enum StatusMonitorPages { workStatePage = 0, realtimePage, historyQueryPage };
        enum DataAnalysisPages { lateralAnalysisPage = 0, verticalAnalysisPage, parameterOptimizationPage };
        enum TwinDetectionPages { paraSynPage = 0, intelligentReasoningPage , paraUpdatePage };
        enum DeepLearningPages { datapreParationPage = 0, modelTrainingPage , modelTestingPage , modelUpdatePage };
        enum DeviceManagementPages { deviceAdditionDeletionPage = 0, monitorThresholdPage, diagnosisManagementPage, reservePage1, reservePage2 };
        enum SystemConfigPages { productionLineAdditionDeletion = 0, reservePage1 };

        int iSelectedIndex = 0; //默认显示第一页

        private int[] selectRowFaultCurrent = { 0 };   //手动记录被选中行，初始给手动设置被选中行的handle（index）赋值-1，目前正常，是否会出bug未知

        public MainForm()
        {
            Global.initDataTable();
            InitializeComponent();
            loadModules();  //动态加载各个模块
            this.navigationFrame_mainMenu.Location = new System.Drawing.Point(0, 200);
            this.panelControl_faultsCurrent.Visible = false;
            this.gridControl_faultsCurrent.DataSource = Global.dtTitleGridShowMainForm;

            StatusMonitor.WorkState.doubleClickTileViewEach_ += doubleClickTileViewEach_informMainFormChangePage;

            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);
        }

        private void loadModules()
        {
            this.statusMonitorControl1 = new StatusMonitor.StatusMonitor();
            this.dataAnalysis1 = new DataAnalysis.DataAnalysis();
            this.deviceManagement1 = new DeviceManagement.DeviceManagement();
            this.systemConfig1 = new SystemConfig.SystemConfig();
            this.navigationPage_statusMonitoring.Controls.Add(this.statusMonitorControl1);
            this.navigationPage_dataAnalysis.Controls.Add(this.dataAnalysis1);
            this.navigationPage_deviceManagement.Controls.Add(this.deviceManagement1);
            this.navigationPage_systemConfig.Controls.Add(this.systemConfig1);
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
                    this.labelControl_title.Text = "视觉检测设备数字化平台";
                    this.labelControl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                }
            }
            else
            {
                this.labelControl_title.Text = "视觉检测设备数字化平台";
                this.labelControl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            }
        }

        //typeConfirmationBox==restart为重启，typeConfirmationBox==close为退出软件
        private void createConfirmationBox(string title, string typeConfirmationBox)
        {
            if (this.confirmationBox_applicationRestartOrClose != null)
                this.confirmationBox_applicationRestartOrClose.Dispose();

            this.confirmationBox_applicationRestartOrClose = new CommonControl.ConfirmationBox();
            this.confirmationBox_applicationRestartOrClose.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox_applicationRestartOrClose.Appearance.Options.UseBackColor = true;
            this.confirmationBox_applicationRestartOrClose.Name = "confirmationBox_applicationRestart";
            this.confirmationBox_applicationRestartOrClose.Size = new System.Drawing.Size(350, 200);
            this.confirmationBox_applicationRestartOrClose.TabIndex = 29;
            this.confirmationBox_applicationRestartOrClose.titleConfirmationBox = title;
            if (typeConfirmationBox == "restart")
            {
                this.confirmationBox_applicationRestartOrClose.Location = new System.Drawing.Point(785, 360);
                this.confirmationBox_applicationRestartOrClose.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_applicationRestartOrClose_restartOK);
                this.confirmationBox_applicationRestartOrClose.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_applicationRestartOrClose_restartCancel);
            }
            else if(typeConfirmationBox == "close")
            {
                this.confirmationBox_applicationRestartOrClose.Location = new System.Drawing.Point(785, 360);
                this.confirmationBox_applicationRestartOrClose.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_applicationRestart_closeOK);
                this.confirmationBox_applicationRestartOrClose.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_applicationRestart_closeCancel);
            }
            this.Controls.Add(this.confirmationBox_applicationRestartOrClose);
            this.confirmationBox_applicationRestartOrClose.Visible = true;
            this.confirmationBox_applicationRestartOrClose.BringToFront();
        }

        private void confirmationBox_applicationRestart_closeOK(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void confirmationBox_applicationRestart_closeCancel(object sender, EventArgs e)
        {
            confirmationBox_applicationRestartOrClose.Dispose();
        }

        private void confirmationBox_applicationRestartOrClose_restartOK(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void confirmationBox_applicationRestartOrClose_restartCancel(object sender, EventArgs e)
        {
            this.confirmationBox_applicationRestartOrClose.Dispose();
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
        }

        private void tileBar_systemConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
        }

        /**
        *******************************************************二级子菜单显示***************************************************************
        */
        //为了使currentPage唯一
        private int processCurrentPage()
        {
            int curPage = 0;
            if (this.navigationFrame_mainMenu.SelectedPage == navigationPage_statusMonitoring)
                curPage = currentPage + 0;
            else if (this.navigationFrame_mainMenu.SelectedPage == navigationPage_dataAnalysis)
                curPage = currentPage + 3;
            else if (this.navigationFrame_mainMenu.SelectedPage == navigationPage_twinDetection)
                curPage = currentPage + 6;
            else if (this.navigationFrame_mainMenu.SelectedPage == navigationPage_deepLearning)
                curPage = currentPage + 9;
            else if (this.navigationFrame_mainMenu.SelectedPage == navigationPage_deviceManagement)
                curPage = currentPage + 13;
            else if (this.navigationFrame_mainMenu.SelectedPage == navigationPage_systemConfig)
                curPage = currentPage + 18;
            return curPage;
        }

        private void tileBarItem_statusMonitoring_workState_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitWorkState(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
            iSelectedIndex = (int)StatusMonitorPages.workStatePage;
            this.statusMonitorControl1.setSelectedFramePage(iSelectedIndex);
            currentPage = (int)StatusMonitorPages.workStatePage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_statusMonitoring_realTimeData_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitRealTime(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
            iSelectedIndex = (int)StatusMonitorPages.realtimePage;
            this.statusMonitorControl1.setSelectedFramePage(iSelectedIndex);
            currentPage = (int)StatusMonitorPages.realtimePage;
            currentPage = processCurrentPage();


        }

        private void tileBarItem_statusMonitoring_historyQuery_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitHistoryQuery(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
            iSelectedIndex = (int)StatusMonitorPages.historyQueryPage;
            this.statusMonitorControl1.selectedFramePage = iSelectedIndex;
            currentPage = (int)StatusMonitorPages.historyQueryPage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_dataAnalysis_LateralAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitLateralAnalysis(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = (int)DataAnalysisPages.lateralAnalysisPage;
            this.dataAnalysis1.selectedFramePage = iSelectedIndex;
            currentPage = (int)DataAnalysisPages.lateralAnalysisPage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_dataAnalysis_VerticalAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitVerticalAnalysis(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = (int)DataAnalysisPages.verticalAnalysisPage;
            this.dataAnalysis1.selectedFramePage = iSelectedIndex;
            currentPage = (int)DataAnalysisPages.verticalAnalysisPage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_dataAnalysis_paraOptimization_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitParameterOptimization(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
            iSelectedIndex = (int)DataAnalysisPages.parameterOptimizationPage;
            this.dataAnalysis1.selectedFramePage = iSelectedIndex;
            currentPage = (int)DataAnalysisPages.parameterOptimizationPage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_twinDetection_paraSyn_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                //deviceOrLineAdditionDeletionReinitParaSyn(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
            iSelectedIndex = (int)TwinDetectionPages.paraSynPage;

            currentPage = (int)TwinDetectionPages.paraSynPage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_twinDetection_intelligentReasoning_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                //deviceOrLineAdditionDeletionReinitIntelligentReasoning(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
            iSelectedIndex = (int)TwinDetectionPages.intelligentReasoningPage;

            currentPage = (int)TwinDetectionPages.intelligentReasoningPage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_twinDetection_paraUpdate_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                //deviceOrLineAdditionDeletionReinitParaUpdate(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
            iSelectedIndex = (int)TwinDetectionPages.paraUpdatePage;

            currentPage = (int)TwinDetectionPages.paraUpdatePage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_dataPreparation_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                //deviceOrLineAdditionDeletionReinitDataPreparation(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = (int)DeepLearningPages.datapreParationPage;

            currentPage = (int)DeepLearningPages.datapreParationPage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_modelTraining_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                //deviceOrLineAdditionDeletionReinitModelTraining(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = (int)DeepLearningPages.modelTrainingPage;

            currentPage = (int)DeepLearningPages.modelTrainingPage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_modelTesting_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                //deviceOrLineAdditionDeletionReinitModelTesting(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = (int)DeepLearningPages.modelTestingPage;

            currentPage = (int)DeepLearningPages.modelTestingPage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_modelUpdate_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                //deviceOrLineAdditionDeletionReinitModelUpdate(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
            iSelectedIndex = (int)DeepLearningPages.modelUpdatePage;

            currentPage = (int)DeepLearningPages.modelUpdatePage;
            currentPage = processCurrentPage();
        }

        private void tileBarItem_deviceManagement_deviceAdditionDeletion_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitDeviceAdditionDeletion(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            currentPage = (int)DeviceManagementPages.deviceAdditionDeletionPage;
            currentPage = processCurrentPage();
            iSelectedIndex = (int)DeviceManagementPages.deviceAdditionDeletionPage;
            this.deviceManagement1.selectedFramePage = iSelectedIndex;
        }
        private void tileBarItem_deviceManagement_monitorThreshold_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitMonitorThreshold(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            currentPage = (int)StatusMonitorPages.workStatePage;
            currentPage = processCurrentPage();
            iSelectedIndex = (int)DeviceManagementPages.monitorThresholdPage;
            this.deviceManagement1.selectedFramePage = iSelectedIndex;
        }

        private void tileBarItem_deviceManagement_diagnosisManagement_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitdiagnosisManagement(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            currentPage = (int)DeviceManagementPages.diagnosisManagementPage;
            currentPage = processCurrentPage();
            iSelectedIndex = (int)DeviceManagementPages.diagnosisManagementPage;
            this.deviceManagement1.selectedFramePage = iSelectedIndex;
        }

        private void tileBarItem_deviceManagement_reserve1_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitDeviceManagementReserve1(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            currentPage = (int)DeviceManagementPages.reservePage1;
            currentPage = processCurrentPage();
            iSelectedIndex = (int)DeviceManagementPages.reservePage1;
            this.deviceManagement1.selectedFramePage = iSelectedIndex;
        }

        private void tileBarItem_deviceManagement_reserve2_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitDeviceManagementReserve2(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            currentPage = (int)DeviceManagementPages.reservePage2;
            currentPage = processCurrentPage();
            iSelectedIndex = (int)DeviceManagementPages.reservePage2;
            this.deviceManagement1.selectedFramePage = iSelectedIndex;


            //if (Global.ifDeviceAdditionOrDeletion == false && Global.ifLineAdditionOrDeletion == false)
            //{
            //    this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
            //    currentPage = (int)DeviceManagementPages.reservePage2;
            //    currentPage = processCurrentPage();
            //    iSelectedIndex = (int)DeviceManagementPages.reservePage2;
            //    this.deviceManagement1.selectedFramePage = iSelectedIndex;
            //}
            //else
            //{
            //    if (currentPage == 13)
            //    {
            //        createConfirmationBox("设备发生变化，确认重启？", "restart");
            //    }
            //    if (currentPage == 18)
            //    {
            //        createConfirmationBox("产线发生变化，确认重启？", "restart");
            //    }
            //}
        }

        private void tileBarItem_systemConfig_productionAdditionDeletion_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Global.ifDeviceAdditionOrDeletion == true || Global.ifLineAdditionOrDeletion == true)
            {
                deviceOrLineAdditionDeletionReinitproductionAdditionDeletion(sender, new EventArgs());
            }

            this.navigationFrame_mainMenu.SelectedPage = navigationPage_systemConfig;
            currentPage = (int)SystemConfigPages.productionLineAdditionDeletion;
            currentPage = processCurrentPage();
            iSelectedIndex = (int)SystemConfigPages.productionLineAdditionDeletion;
            this.deviceManagement1.selectedFramePage = iSelectedIndex;
        }

        private void labelControl_title_Click(object sender, EventArgs e)
        {
            if(Global.dtTitleGridShowMainForm.Rows.Count > 0)
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

            keepSelectRowWhenDataSourceRefresh();
            
        }

        //当表刷新时保持表中被选中的行的index不变，若选中行被删除则仍选中该Index的行，若表的总行数<index，则选中第一行
        private void keepSelectRowWhenDataSourceRefresh()
        {
            if (selectRowFaultCurrent.Length == 1)
            {
                if (selectRowFaultCurrent[0] < this.tileView_1.DataRowCount)
                    this.tileView_1.FocusedRowHandle = selectRowFaultCurrent[0];     //在DataSource发生改变后，手动修改被选中的row
                else
                {
                    this.tileView_1.FocusedRowHandle = 0;
                    selectRowFaultCurrent[0] = 0;
                }
            }
        }

        private void gridControl_faultsCurrent_Click(object sender, EventArgs e)    //不要用itemClick，有时候点击了但selectedrows未改变，出现bug
        {
            if (((DataTable)this.gridControl_faultsCurrent.DataSource).Rows.Count > 0)
                selectRowFaultCurrent = this.tileView_1.GetSelectedRows();  //手动记录被按下按钮
            if(selectRowFaultCurrent.Length > 1)
            {
                MessageBox.Show("当前选中不止一行");
            }
        }

        private void simpleButton_ignoreOnce_Click(object sender, EventArgs e)
        {
            //从fault_current中删除所选记录
            if (Global.dtTitleGridShowMainForm.Rows.Count > 0)  //表空的话不进行后续
            {
                if(selectRowFaultCurrent.Length != 1)
                {
                    MessageBox.Show("当前选中不止一行");
                }
                //DataRow drSelected = this.tileView_1.GetFocusedDataRow(); //调用方法获取被选中的row还是有几率获取到DataSource改变时自动选择的第一行，因为可能选中行的手动修改可能还未执行
                DataRow drSelected = this.tileView_1.GetDataRow(selectRowFaultCurrent[0]);  //通过手动记录获取被选中行。GetDataRow通过RowHandler获取行，Rowhandle和行index值相同

                if (drSelected != null) //避免未选中行就点击按钮出错
                {
                    string valLineName = drSelected["LineName"].ToString();
                    string valDeviceName = drSelected["DeviceName"].ToString();
                    string valFaultName = drSelected["FaultName"].ToString();

                    //dtTitleGridShowMainForm中存储的是名称，而faults_current中是ID
                    string cmdTransform = "SELECT t1.LineNO,t2.DeviceNO,t3.FaultNO " +
                                          "FROM productionline AS t1, device AS t2, faults AS t3 " +
                                          "WHERE t1.LineName=" + "'" + valLineName + "'" + " AND t2.DeviceName=" + "'" + valDeviceName + "'" + " AND t3.FaultName=" + "'" + valFaultName + "';";
                    DataTable dtTemp = new DataTable();
                    bool flag1 = Global.mysqlHelper1._queryTableMySQL(cmdTransform, ref dtTemp);
                    if (flag1 == true)
                    {
                        string valLineNO = dtTemp.Rows[0]["LineNO"].ToString();
                        string valDeviceNO = dtTemp.Rows[0]["DeviceNO"].ToString();
                        string valFaultNO = dtTemp.Rows[0]["FaultNO"].ToString();
                        //string valFaultTime = drSelected["FaultTime"].ToString();
                        DateTime valFaultTime = (DateTime)drSelected["FaultTime"];

                        string cmdIgnoreOnce = "DELETE FROM faults_current WHERE " +
                                             "LineNO=" + "'" + valLineNO + "'" + " AND DeviceNO=" + "'" + valDeviceNO + "'" + " AND FaultNO=" +
                                             "'" + valFaultNO + "'" + " AND FaultTime=" + "'" + valFaultTime + "';";

                        bool flag2 = Global.mysqlHelper1._deleteMySQL(cmdIgnoreOnce);
                        //Global.mysqlHelper1.conn.Close();
                        if (flag2 == true)
                        {
                            Global._refreshTitleGridShow();
                            MessageBox.Show("更新表faults_current一次");
                        }
                        keepSelectRowWhenDataSourceRefresh();
                    }
                }
                else
                {
                    MessageBox.Show("未选中故障");
                }


            }
        }

        private void simpleButton_ignoreFaults_Click(object sender, EventArgs e)
        {
            //从fault_current中删除，并修改faults_config对应的Enable
            if (Global.dtTitleGridShowMainForm.Rows.Count > 0 && selectRowFaultCurrent.Length == 1)
            {
                //DataRow drSelected = this.tileView_1.GetFocusedDataRow(); //调用方法获取被选中的row还是有几率获取到DataSource改变时自动选择的第一行，因为可能选中行的手动修改可能还未执行
                DataRow drSelected = this.tileView_1.GetDataRow(selectRowFaultCurrent[0]);  //通过手动记录获取被选中行
                if (drSelected != null)
                {
                    Global.mysqlHelper1._connectMySQL();

                    string valLineName = drSelected["LineName"].ToString();
                    string valDeviceName = drSelected["DeviceName"].ToString();
                    string valFaultName = drSelected["FaultName"].ToString();

                    //dtTitleGridShowMainForm中存储的是名称，而faults_current中是ID
                    string cmdTransfrom = "SELECT t1.LineNO,t2.DeviceNO,t3.FaultNO " +
                                          "FROM productionline AS t1, device AS t2, faults AS t3 " +
                                          "WHERE t1.LineName=" + "'" + valLineName + "'" + " AND t2.DeviceName=" + "'" + valDeviceName + "'" + " AND t3.FaultName=" + "'" + valFaultName + "';";
                    DataTable dtTemp = new DataTable();
                    bool flag1 = Global.mysqlHelper1._queryTableMySQL(cmdTransfrom, ref dtTemp);
                    if (flag1 == true)
                    {
                        string valLineNO = dtTemp.Rows[0]["LineNO"].ToString();
                        string valDeviceNO = dtTemp.Rows[0]["DeviceNO"].ToString();
                        string valFaultNO = dtTemp.Rows[0]["FaultNO"].ToString();
                        //string valFaultTime = drSelected["FaultTime"].ToString();
                        DateTime valFaultTime = (DateTime)drSelected["FaultTime"];

                        string cmdIgnoreOnce = "DELETE FROM faults_current WHERE " +
                                                "LineNO=" + "'" + valLineNO + "'" + " AND DeviceNO=" + "'" + valDeviceNO + "'" + " AND FaultNO=" +
                                                "'" + valFaultNO + "'" + " AND FaultTime=" + "'" + valFaultTime + "';";

                        string cmdUpdateFaultConfig = "UPDATE faults_config SET FaultEnable='0' "
                                                     + "WHERE LineNO=" + "'" + valLineNO + "'" + " AND DeviceNO=" + "'" + valDeviceNO + "'" + " AND FaultNO=" + "'" + valFaultNO + "';";

                        bool flag2 = Global.mysqlHelper1._deleteMySQL(cmdIgnoreOnce);
                        bool flag3 = Global.mysqlHelper1._updateMySQL(cmdUpdateFaultConfig);
                        //Global.mysqlHelper1.conn.Close();

                        if (flag2 == true)
                        {
                            Global._refreshTitleGridShow();
                            MessageBox.Show("更新表faults_current一次");
                        }

                        if (flag3 == true)
                        {
                            MessageBox.Show("更新表faults_config一次");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("未选中故障");
                }
                
            }

        }

        private void pictureEdit_CETC_DoubleClick(object sender, EventArgs e)
        {
            createConfirmationBox("关闭软件？", "close");
        }

        //响应WorkState双击事件翻页到RealTimeData
        private void doubleClickTileViewEach_informMainFormChangePage(object sender, EventArgs e)
        {
            this.tileBar_statusMonitoring.SelectedItem = this.tileBarItem_statusMonitoring_realTimeData;    //手动将子菜单按钮的【实时数据】选中

            if (Global.ifDeviceAdditionOrDeletion == false && Global.ifLineAdditionOrDeletion == false)
            {
                this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
                iSelectedIndex = (int)StatusMonitorPages.realtimePage;
                this.statusMonitorControl1.selectedFramePage = iSelectedIndex;
                currentPage = (int)StatusMonitorPages.historyQueryPage;
                currentPage = processCurrentPage();
            }
            else
            {
                if (currentPage == 13)
                {
                    createConfirmationBox("设备发生变化，确认重启？", "restart");
                }
                if (currentPage == 18)
                {
                    createConfirmationBox("产线发生变化，确认重启？", "restart");
                }
            }
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
