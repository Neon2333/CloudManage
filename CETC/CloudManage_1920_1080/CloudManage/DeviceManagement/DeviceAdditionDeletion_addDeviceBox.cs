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

        public string titleAddDeviceBox
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

        //当前选中行的index
        public int currentFocusRowHandler
        {
            get
            {
                if(((DataTable)this.gridControl_addDeviceBox.DataSource).Rows.Count > 0)
                {
                    return this.tileView_addDeviceBox.GetSelectedRows()[0];
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

        public delegate void SimpleButtonOKClickHanlder(object sender, EventArgs e);
        public event SimpleButtonOKClickHanlder AddDeviceBoxOKClicked;
        private void simpleButton_addDeviceOK_Click(object sender, EventArgs e)
        {
            AddDeviceBoxOKClicked(sender, new EventArgs());

        }

        public delegate void SimpleButtonCancelClickHanlder(object sender, EventArgs e);
        public event SimpleButtonOKClickHanlder AddDeviceBoxCancelClicked;
        private void simpleButton_addDeviceCancel_Click(object sender, EventArgs e)
        {
            AddDeviceBoxCancelClicked(sender, new EventArgs());
        }

    }
}
