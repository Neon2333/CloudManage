using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress;
using DevExpress.XtraEditors;


namespace DevExpressDemo1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemSimpleButton_Click(object sender, EventArgs e)
        {
            ControlSimpleButton formsimplebutton = new ControlSimpleButton();
            formsimplebutton.Show();
        }

        private void toolStripMenuItem_textEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlTextEdit formtextEdit = new ControlTextEdit();
            formtextEdit.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult r = XtraMessageBox.Show("Do you want to quit the application?", "Confirmation", MessageBoxButtons.YesNo);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 5000; //计时单位ms
            args.Caption = "Auto-close message";
            args.Text = "This message closes automatically after 5 seconds.";
            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            args.DoNotShowAgainCheckBoxVisible = true;  //显示do not ask again
            XtraMessageBox.Show(args).ToString();	//XtraMessageBox.Show(XtraMessageBoxArgs) 
        }

        private void FluentDesignForm_Click(object sender, EventArgs e)
        {
            FormFluentDesign fluentDesignForm = new FormFluentDesign();
            fluentDesignForm.Show();
        }

        private void RibbonForm_Click(object sender, EventArgs e)
        {
            FormRibbon ribbonform = new FormRibbon();
            ribbonform.Show();
        }

        private void toolStripMenuItem_ToolbarForm_Click(object sender, EventArgs e)
        {
            FormToolBar toolBarForm = new FormToolBar();
            toolBarForm.Show();
        }

        private void toolStripMenuItem_SvgImageBox_Click(object sender, EventArgs e)
        {
            ControlSvgImageBox svgImageBoxForm = new ControlSvgImageBox();
            svgImageBoxForm.Show();
        }
    }
}
