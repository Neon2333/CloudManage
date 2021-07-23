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
    public partial class XtraUserControl_tileBarSub : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.Navigation.TileBarDropDownContainer tileBarDropDownContainer_;  //容器
        private DevExpress.XtraBars.Navigation.TileBar tileBar_;    //tileBar
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup_;  //tileBarGroup
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem_1;   //tileBarGroup中的item按钮
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem_2;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem_3;
        DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
        DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
        DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
        

        public XtraUserControl_tileBarSub()
        {
            InitializeComponent();

            this.tileBarDropDownContainer_ = new DevExpress.XtraBars.Navigation.TileBarDropDownContainer();
            this.tileBar_ = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup_ = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tileBarItem_1 = new DevExpress.XtraBars.Navigation.TileBarItem();

            Init_tileBarDropDownContainer();
            Init_tileBar();
            Init_tileBarGroup();
            Init_tileBarItem1();
        }

        //
        //tileBarDropDownContainer
        //

        [Browsable(true), Description("tileBarDropDownContainer的TabIndex"), Category("tileBarDropDownContainer 通用")]
        public int TileBarDropDownContainer_TabIndex
        {
            get
            {
                return this.tileBarDropDownContainer_.TabIndex;
            }
            set
            {
                this.tileBarDropDownContainer_.TabIndex = value;
            }
        }

        [Browsable(true), Description("tileBarDropDownContainer的Location"), Category("tileBarDropDownContainer 通用")]
        public Point TileBarDropDownContainer_Location
        {
            get
            {
                return this.tileBarDropDownContainer_.Location;
            }
            set
            {
                this.tileBarDropDownContainer_.Location = value;
            }
        }

        //initialize tileBarDropDownContainer
        public void Init_tileBarDropDownContainer()
        {

            ((System.ComponentModel.ISupportInitialize)(this.tileBarDropDownContainer_)).BeginInit();
            this.tileBarDropDownContainer_.SuspendLayout();
            //写死的属性
            this.tileBarDropDownContainer_.Name = "tileBarDropDownContainer_";
            this.tileBarDropDownContainer_.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tileBarDropDownContainer_.Size = new System.Drawing.Size(1633, 120);
            this.tileBarDropDownContainer_.Appearance.Options.UseBackColor = true;
            this.tileBarDropDownContainer_.Controls.Add(this.tileBar_);
            //公开的属性
            //this.tileBarDropDownContainer_.Location = new System.Drawing.Point(65, 117);
            //this.tileBarDropDownContainer_.TabIndex = 13;
        }

        //
        //tileBar
        //

        [Browsable(true), Description("tileBar的Text"), Category("tileBarDropDownContainer 通用")]
        public string TileBar_Text
        {
            get
            {
                return this.tileBar_.Text;
            }
            set
            {
                this.tileBar_.Text = value;
            }
        }

        [Browsable(true), Description("tileBar的Location"), Category("tileBarDropDownContainer 通用")]
        public Point TileBar_Location
        {
            get
            {
                return this.TileBar_Location;
            }
            set
            {
                this.TileBar_Location = value;
            }
        }

        public void Init_tileBar()
        {
            this.tileBar_.Name = "tileBar_";
            this.tileBar_.AllowSelectedItem = true;
            this.tileBar_.DropDownOptions.BackColorMode = DevExpress.XtraBars.Navigation.BackColorMode.UseTileBackColor;
            this.tileBar_.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar_.Groups.Add(this.tileBarGroup_);
            this.tileBar_.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar_.Size = new System.Drawing.Size(1633, 70);
            this.tileBar_.MaxId = 6;
            this.tileBar_.TabIndex = 0;
            //公开属性
            //this.tileBar_.Text = "tileBar2";
            //this.tileBar_.Location = new System.Drawing.Point(10, 3);
        }

        //
        //tileBarGroup
        //
           public void Init_tileBarGroup()
        {
            this.tileBarGroup_.Name = "tileBarGroup_";
            this.tileBarGroup_.Items.Add(this.tileBarItem_1);
            //this.tileBarGroup_.Items.Add(this.tileBarItem_2);
            //this.tileBarGroup_.Items.Add(this.tileBarItem_3);
        }

        //
        //tileBarItem1
        //

        [Browsable(true), Description("tileBar的Location"), Category("tileBarDropDownContainer 通用")]
        public string TileBarItem_1_text
        {
            get
            {
                return tileItemElement1.Text;
            }
            set
            {
                tileItemElement1.Text = value;
            }
        }
        public void Init_tileBarItem1()
        {
            //写死属性
            this.tileBarItem_1.Name = "tileBarItem_1";
            this.tileBarItem_1.AppearanceItem.Hovered.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tileBarItem_1.AppearanceItem.Hovered.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileBarItem_1.AppearanceItem.Hovered.ForeColor = System.Drawing.Color.Black;
            this.tileBarItem_1.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileBarItem_1.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileBarItem_1.AppearanceItem.Hovered.Options.UseForeColor = true;
            this.tileBarItem_1.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.tileBarItem_1.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tileBarItem_1.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.tileBarItem_1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBarItem_1.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBarItem_1.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileBarItem_1.AppearanceItem.Selected.BackColor = System.Drawing.Color.SteelBlue;
            this.tileBarItem_1.AppearanceItem.Selected.BorderColor = System.Drawing.Color.White;
            this.tileBarItem_1.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
            this.tileBarItem_1.AppearanceItem.Selected.Options.UseBackColor = true;
            this.tileBarItem_1.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tileBarItem_1.AppearanceItem.Selected.Options.UseForeColor = true;
            this.tileBarItem_1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBarItem_1.Id = 0;
            this.tileBarItem_1.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            //公开属性
            //tileItemElement1.Text = "tileBarItem1";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.tileBarItem_1.Elements.Add(tileItemElement1);
        }


        
    }
}
