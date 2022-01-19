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
    public partial class Control_TimeEdit : DevExpress.XtraEditors.XtraForm
    {
        DateTime NYDate = new DateTime(2021, 3, 8, 0, 0, 0, 0);
        public Control_TimeEdit()
        {
            InitializeComponent();

            this.timeEdit4.Time = new DateTime(2021, 7, 13, 10, 30, 25, 670);
            this.timeEdit5.Time = new DateTime(2021, 7, 13, 10, 30, 25, 670);

            timeSpanEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            timeSpanEdit2.Properties.DisplayFormat.FormatString = "{0:dd} days, {0:hh} hours, {0:mm} minutes and {0:ss} seconds";
            timeSpanEdit2.Properties.ReadOnly = false;
            timeSpanEdit2.Properties.Mask.EditMask = "dd:HH:mm:ss";
            RefreshTimer();
        }

        private void RefreshTimer()
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan timeToNY = currentDate - NYDate;
            timeSpanEdit1.EditValue = timeToNY;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            RefreshTimer();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            labelControl1.Text = timeSpanEdit1.Properties.GetDisplayText(timeSpanEdit1.EditValue) + " left for the New Year!";

        }
    }
}