using DevExpress.XtraCharts;
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

namespace CheckWeighterDataAnalysis.DataAnalysis
{
    public partial class TimeDomainAnalysis : DevExpress.XtraEditors.XtraUserControl
    {

        public TimeDomainAnalysis()
        {
            InitializeComponent();
            initTimeDomainAnalysis();
        }

        private void initTimeDomainAnalysis()
        {
            bindLineData();
        }

        private void bindLineData()
        {
            this.chartControl_line.Series[0].DataSource = StatusMonitor.StatusMonitor.dtLine;     
            this.chartControl_line.Series[0].ArgumentScaleType = ScaleType.Numerical;   
            this.chartControl_line.Series[0].ArgumentDataMember = "countDetection";       
            this.chartControl_line.Series[0].ValueScaleType = ScaleType.Numerical;  
            this.chartControl_line.Series[0].ValueDataMembers.AddRange(new string[] { "currentWeight" });
        }

    }
}
