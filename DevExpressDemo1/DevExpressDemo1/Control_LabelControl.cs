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
    public partial class Control_LabelControl : DevExpress.XtraEditors.XtraForm
    {
        public Control_LabelControl()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("w");
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("q");

        }
    }
}