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

namespace CloudManage
{
    public partial class test : DevExpress.XtraEditors.XtraForm
    {
        public test()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(),"2","tileBarItem3", "2车", "40");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(),"3","tileBarItem4", "3车", "50");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(),"4","tileBarItem5", "4车", "60");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(),"5","tileBarItem6", "5车", "70");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(),"6","tileBarItem7", "6车", "80");

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tag = this.textBox1.Text;
            if (this.sideTileBarControl1._deleteButton(tag))
            {
                this.textBox1.Text = "succeed..";
            }
            else
            {
                this.textBox1.Text = "failed..";
            }
        }


    }
}