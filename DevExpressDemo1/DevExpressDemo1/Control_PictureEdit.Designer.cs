namespace DevExpressDemo1
{
    partial class Control_PictureEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::DevExpressDemo1.Properties.Resources.f2d7c2a55ecf9e4a9ac5eda02e3a7cc86c78bd3e9fae84f3af5e81972caf469a;
            this.pictureEdit1.Location = new System.Drawing.Point(21, 21);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.OptionsMask.MaskLayoutMode = DevExpress.XtraEditors.Controls.PictureEditMaskLayoutMode.MiddleCenter;
            this.pictureEdit1.Properties.OptionsMask.MaskType = DevExpress.XtraEditors.Controls.PictureEditMaskType.Circle;
            this.pictureEdit1.Properties.OptionsMask.Size = new System.Drawing.Size(1000, 1000);
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Always;
            this.pictureEdit1.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.True;
            this.pictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.ControlMouseWheel;
            this.pictureEdit1.Size = new System.Drawing.Size(787, 559);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.ImageEditorDialogShowing += new DevExpress.XtraEditors.ImageEditor.ImageEditorDialogShowingEventHandler(this.pictureEdit1_ImageEditorDialogShowing);
            this.pictureEdit1.ImageEditorDialogClosed += new DevExpress.XtraEditors.ImageEditor.ImageEditorDialogClosedEventHandler(this.pictureEdit1_ImageEditorDialogClosed);
            this.pictureEdit1.TakePictureDialogShowing += new DevExpress.XtraEditors.Camera.TakePictureDialogShowingEventHandler(this.pictureEdit1_TakePictureDialogShowing);
            this.pictureEdit1.TakePictureDialogClosed += new DevExpress.XtraEditors.Camera.TakePictureDialogClosedEventHandler(this.pictureEdit1_TakePictureDialogClosed);
            this.pictureEdit1.DoubleClick += new System.EventHandler(this.pictureEdit1_DoubleClick);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(831, 462);
            this.simpleButton1.LookAndFeel.SkinName = "Glass Oceans";
            this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(149, 118);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "拍照";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Control_PictureEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 666);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "Control_PictureEdit";
            this.Text = "Control_PictureEdit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}