using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DevExpressDemo1
{
    public partial class Control_RadioGroup : DevExpress.XtraEditors.XtraForm
    {
        public Control_RadioGroup()
        {
            InitializeComponent();
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.radioGroup1.EditValue.ToString());
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("selected item changed..");
        }
    }
}