namespace CloudManage
{
    partial class test
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            this.tileBar4 = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup6 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tileBarItem1 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.SuspendLayout();
            // 
            // tileBar4
            // 
            this.tileBar4.AllowSelectedItem = true;
            this.tileBar4.BackColor = System.Drawing.Color.White;
            this.tileBar4.Dock = System.Windows.Forms.DockStyle.Left;
            this.tileBar4.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar4.Groups.Add(this.tileBarGroup6);
            this.tileBar4.ItemSize = 95;
            this.tileBar4.Location = new System.Drawing.Point(0, 0);
            this.tileBar4.MaxId = 9;
            this.tileBar4.Name = "tileBar4";
            this.tileBar4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileBar4.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollBar;
            this.tileBar4.Size = new System.Drawing.Size(226, 586);
            this.tileBar4.TabIndex = 11;
            this.tileBar4.Text = "tileBar4";
            this.tileBar4.WideTileWidth = 190;
            // 
            // tileBarGroup6
            // 
            this.tileBarGroup6.Items.Add(this.tileBarItem1);
            this.tileBarGroup6.Name = "tileBarGroup6";
            this.tileBarGroup6.Text = "产线";
            // 
            // tileBarItem1
            // 
            this.tileBarItem1.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.tileBarItem1.AppearanceItem.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.tileBarItem1.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tileBarItem1.AppearanceItem.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.tileBarItem1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBarItem1.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileBarItem1.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBarItem1.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileBarItem1.AppearanceItem.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            this.tileBarItem1.AppearanceItem.Selected.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.tileBarItem1.AppearanceItem.Selected.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.tileBarItem1.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
            this.tileBarItem1.AppearanceItem.Selected.Options.UseBackColor = true;
            this.tileBarItem1.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tileBarItem1.AppearanceItem.Selected.Options.UseFont = true;
            this.tileBarItem1.AppearanceItem.Selected.Options.UseForeColor = true;
            this.tileBarItem1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileItemElement1.Text = "51";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement2.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tileItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            tileItemElement2.Appearance.Normal.Options.UseFont = true;
            tileItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileItemElement2.Appearance.Selected.Font = new System.Drawing.Font("微软雅黑", 27.75F);
            tileItemElement2.Appearance.Selected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            tileItemElement2.Appearance.Selected.Options.UseFont = true;
            tileItemElement2.Appearance.Selected.Options.UseForeColor = true;
            tileItemElement2.Text = "总览";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileItemElement3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileItemElement3.Text = "";
            this.tileBarItem1.Elements.Add(tileItemElement1);
            this.tileBarItem1.Elements.Add(tileItemElement2);
            this.tileBarItem1.Elements.Add(tileItemElement3);
            this.tileBarItem1.Id = 1;
            this.tileBarItem1.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem1.Name = "tileBarItem1";
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 586);
            this.Controls.Add(this.tileBar4);
            this.Name = "test";
            this.Text = "test";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileBar tileBar4;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup6;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem1;
    }
}