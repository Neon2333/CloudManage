
namespace CheckWeighterDataAnalysis
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            this.sidePanel_title = new DevExpress.XtraEditors.SidePanel();
            this.labelControl_datetime = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit_CETC = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl_title = new DevExpress.XtraEditors.LabelControl();
            this.timer_datetime = new System.Windows.Forms.Timer(this.components);
            this.tileBar_mainMenu = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup_mainMenu = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tileBarItem_statusMonitor = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem_dataAnalysis = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem_exportExcel = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem_sysConfig = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_statusMonitor = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_dataAnalysis = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_exportExcel = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_sysConfig = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.sidePanel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_CETC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel_title
            // 
            this.sidePanel_title.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sidePanel_title.Appearance.Options.UseBackColor = true;
            this.sidePanel_title.Controls.Add(this.labelControl_datetime);
            this.sidePanel_title.Controls.Add(this.pictureEdit_CETC);
            this.sidePanel_title.Controls.Add(this.labelControl_title);
            this.sidePanel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.sidePanel_title.Location = new System.Drawing.Point(0, 0);
            this.sidePanel_title.Name = "sidePanel_title";
            this.sidePanel_title.Size = new System.Drawing.Size(1022, 60);
            this.sidePanel_title.TabIndex = 17;
            this.sidePanel_title.Text = "sidePanel_title";
            // 
            // labelControl_datetime
            // 
            this.labelControl_datetime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_datetime.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_datetime.Appearance.Options.UseFont = true;
            this.labelControl_datetime.Appearance.Options.UseForeColor = true;
            this.labelControl_datetime.Appearance.Options.UseTextOptions = true;
            this.labelControl_datetime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_datetime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_datetime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_datetime.Location = new System.Drawing.Point(830, 0);
            this.labelControl_datetime.Name = "labelControl_datetime";
            this.labelControl_datetime.Size = new System.Drawing.Size(192, 60);
            this.labelControl_datetime.TabIndex = 25;
            this.labelControl_datetime.Text = "yyyy-MM-dd  HH:mm:ss";
            // 
            // pictureEdit_CETC
            // 
            this.pictureEdit_CETC.EditValue = ((object)(resources.GetObject("pictureEdit_CETC.EditValue")));
            this.pictureEdit_CETC.Location = new System.Drawing.Point(38, 14);
            this.pictureEdit_CETC.Name = "pictureEdit_CETC";
            this.pictureEdit_CETC.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit_CETC.Properties.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.pictureEdit_CETC.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit_CETC.Properties.Appearance.Options.UseForeColor = true;
            this.pictureEdit_CETC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit_CETC.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit_CETC.Size = new System.Drawing.Size(115, 30);
            this.pictureEdit_CETC.TabIndex = 23;
            // 
            // labelControl_title
            // 
            this.labelControl_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl_title.Appearance.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_title.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_title.Appearance.Options.UseFont = true;
            this.labelControl_title.Appearance.Options.UseForeColor = true;
            this.labelControl_title.Appearance.Options.UseTextOptions = true;
            this.labelControl_title.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_title.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_title.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_title.Location = new System.Drawing.Point(212, 0);
            this.labelControl_title.Name = "labelControl_title";
            this.labelControl_title.Size = new System.Drawing.Size(600, 60);
            this.labelControl_title.TabIndex = 0;
            this.labelControl_title.Text = "检重设备数据分析软件";
            // 
            // timer_datetime
            // 
            this.timer_datetime.Enabled = true;
            // 
            // tileBar_mainMenu
            // 
            this.tileBar_mainMenu.AllowSelectedItem = true;
            this.tileBar_mainMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.tileBar_mainMenu.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar_mainMenu.Groups.Add(this.tileBarGroup_mainMenu);
            this.tileBar_mainMenu.Location = new System.Drawing.Point(0, 60);
            this.tileBar_mainMenu.MaxId = 4;
            this.tileBar_mainMenu.Name = "tileBar_mainMenu";
            this.tileBar_mainMenu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.tileBar_mainMenu.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar_mainMenu.Size = new System.Drawing.Size(1024, 91);
            this.tileBar_mainMenu.TabIndex = 18;
            this.tileBar_mainMenu.Text = "tileBar1";
            this.tileBar_mainMenu.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // tileBarGroup_mainMenu
            // 
            this.tileBarGroup_mainMenu.Items.Add(this.tileBarItem_statusMonitor);
            this.tileBarGroup_mainMenu.Items.Add(this.tileBarItem_dataAnalysis);
            this.tileBarGroup_mainMenu.Items.Add(this.tileBarItem_exportExcel);
            this.tileBarGroup_mainMenu.Items.Add(this.tileBarItem_sysConfig);
            this.tileBarGroup_mainMenu.Name = "tileBarGroup_mainMenu";
            // 
            // tileBarItem_statusMonitor
            // 
            this.tileBarItem_statusMonitor.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.tileBarItem_statusMonitor.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.tileBarItem_statusMonitor.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBarItem_statusMonitor.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBarItem_statusMonitor.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement1.Text = "状态监测";
            this.tileBarItem_statusMonitor.Elements.Add(tileItemElement1);
            this.tileBarItem_statusMonitor.Id = 0;
            this.tileBarItem_statusMonitor.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem_statusMonitor.Name = "tileBarItem_statusMonitor";
            // 
            // tileBarItem_dataAnalysis
            // 
            this.tileBarItem_dataAnalysis.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tileBarItem_dataAnalysis.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.tileBarItem_dataAnalysis.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBarItem_dataAnalysis.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBarItem_dataAnalysis.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            tileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement2.Text = "数据分析";
            this.tileBarItem_dataAnalysis.Elements.Add(tileItemElement2);
            this.tileBarItem_dataAnalysis.Id = 1;
            this.tileBarItem_dataAnalysis.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem_dataAnalysis.Name = "tileBarItem_dataAnalysis";
            // 
            // tileBarItem_exportExcel
            // 
            this.tileBarItem_exportExcel.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(112)))), ((int)(((byte)(56)))));
            this.tileBarItem_exportExcel.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.tileBarItem_exportExcel.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBarItem_exportExcel.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBarItem_exportExcel.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            tileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement3.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement3.Text = "报表生成";
            this.tileBarItem_exportExcel.Elements.Add(tileItemElement3);
            this.tileBarItem_exportExcel.Id = 2;
            this.tileBarItem_exportExcel.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem_exportExcel.Name = "tileBarItem_exportExcel";
            // 
            // tileBarItem_sysConfig
            // 
            this.tileBarItem_sysConfig.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(196)))));
            this.tileBarItem_sysConfig.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.tileBarItem_sysConfig.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBarItem_sysConfig.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBarItem_sysConfig.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            tileItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement4.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement4.Text = "系统设置";
            this.tileBarItem_sysConfig.Elements.Add(tileItemElement4);
            this.tileBarItem_sysConfig.Id = 3;
            this.tileBarItem_sysConfig.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem_sysConfig.Name = "tileBarItem_sysConfig";
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPage_statusMonitor);
            this.navigationFrame1.Controls.Add(this.navigationPage_dataAnalysis);
            this.navigationFrame1.Controls.Add(this.navigationPage_exportExcel);
            this.navigationFrame1.Controls.Add(this.navigationPage_sysConfig);
            this.navigationFrame1.Location = new System.Drawing.Point(0, 151);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_statusMonitor,
            this.navigationPage_dataAnalysis,
            this.navigationPage_exportExcel,
            this.navigationPage_sysConfig});
            this.navigationFrame1.SelectedPage = this.navigationPage_statusMonitor;
            this.navigationFrame1.Size = new System.Drawing.Size(1024, 617);
            this.navigationFrame1.TabIndex = 19;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage_statusMonitor
            // 
            this.navigationPage_statusMonitor.Name = "navigationPage_statusMonitor";
            this.navigationPage_statusMonitor.Size = new System.Drawing.Size(1024, 617);
            // 
            // navigationPage_dataAnalysis
            // 
            this.navigationPage_dataAnalysis.Name = "navigationPage_dataAnalysis";
            this.navigationPage_dataAnalysis.Size = new System.Drawing.Size(1024, 617);
            // 
            // navigationPage_exportExcel
            // 
            this.navigationPage_exportExcel.Name = "navigationPage_exportExcel";
            this.navigationPage_exportExcel.Size = new System.Drawing.Size(1024, 617);
            // 
            // navigationPage_sysConfig
            // 
            this.navigationPage_sysConfig.Name = "navigationPage_sysConfig";
            this.navigationPage_sysConfig.Size = new System.Drawing.Size(1024, 617);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 768);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.tileBar_mainMenu);
            this.Controls.Add(this.sidePanel_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.sidePanel_title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_CETC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SidePanel sidePanel_title;
        private DevExpress.XtraEditors.LabelControl labelControl_datetime;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_CETC;
        private DevExpress.XtraEditors.LabelControl labelControl_title;
        private System.Windows.Forms.Timer timer_datetime;
        private DevExpress.XtraBars.Navigation.TileBar tileBar_mainMenu;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup_mainMenu;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem_statusMonitor;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem_dataAnalysis;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem_exportExcel;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem_sysConfig;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_statusMonitor;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_dataAnalysis;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_exportExcel;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_sysConfig;
    }
}