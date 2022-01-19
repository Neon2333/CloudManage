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

namespace DevExpressDemo1
{
    public partial class Control_PictureEdit : DevExpress.XtraEditors.XtraForm
    {
        public Control_PictureEdit()
        {
            InitializeComponent();
            
        }

        //双击启用编辑图片
        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            pictureEdit1.ShowImageEditorDialog();
        }

        private void pictureEdit1_TakePictureDialogShowing(object sender, DevExpress.XtraEditors.Camera.TakePictureDialogShowingEventArgs e)
        {
            MessageBox.Show("take picture dialog showing");
        }

        private void pictureEdit1_TakePictureDialogClosed(object sender, DevExpress.XtraEditors.Camera.TakePictureDialogClosedEventArgs e)
        {
            MessageBox.Show("take picture dialog closed");

        }

        private void pictureEdit1_ImageEditorDialogShowing(object sender, DevExpress.XtraEditors.ImageEditor.ImageEditorDialogShowingEventArgs e)
        {
            MessageBox.Show("image editor showing");

        }

        private void pictureEdit1_ImageEditorDialogClosed(object sender, DevExpress.XtraEditors.ImageEditor.ImageEditorDialogClosedEventArgs e)
        {
            MessageBox.Show("image editor closed");

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pictureEdit1.ShowTakePictureDialog();   //调用摄像头拍照
        }
    }
}