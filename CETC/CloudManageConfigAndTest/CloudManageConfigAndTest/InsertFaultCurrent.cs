using DevExpress.XtraEditors;
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

namespace CloudManageConfigAndTest
{
    public partial class InsertFaultCurrent : DevExpress.XtraEditors.XtraForm
    {
        CloudManage.MySQL.MySQLHelper mysqlHelper1;
        int totalInsert = 0;
        string lineNO = String.Empty;
        string deviceNO = String.Empty;
        string faultNO = String.Empty;
        DateTime nowTime = new DateTime();

        DataTable dtLine = new DataTable();
        DataTable dtDeviceConfig = new DataTable();
        DataTable dtDevice = new DataTable();
        DataTable dtFaultsConfig = new DataTable();


        public InsertFaultCurrent()
        {
            InitializeComponent();

            mysqlHelper1 = new CloudManage.MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            mysqlHelper1._connectMySQL();
            initTable();
        }

        public string[] GetColumnsName(DataTable dt)
        {
            if (dt != null)
            {
                string[] strColumns = null;
                if (dt.Columns.Count > 0)
                {
                    int columnNum = 0;
                    columnNum = dt.Columns.Count;
                    strColumns = new string[columnNum];
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        strColumns[i] = dt.Columns[i].ColumnName;
                    }
                }
                return strColumns;
            }
            else
            {
                return null;
            }
        }

        public string[] GetColumnsName(DataRow dr)
        {
            if (dr != null)
            {
                DataTable dtTemp = dr.Table;
                string[] strColumns = null;
                if (dtTemp.Columns.Count > 0)
                {
                    int columnNum = 0;
                    columnNum = dtTemp.Columns.Count;
                    strColumns = new string[columnNum];
                    for (int i = 0; i < dtTemp.Columns.Count; i++)
                    {
                        strColumns[i] = dtTemp.Columns[i].ColumnName;
                    }
                }
                return strColumns;
            }
            else
            {
                return null;
            }
        }

        private void initTable()
        {
            //初始化line列表
            string cmdInitDtLine = "SELECT LineNO, LineName FROM productionline;";
            mysqlHelper1._queryTableMySQL(cmdInitDtLine, ref dtLine);
            for (int i = 0; i < dtLine.Rows.Count; i++)
            {
                this.comboBox_lineNO.Items.Add(dtLine.Rows[i]["LineNO"] + "-" + dtLine.Rows[i]["LineName"]);
            }

            //
            string cmdInitDtDeviceEachLine = "SELECT * FROM device_config;";
            mysqlHelper1._queryTableMySQL(cmdInitDtDeviceEachLine, ref dtDeviceConfig);

            //
            string cmdInitDtDevice = "SELECT DeviceNO, DeviceName FROM device;";
            mysqlHelper1._queryTableMySQL(cmdInitDtDevice, ref dtDevice);

            //
            string cmdInitDtFaultsConfig = "SELECT t1.LineNO, t1.DeviceNO, t1.FaultNO, t2.FaultName, t1.FaultEnable FROM faults_config AS t1 INNER JOIN faults AS t2 ON t1.DeviceNO=t2.DeviceNO AND t1.FaultNO=t2.FaultNO;";
            mysqlHelper1._queryTableMySQL(cmdInitDtFaultsConfig, ref dtFaultsConfig);

        }

        private void timer_insertFaultsCurrent_Tick(object sender, EventArgs e)
        {
            nowTime = DateTime.Now;

            if (lineNO != String.Empty && deviceNO != String.Empty && faultNO != String.Empty)
            {
                string cmdIns = "INSERT INTO faults_current (LineNO, DeviceNO, FaultNO, FaultTime) VALUES ('" + lineNO.ToString() + "', '" +
                              deviceNO.ToString() + "', '" + faultNO.ToString() + "', '" + nowTime.ToString() + "');";

                bool flag = mysqlHelper1._insertMySQL(cmdIns);
                if (flag)
                    this.label_totalInsert.Text += (" " + (++totalInsert).ToString());
            }
        }

        private void simpleButton_insertFaultCurrent_Click(object sender, EventArgs e)
        {
            timer_insertFaultsCurrent.Enabled = true;
            if (this.comboBox_faultNO.Text != "")
            {
                if (timer_insertFaultsCurrent.Enabled)
                    this.label_totalInsert.BackColor = System.Drawing.Color.LimeGreen;
                else
                    this.label_totalInsert.BackColor = System.Drawing.Color.Red;
            }
        }

        private void simpleButton_stopInsert_Click(object sender, EventArgs e)
        {
            timer_insertFaultsCurrent.Enabled = false;
        }

        private void comboBox_lineNO_SelectedValueChanged(object sender, EventArgs e)
        {
            //获取选中LineNO
            string lineNOTemp = this.comboBox_lineNO.SelectedItem.ToString();
            lineNO = lineNOTemp.Substring(0, lineNOTemp.IndexOf('-'));

            this.comboBox_deviceNO.Enabled = true;

            //对应LineNO的device列表
            DataRow[] dr = dtDeviceConfig.Select("LineNO='" + lineNO + "'");
            if (dr.Length == 1)
            {
                string[] colNames = GetColumnsName(dr[0]);
                for (int i = 0; i < colNames.Length; i++)
                {
                    this.comboBox_deviceNO.Items.Add(colNames[i].Substring(colNames[i].IndexOf('_') + 1, 3));
                }
            }

        }

        private void comboBox_deviceNO_SelectedValueChanged(object sender, EventArgs e)
        {
            //获取DeviceNO
            string deviceNOTemp = this.comboBox_deviceNO.SelectedItem.ToString();
            deviceNO = deviceNOTemp.Substring(deviceNOTemp.IndexOf('_') + 1, deviceNOTemp.Length);

            this.comboBox_faultNO.Enabled = true;

            //对应的DeviceNO的faults列表
            DataRow[] dr = dtFaultsConfig.Select("LineNO='" + lineNO + "' AND DeviceNO='" + deviceNO + "' AND FaultEnable='" + "1'");
            if(dr.Length == 1)
            {
                for(int i = 0; i < dr.Length; i++)
                {
                    this.comboBox_faultNO.Items.Add(dr[i]["FaultNO"].ToString() + "-" + dr[i]["FaultName"]);
                }
            }

        }

        
    }
}