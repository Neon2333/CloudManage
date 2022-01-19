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

namespace DevExpressDemo1
{
    public partial class Control_CheckedListBoxControl : DevExpress.XtraEditors.XtraForm
    {
        public Control_CheckedListBoxControl()
        {
            InitializeComponent();
        }

        private void Control_CheckedListBoxControl_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“_222DataSet.employee”中。您可以根据需要移动或删除它。
            this.employeeTableAdapter.Fill(this._222DataSet.employee);

        }
    }
}