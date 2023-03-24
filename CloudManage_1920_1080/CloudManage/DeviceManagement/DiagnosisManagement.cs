using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
        public static ushort currentPageIndex = 15;

        private int[] selectRow = { 0 };

        /// <summary>
        /// 记录：故障在dtFaultsConfig中的行号、故障的产线名、故障的设备名、故障名、故障使能状态
        /// </summary>
        struct faultsIndexAndStatus
        {
            public int rowHandle;   //row在表dtFaultsConfig（记录所有故障）中位置
            public string faultsNO;
            public string faultsLineName;
            public string faultsDeviceName;
            public string faultsFaultName;
            public string faultsFaultEnable;    //"使能""禁止"
        };

        Stack<faultsIndexAndStatus> faultsStorage = new Stack<faultsIndexAndStatus>();                      //暂存故障设置被修改的所有历史
        Dictionary<int, faultsIndexAndStatus> faultsOriginal = new Dictionary<int, faultsIndexAndStatus>(); //暂存未保存时被改动行的最初状态。作用：取消修改时返回故障的最初状态
        Dictionary<int, faultsIndexAndStatus> faultsLatest = new Dictionary<int, faultsIndexAndStatus>();   //存所有被改动行的当前状态。作用：保存故障最新状态到MySQL

        string cmdQueryFaultsConfig = String.Empty;

        enum queryFaultsConfigType {allFaultsConfig = 0, enableFaultsConfig, notEnableFualtsConfig};   //页面显示类型：显示所有故障、仅显示使能、仅显示禁止
        int queryFaultsConfigTypeCurrent = (int)queryFaultsConfigType.allFaultsConfig;  //记录当前显示页面标志（所有故障、仅显示使能、仅显示禁止）
        DataTable dtQueryFaultsConfigEnable = new DataTable();      //暂存查询出来的所有使能
        DataTable dtQueryFaultsConfigNotEnable = new DataTable();   //暂存查询出来的所有禁止

        private CommonControl.InformationBox infoBox_saveOrCancel;  //确认框：保存或取消


        public DiagnosisManagement()
        {
            InitializeComponent();

            initDiagnosisManagement();  //初始化页面

            MainForm.deviceOrLineAdditionDeletionReinitdiagnosisManagement += reInitDiagnosisManagement;    //绑定重新刷新页面事件
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5); //进度条增加5%
        }

        private void reInitDiagnosisManagement(object sender, EventArgs e)
        {
            //MessageBox.Show("重新刷新DiagnosisManagement页面");
            initDiagnosisManagement();
            Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = Global.SetBitValueInt32(Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion, currentPageIndex, false);  //刷新页面后将该页面的标志位重置
        }

        private void initDiagnosisManagement()
        {
            _initSideTileBarWithSub();        //初始化侧边栏
            Global._init_dtFaultsConfig();    //初始化故障配置表
            initDtqueryFaultsConfigEnableAndNotEnable();    //初始化使能/禁止表
            Global.reorderDt(ref Global.dtFaultsConfig);  //NO从1开始排序
            this.gridControl_faultsConfig.DataSource = Global.dtFaultsConfig;   //绑定grid显示数据源
            if (((DataTable)this.gridControl_faultsConfig.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRow[0]; //默认选中第一行
            }
        }

        /// <summary>
        /// 初始化诊断页面侧边栏
        /// </summary>
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

        /// <summary>
        /// 初始化表dtQueryFaultsConfigEnable和dtQueryFaultsConfigNotEnable
        /// </summary>
        private void initDtqueryFaultsConfigEnableAndNotEnable()
        {
            if (this.dtQueryFaultsConfigEnable.Columns.Count == 0)
            {
                this.dtQueryFaultsConfigEnable.Columns.Add("NO", typeof(String));
                this.dtQueryFaultsConfigEnable.Columns.Add("LineName", typeof(String));
                this.dtQueryFaultsConfigEnable.Columns.Add("DeviceName", typeof(String));
                this.dtQueryFaultsConfigEnable.Columns.Add("FaultName", typeof(String));
                this.dtQueryFaultsConfigEnable.Columns.Add("FaultEnable", typeof(String));
            }
            if (this.dtQueryFaultsConfigNotEnable.Columns.Count == 0)
            {
                this.dtQueryFaultsConfigNotEnable.Columns.Add("NO", typeof(String));
                this.dtQueryFaultsConfigNotEnable.Columns.Add("LineName", typeof(String));
                this.dtQueryFaultsConfigNotEnable.Columns.Add("DeviceName", typeof(String));
                this.dtQueryFaultsConfigNotEnable.Columns.Add("FaultName", typeof(String));
                this.dtQueryFaultsConfigNotEnable.Columns.Add("FaultEnable", typeof(String));
            }
        }

        /// <summary>
        /// 刷新诊断页面的导航栏
        /// </summary>
        void _refreshLabelDir()
        {
            string str1 = Global._getProductionLineNameByTag(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem);
            string str2 = Global._getTestingDeviceNameByTag(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2;
        }

        //void refreshLabelDirLine()
        //{
        //    string str1 = Global._getProductionLineNameByTag(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem);
        //    this.labelControl_dir.Text = "   " + str1 + "——" + "所有设备";
        //}

        ////刷新目录：设备
        //public void refreshLabelDirDevice()
        //{
        //    DataRow[] dr = Global.dtSideTileBar.Select("LineNO='" + this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem + "'");
        //    string str1 = Global._getProductionLineNameByTag(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem);
        //    if (dr.Length == 1)
        //    {
        //        if (Convert.ToInt32(dr[0]["DeviceTotalNum"]) != 0)
        //        {
        //            string str2 = Global._getTestingDeviceNameByTag(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub);
        //            this.labelControl_dir.Text = "   " + str1 + "——" + str2;
        //        }
        //        else
        //        {
        //            this.labelControl_dir.Text = "   " + str1 + "——" + "所有设备";
        //        }
        //    }
        //}

        /// <summary>
        /// 点击侧边栏查询的命令
        /// </summary>
        private void initCmdQueryFaultsConfig()
        {
            if(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem == "000")
            {
                if(this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub == "000")
                {
                    //查询所有产线的所有设备的故障：NO、产线名LineName、设备名DeviceName、故障名FaultName、故障使能状态FaultEnable，按照表faults_config中NO排序
                    cmdQueryFaultsConfig = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO ORDER BY t1.`NO`;";
                }
                else
                {
                    //查询所有产线的特定设备（由tagSelectedItemSub指定设备NO）的故障：NO、产线名LineName、设备名DeviceName、故障名FaultName、故障使能状态FaultEnable，按照表faults_config中NO排序
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
                    //查询特定产线（tagSelectedItem）的所有设备的故障：NO、产线名LineName、设备名DeviceName、故障名FaultName、故障使能状态FaultEnable，按照表faults_config中NO排序
                    cmdQueryFaultsConfig = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO " +
                                           "AND t2.LineNO='" + this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem + "' ORDER BY t1.`NO`;";
                }
                else
                {
                    //查询特定产线（由tagSelectedItem指定）的特定设备（由tagSelectedItemSub指定）的故障：NO、产线名LineName、设备名DeviceName、故障名FaultName、故障使能状态FaultEnable，按照表faults_config中NO排序
                    cmdQueryFaultsConfig = "SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable " +
                                           "FROM faults_config AS t1, productionline AS t2, device AS t3, faults AS t4 " +
                                           "WHERE t1.LineNO=t2.LineNO AND t1.DeviceNO=t3.DeviceNO AND t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO " +
                                           "AND t2.LineNO='" + this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItem + "' " +
                                           "AND t3.DeviceNO='" + this.sideTileBarControlWithSub_diagnosisManagement.tagSelectedItemSub + "' " +
                                           "ORDER BY t1.`NO`;";
                }
            }
        }


        /// <summary>
        /// 当grid绑定数据源发生改变时，刷新grid各个tile的状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;
            if ((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["FaultEnable"]) == "使能")
            {
                //故障是使能时，grid对应行为白色
                e.Item.AppearanceItem.Normal.ForeColor = Color.White;   
                e.Item.AppearanceItem.Focused.ForeColor = Color.White;
            }
            else if ((string)tileView1.GetRowCellValue(e.RowHandle, tileView1.Columns["FaultEnable"]) == "禁止")
            {
                //故障是禁止时，grid对应行是红色
                e.Item.AppearanceItem.Normal.ForeColor = Color.FromArgb(208, 49, 68);
                e.Item.AppearanceItem.Focused.ForeColor = Color.FromArgb(208, 49, 68);
            }
        }


        /// <summary>
        /// 根据选中行刷新《更改状态》按钮的颜色
        /// </summary>
        private void refreshColorButtonStatusChange()
        {
            if (((DataTable)this.gridControl_faultsConfig.DataSource).Rows.Count != 0)
            {
                DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);   //根据行index获取grid行（也即grid绑定数据源的某行）
                if (selectRow.Length == 1)
                {
                    if (drTemp["FaultEnable"].ToString() == "使能")
                    {
                        //若选中的行的故障使能状态是"使能",则将《更改状态》按钮的颜色设为绿色
                        this.simpleButton_statusChange.Appearance.BackColor = Color.FromArgb(56, 152, 83);
                    }
                    else if (drTemp["FaultEnable"].ToString() == "禁止")
                    {
                        //若选中的行的故障使能状态是"禁止",则将《更改状态》按钮的颜色设为红色
                        this.simpleButton_statusChange.Appearance.BackColor = Color.FromArgb(208, 49, 68);
                    }
                }
            }
            else
            {
                //若没有故障，则《更改状态》按钮颜色设为白色
                this.simpleButton_statusChange.Appearance.BackColor = Color.Transparent;
            }
        }

        private void keepSelectRowWhenDataSourceRefresh()
        {
            if (selectRow.Length == 1)
            {
                if (selectRow[0] < this.tileView1.DataRowCount)
                    this.tileView1.FocusedRowHandle = selectRow[0];     //在DataSource发生改变后，手动修改被选中的row
                else
                {
                    this.tileView1.FocusedRowHandle = 0;
                    selectRow[0] = 0;
                }
            }
        }

        /// <summary>
        /// 诊断页面消息通知框
        /// </summary>
        /// <param name="infoMsg">通知信息文本</param>
        /// <param name="disappearIntervalMS">显示时间（ms）</param>
        private void initInfoBox_successOrFail(string infoMsg, int disappearIntervalMS)
        {
            this.infoBox_saveOrCancel = new CommonControl.InformationBox();
            this.infoBox_saveOrCancel.disappearEnable = false;
            this.infoBox_saveOrCancel.infoTitle = infoMsg;
            this.infoBox_saveOrCancel.Location = new System.Drawing.Point(652, 250);
            this.infoBox_saveOrCancel.Name = "informationBox1";
            this.infoBox_saveOrCancel.Size = new System.Drawing.Size(350, 150);
            this.infoBox_saveOrCancel.TabIndex = 36;
            this.infoBox_saveOrCancel.timeDisappear = disappearIntervalMS;
            this.Controls.Add(this.infoBox_saveOrCancel);
            this.infoBox_saveOrCancel.BringToFront();
            this.infoBox_saveOrCancel.disappearEnable = true;
        }

        /// <summary>
        /// 手动记录grid选中行 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl_faultsConfig_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_faultsConfig.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界.不要用itemClick，有时候点击了但selectedrows未改变，出现bug
            {
                selectRow = this.tileView1.GetSelectedRows();   //记录选中的行
                refreshColorButtonStatusChange();
            }

            if (selectRow.Length > 1)
            {
                MessageBox.Show("当前选中不止一行");
            }
        }

        /// <summary>
        /// 根据点击侧边栏对应的按钮刷新grid显示
        /// </summary>
        private void refreshGridSourceSideTileBarPressed()
        {
            initCmdQueryFaultsConfig(); //初始化查询命令，4种

            //更新dtFaultsConfig
            bool flag = Global.mysqlHelper1._queryTableMySQL(cmdQueryFaultsConfig, ref Global.dtFaultsConfig);
            Global.reorderDt(ref Global.dtFaultsConfig);

            //以dtFaultsConfig更新dtQueryFaultsConfigEnable
            this.dtQueryFaultsConfigEnable.Rows.Clear();    //清空记录所有"使能"的故障的表dtQueryFaultsConfigEnable
            DataRow[] drTempEnable = Global.dtFaultsConfig.Select("FaultEnable = '使能'");    //从表dtFaultsConfig中查询所有FaultEnable=='使能'的记录
            //将查询到的所有"使能"的故障记录拷贝到表dtQueryFaultsConfigEnable中
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
            Global.reorderDt(ref this.dtQueryFaultsConfigEnable);   //对表dtQueryFaultsConfigEnable的NO进行重整

            //以dtFaultsConfig更新dtQueryFaultsConfigNotEnable
            this.dtQueryFaultsConfigNotEnable.Rows.Clear();     //清空记录所有"禁止"的故障的表dtQueryFaultsConfigNotEnable
            DataRow[] drTempNotEnable = Global.dtFaultsConfig.Select("FaultEnable = '禁止'");     //从表dtFaultsConfig中查询所有FaultEnable=='禁止'的记录
            //将查询到的所有"禁止"的故障记录拷贝到表dtQueryFaultsConfigNotEnable中
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
            Global.reorderDt(ref this.dtQueryFaultsConfigNotEnable);

            selectRow[0] = 0;
            this.tileView1.FocusedRowHandle = selectRow[0]; //查询结果后默认选中第一行
            refreshColorButtonStatusChange();   //查询后默认选中第一行，根据选中的第一行设置《更改状态》按钮的颜色

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

        //子菜单显示“所有设备”，每次点击产线时默认选中“所有设备”，且刷新grid显示
        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
        }

        //点击具体设备时按照设备刷新grid
        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            //refreshLabelDirLine();
            //refreshLabelDirDevice();
            _refreshLabelDir();     //刷新导航栏显示
            refreshGridSourceSideTileBarPressed();  //根据选中侧边栏的按钮刷新grid显示
        }

        /// <summary>
        /// 更改状态按钮事件
        /// 存储被修改的故障的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_statusChange_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_faultsConfig.DataSource).Rows.Count > 0 && selectRow.Length == 1)
            {
                DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);       //取tileView1中选中行的引用，不是传值
                if (drTemp != null) //避免未选中行就点击按钮
                {
                    faultsIndexAndStatus fTemp = new faultsIndexAndStatus();    //创建一个结构体对象记录当前被修改的故障的信息
                    //直接赋值row的话是传引用，状态会随之发生改变，起不到记录的作用,所以各个参数分别赋值
                    fTemp.faultsNO = drTemp["NO"].ToString();   //故障NO
                    fTemp.faultsLineName = drTemp["LineName"].ToString();   //故障发生的产线名
                    fTemp.faultsDeviceName = drTemp["DeviceName"].ToString();   //故障发生的设备名
                    fTemp.faultsFaultName = drTemp["FaultName"].ToString();     //故障名
                    fTemp.faultsFaultEnable = drTemp["FaultEnable"].ToString(); //故障使能状态
                    if(queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.allFaultsConfig)
                    {
                        //若当前显示为"所有"故障，则rowhandleTemp[0]即为在表dtFaultsConfig中的行号
                        int[] rowhandleTemp = this.tileView1.GetSelectedRows();     //获取grid选中行
                        if (rowhandleTemp.Length == 1)
                        {
                            fTemp.rowHandle = rowhandleTemp[0];     //记录当前选中行对应的故障在表dtFaultsConfig中的行号
                        }
                    }
                    else if(queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.enableFaultsConfig)
                    {
                        //若当前显示为"使能"故障，则在表dtFaultsConfig中查询出所有使能故障drs，drs[0]即为在表dtFaultsConfig中的行号
                        DataRow[] drs = Global.dtFaultsConfig.Select("LineName='" + fTemp.faultsLineName + "' and DeviceName='" + fTemp.faultsDeviceName + "' and FaultName='" + fTemp.faultsFaultName + "' and FaultEnable='" + fTemp.faultsFaultEnable + "'");    //从所有故障中查询出
                        if (drs.Length == 1)
                        {
                            fTemp.rowHandle = Global.dtFaultsConfig.Rows.IndexOf(drs[0]);   //记录当前选中行对应的故障在表dtFaultsConfig中的行号
                        }
                    }
                    else
                    {
                        //若当前显示为"禁止"故障，则在表dtFaultsConfig中查询出所有使能故障drs，drs[0]即为在表dtFaultsConfig中的行号
                        DataRow[] drs = Global.dtDeviceConfig.Select("LineName='" + fTemp.faultsDeviceName + "' and DeviceName='" + fTemp.faultsDeviceName + "' and FaultName='" + fTemp.faultsFaultName + "' and FaultEnable='" + fTemp.faultsFaultEnable + "'");
                        if (drs.Length == 1)
                        {
                            fTemp.rowHandle = Global.dtFaultsConfig.Rows.IndexOf(drs[0]);
                        }
                    }
                    faultsStorage.Push(fTemp);   //暂存当前被改变的行。因为可能一次改变多行，然后再点保存/取消

                    //更改grid当前绑定的数据源中该故障使能状态
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
                                drr[0]["FaultEnable"] = drTemp["FaultEnable"].ToString(); //将表dtFaultsConfig中对应的故障的使能状态修改为同表dtQueryFaultsConfigEnable或dtQueryFaultsConfigNotEnable相同
                            }
                        }

                        //保存被修改故障的最新状态
                        fTemp.faultsFaultEnable = "禁止";
                        if (faultsLatest.ContainsKey(fTemp.rowHandle))
                        {
                            faultsLatest[fTemp.rowHandle] = fTemp;
                        }
                        else
                        {
                            faultsLatest.Add(fTemp.rowHandle, fTemp);
                        }
                        refreshColorButtonStatusChange();   //根据故障使能状态被修改清空设置《更改状态》按钮的颜色
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

                        //存储被改动的故障的最新状态
                        fTemp.faultsFaultEnable = "使能";
                        if (faultsLatest.ContainsKey(fTemp.rowHandle))
                        {
                            faultsLatest[fTemp.rowHandle] = fTemp;
                        }
                        else
                        {
                            faultsLatest.Add(fTemp.rowHandle, fTemp);
                        }
                        refreshColorButtonStatusChange();   //根据故障使能状态被修改清空设置《更改状态》按钮的颜色
                    }
                }
            }

        }

        /// <summary>
        /// 更改grid显示故障类型：显示全部/仅使能/仅禁止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_queryTypeFaultsConfig_Click(object sender, EventArgs e)
        {
            selectRow[0] = 0;   //每次更改显示时，都默认选中第一行
            queryFaultsConfigTypeCurrent = (++queryFaultsConfigTypeCurrent) % 3;   //更新按钮显示标志

            if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.allFaultsConfig)     //当前页面显示类型为：所有故障
            {
                this.simpleButton_queryTypeFaultsConfig.Text = "显示全部";
                this.simpleButton_queryTypeFaultsConfig.Appearance.BackColor = Color.Transparent;   //更改《查询故障类型》按钮颜色
                this.gridControl_faultsConfig.DataSource = Global.dtFaultsConfig;   //显示所有故障时，grid绑定数据源为表Global.dtFaultsConfig
                refreshColorButtonStatusChange();   //根据默认选中第一行刷新《更改状态》按钮的颜色
            }
            else if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.enableFaultsConfig)
            {
                this.dtQueryFaultsConfigEnable.Rows.Clear();  //清空dtQueryFaultsConfigType
                this.simpleButton_queryTypeFaultsConfig.Text = "仅显示使能";
                this.simpleButton_queryTypeFaultsConfig.Appearance.BackColor = Color.FromArgb(56, 152, 83); //更改《查询故障类型》按钮颜色
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
                Global.reorderDt(ref this.dtQueryFaultsConfigEnable);
                this.gridControl_faultsConfig.DataSource = this.dtQueryFaultsConfigEnable;    //grid显示绑定dtQueryFaultsConfigType
                refreshColorButtonStatusChange();
            }
            else if (queryFaultsConfigTypeCurrent == (int)queryFaultsConfigType.notEnableFualtsConfig)
            {
                this.dtQueryFaultsConfigNotEnable.Rows.Clear();
                this.simpleButton_queryTypeFaultsConfig.Text = "仅显示禁止";
                this.simpleButton_queryTypeFaultsConfig.Appearance.BackColor = Color.FromArgb(208, 49, 68);
                //从dtFaultsConfig中将禁止的记录拷贝到dtQueryFaultsConfigNotEnable中
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
                Global.reorderDt(ref this.dtQueryFaultsConfigNotEnable);
                this.gridControl_faultsConfig.DataSource = this.dtQueryFaultsConfigNotEnable;
                refreshColorButtonStatusChange();
            }
        }

        /// <summary>
        /// 保存故障状态更改到MySQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_saveStatusChange_Click(object sender, EventArgs e)
        {
            if (faultsLatest.Count != 0)    //faultsLatest行数非0，表明有改动，有改动时才保存
            {
                bool flagSaveSuccess = true;
                //遍历记录所有修改过的故障的最新状态的表faultsLatest
                foreach (var fo in faultsLatest)
                {
                    string lineName = fo.Value.faultsLineName;
                    string deviceName = fo.Value.faultsDeviceName;
                    string faultName = fo.Value.faultsFaultName;

                    //根据fo的产线名、设备名、故障名，查询对应的产线号LineNO、设备号DeviceNO、故障使能状态FaultEnable到表dtTemp
                    string cmdTransform = "SELECT t1.LineNO, t1.DeviceNO, t1.FaultNO, t1.FaultEnable FROM faults_config AS t1 " +
                                          "INNER JOIN productionline AS t2 ON t1.LineNO=t2.LineNO " +
                                          "INNER JOIN device AS t3 ON t1.DeviceNO=t3.DeviceNO " +
                                          "INNER JOIN faults AS t4 ON t1.DeviceNO=t4.DeviceNO AND t1.FaultNO=t4.FaultNO " +
                                          "WHERE t2.LineName='" + lineName + "' AND t3.DeviceName='" + deviceName + "' AND t4.FaultName='" + faultName + "';";

                    DataTable dtTemp = new DataTable();
                    bool flag1 = Global.mysqlHelper1._queryTableMySQL(cmdTransform, ref dtTemp);
                    if (flag1 == true)
                    {
                        string lineNO = dtTemp.Rows[0]["LineNO"].ToString();        //产线号
                        string deviceNO = dtTemp.Rows[0]["DeviceNO"].ToString();    //设备号
                        string faultNO = dtTemp.Rows[0]["FaultNO"].ToString();      //故障号
                        string faultEnable = fo.Value.faultsFaultEnable == "使能" ? "1" : "0";    //故障使能状态：使能-1，禁止-0

                        //根据获取的产线号、设备号、故障号、故障状态修改MySQL表faults_config对应记录
                        string cmdSaveFaultsConfig = "UPDATE faults_config SET FaultEnable='" + faultEnable + "' " +
                                                     "WHERE LineNO='" + lineNO + "' AND DeviceNO='" + deviceNO + "' AND FaultNO='" + faultNO + "';";
                        bool flag2 = Global.mysqlHelper1._updateMySQL(cmdSaveFaultsConfig);
                        if (flag2 == false)
                        {
                            flagSaveSuccess = false;
                        }
                    }
                }
                if (flagSaveSuccess == true)
                {
                    initInfoBox_successOrFail("状态更改保存成功！",1000);
                    this.tileView1.FocusedRowHandle = selectRow[0];
                }
                else
                {
                    initInfoBox_successOrFail("状态更改保存失败！", 1000);
                }

                faultsOriginal.Clear(); //保存修改到MySQL后，记录故障原始状态的表清空
                faultsLatest.Clear();   //保存修改到MySQL后，记录故障最新状态的表清空
            }
            
        }

        /// <summary>
        /// 取消故障的状态修改。将所有被修改过的故障的状态恢复到最初
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_cancelStatusChange_Click(object sender, EventArgs e)
        {
                //遍历表faultsStorage中故障，若在faultsOriginal中出现过则修改其状态，若在faultsOriginal中未出现过则Add
                //遍历结束后，faultsOriginal中将存储所有被修改过的故障的最初的状态。记录被修改故障的表faultsStorage也将被清空。
                while (faultsStorage.Count != 0)    
                {
                    faultsIndexAndStatus fTemp = faultsStorage.Peek();  
                    int rowHandleDtFaultsConfig = 0;
                    //取出各行最初的状态
                    //if (fTemp.rowHandle == 0)
                    //{
                    //    rowHandleDtFaultsConfig = fTemp.rowHandle;
                    //}
                    rowHandleDtFaultsConfig = fTemp.rowHandle;  //获取故障在表Global.dtFaultsConfig中的行号

                    if (faultsOriginal.ContainsKey(rowHandleDtFaultsConfig))
                    {
                        faultsOriginal[rowHandleDtFaultsConfig] = fTemp;    
                    }
                    else
                    {
                        faultsOriginal.Add(rowHandleDtFaultsConfig, fTemp);
                    }
                    faultsStorage.Pop();  //清空记录的被改变的行
                }

                //dtFaultsConfig还原到最初的状态
                foreach (var fo in faultsOriginal)
                {
                    Global.dtFaultsConfig.Rows[fo.Key]["FaultEnable"] = fo.Value.faultsFaultEnable; //还原dtFaultsConfig，不用faultsStorage[0]直接赋值，因为有多个行被记录
                }

                this.dtQueryFaultsConfigEnable.Rows.Clear();  //因为表dtFaultsConfig被修改，所以清空存储所有使能故障的表dtQueryFaultsConfigEnable重新查询+拷贝
                this.dtQueryFaultsConfigNotEnable.Rows.Clear();

                //dtFaultsConfig修改后，以dtFaultsConfig更新dtQueryFaultsConfigEnable
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
                    Global.reorderDt(ref this.dtQueryFaultsConfigEnable);
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
                    Global.reorderDt(ref this.dtQueryFaultsConfigNotEnable);
                }
                
                faultsOriginal.Clear(); //清空记录被修改故障的最初状态的表清空
                faultsLatest.Clear();   //清空记录被修改故障的最新状态的表清空

                refreshColorButtonStatusChange();   //根据选中行刷新《更改状态》按钮颜色
                initInfoBox_successOrFail("所有更改已取消！", 1000);    //信息通知框显示1s

        }


    }
}
