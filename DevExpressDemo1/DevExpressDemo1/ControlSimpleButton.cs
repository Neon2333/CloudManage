using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpressDemo1
{
    public partial class ControlSimpleButton : DevExpress.XtraEditors.XtraForm
    {
        int indexSimpleButton20ImageChanged = 0;
        int indexSimpleButton21SvgImageChanged = 0;
        public ControlSimpleButton()
        {
            InitializeComponent();
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            indexSimpleButton20ImageChanged = (++indexSimpleButton20ImageChanged) % 3;  //不要写成(indexSimpleButton20ImageChanged++) % 3
            if (indexSimpleButton20ImageChanged == 0)
            {
                this.simpleButton20.ImageOptions.ImageIndex = 0;

            }else if (indexSimpleButton20ImageChanged == 1)
            {
                this.simpleButton20.ImageOptions.ImageIndex = 1;
            }else if (indexSimpleButton20ImageChanged == 2)
            {
                this.simpleButton20.ImageOptions.ImageIndex = 2;
            }

        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            indexSimpleButton21SvgImageChanged = (++indexSimpleButton21SvgImageChanged) % 4;  
            if (indexSimpleButton21SvgImageChanged == 0)
            {
                this.simpleButton21.ImageOptions.SvgImage = global::DevExpressDemo1.Properties.Resources.actions_arrow1up;
            }
            else if (indexSimpleButton21SvgImageChanged == 1)
            {
                this.simpleButton21.ImageOptions.SvgImage = global::DevExpressDemo1.Properties.Resources.actions_arrow1right;
            }
            else if (indexSimpleButton21SvgImageChanged == 2)
            {
                this.simpleButton21.ImageOptions.SvgImage = global::DevExpressDemo1.Properties.Resources.actions_arrow1down;
            }
            else if (indexSimpleButton21SvgImageChanged == 3)
            {
                this.simpleButton21.ImageOptions.SvgImage = global::DevExpressDemo1.Properties.Resources.actions_arrow1left;
            }
        }
    }
}
