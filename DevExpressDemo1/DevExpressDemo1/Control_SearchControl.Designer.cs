namespace DevExpressDemo1
{
    partial class Control_SearchControl
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
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase1 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement1 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement2 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement3 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement4 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement5 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement6 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase2 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition4 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement7 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement8 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement9 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement10 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition5 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition6 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            this.listBoxControl5 = new DevExpress.XtraEditors.ListBoxControl();
            this.searchControl2 = new DevExpress.XtraEditors.SearchControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.listBoxControl7 = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl7)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxControl5
            // 
            this.listBoxControl5.Items.AddRange(new object[] {
            "张三",
            "李四",
            "王五",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.listBoxControl5.Location = new System.Drawing.Point(40, 71);
            this.listBoxControl5.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.listBoxControl5.LookAndFeel.UseDefaultLookAndFeel = false;
            this.listBoxControl5.Name = "listBoxControl5";
            this.listBoxControl5.Size = new System.Drawing.Size(462, 314);
            this.listBoxControl5.TabIndex = 11;
            // 
            // searchControl2
            // 
            this.searchControl2.Client = this.listBoxControl5;
            this.searchControl2.Location = new System.Drawing.Point(40, 45);
            this.searchControl2.Name = "searchControl2";
            this.searchControl2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton(),
            new DevExpress.XtraEditors.Repository.MRUButton()});
            this.searchControl2.Properties.Client = this.listBoxControl5;
            this.searchControl2.Properties.FindDelay = 2000;
            this.searchControl2.Properties.NullValuePrompt = "Please Enter your keywords here..";
            this.searchControl2.Properties.ShowDefaultButtonsMode = DevExpress.XtraEditors.Repository.ShowDefaultButtonsMode.AutoShowClear;
            this.searchControl2.Properties.ShowMRUButton = true;
            this.searchControl2.Size = new System.Drawing.Size(462, 20);
            this.searchControl2.TabIndex = 10;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.listBoxControl5;
            this.searchControl1.Location = new System.Drawing.Point(595, 47);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton(),
            new DevExpress.XtraEditors.Repository.MRUButton()});
            this.searchControl1.Properties.Client = this.listBoxControl5;
            this.searchControl1.Properties.FindDelay = 2000;
            this.searchControl1.Properties.NullValuePrompt = "Please Enter your keywords here..";
            this.searchControl1.Properties.ShowDefaultButtonsMode = DevExpress.XtraEditors.Repository.ShowDefaultButtonsMode.AutoShowClear;
            this.searchControl1.Properties.ShowMRUButton = true;
            this.searchControl1.Size = new System.Drawing.Size(353, 20);
            this.searchControl1.TabIndex = 13;
            // 
            // listBoxControl7
            // 
            this.listBoxControl7.ItemHeight = 166;
            this.listBoxControl7.Items.AddRange(new object[] {
            "张三",
            "李四",
            "王五",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.listBoxControl7.Location = new System.Drawing.Point(595, 73);
            this.listBoxControl7.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.listBoxControl7.LookAndFeel.UseDefaultLookAndFeel = false;
            this.listBoxControl7.Name = "listBoxControl7";
            this.listBoxControl7.Size = new System.Drawing.Size(353, 180);
            this.listBoxControl7.TabIndex = 14;
            itemTemplateBase1.Columns.Add(tableColumnDefinition1);
            itemTemplateBase1.Columns.Add(tableColumnDefinition2);
            templatedItemElement1.ColumnIndex = 1;
            templatedItemElement1.FieldName = "age";
            templatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement1.RowIndex = 1;
            templatedItemElement1.Text = "age";
            templatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.ColumnIndex = 1;
            templatedItemElement2.FieldName = "job";
            templatedItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement2.RowIndex = 2;
            templatedItemElement2.Text = "job";
            templatedItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement3.ColumnIndex = 1;
            templatedItemElement3.FieldName = "birthday";
            templatedItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement3.RowIndex = 3;
            templatedItemElement3.Text = "birthday";
            templatedItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement4.FieldName = null;
            templatedItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement4.Text = "姓名";
            templatedItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement5.ColumnIndex = 1;
            templatedItemElement5.FieldName = null;
            templatedItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement5.Text = "资料";
            templatedItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement6.FieldName = "first_name";
            templatedItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement6.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement6.RowIndex = 1;
            templatedItemElement6.Text = "first_name";
            templatedItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            itemTemplateBase1.Elements.Add(templatedItemElement1);
            itemTemplateBase1.Elements.Add(templatedItemElement2);
            itemTemplateBase1.Elements.Add(templatedItemElement3);
            itemTemplateBase1.Elements.Add(templatedItemElement4);
            itemTemplateBase1.Elements.Add(templatedItemElement5);
            itemTemplateBase1.Elements.Add(templatedItemElement6);
            itemTemplateBase1.Name = "template1";
            tableRowDefinition1.Length.Value = 51D;
            tableRowDefinition2.Length.Value = 52D;
            tableRowDefinition3.Length.Value = 59D;
            tableRowDefinition4.Length.Value = 40D;
            itemTemplateBase1.Rows.Add(tableRowDefinition1);
            itemTemplateBase1.Rows.Add(tableRowDefinition2);
            itemTemplateBase1.Rows.Add(tableRowDefinition3);
            itemTemplateBase1.Rows.Add(tableRowDefinition4);
            tableSpan1.RowIndex = 1;
            tableSpan1.RowSpan = 3;
            itemTemplateBase1.Spans.Add(tableSpan1);
            itemTemplateBase2.Columns.Add(tableColumnDefinition3);
            itemTemplateBase2.Columns.Add(tableColumnDefinition4);
            templatedItemElement7.FieldName = "DisplayMember";
            templatedItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement7.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement7.Text = "DisplayMember";
            templatedItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement8.FieldName = "DisplayMember";
            templatedItemElement8.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement8.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement8.RowIndex = 1;
            templatedItemElement8.Text = "DisplayMember";
            templatedItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement9.ColumnIndex = 1;
            templatedItemElement9.FieldName = "DisplayMember";
            templatedItemElement9.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement9.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement9.Text = "DisplayMember";
            templatedItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement10.ColumnIndex = 1;
            templatedItemElement10.FieldName = "DisplayMember";
            templatedItemElement10.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement10.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement10.RowIndex = 1;
            templatedItemElement10.Text = "DisplayMember";
            templatedItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            itemTemplateBase2.Elements.Add(templatedItemElement7);
            itemTemplateBase2.Elements.Add(templatedItemElement8);
            itemTemplateBase2.Elements.Add(templatedItemElement9);
            itemTemplateBase2.Elements.Add(templatedItemElement10);
            itemTemplateBase2.Name = "template2";
            tableRowDefinition5.Length.Value = 13D;
            tableRowDefinition6.Length.Value = 13D;
            itemTemplateBase2.Rows.Add(tableRowDefinition5);
            itemTemplateBase2.Rows.Add(tableRowDefinition6);
            this.listBoxControl7.Templates.Add(itemTemplateBase1);
            this.listBoxControl7.Templates.Add(itemTemplateBase2);
            // 
            // Control_SearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 634);
            this.Controls.Add(this.listBoxControl7);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.listBoxControl5);
            this.Controls.Add(this.searchControl2);
            this.Name = "Control_SearchControl";
            this.Text = "Control_SearchControl";
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listBoxControl5;
        private DevExpress.XtraEditors.SearchControl searchControl2;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl7;
    }
}