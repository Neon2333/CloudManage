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
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FluentDesignForm = new System.Windows.Forms.ToolStripMenuItem();
            this.RibbonForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuControls
            // 
            this.menuControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOftenControls,
            this.formToolStripMenuItem});
            this.menuControls.Location = new System.Drawing.Point(0, 0);
            this.menuControls.Name = "menuControls";
            this.menuControls.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuControls.Size = new System.Drawing.Size(1270, 25);
            this.menuControls.TabIndex = 0;
            this.menuControls.Text = "控件";
            // 
            // toolStripMenuItemOftenControls
            // 
            this.toolStripMenuItemOftenControls.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSimpleButton,
            this.textEditToolStripMenuItem,
            this.toolStripMenuItem1});
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
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FluentDesignForm,
            this.RibbonForm});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.formToolStripMenuItem.Text = "Form";
            // 
            // FluentDesignForm
            // 
            this.FluentDesignForm.Name = "FluentDesignForm";
            this.FluentDesignForm.Size = new System.Drawing.Size(180, 22);
            this.FluentDesignForm.Text = "FluentDesignForm";
            this.FluentDesignForm.Click += new System.EventHandler(this.FluentDesignForm_Click);
            // 
            // RibbonForm
            // 
            this.RibbonForm.Name = "RibbonForm";
            this.RibbonForm.Size = new System.Drawing.Size(180, 22);
            this.RibbonForm.Text = "RibbonForm";
            this.RibbonForm.Click += new System.EventHandler(this.RibbonForm_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem1.Text = "XtraMessageBox";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(247, 22);
            this.toolStripMenuItem2.Text = "普通XtraMessageBox";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(247, 22);
            this.toolStripMenuItem3.Text = "计时自动关闭XtraMessageBox";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 726);
            this.Controls.Add(this.menuControls);
            this.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
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
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FluentDesignForm;
        private System.Windows.Forms.ToolStripMenuItem RibbonForm;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}

