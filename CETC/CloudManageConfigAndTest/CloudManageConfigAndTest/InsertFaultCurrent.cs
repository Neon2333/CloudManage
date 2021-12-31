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

namespace InsertFaultsCurrent
{
    public partial class InsertFaultCurrent : DevExpress.XtraEditors.XtraForm
    {
        CloudManage.MySQL.MySQLHelper mysqlHelper1;
        int totalInsert = 0;
        //string lineNO = String.Empty;
        //string deviceNO = String.Empty;
        //string faultNO = String.Empty;
        string lineNO = "001";
        string deviceNO = "001";
        string faultNO = "1";
        DateTime nowTime = new DateTime();

        DataTable dtLine = new DataTable();
        DataTable dtDeviceConfig = new DataTable();
        DataTable dtDevice = new DataTable();

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
            string cmdInitDtLine = "SELECT LineNO, LineName FROM productionline;";
            mysqlHelper1._queryTableMySQL(cmdInitDtLine, ref dtLine);
            for (int i = 0; i < dtLine.Rows.Count; i++)
            {
                this.comboBox_lineNO.Items.Add(dtLine.Rows[i]["LineNO"] + "-" + dtLine.Rows[i]["LineName"]);
            }

            string cmdInitDtDeviceEachLine = "SELECT * FROM device_config;";
            mysqlHelper1._queryTableMySQL(cmdInitDtDeviceEachLine, ref dtDeviceConfig);

            string cmdInitDtDevice = "SELECT DeviceNO, DeviceName FROM device;";
            mysqlHelper1._queryTableMySQL(cmdInitDtDevice, ref dtDevice);


        }

        private void timer_insertFaultsCurrent_Tick(object sender, EventArgs e)
        {
            string lineNOTemp = this.comboBox_lineNO.SelectedItem.ToString();
            lineNO = lineNOTemp.Substring(0, lineNOTemp.IndexOf('-'));

            deviceNO =
            faultNO = (this.comboBox_faultNO.SelectedIndex + 1).ToString();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.comboBox_faultNO.Text != "")
            {
                timer_insertFaultsCurrent.Enabled = !timer_insertFaultsCurrent.Enabled;
                if (timer_insertFaultsCurrent.Enabled)
                    this.label_totalInsert.BackColor = System.Drawing.Color.LimeGreen;
                else
                    this.label_totalInsert.BackColor = System.Drawing.Color.Red;
            }
        }

        private void comboBox_deviceNO_DropDown(object sender, EventArgs e)
        {
            DataRow[] dr = dtDeviceConfig.Select("LineNO='" + this.comboBox_lineNO.SelectedItem + "'");
            if (dr.Length == 1)
            {
                string[] colNames = GetColumnsName(dr[0]);
                for (int i = 0; i < colNames.Length; i++)
                {
                    this.comboBox_deviceNO.Items.Add(colNames[i].Substring(colNames[i].IndexOf('_') + 1, 3));
                }
            }



        }


    }
}