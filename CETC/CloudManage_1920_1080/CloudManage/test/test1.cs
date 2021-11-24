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

namespace CloudManage.test
{
    public partial class test1 : DevExpress.XtraEditors.XtraForm
    {
        private CommonControl.NumberKeyboard numberKeyboard1;
        public test1()
        {
            InitializeComponent();

            numberKeyboard1 = new CommonControl.NumberKeyboard(0, 200);
            this.Controls.Add(this.numberKeyboard1);
            this.numberKeyboard1.Location = new System.Drawing.Point(324, 39);

        }
    }
}