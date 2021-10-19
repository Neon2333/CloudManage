using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using System.Threading;

namespace CloudManage
{
    public partial class RealTimeDataControl : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable dtRightSide = new DataTable();

        public RealTimeDataControl()
        {
            InitializeComponent();
            test();
        }

        void initDtRightSide()
        {
            dtRightSide.Columns.Add("CPU温度", typeof(String));
            dtRightSide.Columns.Add("CPU利用率", typeof(String));
            dtRightSide.Columns.Add("内存利用率", typeof(String));
            this.gridControl_rightSide.DataSource = dtRightSide;
        }

        void refreshDtRightSide(string cpuTemperature, string CPUusage, string memoryUsage)
        {
            dtRightSide.Rows.Clear();
            DataRow drRightSide = dtRightSide.NewRow();
            drRightSide[0] = cpuTemperature;
            drRightSide[1] = CPUusage;
            drRightSide[2] = memoryUsage;
            dtRightSide.Rows.Add(drRightSide);
        }

        void test()
        {
            string tag = String.Empty;
            string name = String.Empty;
            string text = String.Empty;
            string num = String.Empty;
            for (int i = 1; i <= 10; i++)
            {
                tag = i.ToString();
                name = "tileBarItem" + i.ToString();
                text = i.ToString() + "车";
                num = i.ToString();
                this.sideTileBarControlWithSub1._addSideTileBarItem(new TileBarItem(), tag, name, text, num);
            }

            for (int i = 1; i <= 10; i++)
            {
                tag = i.ToString();
                text = "烟库乱烟检测";
                bool flag = this.sideTileBarControlWithSub1._addSideTileBarItemSub(new TileBarItem(), tag, "tileBarItem_sub" + i.ToString(), text, Encoding.Default.GetBytes(text).Length / 2);

            }

            initDtRightSide();
            refreshDtRightSide("50", "50%", "30%");

            //for (int i = 0; i < 100; i++)
            //{
            //    refreshDtRightSide("50", "50%", "30%");
            //    Thread.Sleep(3000);
            //    refreshDtRightSide("40", "60%", "40%");
            //}


        }

    }
}
