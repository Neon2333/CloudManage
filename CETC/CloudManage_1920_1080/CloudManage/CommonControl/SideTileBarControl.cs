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
using System.Text.RegularExpressions;

namespace CloudManage.CommonControl
{
    public partial class SideTileBarControl : DevExpress.XtraEditors.XtraUserControl
    {
        public SideTileBarControl()
        {
            InitializeComponent();
        }

        //显示总览按钮
        public Boolean showOverview
        {
            get
            {
                return this.tileBarItem1.Visible;
            }
            set
            {
                this.tileBarItem1.Visible = value;
            }
        }

        private bool isAllNum(string tag)
        {
            Regex regexNotAllNums = new Regex("[^0-9]+");
            if (regexNotAllNums.IsMatch(tag))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //在尾部依次添加按钮
        public bool _addSideTileBarItem(TileBarItem tileBarItem, string tagTileBarItem, string nameTileBarItem, string text, string num)
        {
            try
            {
                if (!isAllNum(tagTileBarItem) || !isAllNum(num))
                {
                    return false;
                }
                int count = this.tileBarGroup_sideTileBarControl.Items.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBarControl.Items.ElementAt(i);
                        //tag、itemName、text相同无法添加
                        string tag = temp.Tag.ToString();
                        string itemName = temp.Name;
                        if (tagTileBarItem.CompareTo(tag) == 0 || nameTileBarItem.CompareTo(itemName) == 0) //tag或name重复
                        {
                            return false;
                        }
                    }
                }

                TileItemElement tileItemElementNum = new TileItemElement();
                TileItemElement tileItemElementText = new TileItemElement();
                TileItemElement tileItemElementIcon = new TileItemElement();
                tileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
                tileBarItem.AppearanceItem.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
                tileBarItem.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 24F);
                tileBarItem.AppearanceItem.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
                tileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
                tileBarItem.AppearanceItem.Normal.Options.UseBorderColor = true;
                tileBarItem.AppearanceItem.Normal.Options.UseFont = true;
                tileBarItem.AppearanceItem.Normal.Options.UseForeColor = true;
                tileBarItem.AppearanceItem.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
                tileBarItem.AppearanceItem.Selected.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
                tileBarItem.AppearanceItem.Selected.Font = new System.Drawing.Font("微软雅黑", 24F);
                tileBarItem.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
                tileBarItem.AppearanceItem.Selected.Options.UseBackColor = true;
                tileBarItem.AppearanceItem.Selected.Options.UseBorderColor = true;
                tileBarItem.AppearanceItem.Selected.Options.UseFont = true;
                tileBarItem.AppearanceItem.Selected.Options.UseForeColor = true;
                tileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
                tileItemElementNum.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
                tileItemElementNum.Text = num;
                tileItemElementNum.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
                tileItemElementText.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                tileItemElementText.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
                tileItemElementText.Appearance.Normal.Options.UseFont = true;
                tileItemElementText.Appearance.Normal.Options.UseForeColor = true;
                tileItemElementText.Appearance.Selected.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
                tileItemElementText.Appearance.Selected.ForeColor = System.Drawing.Color.White;
                tileItemElementText.Appearance.Selected.Options.UseFont = true;
                tileItemElementText.Appearance.Selected.Options.UseForeColor = true;
                tileItemElementText.Text = text;
                tileItemElementText.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
                tileItemElementIcon.ImageOptions.Image = global::CloudManage.Properties.Resources.packagingMachine_120_34;
                tileItemElementIcon.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
                tileItemElementIcon.ImageOptions.ImageLocation = new System.Drawing.Point(0, 15);
                tileItemElementIcon.Text = "";
                tileBarItem.Elements.Add(tileItemElementNum);
                tileBarItem.Elements.Add(tileItemElementText);
                tileBarItem.Elements.Add(tileItemElementIcon);
                tileBarItem.Id = 0;
                tileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
                tileBarItem.Name = nameTileBarItem;
                tileBarItem.Tag = tagTileBarItem;

                this.tileBarGroup_sideTileBarControl.Items.Add(tileBarItem);
                return true;
            }
            catch(Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        //可在任意位置以tag删除按钮删除按钮
        public bool _deleteButton(string tagTileBarItem)
        {
            bool flag = false;
            try
            {
                if (!isAllNum(tagTileBarItem))
                {
                    return false;
                }
                int count = this.tileBarGroup_sideTileBarControl.Items.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBarControl.Items.ElementAt(i);
                        string tag = temp.Tag.ToString();
                        if (tagTileBarItem.CompareTo(tag) == 0)
                        {
                            this.tileBarGroup_sideTileBarControl.Items.RemoveAt(i);
                            flag = true;
                            break;
                        }
                    }
                }
                return flag;
                
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        //设置某个Item的Num值
        public bool _setNum(string tagTileBarItem, string num)
        {
            bool flag = false;
            try
            {
                if (!isAllNum(tagTileBarItem) || !isAllNum(num))
                {
                    return false;
                }
                int count = this.tileBarGroup_sideTileBarControl.Items.Count;
                for(int i = 0; i < count; i++)
                {
                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBarControl.Items.ElementAt(i);
                    string tag = temp.Tag.ToString();
                    if (tagTileBarItem.CompareTo(tag) == 0)
                    {
                        ((TileBarItem)this.tileBarGroup_sideTileBarControl.Items.ElementAt(i)).Text = num;
                        flag = true;
                    }
                }
                return flag;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }


    }
}
