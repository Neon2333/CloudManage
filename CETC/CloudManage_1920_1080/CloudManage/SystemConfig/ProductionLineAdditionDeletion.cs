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
        private CommonControl.ConfirmationBox confirmationBox_addLine;

        public ProductionLineAdditionDeletion()
        {
            InitializeComponent();
            initDeviceAdditionDeletion();
        }

        void initDeviceAdditionDeletion()
        {
            Global.initDtProductionLineExists();
            initSideTileBarProductionLineAdditionDeletion();
            this.gridControl_productionLineAdditionDeletion.DataSource = Global.dtProductionLineSystemConfig;
            
            if (((DataTable)this.gridControl_productionLineAdditionDeletion.DataSource).Rows.Count > 0)
            {
                this.tileView1.FocusedRowHandle = selectRowDtProductionLineExists[0]; //默认选中第一行
            }
        }

        private void initSideTileBarProductionLineAdditionDeletion()
        {
            this.sideTileBarControl_productionLineAdditionDeletion.overViewText = "产线";
            string totalProductionCount = String.Empty;
            if (Global.dtProductionCount.Rows.Count == 1)
            {
                totalProductionCount = Global.dtProductionCount.Rows[0]["totalProductionCount"].ToString();
            }
            this.sideTileBarControl_productionLineAdditionDeletion._setNum("000", totalProductionCount);
        }

        //刷新导航目录
        void _refreshLabelDir()
        {
            
        }

        private void refreshDtProductionLineSystemConfig()
        {
            string cmdInitDtProductionLineExists = "SELECT * FROM v_productionline_system_config;";
            Global.mysqlHelper1._queryTableMySQL(cmdInitDtProductionLineExists, ref Global.dtProductionLineSystemConfig);
        }

        private void gridControl_productionLineAdditionDeletion_Click(object sender, EventArgs e)
        {
            //记录选中的行
            if (((DataTable)this.gridControl_productionLineAdditionDeletion.DataSource).Rows.Count > 0)   //防止查询出来的结果为空表，出现越界
            {
                selectRowDtProductionLineExists = this.tileView1.GetSelectedRows();
            }
        }

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

        private void simpleButton_productionLineAddition_Click(object sender, EventArgs e)
        {

        }



    }
}
