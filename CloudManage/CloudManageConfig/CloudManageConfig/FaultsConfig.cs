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

        enum FaultsType { normalFaults, overrunFaults};

        public FaultsConfig()
        {
            InitializeComponent();
            mysqlHelper1._connectMySQL();

            initFaultsConfig();
        }

        private void initFaultsConfig()
        {
            string cmdInitDeviceAlreadyConfigInDtFaults = "SELECT DISTINCT `DeviceNO` FROM faults;";
            DataTable dtDeviceAlreadyConfigInDtFaults = new DataTable("DeviceAlreadyConfigInDtFaults");
            mysqlHelper1._queryTableMySQL(cmdInitDeviceAlreadyConfigInDtFaults, ref dtDeviceAlreadyConfigInDtFaults);
            
            for(int i = 0; i < dtDeviceAlreadyConfigInDtFaults.Rows.Count; i++)
            {
                listBoxControl_deviceExists.Items.Add(dtDeviceAlreadyConfigInDtFaults.Rows[i]["DeviceNO"]);
            }
        }

        private string[] createFaultsNO(FaultsType faultsType, int faultsTotal)
        {
            string[] faultsNOTemp = new string[faultsTotal];

            if (faultsTotal < 9)
            {
                for (int i = 0; i < faultsTotal; i++)
                {
                    faultsNOTemp[i] = faultsType == FaultsType.normalFaults ? "00" + (i + 1).ToString() : "10" + (i + 1).ToString();
                }
            }
            else if (faultsTotal < 100 && faultsTotal >= 10)
            {
                for (int i = 0; i < 9; i++)
                {
                    faultsNOTemp[i] = faultsType == FaultsType.normalFaults ? "00" + (i + 1).ToString() : "10" + (i + 1).ToString();
                }

                for (int i = 9; i < faultsTotal; i++)
                {
                    faultsNOTemp[i] = faultsType == FaultsType.normalFaults ? "0" + (i + 1).ToString() : "1" + (i + 1).ToString();
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    faultsNOTemp[i] = faultsType == FaultsType.normalFaults ? "00" + (i + 1).ToString() : "10" + (i + 1).ToString();
                }

                for (int i = 9; i < 98; i++)
                {
                    faultsNOTemp[i] = faultsType == FaultsType.normalFaults ? "0" + (i + 1).ToString() : "1" + (i + 1).ToString();
                }

                for (int i = 99; i < faultsTotal; i++)
                {
                    faultsNOTemp[i] = faultsType == FaultsType.normalFaults ? (i + 1).ToString() : (i + 1).ToString();
                }
            }

            return faultsNOTemp;
        }

        private void simpleButton_addDeviceNO_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textEdit_deviceNO.Text))
            {
                if(listBoxControl_deviceNO.Items.Count == 0)
                    listBoxControl_deviceNO.Items.Add(textEdit_deviceNO.Text);
                else
                {
                    bool flag = true;
                    for (int i = 0; i < listBoxControl_deviceNO.Items.Count; i++)
                    {
                        if (listBoxControl_deviceNO.Items[i].ToString() == textEdit_deviceNO.Text)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if(flag) listBoxControl_deviceNO.Items.Add(textEdit_deviceNO.Text);
                }
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
            for (int i = 0; i < faultsOverrun.Length; i++)
            {
                textBox_faultsName.Text += "\r\n" + faultsOverrun[i];
            }
            faultsNameList = textBox_faultsName.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            textEdit_faultsCount.Text = faultsNameList.Length.ToString();


            faultsNOList = new string[faultsNameList.Length];
            string[] faultsNOTemp1 = createFaultsNO(FaultsType.normalFaults, faultsNameList.Length - faultsOverrun.Length);
            string[] faultsNOTemp2 = createFaultsNO(FaultsType.overrunFaults, faultsOverrun.Length);
            for(int i = 0; i < faultsNOTemp1.Length; i++)
            {
                faultsNOList[i] = faultsNOTemp1[i];

            }
            for(int i = 0; i < faultsNOTemp2.Length; i++)
            {
                faultsNOList[i + faultsNameList.Length - faultsOverrun.Length] = faultsNOTemp2[i];
            }


            for (int i = 0; i < faultsNOList.Length; i++)
            {
                listBoxControl_faultsNOAndName.Items.Add(faultsNOList[i] + "-" + faultsNameList[i]);
            }
        }

        private void checkEdit_selAllFaults_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEdit_selAllFaults.Checked == true)
            {
                listBoxControl_faultsNOAndName.SelectAll();
            }
            else
            {
                listBoxControl_faultsNOAndName.UnSelectAll();
            }
        }

        private void checkEdit_SelAllDeviceNO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_SelAllDeviceNO.Checked == true)
            {
                listBoxControl_deviceNO.SelectAll();
            }
            else
            {
                listBoxControl_deviceNO.UnSelectAll();
            }
        }

        private void checkEdit_selAllDevice_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_selAllDevice.Checked == true)
            {
                listBoxControl_deviceExists.SelectAll();
            }
            else
            {
                listBoxControl_deviceExists.UnSelectAll();
            }
        }

        private void simpleButton_configDTFaults_Click(object sender, EventArgs e)
        {
            if (listBoxControl_faultsNOAndName.SelectedItems.Count == 0 || listBoxControl_deviceNO.SelectedItems.Count == 0)
                return;

            bool flag = true;

            BaseListBoxControl.SelectedItemCollection selDeviceLists = listBoxControl_deviceNO.SelectedItems;
            BaseListBoxControl.SelectedItemCollection selFaultsLists = listBoxControl_faultsNOAndName.SelectedItems;

            for (int i = 0; i < selDeviceLists.Count; i++)
            {
                string deviceNO = selDeviceLists[i].ToString();

                string cmdQueryDeviceNOExists = "SELECT COUNT(*) FROM faults WHERE `DeviceNO`='" + deviceNO + "';";
                DataTable dtDeviceNOExistsCount = new DataTable("dtDeviceNOExistsCount");
                mysqlHelper1._queryTableMySQL(cmdQueryDeviceNOExists, ref dtDeviceNOExistsCount);

                if (dtDeviceNOExistsCount.Rows[0][0].ToString() == "0")
                {
                    listBoxControl_deviceExists.Items.Add(deviceNO);

                    //faults
                    for (int j = 0; j < selFaultsLists.Count; j++)
                    {
                        string[] faultNOAndName = selFaultsLists[j].ToString().Split('-');

                        string cmdInsertFaults = "INSERT INTO faults (`DeviceNO`, `FaultNO`, `FaultName`) VALUES ('" +
                                                 deviceNO + "','" +
                                                 faultNOAndName[0] + "','" +
                                                 faultNOAndName[1] + "');";
                        flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaults);
                    }
                }
            }
            if (flag) MessageBox.Show("配置表faults成功");
        }

        private void simpleButton_insertFaults1Line_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textEdit_lineNO.Text) || listBoxControl_deviceExists.SelectedItems.Count == 0)
                return;

            bool flag = true;

            BaseListBoxControl.SelectedItemCollection selDeviceLists = listBoxControl_deviceExists.SelectedItems;
            for (int i = 0; i < selDeviceLists.Count; i++)
            {
                string deviceNO = selDeviceLists[i].ToString();
                string cmdFaultsConfigExists = "SELECT COUNT(*) FROM faults_config WHERE `LineNO`='" + textEdit_lineNO.Text + "' AND `DeviceNO`='" + deviceNO + "';";
                DataTable dtFaultsConfigExistsCount = new DataTable("dtFaultsConfigExistsCount");
                mysqlHelper1._queryTableMySQL(cmdFaultsConfigExists, ref dtFaultsConfigExistsCount);
                if(dtFaultsConfigExistsCount.Rows[0][0].ToString() == "0")
                {
                    string cmdQueryDeviceFaults = "SELECT * FROM faults WHERE `DeviceNO`='" + deviceNO + "';";
                    DataTable dtDeviceFaults = new DataTable("deviceFaults");
                    mysqlHelper1._queryTableMySQL(cmdQueryDeviceFaults, ref dtDeviceFaults);


                    for (int j = 0; j < dtDeviceFaults.Rows.Count; j++)
                    {
                        string faultsNO = dtDeviceFaults.Rows[j]["FaultNO"].ToString();
                        //faults_config
                        string cmdInsertFaultsConfig = "INSERT INTO faults_config (`LineNO`, `DeviceNO`, `FaultNO`, `FaultEnable`) VALUES ('" +
                                                                textEdit_lineNO.Text + "','" +
                                                                deviceNO + "','" +
                                                                faultsNO + "','" +
                                                                "1');";
                        flag = flag && mysqlHelper1._insertMySQL(cmdInsertFaultsConfig);
                    }
                }
            }
            if (flag) MessageBox.Show("配置表faults_config成功");
        }

        private void simpleButton_turncateFaults_Click(object sender, EventArgs e)
        {
            string cmdTurncateDtFaults = "TRUNCATE TABLE faults;";
            mysqlHelper1._deleteMySQL(cmdTurncateDtFaults);
            MessageBox.Show("表faults已清空");
            listBoxControl_deviceExists.Items.Clear();
        }

        private void simpleButton_turncateFaults_config_Click(object sender, EventArgs e)
        {
            string cmdTurncateDtFaultsConfig = "TRUNCATE TABLE faults_config;";
            mysqlHelper1._deleteMySQL(cmdTurncateDtFaultsConfig);
            MessageBox.Show("表faults_config已清空");
        }
    }
}