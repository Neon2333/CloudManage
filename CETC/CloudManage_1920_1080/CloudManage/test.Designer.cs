namespace CloudManage
{
    partial class test
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
            this.sideTileBarControl1 = new CloudManage.CommonControl.SideTileBarControl();
            this.SuspendLayout();
            // 
            // sideTileBarControl1
            // 
            this.sideTileBarControl1.Location = new System.Drawing.Point(0, 0);
            this.sideTileBarControl1.Name = "sideTileBarControl1";
            this.sideTileBarControl1.showOverview = true;
            this.sideTileBarControl1.Size = new System.Drawing.Size(250, 1080);
            this.sideTileBarControl1.TabIndex = 0;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 848);
            this.Controls.Add(this.sideTileBarControl1);
            this.Name = "test";
            this.Text = "test";
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControl.SideTileBarControl sideTileBarControl1;
    }
}