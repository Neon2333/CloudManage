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
        private DataTable DTSUB = new DataTable();     //初始化侧边栏用表
        //表DT的字段
        private string ColTagDT = String.Empty;
        private string ColTextDT = String.Empty;
        private string ColNumDT = String.Empty;
        //表DTSUB的字段
        private string ColTagDTSUB = String.Empty;
        private string ColTextDTSUB = String.Empty;

        private string TagSelectedItem = String.Empty;
        private string TagSelectedItemSub = String.Empty;   //总览tag="0"，添加按钮时从tag="1"开始
        public int countSideTileBarItem = 0;    //sideTileBar中显示的items计数。包括“总览”按钮
        public int countSideTileBarItemSub = 0; //sideTileBarSub中items计数
        public int TotalNumDevice = 0;     //检测设备总数
        public SideTileBarControlWithSub()
        {
            InitializeComponent();

            countSideTileBarItem = this.tileBarGroup_sideTileBar.Items.Count;
            TotalNumDevice = Global.dtTestingDeviceName.Rows.Count;  
            countSideTileBarItemSub = this.tileBarGroup_sub.Items.Count;

            TagSelectedItem = (string)this.tileBar_sideTileBar.SelectedItem.Tag;
            TagSelectedItemSub = (string)this.tileBar_sideTileBar_sub.SelectedItem.Tag;

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
        //获取Sub中被选中item的tag
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
                    if(this.ColTagDT!=null)
                        tag = (string)this.DT.Rows[i][this.ColTagDT];
                    name = "tileBarItem" + (i + 1).ToString();   //总览是tileBarItem0
                    if(this.ColTextDT != null)
                        text = (string)this.DT.Rows[i][this.ColTextDT];
                    if (this.ColNumDT != null)
                    {
                        num = this.DT.Rows[i][this.ColNumDT].ToString();
                        totalNumTemp += Convert.ToInt32(num);
                    }
                    //num = Convert.ToString(this.DT.Rows[i][colNum]);  //可以。Convert.toString/toString/(string)区别？
                    //num = (string)this.DT.Rows[i][colNum];    //无法将double转成string
                    this._addSideTileBarItem(new TileBarItem(), tag, name, text, num);   //添加item
                }
                if (this.showOverview == true)
                {
                    this._setNum("000", totalNumTemp.ToString());
                }

                //添加所有检测设备按钮
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
                        this.TagSelectedItem = (string)((TileBarItem)this.tileBarGroup_sideTileBar.Items.ElementAt(i)).Tag; 
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

        //在sideTileBar尾部依次添加按钮
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

                //不显示“总览”时，初始化默认选中“产线1”
                if (this.showOverview == false && this.countSideTileBarItem == 2)
                {
                    this.tileBar_sideTileBar.SelectedItem = tileBarItem;
                    this.TagSelectedItem = (string)this.tileBar_sideTileBar.SelectedItem.Tag;
                }

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

                //显示“所有设备”时，初始化默认选中“所有设备”
                //不显示“所有设备”时，选中“所有设备”但是不显示
                //if (this.showAllDevices == false && this.countSideTileBarItemSub == 2)
                //{
                //    this.tileBar_sideTileBar_sub.SelectedItem = tileBarItemSub;
                //    this.TagSelectedItemSub = (string)this.tileBar_sideTileBar_sub.SelectedItem.Tag;
                //}
                this._selectedItemSub(0);  

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

        //设置sideTileBar的某个Item的Num值
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
            if (this.UseDtInitSideTileBarWithSub == true)
            {
                if (this.showAllDevices == true && (this.TotalNumDevice != this.countSideTileBarItemSub - 1))    //countSideTileBarItemSub比TotalNumDevice多一个“所有设备”
                {
                    MessageBox.Show("_addSideTileBarItemSub未添加表中所有设备");
                }

                if (this.showOverview == true)   
                {
                    if(this.TagSelectedItem == "000")   //选中总览
                    {
                        for (int i = 0; i < this.TotalNumDevice; i++)
                        {
                            temp = (TileBarItem)this.tileBarGroup_sub.Items.ElementAt(i + 1);
                            temp.Visible = true;
                        }

                        this._selectedItemSub(0);   //showAllDevice==true时重新选中“所有设备”,为false时不显示选中
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
                        this._selectedItemSub(0);
                    }
                }
                else
                {
                   if(this.TagSelectedItem != "000")
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
                        this._selectedItemSub(0);
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
            TagSelectedItemSub = (string)this.tileBar_sideTileBar_sub.SelectedItem.Tag; //更新当前选中子菜单按钮
            //MessageBox.Show("sub按钮总数= " + countSideTileBarItemSub.ToString());
            //MessageBox.Show("该按钮的tag= " + TagSelectedItemSub);

            if (sideTileBarItemWithSubClickedSubItem != null)
            {
                sideTileBarItemWithSubClickedSubItem(sender, new EventArgs());
            }

            this.tileBar_sideTileBar.HideDropDownWindow(false); //点击子菜单按钮后立即隐藏子菜单
        }
    }



}
