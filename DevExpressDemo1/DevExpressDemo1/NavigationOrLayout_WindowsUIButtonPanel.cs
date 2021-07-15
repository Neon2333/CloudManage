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
using DevExpress.XtraBars.Docking2010;

namespace DevExpressDemo1
{
    public partial class NavigationOrLayout_WindowsUIButtonPanel : DevExpress.XtraEditors.XtraForm
    {
        public NavigationOrLayout_WindowsUIButtonPanel()
        {
            InitializeComponent();
        }

        private void windowsUIButtonPanel2_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "1":
                    /* Navigate to page A */
                    MessageBox.Show("1 checked");
                    break;
                case "2":
                    /* Navigate to page B */
                    MessageBox.Show("2 checked");
                    break;
                case "3":
                    /* Navigate to page C*/
                    MessageBox.Show("3 checked");
                    break;
                case "4":
                    /* Navigate to page C*/
                    MessageBox.Show("4 checked");
                    break;
            }
        }



    }
}