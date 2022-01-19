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

namespace CloudManage
{
    public partial class XtraUserControl_System : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl_System()
        {
            InitializeComponent();

            this.navigationFrame_Status.Size = new System.Drawing.Size(1366, 768);

        }

        private void windowsUIButtonPanel_System_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();    //checkButton时Caption被禁用了
            switch (tag)
            {
                case "Contacts":
                    this.navigationFrame_Status.SelectedPage = navigationPage_System_1;
                    break;
                case "Calendar":
                    this.navigationFrame_Status.SelectedPage = navigationPage_System_2;
                    break;
                case "Mail":
                    this.navigationFrame_Status.SelectedPage = navigationPage_System_3;
                    break;
            }
        }


    }
}
