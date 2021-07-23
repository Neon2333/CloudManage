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

namespace DXApplication1
{
    public partial class test : DevExpress.XtraEditors.XtraForm
    {
        //XtraUserControl_System userControlSystem = new XtraUserControl_System();

        //XtraUserControl_Status userControlStatus = new XtraUserControl_Status();
        public test()
        {
            InitializeComponent();

            //this.Controls.Add(userControlSystem);
            //this.Controls.Add(userControlStatus);

            XtraUserControl_tileBar tileBar = new XtraUserControl_tileBar();
            this.Controls.Add(tileBar);
           
        }


    }
}