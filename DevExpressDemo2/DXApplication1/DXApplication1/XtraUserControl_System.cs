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
using DevExpress.XtraBars.Docking2010;

namespace DXApplication1
{
    public partial class XtraUserControl_System : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl_System()
        {
            InitializeComponent();
        }

        private void windowsUIButtonPanel2_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();    //checkButton时Caption被禁用了
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
    }



}
