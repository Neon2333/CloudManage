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

namespace DXApplication1
{
    public partial class XtraUserControl_tileBar : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl_tileBar()
        {
            InitializeComponent();
            this.tileBar_mainMenu.Dock= System.Windows.Forms.DockStyle.Top;
        }
    }
}
