namespace DevExpressDemo1
{
    partial class Control_ImageComboBoxEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control_ImageComboBoxEdit));
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.imageComboBoxEdit2 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageComboBoxEdit1 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("sendcsv", "image://svgimages/send/sendcsv.svg");
            this.svgImageCollection1.Add("open", "image://svgimages/actions/open.svg");
            this.svgImageCollection1.Add("doublelast", "image://svgimages/arrows/doublelast.svg");
            this.svgImageCollection1.Add("charttype_bar3d", "image://svgimages/chart/charttype_bar3d.svg");
            this.svgImageCollection1.Add("charttype_pie", "image://svgimages/chart/charttype_pie.svg");
            this.svgImageCollection1.Add("exporttopdf", "image://svgimages/export/exporttopdf.svg");
            this.svgImageCollection1.Add("electronics_photo", "image://svgimages/icon builder/electronics_photo.svg");
            this.svgImageCollection1.Add("electronics_microphone", "image://svgimages/icon builder/electronics_microphone.svg");
            this.svgImageCollection1.Add("actions_user", "image://svgimages/icon builder/actions_user.svg");
            // 
            // imageComboBoxEdit2
            // 
            this.imageComboBoxEdit2.Location = new System.Drawing.Point(456, 54);
            this.imageComboBoxEdit2.Name = "imageComboBoxEdit2";
            this.imageComboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEdit2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("11", null, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("22", null, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("33", null, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("44", null, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("55", null, 4)});
            this.imageComboBoxEdit2.Properties.LargeImages = this.imageCollection1;
            this.imageComboBoxEdit2.Properties.SmallImages = this.imageCollection1;
            this.imageComboBoxEdit2.Size = new System.Drawing.Size(370, 20);
            this.imageComboBoxEdit2.TabIndex = 1;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.imageCollection1.Images.SetKeyName(0, "doublefirst_32x32.png");
            this.imageCollection1.Images.SetKeyName(1, "doublelast_32x32.png");
            this.imageCollection1.Images.SetKeyName(2, "doublenext_32x32.png");
            this.imageCollection1.Images.SetKeyName(3, "doubleprev_32x32.png");
            this.imageCollection1.Images.SetKeyName(4, "first_32x32.png");
            // 
            // imageComboBoxEdit1
            // 
            this.imageComboBoxEdit1.Location = new System.Drawing.Point(62, 54);
            this.imageComboBoxEdit1.Name = "imageComboBoxEdit1";
            this.imageComboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageComboBoxEdit1.Properties.Appearance.Options.UseFont = true;
            this.imageComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEdit1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("11", null, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("22", null, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("33", null, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("44", null, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("55", null, 4)});
            this.imageComboBoxEdit1.Properties.LargeImages = this.svgImageCollection1;
            this.imageComboBoxEdit1.Properties.SmallImages = this.svgImageCollection1;
            this.imageComboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.imageComboBoxEdit1.Size = new System.Drawing.Size(370, 32);
            this.imageComboBoxEdit1.TabIndex = 2;
            // 
            // Control_ImageComboBoxEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 642);
            this.Controls.Add(this.imageComboBoxEdit1);
            this.Controls.Add(this.imageComboBoxEdit2);
            this.Name = "Control_ImageComboBoxEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control_ImageComboBoxEdit";
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit2;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit1;
    }
}