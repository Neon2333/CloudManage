using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.DevAV.ViewModels;
using DevExpress.XtraBars.Navigation;

namespace DXApplication1 {
    public partial class BaseCustomFilterView : XtraUserControl
    {
        private TileBarGroup tileBarGroup2;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.ComponentModel.IContainer components;
        private TileBar tileBar;

        public BaseCustomFilterView() {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        public void SetViewModel(FilterViewModelBase filterViewModel) {
            mvvmContext.SetViewModel(typeof(FilterViewModelBase), filterViewModel);
            InitBindings();
        }
        
        void InitBindings() {
            var fluent = mvvmContext.OfType<FilterViewModelBase>();
            fluent.SetBinding(tileBar,
                x => x.SelectedItem, x => x.SelectedItem,
                filter => (TileItem)tileBarGroup2.Items.FirstOrDefault(item => Equals(item.Tag, filter)), 
                item => (FilterViewModelBase.FilterItem)item.Tag);
            fluent.SetItemsSourceBinding(tileBarGroup2,
                tg => tg.Items, x => x.CustomFilters, 
                (item, filter) => object.Equals(item.Tag, filter),
                (filter) => CreateTileForFilter(filter));
        }
        ITileItem CreateTileForFilter(FilterViewModelBase.FilterItem filter) {
            var tile = new TileBarItem();
            tile.ItemSize = TileBarItemSize.Wide;
            tile.Tag = filter;
            TileItemElement element = new TileItemElement();
            element.TextAlignment = TileItemContentAlignment.MiddleCenter;
            element.Text = filter.Name;
            tile.Elements.Add(element);
            return tile;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tileBar = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup2 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // tileBar
            // 
            this.tileBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar.Groups.Add(this.tileBarGroup2);
            this.tileBar.ItemSize = 40;
            this.tileBar.Location = new System.Drawing.Point(0, 0);
            this.tileBar.Name = "tileBar";
            this.tileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar.Size = new System.Drawing.Size(434, 322);
            this.tileBar.TabIndex = 0;
            this.tileBar.Text = "tileBar1";
            // 
            // tileBarGroup2
            // 
            this.tileBarGroup2.Name = "tileBarGroup2";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            // 
            // BaseCustomFilterView
            // 
            this.Controls.Add(this.tileBar);
            this.Name = "BaseCustomFilterView";
            this.Size = new System.Drawing.Size(434, 322);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
