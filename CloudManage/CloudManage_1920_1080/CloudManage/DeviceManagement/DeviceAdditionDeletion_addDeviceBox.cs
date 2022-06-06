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
    public partial class DeviceAdditionDeletion_addDeviceBox : DevExpress.XtraEditors.XtraUserControl
    {
        public DeviceAdditionDeletion_addDeviceBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            get
            {
                return this.labelControl_addDeviceBoxTitle.Text;
            }
            set
            {
                this.labelControl_addDeviceBoxTitle.Text = value;
            }
        }

        /// <summary>
        /// 字段1
        /// </summary>
        public string gridLabelLeftText
        {
            get
            {
                return this.labelControl_left.Text;
            }
            set
            {
                this.labelControl_left.Text = value;
            }
        }

        /// <summary>
        /// 字段2
        /// </summary>
        public string gridLabelRightText
        {
            get
            {
                return this.labelControl_right.Text;
            }
            set
            {
                this.labelControl_right.Text = value;
            }
        }

        /// <summary>
        /// 数据源
        /// </summary>
        public DataTable dataSource
        {
            get
            {
                return (DataTable)this.gridControl_addDeviceBox.DataSource;
            }
            set
            {
                this.gridControl_addDeviceBox.DataSource = value;
            }
        }

        /// <summary>
        /// 数据源字段1名称
        /// </summary>
        public string colLeftFiledName
        {
            set
            {
                this.tileViewColumn_left.FieldName = value;
            }
        }

        /// <summary>
        /// 数据源字段2名称
        /// </summary>
        public string colRightFiledName
        {
            set
            {
                this.tileViewColumn_right.FieldName = value;
            }
        }

        public string colLeftCaption
        {
            get
            {
                return this.tileViewColumn_left.Caption;
            }
            set
            {
                this.tileViewColumn_left.Caption = value;
            }
        }

        public string colRightCaption
        {
            get
            {
                return this.tileViewColumn_right.Caption;
            }
            set
            {
                this.tileViewColumn_right.Caption = value;
            }
        }

        /// <summary>
        /// 当前选中行的index
        /// </summary>
        public int currentFocusRowHandler
        {
            get
            {
                if(((DataTable)this.gridControl_addDeviceBox.DataSource).Rows.Count > 0)
                {
                    int[] indexOfSelectedRows = this.tileView_addDeviceBox.GetSelectedRows();
                    if (indexOfSelectedRows.Length > 0)
                        return indexOfSelectedRows[0];
                    else
                        return -1;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                this.tileView_addDeviceBox.FocusedRowHandle = value;
            }
        }

        /// <summary>
        /// 获取当前选中行
        /// </summary>
        public DataRow currentSelectedRow
        {
            get
            {
                return this.tileView_addDeviceBox.GetDataRow(this.tileView_addDeviceBox.FocusedRowHandle);
            }
        }

        public delegate void SimpleButtonOKClickHanlder(object sender, EventArgs e);
        public event SimpleButtonOKClickHanlder AddDeviceBoxOKClicked;
        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_addDeviceOK_Click(object sender, EventArgs e)
        {
            AddDeviceBoxOKClicked(sender, new EventArgs());
            this.Dispose();
        }

        public delegate void SimpleButtonCancelClickHanlder(object sender, EventArgs e);
        public event SimpleButtonOKClickHanlder AddDeviceBoxCancelClicked;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_addDeviceCancel_Click(object sender, EventArgs e)
        {
            AddDeviceBoxCancelClicked(sender, new EventArgs());
            this.Dispose();
        }

    }
}
