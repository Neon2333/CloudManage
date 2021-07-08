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
using DevExpress.XtraEditors.Repository;
namespace DevExpressDemo1
{
    public partial class Control_TextEdit : DevExpress.XtraEditors.XtraForm
    {
        public Control_TextEdit()
        {
            InitializeComponent();
        }

        private void textEdit1_MouseClick(object sender, MouseEventArgs e)
        {
            //string str = textEdit1.SelectedText;
            //MessageBox.Show(str);
            textEdit1.SelectionStart = 1;
            textEdit1.SelectionLength = 3;
        }
    }
}
