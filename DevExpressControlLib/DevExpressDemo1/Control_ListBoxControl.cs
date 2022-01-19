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
using DevExpress.Utils;
namespace DevExpressDemo1
{
    public partial class Control_ListBoxControl : DevExpress.XtraEditors.XtraForm
    {
        public Control_ListBoxControl()
        {
            InitializeComponent();
            RatingContextButton ratingContextButton = new RatingContextButton();
            this.listBoxControl4.ContextButtons.Add(ratingContextButton);
        }

        private void listBoxControl4_ContextButtonClick(object sender, ContextItemClickEventArgs e)
        {
            MessageBox.Show("context button clicked");
        }

        private void Control_ListBoxControl_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“_111DataSet.students”中。您可以根据需要移动或删除它。
            this.studentsTableAdapter.Fill(this._111DataSet.students);

        }
    }
}