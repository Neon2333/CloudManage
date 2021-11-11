using DevExpress.XtraEditors;
using System;
using System.Collections;
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
    public partial class DiagnosisManagement : DevExpress.XtraEditors.XtraUserControl
    {
        private int[] selectRow = { -1 };

        struct faultsIndexAndStatus
        {
            public int rowHandle;   //row在dtFaultsConfig中位置
            public string faultsNO;
            public string faultsLineName;
            public string faultsDeviceName;
            public string faultsFaultName;
            public string faultsFaultEnable;

        };

        //Hashtable faultsOriginal = new Hashtable();   //因为Hashtable的Key和Value都是object类型，所以在使用值类型的时候，必然会出现装箱和拆箱的操作，因此性能肯定是不如Dictionary的
        Stack<faultsIndexAndStatus> faultsStorage = new Stack<faultsIndexAndStatus>();                      //暂存故障设置被修改的所有历史
        Dictionary<int, faultsIndexAndStatus> faultsOriginal = new Dictionary<int, faultsIndexAndStatus>(); //暂存未保存时被改动行的最初状态
        Dictionary<int, faultsIndexAndStatus> faultsLatest = new Dictionary<int, faultsIndexAndStatus>();   //存所有被改动行的当前状态

        string cmdQueryFaultsConfig = String.Empty;

        public DiagnosisManagement()
        {
            InitializeComponent();

            _initSideTileBarWithSub();  //初始化侧边栏
            Global._init_dtFaultsConfig();    //初始化故障配置表
            this.gridControl_faultDataTime.DataSource = Global.dtFaultsConfig;
        }

        private void _initSideTileBarWithSub()
        {
            this.sideTileBarControlWithSub_diagnosisManagement.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_diagnosisManagement.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_diagnosisManagement.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_diagnosisManagement.colTextDT = "LineName";
            this.sideTileBarControlWithSub_diagnosisManagement.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_diagnosisManagement.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_diagnosisManagement.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_diagnosisManagement._initSideTileBarWithSub();
        }

        void _refreshLabelDir()
        {
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2;
        }

        private string _getProductionLineNameByTag(string tagProductionLine)
        {
            //dtProductionLine中没有Tag==0的记录
            if (tagProductionLine == "000")
            {
                return "总览";
            }

            string temp = "LineNO=" + "'" + tagProductionLine + "'";
            DataRow[] rowPL = Global.dtProductionLine.Select(temp);
            if (rowPL.Length == 1)
            {
                return (string)rowPL[0]["LineName"];
            }
            else
            {
                return "产线名称查询错误...";
            }
        }

        private string _getTestingDeviceNameByTag(string tagTestingDeviceName)
        {
            if (tagTestingDeviceName == "000")
            {
                return "所有设备";
            }

            string temp = "DeviceNO=" + "'" + tagTestingDeviceName + "'";
            DataRow[] rowTD = Global.dtTestingDeviceName.Select(temp);
            if (rowTD.Length == 1)
            {
                return (string)rowTD[0]["DeviceName"];
            }
            else
            {
                return "产线名称查询错误...";
            }
        }

        private void initCmdQueryFaultsConfig()
        {
            if(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem == "000")
            {
                if(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub == "000")
                {
                    cmdQueryFaultsConfig = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO ORDER BY t1.`NO`;";
                }
                else
                {
                    cmdQueryFaultsConfig = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO " +
                                           "AND t3.DeviceNO='" + this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub + "' ORDER BY t1.`NO`;";
                }
            }
            else
            {
                if (this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub == "000")
                {
                    cmdQueryFaultsConfig = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO " +
                                           "AND t2.LineNO='" + this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem + "' ORDER BY t1.`NO`;";
                }
                else
                {
                    cmdQueryFaultsConfig = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO " +
                                           "AND t2.LineNO='" + this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem + "' " +
                                           "AND t3.DeviceNO='" + this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub + "' " +
                                           "ORDER BY t1.`NO`;";
                }
            }
        }

        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

        }

        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

            initCmdQueryFaultsConfig();

            MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            mysqlHelper1._connectMySQL();
            bool flag = mysqlHelper1._queryTableMySQL(cmdQueryFaultsConfig, ref Global.dtFaultsConfig);
            this.tileView1.FocusedRowHandle = selectRow[0];
        }

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;
            if ((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["FaultEnable"]) == "使能")
            {
                e.Item.AppearanceItem.Normal.ForeColor = Color.Green;
            }
            else if ((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["FaultEnable"]) == "禁止")
            {
                e.Item.AppearanceItem.Normal.ForeColor = Color.Red;
            }


        }

        //private void tileView1_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        //{
        //    selectRow = this.tileView1.GetSelectedRows();   //记录选中的行
        //    DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);
        //    if (selectRow.Length == 1)
        //    {
        //        if (drTemp["FaultEnable"].ToString() == "使能")
        //        {
        //            this.simpleButton_statusChange.Appearance.BackColor = Color.Green;
        //        }
        //        else if(drTemp["FaultEnable"].ToString() == "禁止")
        //        {
        //            this.simpleButton_statusChange.Appearance.BackColor = Color.Red;
        //        }
        //    }
        //}

        private void gridControl_faultDataTime_Click(object sender, EventArgs e)    //不要用itemClick，有时候点击了但selectedrows未改变，出现bug
        {
            selectRow = this.tileView1.GetSelectedRows();   //记录选中的行
            DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);
            if (selectRow.Length == 1)
            {
                if (drTemp["FaultEnable"].ToString() == "使能")
                {
                    this.simpleButton_statusChange.Appearance.BackColor = Color.Green;
                }
                else if (drTemp["FaultEnable"].ToString() == "禁止")
                {
                    this.simpleButton_statusChange.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void simpleButton_statusChange_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(selectRow[0].ToString());
            if (Global.dtFaultsConfig.Rows.Count > 0 && selectRow.Length == 1)
            {
                DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);       //取引用
                if (drTemp != null) //避免未选中行就点击按钮
                {
                    faultsIndexAndStatus fTemp = new faultsIndexAndStatus();
                    //直接赋值row的话是传引用，状态会随之发生改变，起不到记录的作用
                    fTemp.rowHandle = selectRow[0];
                    fTemp.faultsNO = drTemp["NO"].ToString();
                    fTemp.faultsLineName = drTemp["LineName"].ToString();
                    fTemp.faultsDeviceName = drTemp["DeviceName"].ToString();
                    fTemp.faultsFaultName = drTemp["FaultName"].ToString();
                    fTemp.faultsFaultEnable = drTemp["FaultEnable"].ToString();
                    faultsStorage.Push(fTemp);   //暂存当前被改变的行。因为可能一次改变多行，然后再点保存/取消

                    if (drTemp["FaultEnable"].ToString() == "使能")
                    {
                        //Global.dtFaultsConfig.Rows[selectRow[0]]["FaultEnable"] = "禁止"; //修改dt中存储的状态
                        drTemp["FaultEnable"] = "禁止";   //drTemp获得的是dtFaultsConfig该行的引用，不是值传递。所以不用再去dtFaultsConfig中取

                        //保存被修改行当前状态
                        fTemp.faultsFaultEnable = drTemp["FaultEnable"].ToString();
                        if (faultsLatest.ContainsKey(fTemp.rowHandle))
                        {
                            faultsLatest[fTemp.rowHandle] = fTemp;
                        }
                        else
                        {
                            faultsLatest.Add(fTemp.rowHandle, fTemp);
                        }

                        this.simpleButton_statusChange.Appearance.BackColor = Color.Red;
                    }
                    else
                    {
                        //Global.dtFaultsConfig.Rows[selectRow[0]]["FaultEnable"] = "使能";
                        drTemp["FaultEnable"] = "使能";

                        fTemp.faultsFaultEnable = drTemp["FaultEnable"].ToString();
                        if (faultsLatest.ContainsKey(fTemp.rowHandle))
                        {
                            faultsLatest[fTemp.rowHandle] = fTemp;
                        }
                        else
                        {
                            faultsLatest.Add(fTemp.rowHandle, fTemp);
                        }

                        this.simpleButton_statusChange.Appearance.BackColor = Color.Green;
                    }
                }
                else if (selectRow[0] == -1)
                {
                    MessageBox.Show("未选中故障");
                }

            }
        }

        private void simpleButton_saveStatusChange_Click(object sender, EventArgs e)
        {
            MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            mysqlHelper1._connectMySQL();
            //while (faultsStorage.Count != 0)
            //{
            //    faultsIndexAndStatus fTemp = faultsStorage.Peek();
            //    if (!faultsLatest.ContainsKey(fTemp.rowHandle))
            //    {
            //        faultsLatest.Add(fTemp.rowHandle, fTemp);
            //    }
            //    faultsStorage.Pop();  //清空记录的被改变的行
            //}

            bool flagSaveSuccess = true;
            foreach(var fo in faultsLatest)
            {
                string lineName = fo.Value.faultsLineName;
                string deviceName = fo.Value.faultsDeviceName;
                string faultName = fo.Value.faultsFaultName;

                string cmdTransform = "SELECT t1.LineNO, t1.DeviceNO, t1.FaultNO, t1.FaultEnable FROM faults_config AS t1 " +
                                      "INNER JOIN productionline AS t2 ON t1.LineNO=t2.LineNO " +
                                      "INNER JOIN device AS t3 ON t1.DeviceNO=t3.DeviceNO " +
                                      "INNER JOIN faults AS t4 ON t1.DeviceNO=t4.DeviceNO AND t1.FaultNO=t4.FaultNO " +
                                      "WHERE t2.LineName='" + lineName + "' AND t3.DeviceName='" + deviceName + "' AND t4.FaultName='" + faultName + "';";

                DataTable dtTemp = new DataTable();
                bool flag1 = mysqlHelper1._queryTableMySQL(cmdTransform, ref dtTemp);
                if (flag1 == true)
                {
                    string lineNO = dtTemp.Rows[0]["LineNO"].ToString();
                    string deviceNO = dtTemp.Rows[0]["DeviceNO"].ToString();
                    string faultNO = dtTemp.Rows[0]["FaultNO"].ToString();
                    string faultEnable = fo.Value.faultsFaultEnable == "使能" ? "1" : "0";

                    string cmdSaveFaultsConfig = "UPDATE faults_config SET FaultEnable='" + faultEnable + "' " +
                                                 "WHERE LineNO='" + lineNO + "' AND DeviceNO='" + deviceNO + "' AND FaultNO='" + faultNO + "';";
                    bool flag2 = mysqlHelper1._updateMysql(cmdSaveFaultsConfig);
                    if (flag2 == false)
                    {
                        flagSaveSuccess = false;
                    }
                }
            }
            if (flagSaveSuccess == true)
            {
                MessageBox.Show("保存成功");
                this.tileView1.FocusedRowHandle = selectRow[0];
            }
            else
            {
                MessageBox.Show("保存失败");
            }

            faultsOriginal.Clear();
            faultsLatest.Clear();
            mysqlHelper1.conn.Close();
        }

        private void simpleButton_cancelStatusChange_Click(object sender, EventArgs e)
        {
            while (faultsStorage.Count != 0)
            {
                faultsIndexAndStatus fTemp = faultsStorage.Peek();
                //取出各行最初的状态
                if (faultsOriginal.ContainsKey(fTemp.rowHandle))
                {
                    faultsOriginal[fTemp.rowHandle] = fTemp;
                }
                else
                {
                    faultsOriginal.Add(fTemp.rowHandle, fTemp);
                }
                faultsStorage.Pop();  //清空记录的被改变的行
            }

            foreach(var fo in faultsOriginal)
            {
                Global.dtFaultsConfig.Rows[fo.Key]["FaultEnable"] = fo.Value.faultsFaultEnable; //不用faultsStorage[0]直接赋值，因为有多个行被记录
            }

            faultsOriginal.Clear();
            faultsLatest.Clear();

            //取消后恢复按钮颜色
            if (Global.dtFaultsConfig.Rows[selectRow[0]]["FaultEnable"].ToString() == "禁止")
            {
                this.simpleButton_statusChange.Appearance.BackColor = Color.Red;
            }
            else
            {
                this.simpleButton_statusChange.Appearance.BackColor = Color.Green;
            }
        }

        


    }
}
