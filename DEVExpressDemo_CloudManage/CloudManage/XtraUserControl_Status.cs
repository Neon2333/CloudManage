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
    public partial class XtraUserControl_Status : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl_Status()
        {
            InitializeComponent();
            this.Dock= System.Windows.Forms.DockStyle.Fill;
        }

        private void windowsUIButtonPanel_Status_ButtonChecked(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();    //checkButton时Caption被禁用了
            switch (tag)
            {
                case "New":
                    this.navigationFrame_Status.SelectedPage = navigationPage_Status_1;
                    break;
                case "Edit":
                    this.navigationFrame_Status.SelectedPage = navigationPage_Status_2;
                    break;
                case "Filter":
                    this.navigationFrame_Status.SelectedPage = navigationPage_Status_3;
                    break;
            }
        }
    }
}
