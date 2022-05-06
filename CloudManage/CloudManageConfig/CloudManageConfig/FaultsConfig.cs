using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManageConfig
{
    public partial class FaultsConfig : DevExpress.XtraEditors.XtraForm
    {
        MySQLHelper mysqlHelper1 = new MySQLHelper("localhost", "cloud_manage", "root", "ei41");

        string[] faultsNameList;
        string[] faultsNOList;
        string[] faultsOverrun = { "检测数量超限", "缺陷数量超限", "CPU温度超限", "CPU利用率超限", "内存利用率超限" };
        public FaultsConfig()
        {
            InitializeComponent();
            mysqlHelper1._connectMySQL();
        }



        private void simpleButton_addDeviceNO_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textEdit_deviceNO.Text))
            {
                listBoxControl_deviceNO.Items.Add(textEdit_deviceNO.Text);
            }
        }

        private void simpleButton_delDeviceNO_Click(object sender, EventArgs e)
        {
            if (listBoxControl_deviceNO.Items.Count != 0)
            {
                listBoxControl_deviceNO.Items.RemoveAt(listBoxControl_deviceNO.Items.Count - 1);
            }
        }

        private void simpleButton_faulsNameOK_Click(object sender, EventArgs e)
        {
            faultsNameList = textBox_faultsName.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            textEdit_faultsCount.Text = faultsNameList.Length.ToString();

            faultsNOList = new string[faultsNameList.Length];   

            if (faultsNameList.Length < 9)
            {
                for(int i = 0; i < faultsNameList.Length; i++)
                {
                    faultsNOList[i] = "00" + (i + 1).ToString();
                }
            }
            else if(faultsNameList.Length < 100 && faultsNameList.Length >= 10)
            {
                for (int i = 0; i < 9; i++)
                {
                    faultsNOList[i] = "00" + (i + 1).ToString();
                }

                for (int i = 9; i < faultsNameList.Length; i++)
                {
                    faultsNOList[i] = "0" + (i + 1).ToString();
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    faultsNOList[i] = "00" + (i + 1).ToString();
                }

                for (int i = 9; i < 98; i++)
                {
                    faultsNOList[i] = "0" + (i + 1).ToString();
                }

                for (int i = 99; i < faultsNameList.Length; i++)
                {
                    faultsNOList[i] = (i + 1).ToString();
                }
            }

        }


        private void simpleButton_insertFaults1Line_Click(object sender, EventArgs e)
        {
            bool flag = true;

            for (int i = 0; i < listBoxControl_deviceNO.Items.Count; i++)
            {
                for (int j = 0; j < faultsNameList.Length; j++)
                {
                    //faults
                    string cmdInsertFaults = "INSERT INTO faults (`DeviceNO`, `FaultNO`, `FaultName`) VALUES ('" +
                                             listBoxControl_deviceNO.Items[i].ToString() + "','" +
                                             faultsNOList[j] + "','" +
                                             faultsNameList[j] + "');";
                    flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaults);

                    //faults_config
                    string cmdInsertFaultsConfig = "INSERT INTO faults_config (`LineNO`, `DeviceNO`, `FaultNO`, `FaultEnable`) VALUES ('" +
                                                    textEdit_lineNO.Text + "','" +
                                                    listBoxControl_deviceNO.Items[i].ToString() + "','" +
                                                    faultsNOList[j] + "','" +
                                                    "1');";
                    flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaultsConfig);
                }


                for(int k = 0; k < faultsOverrun.Length; k++)
                {
                    //faults
                    string cmdInsertFaults = "INSERT INTO faults (`DeviceNO`, `FaultNO`, `FaultName`) VALUES ('" +
                                             listBoxControl_deviceNO.Items[i].ToString() + "','" +
                                             "10" + (k + 1).ToString() + "','" +
                                             faultsOverrun[k] + "');";
                    flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaults);

                    //faults_config
                    string cmdInsertFaultsConfig = "INSERT INTO faults_config (`LineNO`, `DeviceNO`, `FaultNO`, `FaultEnable`) VALUES ('" +
                                                    textEdit_lineNO.Text + "','" +
                                                    listBoxControl_deviceNO.Items[i].ToString() + "','" +
                                                    "10" + (k + 1).ToString() + "','" +
                                                    "1');";
                    flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaultsConfig);
                }

            }
            if (flag) MessageBox.Show("配置1条产线故障成功");


        }

        private void simpleButton_insertFaults1Device_Click(object sender, EventArgs e)
        {
            bool flag = true;


            for (int i = 0; i < faultsNameList.Length; i++)
            {
                //faults
                string cmdInsertFaults = "INSERT INTO faults (`DeviceNO`, `FaultNO`, `FaultName`) VALUES ('" +
                                         listBoxControl_deviceNO.SelectedValue.ToString() + "','" +
                                         faultsNOList[i] + "','" +
                                         faultsNameList[i] + "');";
                flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaults);

                //faults_config
                string cmdInsertFaultsConfig = "INSERT INTO faults_config (`LineNO`, `DeviceNO`, `FaultNO`, `FaultEnable`) VALUES ('" +
                                                textEdit_lineNO.Text + "','" +
                                                listBoxControl_deviceNO.SelectedValue.ToString() + "','" +
                                                faultsNOList[i] + "','" +
                                                "1');";
                flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaultsConfig);
            }


            for (int k = 0; k < faultsOverrun.Length; k++)
            {
                //faults
                string cmdInsertFaults = "INSERT INTO faults (`DeviceNO`, `FaultNO`, `FaultName`) VALUES ('" +
                                         listBoxControl_deviceNO.SelectedValue.ToString() + "','" +
                                         "10" + (k + 1).ToString() + "','" +
                                         faultsOverrun[k] + "');";
                flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaults);

                //faults_config
                string cmdInsertFaultsConfig = "INSERT INTO faults_config (`LineNO`, `DeviceNO`, `FaultNO`, `FaultEnable`) VALUES ('" +
                                                textEdit_lineNO.Text + "','" +
                                                listBoxControl_deviceNO.SelectedValue.ToString() + "','" +
                                                "10" + (k + 1).ToString() + "','" +
                                                "1');";
                flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaultsConfig);
            }
            if (flag) MessageBox.Show("配置1条产线故障成功");


        }
    }
}