namespace DXApplication1
{
    partial class XtraUserControl_System
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraUserControl_System));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.navigationFrame_Level2 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage4 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.svgImageBox8 = new DevExpress.XtraEditors.SvgImageBox();
            this.navigationPage3 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.listBoxControl5 = new DevExpress.XtraEditors.ListBoxControl();
            this.searchControl2 = new DevExpress.XtraEditors.SearchControl();
            this.navigationPage5 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.timeEdit5 = new DevExpress.XtraEditors.TimeEdit();
            this.windowsUIButtonPanel2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_Level2)).BeginInit();
            this.navigationFrame_Level2.SuspendLayout();
            this.navigationPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox8)).BeginInit();
            this.navigationPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).BeginInit();
            this.navigationPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit5.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationFrame_Level2
            // 
            this.navigationFrame_Level2.Controls.Add(this.navigationPage4);
            this.navigationFrame_Level2.Controls.Add(this.navigationPage3);
            this.navigationFrame_Level2.Controls.Add(this.navigationPage5);
            this.navigationFrame_Level2.Location = new System.Drawing.Point(142, 69);
            this.navigationFrame_Level2.Name = "navigationFrame_Level2";
            this.navigationFrame_Level2.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage3,
            this.navigationPage4,
            this.navigationPage5});
            this.navigationFrame_Level2.SelectedPage = this.navigationPage4;
            this.navigationFrame_Level2.Size = new System.Drawing.Size(924, 564);
            this.navigationFrame_Level2.TabIndex = 12;
            this.navigationFrame_Level2.Text = "navigationFrame2";
            // 
            // navigationPage4
            // 
            this.navigationPage4.Controls.Add(this.svgImageBox8);
            this.navigationPage4.Name = "navigationPage4";
            this.navigationPage4.Size = new System.Drawing.Size(924, 564);
            // 
            // svgImageBox8
            // 
            this.svgImageBox8.BackColor = System.Drawing.Color.White;
            this.svgImageBox8.Location = new System.Drawing.Point(483, 150);
            this.svgImageBox8.Name = "svgImageBox8";
            this.svgImageBox8.Size = new System.Drawing.Size(133, 120);
            this.svgImageBox8.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            this.svgImageBox8.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox8.SvgImage")));
            this.svgImageBox8.TabIndex = 13;
            this.svgImageBox8.Text = "svgImageBox8";
            // 
            // navigationPage3
            // 
            this.navigationPage3.Controls.Add(this.listBoxControl5);
            this.navigationPage3.Controls.Add(this.searchControl2);
            this.navigationPage3.Name = "navigationPage3";
            this.navigationPage3.Size = new System.Drawing.Size(924, 564);
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
            this.listBoxControl5.Location = new System.Drawing.Point(318, 66);
            this.listBoxControl5.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.listBoxControl5.LookAndFeel.UseDefaultLookAndFeel = false;
            this.listBoxControl5.Name = "listBoxControl5";
            this.listBoxControl5.Size = new System.Drawing.Size(462, 314);
            this.listBoxControl5.TabIndex = 13;
            // 
            // searchControl2
            // 
            this.searchControl2.Client = this.listBoxControl5;
            this.searchControl2.Location = new System.Drawing.Point(318, 40);
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
            this.searchControl2.TabIndex = 12;
            // 
            // navigationPage5
            // 
            this.navigationPage5.Caption = "navigationPage5";
            this.navigationPage5.Controls.Add(this.timeEdit5);
            this.navigationPage5.Name = "navigationPage5";
            this.navigationPage5.Size = new System.Drawing.Size(924, 564);
            // 
            // timeEdit5
            // 
            this.timeEdit5.EditValue = new System.DateTime(2021, 7, 13, 0, 0, 0, 0);
            this.timeEdit5.Location = new System.Drawing.Point(474, 200);
            this.timeEdit5.Name = "timeEdit5";
            this.timeEdit5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit5.Properties.Mask.EditMask = "G";
            this.timeEdit5.Size = new System.Drawing.Size(150, 20);
            this.timeEdit5.TabIndex = 10;
            this.timeEdit5.Tag = "设置Mask";
            // 
            // windowsUIButtonPanel2
            // 
            this.windowsUIButtonPanel2.AppearanceButton.Hovered.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText;
            this.windowsUIButtonPanel2.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanel2.AppearanceButton.Pressed.BackColor = System.Drawing.Color.DodgerBlue;
            this.windowsUIButtonPanel2.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.DodgerBlue;
            this.windowsUIButtonPanel2.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanel2.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButtonPanel2.BackColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel2.ButtonInterval = 40;
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            windowsUIButtonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions3.SvgImage")));
            this.windowsUIButtonPanel2.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Contacts", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, "Contacts", 1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Calendar", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, "Calendar", 1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Mail", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, "Mail", 1, false)});
            this.windowsUIButtonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel2.Location = new System.Drawing.Point(0, 700);
            this.windowsUIButtonPanel2.Name = "windowsUIButtonPanel2";
            this.windowsUIButtonPanel2.Size = new System.Drawing.Size(1307, 83);
            this.windowsUIButtonPanel2.TabIndex = 13;
            this.windowsUIButtonPanel2.Text = "windowsUIButtonPanel2";
            this.windowsUIButtonPanel2.UseButtonBackgroundImages = false;
            this.windowsUIButtonPanel2.ButtonChecked += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel2_ButtonChecked);
            // 
            // XtraUserControl_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.windowsUIButtonPanel2);
            this.Controls.Add(this.navigationFrame_Level2);
            this.Name = "XtraUserControl_System";
            this.Size = new System.Drawing.Size(1307, 783);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_Level2)).EndInit();
            this.navigationFrame_Level2.ResumeLayout(false);
            this.navigationPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox8)).EndInit();
            this.navigationPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).EndInit();
            this.navigationPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit5.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_Level2;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage4;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox8;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage3;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl5;
        private DevExpress.XtraEditors.SearchControl searchControl2;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage5;
        private DevExpress.XtraEditors.TimeEdit timeEdit5;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel2;
    }
}
