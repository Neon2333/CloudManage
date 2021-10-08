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
using System.Collections;

namespace CloudManage.CommonControl
{
    public partial class SideTileBarControlWithSub : DevExpress.XtraEditors.XtraUserControl
    {
        private DataTable Dt = new DataTable();

        private string TagSelectedItem = String.Empty;
        private string TagSelectedItemSub = String.Empty;   //总览tag="0"，添加按钮时从tag="1"开始
        public int countSideTileBarItem = 0;    //sideTileBar中显示的items计数。包括“总览”按钮
        public int countSideTileBarItemSub = 0; //sideTileBarSub中items计数
        public int TotalNumDevice = 0;     //检测设备总数
        //public string UsedItemsSub = String.Empty; //使用设备标志字符串
        public SideTileBarControlWithSub()
        {
            InitializeComponent();
            countSideTileBarItem = this.tileBarGroup_sideTileBar.Items.Count;
            TotalNumDevice = this.Dt.Columns.Count - 1;  //从表格读取列数初始化检测设备总数，去掉第一列Tag
            countSideTileBarItemSub = this.tileBarGroup_sub.Items.Count;
            TagSelectedItem = "0";  //初始默认选中“总览”

        }

        //显示总览按钮
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

        public DataTable dataTableTileBarSub
        {
            set
            {
                this.Dt = value;
            }
            get
            {
                return this.Dt;
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
        //获取Sub中被选中item的tag
        public string tagSelectedItemSub
        {
            get
            {
                return this.TagSelectedItemSub;
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
                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                    tagTemp = (string)temp.Tag;
                    if (tag.CompareTo(tagTemp) == 0)
                    {
                        TagSelectedItem = tagTemp;
                        this.tileBar_sideTileBar.SelectedItem = temp;
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
        //通过tag选中sub的item
        public bool _selectedItemSub(string tag)
        {
            bool flag = false;
            string tagTemp = String.Empty;
            try
            {
                for (int i = 0; i < countSideTileBarItemSub; i++)
                {
                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i);
                    tagTemp = (string)temp.Tag;
                    if (tag.CompareTo(tagTemp) == 0)
                    {
                        TagSelectedItemSub = tagTemp;
                        this.tileBar_sideTileBar_sub.SelectedItem = temp;
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
                    if (indexItem == i)
                    {
                        this.tileBar_sideTileBar.SelectedItem = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
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
        //通过index选中sub的item
        public bool _selectedItemSub(int indexItem)
        {
            bool flag = false;
            try
            {
                for (int i = 0; i < countSideTileBarItemSub; i++)
                {
                    if (indexItem == i)
                    {
                        this.tileBar_sideTileBar_sub.SelectedItem = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i);
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

        //在sideTileBar尾部依次添加按钮
        public bool _addSideTileBarItem(TileBarItem tileBarItem, string tagTileBarItem, string nameTileBarItem, string text, string num)
        {
            TotalNumDevice = this.Dt.Columns.Count - 1;  //更新当前的设备数

            try
            {
                if (!isAllNum(tagTileBarItem) || !isAllNum(num))
                {
                    return false;
                }
                if (countSideTileBarItem > 0)
                {
                    for (int i = 0; i < countSideTileBarItem; i++)
                    {
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
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
                //tileBarItem.DropDownControl = this.tileBarDropDownContainer_sub;
                tileBarItem.DropDownOptions.BackColorMode = DevExpress.XtraBars.Navigation.BackColorMode.UseBeakColor;
                tileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
                tileBarItem.ShowDropDownButton = DevExpress.Utils.DefaultBoolean.True;
                tileBarItem.DropDownOptions.AutoHeight = DevExpress.Utils.DefaultBoolean.False;
                tileBarItem.DropDownOptions.Height = 270;   //每个tileBarItem的绑定的子菜单的显示宽度
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

                this.tileBarGroup_sideTileBar.Items.Add(tileBarItem);
                countSideTileBarItem = this.tileBarGroup_sideTileBar.Items.Count;    //更新显示的tileBarItem计数
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        //在sideTileBarSub的尾部依次添加按钮
        public bool _addSideTileBarItemSub(TileBarItem tileBarItemSub, string tagTileBarItemSub, string nameTileBarItemSub, string textSub, int numOfChineseCharacters)
        {
            try
            {
                if (countSideTileBarItemSub > 0)
                {
                    for (int i = 0; i < countSideTileBarItemSub; i++)
                    {
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i);
                        //tag、itemName、text相同无法添加
                        string tag = temp.Tag.ToString();
                        string itemName = temp.Name;
                        if (tagTileBarItemSub.CompareTo(tag) == 0 || nameTileBarItemSub.CompareTo(itemName) == 0) //tag或name重复
                        {
                            return false;
                        }
                    }
                }

                DevExpress.XtraEditors.TileItemElement tileItemElement = new DevExpress.XtraEditors.TileItemElement();
                tileBarItemSub.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
                tileBarItemSub.AppearanceItem.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
                tileBarItemSub.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
                tileBarItemSub.AppearanceItem.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
                tileBarItemSub.AppearanceItem.Normal.Options.UseBackColor = true;
                tileBarItemSub.AppearanceItem.Normal.Options.UseBorderColor = true;
                tileBarItemSub.AppearanceItem.Normal.Options.UseFont = true;
                tileBarItemSub.AppearanceItem.Normal.Options.UseForeColor = true;
                tileBarItemSub.AppearanceItem.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
                tileBarItemSub.AppearanceItem.Selected.BorderColor = System.Drawing.Color.White;
                tileBarItemSub.AppearanceItem.Selected.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tileBarItemSub.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
                tileBarItemSub.AppearanceItem.Selected.Options.UseBackColor = true;
                tileBarItemSub.AppearanceItem.Selected.Options.UseBorderColor = true;
                tileBarItemSub.AppearanceItem.Selected.Options.UseFont = true;
                tileBarItemSub.AppearanceItem.Selected.Options.UseForeColor = true;
                tileBarItemSub.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
                tileItemElement.ImageOptions.Image = global::CloudManage.Properties.Resources.zoom_32x32;
                tileItemElement.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
                tileItemElement.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
                tileItemElement.ImageOptions.ImageToTextIndent = 10;
                tileItemElement.Text = textSub;
                tileItemElement.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
                tileBarItemSub.Elements.Add(tileItemElement);
                tileBarItemSub.Id = 0;
                tileBarItemSub.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
                tileBarItemSub.Name = nameTileBarItemSub;
                int paddingLeft = 0;
                switch (numOfChineseCharacters)
                {
                    case 6:
                        paddingLeft = 40;
                        break;
                    case 7:
                        paddingLeft = 30;
                        break;
                    case 8:
                        paddingLeft = 20;
                        break;
                    default:
                        paddingLeft = 40;
                        break;
                }
                tileBarItemSub.Padding = new System.Windows.Forms.Padding(paddingLeft, 0, 0, 0);
                tileBarItemSub.Tag = tagTileBarItemSub;
                tileBarItemSub.Visible = false; //默认不可见
                tileBarGroup_sub.Items.Add(tileBarItemSub);

                countSideTileBarItemSub = this.tileBarGroup_sub.Items.Count;    //更新tileBarItemSub计数
                TotalNumDevice = this.Dt.Columns.Count - 1;  //更新检测设备总数
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        //以tag删除按钮
        public bool _deleteButton(string tagTileBarItem)
        {
            bool flag = false;
            try
            {
                if (!isAllNum(tagTileBarItem))
                {
                    return false;
                }
                if (countSideTileBarItem > 0)
                {
                    for (int i = 0; i < countSideTileBarItem; i++)
                    {
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                        string tag = temp.Tag.ToString();
                        if (tagTileBarItem.CompareTo(tag) == 0)
                        {
                            this.tileBarGroup_sideTileBar.Items.RemoveAt(i);
                            countSideTileBarItem = this.tileBarGroup_sideTileBar.Items.Count; //更新显示的tileBarItem的计数
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
        //以tag删除sub的按钮。
        //删除sub的按钮后，要读取新的表格赋值给Dt，新表格将删除的sub按钮对应的标志列去掉
        public bool _deleteButtonSub(string tagTileBarItemSub, DataTable dataTableNew)
        {
            this.Dt.Rows.Clear();
            this.Dt.Columns.Clear();    //清空旧表数据和结构
            this.Dt = dataTableNew;    //绑定新表

            bool flag = false;
            try
            {
                if (countSideTileBarItemSub > 0)
                {
                    for (int i = 0; i < countSideTileBarItemSub; i++)
                    {
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i);
                        string tag = temp.Tag.ToString();
                        if (tagTileBarItemSub.CompareTo(tag) == 0)
                        {
                            this.tileBarGroup_sub.Items.RemoveAt(i);
                            countSideTileBarItemSub = this.tileBarGroup_sub.Items.Count;    //更新tileBarItemSub计数
                            TotalNumDevice = this.Dt.Columns.Count - 1;    //更新检测设备总数
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

        //设置sideTileBar的某个Item的Num值
        public bool _setNum(string tagTileBarItem, string num)
        {
            bool flag = false;
            try
            {
                if (!isAllNum(tagTileBarItem) || !isAllNum(num))
                {
                    return false;
                }
                for (int i = 0; i < countSideTileBarItem; i++)
                {
                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                    string tag = temp.Tag.ToString();
                    if (tagTileBarItem.CompareTo(tag) == 0)
                    {
                        ((TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i)).Text = num;
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

        //设置sub的某个Item的textSub值
        public bool _setTextSub(string tagTileBarItemSub, string textSub)
        {
            bool flag = false;
            try
            {
                for (int i = 0; i < countSideTileBarItem; i++)
                {
                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i);
                    string tag = temp.Tag.ToString();
                    if (tagTileBarItemSub.CompareTo(tag) == 0)
                    {
                        ((TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i)).Text = textSub;
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

        //private bool _existsInArr(string []arr, string ele)
        //{
        //    return ((IList)arr).Contains(ele);
        //}


        //显示sub按钮隐藏多余的按钮
        public void _showSubItemHideRedundantItem()
        {
            TileBarItem temp = null;
            if (this.TotalNumDevice != this.countSideTileBarItemSub - 1)    //countSideTileBarItemSub比TotalNumDevice多一个“所有设备”
            {
                MessageBox.Show("_addSideTileBarItemSub未添加表中所有设备");
            }

            if (this.TagSelectedItem == "0")    //选中总览
            {
                for (int i = 0; i < this.TotalNumDevice; i++)
                {
                    temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i + 1);
                    temp.Visible = true;
                }
            }
            else
            {
                //从Dt中读取检测设备标志，实现检测设备按钮的显示
                int indexRow = 0;
                indexRow = Convert.ToInt32(this.TagSelectedItem) - 1;   //dt中的行index为tag-1
                DataRow dr = this.Dt.Rows[indexRow];
                for (int i = 0; i < this.TotalNumDevice; i++)
                {
                    temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i + 1);
                    int flag = Convert.ToInt32(dr[i + 1]);  //deviceEnable表中检测设备标志位
                    if (flag == 1)
                    {
                        temp.Visible = true;
                    }
                    else
                    {
                        temp.Visible = false;
                    }

                }
            }
        }

        //点击sideTileItem，显示对应设备子菜单
        private void tileBar_sideTileBar_ItemClick(object sender, TileItemEventArgs e)
        {
            TileBarItem temp = null;

            //原SelectedItem解绑DropDownControl
            for (int i = 0; i < countSideTileBarItem; i++)
            {
                temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                string tag = temp.Tag.ToString();
                if (tagSelectedItem.CompareTo(tag) == 0)
                {
                    temp.DropDownControl = null;
                    break;
                }
            }

            TagSelectedItem = (string)this.tileBar_sideTileBar.SelectedItem.Tag; //更新当前选中按钮变量
            for (int i = 0; i < countSideTileBarItem; i++)
            {
                temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                string tag = temp.Tag.ToString();
                if (tagSelectedItem.CompareTo(tag) == 0)
                {
                    _showSubItemHideRedundantItem();
                    temp.DropDownControl = this.tileBarDropDownContainer_sub;    //重新绑定 
                    this.tileBar_sideTileBar.ShowDropDown(temp);   //立即显示子菜单
                    break;
                }
            }
        }

        //点击sideTileItemSub事件
        public delegate void TileItemWithSubClickedHanlder(object sender, EventArgs e);
        public event TileItemWithSubClickedHanlder sideTileBarItemWithSubClicked; //自定义事件，将SideTileBarControl的itemSelectedChanged事件传出

        private void tileBar_sideTileBar_sub_ItemClick(object sender, TileItemEventArgs e)
        {
            TagSelectedItemSub = (string)this.tileBar_sideTileBar_sub.SelectedItem.Tag; //更新当前选中按钮变量
            MessageBox.Show("sub按钮总数= " + countSideTileBarItemSub.ToString());
            MessageBox.Show("该按钮的tag= " + TagSelectedItemSub);

            if (sideTileBarItemWithSubClicked != null)
            {
                sideTileBarItemWithSubClicked(sender, new EventArgs());
            }
        }
    }



}
