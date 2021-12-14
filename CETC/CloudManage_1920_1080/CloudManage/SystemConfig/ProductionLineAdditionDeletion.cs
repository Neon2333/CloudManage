using DevExpress.XtraEditors;
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
        private CommonControl.ConfirmationBox confirmationBox_delLine;
        private CommonControl.ConfirmationBox confirmationBox_inputLineName;
        private CommonControl.ConfirmationBox confirmationBox_addLine;
        string inputLineName = String.Empty;
        string[] lineNOVec = new string[999];   //暂存所有可能的LineNO

        public ProductionLineAdditionDeletion()
        {
            InitializeComponent();
            initDeviceAdditionDeletion();
        }

        void initDeviceAdditionDeletion()
        {
            initLineNOVec();
            Global.initDtProductionLineExists();
            initSideTileBarProductionLineAdditionDeletion();
            this.gridControl_productionLineAdditionDeletion.DataSource = Global.dtProductionLineSystemConfig;
            dtucTextBoxEx1.HandInputExePath = "D:\\WorkSpace\\DevExpressDemo\\CETC\\HandInput\\handinput.exe";

            if (((DataTable)this.gridControl_productionLineAdditionDeletion.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRowDtProductionLineExists[0]; //默认选中第一行
            }
        }
        
        private void initLineNOVec()
        {
            for(int i = 1; i <= 9; i++)
            {
                lineNOVec[i - 1] = "00" + i.ToString();
            }
            for(int i = 10; i <= 99; i++)
            {
                lineNOVec[i - 1] = "0" + i.ToString();
            }
            for(int i = 100; i <= 999; i++)
            {
                lineNOVec[i - 1] = i.ToString();
            }
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

        private void gridControl_productionLineAdditionDeletion_Click(object sender, EventArgs e)
        {
            //记录选中的行
            if (((DataTable)this.gridControl_productionLineAdditionDeletion.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRowDtProductionLineExists = this.tileView1.GetSelectedRows();
            }
        }

        /*********************************************删除产线*******************************************************/
        private void simpleButton_productionLineDeletion_Click(object sender, EventArgs e)
        {
            if (Global.dtDeviceCanDeleteEachLine.Rows.Count != 0)
            {
                //弹出确认框
                this.confirmationBox_delLine = new CommonControl.ConfirmationBox();
                this.confirmationBox_delLine.Appearance.BackColor = System.Drawing.Color.White;
                this.confirmationBox_delLine.Appearance.Options.UseBackColor = true;
                this.confirmationBox_delLine.Location = new System.Drawing.Point(627, 169);
                this.confirmationBox_delLine.Name = "confirmationBox1";
                this.confirmationBox_delLine.Size = new System.Drawing.Size(350, 200);
                this.confirmationBox_delLine.TabIndex = 29;
                DataRow drSelected = tileView1.GetDataRow(selectRowDtProductionLineExists[0]);    //获取的是grid绑定的表所有列，而不仅仅是显示出来的列
                this.confirmationBox_delLine.titleConfirmationBox = "确认删除  " + Global._getProductionLineNameByTag(drSelected["LineNO"].ToString()) + "?";
                this.confirmationBox_delLine.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_delLine_ConfirmationBoxOKClicked);
                this.confirmationBox_delLine.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_delLine_ConfirmationBoxCancelClicked);
                this.Controls.Add(this.confirmationBox_delLine);
                this.confirmationBox_delLine.Visible = true;
                this.confirmationBox_delLine.BringToFront();
            }
        }

        private void confirmationBox_delLine_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            if (Global.dtProductionLineSystemConfig.Rows.Count != 0)
            {
                this.confirmationBox_delLine.titleConfirmationBox = " 删除将无法恢复，确认删除？";
                this.confirmationBox_delLine.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_delLine_ConfirmationBoxOKDoubleCheckClicked);
                this.confirmationBox_delLine.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_delLine_ConfirmationBoxCancelDoubleCheckClicked);
            }
        }

        private void confirmationBox_delLine_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            this.confirmationBox_delLine.Visible = false;
        }

        private void confirmationBox_delLine_ConfirmationBoxOKDoubleCheckClicked(object sender, EventArgs e)
        {
            DataRow drSelected = this.tileView1.GetDataRow(selectRowDtProductionLineExists[0]);

            MySqlParameter lineNO = new MySqlParameter("ln", MySqlDbType.VarChar, 20);
            lineNO.Value = drSelected["LineNO"].ToString();
            MySqlParameter ifAffected = new MySqlParameter("ifRowAffected", MySqlDbType.Int32, 1);
            MySqlParameter[] paras = { lineNO, ifAffected };
            string cmdDeleteLine = "p_deleteLine";
            Global.mysqlHelper1._executeProcMySQL(cmdDeleteLine, paras, 1, 1);

            this.confirmationBox_delLine.Visible = false;

            if (Convert.ToInt32(ifAffected.Value) == 1)
            {
                MessageBox.Show("删除成功");
                Global.ifLineAdditionOrDeletion = true;
                refreshDtProductionLineSystemConfig();

            }
            else if (Convert.ToInt32(ifAffected.Value) == 0)
            {
                MessageBox.Show("删除失败");
            }
        }

        private void confirmationBox_delLine_ConfirmationBoxCancelDoubleCheckClicked(object sender, EventArgs e)
        {
            this.confirmationBox_delLine.Visible = false;
        }

        /*********************************************增加产线*******************************************************/
        private void simpleButton_productionLineAddition_Click(object sender, EventArgs e)
        {
            this.confirmationBox_inputLineName = new CommonControl.ConfirmationBox();
            this.confirmationBox_inputLineName.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox_inputLineName.Appearance.Options.UseBackColor = true;
            this.confirmationBox_inputLineName.Location = new System.Drawing.Point(627, 169);
            this.confirmationBox_inputLineName.Name = "confirmationBox1";
            this.confirmationBox_inputLineName.Size = new System.Drawing.Size(350, 200);
            this.confirmationBox_inputLineName.TabIndex = 29;
            DataRow drSelected = tileView1.GetDataRow(selectRowDtProductionLineExists[0]);    //获取的是grid绑定的表所有列，而不仅仅是显示出来的列
            this.confirmationBox_inputLineName.titleConfirmationBox = "请输入产线名称";
            this.confirmationBox_inputLineName.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_inputLineName_ConfirmationBoxOKClicked);
            this.confirmationBox_inputLineName.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_inputLineName_ConfirmationBoxCancelClicked);
            this.Controls.Add(this.confirmationBox_inputLineName);
            this.confirmationBox_inputLineName.Visible = true;
            this.confirmationBox_inputLineName.BringToFront();

            this.dtucTextBoxEx1.Visible = true;
        }

        private void confirmationBox_inputLineName_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            if (this.dtucTextBoxEx1.InputText!="")
                inputLineName = this.dtucTextBoxEx1.InputText;
            this.dtucTextBoxEx1.ResetText();
            if (inputLineName != "")
            {
                this.dtucTextBoxEx1.Visible = false;
                this.confirmationBox_inputLineName.Visible = false;

                this.confirmationBox_addLine = new CommonControl.ConfirmationBox();
                this.confirmationBox_addLine.Appearance.BackColor = System.Drawing.Color.White;
                this.confirmationBox_addLine.Appearance.Options.UseBackColor = true;
                this.confirmationBox_addLine.Location = new System.Drawing.Point(627, 169);
                this.confirmationBox_addLine.Name = "confirmationBox1";
                this.confirmationBox_addLine.Size = new System.Drawing.Size(350, 200);
                this.confirmationBox_addLine.TabIndex = 29;
                this.confirmationBox_addLine.titleConfirmationBox = "确认添加产线   " + inputLineName + "?";
                this.confirmationBox_addLine.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_addLine_ConfirmationBoxOKClicked);
                this.confirmationBox_addLine.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_addLine_ConfirmationBoxCancelClicked);
                this.Controls.Add(this.confirmationBox_addLine);
                this.confirmationBox_addLine.Visible = true;
                this.confirmationBox_addLine.BringToFront();
            }
        }

        private void confirmationBox_inputLineName_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            this.dtucTextBoxEx1.ResetText();
            this.dtucTextBoxEx1.Visible = false;
            this.confirmationBox_inputLineName.Visible = false;
        }

        private void confirmationBox_addLine_ConfirmationBoxOKClicked(object sender, EventArgs e)
        {
            string lNO = String.Empty;
            List<string> ll = new List<string>();
            for (int i = 0; i < Global.dtProductionLine.Rows.Count; i++)
            {
                ll.Add(Global.dtProductionLine.Rows[i]["LineNO"].ToString());
            }

            for(int i = 0; i < 999; i++)
            {
                if (ll.Contains(lineNOVec[i]) == false)
                {
                    lNO = lineNOVec[i];
                    break;
                }
            }

            MySqlParameter lineNO = new MySqlParameter("ln", MySqlDbType.VarChar, 20);
            lineNO.Value = lNO;
            MySqlParameter lineName = new MySqlParameter("lname", MySqlDbType.VarChar, 20);
            lineName.Value = this.dtucTextBoxEx1.InputText;
            MySqlParameter ifAffected = new MySqlParameter("ifRowAffected", MySqlDbType.Int32, 1);
            MySqlParameter[] paras = { lineNO, lineName, ifAffected };
            string cmdAddLine = "p_addLine";
            Global.mysqlHelper1._executeProcMySQL(cmdAddLine, paras, 2, 1);

            this.confirmationBox_addLine.Visible = false;

            if (Convert.ToInt32(ifAffected.Value) == 1)
            {
                MessageBox.Show("添加成功");
                Global.ifLineAdditionOrDeletion = true;
                refreshDtProductionLineSystemConfig();
            }
            else if (Convert.ToInt32(ifAffected.Value) == 0)
            {
                MessageBox.Show("添加失败");
            }
        }

        private void confirmationBox_addLine_ConfirmationBoxCancelClicked(object sender, EventArgs e)
        {
            this.confirmationBox_addLine.Visible = false;
        }


    }
}
