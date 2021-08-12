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
using DevExpress.XtraBars.Navigation;

namespace CloudManage
{
    public partial class testSideTileBarControl : DevExpress.XtraEditors.XtraForm
    {
        public testSideTileBarControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.sideTileBarControl1.showOverview = !this.sideTileBarControl1.showOverview;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.sideTileBarControl1._addSideTileBarItem(new TileBarItem(), this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text)?"success..":"failed..";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox6.Text = this.sideTileBarControl1._deleteButton(this.textBox6.Text) ? "success.." : "failed..";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox8.Text = this.sideTileBarControl1._setNum(this.textBox8.Text, this.textBox9.Text) ? "success.." : "failed..";
        }




    }
}