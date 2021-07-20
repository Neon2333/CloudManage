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
        }

        private void windowsUIButtonPanel2_ButtonChecked(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Contacts":
                    this.navigationFrame_Level2.SelectedPage = navigationPage3;
                    break;
                case "Calendar":
                    this.navigationFrame_Level2.SelectedPage = navigationPage4;

                    break;
                case "Mail":
                    this.navigationFrame_Level2.SelectedPage = navigationPage5;

                    break;
            }
        }


        private void tileBarItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_Level1.SelectedPage = navigationPage1;

        }

        private void tileBarItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_Level1.SelectedPage = navigationPage2;

        }

        private void tileBarItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_Level2.SelectedPage = navigationPage3;
        }

        private void tileBarItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_Level2.SelectedPage = navigationPage4;

        }

        private void tileBarItem7_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_Level2.SelectedPage = navigationPage5;

        }
    }
}
