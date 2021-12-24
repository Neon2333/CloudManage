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

namespace CloudManage.CommonControl
{
    public partial class InformationBox : DevExpress.XtraEditors.XtraUserControl
    {
        public InformationBox()
        {
            InitializeComponent();
            this.timer_disappear.Enabled = true;
        }

        public string infoTitle
        {
            set
            {
                this.labelControl_infoTitle.Text = "      " + value;
            }
            get
            {
                return this.labelControl_infoTitle.Text.Substring(6);
            }
        }

        public int timeDisappear
        {
            set
            {
                this.timer_disappear.Interval = value;
            }
            get
            {
                return this.timer_disappear.Interval;
            }
        }

        private void simpleButton_infoOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer_disappear_Tick(object sender, EventArgs e)
        {
            this.timer_disappear.Enabled = false;
            this.Dispose();
        }
    }
}
