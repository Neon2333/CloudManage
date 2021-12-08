using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManage.DeviceManagement
{
    public partial class DeviceAdditionDeletion : DevExpress.XtraEditors.XtraUserControl
    {
        private int[] selectRowDtDeviceCanDeleteEachLine = { 0 };   //当表变化时当前选中行会自动变成第一行，selectRow[0]记录的选中行重置当前选中行
        private int[] selectRowDtDeviceCanAddEachLine = { 0 };
        private CommonControl.ConfirmationBox confirmationBox1;


        public DeviceAdditionDeletion()
        {
            InitializeComponent();

            initDeviceAdditionDeletion();
        }

        void initDeviceAdditionDeletion()
        {
            initSideTileBarWorkState();
            Global.initDtDeviceCanDeleteEachLine();     //初始化可删除设备表
            refreshDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);
            this.gridControl_deviceAdditionDeletion.DataSource = Global.dtDeviceCanDeleteEachLine;
            if (((DataTable)this.gridControl_deviceAdditionDeletion.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRowDtDeviceCanDeleteEachLine[0]; //默认选中第一行
            }

            Global.initDtDeviceCanAddEachLine();   //初始化可添加设备表
        }

        private void initSideTileBarWorkState()
        {
            this.sideTileBarControl_deviceAdditionDeletion.dtInitSideTileBar = Global.dtSideTileBar;
            this.sideTileBarControl_deviceAdditionDeletion.colTagDT = "LineNO";
            this.sideTileBarControl_deviceAdditionDeletion.colTextDT = "LineName";
            this.sideTileBarControl_deviceAdditionDeletion.colNumDT = "DeviceTotalNum";
            this.sideTileBarControl_deviceAdditionDeletion._initSideTileBar();
        }

        //刷新导航目录
        void _refreshLabelDir()
        {
            string str1 = Global._getProductionLineNameByTag(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);
            this.labelControl_dir.Text = "   " + str1;
        }

        //记录选中行
        private void gridControl_deviceAdditionDeletion_Click(object sender, EventArgs e)
        {
            //记录选中的行
            if (((DataTable)this.gridControl_deviceAdditionDeletion.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRowDtDeviceCanDeleteEachLine = this.tileView1.GetSelectedRows();
            }
            if(this.deviceAdditionDeletion_addDeviceBox1!=null)
                selectRowDtDeviceCanAddEachLine[0] = this.deviceAdditionDeletion_addDeviceBox1.currentFocusRowHandler;
        }

        //填充dtDeviceCanDeleteEachLine
        void refreshDtDeviceCanDeleteEachLine(string LineNO)
        {
            /**
             *  1.  从MySQL中查出的表放到datatable中，datatable若没用Columns.Add()添加表头，query时会自动添加表头；
             *  2.  datatable初始化表头时不一定要和MySQL保持完全一致，可以用Columns.Add()手动添加MySQL表中没有的列，这样通过query填充datatable时，MySQL表中没有的列不会填充，只填充有的列。
             *  3.  添加MySQL表中没有的列，虽然冗余，但有时会简化查询过程，如Global.initDtDeviceCanDeleteEachLine()
             *  4.  使用视图存储一些小的、常用的表可以简化查询
             */

            Global.dtDeviceCanDeleteEachLine.Rows.Clear();

            //MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            //mysqlHelper1._connectMySQL();
            //获得设备数
            int deviceCountEachLine = 0;
            DataTable dtDeviceCountEachLine = new DataTable();
            string cmdGetDeviceEnableCount = "SELECT DeviceCount FROM v_device_count_eachline WHERE LineNO='" + LineNO + "';";
            Global.mysqlHelper1._queryTableMySQL(cmdGetDeviceEnableCount, ref dtDeviceCountEachLine);
            if (dtDeviceCountEachLine.Rows.Count == 1)
            {
                deviceCountEachLine = Convert.ToInt32(dtDeviceCountEachLine.Rows[0][0]);
            }

            for (int i = 0; i < deviceCountEachLine; i++)
            {
                DataRow dr = Global.dtDeviceCanDeleteEachLine.NewRow();
                dr["NO"] = i;
                dr["LineNO"] = LineNO;
                dr["LineName"] = Global._getProductionLineNameByTag(LineNO);
                Global.dtDeviceCanDeleteEachLine.Rows.Add(dr);
            }

            //填充DeviceNO、DeviceName、ValidParaCount
            DataTable dtDeviceNOAndValidParaCount = new DataTable();
            string cmdGetDeviceNOAndValidParaCount = "SELECT DeviceNO, ValidParaCount FROM device_info WHERE LineNO='" + LineNO + "';";
            Global.mysqlHelper1._queryTableMySQL(cmdGetDeviceNOAndValidParaCount, ref dtDeviceNOAndValidParaCount);

            for (int i = 0; i < Global.dtDeviceCanDeleteEachLine.Rows.Count; i++)
            {
                Global.dtDeviceCanDeleteEachLine.Rows[i]["DeviceNO"] = dtDeviceNOAndValidParaCount.Rows[i]["DeviceNO"];
                Global.dtDeviceCanDeleteEachLine.Rows[i]["ValidParaCount"] = dtDeviceNOAndValidParaCount.Rows[i]["ValidParaCount"];
                Global.dtDeviceCanDeleteEachLine.Rows[i]["DeviceName"] = Global._getTestingDeviceNameByTag(dtDeviceNOAndValidParaCount.Rows[i]["DeviceNO"].ToString());
            }

            //填充DeviceFaultsCount、DeviceFaultsEnableCount
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
            Global.reorderDt(ref Global.dtDeviceCanDeleteEachLine);
            //当表中数据发生改变时，会自动选中第一行，需要用selectRow重置选中行
            if (this.gridControl_deviceAdditionDeletion.DataSource != null)
            {
                this.tileView1.FocusedRowHandle = selectRowDtDeviceCanDeleteEachLine[0];
            }
        }

        private void refreshDtDeviceCanAddEachLine(string LineNO)
        {
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
            //填充NO
            Global.reorderDt(ref Global.dtDeviceCanAddEachLine);

            //当表中数据发生改变时，会自动选中第一行，需要用selectRow重置选中行
            if (this.deviceAdditionDeletion_addDeviceBox1 != null)
            {
                this.deviceAdditionDeletion_addDeviceBox1.currentFocusRowHandler = selectRowDtDeviceCanAddEachLine[0];
            }
        }

        private void sideTileBarControl_deviceAdditionDeletion_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            _refreshLabelDir();
            refreshDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);   //刷新可删除列表
            refreshDtDeviceCanAddEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);      //刷新可添加列表
        }

        

        private void simpleButton_deviceAddition_Click(object sender, EventArgs e)
        {
            //创建设备添加框
            this.deviceAdditionDeletion_addDeviceBox1 = new DeviceAdditionDeletion_addDeviceBox();
            this.deviceAdditionDeletion_addDeviceBox1.Location = new System.Drawing.Point(535, 252);
            this.deviceAdditionDeletion_addDeviceBox1.Name = "deviceAdditionDeletion_addDeviceBox1";
            this.deviceAdditionDeletion_addDeviceBox1.Size = new System.Drawing.Size(550, 548);
            this.deviceAdditionDeletion_addDeviceBox1.TabIndex = 29;
            this.deviceAdditionDeletion_addDeviceBox1.titleAddDeviceBox = "添加设备";
            this.deviceAdditionDeletion_addDeviceBox1.AddDeviceBoxOKClicked += new DeviceAdditionDeletion_addDeviceBox.SimpleButtonOKClickHanlder(this.deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxOKClicked);
            this.deviceAdditionDeletion_addDeviceBox1.AddDeviceBoxCancelClicked += new DeviceAdditionDeletion_addDeviceBox.SimpleButtonOKClickHanlder(this.deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxCancelClicked);
            this.Controls.Add(this.deviceAdditionDeletion_addDeviceBox1);
            this.deviceAdditionDeletion_addDeviceBox1.Visible = true;
            this.deviceAdditionDeletion_addDeviceBox1.BringToFront();
            this.deviceAdditionDeletion_addDeviceBox1.dataSource = Global.dtDeviceCanAddEachLine;

            refreshDtDeviceCanAddEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);
        }

        private void simpleButton_deviceDeletion_Click(object sender, EventArgs e)
        {
            if (Global.dtDeviceCanDeleteEachLine.Rows.Count != 0)
            {
                //弹出确认框
                this.confirmationBox1 = new CommonControl.ConfirmationBox();
                this.confirmationBox1.Appearance.BackColor = System.Drawing.Color.White;
                this.confirmationBox1.Appearance.Options.UseBackColor = true;
                this.confirmationBox1.Location = new System.Drawing.Point(627, 169);
                this.confirmationBox1.Name = "confirmationBox1";
                this.confirmationBox1.Size = new System.Drawing.Size(350, 200);
                this.confirmationBox1.TabIndex = 29;
                DataRow drSelected = tileView1.GetDataRow(selectRowDtDeviceCanDeleteEachLine[0]);    //获取的是grid绑定的表所有列，而不仅仅是显示出来的列
                this.confirmationBox1.titleConfirmationBox = "确认删除  " + Global._getTestingDeviceNameByTag(drSelected["DeviceNO"].ToString()) + "?";
                this.confirmationBox1.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox1_ConfirmationBoxOKClicked);
                this.confirmationBox1.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox1_ConfirmationBoxCancelClicked);
                this.Controls.Add(this.confirmationBox1);
                this.confirmationBox1.Visible = true;
                this.confirmationBox1.BringToFront();
            }
        }

        private void confirmationBox1_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            if (Global.dtDeviceCanDeleteEachLine.Rows.Count != 0)
            {
                DataRow drSelected = tileView1.GetDataRow(selectRowDtDeviceCanDeleteEachLine[0]);    //获取的是grid绑定的表所有列，而不仅仅是显示出来的列

                MySqlParameter lineNO = new MySqlParameter("ln", MySqlDbType.VarChar, 20);
                lineNO.Value = this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem;
                MySqlParameter deviceNO = new MySqlParameter("dn", MySqlDbType.VarChar, 20);
                deviceNO.Value = drSelected["DeviceNO"];
                MySqlParameter ifAffected = new MySqlParameter("ifRowAffected", MySqlDbType.Int32, 1);
                MySqlParameter[] paras = { lineNO, deviceNO, ifAffected };
                string cmdDeleteDevice = "p_deleteDevice";
                Global.mysqlHelper1._executeProcMySQL(cmdDeleteDevice, paras, 2, 1);

                this.confirmationBox1.Visible = false;

                if (Convert.ToInt32(ifAffected.Value) == 1)
                {
                    MessageBox.Show("删除成功");
                    Global.ifDeviceAdditionOrDeletion = true;
                    refreshDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);   //刷新grid显示
                    refreshDtDeviceCanAddEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);
                }
                else if (Convert.ToInt32(ifAffected.Value) == 0)
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void confirmationBox1_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            this.confirmationBox1.Visible = false;
        }

        private void deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxOKClicked(object sender, EventArgs e)
        {
            if (Global.dtDeviceCanAddEachLine.Rows.Count != 0)
            {
                //DataRow drSelected = Global.dtDeviceCanAddEachLine.Rows[selectRowDtDeviceCanAddEachLine[0]];
                DataRow drSelected = this.deviceAdditionDeletion_addDeviceBox1.currentSelectedRow;
                DataRow[] drDevice = Global.dtTestingDeviceName.Select("DeviceNO=" + drSelected["DeviceNO"]);

                //device_config
                string cmdAddDtDevice_config = "UPDATE device_config SET DeviceStatus_" + drSelected["DeviceNO"].ToString() +
                                           "='1' WHERE LineNO='" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "';";
                bool flag_device_config = false;
                flag_device_config = Global.mysqlHelper1._updateMySQL(cmdAddDtDevice_config);


                //device_info
                string cmdAddDeviceDtDeviceInfo = "Insert INTO device_info (LineNO, DeviceNO, DeviceStatus, ValidParaCount";
                for (int i = 0; i < 64; i++)
                {
                    cmdAddDeviceDtDeviceInfo = cmdAddDeviceDtDeviceInfo + ", Para" + (i + 1).ToString();
                }
                cmdAddDeviceDtDeviceInfo += ") VALUES (";
                cmdAddDeviceDtDeviceInfo += "'" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', '" + drDevice[0]["DeviceNO"].ToString() + "', " + "'1', '" + drDevice[0]["ValidParaCount"].ToString() + "'";
                for (int i = 0; i < 64; i++)
                {
                    string p = "Para" + (i + 1).ToString() + "Default";
                    if (drDevice[0][p].ToString() == "\\")
                    {
                        cmdAddDeviceDtDeviceInfo = cmdAddDeviceDtDeviceInfo + ", " + "'" + drDevice[0][p].ToString() + "\\'";
                    }
                    else
                    {
                        cmdAddDeviceDtDeviceInfo = cmdAddDeviceDtDeviceInfo + ", " + "'" + drDevice[0][p].ToString() + "'";
                    }
                }
                cmdAddDeviceDtDeviceInfo += ");";
                bool flag_device_info = Global.mysqlHelper1._insertMySQL(cmdAddDeviceDtDeviceInfo);
                if (flag_device_info == true)
                {
                    Global.mysqlHelper1._updateMySQL("ALTER TABLE device_info AUTO_INCREMENT=1;");  //重置主键NO
                }

                //device_threshold
                string cmdAddDeviceDtDevice_info_threshold = "INSERT INTO device_info_threshold (LineNO, DeviceNO, MachineNO, LocationX, LocationY, ValidParaCount";
                for (int i = 0; i < 64; i++)
                {
                    cmdAddDeviceDtDevice_info_threshold = cmdAddDeviceDtDevice_info_threshold + ", Para" + (i + 1).ToString() + "Min" + ", Para" + (i + 1).ToString() + "Max";
                }
                cmdAddDeviceDtDevice_info_threshold += ") VALUES (";
                cmdAddDeviceDtDevice_info_threshold += "'" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', '" +
                                                       drDevice[0]["DeviceNO"].ToString() + "', '" + drDevice[0]["MachineNO"].ToString() + "', '" +
                                                       drDevice[0]["LocationX"].ToString() + "', '" + drDevice[0]["LocationY"].ToString() + "', '" +
                                                       drDevice[0]["ValidParaCount"].ToString() + "', ";
                if (drDevice[0]["Para1MinDefault"].ToString() == "\\")
                {
                    cmdAddDeviceDtDevice_info_threshold += "'" + drDevice[0]["Para1MinDefault"] + "\\', ";
                }
                else
                {
                    cmdAddDeviceDtDevice_info_threshold += "'" + drDevice[0]["Para1MinDefault"] + "', ";
                }
                if (drDevice[0]["Para1MinDefault"].ToString() == "\\")
                {
                    cmdAddDeviceDtDevice_info_threshold += "'" + drDevice[0]["Para1MaxDefault"] + "\\'";
                }
                else
                {
                    cmdAddDeviceDtDevice_info_threshold += "'" + drDevice[0]["Para1MaxDefault"] + "'";
                }

                for (int i = 1; i < 64; i++)
                {
                    string p1 = "Para" + (i + 1).ToString() + "MinDefault";
                    string p2 = "Para" + (i + 1).ToString() + "MaxDefault";
                    if (drDevice[0][p1].ToString() == "\\")
                    {
                        cmdAddDeviceDtDevice_info_threshold += ", '" + drDevice[0][p1] + "\\'";
                    }
                    else
                    {
                        cmdAddDeviceDtDevice_info_threshold += ", '" + drDevice[0][p1] + "'";
                    }
                    if (drDevice[0][p2].ToString() == "\\")
                    {
                        cmdAddDeviceDtDevice_info_threshold += ", '" + drDevice[0][p2] + "\\'";
                    }
                    else
                    {
                        cmdAddDeviceDtDevice_info_threshold += ", '" + drDevice[0][p2] + "'";
                    }
                }
                cmdAddDeviceDtDevice_info_threshold += ");";
                bool flag_device_info_threshold = Global.mysqlHelper1._insertMySQL(cmdAddDeviceDtDevice_info_threshold);
                if (flag_device_info_threshold == true)
                {
                    Global.mysqlHelper1._updateMySQL("ALTER TABLE device_info_threshold AUTO_INCREMENT=1;");  //重置主键NO
                }

                //device_paraNameAndSuffix
                string cmdAddDevice_paraNameAndSuffix = "INSERT INTO device_info_paranameandsuffix (LineNO, DeviceNO, ValidParaCount";
                for (int i = 0; i < 64; i++)
                {
                    cmdAddDevice_paraNameAndSuffix = cmdAddDevice_paraNameAndSuffix + ", Para" + (i + 1).ToString() + "Name" + ", Para" + (i + 1).ToString() + "Suffix";
                }
                cmdAddDevice_paraNameAndSuffix += ") VALUES (";
                cmdAddDevice_paraNameAndSuffix += "'" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', '" +
                                                       drDevice[0]["DeviceNO"].ToString() + "', '" +
                                                       drDevice[0]["ValidParaCount"].ToString() + "', ";
                if (drDevice[0]["Para1NameDefault"].ToString() == "\\")
                {
                    cmdAddDevice_paraNameAndSuffix += "'" + drDevice[0]["Para1NameDefault"] + "\\', ";
                }
                else
                {
                    cmdAddDevice_paraNameAndSuffix += "'" + drDevice[0]["Para1NameDefault"] + "', ";
                }
                if (drDevice[0]["Para1SuffixDefault"].ToString() == "\\")
                {
                    cmdAddDevice_paraNameAndSuffix += "'" + drDevice[0]["Para1SuffixDefault"] + "\\'";
                }
                else
                {
                    cmdAddDevice_paraNameAndSuffix += "'" + drDevice[0]["Para1SuffixDefault"] + "'";
                }

                for (int i = 1; i < 64; i++)
                {
                    string p1 = "Para" + (i + 1).ToString() + "NameDefault";
                    string p2 = "Para" + (i + 1).ToString() + "SuffixDefault";
                    if (drDevice[0][p1].ToString() == "\\")
                    {
                        cmdAddDevice_paraNameAndSuffix += ", '" + drDevice[0][p1] + "\\'";
                    }
                    else
                    {
                        cmdAddDevice_paraNameAndSuffix += ", '" + drDevice[0][p1] + "'";
                    }
                    if (drDevice[0][p2].ToString() == "\\")
                    {
                        cmdAddDevice_paraNameAndSuffix += ", '" + drDevice[0][p2] + "\\'";
                    }
                    else
                    {
                        cmdAddDevice_paraNameAndSuffix += ", '" + drDevice[0][p2] + "'";
                    }
                }
                cmdAddDevice_paraNameAndSuffix += ");";
                bool flag_device_paraNameAndSuffix = Global.mysqlHelper1._insertMySQL(cmdAddDevice_paraNameAndSuffix);
                if (flag_device_paraNameAndSuffix == true)
                {
                    Global.mysqlHelper1._updateMySQL("ALTER TABLE device_info_paranameandsuffix AUTO_INCREMENT=1;");  //重置主键NO
                }

                //faults_config
                string cmdFaultsDevice = "SELECT * FROM faults WHERE DeviceNO=" + drSelected["DeviceNO"].ToString() + ";";
                DataTable dtFaultsDevice = new DataTable();
                Global.mysqlHelper1._queryTableMySQL(cmdFaultsDevice, ref dtFaultsDevice);

                bool flag_faults_config = true;
                for (int i = 0; i < dtFaultsDevice.Rows.Count; i++)
                {
                    string fn = dtFaultsDevice.Rows[i]["FaultNO"].ToString();
                    string cmdAddDtFaults_config = "INSERT INTO faults_config (LineNO, DeviceNO, FaultNO, FaultEnable) VALUES (" +
                                                   "'" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', " + "'" + drSelected["DeviceNO"].ToString() + "', " +
                                                   "'" + fn + "', " + "'1');";
                    flag_faults_config = flag_faults_config && Global.mysqlHelper1._insertMySQL(cmdAddDtFaults_config); ;
                }
                if (flag_faults_config == true)
                {
                    Global.mysqlHelper1._updateMySQL("ALTER TABLE faults_config AUTO_INCREMENT=1;");  //重置主键NO
                }

                if (flag_device_config == true && flag_device_info == true && flag_device_info_threshold == true && flag_device_paraNameAndSuffix == true && flag_faults_config == true)
                {
                    MessageBox.Show("添加成功");
                    Global.ifDeviceAdditionOrDeletion = true;   //设备发生了增删
                    refreshDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);   //刷新grid显示
                    refreshDtDeviceCanAddEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
        }

        private void deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxCancelClicked(object sender, EventArgs e)
        {
            this.deviceAdditionDeletion_addDeviceBox1.Visible = false;
        }

        //添加设备后，MySQL中表已变化，但datatable暂时未变。
        //经过调试，发现用到表device_config、device_info、device_threshold、device_para、faults_config的地方，好像都从MySQL中重新查询了datatable？
        //目前发现未更新的地方只有侧边栏的num，即各产线的设备数未更新

    }
}
