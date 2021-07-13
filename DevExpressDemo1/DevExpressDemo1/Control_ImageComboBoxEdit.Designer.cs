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
            this.imageComboBoxEdit1 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageComboBoxEdit1
            // 
            this.imageComboBoxEdit1.Location = new System.Drawing.Point(55, 54);
            this.imageComboBoxEdit1.Name = "imageComboBoxEdit1";
            this.imageComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEdit1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("11", null, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("22", null, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("33", null, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("44", null, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("55", null, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("66", null, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("77", null, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("88", null, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("99", null, -1)});
            this.imageComboBoxEdit1.Size = new System.Drawing.Size(319, 20);
            this.imageComboBoxEdit1.TabIndex = 0;
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
            // Control_ImageComboBoxEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 642);
            this.Controls.Add(this.imageComboBoxEdit1);
            this.Name = "Control_ImageComboBoxEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control_ImageComboBoxEdit";
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}