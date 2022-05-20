using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManage
{
    public partial class XtraForm_gridControl : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm_gridControl()
        {
            InitializeComponent();
            initGridControl();
        }

        private void initGridControl()
        {
            //创建一个datatable
            DataTable dt = new DataTable("dtName");

            //添加列
            dt.Columns.Add("col1", typeof(String)); //Add()参数：列名,该列存放的数据的类型
            dt.Columns.Add("col2", typeof(String));

            //添加行
            for(int i = 0; i < 5; i++)
            {
                DataRow dr = dt.NewRow();   //创建dt的一个行对象dr
                dr["col1"] = "str1";        //给dr的两个列赋值
                dr["col2"] = "str2";
                dt.Rows.Add(dr);            //将行dr添加到表dt中
            }



            //将dt绑定到grid
            gridControl1.DataSource = dt;

            /**
             *在UI设置：
             *          点击change view 改为 TileView
             *          点击run designer
             *          在Columns页面添加列，将tileviewColumn的filedname设为dt的列名（filedname要同列名相同否则不显示）
             *          在Tile Template设置要展示的表格的样式：将tileviewColumn拖曳到tile里，tile就是当前这个表格的一个小方块。点击某个tileviewColumn可在右侧的Properties中设置高度、宽度、颜色等
             *          在layout里可以查看设置的tile的形式。可在layout的Settings设置grid中显示tile的长度、高度等
             *          
             *          在Views右侧的Properties中的Appearance的colorNormal、colorFocused、colorSelected设置tile普通、悬停、选中时的颜色
             *          
             *          
             */

        }

    }
}