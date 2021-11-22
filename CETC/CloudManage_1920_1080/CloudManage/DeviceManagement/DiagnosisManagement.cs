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
        private int[] selectRow = { 0 };

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

        enum queryFaultsConfigType {allFaultsConfig=0, enableFaultsConfig, notEnableFualtsConfig};
        int queryFaultsConfigTypeCurrent = (int)queryFaultsConfigType.allFaultsConfig;  //当前显示标志
        DataTable dtQueryFaultsConfigEnable = new DataTable();    //暂存查询出来的所有使能、禁止
        DataTable dtQueryFaultsConfigNotEnable = new DataTable();

        public DiagnosisManagement()
        {
            InitializeComponent();

            _initSideTileBarWithSub();        //初始化侧边栏
            Global._init_dtFaultsConfig();    //初始化故障配置表
            initDtqueryFaultsConfigEnableAndNotEnable();    //初始化使能/禁止表
            Global.reorderDtFaultsConfigNO(Global.dtFaultsConfig);  //NO从1开始排序
            this.gridControl_faultsConfig.DataSource = Global.dtFaultsConfig;
            if (((DataTable)this.gridControl_faultsConfig.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRow[0]; //默认选中第一行
            }
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

        private void initDtqueryFaultsConfigEnableAndNotEnable()
        {
            this.dtQueryFaultsConfigEnable.Columns.Add("NO", typeof(String));
            this.dtQueryFaultsConfigEnable.Columns.Add("LineName", typeof(String));
            this.dtQueryFaultsConfigEnable.Columns.Add("DeviceName", typeof(String));
            this.dtQueryFaultsConfigEnable.Columns.Add("FaultName", typeof(String));
            this.dtQueryFaultsConfigEnable.Columns.Add("FaultEnable", typeof(String));

            this.dtQueryFaultsConfigNotEnable.Columns.Add("NO", typeof(String));
            this.dtQueryFaultsConfigNotEnable.Columns.Add("LineName", typeof(String));
            this.dtQueryFaultsConfigNotEnable.Columns.Add("DeviceName", typeof(String));
            this.dtQueryFaultsConfigNotEnable.Columns.Add("FaultName", typeof(String));
            this.dtQueryFaultsConfigNotEnable.Columns.Add("FaultEnable", typeof(String));
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

        //点击侧边栏查询的命令
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

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;
            if ((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["FaultEnable"]) == "使能")
            {
                e.Item.AppearanceItem.Normal.ForeColor = Color.White;
            }
            else if ((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["FaultEnable"]) == "禁止")
            {
                e.Item.AppearanceItem.Normal.ForeColor = Color.FromArgb(208, 49, 68);
            }
        }


        //根据选中行刷新《更改状态》按钮的颜色
        private void refreshColorButtonStatusChange()
        {
            //DataTable dtTemp = ;
            if (((DataTable)this.gridControl_faultsConfig.DataSource).Rows.Count != 0)
            {
                DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);
                if (selectRow.Length == 1)
                {
                    if (drTemp["FaultEnable"].ToString() == "使能")
                    {
                        this.simpleButton_statusChange.Appearance.BackColor = Color.FromArgb(56, 152, 83);
                    }
                    else if (drTemp["FaultEnable"].ToString() == "禁止")
                    {
                        this.simpleButton_statusChange.Appearance.BackColor = Color.FromArgb(208, 49, 68);
                    }
                }
            }
            else
            {
                this.simpleButton_statusChange.Appearance.BackColor = Color.Transparent;
            }
        }

        //点击选中某行时
        private void gridControl_faultDataTime_Click(object sender, EventArgs e)    //不要用itemClick，有时候点击了但selectedrows未改变，出现bug
        {
            if (((DataTable)this.gridControl_faultsConfig.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRow = this.tileView1.GetSelectedRows();   //记录选中的行
                refreshColorButtonStatusChange();
            }
        }

        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
            _refreshLabelDir();
        }

        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

            initCmdQueryFaultsConfig(); //初始化查询命令，4种

            MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
            mysqlHelper1._connectMySQL();

            //更新dtFaultsConfig
            bool flag = mysqlHelper1._queryTableMySQL(cmdQueryFaultsConfig, ref Global.dtFaultsConfig);
            Global.reorderDtFaultsConfigNO(Global.dtFaultsConfig);

            //以dtFaultsConfig更新dtQueryFaultsConfigEnable
            this.dtQueryFaultsConfigEnable.Rows.Clear();  //清空
            DataRow[] drTempEnable = Global.dtFaultsConfig.Select("FaultEnable = '使能'");
            foreach (var dp in drTempEnable)
            {
                //不能直接把dp添加到dtQueryFaultsConfigEnable中，报错dp属于另一个表
                DataRow dr = this.dtQueryFaultsConfigEnable.NewRow();
                dr["NO"] = dp["NO"];
                dr["LineName"] = dp["LineName"];
                dr["DeviceName"] = dp["DeviceName"];
                dr["FaultName"] = dp["FaultName"];
                dr["FaultEnable"] = dp["FaultEnable"];
                this.dtQueryFaultsConfigEnable.Rows.Add(dr);
            }
            Global.reorderDtFaultsConfigNO(this.dtQueryFaultsConfigEnable);

            //以dtFaultsConfig更新dtQueryFaultsConfigNotEnable
            this.dtQueryFaultsConfigNotEnable.Rows.Clear();
            DataRow[] drTempNotEnable = Global.dtFaultsConfig.Select("FaultEnable = '禁止'");
            foreach (var dp in drTempNotEnable)
            {
                DataRow dr = this.dtQueryFaultsConfigNotEnable.NewRow();
                dr["NO"] = dp["NO"];
                dr["LineName"] = dp["LineName"];
                dr["DeviceName"] = dp["DeviceName"];
                dr["FaultName"] = dp["FaultName"];
                dr["FaultEnable"] = dp["FaultEnable"];
                this.dtQueryFaultsConfigNotEnable.Rows.Add(dr);
            }
            Global.reorderDtFaultsConfigNO(this.dtQueryFaultsConfigNotEnable);

            //查询结果后默认选中第一行
            selectRow[0] = 0;
            this.tileView1.FocusedRowHandle = selectRow[0];
            refreshColorButtonStatusChange();


            //在显示全部时点击查询
            if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.allFaultsConfig)
            {
                
            }
            //在仅显示使能时点击查询
            else if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.enableFaultsConfig)
            {

            }
            //在仅显示禁止时点击查询
            else if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.notEnableFualtsConfig)
            {

            }
        }

        private void simpleButton_statusChange_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_faultsConfig.DataSource).Rows.Count > 0 && selectRow.Length == 1)
            {
                DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);       //取tileView1中选中行的引用，不是传值
                if (drTemp != null) //避免未选中行就点击按钮
                {
                    faultsIndexAndStatus fTemp = new faultsIndexAndStatus();
                    //直接赋值row的话是传引用，状态会随之发生改变，起不到记录的作用,所以各个参数分别赋值
                    fTemp.rowHandle = selectRow[0];
                    fTemp.faultsNO = drTemp["NO"].ToString();
                    fTemp.faultsLineName = drTemp["LineName"].ToString();
                    fTemp.faultsDeviceName = drTemp["DeviceName"].ToString();
                    fTemp.faultsFaultName = drTemp["FaultName"].ToString();
                    fTemp.faultsFaultEnable = drTemp["FaultEnable"].ToString();
                    faultsStorage.Push(fTemp);   //暂存当前被改变的行。因为可能一次改变多行，然后再点保存/取消

                    if (drTemp["FaultEnable"].ToString() == "使能")
                    {
                        drTemp["FaultEnable"] = "禁止";   //修改当前DataSource绑定的表某行

                        //因为DataSource绑定的可能是dtFaultsConfig或dtQueryFaultsConfigType。当是后者时需要将修改的行同步到dtFaultsConfig
                        if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.enableFaultsConfig || queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.notEnableFualtsConfig)
                        {
                            string cmdSelDtFaultsConfig = "LineName = '" + drTemp["LineName"].ToString() + "' AND DeviceName = '" + drTemp["DeviceName"].ToString() + "' AND FaultName = '" + drTemp["FaultName"].ToString() + "'";
                            DataRow[] drr = Global.dtFaultsConfig.Select(cmdSelDtFaultsConfig); //查询出dtFaultsConfig中对应行
                            if (drr.Length == 1)
                            {
                                drr[0]["FaultEnable"] = drTemp["FaultEnable"].ToString(); //同步dtFaultsConfig中对应dtQueryFaultsConfigType的行
                            }
                        }

                        //保存被修改行当前状态
                        fTemp.faultsFaultEnable = "禁止";
                        if (faultsLatest.ContainsKey(fTemp.rowHandle))
                        {
                            faultsLatest[fTemp.rowHandle] = fTemp;
                        }
                        else
                        {
                            faultsLatest.Add(fTemp.rowHandle, fTemp);
                        }
                        refreshColorButtonStatusChange();
                    }
                    else
                    {
                        drTemp["FaultEnable"] = "使能";

                        if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.enableFaultsConfig || queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.notEnableFualtsConfig)
                        {
                            string cmdSelDtFaultsConfig = "LineName = '" + drTemp["LineName"].ToString() + "' AND DeviceName = '" + drTemp["DeviceName"].ToString() + "' AND FaultName = '" + drTemp["FaultName"].ToString() + "'";
                            DataRow[] drr = Global.dtFaultsConfig.Select(cmdSelDtFaultsConfig); //查询出dtFaultsConfig中对应行
                            if (drr.Length == 1)
                            {
                                drr[0]["FaultEnable"] = drTemp["FaultEnable"].ToString(); //同步dtFaultsConfig中对应dtQueryFaultsConfigType的行
                            }
                        }

                        fTemp.faultsFaultEnable = "使能";
                        if (faultsLatest.ContainsKey(fTemp.rowHandle))
                        {
                            faultsLatest[fTemp.rowHandle] = fTemp;
                        }
                        else
                        {
                            faultsLatest.Add(fTemp.rowHandle, fTemp);
                        }
                        refreshColorButtonStatusChange();
                    }
                }
            }

        }

        //显示全部/使能/禁止
        private void simpleButton_queryTypeFaultsConfig_Click(object sender, EventArgs e)
        {
            selectRow[0] = 0;   //每次更改显示时，都默认选中第一行
            queryFaultsConfigTypeCurrent = (++queryFaultsConfigTypeCurrent) % 3;   //更新按钮显示标志

            if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.allFaultsConfig)
            {
                this.simpleButton_queryTypeFaultsConfig.Text = "显示全部";
                this.simpleButton_queryTypeFaultsConfig.Appearance.BackColor = Color.Transparent;
                this.gridControl_faultsConfig.DataSource = Global.dtFaultsConfig;
                refreshColorButtonStatusChange();
            }
            else if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.enableFaultsConfig)
            {
                this.dtQueryFaultsConfigEnable.Rows.Clear();  //清空dtQueryFaultsConfigType
                this.simpleButton_queryTypeFaultsConfig.Text = "仅显示使能";
                this.simpleButton_queryTypeFaultsConfig.Appearance.BackColor = Color.FromArgb(56, 152, 83);
                //从dtFaultsConfig中将使能的记录拷贝到dtQueryFaultsConfigEnable中
                DataRow[] drTemp = Global.dtFaultsConfig.Select("FaultEnable = '使能'");
                foreach (var dp in drTemp)
                {
                    //不能直接把dp添加到dtQueryFaultsConfigEnable中，报错dp属于另一个表
                    DataRow dr = this.dtQueryFaultsConfigEnable.NewRow();
                    dr["NO"] = dp["NO"];
                    dr["LineName"] = dp["LineName"];
                    dr["DeviceName"] = dp["DeviceName"];
                    dr["FaultName"] = dp["FaultName"];
                    dr["FaultEnable"] = dp["FaultEnable"];
                    this.dtQueryFaultsConfigEnable.Rows.Add(dr);
                }
                Global.reorderDtFaultsConfigNO(this.dtQueryFaultsConfigEnable);
                this.gridControl_faultsConfig.DataSource = this.dtQueryFaultsConfigEnable;    //grid显示绑定dtQueryFaultsConfigType
                refreshColorButtonStatusChange();
            }
            else if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.notEnableFualtsConfig)
            {
                this.dtQueryFaultsConfigNotEnable.Rows.Clear();
                this.simpleButton_queryTypeFaultsConfig.Text = "仅显示禁止";
                this.simpleButton_queryTypeFaultsConfig.Appearance.BackColor = Color.FromArgb(208, 49, 68);
                //从dtFaultsConfig中将禁止的记录拷贝到dtQueryFaultsConfigType中
                DataRow[] drTemp = Global.dtFaultsConfig.Select("FaultEnable = '禁止'");
                foreach (var dp in drTemp)
                {
                    DataRow dr = this.dtQueryFaultsConfigNotEnable.NewRow();
                    dr["NO"] = dp["NO"];
                    dr["LineName"] = dp["LineName"];
                    dr["DeviceName"] = dp["DeviceName"];
                    dr["FaultName"] = dp["FaultName"];
                    dr["FaultEnable"] = dp["FaultEnable"];
                    this.dtQueryFaultsConfigNotEnable.Rows.Add(dr);
                }
                Global.reorderDtFaultsConfigNO(this.dtQueryFaultsConfigNotEnable);
                this.gridControl_faultsConfig.DataSource = this.dtQueryFaultsConfigNotEnable;
                refreshColorButtonStatusChange();
            }
        }

        private void simpleButton_saveStatusChange_Click(object sender, EventArgs e)
        {
            if (faultsLatest.Count != 0)    //有改动时才保存
            {
                MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "cloud_manage", "root", "ei41");
                mysqlHelper1._connectMySQL();

                bool flagSaveSuccess = true;
                foreach (var fo in faultsLatest)
                {
                    string lineName = fo.Value.faultsLineName;
                    string deviceName = fo.Value.faultsDeviceName;
                    string faultName = fo.Value.faultsFaultName;

                    //后续加个事务
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
            
        }

        private void simpleButton_cancelStatusChange_Click(object sender, EventArgs e)
        {
            while (faultsStorage.Count != 0)
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

                //dtFaultsConfig还原到最初的状态
                foreach (var fo in faultsOriginal)
                {
                    Global.dtFaultsConfig.Rows[fo.Key]["FaultEnable"] = fo.Value.faultsFaultEnable; //还原dtFaultsConfig，不用faultsStorage[0]直接赋值，因为有多个行被记录
                }

                this.dtQueryFaultsConfigEnable.Rows.Clear();  //清空
                this.dtQueryFaultsConfigNotEnable.Rows.Clear();  //清空

                //以dtFaultsConfig更新dtQueryFaultsConfigEnable
                if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.enableFaultsConfig)
                {
                    DataRow[] drTemp = Global.dtFaultsConfig.Select("FaultEnable = '使能'");
                    foreach (var dp in drTemp)
                    {
                        //不能直接把dp添加到dtQueryFaultsConfigType中，报错dp属于另一个表
                        DataRow dr = this.dtQueryFaultsConfigEnable.NewRow();
                        dr["NO"] = dp["NO"];
                        dr["LineName"] = dp["LineName"];
                        dr["DeviceName"] = dp["DeviceName"];
                        dr["FaultName"] = dp["FaultName"];
                        dr["FaultEnable"] = dp["FaultEnable"];
                        this.dtQueryFaultsConfigEnable.Rows.Add(dr);
                    }
                    Global.reorderDtFaultsConfigNO(this.dtQueryFaultsConfigEnable);
                }
                //以dtFaultsConfig更新dtQueryFaultsConfigNotEnable
                else if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.notEnableFualtsConfig)
                {
                    DataRow[] drTemp = Global.dtFaultsConfig.Select("FaultEnable = '禁止'");
                    foreach (var dp in drTemp)
                    {
                        //不能直接把dp添加到dtQueryFaultsConfigType中，报错dp属于另一个表
                        DataRow dr = this.dtQueryFaultsConfigNotEnable.NewRow();
                        dr["NO"] = dp["NO"];
                        dr["LineName"] = dp["LineName"];
                        dr["DeviceName"] = dp["DeviceName"];
                        dr["FaultName"] = dp["FaultName"];
                        dr["FaultEnable"] = dp["FaultEnable"];
                        this.dtQueryFaultsConfigNotEnable.Rows.Add(dr);
                    }
                    Global.reorderDtFaultsConfigNO(this.dtQueryFaultsConfigNotEnable);
                }
                
                faultsOriginal.Clear();
                faultsLatest.Clear();

                refreshColorButtonStatusChange();
            }
        }


       




    }
}
