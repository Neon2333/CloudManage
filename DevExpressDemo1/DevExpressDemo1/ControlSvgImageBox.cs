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
using DevExpress;

namespace DevExpressDemo1
{
    public partial class ControlSvgImageBox : DevExpress.XtraEditors.XtraForm
    {
        public ControlSvgImageBox()
        {
            InitializeComponent();

            //访问根item
            //svgImageBox5.RootItems[0].Items[1].Visible = false;
            //svgImageBox5.RootItems[0].Items[0].Appearance.Normal.FillColor = Color.Aqua;

            //按照item的Id查找，返回SvgImageItem的集合
            //var itemsId = svgImageBox5.FindItems(item => item.Id != null && item.Id.Equals("13"));
            //itemsId.ForEach(item => item.Visible = false);

            //只有一个Tag符合的，按照item的Tag查找，返回一个SvgImageItem
            //var itemsTag = svgImageBox5.FindItems(item => item.Tag != null && item.Tag.Equals("shining"));
            //itemsTag.ForEach(item => item.Appearance.Normal.FillColor = Color.DarkRed);

            //var itemTag = svgImageBox5.FindItem(item => item.Tag != null && item.Tag.Equals("shining"));
            //itemTag.Appearance.Normal.FillColor = Color.DarkRed;

            //===========================================================================================================

            //通过item.Selected属性get,set被选择的item
            //var itemsTag = svgImageBox6.FindItems(item => item.Id != null && item.Id.Equals("0"));
            //itemsTag.ForEach(item => item.Selected=true);

            //通过Select(item)设定被选择的item
            //var itemId = svgImageBox6.FindItem(item => item.Id != null && item.Id.Equals("1"));
            //svgImageBox6.Select(itemId);

            
        }

        //
        private void svgImageBox6_QueryHoveredItem(object sender, SvgImageQueryHoveredItemEventArgs e)
        {
            //svgImageBox6.ItemAppearance.Normal.BorderColor = Color.Red;

        }

        //选中的item改变时触发
        private void svgImageBox6_SelectionChanged(object sender, EventArgs e)
        {
            //通过Selection获取被选择的item
            foreach (var item in svgImageBox6.Selection)
            {
                MessageBox.Show("choose item is " + item.Id);
            }
        }

        //光标离开图形时触发
        private void svgImageBox6_ItemEnter(object sender, SvgImageItemEventArgs e)
        {
            //MessageBox.Show("mouse cursor leave");
        }

        //鼠标光标进入图形时触发
        private void svgImageBox6_ItemLeave(object sender, SvgImageItemEventArgs e)
        {
            //MessageBox.Show("mouse cursor enter");
        }

        private void svgImageBox7_QueryHoveredItem(object sender, SvgImageQueryHoveredItemEventArgs e)
        {
            if (e.HoveredItem != null && !CheckSeatId(e.HoveredItem))
                e.HoveredItem = e.HoveredItem.FindAncestors(a => CheckSeatId(a)).FirstOrDefault();
        }

        bool CheckSeatId(SvgImageItem svgImageItem)
        {
            return svgImageItem.Id != null && svgImageItem.Id.StartsWith("seat");
        }

        private void svgImageBox7_SelectionChanged(object sender, EventArgs e)
        {
            listBox_chosenChair.Items.Clear();
            foreach (var item in svgImageBox7.Selection)
            {
                if (item.Id.Contains("seat"))
                {
                    string seatName = "seat num: " + item.Id;
                    listBox_chosenChair.Items.Add(seatName);
                }
                
            }
        }

        private void simpleButton_clear_Click(object sender, EventArgs e)
        {
            listBox_chosenChair.Items.Clear();

        }
    }
}