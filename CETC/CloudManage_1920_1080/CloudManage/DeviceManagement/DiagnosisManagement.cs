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
    public partial class DiagnosisManagement : DevExpress.XtraEditors.XtraUserControl
    {
        private int[] selectRow = { -1 };
        struct faultsIndexAndStatus
        {
            public int rowHandle;
            public string faultStatus;
        };
        List<faultsIndexAndStatus> faultsStorage = new List<faultsIndexAndStatus>();    //暂存被修改的故障设置

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

        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

        }

        private void sideTileBarControlWithSub_diagnosisManagement_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            _refreshLabelDir();

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

        private void tileView1_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            selectRow = this.tileView1.GetSelectedRows();   //记录选中的行
            DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);
            if (selectRow.Length == 1)
            {
                if (drTemp["FaultEnable"].ToString() == "使能")
                {
                    this.simpleButton_statusChange.Appearance.BackColor = Color.Green;
                }
                else if(drTemp["FaultEnable"].ToString() == "禁止")
                {
                    this.simpleButton_statusChange.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void simpleButton_statusChange_Click(object sender, EventArgs e)
        {
            if (Global.dtFaultsConfig.Rows.Count > 0 && selectRow.Length == 1)
            {
                DataRow drTemp = this.tileView1.GetDataRow(selectRow[0]);
                if (drTemp != null) //避免未选中行就点击按钮
                {
                    if (drTemp["FaultEnable"].ToString() == "使能")
                    {
                        faultsIndexAndStatus fTemp = new faultsIndexAndStatus();
                        fTemp.rowHandle = selectRow[0];
                        fTemp.faultStatus = drTemp["FaultEnable"].ToString();
                        faultsStorage.Add(fTemp);   //暂存当前被改变的行。因为可能一次改变多行，然后再点保存/取消，所以用list存

                        Global.dtFaultsConfig.Rows[selectRow[0]]["FaultEnable"] = "禁止"; //修改dt中存储的状态
                        this.simpleButton_statusChange.Appearance.BackColor = Color.Red;
                    }
                    else
                    {
                        faultsIndexAndStatus fTemp = new faultsIndexAndStatus();
                        fTemp.rowHandle = selectRow[0];
                        fTemp.faultStatus = drTemp["FaultEnable"].ToString();
                        faultsStorage.Add(fTemp);

                        Global.dtFaultsConfig.Rows[selectRow[0]]["FaultEnable"] = "使能";
                        this.simpleButton_statusChange.Appearance.BackColor = Color.Green;
                    }
                }
                else if(selectRow[0] == -1)
                {
                    MessageBox.Show("未选中故障");
                }
                
            }
        }

        private void simpleButton_saveStatusChange_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton_cancelStatusChange_Click(object sender, EventArgs e)
        {
            foreach(var fTemp in faultsStorage)
            {
                Global.dtFaultsConfig.Rows[fTemp.rowHandle]["FaultEnable"] = fTemp.faultStatus;
            }
            faultsStorage.Clear();  //清空记录的被改变的行
        }
    }
}
