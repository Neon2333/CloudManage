namespace DevExpressDemo1
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuControls = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemOftenControls = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSimpleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.textEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuControls
            // 
            this.menuControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOftenControls});
            this.menuControls.Location = new System.Drawing.Point(0, 0);
            this.menuControls.Name = "menuControls";
            this.menuControls.Size = new System.Drawing.Size(1101, 25);
            this.menuControls.TabIndex = 0;
            this.menuControls.Text = "控件";
            // 
            // toolStripMenuItemOftenControls
            // 
            this.toolStripMenuItemOftenControls.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSimpleButton,
            this.textEditToolStripMenuItem});
            this.toolStripMenuItemOftenControls.Name = "toolStripMenuItemOftenControls";
            this.toolStripMenuItemOftenControls.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItemOftenControls.Text = "常用控件";
            // 
            // toolStripMenuItemSimpleButton
            // 
            this.toolStripMenuItemSimpleButton.Name = "toolStripMenuItemSimpleButton";
            this.toolStripMenuItemSimpleButton.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItemSimpleButton.Text = "SimpleButton";
            this.toolStripMenuItemSimpleButton.Click += new System.EventHandler(this.toolStripMenuItemSimpleButton_Click);
            // 
            // textEditToolStripMenuItem
            // 
            this.textEditToolStripMenuItem.Name = "textEditToolStripMenuItem";
            this.textEditToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.textEditToolStripMenuItem.Text = "TextEdit";
            this.textEditToolStripMenuItem.Click += new System.EventHandler(this.textEditToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 640);
            this.Controls.Add(this.menuControls);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.menuControls.ResumeLayout(false);
            this.menuControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuControls;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOftenControls;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSimpleButton;
        private System.Windows.Forms.ToolStripMenuItem textEditToolStripMenuItem;
    }
}

