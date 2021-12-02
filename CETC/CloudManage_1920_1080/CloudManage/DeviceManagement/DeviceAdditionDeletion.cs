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
        private int[] selectRow = { 0 };
        private CommonControl.ConfirmationBox confirmationBox1;



        public DeviceAdditionDeletion()
        {
            InitializeComponent();

            initDeviceAdditionDeletion();
        }

        void initDeviceAdditionDeletion()
        {
            initSideTileBarWorkState();
            Global.initDtDeviceCanDeleteEachLine();
            getDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);
            this.gridControl_deviceAdditionDeletion.DataSource = Global.dtDeviceCanDeleteEachLine;
            if (((DataTable)this.gridControl_deviceAdditionDeletion.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRow[0]; //默认选中第一行
            }
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

        //填充dtDeviceCanDeleteEachLine
        void getDtDeviceCanDeleteEachLine(string LineNO)
        {
            /**
             *  1.  从MySQL中查出的表放到datatable中，datatable若没用Columns.Add()添加表头，query时会自动添加表头；
             *  2.  datatable初始化表头时不一定要和MySQL保持完全一致，可以用Columns.Add()手动添加MySQL表中没有的列，这样通过query填充datatable时，MySQL表中没有的列不会填充，只填充有的列。
             *  3.  添加MySQL表中没有的列，虽然冗余，但有时会简化查询过程，如Global.initDtDeviceCanDeleteEachLine()
             *  4.  使用视图存储一些小的、常用的表可以简化查询
             */
            Global.dtDeviceCanDeleteEachLine.Rows.Clear();

            MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            mysqlHelper1._connectMySQL();
            //获得设备数
            int deviceCountEachLine = 0;
            DataTable dtDeviceCountEachLine = new DataTable();
            string cmdGetDeviceEnableCount = "SELECT DeviceCount FROM v_device_count_eachline WHERE LineNO='" + LineNO + "';";
            mysqlHelper1._queryTableMySQL(cmdGetDeviceEnableCount, ref dtDeviceCountEachLine);
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
            mysqlHelper1._queryTableMySQL(cmdGetDeviceNOAndValidParaCount, ref dtDeviceNOAndValidParaCount);

            for (int i = 0; i < Global.dtDeviceCanDeleteEachLine.Rows.Count; i++)
            {
                Global.dtDeviceCanDeleteEachLine.Rows[i]["DeviceNO"] = dtDeviceNOAndValidParaCount.Rows[i]["DeviceNO"];
                Global.dtDeviceCanDeleteEachLine.Rows[i]["ValidParaCount"] = dtDeviceNOAndValidParaCount.Rows[i]["ValidParaCount"];
                Global.dtDeviceCanDeleteEachLine.Rows[i]["DeviceName"] = Global._getTestingDeviceNameByTag(dtDeviceNOAndValidParaCount.Rows[i]["DeviceNO"].ToString());
            }

            //填充DeviceFaultsCount、DeviceFaultsEnableCount
            DataTable dtDeviceFaultsCountAndFaultsEnableCount = new DataTable();
            string cmdGetDtDeviceFaultsCountAndFaultsEnableCount = "SELECT * FROM v_deviceFaultsCount_and_faultsEnableCount WHERE LineNO='" + LineNO + "';";
            mysqlHelper1._queryTableMySQL(cmdGetDtDeviceFaultsCountAndFaultsEnableCount, ref dtDeviceFaultsCountAndFaultsEnableCount);
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
            mysqlHelper1.conn.Close();
        }

        private void sideTileBarControl_deviceAdditionDeletion_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            _refreshLabelDir();
            getDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);
        }

        //记录选中行
        private void gridControl_deviceAdditionDeletion_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_deviceAdditionDeletion.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRow = this.tileView1.GetSelectedRows();   //记录选中的行
            }
        }

        private void simpleButton_deviceAddition_Click(object sender, EventArgs e)
        {
            this.deviceAdditionDeletion_addDeviceBox1 = new DeviceAdditionDeletion_addDeviceBox();
            this.deviceAdditionDeletion_addDeviceBox1.Location = new System.Drawing.Point(6, 246);
            this.deviceAdditionDeletion_addDeviceBox1.Name = "deviceAdditionDeletion_addDeviceBox1";
            this.deviceAdditionDeletion_addDeviceBox1.Size = new System.Drawing.Size(550, 548);
            this.deviceAdditionDeletion_addDeviceBox1.TabIndex = 29;
            this.deviceAdditionDeletion_addDeviceBox1.titleAddDeviceBox = "添加设备";

            this.deviceAdditionDeletion_addDeviceBox1.AddDeviceBoxOKClicked += new DeviceAdditionDeletion_addDeviceBox.SimpleButtonOKClickHanlder(this.deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxOKClicked);
            this.deviceAdditionDeletion_addDeviceBox1.AddDeviceBoxCancelClicked += new DeviceAdditionDeletion_addDeviceBox.SimpleButtonOKClickHanlder(this.deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxCancelClicked);

            this.panelControl_rightSide.Controls.Add(this.deviceAdditionDeletion_addDeviceBox1);
            this.deviceAdditionDeletion_addDeviceBox1.Visible = true;
            this.deviceAdditionDeletion_addDeviceBox1.BringToFront();

        }

        private void simpleButton_deviceDeletion_Click(object sender, EventArgs e)
        {
            //弹出确认框
            this.confirmationBox1 = new CommonControl.ConfirmationBox();
            this.confirmationBox1.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox1.Appearance.Options.UseBackColor = true;
            this.confirmationBox1.Location = new System.Drawing.Point(649, 291);
            this.confirmationBox1.Name = "confirmationBox1";
            this.confirmationBox1.Size = new System.Drawing.Size(350, 200);
            this.confirmationBox1.TabIndex = 29;
            this.confirmationBox1.titleConfirmationBox = "确认删除 " + Global._getTestingDeviceNameByTag(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem) + "?";
            this.confirmationBox1.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox1_ConfirmationBoxOKClicked);
            this.confirmationBox1.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox1_ConfirmationBoxCancelClicked);
            this.Controls.Add(this.confirmationBox1);
            this.confirmationBox1.Visible = true;
            this.confirmationBox1.BringToFront();

        }

        private void confirmationBox1_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            mysqlHelper1._connectMySQL();

            DataRow drSelected = tileView1.GetDataRow(selectRow[0]);    //获取的是grid绑定的表所有列，而不仅仅是显示出来的列

            MySqlParameter lineNO = new MySqlParameter("ln", MySqlDbType.VarChar, 20);
            lineNO.Value = this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem;
            MySqlParameter deviceNO = new MySqlParameter("dn", MySqlDbType.VarChar, 20);
            deviceNO.Value = drSelected["DeviceNO"];
            MySqlParameter ifAffected = new MySqlParameter("ifRowAffected", MySqlDbType.Int32, 1);
            MySqlParameter[] paras = { lineNO, deviceNO, ifAffected };
            string cmdDeleteDevice = "p_deleteDevice";
            mysqlHelper1._executeProcMySQL(cmdDeleteDevice, paras, 2, 1);

            //string cmdDeleteDevice = "CALL p_deleteDevice('" + this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem + "', '" + drSelected["DeviceNO"] + "');";
            //mysqlHelper1._updateMySQL(cmdDeleteDevice);

            this.confirmationBox1.Visible = false;
            getDtDeviceCanDeleteEachLine(this.sideTileBarControl_deviceAdditionDeletion.tagSelectedItem);   //刷新grid显示

            if (Convert.ToInt32(ifAffected.Value) == 1)
            {
                MessageBox.Show("删除成功");
            }
            else if (Convert.ToInt32(ifAffected.Value) == 0)
            {
                MessageBox.Show("删除失败");
            }
            mysqlHelper1.conn.Close();
        }

        private void confirmationBox1_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            this.confirmationBox1.Visible = false;
        }

        private void deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxOKClicked(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void deviceAdditionDeletion_addDeviceBox1_AddDeviceBoxCancelClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Cancel");
        }

    }
}
