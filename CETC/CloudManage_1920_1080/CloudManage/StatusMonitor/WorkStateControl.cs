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
using DevExpress.XtraBars.Navigation;

namespace CloudManage.StatusMonitor
{
    public partial class WorkStateControl : DevExpress.XtraEditors.XtraUserControl
    {
        public WorkStateControl()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "2", "tileBarItem3", "2车", "51");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "3", "tileBarItem4", "3车", "51");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "4", "tileBarItem5", "4车", "51");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "5", "tileBarItem6", "5车", "51");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "6", "tileBarItem7", "6车", "51");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "7", "tileBarItem8", "7车", "51");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "8", "tileBarItem9", "8车", "51");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "9", "tileBarItem10", "9车", "51");
            this.sideTileBarControl1._addSideTileBarItem(new DevExpress.XtraBars.Navigation.TileBarItem(), "10", "tileBarItem11", "10车", "51");

        }
    }
}
