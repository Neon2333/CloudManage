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
        //状态参数
        private struct Status
        {
            string brand;               //品牌
            double curWeight;           //当前重量
            string OK;                  //结果
            double lastOverWeight;      //上次超重
            double lastUnderWeight;     //上次欠重
            double countDetection;      //检测数量
            double countOverWeight;     //超重数量
            double countUnderWeight;    //欠重数量
            double maxWeight;           //最大值
            double minWeight;           //最小值
        };

        public StatusMonitor()
        {
            InitializeComponent();
            bindData();
            labelControl_OK.Parent = this.chartControl_line;
            labelControl_curWeightVal.Parent = this.chartControl_line;
        }


        private void bindData()
        {
            //// Create a line series, bind it to data and add to the chart.
            //Series series = new Series("", ViewType.Line);
            //series.DataSource = CreateChartData(500);
            //this.chartControl_line.Series.Add(series);

            //series.ArgumentScaleType = ScaleType.Numerical;
            //series.ArgumentDataMember = "Argument";
            //series.ValueScaleType = ScaleType.Numerical;
            //series.ValueDataMembers.AddRange(new string[] { "Value" });
            
            //// 显示小圆点
            //LineSeriesView view = (LineSeriesView)series.View;
            ////view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            ////显示每个小圆点的数值
            ////series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //series.Label.ResolveOverlappingMode = ResolveOverlappingMode.HideOverlapped;
            //series.Label.TextPattern = "{V:#.00}";

            //// Create a chart title.
            //ChartTitle chartTitle = new ChartTitle();
            //chartTitle.Text = "当前重量变化曲线";
            //chartControl_line.Titles.Add(chartTitle);

            //// Customize axes.
            //XYDiagram diagram = chartControl_line.Diagram as XYDiagram;
            //diagram.AxisX.WholeRange.SetMinMaxValues(0, 100);
            //diagram.AxisX.WholeRange.SideMarginsValue = 1;          //X轴的原点从-1处开始
            //diagram.AxisY.WholeRange.AlwaysShowZeroLevel = false;
            //diagram.AxisY.WholeRange.SetMinMaxValues(0, 20);

            //diagram.EnableAxisXScrolling = true;
            //diagram.EnableAxisYScrolling = true;
            //diagram.EnableAxisXZooming = true;
            ////X轴为时间的设置
            ////diagram.AxisX.Label.TextPattern = "{A:MMM, d (HH:mm)}";
            ////diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Hour;
            ////diagram.AxisX.DateTimeScaleOptions.GridSpacing = 1;

            ////((XYDiagram)chartControl_line.Diagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False;
            ////chartControl_line.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
        }

        private DataTable CreateChartData(int rowCount)
        {
            // Create an empty table.
            DataTable table = new DataTable("Table1");

            // Add two columns to the table.
            table.Columns.Add("Argument", typeof(Int32));
            table.Columns.Add("Value", typeof(Int32));

            // Add data rows to the table.
            Random rnd = new Random();
            DataRow row = null;
            for (int i = 0; i < rowCount; i++)
            {
                row = table.NewRow();
                row["Argument"] = i;
                row["Value"] = rnd.Next(15);
                table.Rows.Add(row);
            }
            return table;
        }


    }
}
