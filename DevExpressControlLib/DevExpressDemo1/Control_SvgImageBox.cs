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
    public partial class Control_SvgImageBox : DevExpress.XtraEditors.XtraForm
    {
        public Control_SvgImageBox()
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


        //================================================================================================
        /**
        *svgImageBox7.Selection出现奇怪的现象。点击空白非seat区域时，Selection会变为Empty，Selection.Count变为0
        *导致点击空白区域时会发生ListBox清空的情况
        */

        //鼠标移入图形时触发
        private void svgImageBox7_QueryHoveredItem(object sender, SvgImageQueryHoveredItemEventArgs e)
        {
            if (e.HoveredItem != null && !CheckSeatId(e.HoveredItem))
                e.HoveredItem = e.HoveredItem.FindAncestors(a => CheckSeatId(a)).FirstOrDefault();
        }


        //检查鼠标点击的位置是否是seat
        bool CheckSeatId(SvgImageItem svgImageItem)
        {
            return svgImageItem.Id != null && svgImageItem.Id.StartsWith("seat");
        }

        private void svgImageBox7_SelectionChanged(object sender, EventArgs e)
        {
            //bug：点击空白处会清空ListBox
            //原因：无条件清空ListBox,点击空白处ListBox被清空但Selection为Empty
            //listBox_chosenChair.Items.Clear();
            //foreach (var item in svgImageBox7.Selection)
            //{
            //    if (item.Id.Contains("seat"))
            //    {
            //        string seatName = "seat num: " + item.Id;
            //        listBox_chosenChair.Items.Add(seatName);
            //    }

            //}


            if (svgImageBox7.Selection.Count!=0)
            {
                //Unselect某个seat时ListBox无法去掉某个seat
                //int len = svgImageBox7.Selection.Count;
                //string seatName = "seat num: " + svgImageBox7.Selection.ElementAt(len - 1).Id;
                //listBox_chosenChair.Items.Add(seatName);

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

        }
        private void simpleButton_clear_Click(object sender, EventArgs e)
        {
            listBox_chosenChair.Items.Clear();
            if (svgImageBox7.Selection.Count != 0)
            {
                foreach (var item in svgImageBox7.Selection)
                {
                    svgImageBox7.Unselect(item);
                }
            }
        }

        private void svgImageBox1_MouseEnter(object sender, EventArgs e)
        {
            svgImageBox1.SizeMode = SvgImageSizeMode.Zoom;
        }

        private void svgImageBox1_MouseLeave(object sender, EventArgs e)
        {
            svgImageBox1.SizeMode = SvgImageSizeMode.Clip;
        }

        private void svgImageBox2_MouseEnter(object sender, EventArgs e)
        {
            svgImageBox2.SizeMode = SvgImageSizeMode.Zoom;

        }

        private void svgImageBox2_MouseLeave(object sender, EventArgs e)
        {
            svgImageBox2.SizeMode = SvgImageSizeMode.Clip;

        }

        private void svgImageBox3_MouseEnter(object sender, EventArgs e)
        {
            svgImageBox3.SizeMode = SvgImageSizeMode.Zoom;

        }

        private void svgImageBox3_MouseLeave(object sender, EventArgs e)
        {
            svgImageBox3.SizeMode = SvgImageSizeMode.Clip;

        }

        private void svgImageBox4_MouseEnter(object sender, EventArgs e)
        {
            svgImageBox4.SizeMode = SvgImageSizeMode.Zoom;

        }

        private void svgImageBox4_MouseLeave(object sender, EventArgs e)
        {
            svgImageBox4.SizeMode = SvgImageSizeMode.Clip;

        }
    }
}