using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckWeighterDataAnalysis.StatusMonitor
{
    public partial class StatusMonitor : DevExpress.XtraEditors.XtraUserControl
    {
        public static DataTable dtLine = new DataTable("tableLine");  //折线图数据源，只显示200个点
        private DataTable dtPie = new DataTable("tablePie");    //饼图数据源，只要不更换brand就一直累计
        private DataTable dtPoint = new DataTable("tablePoint");//散点图数据源，只要不更换brand就一直累计
        private double lastOverWeght = 0.0D;
        private double lastUnderWeight = 0.0D;

        Dictionary<int, int> weightAndIndexGramDtPoint = new Dictionary<int, int>();
        private int indexDtPoint = 0;   //dtPoint中存的点的个数（行数，重量不同才会增加一行）
        //散点图横轴坐标边缘
        private Int32[] minXRangePoint = { 0, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000, 13000, 14000, 15000 };
        private Int32[] maxXRangePoint = { 0, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000, 13000, 14000, 15000 };
        private Int32 minXPoint = 0;    //横轴范围左侧
        private Int32 maxXPoint = 0;   //横轴范围右侧

        //散点图横轴分辨率档位
        private Int32[] intervalAxisXPoint = { 10, 20, 50, 100};     //散点图横轴分辨率
        private Int32 gearIntervalAxisXPoint = 0;                    //散点图横轴档位


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

            setAxisXMinMaxPoint(8, 12);  //设定散点图横轴区间范围
            setGearIntervalAxisXPoint(0);   //设定散点图横轴分辨率

            initDatatable();
            bindLineData();
            bindPieData();
            bindPointData();
            labelControl_status.Parent = this.chartControl_line;
            labelControl_curWeightVal.Parent = this.chartControl_line;
        }

        private void initDatatable()
        {
            //添加一次称重数据
            if (dtLine.Columns.Count == 0)
            {
                dtLine.Columns.Add("countDetection", typeof(Int32));
                dtLine.Columns.Add("currentWeight", typeof(double));
            }

            if (dtPie.Columns.Count == 0)
            {
                dtPie.Columns.Add("status", typeof(String));
                dtPie.Columns.Add("countCur", typeof(Int32));
            }

            if(dtPoint.Columns.Count == 0)
            {
                dtPoint.Columns.Add("weightSection", typeof(Int32));
                dtPoint.Columns.Add("countInSection", typeof(Int32));
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
            this.chartControl_pie.Series[0].ArgumentDataMember = "status";
            this.chartControl_pie.Series[0].ArgumentScaleType = ScaleType.Auto;
            this.chartControl_pie.Series[0].ValueDataMembers.AddRange(new string[] { "countCur" });
            this.chartControl_pie.Series[0].ValueScaleType = ScaleType.Numerical;
            this.chartControl_pie.Series[0].LegendTextPattern = "{A}：{VP:p2}";  //图例格式"Argument:Value"。V:n2为Value:numeric小数点后2位，VP:p2为Value:percent小数点后2位
        }

        private void bindPointData()
        {
            this.chartControl_point.Series[0].DataSource = dtPoint;
            this.chartControl_point.Series[0].ArgumentScaleType = ScaleType.Auto;
            this.chartControl_point.Series[0].ArgumentDataMember = "weightSection";
            this.chartControl_point.Series[0].ValueScaleType = ScaleType.Numerical;
            this.chartControl_point.Series[0].ValueDataMembers.AddRange(new string[] { "countInSection" });
        }

        //刷新左侧标签显示
        private void updateLabels()
        {
            labelControl_brandVal.Text = Global.curStatus.brand;
            labelControl_curWeightVal.Text = Global.curStatus.curWeight.ToString() + "KG";
            labelControl_lastOverWeightVal.Text = Global.curStatus.lastOverWeight > 0 ? Global.curStatus.lastOverWeight.ToString():"";
            labelControl_lastUnderWeightVal.Text = Global.curStatus.lastUnderWeight > 0 ? Global.curStatus.lastUnderWeight.ToString():"";
            labelControl_underWeightCountVal.Text = Global.curStatus.countUnderWeight.ToString();
            labelControl_overWeightCountVal.Text = Global.curStatus.countOverWeight.ToString();
            labelControl_detectionCountVal.Text = Global.curStatus.countDetection.ToString();
            labelControl_maxWeightInHistory.Text = Global.curStatus.maxWeightInHistory.ToString();
            labelControl_minWeightInHistory.Text = Global.curStatus.minWeightInHistory.ToString();
        }

        //刷新折线图数据源
        private void updateChartLineData()
        {
            //点总数未到200时直接添加，超过200时添加一个点：删掉原有第1行，在最后添加一行
            if(Global.curStatus.countDetection <= 200)
            {
                DataRow drCurWeight = dtLine.NewRow();
                drCurWeight["countDetection"] = Global.curStatus.countDetection;
                drCurWeight["currentWeight"] = Global.curStatus.curWeight;
                dtLine.Rows.Add(drCurWeight);
            }
            else
            {
                dtLine.Rows.RemoveAt(0);
                DataRow drCurWeight = dtLine.NewRow();
                drCurWeight["countDetection"] = Global.curStatus.countDetection;
                drCurWeight["currentWeight"] = Global.curStatus.curWeight;
                dtLine.Rows.Add(drCurWeight);

                for(int i = 0; i < 200; i++)
                {
                    dtLine.Rows[i]["countDetection"] = (i + 1).ToString();
                }
            }
            

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

                Global.curStatus.lastOverWeight = lastOverWeght;    //超重、欠重都要更新，否则出现类似场景：第一次是超重，后面一直是欠重，则超重一直得不到刷新
                Global.curStatus.lastUnderWeight = lastUnderWeight;
                
                lastOverWeght = Global.curStatus.curWeight;
            }
            else if(Global.curStatus.flagOverWeightOrUnderWeight == "L-")
            {
                Global.curStatus.countUnderWeight++;
                labelControl_status.Text = "NG";
                this.labelControl_status.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
                
                Global.curStatus.lastOverWeight = lastOverWeght;
                Global.curStatus.lastUnderWeight = lastUnderWeight;
                
                lastUnderWeight = Global.curStatus.curWeight;
            }
            else if(Global.curStatus.flagOverWeightOrUnderWeight == "p-")
            {
                Global.curStatus.lastOverWeight = lastOverWeght;    
                Global.curStatus.lastUnderWeight = lastUnderWeight;
                
                labelControl_status.Text = "OK";
                this.labelControl_status.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(152)))), ((int)(((byte)(83)))));
            }
        }

        //刷新Pie图数据源，Pie图绑定数值，自动显示占比
        private void updateChartPieData()
        {
            if (dtPie.Rows.Count == 0)
            {
                DataRow drCountUnderWeight = dtPie.NewRow();
                drCountUnderWeight["status"] = "欠重";
                drCountUnderWeight["countCur"] = Global.curStatus.countUnderWeight;
                dtPie.Rows.Add(drCountUnderWeight);

                DataRow drCountOverWeight = dtPie.NewRow();
                drCountOverWeight["status"] = "超重";
                drCountOverWeight["countCur"] = Global.curStatus.countOverWeight;
                dtPie.Rows.Add(drCountOverWeight);

                DataRow drCountNormal = dtPie.NewRow();
                drCountNormal["status"] = "正常";
                drCountNormal["countCur"] = Global.curStatus.countDetection - Global.curStatus.countOverWeight - Global.curStatus.countUnderWeight;
                dtPie.Rows.Add(drCountNormal);


            }
            else
            {
                dtPie.Rows[0]["countCur"] = Global.curStatus.countUnderWeight;
                dtPie.Rows[1]["countCur"] = Global.curStatus.countOverWeight;
                dtPie.Rows[2]["countCur"] = Global.curStatus.countDetection - Global.curStatus.countOverWeight - Global.curStatus.countUnderWeight;
            }

        }

        //刷新Point图数据源
        private void updateChartPointData()
        {
            int indexDtPointTemp = 0;
            int weightGram = weightIntervalProcess(Global.curStatus.curWeight);
            //int weightGram = Convert.ToInt32(Global.curStatus.curWeight);
            if (weightAndIndexGramDtPoint.ContainsKey(weightGram) == false)
            {
                DataRow dr = dtPoint.NewRow();
                dr["weightSection"] = weightGram;
                dr["countInSection"] = 1;
                dtPoint.Rows.Add(dr);
                weightAndIndexGramDtPoint.Add(weightGram, indexDtPoint);
                indexDtPoint++;
            }
            else
            {
                indexDtPointTemp = weightAndIndexGramDtPoint[weightGram];
                dtPoint.Rows[indexDtPointTemp]["countInSection"] = Convert.ToInt32(dtPoint.Rows[indexDtPointTemp]["countInSection"]) + 1;
            }
        }

        //设置散点图横轴坐标范围
        private void setAxisXMinMaxPoint(int minKilogram, int maxKilogram)
        {
            if (minKilogram < maxKilogram)
            {
                minXPoint = minXRangePoint[minKilogram];
                maxXPoint = maxXRangePoint[maxKilogram];
                XYDiagram diagram = (XYDiagram)this.chartControl_point.Diagram;
                diagram.AxisX.WholeRange.SetMinMaxValues(minXPoint, maxXPoint);
            }
            else
            {
                MessageBox.Show("请输入合适的重量显示范围");
            }

        }

        //设置散点图横轴分辨率档位
        private void setGearIntervalAxisXPoint(int gear)
        {
            if (gear <= 3 && gear >= 0)
            {
                gearIntervalAxisXPoint = gear;
            }
            else
            {
                MessageBox.Show("请输入正确的档位");
                throw new Exception();
            }
        }

        //将重量（KG)按照区间划归
        private int weightIntervalProcess(double weightKilogram)
        {
            //小于minXPoint的设为minXPoint，大于maxXPoint的设为maxXPoint
            int weightgram = Convert.ToInt32(weightKilogram * 1000);
            int weight = 0;
            if (weightgram <= minXPoint)
            {
                weight = minXPoint;
            }
            else if(weightgram >= maxXPoint)
            {
                weight = maxXPoint;
            }
            else
            {
                //除法效率低，待优化（左右移）
                int countInterval = (weightgram - minXPoint) / intervalAxisXPoint[gearIntervalAxisXPoint];
                 int remainder = (weightgram - minXPoint) - countInterval * intervalAxisXPoint[gearIntervalAxisXPoint];
                int intervalDeviceTwo = intervalAxisXPoint[gearIntervalAxisXPoint] / 2;
                if (remainder < intervalDeviceTwo)
                {
                    weight = minXPoint + countInterval * intervalAxisXPoint[gearIntervalAxisXPoint];
                }
                else
                {
                    weight = minXPoint + (1 + countInterval) * intervalAxisXPoint[gearIntervalAxisXPoint];
                }
            }

            return weight;
        }

        private void insertCurStatusIntoMySQL()
        {
            Thread threadInsertMySQL = new Thread(new ThreadStart(Global.insertCurStatusMySQL));
            threadInsertMySQL.IsBackground = true;
            threadInsertMySQL.Name = "threadInsertMySQL" + Global.curStatus.countDetection.ToString();
            threadInsertMySQL.Start();
        }

        private void labelControl_curWeightVal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("export excel");
            this.chartControl_line.ExportToXlsx(@"C:\Users\eivision\Desktop\a.xlsx");
        }

        private int createRandomProbability(int probability, int a, int b, int c)
        {
            //以概率probablity生成[a,b]区间数，1-probablity概率生成[b,c]区间数
            Random myRandom = new Random();
            int i = myRandom.Next(1, 100);
            if (i <= probability)
            {
                int j = myRandom.Next(a, b);
                return j;
            }
            else
            {
                int j = myRandom.Next(b + 1, c);
                return j;
            }
        }

        //刷新数据源
        private void timer_detectOnce_Tick(object sender, EventArgs e)
        {
            //模拟数据生成
            Global.curStatus.countDetection++;
            Random rnd = new Random();
            //double cw = rnd.Next(8, 12) + rnd.Next(0, 9) * 0.1 + rnd.Next(0, 9) * 0.01 + rnd.Next(0, 9) * 0.001;
            double cw = createRandomProbability(90, 8, 12, 13)  + rnd.Next(0, 9) * 0.1 + rnd.Next(0, 9) * 0.01 + rnd.Next(0, 9) * 0.001;

            Global.curStatus.curWeight = cw;
            if (Global.curStatus.curWeight > 12)
                Global.curStatus.flagOverWeightOrUnderWeight = "H-";
            else if (Global.curStatus.curWeight < 11)
                Global.curStatus.flagOverWeightOrUnderWeight = "L-";
            else
                Global.curStatus.flagOverWeightOrUnderWeight = "p-";
            Global.curStatus.brand = "LG";

            updateLabels();
            updateChartLineData();
            updateChartPieData();
            updateChartPointData();

            insertCurStatusIntoMySQL();

        }

        private void labelControl_status_Click(object sender, EventArgs e)
        {
            this.timer_detectOnce.Enabled = !this.timer_detectOnce.Enabled;
        }


    }
}
