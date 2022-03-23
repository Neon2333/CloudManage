
namespace CloudManage.DeepLearning
{
    partial class DataPreparation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl_displayOKPics = new DevExpress.XtraGrid.GridControl();
            this.winExplorerView_displayPicsOK = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.gridColumn_picName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_pic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_displayNGPics = new DevExpress.XtraGrid.GridControl();
            this.winExplorerView_displayPicsNG = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton_delPicsNG = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_delPicsOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_dir = new DevExpress.XtraEditors.LabelControl();
            this.sideTileBarControlWithSub1 = new CloudManage.CommonControl.SideTileBarControlWithSub();
            this.windowsUIButtonPanel_dataPreparation = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_displayOKPics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView_displayPicsOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_displayNGPics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView_displayPicsNG)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_displayOKPics
            // 
            this.gridControl_displayOKPics.Location = new System.Drawing.Point(246, 50);
            this.gridControl_displayOKPics.MainView = this.winExplorerView_displayPicsOK;
            this.gridControl_displayOKPics.Name = "gridControl_displayOKPics";
            this.gridControl_displayOKPics.Size = new System.Drawing.Size(755, 672);
            this.gridControl_displayOKPics.TabIndex = 12;
            this.gridControl_displayOKPics.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.winExplorerView_displayPicsOK});
            // 
            // winExplorerView_displayPicsOK
            // 
            this.winExplorerView_displayPicsOK.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_picName,
            this.gridColumn_pic});
            this.winExplorerView_displayPicsOK.ColumnSet.ExtraLargeImageColumn = this.gridColumn_pic;
            this.winExplorerView_displayPicsOK.ColumnSet.LargeImageIndexColumn = this.gridColumn_pic;
            this.winExplorerView_displayPicsOK.ColumnSet.MediumImageIndexColumn = this.gridColumn_pic;
            this.winExplorerView_displayPicsOK.ColumnSet.SmallImageIndexColumn = this.gridColumn_pic;
            this.winExplorerView_displayPicsOK.ColumnSet.TextColumn = this.gridColumn_picName;
            this.winExplorerView_displayPicsOK.GridControl = this.gridControl_displayOKPics;
            this.winExplorerView_displayPicsOK.Name = "winExplorerView_displayPicsOK";
            this.winExplorerView_displayPicsOK.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.SegmentedFade;
            this.winExplorerView_displayPicsOK.OptionsImageLoad.AsyncLoad = true;
            this.winExplorerView_displayPicsOK.OptionsSelection.ItemSelectionMode = DevExpress.XtraGrid.Views.WinExplorer.IconItemSelectionMode.Click;
            this.winExplorerView_displayPicsOK.OptionsSelection.MultiSelect = true;
            this.winExplorerView_displayPicsOK.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Large;
            // 
            // gridColumn_picName
            // 
            this.gridColumn_picName.Caption = "图片名称";
            this.gridColumn_picName.FieldName = "picName";
            this.gridColumn_picName.Name = "gridColumn_picName";
            this.gridColumn_picName.Visible = true;
            this.gridColumn_picName.VisibleIndex = 0;
            // 
            // gridColumn_pic
            // 
            this.gridColumn_pic.Caption = "图片";
            this.gridColumn_pic.FieldName = "pic";
            this.gridColumn_pic.Name = "gridColumn_pic";
            this.gridColumn_pic.Visible = true;
            this.gridColumn_pic.VisibleIndex = 0;
            // 
            // gridControl_displayNGPics
            // 
            this.gridControl_displayNGPics.Location = new System.Drawing.Point(1007, 50);
            this.gridControl_displayNGPics.MainView = this.winExplorerView_displayPicsNG;
            this.gridControl_displayNGPics.Name = "gridControl_displayNGPics";
            this.gridControl_displayNGPics.Size = new System.Drawing.Size(851, 672);
            this.gridControl_displayNGPics.TabIndex = 13;
            this.gridControl_displayNGPics.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.winExplorerView_displayPicsNG});
            // 
            // winExplorerView_displayPicsNG
            // 
            this.winExplorerView_displayPicsNG.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.winExplorerView_displayPicsNG.ColumnSet.ExtraLargeImageColumn = this.gridColumn2;
            this.winExplorerView_displayPicsNG.ColumnSet.LargeImageIndexColumn = this.gridColumn2;
            this.winExplorerView_displayPicsNG.ColumnSet.MediumImageIndexColumn = this.gridColumn2;
            this.winExplorerView_displayPicsNG.ColumnSet.SmallImageIndexColumn = this.gridColumn2;
            this.winExplorerView_displayPicsNG.ColumnSet.TextColumn = this.gridColumn1;
            this.winExplorerView_displayPicsNG.GridControl = this.gridControl_displayNGPics;
            this.winExplorerView_displayPicsNG.Name = "winExplorerView_displayPicsNG";
            this.winExplorerView_displayPicsNG.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.SegmentedFade;
            this.winExplorerView_displayPicsNG.OptionsImageLoad.AsyncLoad = true;
            this.winExplorerView_displayPicsNG.OptionsSelection.ItemSelectionMode = DevExpress.XtraGrid.Views.WinExplorer.IconItemSelectionMode.Click;
            this.winExplorerView_displayPicsNG.OptionsSelection.MultiSelect = true;
            this.winExplorerView_displayPicsNG.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Large;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "图片名称";
            this.gridColumn1.FieldName = "picName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "图片";
            this.gridColumn2.FieldName = "pic";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // simpleButton_delPicsNG
            // 
            this.simpleButton_delPicsNG.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.simpleButton_delPicsNG.Appearance.Options.UseFont = true;
            this.simpleButton_delPicsNG.Location = new System.Drawing.Point(1007, 728);
            this.simpleButton_delPicsNG.Name = "simpleButton_delPicsNG";
            this.simpleButton_delPicsNG.Size = new System.Drawing.Size(851, 66);
            this.simpleButton_delPicsNG.TabIndex = 18;
            this.simpleButton_delPicsNG.Text = "删除NG";
            this.simpleButton_delPicsNG.Click += new System.EventHandler(this.simpleButton_delPicsNG_Click);
            // 
            // simpleButton_delPicsOK
            // 
            this.simpleButton_delPicsOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_delPicsOK.Appearance.Options.UseFont = true;
            this.simpleButton_delPicsOK.Location = new System.Drawing.Point(246, 728);
            this.simpleButton_delPicsOK.Name = "simpleButton_delPicsOK";
            this.simpleButton_delPicsOK.Size = new System.Drawing.Size(755, 66);
            this.simpleButton_delPicsOK.TabIndex = 17;
            this.simpleButton_delPicsOK.Text = "删除OK";
            this.simpleButton_delPicsOK.Click += new System.EventHandler(this.simpleButton_delPicsOK_Click);
            // 
            // labelControl_dir
            // 
            this.labelControl_dir.Appearance.BackColor = System.Drawing.Color.Gray;
            this.labelControl_dir.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_dir.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_dir.Appearance.Options.UseBackColor = true;
            this.labelControl_dir.Appearance.Options.UseFont = true;
            this.labelControl_dir.Appearance.Options.UseForeColor = true;
            this.labelControl_dir.Appearance.Options.UseTextOptions = true;
            this.labelControl_dir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_dir.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_dir.Location = new System.Drawing.Point(246, 0);
            this.labelControl_dir.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_dir.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_dir.Name = "labelControl_dir";
            this.labelControl_dir.Size = new System.Drawing.Size(1612, 50);
            this.labelControl_dir.TabIndex = 15;
            this.labelControl_dir.Text = "   总览——所有设备";
            // 
            // sideTileBarControlWithSub1
            // 
            this.sideTileBarControlWithSub1.colNumDT = "";
            this.sideTileBarControlWithSub1.colTagDT = "";
            this.sideTileBarControlWithSub1.colTagDTSUB = "";
            this.sideTileBarControlWithSub1.colTextDT = "";
            this.sideTileBarControlWithSub1.colTextDTSUB = "";
            this.sideTileBarControlWithSub1.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControlWithSub1.Name = "sideTileBarControlWithSub1";
            this.sideTileBarControlWithSub1.showAllDevices = true;
            this.sideTileBarControlWithSub1.showOverview = true;
            this.sideTileBarControlWithSub1.Size = new System.Drawing.Size(510, 800);
            this.sideTileBarControlWithSub1.TabIndex = 16;
            this.sideTileBarControlWithSub1.useDtInitSideTileBarWithSub = true;
            // 
            // windowsUIButtonPanel_dataPreparation
            // 
            this.windowsUIButtonPanel_dataPreparation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.windowsUIButtonPanel_dataPreparation.ButtonInterval = 20;
            this.windowsUIButtonPanel_dataPreparation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_dataPreparation.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_dataPreparation.Location = new System.Drawing.Point(0, 800);
            this.windowsUIButtonPanel_dataPreparation.Name = "windowsUIButtonPanel_dataPreparation";
            this.windowsUIButtonPanel_dataPreparation.Size = new System.Drawing.Size(1920, 80);
            this.windowsUIButtonPanel_dataPreparation.TabIndex = 14;
            this.windowsUIButtonPanel_dataPreparation.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel_dataPreparation.UseButtonBackgroundImages = false;
            // 
            // DataPreparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_displayOKPics);
            this.Controls.Add(this.gridControl_displayNGPics);
            this.Controls.Add(this.simpleButton_delPicsNG);
            this.Controls.Add(this.simpleButton_delPicsOK);
            this.Controls.Add(this.labelControl_dir);
            this.Controls.Add(this.sideTileBarControlWithSub1);
            this.Controls.Add(this.windowsUIButtonPanel_dataPreparation);
            this.Name = "DataPreparation";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_displayOKPics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView_displayPicsOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_displayNGPics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView_displayPicsNG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_displayOKPics;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView_displayPicsOK;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_picName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_pic;
        private DevExpress.XtraGrid.GridControl gridControl_displayNGPics;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView_displayPicsNG;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_delPicsNG;
        private DevExpress.XtraEditors.SimpleButton simpleButton_delPicsOK;
        private DevExpress.XtraEditors.LabelControl labelControl_dir;
        private CommonControl.SideTileBarControlWithSub sideTileBarControlWithSub1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_dataPreparation;
    }
}
