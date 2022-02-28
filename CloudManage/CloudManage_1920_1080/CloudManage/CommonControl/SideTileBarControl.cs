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
        private bool UseDtInitSideTileBar = true;   //是否使用表初始化侧边栏
        private string TagSelectedItem = String.Empty;
        public int countSideTileBarItem = 0;    //item总数
        DataTable DT = new DataTable();     //用于初始化侧边栏的表
        //表DT的3个字段
        private string ColTagDT = String.Empty;
        private string ColTextDT = String.Empty;
        private string ColNumDT = String.Empty;

        public SideTileBarControl()
        {
            InitializeComponent();
            countSideTileBarItem = this.tileBarGroup_sideTileBarControl.Items.Count;
            if (this.showOverview == true)
            {
                TagSelectedItem = "000"; 
            }
            else
            {
                TagSelectedItem = "001";
            }
        }

        public Boolean useDtInitSideTileBar
        {
            get
            {
                return this.UseDtInitSideTileBar;
            }
            set
            {
                this.UseDtInitSideTileBar = value;
            }
        }

        public DataTable dtInitSideTileBar
        {
            set
            {
                this.DT = value;   
            }
        }

        //“总览”按钮显示
        public Boolean showOverview
        {
            get
            {
                return this.tileBarItem0.Visible;
            }
            set
            {
                this.tileBarItem0.Visible = value;
            }
        }

        //“总览”按钮的显示名
        public string overViewText
        {
            set
            {
                this.tileItemElement2.Text = value;
            }
        }

        //获取被选中item的tag
        public string tagSelectedItem
        {
            get
            {
                return this.TagSelectedItem;
            }
        }

        public string colTagDT
        {
            get
            {
                return this.ColTagDT;
            }
            set
            {
                this.ColTagDT = value;
            }
        }

        public string colTextDT
        {
            get
            {
                return this.ColTextDT;
            }
            set
            {
                this.ColTextDT = value;
            }
        }

        public string colNumDT
        {
            get
            {
                return this.ColNumDT;
            }
            set
            {
                this.ColNumDT = value;
            }
        }

        //初始化侧边栏
        //参数传入null时
        public void _initSideTileBar()
        {
            //遍历DT，对于DT中的某个产线，Items中没有，则将DT对应的产线添加到第一级侧边栏
            //遍历DT，若DT中的某个产线，Items中已存在，则修改该产线的num（设备数）
            //遍历Items，对于已添加到第一级侧边栏的产线，若在DT中没有，则需要删除

            if (this.UseDtInitSideTileBar == true)
            {
                //添加产线按钮tileBarItem
                string tag = String.Empty;
                string itemName = String.Empty;
                string text = String.Empty;
                string num = String.Empty;

                int totalNumTemp = 0;
                for (int i = 0; i < this.DT.Rows.Count; i++)
                {
                    if(this.colTagDT!=null)
                        tag = (string)this.DT.Rows[i][this.colTagDT];
                    itemName = "tileBarItem" + (i + 1).ToString();   //tileBarItem0是总览,tileBarItem1是1号车
                    if(this.colTextDT !=null)
                        text = (string)this.DT.Rows[i][this.colTextDT];
                    if (this.colNumDT != null) { 
                        num = this.DT.Rows[i][this.colNumDT].ToString();
                        totalNumTemp ++;
                    }
                    this._addSideTileBarItem(new TileBarItem(), tag, itemName, text, num);   //添加item
                }

                _removeSideTileBarItemNotInDT();    //删除侧边栏中已被删除的产线

                if (this.showOverview == true)
                {
                    this._setNum("000", totalNumTemp.ToString());
                }
            }
            else
            {
                MessageBox.Show("useDtInitSideTileBar为false");
            }
        }

        //在尾部依次添加按钮
        public bool _addSideTileBarItem(TileBarItem tileBarItem, string tagTileBarItem, string nameTileBarItem, string text, string num)
        {
            try
            {
                if (!_isAllNum(tagTileBarItem) || !_isAllNum(num))
                {
                    return false;
                }
                if (countSideTileBarItem > 0)
                {
                    for (int i = 0; i < countSideTileBarItem; i++)
                    {
                        //遍历DT，对于DT中的某个产线，Items中没有，则将DT对应的产线添加到第一级侧边栏
                        //遍历DT，若DT中的某个产线，Items中已存在，则修改该产线的num（设备数）
                        //遍历Items，对于已添加到第一级侧边栏的产线，若在DT中没有，则需要删除
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBarControl.Items.ElementAt(i);


                        //tag、itemName、text相同无法添加
                        string tag = temp.Tag.ToString();
                        string itemName = temp.Name;
                        if (tagTileBarItem.CompareTo(tag) == 0 || nameTileBarItem.CompareTo(itemName) == 0) //tag或name重复
                        {
                            //若添加的item已存在，则不再添加而是修改其num值
                            this._setNum(tag, num);
                            return true;
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
                tileItemElementText.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                tileItemElementText.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
                tileItemElementText.Appearance.Normal.Options.UseFont = true;
                tileItemElementText.Appearance.Normal.Options.UseForeColor = true;
                tileItemElementText.Appearance.Selected.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
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
                countSideTileBarItem = this.tileBarGroup_sideTileBarControl.Items.Count;    //更新tileBarItem总数
                //不显示“总览”时，初始化默认选中“产线1”
                if (this.showOverview == false && this.countSideTileBarItem == 2)
                {
                    this.tileBar_sideTileBarControl.SelectedItem = tileBarItem;
                    this.TagSelectedItem = (string)this.tileBar_sideTileBarControl.SelectedItem.Tag;
                }
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        //清除this.DT中不存在但Items中存在的产线（被删除的产线对应的item要清除）
        public void _removeSideTileBarItemNotInDT()
        {
            if (countSideTileBarItem > 0)
            {
                for (int i = 1; i < countSideTileBarItem; i++)
                {
                    bool flag = false;

                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBarControl.Items.ElementAt(i);
                    string tag = temp.Tag.ToString();
                    string itemName = temp.Name;

                    for (int j = 0; j < this.DT.Rows.Count; j++)
                    {
                        if(tag.CompareTo((string)this.DT.Rows[j][this.colTagDT]) == 0)
                        {
                            flag = true;
                            break;
                        }
                    }
                    
                    if(flag == false)
                    {
                        this._removeItemByTag(tag);

                    }


                }
            }
        }

        //通过tag选中item
        public bool _selectedItem(string tag)
        {
            bool flag = false;
            string tagTemp = String.Empty;
            try
            {
                for (int i = 0; i < countSideTileBarItem; i++)
                {
                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBarControl.Items.ElementAt(i);
                    tagTemp = (string)temp.Tag;
                    if (tag.CompareTo(tagTemp) == 0)
                    {
                        TagSelectedItem = tagTemp;
                        this.tileBar_sideTileBarControl.SelectedItem = temp;
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

        //通过index选中item
        public bool _selectedItem(int indexItem)
        {
            bool flag = false;
            try
            {
                for (int i = 0; i < countSideTileBarItem; i++)
                {
                    if(indexItem == i)
                    {
                        this.tileBar_sideTileBarControl.SelectedItem = (TileBarItem)this.tileBarGroup_sideTileBarControl.Items.ElementAt(i);
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

        private bool _isAllNum(string tag)
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

       

        //以tag删除按钮
        public bool _removeItemByTag(string tagTileBarItem)
        {
            bool flag = false;
            try
            {
                if (!_isAllNum(tagTileBarItem))
                {
                    return false;
                }
                if (countSideTileBarItem > 0)
                {
                    for (int i = 0; i < countSideTileBarItem; i++)
                    {
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBarControl.Items.ElementAt(i);
                        string tag = temp.Tag.ToString();
                        if (tagTileBarItem.CompareTo(tag) == 0)
                        {
                            this.tileBarGroup_sideTileBarControl.Items.RemoveAt(i);
                            this.countSideTileBarItem = this.tileBarGroup_sideTileBarControl.Items.Count;
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

        //清空按钮
        public void _removeAllItem()
        {
            for(int i = 0; i < countSideTileBarItem; i++)
            {
                this.tileBarGroup_sideTileBarControl.Items.RemoveAt(i);
            }
        }

        //设置某个Item的Num值
        public bool _setNum(string tagTileBarItem, string num)
        {
            bool flag = false;
            try
            {
                if (!_isAllNum(tagTileBarItem) || !_isAllNum(num))
                {
                    return false;
                }
                for (int i = 0; i < countSideTileBarItem; i++)
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

        //通过Tag获得Text
        public string _getItemTextUseTag(string tagTileBarItem)
        {
            DataRow[] dr = null;
            if (_isAllNum(tagTileBarItem) == true && this.DT.Rows.Count != 0)
            {
                dr = this.DT.Select(this.ColTagDT + "='"+ tagTileBarItem + "'");
            }
            if (dr.Length != 1)
            {
                return "未找到";
            }
            else
            {
                return dr[0][this.ColTextDT].ToString();
            }

        }


        public delegate void TileItemSelectedChangedHanlder(object sender, EventArgs e);
        public event TileItemSelectedChangedHanlder sideTileBarItemSelectedChanged; //自定义事件，将SideTileBarControl的itemSelectedChanged事件传出
        private void tileBar_sideTileBarControl_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            TagSelectedItem = (string)this.tileBar_sideTileBarControl.SelectedItem.Tag;
            if (sideTileBarItemSelectedChanged != null)
            {
                sideTileBarItemSelectedChanged(sender, new EventArgs());
            }
        }

        public delegate void TileItemItemClickedHanlder(object sender, EventArgs e);
        public event TileItemItemClickedHanlder sideTileBarItemClicked; //自定义事件，将SideTileBarControl的itemSelectedChanged事件传出
        private void tileBar_sideTileBarControl_ItemClick(object sender, TileItemEventArgs e)
        {
            TagSelectedItem = (string)this.tileBar_sideTileBarControl.SelectedItem.Tag;
            if (sideTileBarItemClicked != null)
            {
                sideTileBarItemClicked(sender, new EventArgs());
            }
        }
    }
}
