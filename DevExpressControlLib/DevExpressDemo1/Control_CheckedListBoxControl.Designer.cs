
namespace DevExpressDemo1
{
    partial class Control_CheckedListBoxControl
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
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase15 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition43 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition44 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition45 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement57 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement58 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement59 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement60 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition29 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition30 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan29 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan30 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.checkedListBoxControl2 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this._222DataSet = new DevExpressDemo1._222DataSet();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new DevExpressDemo1._222DataSetTableAdapters.employeeTableAdapter();
            this.checkedListBoxControl3 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.checkedListBoxControl4 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._222DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("一月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("二月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("三月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("四月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("五月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("六月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("七月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("八月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("九月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("十月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("十一月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("十二")});
            this.checkedListBoxControl1.Location = new System.Drawing.Point(72, 46);
            this.checkedListBoxControl1.MultiColumn = true;
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.checkedListBoxControl1.Size = new System.Drawing.Size(148, 451);
            this.checkedListBoxControl1.TabIndex = 1;
            // 
            // checkedListBoxControl2
            // 
            this.checkedListBoxControl2.DataSource = this.employeeBindingSource;
            this.checkedListBoxControl2.ItemHeight = 120;
            this.checkedListBoxControl2.Location = new System.Drawing.Point(274, 46);
            this.checkedListBoxControl2.MultiColumn = true;
            this.checkedListBoxControl2.Name = "checkedListBoxControl2";
            this.checkedListBoxControl2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.checkedListBoxControl2.Size = new System.Drawing.Size(171, 451);
            this.checkedListBoxControl2.TabIndex = 2;
            itemTemplateBase15.Columns.Add(tableColumnDefinition43);
            itemTemplateBase15.Columns.Add(tableColumnDefinition44);
            itemTemplateBase15.Columns.Add(tableColumnDefinition45);
            templatedItemElement57.ColumnIndex = 1;
            templatedItemElement57.FieldName = "first name";
            templatedItemElement57.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement57.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement57.Text = "first name";
            templatedItemElement57.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement58.ColumnIndex = 2;
            templatedItemElement58.FieldName = "last name";
            templatedItemElement58.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement58.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement58.Text = "last name";
            templatedItemElement58.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement59.ColumnIndex = 1;
            templatedItemElement59.FieldName = "job";
            templatedItemElement59.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement59.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement59.RowIndex = 1;
            templatedItemElement59.Text = "job";
            templatedItemElement59.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement60.FieldName = "photo";
            templatedItemElement60.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement60.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement60.Text = "photo";
            templatedItemElement60.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            itemTemplateBase15.Elements.Add(templatedItemElement57);
            itemTemplateBase15.Elements.Add(templatedItemElement58);
            itemTemplateBase15.Elements.Add(templatedItemElement59);
            itemTemplateBase15.Elements.Add(templatedItemElement60);
            itemTemplateBase15.Name = "template1";
            itemTemplateBase15.Rows.Add(tableRowDefinition29);
            itemTemplateBase15.Rows.Add(tableRowDefinition30);
            tableSpan29.RowSpan = 2;
            tableSpan30.ColumnIndex = 1;
            tableSpan30.ColumnSpan = 2;
            tableSpan30.RowIndex = 1;
            itemTemplateBase15.Spans.Add(tableSpan29);
            itemTemplateBase15.Spans.Add(tableSpan30);
            this.checkedListBoxControl2.Templates.Add(itemTemplateBase15);
            // 
            // _222DataSet
            // 
            this._222DataSet.DataSetName = "_222DataSet";
            this._222DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "employee";
            this.employeeBindingSource.DataSource = this._222DataSet;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // checkedListBoxControl3
            // 
            this.checkedListBoxControl3.HotTrackItems = true;
            this.checkedListBoxControl3.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnHotTrackEx;
            this.checkedListBoxControl3.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("一月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("二月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("三月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("四月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("五月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("六月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("七月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("八月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("九月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("十月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("十一月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("十二")});
            this.checkedListBoxControl3.Location = new System.Drawing.Point(492, 46);
            this.checkedListBoxControl3.Name = "checkedListBoxControl3";
            this.checkedListBoxControl3.Size = new System.Drawing.Size(168, 451);
            this.checkedListBoxControl3.TabIndex = 3;
            this.checkedListBoxControl3.ToolTipTitle = "热跟踪";
            // 
            // checkedListBoxControl4
            // 
            this.checkedListBoxControl4.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("一月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("二月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("三月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("四月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("五月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("六月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("七月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("八月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("九月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("十月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("十一月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("十二")});
            this.checkedListBoxControl4.Location = new System.Drawing.Point(715, 46);
            this.checkedListBoxControl4.MultiColumn = true;
            this.checkedListBoxControl4.Name = "checkedListBoxControl4";
            this.checkedListBoxControl4.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.checkedListBoxControl4.Size = new System.Drawing.Size(148, 451);
            this.checkedListBoxControl4.TabIndex = 4;
            this.checkedListBoxControl4.ToolTipTitle = "搜索框";
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.checkedListBoxControl4;
            this.searchControl1.Location = new System.Drawing.Point(715, 13);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.checkedListBoxControl4;
            this.searchControl1.Size = new System.Drawing.Size(148, 20);
            this.searchControl1.TabIndex = 5;
            // 
            // Control_CheckedListBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 654);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.checkedListBoxControl4);
            this.Controls.Add(this.checkedListBoxControl3);
            this.Controls.Add(this.checkedListBoxControl2);
            this.Controls.Add(this.checkedListBoxControl1);
            this.Name = "Control_CheckedListBoxControl";
            this.Text = "Control_CheckedListBoxControl";
            this.Load += new System.EventHandler(this.Control_CheckedListBoxControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._222DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl2;
        private _222DataSet _222DataSet;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private _222DataSetTableAdapters.employeeTableAdapter employeeTableAdapter;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl3;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl4;
        private DevExpress.XtraEditors.SearchControl searchControl1;
    }
}