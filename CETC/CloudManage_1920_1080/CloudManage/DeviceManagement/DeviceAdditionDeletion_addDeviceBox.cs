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

        public string colLeftFiledName
        {
            set
            {
                this.tileViewColumn_left.FieldName = value;
            }
        }

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

        //当前选中行的index
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

        //当前选中行
        public DataRow currentSelectedRow
        {
            get
            {
                return this.tileView_addDeviceBox.GetDataRow(this.tileView_addDeviceBox.FocusedRowHandle);
            }
        }

        public delegate void SimpleButtonOKClickHanlder(object sender, EventArgs e);
        public event SimpleButtonOKClickHanlder AddDeviceBoxOKClicked;
        private void simpleButton_addDeviceOK_Click(object sender, EventArgs e)
        {
            AddDeviceBoxOKClicked(sender, new EventArgs());
            this.Dispose();
        }

        public delegate void SimpleButtonCancelClickHanlder(object sender, EventArgs e);
        public event SimpleButtonOKClickHanlder AddDeviceBoxCancelClicked;
        private void simpleButton_addDeviceCancel_Click(object sender, EventArgs e)
        {
            AddDeviceBoxCancelClicked(sender, new EventArgs());
            this.Dispose();
        }

    }
}
