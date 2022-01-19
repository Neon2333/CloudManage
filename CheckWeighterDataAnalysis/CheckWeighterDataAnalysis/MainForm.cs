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

namespace CheckWeighterDataAnalysis
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        DateTime now = new DateTime();

        StatusMonitor.StatusMonitor statusMonitor1;

        public MainForm()
        {
            InitializeComponent();
            _initMainForm();
        }

        private void timer_datetime_Tick(object sender, EventArgs e)
        {
            now = DateTime.Now;
            this.labelControl_datetime.Text = now.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        private void _initMainForm()
        {
            statusMonitor1 = new StatusMonitor.StatusMonitor();
            this.statusMonitor1.Location = new System.Drawing.Point(0,0);
            this.statusMonitor1.Name = "statusMonitor2";
            this.statusMonitor1.Size = new System.Drawing.Size(1024, 617);
            this.statusMonitor1.TabIndex = 0;
            this.navigationPage_statusMonitor.Controls.Add(statusMonitor1);

        }



    }
}