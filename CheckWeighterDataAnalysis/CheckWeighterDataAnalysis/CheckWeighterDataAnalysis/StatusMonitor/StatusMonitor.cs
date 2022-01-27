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

namespace CheckWeighterDataAnalysis.StatusMonitor
{
    public partial class StatusMonitor : DevExpress.XtraEditors.XtraUserControl
    {
        private DataTable dtPie = new DataTable("tablePie");    //饼图数据源
        private DataTable dtLine = new DataTable("tableLine");  //折线图数据源
        private double lastOverWeght = 0.0D;
        private double lastUnderWeight = 0.0D;

        public StatusMonitor()
        {
            InitializeComponent();
            initStatusMonitor();
        }

        private void initStatusMonitor()
        {
            Global.curStatus.brand = "LG";
            Global.curStatus.countDetection = 0;
            Global.curStatus.countOverWeight = 0;
            Global.curStatus.countUnderWeight = 0;
            Global.curStatus.lastOverWeight = 0.0D;
            Global.curStatus.lastUnderWeight = 0.0D;
            Global.curStatus.maxWeightInHistory = 0.0D;
            Global.curStatus.minWeightInHistory = 20.0D;

            //updateLabels();
            //updateChartLineData();
            //updateChartPieData();

            initDataSource();
            bindLineData();
            bindPieData();
            labelControl_status.Parent = this.chartControl_line;
            labelControl_curWeightVal.Parent = this.chartControl_line;
        }

        private void initDataSource()
        {
            //添加一次称重数据
            if (dtLine.Columns.Count == 0)
            {
                dtLine.Columns.Add("countDetection", typeof(Int32));
                dtLine.Columns.Add("currentWeight", typeof(double));
            }

            if (dtPie.Columns.Count == 0)
            {
                dtPie.Columns.Add("index", typeof(Int32));
                dtPie.Columns.Add("countCur", typeof(Int32));
            }
        }

        private void bindLineData()
        {
            this.chartControl_line.Series[0].DataSource = dtLine;      //绑定Datatable
            this.chartControl_line.Series[0].ArgumentScaleType = ScaleType.Numerical;   //设定Argument的类型
            this.chartControl_line.Series[0].ArgumentDataMember = "countDetection";       //设定Argument的字段名
            this.chartControl_line.Series[0].ValueScaleType = ScaleType.Numerical;  //设定Value的类型
            this.chartControl_line.Series[0].ValueDataMembers.AddRange(new string[] { "currentWeight" });
        }

        private void bindPieData()
        {
            this.chartControl_pie.Series[0].DataSource = dtPie;
            this.chartControl_pie.Series[0].ArgumentScaleType = ScaleType.Numerical;
            this.chartControl_pie.Series[0].ArgumentDataMember = "index";
            this.chartControl_pie.Series[0].ValueScaleType = ScaleType.Numerical;
            this.chartControl_pie.Series[0].ValueDataMembers.AddRange(new string[] { "countCur" });
        }

        //刷新左侧标签显示
        private void updateLabels()
        {
            labelControl_brandVal.Text = Global.curStatus.brand;
            labelControl_curWeightVal.Text = Global.curStatus.curWeight.ToString() + "KG";
            labelControl_lastOverWeightVal.Text = Global.curStatus.lastOverWeight.ToString() + "KG";
            labelControl_underWeightVal.Text = Global.curStatus.lastUnderWeight.ToString() + "KG";
            labelControl_detectionCountVal.Text = Global.curStatus.countDetection.ToString();
            labelControl_overWeightCountVal.Text = Global.curStatus.countOverWeight.ToString();
            labelControl_underWeightCountVal.Text = Global.curStatus.countUnderWeight.ToString();
            labelControl_maxWeightInHistory.Text = Global.curStatus.maxWeightInHistory.ToString() + "KG";
            labelControl_minWeightInHistory.Text = Global.curStatus.minWeightInHistory.ToString() + "KG";
        }

        //初始化、刷新折线图数据源
        private void updateChartLineData()
        {
            DataRow drCurWeight = dtLine.NewRow();
            drCurWeight["countDetection"] = Global.curStatus.countDetection;
            drCurWeight["currentWeight"] = Global.curStatus.curWeight;
            dtLine.Rows.Add(drCurWeight);

            //刷新最大值、最小值
            if (Global.curStatus.curWeight > Global.curStatus.maxWeightInHistory)
            {
                Global.curStatus.maxWeightInHistory = Global.curStatus.curWeight;
            }
            else if (Global.curStatus.curWeight < Global.curStatus.minWeightInHistory)
            {
                Global.curStatus.minWeightInHistory = Global.curStatus.curWeight;
            }

            //超重、欠重
            if(Global.curStatus.flagOverWeightOrUnderWeight == "H-")
            {
                Global.curStatus.countOverWeight++;
                labelControl_status.Text = "NG";
                this.labelControl_status.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
                Global.curStatus.lastOverWeight = lastOverWeght;
                lastOverWeght = Global.curStatus.curWeight;
            }
            else if(Global.curStatus.flagOverWeightOrUnderWeight == "L-")
            {
                Global.curStatus.countUnderWeight++;
                labelControl_status.Text = "NG";
                this.labelControl_status.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
                Global.curStatus.lastUnderWeight = lastUnderWeight;
                lastUnderWeight = Global.curStatus.curWeight;
            }
            else if(Global.curStatus.flagOverWeightOrUnderWeight == "p-")
            {
                labelControl_status.Text = "OK";
                this.labelControl_status.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(152)))), ((int)(((byte)(83)))));
            }
        }

        //Pie图绑定数值，自动显示占比
        private void updateChartPieData()
        {
            if (dtPie.Rows.Count == 0)
            {
                DataRow drCountNormal = dtPie.NewRow();
                drCountNormal["index"] = 0;
                drCountNormal["countCur"] = Global.curStatus.countDetection - Global.curStatus.countOverWeight - Global.curStatus.countUnderWeight;
                dtPie.Rows.Add(drCountNormal);

                DataRow drCountOverWeight = dtPie.NewRow();
                drCountOverWeight["index"] = 1;
                drCountOverWeight["countCur"] = Global.curStatus.countOverWeight;
                dtPie.Rows.Add(drCountOverWeight);

                DataRow drCountUnderWeight = dtPie.NewRow();
                drCountUnderWeight["index"] = 2;
                drCountUnderWeight["countCur"] = Global.curStatus.countUnderWeight;
                dtPie.Rows.Add(drCountUnderWeight);
            }
            else
            {
                dtPie.Rows[0]["countCur"] = Global.curStatus.countDetection - Global.curStatus.countOverWeight - Global.curStatus.countUnderWeight;
                dtPie.Rows[1]["countCur"] = Global.curStatus.countOverWeight;
                dtPie.Rows[2]["countCur"] = Global.curStatus.countUnderWeight;
            }

        }

        private void labelControl_curWeightVal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("export excel");
            this.chartControl_line.ExportToXlsx(@"C:\Users\eivision\Desktop\a.xlsx");
        }

        //刷新数据源
        private void timer_detectOnce_Tick(object sender, EventArgs e)
        {
            Global.curStatus.countDetection++;
            Random rnd = new Random();
            int cw = rnd.Next(5, 20);

            Global.curStatus.curWeight = cw;
            if (Global.curStatus.curWeight > 18)
                Global.curStatus.flagOverWeightOrUnderWeight = "H-";
            else if (Global.curStatus.curWeight < 6)
                Global.curStatus.flagOverWeightOrUnderWeight = "L-";
            else
                Global.curStatus.flagOverWeightOrUnderWeight = "p-";
            Global.curStatus.brand = "LG";

            updateLabels();
            updateChartLineData();
            updateChartPieData();
        }



    }
}
