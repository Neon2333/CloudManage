using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManage.DeviceManagement
{
    public partial class DeviceAdditionDeletion : DevExpress.XtraEditors.XtraUserControl
    {
        public static ushort currentPageIndex = 13;

        private int[] selectRowDtDeviceCanDeleteEachLine = { 0 };   //当表变化时当前选中行会自动变成第一行，selectRow[0]记录的选中行重置当前选中行
        private int[] selectRowDtDeviceCanAddEachLine = { 0 };      //手动记录可添加产线grid的行
        private CommonControl.ConfirmationBox confirmationBox1;     //确认框对象
        private CommonControl.InformationBox infoBox_successOrFail; //信息框
        private DeviceAdditionDeletion_addDeviceBox deviceAdditionDeletion_addDeviceBox1;   //添加设备弹出框
        private DeviceAdditionDeletion_addDeviceBox deviceAdditionDeletion_selectMachine1;  //选择Machine弹出框

        string toDeleteDevice = String.Empty;   //要删除的设备
        string deviceNOSel = String.Empty;      //选中的设备的NO
        bool flag_device_info_threshold = false;    //表device_info_threshold修改成功标志
        bool flag_device_config = false;            //表device_config修改成功标志
        bool flag_device_info = false;              //表device_info修改成功标志
        bool flag_device_paraNameAndSuffix = false; //表device_paraNameAndSuffix修改成功标志
        bool flag_faults_config = false;            //表faults_config修改成功标志

        DataRow drSelectedAddDeviceBox = null;      //添加设备弹出框选中行
        DataRow[] drSelectedDevice = null;          //选中设备框
        public DeviceAdditionDeletion()
        {
            InitializeComponent();

            initDeviceAdditionDeletion();   //初始化页面

            MainForm.deviceOrLineAdditionDeletionReinitDeviceAdditionDeletion += reInitDeviceAdditionDeletion;      //绑定重刷新页面事件

            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);
        }

        public void reInitDeviceAdditionDeletion(object sender, EventArgs e)
        {
            //MessageBox.Show("重新刷新DeviceAdditionDeletion页面");
            initDeviceAdditionDeletion();
            Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = Global.SetBitValueInt32(Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion, currentPageIndex, false);  //刷新页面后将该页面的标志位重置
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        void initDeviceAdditionDeletion()
        {
            initSideTileBarDeviceAdditionDeletion();    //初始化侧边栏
            Global.initDtDeviceCanDeleteEachLine();     //初始化可删除设备表
            refreshDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);   //根据侧边栏选中的产线查询可删除的设备到Global.dtDeviceCanDeleteEachLine
            this.gridControl_deviceDeletion.DataSource = Global.dtDeviceCanDeleteEachLine;  //设备增删弹出框grid绑定数据源
            if (((DataTable)this.gridControl_deviceDeletion.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRowDtDeviceCanDeleteEachLine[0]; //默认选中第一行
            }

            Global.initDtDeviceCanAddEachLine();   //初始化可添加设备表
            Global.initDtMachineCanSelectEachDevice();  //初始化可添加机器表
        }

        /// <summary>
        /// 初始化侧边栏
        /// </summary>
        private void initSideTileBarDeviceAdditionDeletion()
        {
            Global._init_dtSideTileBarWorkState();
            this.sideTileBarControl_deviceAdditionDeletion.dtInitSideTileBar = Global.dtSideTileBar;
            this.sideTileBarControl_deviceAdditionDeletion.colTagDT = "LineNO";
            this.sideTileBarControl_deviceAdditionDeletion.colTextDT = "LineName";
            this.sideTileBarControl_deviceAdditionDeletion.colNumDT = "DeviceTotalNum";
            this.sideTileBarControl_deviceAdditionDeletion._initSideTileBar();
        }

        /// <summary>
        /// 显示信息弹出框
        /// </summary>
        /// <param name="infoMsg">弹出框显示的信息</param>
        /// <param name="disappearIntervalMS">显示时间（ms）</param>
        private void initInfoBox_successOrFail(string infoMsg, int disappearIntervalMS)
        {
            this.infoBox_successOrFail = new CommonControl.InformationBox();
            this.infoBox_successOrFail.disappearEnable = false;
            this.infoBox_successOrFail.infoTitle = infoMsg;
            this.infoBox_successOrFail.Location = new System.Drawing.Point(652, 250);
            this.infoBox_successOrFail.Name = "informationBox1";
            this.infoBox_successOrFail.Size = new System.Drawing.Size(350, 150);
            this.infoBox_successOrFail.TabIndex = 36;
            this.infoBox_successOrFail.timeDisappear = disappearIntervalMS;
            this.Controls.Add(this.infoBox_successOrFail);
            this.infoBox_successOrFail.BringToFront();
            this.infoBox_successOrFail.disappearEnable = true;
        }


        //刷新导航目录
        void _refreshLabelDir()
        {
            string str1 = Global._getProductionLineNameByTag(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);
            this.labelControl_dir.Text = "   " + str1;
        }

        private void keepSelectRowWhenDataSourceRefresh()
        {
            if (selectRowDtDeviceCanDeleteEachLine.Length == 1)
            {
                if (selectRowDtDeviceCanDeleteEachLine[0] < this.tileView1.DataRowCount)
                    this.tileView1.FocusedRowHandle = selectRowDtDeviceCanDeleteEachLine[0];     //在DataSource发生改变后，手动修改被选中的row
                else
                {
                    this.tileView1.FocusedRowHandle = 0;
                    selectRowDtDeviceCanDeleteEachLine[0] = 0;
                }
            }
        }

        //记录选中行
        private void gridControl_deviceDeletion_Click(object sender, EventArgs e)
        {
            //记录选中的行
            if (((DataTable)this.gridControl_deviceDeletion.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRowDtDeviceCanDeleteEachLine = this.tileView1.GetSelectedRows();
            }

            if (selectRowDtDeviceCanDeleteEachLine.Length > 1)
            {
                MessageBox.Show("当前选中不止一行");
            }
        }

        /// <summary>
        /// 刷新可删除设备弹出框
        /// 根据lineNO查询该产线可删除的设备到Global.dtDeviceCanDeleteEachLine
        /// </summary>
        /// <param name="LineNO">产线NO</param>
        void refreshDtDeviceCanDeleteEachLine(string LineNO)
        {
            /**
             *  1.  从MySQL中查出的表放到datatable中，datatable若没用Columns.Add()添加表头，query时会自动添加表头；
             *  2.  datatable初始化表头时不一定要和MySQL保持完全一致，可以用Columns.Add()手动添加MySQL表中没有的列，这样通过query填充datatable时，MySQL表中没有的列不会填充，只填充有的列。
             *  3.  添加MySQL表中没有的列，虽然冗余，但有时会简化查询过程，如Global.initDtDeviceCanDeleteEachLine()
             *  4.  使用视图存储一些小的、常用的表可以简化查询
             */
            Global.dtDeviceCanDeleteEachLine.Rows.Clear();

            //获得设备数
            int deviceCountEachLine = 0;
            //DataTable dtDeviceCountEachLine = new DataTable();
            //string cmdGetDeviceEnableCount = "SELECT DeviceCount FROM v_device_count_eachline WHERE LineNO='" + LineNO + "';";
            //Global.mysqlHelper1._queryTableMySQL(cmdGetDeviceEnableCount, ref dtDeviceCountEachLine);

            Global._init_dtSideTileBarWorkState();
            DataRow[] drDtSideTileBar = Global.dtSideTileBar.Select("LineNO='" + LineNO + "'"); //从dtSideTileBar中查询指定lineNO的记录

            if (drDtSideTileBar.Length == 1)
            {
                deviceCountEachLine = Convert.ToInt32(drDtSideTileBar[0]["DeviceTotalNum"]);    //获取lineNO指定的产线的设备总数
            }

            //向Global.dtDeviceCanDeleteEachLine填充NO、产线NO、产线名
            for (int i = 0; i < deviceCountEachLine; i++)
            {
                DataRow dr = Global.dtDeviceCanDeleteEachLine.NewRow();
                dr["NO"] = i;
                dr["LineNO"] = LineNO;
                dr["LineName"] = Global._getProductionLineNameByTag(LineNO);    //获取lineNO指定产线的产线名
                Global.dtDeviceCanDeleteEachLine.Rows.Add(dr);
            }

            //向Global.dtDeviceCanDeleteEachLine中填充DeviceNO、DeviceName、ValidParaCount
            DataTable dtDeviceNOAndValidParaCount = new DataTable();
            string cmdGetDeviceNOAndValidParaCount = "SELECT DeviceNO, ValidParaCount FROM device_info WHERE LineNO='" + LineNO + "';";
            Global.mysqlHelper1._queryTableMySQL(cmdGetDeviceNOAndValidParaCount, ref dtDeviceNOAndValidParaCount);

            for (int i = 0; i < Global.dtDeviceCanDeleteEachLine.Rows.Count; i++)
            {
                Global.dtDeviceCanDeleteEachLine.Rows[i]["DeviceNO"] = dtDeviceNOAndValidParaCount.Rows[i]["DeviceNO"];
                Global.dtDeviceCanDeleteEachLine.Rows[i]["ValidParaCount"] = dtDeviceNOAndValidParaCount.Rows[i]["ValidParaCount"];
                Global.dtDeviceCanDeleteEachLine.Rows[i]["DeviceName"] = Global._getTestingDeviceNameByTag(dtDeviceNOAndValidParaCount.Rows[i]["DeviceNO"].ToString());
            }

            //向Global.dtDeviceCanDeleteEachLine中填充DeviceFaultsCount、DeviceFaultsEnableCount
            DataTable dtDeviceFaultsCountAndFaultsEnableCount = new DataTable();
            string cmdGetDtDeviceFaultsCountAndFaultsEnableCount = "SELECT * FROM v_deviceFaultsCount_and_faultsEnableCount WHERE LineNO='" + LineNO + "';";
            Global.mysqlHelper1._queryTableMySQL(cmdGetDtDeviceFaultsCountAndFaultsEnableCount, ref dtDeviceFaultsCountAndFaultsEnableCount);
            for (int i = 0; i < Global.dtDeviceCanDeleteEachLine.Rows.Count; i++)
            {
                string dn = Global.dtDeviceCanDeleteEachLine.Rows[i]["DeviceNO"].ToString();
                DataRow[] drs = dtDeviceFaultsCountAndFaultsEnableCount.Select("DeviceNO=" + "'" + dn + "'");
                if (drs.Length == 1)
                {
                    Global.dtDeviceCanDeleteEachLine.Rows[i]["DeviceFaultsCount"] = drs[0]["DeviceFaultsCount"];
                    Global.dtDeviceCanDeleteEachLine.Rows[i]["DeviceFaultsEnableCount"] = drs[0]["DeviceFaultsEnableCount"];
                }
            }
            Global.reorderDt(ref Global.dtDeviceCanDeleteEachLine); //给Global.dtDeviceCanDeleteEachLine的NO重排从1开始
            //当表中数据发生改变时，会自动选中第一行，需要用selectRow重置选中行
            if (this.gridControl_deviceDeletion.DataSource != null)
            {
                keepSelectRowWhenDataSourceRefresh();
            }
        }

        /// <summary>
        /// 刷新可添加设备弹出框
        /// 根据指定产线lineNO查询该产线可增加的设备到Global.gffdtDeviceCanAddEachLine
        /// </summary>
        /// <param name="LineNO">指定产线</param>
        private void refreshDtDeviceCanAddEachLine(string LineNO)
        {
            //DataTable dtTemp = Global.dtDeviceCanAddEachLine;
            //if (dtTemp.Columns.Count != 0)
            //{
            //    this.deviceAdditionDeletion_addDeviceBox1.dataSource = dtTemp;
            //}
            Global.dtDeviceCanAddEachLine.Rows.Clear();
            //显示每台产线可添加设备的grid绑定表填充数据
            Global._init_dtDeviceConfig();
            DataRow[] drDeviceConfigSelected = Global.dtDeviceConfig.Select("LineNO='" + LineNO + "'");
            if (drDeviceConfigSelected.Length == 1)
            {
                string[] colNames = Global.GetColumnsByDataTable(Global.dtDeviceConfig);
                for (int i = 2; i < Global.dtDeviceConfig.Columns.Count; i++)
                {
                    if (drDeviceConfigSelected[0][i].ToString() == "0")
                    {
                        //填充DeviceNO
                        string deviceNO = String.Empty;
                        for (int j = 0; j < colNames[i].Length; j++)
                        {
                            if (colNames[i].ElementAt(j) >= '0' && colNames[i].ElementAt(j) <= '9')
                            {
                                deviceNO += colNames[i].ElementAt(j);
                            }
                        }

                        //填充DeviceName
                        string deviceName = String.Empty;
                        DataRow[] drDeviceName = Global.dtTestingDeviceName.Select("DeviceNO='" + deviceNO + "'");
                        if (drDeviceName.Length == 1)
                        {
                            deviceName = drDeviceName[0]["DeviceName"].ToString();
                        }

                        DataRow dr = Global.dtDeviceCanAddEachLine.NewRow();
                        dr["DeviceNO"] = deviceNO;
                        dr["DeviceName"] = deviceName;
                        Global.dtDeviceCanAddEachLine.Rows.Add(dr);
                    }
                }
            }
            Global.reorderDt(ref Global.dtDeviceCanAddEachLine);    //填充NO
            //this.deviceAdditionDeletion_addDeviceBox1.dataSource = Global.dtDeviceCanAddEachLine;
            //当表中数据发生改变时，会自动选中第一行，需要用selectRow重置选中行
            if (this.deviceAdditionDeletion_addDeviceBox1 != null)
            {
                this.deviceAdditionDeletion_addDeviceBox1.currentFocusRowHandler = selectRowDtDeviceCanAddEachLine[0];
            }
        }

        /// <summary>
        /// 刷新deviceNO指定设备可选择的machine列表弹出框
        /// </summary>
        /// <param name="deviceNO"></param>
        public static void refreshDtMachineCanSelectEachDevice(string deviceNO)
        {
            string cmdRefreshDtMachineCanSelectEachDevice = "CALL initDtMachineCanSelectEachDevice('" + deviceNO + "');";
            Global.mysqlHelper1._queryTableMySQL(cmdRefreshDtMachineCanSelectEachDevice, ref Global.dtMachineCanSelectEachDevice);
            Global.reorderDt(ref Global.dtMachineCanSelectEachDevice);
        }

        /// <summary>
        /// 锁定按钮
        /// </summary>
        /// <param name="lockOrUnlock"></param>
        private void lockUnlockButton(string lockOrUnlock)
        {
            if (lockOrUnlock == "lockbtn")
            {
                this.simpleButton_deviceAddition.Enabled = false;
                this.simpleButton_deviceDeletion.Enabled = false;
            }
            else if (lockOrUnlock == "unlockbtn")
            {
                this.simpleButton_deviceAddition.Enabled = true;
                this.simpleButton_deviceDeletion.Enabled = true;
            }
        }

        /// <summary>
        /// 侧边栏选中改变时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sideTileBarControl_deviceAdditionDeletion_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            _refreshLabelDir();
            refreshDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);   //刷新可删除列表
            refreshDtDeviceCanAddEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);      //刷新可添加列表
        }

        //*************************************************************删除设备****************************************************************************
        
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_deviceDeletion_Click(object sender, EventArgs e)
        {

            if (Global.dtDeviceCanDeleteEachLine.Rows.Count != 0)
            {
                lockUnlockButton("lockbtn");
                //弹出确认框
                this.confirmationBox1 = new CommonControl.ConfirmationBox();
                this.confirmationBox1.Appearance.BackColor = System.Drawing.Color.White;
                this.confirmationBox1.Appearance.Options.UseBackColor = true;
                this.confirmationBox1.Location = new System.Drawing.Point(624, 100);
                this.confirmationBox1.Name = "confirmationBox1";
                this.confirmationBox1.Size = new System.Drawing.Size(350, 200);
                this.confirmationBox1.TabIndex = 29;
                DataRow drSelected = tileView1.GetDataRow(selectRowDtDeviceCanDeleteEachLine[0]);    //获取的是grid绑定的表所有列，而不仅仅是显示出来的列
                toDeleteDevice = Global._getTestingDeviceNameByTag(drSelected["DeviceNO"].ToString());  //待删除设备的名称
                this.confirmationBox1.titleConfirmationBox = "确认删除“" + toDeleteDevice + "”?";
                this.confirmationBox1.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox1_ConfirmationBoxOKClicked);
                this.confirmationBox1.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox1_ConfirmationBoxCancelClicked);
                this.Controls.Add(this.confirmationBox1);
                this.confirmationBox1.Visible = true;
                this.confirmationBox1.BringToFront();
            }
        }

        /// <summary>
        /// 设备删除OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmationBox1_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            if (Global.dtDeviceCanDeleteEachLine.Rows.Count != 0)
            {
                DataRow drSelected = tileView1.GetDataRow(selectRowDtDeviceCanDeleteEachLine[0]);    //获取的是grid绑定的表所有列，而不仅仅是显示出来的列

                MySqlParameter lineNO = new MySqlParameter("ln", MySqlDbType.VarChar, 20);
                lineNO.Value = this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem;  //选中的产线的NO
                MySqlParameter deviceNO = new MySqlParameter("dn", MySqlDbType.VarChar, 20);
                deviceNO.Value = drSelected["DeviceNO"];    //选中的要删除的设备的NO
                MySqlParameter ifAffected = new MySqlParameter("ifRowAffected", MySqlDbType.Int32, 1);
                MySqlParameter[] paras = { lineNO, deviceNO, ifAffected };
                string cmdDeleteDevice = "p_deleteDevice";
                Global.mysqlHelper1._executeProcMySQL(cmdDeleteDevice, paras, 2, 1);    //删除设备

                //this.confirmationBox1.Visible = false;

                if (Convert.ToInt32(ifAffected.Value) == 1)
                {
                    initInfoBox_successOrFail("“" + toDeleteDevice + "”删除成功！", 1000);

                    //Global.ifDeviceAdditionOrDeletion = true;
                    //Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = 1;
                    Global.SetInt32AllBit1(ref Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion);    //删除成功，将页面重刷标志位各bit置1

                    initDeviceAdditionDeletion();    //刷新本页面
                    Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = Global.SetBitValueInt32(Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion, currentPageIndex, false);  //刷新页面后将该页面的标志位重置
                    refreshDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);   //刷新可删除设备grid的数据源
                    refreshDtDeviceCanAddEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);      //刷新可添加设备grid的数据源

                    //device_config
                    Global._init_dtDeviceConfig();

                }
                else
                {
                    initInfoBox_successOrFail("“" + toDeleteDevice + "”删除失败！", 2000);
                }

                lockUnlockButton("unlockbtn");
            }
        }

        /// <summary>
        /// 设备删除取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmationBox1_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            lockUnlockButton("unlockbtn");
            //this.confirmationBox1.Visible = false;
        }

        /******************************************************增加设备**************************************************************/
        private void simpleButton_deviceAddition_Click(object sender, EventArgs e)
        {
            //if (this.splashScreenManager_deviceAdditionDeletion.IsSplashFormVisible == true)
            //    this.splashScreenManager_deviceAdditionDeletion.CloseWaitForm();

            lockUnlockButton("lockbtn");

            //创建设备添加框
            if (this.deviceAdditionDeletion_addDeviceBox1 != null)
            {
                this.deviceAdditionDeletion_addDeviceBox1.Dispose();    //创建前一定要销毁上一次new的deviceAdditionDeletion_addDeviceBox1，否则重复点“增加设备时”就会出现很多窗口
            }

            this.splashScreenManager_deviceAdditionDeletion.ShowWaitForm();     //显示等待图标
            refreshDtDeviceCanAddEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);      //根据选中产线刷新可添加设备grid数据源

            //弹出框参数设置
            this.deviceAdditionDeletion_addDeviceBox1 = new DeviceAdditionDeletion_addDeviceBox();
            this.deviceAdditionDeletion_addDeviceBox1.dataSource = Global.dtDeviceCanAddEachLine;
            this.deviceAdditionDeletion_addDeviceBox1.gridLabelLeftText = "序号";
            this.deviceAdditionDeletion_addDeviceBox1.gridLabelRightText = "检测设备名称";
            this.deviceAdditionDeletion_addDeviceBox1.colLeftFiledName = "NO";
            this.deviceAdditionDeletion_addDeviceBox1.colRightFiledName = "DeviceName";
            this.deviceAdditionDeletion_addDeviceBox1.colLeftCaption = "NO";
            this.deviceAdditionDeletion_addDeviceBox1.colRightCaption = "Device Name";
            this.deviceAdditionDeletion_addDeviceBox1.Location = new System.Drawing.Point(524, 100);
            this.deviceAdditionDeletion_addDeviceBox1.Name = "deviceAdditionDeletion_addDeviceBox1";
            this.deviceAdditionDeletion_addDeviceBox1.Size = new System.Drawing.Size(550, 548);
            this.deviceAdditionDeletion_addDeviceBox1.TabIndex = 29;
            this.deviceAdditionDeletion_addDeviceBox1.title = "添加设备";
            this.deviceAdditionDeletion_addDeviceBox1.AddDeviceBoxOKClicked += new DeviceAdditionDeletion_addDeviceBox.SimpleButtonOKClickHanlder(this.deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxOKClicked);
            this.deviceAdditionDeletion_addDeviceBox1.AddDeviceBoxCancelClicked += new DeviceAdditionDeletion_addDeviceBox.SimpleButtonOKClickHanlder(this.deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxCancelClicked);
            this.Controls.Add(this.deviceAdditionDeletion_addDeviceBox1);
            this.deviceAdditionDeletion_addDeviceBox1.BringToFront();
            this.deviceAdditionDeletion_addDeviceBox1.Visible = true;
            Thread.Sleep(1000);
            this.splashScreenManager_deviceAdditionDeletion.CloseWaitForm();
        }

        /// <summary>
        /// 设备添加OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxOKClicked(object sender, EventArgs e)
        {
            if (Global.dtDeviceCanAddEachLine.Rows.Count != 0)
            {
                //DataRow drSelected = Global.dtDeviceCanAddEachLine.Rows[selectRowDtDeviceCanAddEachLine[0]];
                drSelectedAddDeviceBox = this.deviceAdditionDeletion_addDeviceBox1.currentSelectedRow;
                drSelectedDevice = Global.dtTestingDeviceName.Select("DeviceNO=" + drSelectedAddDeviceBox["DeviceNO"]); //选中的设备的NO

                //选择机器
                addDevice_insertDevice_threshold_selectMachine(drSelectedDevice[0]);

                //this.deviceAdditionDeletion_addDeviceBox1.Dispose();
            }
        }

        /// <summary>
        /// 设备添加取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxCancelClicked(object sender, EventArgs e)
        {
            lockUnlockButton("unlockbtn");
            //this.deviceAdditionDeletion_addDeviceBox1.Visible = false;
            //只是visible=false是在堆上new出来的窗口的资源没有释放，所以会随着点击“增加设备”按钮次数的增多而越来越慢，要dispose
            //this.deviceAdditionDeletion_addDeviceBox1.Dispose();    

        }

        /// <summary>
        /// 根据选定的设备，弹出选择machine框
        /// </summary>
        /// <param name="dr"></param>
        private void addDevice_insertDevice_threshold_selectMachine(DataRow dr)
        {
            deviceNOSel = dr["DeviceNO"].ToString();

            refreshDtMachineCanSelectEachDevice(deviceNOSel);   //根据指定设备NO刷新该设备可选择的machine

            this.deviceAdditionDeletion_selectMachine1 = new DeviceAdditionDeletion_addDeviceBox();
            this.deviceAdditionDeletion_selectMachine1.dataSource = Global.dtMachineCanSelectEachDevice;
            this.deviceAdditionDeletion_selectMachine1.title = "添加机器";
            this.deviceAdditionDeletion_selectMachine1.gridLabelLeftText = "序号";
            this.deviceAdditionDeletion_selectMachine1.gridLabelRightText = "机器名称";
            this.deviceAdditionDeletion_selectMachine1.colLeftFiledName = "NO";
            this.deviceAdditionDeletion_selectMachine1.colRightFiledName = "MachineName";
            this.deviceAdditionDeletion_selectMachine1.colLeftCaption = "NO";
            this.deviceAdditionDeletion_selectMachine1.colRightCaption = "Machine Name";
            this.deviceAdditionDeletion_selectMachine1.Location = new System.Drawing.Point(524, 100);
            this.deviceAdditionDeletion_selectMachine1.Name = "deviceAdditionDeletion_selectMachine1";
            this.deviceAdditionDeletion_selectMachine1.Size = new System.Drawing.Size(550, 548);
            this.deviceAdditionDeletion_selectMachine1.TabIndex = 29;
            this.deviceAdditionDeletion_selectMachine1.AddDeviceBoxOKClicked += new DeviceAdditionDeletion_addDeviceBox.SimpleButtonOKClickHanlder(this.deviceAdditionDeletion_selectMachine1_OKClicked);
            this.deviceAdditionDeletion_selectMachine1.AddDeviceBoxCancelClicked += new DeviceAdditionDeletion_addDeviceBox.SimpleButtonOKClickHanlder(this.deviceAdditionDeletion_selectMachine1_CancelClicked);
            this.Controls.Add(this.deviceAdditionDeletion_selectMachine1);
            this.deviceAdditionDeletion_selectMachine1.BringToFront();
            this.deviceAdditionDeletion_selectMachine1.Visible = true;
        }

        /// <summary>
        /// 增加设备选择machine，OK，根据添加的设备更新数据库各表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deviceAdditionDeletion_selectMachine1_OKClicked(object sender, EventArgs e)
        {
            //向表device_threshold中插入记录
            addDevice_insertDevice_threshold(drSelectedDevice[0]);
            //向表device_config中插入记录
            flag_device_config = addDevice_updateDevice_config(drSelectedAddDeviceBox); 

            //向表device_info插入记录
            flag_device_info = addDevice_insertDevice_info(drSelectedDevice[0]);

            //向表device_paraNameAndSuffix中插入记录
            flag_device_paraNameAndSuffix = addDevice_insertDevice_paraNameAndSuffix(drSelectedDevice[0]);

            //向表faults_config中插入记录
            flag_faults_config = addDevice_insertFaults_config(drSelectedDevice[0]);
            if (flag_device_config == true && flag_device_info == true && flag_device_info_threshold == true && flag_device_paraNameAndSuffix == true && flag_faults_config == true)
            {
                initInfoBox_successOrFail("“" + drSelectedAddDeviceBox["DeviceName"].ToString() + "”设备添加成功！", 1000);    //若数据库中所有表都更新成功显示信息弹出框

                //Global.ifDeviceAdditionOrDeletion = true;   //设备发生了增删
                //Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = 1;
                Global.SetInt32AllBit1(ref Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion);    //设备添加成功，将页面重刷标志置1


                initDeviceAdditionDeletion();     //设备添加成功，重刷本页面
                Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = Global.SetBitValueInt32(Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion, currentPageIndex, false);  //刷新页面后将该页面的标志位重置

                refreshDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);   //刷新可删除设备grid显示
                refreshDtDeviceCanAddEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);      //刷新可添加设备grid显示
            }
            else
            {
                initInfoBox_successOrFail("“" + drSelectedAddDeviceBox["DeviceName"].ToString() + "”设备添加失败！", 2000);
            }

            //this.deviceAdditionDeletion_selectMachine1.Dispose();    //选择OK需要手动释放
            lockUnlockButton("unlockbtn");
        }

        /// <summary>
        /// 增加设备选择machine取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deviceAdditionDeletion_selectMachine1_CancelClicked(object sender, EventArgs e)
        {
            lockUnlockButton("unlockbtn");
        }

        /// <summary>
        /// 以侧边栏选中的lineNO、dr中DeviceNO、MachineNO、LocationXL、LocationYui、ValidParaCount、ParaMinDefault、ParaMaxDefault作为取值
        /// 向device_threshold中插入记录（产线NO，设备NO，机器NO，设备坐标X，设备坐标Y，有效参数个数，64个参数的最小值、最大值）
        /// </summary>
        /// <param name="dr"></param>
        private void addDevice_insertDevice_threshold(DataRow dr)
        {
            DataRow drSelectedMachine = this.deviceAdditionDeletion_selectMachine1.currentSelectedRow;  //选中的machine

            string cmdAddDeviceDtDevice_info_threshold = "INSERT INTO device_info_threshold (LineNO, DeviceNO, MachineNO, LocationX, LocationY, ValidParaCount";
            for (int i = 0; i < 64; i++)
            {
                cmdAddDeviceDtDevice_info_threshold = cmdAddDeviceDtDevice_info_threshold + ", Para" + (i + 1).ToString() + "Min" + ", Para" + (i + 1).ToString() + "Max";
            }
            cmdAddDeviceDtDevice_info_threshold += ") VALUES (";
            //cmdAddDeviceDtDevice_info_threshold += "'" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', '" +
            //                                       dr["DeviceNO"].ToString() + "', '" + dr["MachineNO"].ToString() + "', '" +
            //                                       dr["LocationX"].ToString() + "', '" + dr["LocationY"].ToString() + "', '" +
            //                                       dr["ValidParaCount"].ToString() + "', ";
            cmdAddDeviceDtDevice_info_threshold += "'" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', '" +
                                                   dr["DeviceNO"].ToString() + "', '" + drSelectedMachine["MachineNO"].ToString() + "', '" +
                                                   drSelectedMachine["LocationX"].ToString() + "', '" + drSelectedMachine["LocationY"].ToString() + "', '" +
                                                   dr["ValidParaCount"].ToString() + "', ";

            if (dr["Para1MinDefault"].ToString() == "\\")
            {
                cmdAddDeviceDtDevice_info_threshold += "'" + dr["Para1MinDefault"] + "\\', ";
            }
            else
            {
                cmdAddDeviceDtDevice_info_threshold += "'" + dr["Para1MinDefault"] + "', ";
            }
            if (dr["Para1MinDefault"].ToString() == "\\")
            {
                cmdAddDeviceDtDevice_info_threshold += "'" + dr["Para1MaxDefault"] + "\\'";
            }
            else
            {
                cmdAddDeviceDtDevice_info_threshold += "'" + dr["Para1MaxDefault"] + "'";
            }

            for (int i = 1; i < 64; i++)
            {
                string p1 = "Para" + (i + 1).ToString() + "MinDefault";
                string p2 = "Para" + (i + 1).ToString() + "MaxDefault";
                if (dr[p1].ToString() == "\\")
                {
                    cmdAddDeviceDtDevice_info_threshold += ", '" + dr[p1] + "\\'";
                }
                else
                {
                    cmdAddDeviceDtDevice_info_threshold += ", '" + dr[p1] + "'";
                }
                if (dr[p2].ToString() == "\\")
                {
                    cmdAddDeviceDtDevice_info_threshold += ", '" + dr[p2] + "\\'";
                }
                else
                {
                    cmdAddDeviceDtDevice_info_threshold += ", '" + dr[p2] + "'";
                }
            }
            cmdAddDeviceDtDevice_info_threshold += ");";
            flag_device_info_threshold = Global.mysqlHelper1._insertMySQL(cmdAddDeviceDtDevice_info_threshold);
            if (flag_device_info_threshold == true)
            {
                Global.mysqlHelper1._updateMySQL("ALTER TABLE device_info_threshold AUTO_INCREMENT=1;");  //重置主键NO
            }
        }

        /// <summary>
        /// 添加设备在表device_config中添加记录
        /// 根据dr中DeviceNO和侧边栏选中的产线lineNO，将表device_config中的DeviceStatus改为默认值1
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool addDevice_updateDevice_config(DataRow dr)
        {
            //device_config
            string cmdAddDtDevice_config = "UPDATE device_config SET DeviceStatus_" + dr["DeviceNO"].ToString() +
                                       "='1' WHERE LineNO='" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "';";
            bool flag = false;
            flag = Global.mysqlHelper1._updateMySQL(cmdAddDtDevice_config);
            return flag;
        }

        /// <summary>
        /// 以侧边栏选中产线lineNO,dr["DeviceNO"]，deviceStatusDefault，dr["ValidParaCount"]，dr["ParaDefault"]为取值
        /// 插入表device_info的字段LineNO, DeviceNO, DeviceStatus, ValidParaCount，Para1~Para64
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool addDevice_insertDevice_info(DataRow dr)
        {
            //device_info
            string cmdAddDeviceDtDeviceInfo = "Insert INTO device_info (LineNO, DeviceNO, DeviceStatus, ValidParaCount";
            for (int i = 0; i < 64; i++)
            {
                cmdAddDeviceDtDeviceInfo = cmdAddDeviceDtDeviceInfo + ", Para" + (i + 1).ToString();
            }
            cmdAddDeviceDtDeviceInfo += ") VALUES (";
            string deviceStatusDefault = "'1'"; //添加的设备的的状态初始值默认为1
            for (int i = 0; i < 64; i++)
            {
                string p = "Para" + (i + 1).ToString() + "Default";
                string pMin = "Para" + (i + 1).ToString() + "MinDefault";
                string pMax = "Para" + (i + 1).ToString() + "MaxDefault";
                if (dr[p].ToString() != "\\")
                {
                    if (Convert.ToDouble(dr[p]) < Convert.ToDouble(dr[pMin]) || Convert.ToDouble(dr[p]) > Convert.ToDouble(dr[pMax]))   //添加的设备的参数若存在超限则状态DeviceStatus初始值设为0
                    {
                        deviceStatusDefault = "'0'";
                    }
                }
            }

            cmdAddDeviceDtDeviceInfo += "'" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', '" + dr["DeviceNO"].ToString() + "', " + deviceStatusDefault + ", '" + dr["ValidParaCount"].ToString() + "'";
            for (int i = 0; i < 64; i++)
            {
                string p = "Para" + (i + 1).ToString() + "Default";
                if (dr[p].ToString() == "\\")
                {
                    cmdAddDeviceDtDeviceInfo = cmdAddDeviceDtDeviceInfo + ", " + "'" + dr[p].ToString() + "\\'";
                }
                else
                {
                    cmdAddDeviceDtDeviceInfo = cmdAddDeviceDtDeviceInfo + ", " + "'" + dr[p].ToString() + "'";
                }
            }
            cmdAddDeviceDtDeviceInfo += ");";
            bool flag = Global.mysqlHelper1._insertMySQL(cmdAddDeviceDtDeviceInfo);
            if (flag == true)
            {
                Global.mysqlHelper1._updateMySQL("ALTER TABLE device_info AUTO_INCREMENT=1;");  //重置主键NO
            }
            return flag;
        }

        /// <summary>
        /// 以侧边栏选中产线lineNO，dr["DeviceNO"]， dr["ValidParaCount"]，dr["Para1NameDefault"],dr["Para1SuffixDefault"]...dr["Para64NameDefault"],dr["Para64SuffixDefault"]作为取值
        /// 插入表device_info_paranameandsuffix的字段LineNO, DeviceNO, ValidParaCount，ParaName，ParaSuffix
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool addDevice_insertDevice_paraNameAndSuffix(DataRow dr)
        {
            //device_paraNameAndSuffix
            string cmdAddDevice_paraNameAndSuffix = "INSERT INTO device_info_paranameandsuffix (LineNO, DeviceNO, ValidParaCount";
            for (int i = 0; i < 64; i++)
            {
                cmdAddDevice_paraNameAndSuffix = cmdAddDevice_paraNameAndSuffix + ", Para" + (i + 1).ToString() + "Name" + ", Para" + (i + 1).ToString() + "Suffix";
            }
            cmdAddDevice_paraNameAndSuffix += ") VALUES (";
            cmdAddDevice_paraNameAndSuffix += "'" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', '" +
                                                   dr["DeviceNO"].ToString() + "', '" +
                                                   dr["ValidParaCount"].ToString() + "', ";
            if (dr["Para1NameDefault"].ToString() == "\\")
            {
                cmdAddDevice_paraNameAndSuffix += "'" + dr["Para1NameDefault"] + "\\', ";
            }
            else
            {
                cmdAddDevice_paraNameAndSuffix += "'" + dr["Para1NameDefault"] + "', ";
            }
            if (dr["Para1SuffixDefault"].ToString() == "\\")
            {
                cmdAddDevice_paraNameAndSuffix += "'" + dr["Para1SuffixDefault"] + "\\'";
            }
            else
            {
                cmdAddDevice_paraNameAndSuffix += "'" + dr["Para1SuffixDefault"] + "'";
            }

            for (int i = 1; i < 64; i++)
            {
                string p1 = "Para" + (i + 1).ToString() + "NameDefault";
                string p2 = "Para" + (i + 1).ToString() + "SuffixDefault";
                if (dr[p1].ToString() == "\\")
                {
                    cmdAddDevice_paraNameAndSuffix += ", '" + dr[p1] + "\\'";
                }
                else
                {
                    cmdAddDevice_paraNameAndSuffix += ", '" + dr[p1] + "'";
                }
                if (dr[p2].ToString() == "\\")
                {
                    cmdAddDevice_paraNameAndSuffix += ", '" + dr[p2] + "\\'";
                }
                else
                {
                    cmdAddDevice_paraNameAndSuffix += ", '" + dr[p2] + "'";
                }
            }
            cmdAddDevice_paraNameAndSuffix += ");";
            bool flag = Global.mysqlHelper1._insertMySQL(cmdAddDevice_paraNameAndSuffix);
            if (flag == true)
            {
                Global.mysqlHelper1._updateMySQL("ALTER TABLE device_info_paranameandsuffix AUTO_INCREMENT=1;");  //重置主键NO
            }
            return flag;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool addDevice_insertFaults_config(DataRow dr)
        {
            //faults_config
            string cmdFaultsDevice = "SELECT * FROM faults WHERE DeviceNO=" + dr["DeviceNO"].ToString() + ";";
            DataTable dtFaultsDevice = new DataTable();
            Global.mysqlHelper1._queryTableMySQL(cmdFaultsDevice, ref dtFaultsDevice);  //查询DeviceNO==dr["DeviceNO"]设备的所有故障

            bool flag = true;
            for (int i = 0; i < dtFaultsDevice.Rows.Count; i++)
            {
                string fn = dtFaultsDevice.Rows[i]["FaultNO"].ToString();
                string cmdAddDtFaults_config = "INSERT INTO faults_config (LineNO, DeviceNO, FaultNO, FaultEnable) VALUES (" +
                                               "'" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', " + "'" + dr["DeviceNO"].ToString() + "', " +
                                               "'" + fn + "', " + "'1');";
                flag = flag && Global.mysqlHelper1._insertMySQL(cmdAddDtFaults_config);     //向fualts_config中插入DeviceNO==dr["DeviceNO"]设备的所有故障，并将故障使能置1
            }
            if (flag == true)
            {
                Global.mysqlHelper1._updateMySQL("ALTER TABLE faults_config AUTO_INCREMENT=1;");  //重置主键NO
            }
            return flag;
        }


        //添加设备后，MySQL中表已变化，但datatable暂时未变。
        //经过调试，发现用到表device_config、device_info、device_threshold、device_para、faults_config的地方，好像都从MySQL中重新查询了datatable？
        //目前发现未更新的地方只有侧边栏的num，即各产线的设备数未更新

    }
}
