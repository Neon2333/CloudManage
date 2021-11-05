
namespace CloudManage.test
{
    partial class test1
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
            this.lateralAnalysis1 = new CloudManage.DataAnalysis.LateralAnalysis();
            this.SuspendLayout();
            // 
            // lateralAnalysis1
            // 
            this.lateralAnalysis1.Location = new System.Drawing.Point(0, 0);
            this.lateralAnalysis1.Name = "lateralAnalysis1";
            this.lateralAnalysis1.Size = new System.Drawing.Size(1920, 880);
            this.lateralAnalysis1.TabIndex = 0;
            // 
            // test1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 848);
            this.Controls.Add(this.lateralAnalysis1);
            this.Name = "test1";
            this.Text = "test1";
            this.ResumeLayout(false);

        }

        #endregion

        private DataAnalysis.LateralAnalysis lateralAnalysis1;
    }
}