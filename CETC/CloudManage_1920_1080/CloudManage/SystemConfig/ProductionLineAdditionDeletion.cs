using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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

namespace CloudManage.SystemConfig
{
    public partial class ProductionLineAdditionDeletion : DevExpress.XtraEditors.XtraUserControl
    {
        private int[] selectRowDtProductionLineExists = { 0 };
        private CommonControl.ConfirmationBox confirmationBox_message;
        private VisionSystemControlLibrary.StandardKeyboard standardKeyboard1;
        private CommonControl.InformationBox infoBox_successOrFail;
        private CommonControl.ConfirmationBox confirmationBox_addLine;
        private CommonControl.ConfirmationBox confirmationBox_delLine;
        private CommonControl.ConfirmationBox confirmationBox_modifyLineName;
        private CommonControl.ConfirmationBox confirmationBox_copyLine;


        string inputLineName = String.Empty;
        string[] lineNOVec = new string[999];   //暂存所有可能的LineNO

        public ProductionLineAdditionDeletion()
        {
            InitializeComponent();
            initDeviceAdditionDeletion();

            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);

        }

        void initDeviceAdditionDeletion()
        {
            initLineNOVec();
            Global.initDtProductionLineExists();
            initSideTileBarProductionLineAdditionDeletion();
            this.gridControl_productionLineAdditionDeletion.DataSource = Global.dtProductionLineSystemConfig;

            if (((DataTable)this.gridControl_productionLineAdditionDeletion.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRowDtProductionLineExists[0]; //默认选中第一行
            }
        }

        private void initInfoBox_successOrFail(string infoMsg, int disappearIntervalMS)
        {
            this.infoBox_successOrFail = new CommonControl.InformationBox();
            this.infoBox_successOrFail.disappearEnable = false;
            this.infoBox_successOrFail.infoTitle = infoMsg;
            this.infoBox_successOrFail.Location = new System.Drawing.Point(652, 250);
            this.infoBox_successOrFail.Name = "informationBox1";
            this.infoBox_successOrFail.Size = new System.Drawing.Size(350, 150);
            this.infoBox_successOrFail.TabIndex = 36;
            this.infoBox_successOrFail.timeDisappear = disappearIntervalMS;
            this.Controls.Add(this.infoBox_successOrFail);
            this.infoBox_successOrFail.BringToFront();
            this.infoBox_successOrFail.disappearEnable = true;
        }

        private void initStandardKeyboard(string title)
        {
            if (this.standardKeyboard1 != null)
                this.standardKeyboard1.Dispose();
            this.standardKeyboard1 = new VisionSystemControlLibrary.StandardKeyboard();
            this.standardKeyboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.standardKeyboard1.CapsLock = false;
            this.standardKeyboard1.Chinese_Caption = " ";
            this.standardKeyboard1.English_Caption = " ";
            this.standardKeyboard1.FirstInitialStringValue = false;
            this.standardKeyboard1.InvalidCharacter = null;
            this.standardKeyboard1.IsPassword = false;
            this.standardKeyboard1.Language = VisionSystemClassLibrary.Enum.InterfaceLanguage.English;
            this.standardKeyboard1.Location = new System.Drawing.Point(444, 300);
            this.standardKeyboard1.MaxLength = ((byte)(30));
            this.standardKeyboard1.Name = "standardKeyboard1";
            this.standardKeyboard1.Password = "";
            this.standardKeyboard1.PasswordStyle = 0;
            this.standardKeyboard1.Shift = false;
            this.standardKeyboard1.Size = new System.Drawing.Size(710, 406);
            this.standardKeyboard1.StringValue = "";
            this.standardKeyboard1.StringValueBuf = "";
            this.standardKeyboard1.TabIndex = 0;
            this.standardKeyboard1.Chinese_Caption = title;
            this.Controls.Add(this.standardKeyboard1);
            this.standardKeyboard1.BringToFront();
            this.standardKeyboard1.Visible = true;
            this.standardKeyboard1.Close_Click += new System.EventHandler(standardKeyboard_ESC);
        }

        private void standardKeyboard_ESC(object sender, EventArgs e)
        {
            if (this.standardKeyboard1.EnterNewValue == false)
            {
                lockUnlockButton("unlockbtn");
                this.standardKeyboard1.Dispose();
            }
        }

        private void initConfirmationBox_message(string msg)
        {
            this.confirmationBox_message = new CommonControl.ConfirmationBox();
            this.confirmationBox_message.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox_message.Appearance.Options.UseBackColor = true;
            this.confirmationBox_message.Location = new System.Drawing.Point(624, 100);
            this.confirmationBox_message.Name = "confirmationBox1";
            this.confirmationBox_message.Size = new System.Drawing.Size(350, 200);
            this.confirmationBox_message.TabIndex = 29;
            this.confirmationBox_message.titleConfirmationBox = msg;
            this.Controls.Add(this.confirmationBox_message);
            this.confirmationBox_message.Visible = true;
            this.confirmationBox_message.BringToFront();
        }

        private void initConfirmationBox_addLine()
        {
            this.confirmationBox_addLine = new CommonControl.ConfirmationBox();
            this.confirmationBox_addLine.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox_addLine.Appearance.Options.UseBackColor = true;
            this.confirmationBox_addLine.Location = new System.Drawing.Point(624, 100);
            this.confirmationBox_addLine.Name = "confirmationBox1";
            this.confirmationBox_addLine.Size = new System.Drawing.Size(350, 200);
            this.confirmationBox_addLine.TabIndex = 29;
            this.Controls.Add(this.confirmationBox_addLine);
            this.confirmationBox_addLine.Visible = true;
            this.confirmationBox_addLine.BringToFront();
            this.confirmationBox_addLine.titleConfirmationBox = "确认添加产线:  “" + inputLineName + "”?";
        }

        private void initConfirmationBox_delLine()
        {
            //弹出确认框
            this.confirmationBox_delLine = new CommonControl.ConfirmationBox();
            this.confirmationBox_delLine.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox_delLine.Appearance.Options.UseBackColor = true;
            this.confirmationBox_delLine.Location = new System.Drawing.Point(624, 100);
            this.confirmationBox_delLine.Name = "confirmationBox1";
            this.confirmationBox_delLine.Size = new System.Drawing.Size(350, 200);
            this.confirmationBox_delLine.TabIndex = 29;
            this.Controls.Add(this.confirmationBox_delLine);
            this.confirmationBox_delLine.Visible = true;
            this.confirmationBox_delLine.BringToFront();
           
        }

        private void initConfirmationBox_modifyLineName()
        {
            this.confirmationBox_modifyLineName = new CommonControl.ConfirmationBox();
            this.confirmationBox_modifyLineName.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox_modifyLineName.Appearance.Options.UseBackColor = true;
            this.confirmationBox_modifyLineName.Location = new System.Drawing.Point(624, 100);
            this.confirmationBox_modifyLineName.Name = "confirmationBox1";
            this.confirmationBox_modifyLineName.Size = new System.Drawing.Size(350, 200);
            this.confirmationBox_modifyLineName.TabIndex = 29;
            this.Controls.Add(this.confirmationBox_modifyLineName);
            this.confirmationBox_modifyLineName.Visible = true;
            this.confirmationBox_modifyLineName.BringToFront();
           
        }

        private void initConfiramtionBox_copyLine()
        {
            this.confirmationBox_copyLine = new CommonControl.ConfirmationBox();
            this.confirmationBox_copyLine.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox_copyLine.Appearance.Options.UseBackColor = true;
            this.confirmationBox_copyLine.Location = new System.Drawing.Point(624, 100);
            this.confirmationBox_copyLine.Name = "confirmationBox1";
            this.confirmationBox_copyLine.Size = new System.Drawing.Size(350, 200);
            this.confirmationBox_copyLine.TabIndex = 29;
            this.Controls.Add(this.confirmationBox_copyLine);
            this.confirmationBox_copyLine.Visible = true;
            this.confirmationBox_copyLine.BringToFront();
            
        }

       

        private void initLineNOVec()
        {
            for (int i = 1; i <= 9; i++)
            {
                lineNOVec[i - 1] = "00" + i.ToString();
            }
            for (int i = 10; i <= 99; i++)
            {
                lineNOVec[i - 1] = "0" + i.ToString();
            }
            for (int i = 100; i <= 999; i++)
            {
                lineNOVec[i - 1] = i.ToString();
            }
        }

        private void lockUnlockButton(string lockOrUnlock)
        {
            if (lockOrUnlock == "lockbtn")
            {
                this.simpleButton_productionLineAddition.Enabled = false;
                this.simpleButton_productionLineDeletion.Enabled = false;
                this.simpleButton_lineNameModify.Enabled = false;
                this.simpleButton_productionLineCopy.Enabled = false;
            }
            else if (lockOrUnlock == "unlockbtn")
            {
                this.simpleButton_productionLineAddition.Enabled = true;
                this.simpleButton_productionLineDeletion.Enabled = true;
                this.simpleButton_lineNameModify.Enabled = true;
                this.simpleButton_productionLineCopy.Enabled = true;
            }
            else
                throw new ArgumentException();
        }

        //生成一个在表中未用的LineNO
        private string createLineNO()
        {
            string lNO = String.Empty;
            List<string> ll = new List<string>();
            for (int i = 0; i < Global.dtProductionLine.Rows.Count; i++)
            {
                ll.Add(Global.dtProductionLine.Rows[i]["LineNO"].ToString());
            }

            for (int i = 0; i < 999; i++)
            {
                if (ll.Contains(lineNOVec[i]) == false)
                {
                    lNO = lineNOVec[i];
                    break;
                }
            }
            return lNO;
        }

        private void initSideTileBarProductionLineAdditionDeletion()
        {
            this.sideTileBarControl_productionLineAdditionDeletion.overViewText = "产线";
            string totalProductionCount = Global.dtSideTileBar.Rows.Count.ToString();
            this.sideTileBarControl_productionLineAdditionDeletion._setNum("000", totalProductionCount);
        }

        private void refreshDtProductionLineSystemConfig()
        {
            Global._init_dtSideTileBarWorkState();
            Global.initDtProductionLineExists();
        }

        private void keepSelectRowWhenDataSourceRefresh()
        {
            if (selectRowDtProductionLineExists.Length == 1)
            {
                if (selectRowDtProductionLineExists[0] < this.tileView1.DataRowCount)
                    this.tileView1.FocusedRowHandle = selectRowDtProductionLineExists[0];     //在DataSource发生改变后，手动修改被选中的row
                else
                {
                    this.tileView1.FocusedRowHandle = 0;
                    selectRowDtProductionLineExists[0] = 0;
                }
            }
        }

        //记录选中的行
        private void gridControl_productionLineAdditionDeletion_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_productionLineAdditionDeletion.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRowDtProductionLineExists = this.tileView1.GetSelectedRows();
            }
            if (selectRowDtProductionLineExists.Length > 1)
            {
                MessageBox.Show("当前选中不止一行");
            }
        }

        /*********************************************添加产线*******************************************************/
        private void simpleButton_productionLineAddition_Click(object sender, EventArgs e)
        {
            lockUnlockButton("lockbtn");
            initStandardKeyboard("请输入产线名称");
            this.standardKeyboard1.Close_Click += new System.EventHandler(standardKeyboard1_addLine_checkOK);
        }

        private void standardKeyboard1_addLine_checkOK(object sender, EventArgs e)
        {
            if (this.standardKeyboard1.EnterNewValue == true)
            {
                if (this.standardKeyboard1.StringValue != "")
                {
                    inputLineName = this.standardKeyboard1.StringValue;
                    this.standardKeyboard1.StringValue = "";
                    this.standardKeyboard1.Dispose();
                }
                if (inputLineName != "")
                {
                    initConfirmationBox_addLine();
                    this.confirmationBox_addLine.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_addLine_ConfirmationBoxOKClicked);
                    this.confirmationBox_addLine.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_addLine_ConfirmationBoxCancelClicked);
                }
            }
        }

        private void confirmationBox_addLine_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            //this.confirmationBox_addLine.Dispose();

            MySqlParameter lineNO = new MySqlParameter("ln", MySqlDbType.VarChar, 20);
            lineNO.Value = createLineNO();
            MySqlParameter lineName = new MySqlParameter("lname", MySqlDbType.VarChar, 20);
            lineName.Value = inputLineName;
            inputLineName = "";
            MySqlParameter ifAffected = new MySqlParameter("ifRowAffected", MySqlDbType.Int32, 1);
            MySqlParameter[] paras = { lineNO, lineName, ifAffected };
            string cmdAddLine = "p_addLine";
            Global.mysqlHelper1._executeProcMySQL(cmdAddLine, paras, 2, 1);


            if (Convert.ToInt32(ifAffected.Value) == 1)
            {
                initInfoBox_successOrFail("添加成功！", 2000);

                Global.ifLineAdditionOrDeletion = true;
                refreshDtProductionLineSystemConfig();

                //重读device_config
                Global._init_dtDeviceConfig();
                //重读productionLine
                Global._init_dtProductionLine();
            }
            else
            {
                initInfoBox_successOrFail("添加失败！", 2000);
            }
            lockUnlockButton("unlockbtn");

        }

        private void confirmationBox_addLine_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            lockUnlockButton("unlockbtn");
            inputLineName = "";
        }

        /*********************************************删除产线*******************************************************/
        private void simpleButton_productionLineDeletion_Click(object sender, EventArgs e)
        {
            if (Global.dtProductionLineSystemConfig.Rows.Count != 0)
            {
                lockUnlockButton("lockbtn");
                DataRow drSelected = tileView1.GetDataRow(selectRowDtProductionLineExists[0]);    //获取的是grid绑定的表所有列，而不仅仅是显示出来的列
                initConfirmationBox_delLine();
                this.confirmationBox_delLine.titleConfirmationBox = "确认删除：  “" + Global._getProductionLineNameByTag(drSelected["LineNO"].ToString()) + "”?";
                this.confirmationBox_delLine.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_delLine_ConfirmationBoxOKClicked);
                this.confirmationBox_delLine.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_delLine_ConfirmationBoxCancelClicked);
            }
        }

        private void confirmationBox_delLine_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            if (Global.dtProductionLineSystemConfig.Rows.Count != 0)
            {
                //confirmationBox_delLine.Dispose();
                initConfirmationBox_delLine();
                this.confirmationBox_delLine.titleConfirmationBox = " 删除将无法恢复，确认删除？";
                this.confirmationBox_delLine.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_delLine_ConfirmationBoxOKDoubleCheckClicked);
                this.confirmationBox_delLine.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_delLine_ConfirmationBoxCancelDoubleCheckClicked);
            }
        }

        private void confirmationBox_delLine_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            lockUnlockButton("unlockbtn");
            //confirmationBox_delLine.Dispose();
        }

        private void confirmationBox_delLine_ConfirmationBoxOKDoubleCheckClicked(object sender, EventArgs e)
        {
            if (Global.dtProductionLineSystemConfig.Rows.Count != 0)
            {
                DataRow drSelected = this.tileView1.GetDataRow(selectRowDtProductionLineExists[0]);

                MySqlParameter lineNO = new MySqlParameter("ln", MySqlDbType.VarChar, 20);
                lineNO.Value = drSelected["LineNO"].ToString();
                MySqlParameter ifAffectedDelLine = new MySqlParameter("ifAffectedRowDelLine_", MySqlDbType.Int32, 1);
                MySqlParameter[] paras = { lineNO, ifAffectedDelLine };
                string cmdDeleteLine = "p_deleteLine";
                Global.mysqlHelper1._executeProcMySQL(cmdDeleteLine, paras, 1, 1);


                this.confirmationBox_delLine.Visible = false;

                if (Convert.ToInt32(ifAffectedDelLine.Value) == 1)
                {
                    initInfoBox_successOrFail("删除成功！", 2000);

                    Global.ifLineAdditionOrDeletion = true;
                    refreshDtProductionLineSystemConfig();

                    //只需重读当前页面用到的表，其他表，重启时会更新
                    //重读device_config
                    Global._init_dtDeviceConfig();
                    //重读productionLine
                    Global._init_dtProductionLine();
                    //重读device_info

                    //重读device_info_paranameandsuffix

                    //重读device_info_threshold

                    //重读faults_config

                    //重读faults_current

                    //重读faults_history
                }
                else
                {
                    initInfoBox_successOrFail("删除失败！", 2000);
                }
            }
        }

        private void confirmationBox_delLine_ConfirmationBoxCancelDoubleCheckClicked(object sender, EventArgs e)
        {
            lockUnlockButton("unlockbtn");
            confirmationBox_delLine.Dispose();
        }

        /*********************************************修改产线名*******************************************************/
        private void simpleButton_lineNameModify_Click(object sender, EventArgs e)
        {
            if (Global.dtProductionLineSystemConfig.Rows.Count != 0 && this.selectRowDtProductionLineExists.Length != 0)
            {
                lockUnlockButton("lockbtn");    
                DataRow drSelected = tileView1.GetDataRow(selectRowDtProductionLineExists[0]);    //获取的是grid绑定的表所有列，而不仅仅是显示出来的列
                initStandardKeyboard("确认修改产线：  “" + Global._getProductionLineNameByTag(drSelected["LineNO"].ToString()) + "”?");
                this.standardKeyboard1.Close_Click += new System.EventHandler(standardKeyboard1_modifyLineName_checkOK);
            }
        }

        private void standardKeyboard1_modifyLineName_checkOK(object sender, EventArgs e)
        {
            if (this.standardKeyboard1.EnterNewValue == true)
            {
                if (this.standardKeyboard1.StringValue != "")
                {
                    inputLineName = this.standardKeyboard1.StringValue;
                    this.standardKeyboard1.StringValue = "";
                    //this.standardKeyboard1.Visible = false;
                    this.standardKeyboard1.Dispose();
                }
                if (inputLineName != "")
                {
                    initConfirmationBox_modifyLineName();
                    this.confirmationBox_modifyLineName.titleConfirmationBox = "确认将产线名修改为：  “" + inputLineName + "”?";
                    this.confirmationBox_modifyLineName.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_modifyLineNameCheck_ConfirmationBoxOKClicked);
                    this.confirmationBox_modifyLineName.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_modifyLineNameCheck_ConfirmationBoxCancelClicked);
                }
            }
        }

        private void confirmationBox_modifyLineNameCheck_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            if (Global.dtProductionLineSystemConfig.Rows.Count != 0)
            {
                DataRow drSelected = this.tileView1.GetDataRow(selectRowDtProductionLineExists[0]);

                MySqlParameter lineNO = new MySqlParameter("ln", MySqlDbType.VarChar, 20);
                lineNO.Value = drSelected["LineNO"].ToString();
                MySqlParameter lineName = new MySqlParameter("lName", MySqlDbType.VarChar, 20);
                lineName.Value = inputLineName;
                inputLineName = "";
                MySqlParameter ifAffectedModifyLineName = new MySqlParameter("ifAffectedRowModifyLine_", MySqlDbType.Int32, 1);
                MySqlParameter[] paras = { lineNO, lineName, ifAffectedModifyLineName };
                string cmdModifyLineName = "p_modifyLineName";
                Global.mysqlHelper1._executeProcMySQL(cmdModifyLineName, paras, 2, 1);

                //confirmationBox_modifyLineName.Visible = false;

                if (Convert.ToInt32(ifAffectedModifyLineName.Value) == 1)
                {
                    initInfoBox_successOrFail("修改成功！", 2000);

                    Global.ifLineAdditionOrDeletion = true;
                    refreshDtProductionLineSystemConfig();
                    //重读productionLine
                    Global._init_dtProductionLine();
                }
                else
                {
                    initInfoBox_successOrFail("修改失败！", 2000);
                }
                lockUnlockButton("unlockbtn");
            }
        }

        private void confirmationBox_modifyLineNameCheck_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            lockUnlockButton("unlockbtn");
            //this.confirmationBox_modifyLineName.Dispose();
        }

        /*********************************************复制产线*******************************************************/
        private void simpleButton_productionLineCopy_Click(object sender, EventArgs e)
        {

            if (Global.dtProductionLineSystemConfig.Rows.Count != 0)
            {
                lockUnlockButton("lockbtn");
                DataRow drSelected = this.tileView1.GetDataRow(selectRowDtProductionLineExists[0]);
                initConfirmationBox_message("确认拷贝产线：  “" + Global._getProductionLineNameByTag(drSelected["LineNO"].ToString()) + "”?");
                this.confirmationBox_message.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_message_copyCheckOKClicked);
                this.confirmationBox_message.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_message_copyCheckCancelClicked);
            }
        }

        private void confirmationBox_message_copyCheckOKClicked(object sender, EventArgs e)
        {
            //this.confirmationBox_message.Dispose();
            initStandardKeyboard("请输入产线名");
            this.standardKeyboard1.Close_Click += new System.EventHandler(standardKeyboard1_copyLine_checkOK);
        }

        private void confirmationBox_message_copyCheckCancelClicked(object sender, EventArgs e)
        {
            lockUnlockButton("unlockbtn");
            //this.confirmationBox_message.Dispose();
        }

        //读取被选中产线的LineNO在相关表中的记录。替换LineName、LineNO将记录重新插入
        private void standardKeyboard1_copyLine_checkOK(object sender, EventArgs e)
        {
            if (this.standardKeyboard1.EnterNewValue == true)
            {
                if (this.standardKeyboard1.StringValue != "")
                {
                    inputLineName = this.standardKeyboard1.StringValue;
                    this.standardKeyboard1.StringValue = "";
                    this.standardKeyboard1.Dispose();
                }
                if (inputLineName != "")
                {
                    initConfiramtionBox_copyLine();
                    this.confirmationBox_copyLine.titleConfirmationBox = "确认产线名为：  “" + inputLineName + "”?";
                    this.confirmationBox_copyLine.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_copyLineCheckLineName_ConfirmationBoxOKClicked);
                    this.confirmationBox_copyLine.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_copyLineCheckLineName_ConfirmationBoxCancelClicked);
                }
            }
        }

        private void confirmationBox_copyLineCheckLineName_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            if (inputLineName != "")
            {
                this.confirmationBox_copyLine.Visible = false;

                DataRow drSelected = this.tileView1.GetDataRow(selectRowDtProductionLineExists[0]);
                string lineNOSelected = drSelected["LineNO"].ToString();
                string lineNODst = createLineNO();
                //productionline
                string cmdProductionLineCopy = "INSERT INTO productionline (LineNO, LineName) VALUES ('" + createLineNO() + "', '" + inputLineName + "');";
                inputLineName = "";
                bool flagProductionLineCopy = Global.mysqlHelper1._insertMySQL(cmdProductionLineCopy);

                //device_config
                bool flagDevice_flag = lineDtCopy("device_config", ref Global.dtDeviceConfig, lineNOSelected, lineNODst);

                //device_info
                string cmdDevice_info = "SELECT * FROM device_info;";
                DataTable dtDevice_info = new DataTable();
                Global.mysqlHelper1._queryTableMySQL(cmdDevice_info, ref dtDevice_info);
                bool flagDevice_infoCopy = lineDtCopy("device_info", ref dtDevice_info, lineNOSelected, lineNODst);

                //device_info_paranameandsuffix
                string cmdDevice_info_paranameandsuffix = "SELECT * FROM device_info_paranameandsuffix;";
                DataTable dtDevice_info_paranameandsuffix = new DataTable();
                Global.mysqlHelper1._queryTableMySQL(cmdDevice_info_paranameandsuffix, ref dtDevice_info_paranameandsuffix);
                bool flagDevice_info_paranameandsuffixCopy = lineDtCopy("device_info_paranameandsuffix", ref dtDevice_info_paranameandsuffix, lineNOSelected, lineNODst);

                //device_info_threshold
                string cmdDevice_info_threshold = "SELECT * FROM device_info_threshold;";
                DataTable dtDevice_info_threshold = new DataTable();
                Global.mysqlHelper1._queryTableMySQL(cmdDevice_info_threshold, ref dtDevice_info_threshold);
                bool flagDevice_info_threshold = lineDtCopy("device_info_threshold", ref dtDevice_info_threshold, lineNOSelected, lineNODst);

                //faults_config
                string cmdFaults_config = "SELECT * FROM faults_config;";
                DataTable dtFaults_config = new DataTable();
                Global.mysqlHelper1._queryTableMySQL(cmdFaults_config, ref dtFaults_config);
                bool flagFaults_config = lineDtCopy("faults_config", ref dtFaults_config, lineNOSelected, lineNODst);

                if (flagProductionLineCopy && flagDevice_flag && flagDevice_info_paranameandsuffixCopy && flagDevice_info_threshold && flagFaults_config)
                {
                    initInfoBox_successOrFail("产线复制成功！", 2000);
                    Global.ifLineAdditionOrDeletion = true;
                    refreshDtProductionLineSystemConfig();
                }
                else
                {
                    initInfoBox_successOrFail("产线复制失败！", 2000);
                }
                lockUnlockButton("unlockbtn");
            }
        }

        private void confirmationBox_copyLineCheckLineName_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            lockUnlockButton("unlockbtn");
            inputLineName = "";
        }

        //将表中指定lineNO的记录复制
        private bool lineDtCopy(string tableName, ref DataTable table, string srcLineNO, string dstLineNO)
        {
            string[] colNamesTable = Global.GetColumnsByDataTable(table);
            string cmdDtWithLineNOCopy = "INSERT INTO " + tableName + " (LineNO";
            for (int i = 2; i < colNamesTable.Length; i++)
            {
                cmdDtWithLineNOCopy += ", " + colNamesTable[i];
            }
            cmdDtWithLineNOCopy += ") SELECT '" + dstLineNO + "' AS LineNO";
            for (int i = 2; i < colNamesTable.Length; i++)
            {
                cmdDtWithLineNOCopy += ", " + colNamesTable[i];
            }
            cmdDtWithLineNOCopy += " FROM " + tableName + " WHERE LineNO='" + srcLineNO + "';";
            string cmdNoSrcLineNOInDtWithLineNO = "SELECT COUNT(*) FROM " + tableName + " WHERE LineNO='" + srcLineNO + "';";
            DataTable dtRowCount = new DataTable();
            Global.mysqlHelper1._queryTableMySQL(cmdNoSrcLineNOInDtWithLineNO, ref dtRowCount);
            if(dtRowCount.Rows.Count==1 && Convert.ToInt32(dtRowCount.Rows[0][0]) != 0)
            {
                return Global.mysqlHelper1._insertMySQL(cmdDtWithLineNOCopy) == true ? true : false;
            }
            else
            {
                return true;
            }
        }

    }
}
