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
            dtRightSide.Columns.Add("参数名", typeof(String));
            dtRightSide.Columns.Add("值", typeof(String));
            for(int i = 0; i < 10; i++)
            {
                DataRow drRightSide1 = dtRightSide.NewRow();
                drRightSide1[0] = "CPU温度";
                drRightSide1[1] = "50℃";
                dtRightSide.Rows.Add(drRightSide1);

                DataRow drRightSide2 = dtRightSide.NewRow();
                drRightSide2[0] = "CPU利用率";
                drRightSide2[1] = "60%";
                dtRightSide.Rows.Add(drRightSide2);
                
                DataRow drRightSide3 = dtRightSide.NewRow();
                drRightSide3[0] = "内存利用率";
                drRightSide3[1] = "70%";
                dtRightSide.Rows.Add(drRightSide3);
            }
            this.gridControl_rightSide.DataSource = dtRightSide;
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

            //for (int i = 0; i < 100; i++)
            //{
            //    refreshDtRightSide("50", "50%", "30%");
            //    Thread.Sleep(3000);
            //    refreshDtRightSide("40", "60%", "40%");
            //}


        }

    }
}
