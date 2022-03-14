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
        private bool UseDtInitSideTileBarWithSub = true;     //是否通过表初始化侧边栏
        private DataTable DT = new DataTable();     //初始化侧边栏用表
        private DataTable DTSUB = new DataTable();     //初始化侧边栏子菜单用表
        //表DT的字段
        private string ColTagDT = String.Empty;
        private string ColTextDT = String.Empty;
        private string ColNumDT = String.Empty;
        //表DTSUB的字段
        private string ColTagDTSUB = String.Empty;
        private string ColTextDTSUB = String.Empty;

        private string TagSelectedItem = String.Empty;      //当前选中的产线的id
        private string TagItemWhichSubItemBeenSelected = String.Empty;  //当前被单选选中设备的产线的id，记录上一次被单选设备的产线，与当前选中产线进行对比
        private string TagSelectedItemSub = String.Empty;   //总览tag="000"，添加按钮时从tag="001"开始
        public int countSideTileBarItem = 0;    //sideTileBar中显示的items计数。包括“总览”按钮
        public int countSideTileBarItemSub = 0; //sideTileBarSub中items计数
        public int TotalNumDevice = 0;     //检测设备总数
        public SideTileBarControlWithSub()
        {
            InitializeComponent();

            countSideTileBarItem = this.tileBarGroup_sideTileBar.Items.Count;
            TotalNumDevice = Global.dtTestingDeviceName.Rows.Count;
            countSideTileBarItemSub = this.tileBarGroup_sub.Items.Count;

            TagSelectedItem = (string)this.tileBar_sideTileBar.SelectedItem.Tag;    //000
            TagSelectedItemSub = (string)this.tileBar_sideTileBar_sub.SelectedItem.Tag;     //000

        }

        public DataTable dtInitSideTileBarWithSub
        {
            set
            {
                this.DT = value;
            }
        }
        public DataTable dtSubInitSideTileBarWithSub
        {
            set
            {
                this.DTSUB = value;
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

        //“所有设备”按钮显示
        public Boolean showAllDevices
        {
            get
            {
                return this.tileBarItem_sub0.Visible;
            }
            set
            {
                this.tileBarItem_sub0.Visible = value;
            }
        }

        //是否使用表dataTableTileBarSub获取子菜单中检测设备使能
        public Boolean useDtInitSideTileBarWithSub
        {
            get
            {
                return this.UseDtInitSideTileBarWithSub;
            }
            set
            {
                this.UseDtInitSideTileBarWithSub = value;
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

        //获取被选中subItem的item的id
        public string tagItemWhichSubItemBeenSelected
        {
            get
            {
                return this.TagItemWhichSubItemBeenSelected;
            }
        }

        //获取被选中的subItemd的tag
        public string tagSelectedItemSub
        {
            get
            {
                return this.TagSelectedItemSub;
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

        public string colTagDTSUB
        {
            get
            {
                return this.ColTagDTSUB;
            }
            set
            {
                this.ColTagDTSUB = value;
            }
        }

        public string colTextDTSUB
        {
            get
            {
                return this.ColTextDTSUB;
            }
            set
            {
                this.ColTextDTSUB = value;
            }
        }

        //初始化侧边栏
        //第一级侧边栏采用添加、删除item的方式
        //第二级侧边栏中添加item的数量是固定的，由表device决定。不同的只是最后根据device_config决定各个item的Visible的不同
        public void _initSideTileBarWithSub()
        {
            if (UseDtInitSideTileBarWithSub)
            {
                //添加产线按钮
                string tag = String.Empty;
                string name = String.Empty;
                string text = String.Empty;
                string num = String.Empty;
                int totalNumTemp = 0;

                for (int i = 0; i < this.DT.Rows.Count; i++)
                {
                    if (this.ColTagDT != null)
                        tag = (string)this.DT.Rows[i][this.ColTagDT];
                    name = "tileBarItem" + (i + 1).ToString();   //总览是tileBarItem0
                    if (this.ColTextDT != null)
                        text = (string)this.DT.Rows[i][this.ColTextDT];
                    if (this.ColNumDT != null)
                    {
                        num = this.DT.Rows[i][this.ColNumDT].ToString();
                        totalNumTemp++;
                    }
                    //num = Convert.ToString(this.DT.Rows[i][colNum]);  //可以。Convert.toString/toString/(string)区别？
                    //num = (string)this.DT.Rows[i][colNum];    //无法将double转成string
                    this._addSideTileBarItem(new TileBarItem(), tag, name, text, num);   //向第一级侧边栏添加item
                }

                _removeSideTileBarItemNotInDT();    //删除侧边栏中已被删除的产线

                this._setUpperRight("000", totalNumTemp.ToString());
                this.TagItemWhichSubItemBeenSelected = "000";

                //一次性添加表device中的所有检测设备按钮
                for (int i = 0; i < this.DTSUB.Rows.Count; i++)
                {
                    string tagTemp = String.Empty;
                    string nameTemp = String.Empty;
                    if (this.ColTagDTSUB != null)
                        tagTemp = (string)this.DTSUB.Rows[i][this.ColTagDTSUB];
                    if (this.ColTextDTSUB != null)
                        nameTemp = (string)this.DTSUB.Rows[i][this.ColTextDTSUB];
                    bool flag = this._addSideTileBarItemSub(new TileBarItem(), tagTemp, "tileBarItem_sub" + (i + 1).ToString(), nameTemp, Encoding.Default.GetBytes(nameTemp).Length / 2);
                }
                //添加“占位”subItem
                bool flag1 = this._addSideTileBarItemSub(new TileBarItem(), "-1", "tileBarItem_sub-1", "占位", Encoding.Default.GetBytes("占位").Length / 2);

                //根据DTSUB中各个设备的使能，决定第二级侧边栏中item的Visible
                this._showSubItemHideRedundantItem();
            }
            else
            {
                MessageBox.Show("useDtInitSideTileBarWithSub为false");
            }

        }

        //通过Tag获得Text
        public string _getItemTextUseTag(string tagTileBarItem)
        {
            DataRow[] dr = null;
            if (_isAllNum(tagTileBarItem) == true && this.DT.Rows.Count != 0)
            {
                dr = this.DT.Select(this.ColTagDT + "='" + tagTileBarItem + "'");
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

                //更新TagSelectedItem
                if (this.TagSelectedItem == this.TagItemWhichSubItemBeenSelected)
                {
                    this._selectedItemSub(this.TagSelectedItemSub);
                }
                else
                {
                    this._selectedItemSub("-1");
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
                        this.tileBar_sideTileBar_sub.SelectedItem = temp;
                        if (tagTemp != "-1")    //若选中的是“占位”，TagSelectedItemSub不更新
                        {
                            TagSelectedItemSub = tagTemp;
                            TagItemWhichSubItemBeenSelected = TagSelectedItem;                          //更新TagItemWhichSubItemBeenSelected
                        }
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
                        this.TagSelectedItem = (string)((TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i)).Tag;
                        flag = true;
                    }
                }

                if (this.TagSelectedItem == this.TagItemWhichSubItemBeenSelected)
                {
                    this._selectedItemSub(this.TagSelectedItemSub);
                }
                else
                {
                    this._selectedItemSub("-1");
                }
                return flag;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        //通过index选中subItem
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
                        TagItemWhichSubItemBeenSelected = TagSelectedItem;                          //更新TagItemWhichSubItemBeenSelected
                        if (((string)((TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i)).Tag) != "-1")
                            this.TagSelectedItemSub = (string)((TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i)).Tag;
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

        //向第一级侧边栏添加按钮、删除按钮、修改按钮num值
        //
        public bool _addSideTileBarItem(TileBarItem tileBarItem, string tagTileBarItem, string nameTileBarItem, string text, string num)
        {
            TotalNumDevice = Global.dtTestingDeviceName.Rows.Count;  //更新当前的设备数
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
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                        //tag、itemName、text相同无法添加
                        string tag = temp.Tag.ToString();
                        string itemName = temp.Name;
                        if (tagTileBarItem.CompareTo(tag) == 0 || nameTileBarItem.CompareTo(itemName) == 0) //tag或name重复
                        {
                            //若添加的item已存在，则不再添加而是修改其num值和text值
                            this._setUpperRight(tagTileBarItem, num);
                            this._setBottomLeft(tagTileBarItem, text);
                            return true;

                            //若添加的item已存在，则将该item删除，重新添加（上方修改num值可行，但除了修改num值还需修改text值）

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
                //tileBarItem.DropDownOptions.BackColorMode = DevExpress.XtraBars.Navigation.BackColorMode.UseBeakColor;
                //tileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
                tileBarItem.DropDownOptions.BackColorMode = DevExpress.XtraBars.Navigation.BackColorMode.UseBeakColor;
                tileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.White;
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

                //显示“总览”时，选中“总览”
                //不显示“总览”时，TagSelectedItem初始化默认选中“产线1”
                //子菜单：不论是否显示“所有设备”初始都默认选中“所有设备”
                if (this.showOverview == true)
                {
                    TagSelectedItem = "000";
                    //this.TagItemWhichSubItemBeenSelected = "000";
                }
                else if (this.showOverview == false && this.countSideTileBarItem == 2)
                {
                    this.tileBar_sideTileBar.SelectedItem = tileBarItem;
                    //this.TagItemWhichSubItemBeenSelected = (string)this.tileBar_sideTileBar.SelectedItem.Tag;   
                    //this.TagSelectedItem = (string)this.tileBar_sideTileBar.SelectedItem.Tag;
                    //this.TagItemWhichSubItemBeenSelected = (string)tileBarItem.Tag;
                    this.TagSelectedItem = (string)tileBarItem.Tag;
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

                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                    string tag = temp.Tag.ToString();
                    string itemName = temp.Name;

                    for (int j = 0; j < this.DT.Rows.Count; j++)
                    {
                        if (tag.CompareTo((string)this.DT.Rows[j][this.colTagDT]) == 0)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag == false)
                    {
                        this._removeItemByTag(tag);
                    }


                }
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
                            //若添加的item已存在，则不再添加而是修改其num值
                            this._setUpperRightSub(tagTileBarItemSub, textSub);
                            return true;
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
                if (UseDtInitSideTileBarWithSub == true)
                {
                    tileBarItemSub.Visible = false; //读检测设备使能表的话，就让所有添加的时候不可见。通过_showSubItemHideRedundantItem()设置子菜单item显示
                }
                else
                {
                    tileBarItemSub.Visible = true;  //不读表的话，就直接全部可见
                }
                tileBarGroup_sub.Items.Add(tileBarItemSub);

                countSideTileBarItemSub = this.tileBarGroup_sub.Items.Count;    //更新tileBarItemSub计数
                TotalNumDevice = Global.dtTestingDeviceName.Rows.Count;  //更新检测设备总数

                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
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
                        TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                        string tag = temp.Tag.ToString();
                        if (tagTileBarItem.CompareTo(tag) == 0)
                        {
                            this.tileBarGroup_sideTileBar.Items.RemoveAt(i);
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
        public bool _deleteButtonSub(string tagTileBarItemSub)
        {
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
                            TotalNumDevice = Global.dtTestingDeviceName.Rows.Count;    //更新检测设备总数
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

        //设置sideTileBar的某个Item的右上角text值
        public bool _setUpperRight(string tagTileBarItem, string text)
        {
            bool flag = false;
            try
            {
                if (!_isAllNum(tagTileBarItem) || !_isAllNum(text))
                {
                    return false;
                }
                for (int i = 0; i < countSideTileBarItem; i++)
                {
                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                    string tag = temp.Tag.ToString();
                    if (tagTileBarItem.CompareTo(tag) == 0)
                    {
                        ((TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i)).Text = text;
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

        public bool _setBottomLeft(string tagTileBarItem, string text)
        {
            bool flag = false;
            try
            {
                if (!_isAllNum(tagTileBarItem) || !_isAllNum(text))
                {
                    return false;
                }
                for (int i = 0; i < countSideTileBarItem; i++)
                {
                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                    string tag = temp.Tag.ToString();
                    if (tagTileBarItem.CompareTo(tag) == 0)
                    {
                        ((TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i)).Elements[1].Text = text;    //tileBarItem.Elements[0]-tileItemElementNum,tileBarItem.Elements[1]-tileItemElementText,tileBarItem.Elements[2]-tileItemElementIcon
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

        //设置sub的某个Item的右上角textSub值
        public bool _setUpperRightSub(string tagTileBarItemSub, string textSub)
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

        public bool _setBottomLeftSub(string tagTileBarItem, string text)
        {
            bool flag = false;
            try
            {
                if (!_isAllNum(tagTileBarItem) || !_isAllNum(text))
                {
                    return false;
                }
                for (int i = 0; i < countSideTileBarItem; i++)
                {
                    TileBarItem temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i);
                    string tag = temp.Tag.ToString();
                    if (tagTileBarItem.CompareTo(tag) == 0)
                    {
                        ((TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i)).Elements[1].Text = text;    //tileBarItem.Elements[0]-tileItemElementNum,tileBarItem.Elements[1]-tileItemElementText,tileBarItem.Elements[2]-tileItemElementIcon
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
            if (this.UseDtInitSideTileBarWithSub == true)
            {
                if (this.showAllDevices == true && (this.TotalNumDevice != this.countSideTileBarItemSub - 2))    //countSideTileBarItemSub比TotalNumDevice多一个“所有设备”和“占位”
                {
                    MessageBox.Show("_addSideTileBarItemSub未添加表中所有设备");
                }

                if (this.showOverview == true)
                {
                    if (this.TagSelectedItem == "000")   //选中总览
                    {
                        for (int i = 0; i < this.TotalNumDevice; i++)
                        {
                            temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i + 1);
                            temp.Visible = true;
                        }
                    }
                    else
                    {
                        //从dtDeviceConfig中读取检测设备标志，实现检测设备按钮的显示
                        DataRow dr = null;
                        for (int i = 0; i < Global.dtDeviceConfig.Rows.Count; i++)
                        {
                            if ((string)Global.dtDeviceConfig.Rows[i]["LineNO"] == this.TagSelectedItem)
                            {
                                dr = Global.dtDeviceConfig.Rows[i];
                                break;
                            }
                        }
                        for (int i = 0; i < this.TotalNumDevice; i++)
                        {
                            temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i + 1);
                            int flag = Convert.ToInt32(dr[i + 2]);  //deviceConfig表中检测设备标志位
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
                else
                {
                    if (this.TagSelectedItem != "000")
                    {
                        //从dtDeviceConfig中读取检测设备标志，实现检测设备按钮的显示
                        DataRow dr = null;
                        for (int i = 0; i < Global.dtDeviceConfig.Rows.Count; i++)
                        {
                            if ((string)Global.dtDeviceConfig.Rows[i]["LineNO"] == this.TagSelectedItem)
                            {
                                dr = Global.dtDeviceConfig.Rows[i];
                                break;
                            }
                        }
                        if (dr != null)
                        {
                            for (int i = 0; i < this.TotalNumDevice; i++)
                            {
                                temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i + 1);
                                int flag = Convert.ToInt32(dr[i + 2]);  //deviceConfig表中检测设备标志位从dr[2]开始
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
                }

            }
            else
            {
                //不读表dtDeviceConfig添加检测设备
            }

        }

        //传出点击sideTileItemSub事件
        public delegate void TileItemWithSubClickedItemHanlder(object sender, EventArgs e);
        public event TileItemWithSubClickedItemHanlder sideTileBarItemWithSubClickedItem; //自定义事件，将SideTileBarControl的itemSelectedChanged事件传出

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

            TagSelectedItem = (string)this.tileBar_sideTileBar.SelectedItem.Tag; //更新当前选中主菜单按钮
            for (int i = 0; i < countSideTileBarItem; i++)
            {
                temp = (TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i);
                string tag = temp.Tag.ToString();
                if (tagSelectedItem.CompareTo(tag) == 0)
                {
                    _showSubItemHideRedundantItem();
                    //if(this.showAllDevices == true)
                    //{
                    //    this.tileBar_sideTileBar.SelectedItem = this.tileBarItem0;
                    //    this.TagSelectedItemSub = (string)this.tileBar_sideTileBar.SelectedItem.Tag;
                    //}
                    //else if(this.showAllDevices == false && this.countSideTileBarItemSub > 1)
                    //{
                    //    this.tileBar_sideTileBar.SelectedItem = this.tileBar_sideTileBar1;
                    //    this.TagSelectedItemSub = (string)this.tileBar_sideTileBar.SelectedItem.Tag;
                    //}

                    temp.DropDownControl = this.tileBarDropDownContainer_sub;    //重新绑定 
                    this.tileBar_sideTileBar.ShowDropDown(temp);   //立即显示子菜单
                    break;
                }
            }

            //选中产线时，若当前选中不是TagItemWhichSubItemBeenSelected则选中“占位”的subItem；否则，恢复选中TagSelectedItemSub
            if (this.TagSelectedItem == this.TagItemWhichSubItemBeenSelected)
            {
                this._selectedItemSub(this.TagSelectedItemSub);
            }
            else
            {
                this._selectedItemSub("-1");
            }

            //传出事件
            if (sideTileBarItemWithSubClickedItem != null)
            {
                sideTileBarItemWithSubClickedItem(sender, new EventArgs());
            }
        }

        //传出点击sideTileItemSub事件
        public delegate void TileItemWithSubClickedSubItemHanlder(object sender, EventArgs e);
        public event TileItemWithSubClickedSubItemHanlder sideTileBarItemWithSubClickedSubItem; //自定义事件，将SideTileBarControl的itemSelectedChanged事件传出

        private void tileBar_sideTileBar_sub_ItemClick(object sender, TileItemEventArgs e)
        {
            TagSelectedItemSub = (string)this.tileBar_sideTileBar_sub.SelectedItem.Tag; //更新当前选中子菜单按钮(可选中的一定不是“占位”)
            TagItemWhichSubItemBeenSelected = TagSelectedItem;                          //更新TagItemWhichSubItemBeenSelected
            //MessageBox.Show("sub按钮总数= " + countSideTileBarItemSub.ToString());
            //MessageBox.Show("该按钮的tag= " + TagSelectedItemSub);

            //传出事件
            if (sideTileBarItemWithSubClickedSubItem != null)
            {
                sideTileBarItemWithSubClickedSubItem(sender, new EventArgs());
            }

            this.tileBar_sideTileBar.HideDropDownWindow(false); //点击子菜单按钮后立即隐藏子菜单
        }
    }



}
