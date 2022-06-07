using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
        public static ushort currentPageIndex = 14;     //本页在所有页面中的index

        private CommonControl.NumberKeyboard numberKeyboard1;   //数字小键盘对象

        private int[] selectRow = { 0 };    //选中行的RowHandle
        //int[] selectRow = new int[1];    //选中行的RowHandle

        string cmdQueryDeviceInfoThresholdTemp = String.Empty;
        enum ModifyUpperOrLower { modifyUpper = 0, modifyLower = 1 };   //标识修改的是上限还是下限
        int modifyUpperOrLowerCurrent;  //当前修改的是上限还是下限
        private CommonControl.InformationBox infoBox_saveOrCancel;      //信息通知框：保存或取消

        struct thresholdIndexAndVal
        {
            public string NO;       //row在dtDeviceInfoThresholdGridShow中位置
            public int rowHandle;   //row在dtDeviceInfoThresholdGridShowTemp中位置
            public string LineNO;
            public string DeviceNO;
            public string ParaNO;       //参数NO
            public string ParaSuffix;   //参数单位
            public string LowerLimit;   //下限
            public string UpperLimit;   //上限
        };

        Dictionary<int, thresholdIndexAndVal> thresholdOriginal = new Dictionary<int, thresholdIndexAndVal>(); //暂存未保存时被改动行的最初状态
        Dictionary<int, thresholdIndexAndVal> thresholdLatest = new Dictionary<int, thresholdIndexAndVal>();   //存所有被改动行的最新的状态

        public MonitorThreshold()
        {
            InitializeComponent();
            initMonitorThreshold(); //初始化页面
            MainForm.deviceOrLineAdditionDeletionReinitMonitorThreshold += reInitRealTime;  //绑定重刷新页面事件
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5); //进度条+5%

        }

        public void reInitRealTime(object sender, EventArgs e)
        {
            //MessageBox.Show("重新刷新MonitorThreshold页面");
            initMonitorThreshold();
            Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion = Global.SetBitValueInt32(Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion, currentPageIndex, false);  //刷新页面后将该页面的标志位重置
        }

        private void initMonitorThreshold()
        {
            _initSideTileBarWithSub();  //初始化侧边栏
            Global._init_dtDeviceInfoThresholdGridShow();   //
            Global.reorderDt(ref Global.dtDeviceInfoThresholdGridShow);     //对表dtDeviceInfoThresholdGridShow的NO重排序
            this.gridControl_monitorThreshold.DataSource = Global.dtDeviceInfoThresholdGridShow;    //dtDeviceInfoThresholdGridShow作为grid数据源

            if (((DataTable)this.gridControl_monitorThreshold.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRow[0]; //默认选中第一行
            }
            refreshSelectRow();
        }


        /// <summary>
        /// 初始化阈值监测页面侧边栏
        /// </summary>
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

        /// <summary>
        /// 刷新导航栏
        /// </summary>
        void _refreshLabelDir()
        {
            string str1 = Global._getProductionLineNameByTag(this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem);
            string str2 = Global._getTestingDeviceNameByTag(this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub);
            this.labelControl_dir.Text = "   " + str1 + "——" + str2;
        }

        //void refreshLabelDirLine()
        //{
        //    string str1 = Global._getProductionLineNameByTag(this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem);
        //    this.labelControl_dir.Text = "   " + str1 + "——" + "所有设备";
        //}

        ////刷新目录：设备
        //public void refreshLabelDirDevice()
        //{
        //    DataRow[] dr = Global.dtSideTileBar.Select("LineNO='" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem + "'");
        //    string str1 = Global._getProductionLineNameByTag(this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem);
        //    if (dr.Length == 1)
        //    {
        //        if (Convert.ToInt32(dr[0]["DeviceTotalNum"]) != 0)
        //        {
        //            string str2 = Global._getTestingDeviceNameByTag(this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub);
        //            this.labelControl_dir.Text = "   " + str1 + "——" + str2;
        //        }
        //        else
        //        {
        //            this.labelControl_dir.Text = "   " + str1 + "——" + "所有设备";
        //        }
        //    }
        //}

        //刷新当前选中行（当grid绑定的dt发生改变时必须要刷新，否则自动选中第一行）
        private void refreshSelectRow()
        {
            if (selectRow.Length == 1)
            {
                this.tileView1.FocusedRowHandle = selectRow[0];
            }
        }

        /// <summary>
        /// 小键盘刷新(重新创建对象)
        /// </summary>
        /// <param name="title">数字小键盘的标题</param>
        /// <param name="min">数字小键盘合法输入值范围下限</param>
        /// <param name="max">数字小键盘合法输入值范围上限</param>
        private void createNumberKeyboard(string title, double min, double max)
        {
            if (this.numberKeyboard1 != null)
            {
                this.numberKeyboard1.Visible = false;
            }
            this.numberKeyboard1 = new CommonControl.NumberKeyboard(min, max);
            this.numberKeyboard1.Appearance.BackColor = System.Drawing.Color.White;
            this.numberKeyboard1.Appearance.Options.UseBackColor = true;
            this.numberKeyboard1.Location = new System.Drawing.Point(6, 150);
            this.numberKeyboard1.Name = "numberKeyboard1";
            this.numberKeyboard1.Size = new System.Drawing.Size(350, 650);
            this.numberKeyboard1.TabIndex = 28;
            this.numberKeyboard1.title = title;
            this.panelControl_rightSide.Controls.Add(this.numberKeyboard1);
            this.numberKeyboard1.BringToFront();
            this.numberKeyboard1.Visible = false;
            this.numberKeyboard1.NumberKeyboardEnterClicked += new CloudManage.CommonControl.NumberKeyboard.SimpleButtonEnterClickHanlder(this.numberKeyboard1_NumberKeyboardEnterClicked);
        }

        /// <summary>
        /// 将dr中的UpperLimit、LowerLimit中的单位去掉
        /// </summary>
        /// <param name="limit">传入的UpperLimit或LowerLimit</param>
        /// <param name="suffix">传入的上下限的单位</param>
        /// <returns>UpperLimit或LowerLimit去掉单位后的字符串</returns>
        private string removeSuffixLimits(string limit, string suffix)
        {
            int lenStrSuffis = suffix.Length;
            int lenLimit = limit.Length;
            string limitWithoutSuffix = limit.Remove(lenLimit - lenStrSuffis);
            return limitWithoutSuffix;
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
        /// 创建保存或取消信息通知框
        /// </summary>
        /// <param name="infoMsg">信息通知框显示的文本</param>
        /// <param name="disappearIntervalMS">信息通知框显示时间（ms）</param>
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

        //手动记录grid中选中行
        private void gridControl_deviceInfoThreshold_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_monitorThreshold.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRow = this.tileView1.GetSelectedRows();   //记录选中的行
                refreshSelectRow();
            }
            if (selectRow.Length > 1)
            {
                MessageBox.Show("当前选中不止一行");
            }
        }

        /// <summary>
        /// 点击侧边栏不同按钮时，初始化数据库查询命令
        /// </summary>
        private void initCmdQueryDeviceInfoThresholdTemp()
        {
            if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem == "000")
            {
                if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub == "000")
                {
                    //查询所有产线的所有设备
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(0, '000', '000')";    
                }
                else
                {
                    //查询所有产线的指定设备
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(1, '000', '" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub + "');";
                }
            }
            else
            {
                if (this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub == "000")
                {
                    //查询指定产线的所有设备
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(2,'" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem + "', '000');";
                }
                else
                {
                    //查询指定产线的指定设备
                    cmdQueryDeviceInfoThresholdTemp = "CALL initDtDeviceInfoThresholdGridShowTemp(3,'" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItem + "', '" + this.sideTileBarControlWithSub_monitorThreshold.tagSelectedItemSub + "');";
                }
            }
        }

        /// <summary>
        /// 根据选中的侧边栏按钮，查询数据库更新表dtDeviceInfoThresholdGridShowTemp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshGridSourceSideTileBarPressed(object sender, EventArgs e)
        {
            if (this.numberKeyboard1 != null)
                this.numberKeyboard1.Visible = false;    //隐藏小键盘，等待重新选择“更改上下限”重新创建
            initCmdQueryDeviceInfoThresholdTemp();  //初始化查询命令
            //simpleButton_cancelThresholdModify_Click(sender, e);    //上次未保存的操作全部取消
            cancelThresholdModify();    //上次未保存的操作全部取消

            //更新dtFaultsConfig
            bool flag = Global.mysqlHelper1._queryTableMySQL(cmdQueryDeviceInfoThresholdTemp, ref Global.dtDeviceInfoThresholdGridShowTemp);
            Global.dtDeviceInfoThresholdGridShow.Rows.Clear();
            Global.transformDtDeviceInfoThresholdGridTemp(ref Global.dtDeviceInfoThresholdGridShowTemp, ref Global.dtDeviceInfoThresholdGridShow);
            Global.reorderDt(ref Global.dtDeviceInfoThresholdGridShow);
            selectRow[0] = 0;
            refreshSelectRow();
        }

        private void sideTileBarControlWithSub_monitorThreshold_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
            //refreshLabelDirLine();
            //refreshGridSourceSideTileBarPressed(sender, e);
        }

        private void sideTileBarControlWithSub_monitorThreshold_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            //refreshLabelDirLine();
            //refreshLabelDirDevice();
            _refreshLabelDir();
            refreshGridSourceSideTileBarPressed(sender, e);
        }


        //修改上限按钮事件
        private void simpleButton_modifyUpperLimit_Click(object sender, EventArgs e)
        {
            if (((DataTable)gridControl_monitorThreshold.DataSource).Rows.Count > 0)
            {
                this.modifyUpperOrLowerCurrent = (int)ModifyUpperOrLower.modifyUpper;   //修改当前修改上限/下限标志
                string lowerLimitCurrentRow = removeSuffixLimits(Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["LowerLimit"].ToString(), Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"].ToString());  //把dt["LowerLimit"]的单位去掉
                createNumberKeyboard("修改上限", Convert.ToDouble(lowerLimitCurrentRow), 999999D);  //创建小键盘，上限修改的最小值为下限
                this.numberKeyboard1.Visible = true;
            }
        }

        //修改下限按钮事件
        private void simpleButton_modifyLowerLimit_Click(object sender, EventArgs e)
        {
            if (((DataTable)gridControl_monitorThreshold.DataSource).Rows.Count > 0)
            {
                this.modifyUpperOrLowerCurrent = (int)ModifyUpperOrLower.modifyLower;   //修改当前修改上限/下限标志
                string upperLimitCurrentRow = removeSuffixLimits(Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["UpperLimit"].ToString(), Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"].ToString());  //把dt["LowerLimit"]的单位去掉
                createNumberKeyboard("修改下限", 0.0D, Convert.ToDouble(upperLimitCurrentRow)); //创建小键盘，下限修改的最大值为上限
                this.numberKeyboard1.Visible = true;
            }
        }

        /// <summary>
        /// 数字小键盘Enter事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberKeyboard1_NumberKeyboardEnterClicked(object sender, EventArgs e)
        {
            if (this.modifyUpperOrLowerCurrent == (int)ModifyUpperOrLower.modifyUpper)  
            {
                //修改上限
                double numberKeyboardResultTemp = this.numberKeyboard1.result;  //获取小键盘输入结果
                string lowerLimitCurrentRow = removeSuffixLimits(Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["LowerLimit"].ToString(), Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"].ToString());  //把dt["LowerLimit"]的单位去掉

                //保存最新的修改
                if (((DataTable)this.gridControl_monitorThreshold.DataSource).Rows.Count > 0 && selectRow.Length == 1)
                {
                    DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);   //获取grid选中行
                    if (drTemp != null)
                    {
                        //获取选中行的信息并保存
                        thresholdIndexAndVal fTemp = new thresholdIndexAndVal();
                        fTemp.NO = drTemp["NO"].ToString();
                        fTemp.rowHandle = selectRow[0];
                        fTemp.LineNO = drTemp["LineNO"].ToString();
                        fTemp.DeviceNO = drTemp["DeviceNO"].ToString();
                        fTemp.ParaNO = drTemp["ParaNO"].ToString();
                        fTemp.ParaSuffix = drTemp["ParaSuffix"].ToString();
                        fTemp.LowerLimit = drTemp["LowerLimit"].ToString();
                        fTemp.UpperLimit = drTemp["UpperLimit"].ToString();

                        //保存被修改行的原始信息到thresholdOriginal
                        if (!thresholdOriginal.ContainsKey(Convert.ToInt32(fTemp.NO)))
                        {
                            thresholdOriginal.Add(Convert.ToInt32(fTemp.NO), fTemp);
                        }

                        //保存被修改行最新修改（只改了上限）后的信息
                        string UpperLimitTemp = numberKeyboardResultTemp.ToString() + Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"];
                        fTemp.UpperLimit = UpperLimitTemp;  //暂存最新修改，暂时不修改grid绑定表，否则会在thresholdLatest暂存最新修改前，就触发itemCustomize事件，最新的修改无法表现在grid上的红色改变
                        if (thresholdLatest.ContainsKey(Convert.ToInt32(fTemp.NO)))
                        {
                            thresholdLatest[Convert.ToInt32(fTemp.NO)] = fTemp; //若有更新信息
                        }
                        else
                        {
                            thresholdLatest.Add(Convert.ToInt32(fTemp.NO), fTemp);  //若没有则添加
                        }

                        //修改grid显示
                        Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["UpperLimit"] = UpperLimitTemp; //修改数据源中对应行的上限
                        selectRow = this.tileView1.GetSelectedRows();
                        refreshSelectRow();
                    }
                }
            }
            else
            {
                //修改下限
                //需要判断输入的下限是否小于上限
                double numberKeyboardResultTemp = this.numberKeyboard1.result;
                string upperLimitCurrentRow = removeSuffixLimits(Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["UpperLimit"].ToString(), Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"].ToString());

                if (((DataTable)this.gridControl_monitorThreshold.DataSource).Rows.Count > 0 && selectRow.Length == 1)
                {
                    DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);   //获取grid选中行
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

                        //保存被修改行的原始信息到thresholdOriginal
                        if (!thresholdOriginal.ContainsKey(Convert.ToInt32(fTemp.NO)))
                        {
                            thresholdOriginal.Add(Convert.ToInt32(fTemp.NO), fTemp);
                        }

                        //保存被修改行最新的信息
                        string LowerLimitTemp = numberKeyboardResultTemp.ToString() + Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["ParaSuffix"];    //修改后的下限
                        fTemp.LowerLimit = LowerLimitTemp;  
                        if (thresholdLatest.ContainsKey(Convert.ToInt32(fTemp.NO)))
                        {
                            thresholdLatest[Convert.ToInt32(fTemp.NO)] = fTemp;
                        }
                        else
                        {
                            thresholdLatest.Add(Convert.ToInt32(fTemp.NO), fTemp);
                        }

                        Global.dtDeviceInfoThresholdGridShow.Rows[selectRow[0]]["LowerLimit"] = LowerLimitTemp; //修改数据源中对应行的下限
                        selectRow = this.tileView1.GetSelectedRows();
                        refreshSelectRow();
                    }
                }
            }
        }

        public delegate void ParaLimitsChangedHanlder(object sender, EventArgs e);
        public static event ParaLimitsChangedHanlder paraLimitsChangedExists; //不用static，RealTime访问不到？
        /// <summary>
        /// 将所有被修改的行的最新状态写入MySQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_saveThresholdModify_Click(object sender, EventArgs e)
        {
            if (thresholdLatest.Count != 0)    //有修改时才保存
            {
                bool flagSaveSuccess = true;
                foreach (var to in thresholdLatest)
                {
                    //遍历thresholdLatest，依次获取产线NO、设备NO、参数NO、上限、下限
                    string lineNO = to.Value.LineNO;
                    string deviceNO = to.Value.DeviceNO;
                    string paraNO = to.Value.ParaNO;
                    string upperLimit = removeSuffixLimits(to.Value.UpperLimit, to.Value.ParaSuffix);
                    string lowerLimit = removeSuffixLimits(to.Value.LowerLimit, to.Value.ParaSuffix);

                    //将上述获取的参数作为新值更新表device_info中记录
                    string cmdSaveDtDevice_info_threshold = "UPDATE device_info_threshold SET Para" + paraNO + "Max='" + upperLimit +
                                          "', Para" + paraNO + "Min='" + lowerLimit + "' WHERE LineNO='" + lineNO + "' AND DeviceNO='" + deviceNO + "';";
                    bool flag1 = Global.mysqlHelper1._updateMySQL(cmdSaveDtDevice_info_threshold);
                    if (flag1 == false)
                    {
                        flagSaveSuccess = false;
                        initInfoBox_successOrFail("阈值修改保存失败！", 1000);
                    }
                }

                //将修改成功写入MySQL
                if (flagSaveSuccess == true)
                {
                    thresholdLatest.Clear();    //清空暂存被修改的最新信息的表
                    Global.reorderDt(ref Global.dtDeviceInfoThresholdGridShow); //保存后，因为grid绑定的表没有变化，所以虽然thresholdLatest以清空，但itemCustomize不会触发，被修改的行不会从红色刷新到白色
                    if(((DataTable)this.gridControl_monitorThreshold.DataSource).Rows.Count > 0)
                        selectRow = this.tileView1.GetSelectedRows();
                    refreshSelectRow();
                    initInfoBox_successOrFail("阈值修改保存成功！",1000);

                    paraLimitsChangedExists(sender, new EventArgs());   //将阈值被修改的事件传到RealTimeData，根据阈值的修改重新刷新实时数据的正常/异常显示
                }
                thresholdOriginal.Clear();
            }
        }

        /// <summary>
        /// 放弃阈值的修改
        /// 用记录被修改行最初状态的表thresholdOriginal还原数据源Global.dtDeviceInfoThresholdGridShow中状态
        /// </summary>
        private void cancelThresholdModify()
        {
            this.thresholdLatest.Clear();   //首先把最新修改表清空，防止后面用thresholdOriginal还原dtDeviceInfoThresholdGridShow触发itemCustomize时，thresholdLatest未修改

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
            }

            this.thresholdOriginal.Clear(); //全部还原后清空记录最初状态的表
            //Global.transformDtDeviceInfoThresholdGridTemp(ref Global.dtDeviceInfoThresholdGridShowTemp, ref Global.dtDeviceInfoThresholdGridShow);            Global.reorderDt(ref Global.dtDeviceInfoThresholdGridShow); //重排grid绑定的dt会触发itemCustomize事件

            if (((DataTable)this.gridControl_monitorThreshold.DataSource).Rows.Count > 0)
                selectRow = this.tileView1.GetSelectedRows();
            refreshSelectRow();
        }

        private void simpleButton_cancelThresholdModify_Click(object sender, EventArgs e)
        {
            cancelThresholdModify();
            initInfoBox_successOrFail("所有修改已取消！", 1000);
        }

        //刷新grid中所有被修改过的行的字体颜色
        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item == null || e.Item.Elements.Count == 0)
                return;

            e.Item.AppearanceItem.Normal.ForeColor = Color.White;   //字体默认白色
            e.Item.AppearanceItem.Focused.ForeColor = Color.White;

            if (thresholdLatest.ContainsKey(e.RowHandle + 1))   //(DataTable)tileview1.DataSource中NO=RowHandle+1
            {
                e.Item.AppearanceItem.Normal.ForeColor = Color.FromArgb(208, 49, 68);   //数据源中的某行的NO在thresholdLatest中存在就表明被修改过
                e.Item.AppearanceItem.Focused.ForeColor = Color.FromArgb(208, 49, 68);
            }
        }


    }
}
