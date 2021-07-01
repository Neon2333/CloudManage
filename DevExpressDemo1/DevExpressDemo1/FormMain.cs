using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DevExpressDemo1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemSimpleButton_Click(object sender, EventArgs e)
        {
            FormSimpleButton formSimpleButton = new FormSimpleButton();
            formSimpleButton.Show();
        }
    }
}
