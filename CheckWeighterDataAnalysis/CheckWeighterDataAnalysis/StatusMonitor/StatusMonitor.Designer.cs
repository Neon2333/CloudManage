
namespace CheckWeighterDataAnalysis.StatusMonitor
{
    partial class StatusMonitor
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
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesView pointSeriesView2 = new DevExpress.XtraCharts.PointSeriesView();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.XYDiagram xyDiagram4 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.chartControl3 = new DevExpress.XtraCharts.ChartControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridControl1);
            this.panelControl4.Location = new System.Drawing.Point(6, 6);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(266, 604);
            this.panelControl4.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(5, 97);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(256, 154);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.chartControl3);
            this.panelControl3.Location = new System.Drawing.Point(623, 311);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(395, 299);
            this.panelControl3.TabIndex = 2;
            // 
            // chartControl3
            // 
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl3.Diagram = xyDiagram3;
            this.chartControl3.Legend.Name = "Default Legend";
            this.chartControl3.Location = new System.Drawing.Point(5, 5);
            this.chartControl3.Name = "chartControl3";
            series4.Name = "Series 1";
            series4.View = pointSeriesView2;
            this.chartControl3.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4};
            this.chartControl3.Size = new System.Drawing.Size(385, 289);
            this.chartControl3.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chartControl2);
            this.panelControl2.Location = new System.Drawing.Point(278, 311);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(339, 299);
            this.panelControl2.TabIndex = 1;
            // 
            // chartControl2
            // 
            this.chartControl2.Legend.Name = "Default Legend";
            this.chartControl2.Location = new System.Drawing.Point(5, 5);
            this.chartControl2.Name = "chartControl2";
            series5.Name = "Series 1";
            series5.View = pieSeriesView2;
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series5};
            this.chartControl2.Size = new System.Drawing.Size(329, 289);
            this.chartControl2.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chartControl1);
            this.panelControl1.Location = new System.Drawing.Point(278, 6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(740, 299);
            this.panelControl1.TabIndex = 0;
            // 
            // chartControl1
            // 
            xyDiagram4.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram4.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram4;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(5, 5);
            this.chartControl1.Name = "chartControl1";
            series6.Name = "Series 1";
            series6.View = lineSeriesView2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series6};
            this.chartControl1.Size = new System.Drawing.Size(730, 289);
            this.chartControl1.TabIndex = 2;
            // 
            // StatusMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "StatusMonitor";
            this.Size = new System.Drawing.Size(1024, 617);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraCharts.ChartControl chartControl2;
        private DevExpress.XtraCharts.ChartControl chartControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
