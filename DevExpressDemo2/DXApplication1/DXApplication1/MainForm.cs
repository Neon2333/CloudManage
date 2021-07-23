using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.ControlBox = false;    //不显示最小化、关闭、最大化
            this.ClientSize = new System.Drawing.Size(1364, 736);

        }


        private void tileBarItem_system_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage1;
        }

        private void tileBarItem_status_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage2;
        }

        //this.tileBarItem3.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileBarItem_status_ItemClick);



    }
}
