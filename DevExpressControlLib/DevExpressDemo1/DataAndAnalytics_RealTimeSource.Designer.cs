namespace DevExpressDemo1
{
    partial class DataAndAnalytics_RealTimeSource
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
            this.realTimeSource1 = new DevExpress.Data.RealTimeSource();
            this.SuspendLayout();
            // 
            // realTimeSource1
            // 
            this.realTimeSource1.DisplayableProperties = null;
            // 
            // DataAndAnalytics_RealTimeSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 606);
            this.Name = "DataAndAnalytics_RealTimeSource";
            this.Text = "DataAndAnalytics_RealTimeSource";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Data.RealTimeSource realTimeSource1;
    }
}