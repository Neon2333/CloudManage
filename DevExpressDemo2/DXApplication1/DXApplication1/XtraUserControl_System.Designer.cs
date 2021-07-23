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
            DevExpress.XtraCharts.SimpleDiagram3D simpleDiagram3D1 = new DevExpress.XtraCharts.SimpleDiagram3D();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Pie3DSeriesView pie3DSeriesView1 = new DevExpress.XtraCharts.Pie3DSeriesView();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraUserControl_System));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.navigationFrame_Status = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_System_2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            this.navigationPage_System_1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.navigationPage_System_3 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.chartControl3 = new DevExpress.XtraCharts.ChartControl();
            this.windowsUIButtonPanel_System = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_Status)).BeginInit();
            this.navigationFrame_Status.SuspendLayout();
            this.navigationPage_System_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView1)).BeginInit();
            this.navigationPage_System_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            this.navigationPage_System_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationFrame_Status
            // 
            this.navigationFrame_Status.Controls.Add(this.navigationPage_System_2);
            this.navigationFrame_Status.Controls.Add(this.navigationPage_System_1);
            this.navigationFrame_Status.Controls.Add(this.navigationPage_System_3);
            this.navigationFrame_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame_Status.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame_Status.Name = "navigationFrame_Status";
            this.navigationFrame_Status.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_System_1,
            this.navigationPage_System_2,
            this.navigationPage_System_3});
            this.navigationFrame_Status.SelectedPage = this.navigationPage_System_2;
            this.navigationFrame_Status.Size = new System.Drawing.Size(1163, 617);
            this.navigationFrame_Status.TabIndex = 12;
            this.navigationFrame_Status.Text = "navigationFrame2";
            // 
            // navigationPage_System_2
            // 
            this.navigationPage_System_2.Caption = "navigationPage_System_2";
            this.navigationPage_System_2.Controls.Add(this.chartControl2);
            this.navigationPage_System_2.Name = "navigationPage_System_2";
            this.navigationPage_System_2.Size = new System.Drawing.Size(1163, 617);
            // 
            // chartControl2
            // 
            simpleDiagram3D1.RotationMatrixSerializable = "0.114399744820472;-0.549083538171327;0.827900940024995;0;0.992093666061466;0.0198" +
    "561797594028;-0.123918884299711;0;0.0516028695494133;0.835531567467454;0.5470138" +
    "42255977;0;0;0;0;1";
            this.chartControl2.Diagram = simpleDiagram3D1;
            this.chartControl2.Legend.Name = "Default Legend";
            this.chartControl2.Location = new System.Drawing.Point(413, 173);
            this.chartControl2.Name = "chartControl2";
            series1.Name = "Series 1";
            series1.View = pie3DSeriesView1;
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl2.Size = new System.Drawing.Size(541, 422);
            this.chartControl2.TabIndex = 2;
            // 
            // navigationPage_System_1
            // 
            this.navigationPage_System_1.Caption = "navigationPage_System_1";
            this.navigationPage_System_1.Controls.Add(this.chartControl1);
            this.navigationPage_System_1.Name = "navigationPage_System_1";
            this.navigationPage_System_1.Size = new System.Drawing.Size(1163, 617);
            // 
            // chartControl1
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(413, 173);
            this.chartControl1.Name = "chartControl1";
            series2.Name = "Series 1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl1.Size = new System.Drawing.Size(541, 422);
            this.chartControl1.TabIndex = 2;
            // 
            // navigationPage_System_3
            // 
            this.navigationPage_System_3.Caption = "navigationPage_System_3";
            this.navigationPage_System_3.Controls.Add(this.chartControl3);
            this.navigationPage_System_3.Name = "navigationPage_System_3";
            this.navigationPage_System_3.Size = new System.Drawing.Size(1163, 617);
            // 
            // chartControl3
            // 
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl3.Diagram = xyDiagram2;
            this.chartControl3.Legend.Name = "Default Legend";
            this.chartControl3.Location = new System.Drawing.Point(413, 173);
            this.chartControl3.Name = "chartControl3";
            series3.Name = "Series 1";
            series3.View = lineSeriesView1;
            this.chartControl3.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.chartControl3.Size = new System.Drawing.Size(541, 422);
            this.chartControl3.TabIndex = 2;
            // 
            // windowsUIButtonPanel_System
            // 
            this.windowsUIButtonPanel_System.AppearanceButton.Hovered.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText;
            this.windowsUIButtonPanel_System.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanel_System.AppearanceButton.Pressed.BackColor = System.Drawing.Color.DodgerBlue;
            this.windowsUIButtonPanel_System.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.DodgerBlue;
            this.windowsUIButtonPanel_System.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanel_System.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButtonPanel_System.BackColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_System.ButtonInterval = 40;
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            windowsUIButtonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions3.SvgImage")));
            this.windowsUIButtonPanel_System.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Contacts", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, "Contacts", 1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Calendar", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, "Calendar", 1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Mail", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, "Mail", 1, false)});
            this.windowsUIButtonPanel_System.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_System.Location = new System.Drawing.Point(0, 617);
            this.windowsUIButtonPanel_System.Name = "windowsUIButtonPanel_System";
            this.windowsUIButtonPanel_System.Size = new System.Drawing.Size(1163, 83);
            this.windowsUIButtonPanel_System.TabIndex = 13;
            this.windowsUIButtonPanel_System.Text = "windowsUIButtonPanel2";
            this.windowsUIButtonPanel_System.UseButtonBackgroundImages = false;
            this.windowsUIButtonPanel_System.ButtonChecked += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel_System_ButtonChecked);
            // 
            // XtraUserControl_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame_Status);
            this.Controls.Add(this.windowsUIButtonPanel_System);
            this.Name = "XtraUserControl_System";
            this.Size = new System.Drawing.Size(1163, 700);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_Status)).EndInit();
            this.navigationFrame_Status.ResumeLayout(false);
            this.navigationPage_System_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            this.navigationPage_System_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.navigationPage_System_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_Status;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_System_2;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_System_1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_System_3;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraCharts.ChartControl chartControl2;
        private DevExpress.XtraCharts.ChartControl chartControl3;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_System;
    }
}
