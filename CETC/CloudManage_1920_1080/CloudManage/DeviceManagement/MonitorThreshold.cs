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

namespace CloudManage.DeviceManagement
{
    public partial class MonitorThreshold : DevExpress.XtraEditors.XtraUserControl
    {

        private int[] selectRow = { 0 };    //选中行的RowHandle
        string cmdQueryDeviceInfoThresholdTemp = String.Empty;
        enum ModifyUpperOrLower { modifyUpper = 0, modifyLower = 1 };
        int modifyUpperOrLowerCurrent;  //当前修改的是上限还是下限

        struct thresholdIndexAndVal
        {
            public string NO;       //row在dtDeviceInfoThresholdGridShow中位置
            public int rowHandle;   //row在dtDeviceInfoThresholdGridShowTemp中位置
            public string LineNO;
            public string DeviceNO;
            public string ParaNO;
            public string ParaSuffix;
            public string LowerLimit;
            public string UpperLimit;
        };

        Stack<thresholdIndexAndVal> thresholdStorage = new Stack<thresholdIndexAndVal>();                      //暂存故障设置被修改的所有历史
        Dictionary<int, thresholdIndexAndVal> thresholdOriginal = new Dictionary<int, thresholdIndexAndVal>(); //暂存未保存时被改动行的最初状态
        Dictionary<int, thresholdIndexAndVal> thresholdLatest = new Dictionary<int, thresholdIndexAndVal>();   //存所有被改动行的当前状态


        public MonitorThreshold()
        {
            InitializeComponent();

            _initSideTileBarWithSub();
            Global._init_dtDeviceInfoThresholdGridShow();
            Global.reorderDt(ref Global.dtDeviceInfoThresholdGridShow);
            this.gridControl_deviceInfoThreshold.DataSource = Global.dtDeviceInfoThresholdGridShow;

            if (((DataTable)this.gridControl_deviceInfoThreshold.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRow[0]; //默认选中第一行
            }

            //this.numberKeyboard1 = new CommonControl.NumberKeyboard(0, 200);
            //this.panelControl_rightSide.Controls.Add(this.numberKeyboard1);
            //this.numberKeyboard1.Location = new System.Drawing.Point(6, 150);
            //this.numberKeyboard1.BringToFront();
            //this.numberKeyboard1.Visible = false;
        }

        private void _initSideTileBarWithSub()
        {
            this.sideTileBarControlWithSub_monitorThreshold.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_monitorThreshold.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_monitorThreshold.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_monitorThreshold.colTextDT = "LineName";
            this.sideTileBarControlWithSub_monitorThreshold.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_monitorThreshold.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_monitorThreshold.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_monitorThreshold._initSideTileBarWithSub();
        }

        void _refreshLabelDir()
        {
            string str1 = _getProductionLineNameByTag(this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem);
            string str2 = _getTestingDeviceNameByTag(this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub);
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

        private string removeSuffixLimits(string limit, string suffix)
        {
            int lenStrSuffis = suffix.Length;
            int lenLimit = limit.Length;
            string limitWithoutSuffix = limit.Remove(lenLimit - lenStrSuffis);
            return limitWithoutSuffix;
        }

        private void gridControl_deviceInfoThreshold_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_deviceInfoThreshold.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRow = this.tileView1.GetSelectedRows();   //记录选中的行
            }
            if (selectRow.Length == 1)
            {
                this.tileView1.FocusedRowHandle = selectRow[0];
            }
        }

        //点击侧边栏查询的命令
        private void initCmdQueryDeviceInfoThresholdTemp()
        {
            if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem == "000")
            {
                if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub == "000")
                {
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(0, '000', '000')";
                }
                else
                {
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(1, '000', '" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub + "');";
                }
            }
            else
            {
                if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub == "000")
                {
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(2,'" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem + "', '000');";
                }
                else
                {
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(3,'" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem + "', '" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub + "');";
                }
            }
        }

        private void sideTileBarControlWithSub_monitorThreshold_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
            //_refreshLabelDir();
        }

        private void sideTileBarControlWithSub_monitorThreshold_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

            initCmdQueryDeviceInfoThresholdTemp();

            MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            mysqlHelper1._connectMySQL();

            //更新dtFaultsConfig
            bool flag = mysqlHelper1._queryTableMySQL(cmdQueryDeviceInfoThresholdTemp, ref Global.dtDeviceInfoThresholdGridShowTemp);
            Global.dtDeviceInfoThresholdGridShow.Rows.Clear();
            Global.transformDtDeviceInfoThresholdGridTemp(ref Global.dtDeviceInfoThresholdGridShowTemp, ref Global.dtDeviceInfoThresholdGridShow);
            Global.reorderDt(ref Global.dtDeviceInfoThresholdGridShow);
            selectRow[0] = 0;
        }

        private void simpleButton_modifyUpperLimit_Click(object sender, EventArgs e)
        {
            this.modifyUpperOrLowerCurrent = (int)ModifyUpperOrLower.modifyUpper;
            this.numberKeyboard1.Visible = true;

            

        }

        private void simpleButton_modifyLowerLimit_Click(object sender, EventArgs e)
        {
            this.modifyUpperOrLowerCurrent = (int)ModifyUpperOrLower.modifyLower;
            this.numberKeyboard1.Visible = true;


        }

        private void numberKeyboard1_NumberKeyboardEnterClicked(object sender, EventArgs e)
        {
            if (this.modifyUpperOrLowerCurrent == (int)ModifyUpperOrLower.modifyUpper)
            {
                //需要判断输入的上限是否大于下限
                //把dt["LowerLimit"]的单位去掉
                double numberKeyboardResultTemp = this.numberKeyboard1.result;
                string lowerLimitCurrentRow = removeSuffixLimits(Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["LowerLimit"].ToString(), Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"].ToString());

                if (numberKeyboardResultTemp >= Convert.ToDouble(lowerLimitCurrentRow))
                {
                    //保存修改前、最新的修改
                    if (((DataTable)this.gridControl_deviceInfoThreshold.DataSource).Rows.Count > 0 && selectRow.Length == 1)
                    {
                        DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);
                        if (drTemp != null)
                        {
                            thresholdIndexAndVal fTemp = new thresholdIndexAndVal();
                            fTemp.NO = drTemp["NO"].ToString();
                            fTemp.rowHandle = selectRow[0];
                            fTemp.LineNO = drTemp["LineNO"].ToString();
                            fTemp.DeviceNO = drTemp["DeviceNO"].ToString();
                            fTemp.ParaNO = drTemp["ParaNO"].ToString();
                            fTemp.ParaSuffix = drTemp["ParaSuffix"].ToString();
                            fTemp.LowerLimit = drTemp["LowerLimit"].ToString();
                            fTemp.UpperLimit = drTemp["UpperLimit"].ToString();

                            //保存原始状态
                            if (!thresholdOriginal.ContainsKey(Convert.ToInt32(fTemp.NO)))
                            {
                                thresholdOriginal.Add(Convert.ToInt32(fTemp.NO), fTemp);
                            }
                            
                            //修改grid显示
                            Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["UpperLimit"] = numberKeyboardResultTemp.ToString() + Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"];
                            fTemp.UpperLimit = Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["UpperLimit"].ToString();

                            //保存最新状态
                            if (thresholdLatest.ContainsKey(Convert.ToInt32(fTemp.NO)))
                            {
                                thresholdLatest[Convert.ToInt32(fTemp.NO)] = fTemp;
                            }
                            else
                            {
                                thresholdLatest.Add(Convert.ToInt32(fTemp.NO), fTemp);
                            }
                        }
                    }

                }
            }
            else
            {
                //需要判断输入的下限是否小于上限
                double numberKeyboardResultTemp = this.numberKeyboard1.result;
                string upperLimitCurrentRow = removeSuffixLimits(Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["UpperLimit"].ToString(), Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"].ToString());

                if (numberKeyboardResultTemp <= Convert.ToDouble(upperLimitCurrentRow))
                {
                    if (((DataTable)this.gridControl_deviceInfoThreshold.DataSource).Rows.Count > 0 && selectRow.Length == 1)
                    {
                        DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);
                        if (drTemp != null)
                        {
                            thresholdIndexAndVal fTemp = new thresholdIndexAndVal();
                            fTemp.NO = drTemp["NO"].ToString();
                            fTemp.rowHandle = selectRow[0];
                            fTemp.LineNO = drTemp["LineNO"].ToString();
                            fTemp.DeviceNO = drTemp["DeviceNO"].ToString();
                            fTemp.ParaNO = drTemp["ParaNO"].ToString();
                            fTemp.ParaSuffix = drTemp["ParaSuffix"].ToString();
                            fTemp.LowerLimit = drTemp["LowerLimit"].ToString();
                            fTemp.UpperLimit = drTemp["UpperLimit"].ToString();

                            //保存原始状态
                            if (!thresholdOriginal.ContainsKey(Convert.ToInt32(fTemp.NO)))
                            {
                                thresholdOriginal.Add(Convert.ToInt32(fTemp.NO), fTemp);
                            }

                            //修改grid显示
                            Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["LowerLimit"] = numberKeyboardResultTemp.ToString() + Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"];
                            fTemp.UpperLimit = Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["LowerLimit"].ToString();

                            //保存最新状态
                            if (thresholdLatest.ContainsKey(Convert.ToInt32(fTemp.NO)))
                            {
                                thresholdLatest[Convert.ToInt32(fTemp.NO)] = fTemp;
                            }
                            else
                            {
                                thresholdLatest.Add(Convert.ToInt32(fTemp.NO), fTemp);
                            }
                        }
                    }

                }
            }
        }

        private void simpleButton_saveThresholdModify_Click(object sender, EventArgs e)
        {
            if (thresholdLatest.Count != 0)    //有改动时才保存
            {
                MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
                mysqlHelper1._connectMySQL();

                bool flagSaveSuccess = true;
                foreach (var to in thresholdLatest)
                {
                    string lineNO = to.Value.LineNO;
                    string deviceNO = to.Value.DeviceNO;
                    string paraNO = to.Value.ParaNO;
                    string upperLimit = removeSuffixLimits(to.Value.UpperLimit, to.Value.ParaSuffix);
                    string lowerLimit = removeSuffixLimits(to.Value.LowerLimit, to.Value.ParaSuffix);

                    string cmdSaveDtDevice_info_threshold = "UPDATE device_info_threshold SET Para" + paraNO + "Max='" + upperLimit +
                                          "', Para" + paraNO + "Min='" + lowerLimit + "' WHERE LineNO='" + lineNO + "' AND DeviceNO='" + deviceNO + "';";
                    bool flag1 = mysqlHelper1._updateMysql(cmdSaveDtDevice_info_threshold);
                    if (flag1 == false)
                    {
                        flagSaveSuccess = false;
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

                thresholdOriginal.Clear();
                thresholdLatest.Clear();
                mysqlHelper1.conn.Close();
            }
        }

        private void simpleButton_cancelThresholdModify_Click(object sender, EventArgs e)
        {
            //dtDeviceInfoThresholdGridShowTemp还原到最初的状态
            foreach (var to in thresholdOriginal)
            {
                string filter = "NO = '" + to.Key.ToString() + "'";
                DataRow[] dr = Global.dtDeviceInfoThresholdGridShow.Select(filter);
                if (dr.Length == 1)
                {
                    dr[0]["LowerLimit"] = to.Value.LowerLimit;
                    dr[0]["UpperLimit"] = to.Value.UpperLimit; 
                }

                //Global.dtDeviceInfoThresholdGridShow.Rows[to.Key]["LowerLimit"] = to.Value.LowerLimit;
                //Global.dtDeviceInfoThresholdGridShow.Rows[to.Key]["UpperLimit"] = to.Value.UpperLimit;
            }

            this.thresholdOriginal.Clear();
            this.thresholdLatest.Clear();
            Global.transformDtDeviceInfoThresholdGridTemp(ref Global.dtDeviceInfoThresholdGridShowTemp, ref Global.dtDeviceInfoThresholdGridShow);
            Global.reorderDt(ref Global.dtDeviceInfoThresholdGridShow);
            selectRow[0] = 0;
        }
    }
}
