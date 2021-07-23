namespace DXApplication1
{
    partial class XtraUserControl_Status
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraUserControl_Status));
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.navigationFrame_Status = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_Status_1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.navigationPage_Status_2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.svgImageBox8 = new DevExpress.XtraEditors.SvgImageBox();
            this.navigationPage_Status_3 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            this.windowsUIButtonPanel_Status = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_Status)).BeginInit();
            this.navigationFrame_Status.SuspendLayout();
            this.navigationPage_Status_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            this.navigationPage_Status_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox8)).BeginInit();
            this.navigationPage_Status_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationFrame_Status
            // 
            this.navigationFrame_Status.Controls.Add(this.navigationPage_Status_1);
            this.navigationFrame_Status.Controls.Add(this.navigationPage_Status_2);
            this.navigationFrame_Status.Controls.Add(this.navigationPage_Status_3);
            this.navigationFrame_Status.Location = new System.Drawing.Point(79, 99);
            this.navigationFrame_Status.Name = "navigationFrame_Status";
            this.navigationFrame_Status.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_Status_1,
            this.navigationPage_Status_2,
            this.navigationPage_Status_3});
            this.navigationFrame_Status.SelectedPage = this.navigationPage_Status_3;
            this.navigationFrame_Status.Size = new System.Drawing.Size(921, 491);
            this.navigationFrame_Status.TabIndex = 3;
            this.navigationFrame_Status.Text = "navigationFrame1";
            // 
            // navigationPage_Status_1
            // 
            this.navigationPage_Status_1.Caption = "navigationPage_Status_1";
            this.navigationPage_Status_1.Controls.Add(this.chartControl1);
            this.navigationPage_Status_1.Name = "navigationPage_Status_1";
            this.navigationPage_Status_1.Size = new System.Drawing.Size(921, 491);
            // 
            // chartControl1
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(190, 48);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(541, 422);
            this.chartControl1.TabIndex = 1;
            // 
            // navigationPage_Status_2
            // 
            this.navigationPage_Status_2.Caption = "navigationPage_Status_2";
            this.navigationPage_Status_2.Controls.Add(this.svgImageBox8);
            this.navigationPage_Status_2.Name = "navigationPage_Status_2";
            this.navigationPage_Status_2.Size = new System.Drawing.Size(921, 491);
            // 
            // svgImageBox8
            // 
            this.svgImageBox8.BackColor = System.Drawing.Color.White;
            this.svgImageBox8.Location = new System.Drawing.Point(394, 199);
            this.svgImageBox8.Name = "svgImageBox8";
            this.svgImageBox8.Size = new System.Drawing.Size(133, 120);
            this.svgImageBox8.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            this.svgImageBox8.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox8.SvgImage")));
            this.svgImageBox8.TabIndex = 13;
            this.svgImageBox8.Text = "svgImageBox8";
            // 
            // navigationPage_Status_3
            // 
            this.navigationPage_Status_3.Caption = "navigationPage_Status_3";
            this.navigationPage_Status_3.Controls.Add(this.chartControl2);
            this.navigationPage_Status_3.Name = "navigationPage_Status_3";
            this.navigationPage_Status_3.Size = new System.Drawing.Size(921, 491);
            // 
            // chartControl2
            // 
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl2.Diagram = xyDiagram2;
            this.chartControl2.Legend.Name = "Default Legend";
            this.chartControl2.Location = new System.Drawing.Point(190, 48);
            this.chartControl2.Name = "chartControl2";
            series2.Name = "Series 1";
            series2.View = lineSeriesView1;
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl2.Size = new System.Drawing.Size(541, 422);
            this.chartControl2.TabIndex = 2;
            // 
            // windowsUIButtonPanel_Status
            // 
            this.windowsUIButtonPanel_Status.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.windowsUIButtonPanel_Status.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanel_Status.AppearanceButton.Pressed.BackColor = System.Drawing.Color.Aqua;
            this.windowsUIButtonPanel_Status.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.Aqua;
            this.windowsUIButtonPanel_Status.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanel_Status.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButtonPanel_Status.BackColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel_Status.ButtonInterval = 40;
            windowsUIButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions1.Image")));
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            windowsUIButtonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions3.SvgImage")));
            this.windowsUIButtonPanel_Status.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("New", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, "New", 1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Edit", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, "Edit", 1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Filter", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, "Filter", 1, false)});
            this.windowsUIButtonPanel_Status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel_Status.Location = new System.Drawing.Point(0, 632);
            this.windowsUIButtonPanel_Status.Name = "windowsUIButtonPanel_Status";
            this.windowsUIButtonPanel_Status.Size = new System.Drawing.Size(1079, 84);
            this.windowsUIButtonPanel_Status.TabIndex = 4;
            this.windowsUIButtonPanel_Status.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel_Status.UseButtonBackgroundImages = false;
            // 
            // XtraUserControl_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.windowsUIButtonPanel_Status);
            this.Controls.Add(this.navigationFrame_Status);
            this.Name = "XtraUserControl_Status";
            this.Size = new System.Drawing.Size(1079, 716);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_Status)).EndInit();
            this.navigationFrame_Status.ResumeLayout(false);
            this.navigationPage_Status_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.navigationPage_Status_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox8)).EndInit();
            this.navigationPage_Status_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_Status;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_Status_1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_Status_2;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox8;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_Status_3;
        private DevExpress.XtraCharts.ChartControl chartControl2;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel_Status;
    }
}
