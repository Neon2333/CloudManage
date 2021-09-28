namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo1 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo2 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo3 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo4 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.ExcelWorksheetSettings excelWorksheetSettings1 = new DevExpress.DataAccess.Excel.ExcelWorksheetSettings();
            DevExpress.DataAccess.Excel.ExcelSourceOptions excelSourceOptions1 = new DevExpress.DataAccess.Excel.ExcelSourceOptions(excelWorksheetSettings1);
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition4 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition5 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition6 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition7 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.colno = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colmno = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colname = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colmess = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.excelDataSource1 = new DevExpress.DataAccess.Excel.ExcelDataSource();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colno
            // 
            this.colno.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colno.AppearanceCell.Options.UseFont = true;
            this.colno.FieldName = "no";
            this.colno.Name = "colno";
            this.colno.Visible = true;
            this.colno.VisibleIndex = 0;
            this.colno.Width = 50;
            // 
            // colmno
            // 
            this.colmno.FieldName = "mno";
            this.colmno.Name = "colmno";
            this.colmno.Visible = true;
            this.colmno.VisibleIndex = 3;
            // 
            // colname
            // 
            this.colname.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.colname.AppearanceCell.Options.UseFont = true;
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 1;
            this.colname.Width = 241;
            // 
            // colmess
            // 
            this.colmess.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.colmess.AppearanceCell.Options.UseFont = true;
            this.colmess.FieldName = "mess";
            this.colmess.Name = "colmess";
            this.colmess.Visible = true;
            this.colmess.VisibleIndex = 2;
            this.colmess.Width = 245;
            // 
            // imageSlider1
            // 
            this.imageSlider1.AllowLooping = true;
            this.imageSlider1.Appearance.BorderColor = System.Drawing.Color.Maroon;
            this.imageSlider1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.imageSlider1.Appearance.Options.UseBorderColor = true;
            this.imageSlider1.Appearance.Options.UseForeColor = true;
            this.imageSlider1.AutoSlideInterval = 1000;
            this.imageSlider1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imageSlider1.CurrentImageIndex = 0;
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images1"))));
            this.imageSlider1.Location = new System.Drawing.Point(205, 299);
            this.imageSlider1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.imageSlider1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(567, 209);
            this.imageSlider1.TabIndex = 0;
            this.imageSlider1.Text = "imageSlider1";
            this.imageSlider1.ImageChanged += new System.EventHandler<DevExpress.XtraEditors.Controls.ImageChangedEventArgs>(this.imageSlider1_ImageChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.AppearancePressed.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.simpleButton1.AppearancePressed.Options.UseFont = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(647, 81);
            this.simpleButton1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton1.Size = new System.Drawing.Size(146, 46);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "忽略一次";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.excelDataSource1;
            this.gridControl1.Location = new System.Drawing.Point(24, 81);
            this.gridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.tileView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(609, 187);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1});
            // 
            // excelDataSource1
            // 
            this.excelDataSource1.FileName = "C:\\Users\\Administrator\\Desktop\\bb.xlsx";
            this.excelDataSource1.Name = "excelDataSource1";
            this.excelDataSource1.ResultSchemaSerializable = "PFZpZXc+PEZpZWxkIE5hbWU9Im5vIiBUeXBlPSJEb3VibGUiIC8+PEZpZWxkIE5hbWU9Im1ubyIgVHlwZ" +
    "T0iRG91YmxlIiAvPjxGaWVsZCBOYW1lPSJuYW1lIiBUeXBlPSJTdHJpbmciIC8+PEZpZWxkIE5hbWU9I" +
    "m1lc3MiIFR5cGU9IlN0cmluZyIgLz48L1ZpZXc+";
            fieldInfo1.Name = "no";
            fieldInfo1.Type = typeof(double);
            fieldInfo2.Name = "mno";
            fieldInfo2.Type = typeof(double);
            fieldInfo3.Name = "name";
            fieldInfo3.Type = typeof(string);
            fieldInfo4.Name = "mess";
            fieldInfo4.Type = typeof(string);
            this.excelDataSource1.Schema.AddRange(new DevExpress.DataAccess.Excel.FieldInfo[] {
            fieldInfo1,
            fieldInfo2,
            fieldInfo3,
            fieldInfo4});
            excelWorksheetSettings1.CellRange = null;
            excelWorksheetSettings1.WorksheetName = "Sheet1";
            excelSourceOptions1.ImportSettings = excelWorksheetSettings1;
            this.excelDataSource1.SourceOptions = excelSourceOptions1;
            // 
            // tileView1
            // 
            this.tileView1.Appearance.ItemFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tileView1.Appearance.ItemFocused.Options.UseBackColor = true;
            this.tileView1.Appearance.ItemNormal.BackColor = System.Drawing.Color.Red;
            this.tileView1.Appearance.ItemNormal.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileView1.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tileView1.Appearance.ItemNormal.Options.UseFont = true;
            this.tileView1.Appearance.ItemSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tileView1.Appearance.ItemSelected.Options.UseBackColor = true;
            this.tileView1.Appearance.ViewCaption.BackColor = System.Drawing.Color.Red;
            this.tileView1.Appearance.ViewCaption.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tileView1.Appearance.ViewCaption.Options.UseBackColor = true;
            this.tileView1.Appearance.ViewCaption.Options.UseFont = true;
            this.tileView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colno,
            this.colname,
            this.colmess,
            this.colmno});
            this.tileView1.ContextButtonOptions.ItemCursor = System.Windows.Forms.Cursors.PanSouth;
            this.tileView1.ContextButtonOptions.PanelCursor = System.Windows.Forms.Cursors.Arrow;
            this.tileView1.GridControl = this.gridControl1;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsEditForm.AllowHtmlCaptions = true;
            this.tileView1.OptionsTiles.GroupTextPadding = new System.Windows.Forms.Padding(6, 8, 12, 8);
            this.tileView1.OptionsTiles.IndentBetweenGroups = 0;
            this.tileView1.OptionsTiles.IndentBetweenItems = 0;
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(260, 50);
            this.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
            this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
            this.tileView1.OptionsTiles.RowCount = 3;
            this.tileView1.OptionsTiles.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileView1.OptionsTiles.StretchItems = true;
            this.tileView1.OptionsView.BackgroundColorMode = DevExpress.XtraGrid.Views.Tile.BackgroundColorMode.Skin;
            this.tileView1.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            tableColumnDefinition1.Length.Value = 30D;
            tableColumnDefinition3.Length.Value = 40D;
            tableColumnDefinition5.Length.Value = 50D;
            tableColumnDefinition7.Length.Value = 60D;
            this.tileView1.TileColumns.Add(tableColumnDefinition1);
            this.tileView1.TileColumns.Add(tableColumnDefinition2);
            this.tileView1.TileColumns.Add(tableColumnDefinition3);
            this.tileView1.TileColumns.Add(tableColumnDefinition4);
            this.tileView1.TileColumns.Add(tableColumnDefinition5);
            this.tileView1.TileColumns.Add(tableColumnDefinition6);
            this.tileView1.TileColumns.Add(tableColumnDefinition7);
            this.tileView1.TileRows.Add(tableRowDefinition1);
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement1.Appearance.Normal.Options.UseTextOptions = true;
            tileViewItemElement1.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tileViewItemElement1.Appearance.Normal.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tileViewItemElement1.Column = this.colno;
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.Text = "colno";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement2.Column = this.colmno;
            tileViewItemElement2.ColumnIndex = 2;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.Text = "colmno";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tileViewItemElement3.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement3.Column = this.colname;
            tileViewItemElement3.ColumnIndex = 4;
            tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.Text = "colname";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tileViewItemElement4.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            tileViewItemElement4.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement4.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement4.Column = this.colmess;
            tileViewItemElement4.ColumnIndex = 6;
            tileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.Text = "colmess";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.Appearance.Normal.BackColor = System.Drawing.Color.Gray;
            tileViewItemElement5.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement5.ColumnIndex = 1;
            tileViewItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement5.StretchVertical = true;
            tileViewItemElement5.Text = "element1";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.Width = 1;
            tileViewItemElement6.Appearance.Normal.BackColor = System.Drawing.Color.Gray;
            tileViewItemElement6.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement6.ColumnIndex = 3;
            tileViewItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement6.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement6.StretchVertical = true;
            tileViewItemElement6.Text = "element2";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement6.Width = 1;
            tileViewItemElement7.Appearance.Normal.BackColor = System.Drawing.Color.Gray;
            tileViewItemElement7.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement7.ColumnIndex = 5;
            tileViewItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement7.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement7.StretchVertical = true;
            tileViewItemElement7.Text = "element3";
            tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement7.Width = 1;
            this.tileView1.TileTemplate.Add(tileViewItemElement1);
            this.tileView1.TileTemplate.Add(tileViewItemElement2);
            this.tileView1.TileTemplate.Add(tileViewItemElement3);
            this.tileView1.TileTemplate.Add(tileViewItemElement4);
            this.tileView1.TileTemplate.Add(tileViewItemElement5);
            this.tileView1.TileTemplate.Add(tileViewItemElement6);
            this.tileView1.TileTemplate.Add(tileViewItemElement7);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseImage = true;
            this.simpleButton2.AppearancePressed.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.simpleButton2.AppearancePressed.Options.UseFont = true;
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(647, 143);
            this.simpleButton2.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.simpleButton2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton2.Size = new System.Drawing.Size(146, 46);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "屏蔽故障";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(25, 23);
            this.labelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 56);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "序号";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(132, 23);
            this.labelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(133, 56);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "机台编号";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(427, 23);
            this.labelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(207, 56);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "故障信息";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Silver;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(78, 4);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.True;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(819, 290);
            this.panelControl1.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseBackColor = true;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(261, 23);
            this.labelControl4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(169, 56);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "检测设备类型";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.AppearancePressed.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.simpleButton3.AppearancePressed.Options.UseFont = true;
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(800, 346);
            this.simpleButton3.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.simpleButton3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton3.Size = new System.Drawing.Size(97, 46);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "显示";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 510);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.imageSlider1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏蔽故障";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.DataAccess.Excel.ExcelDataSource excelDataSource1;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colno;
        private DevExpress.XtraGrid.Columns.TileViewColumn colname;
        private DevExpress.XtraGrid.Columns.TileViewColumn colmess;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraGrid.Columns.TileViewColumn colmno;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}

