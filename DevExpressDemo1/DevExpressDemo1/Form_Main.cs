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
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemSimpleButton_Click(object sender, EventArgs e)
        {
            Control_SimpleButton formsimplebutton = new Control_SimpleButton();
            formsimplebutton.Show();
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
            Form_FluentDesign fluentDesignForm = new Form_FluentDesign();
            fluentDesignForm.Show();
        }

        private void RibbonForm_Click(object sender, EventArgs e)
        {
            Form_Ribbon ribbonform = new Form_Ribbon();
            ribbonform.Show();
        }

        private void toolStripMenuItem_ToolbarForm_Click(object sender, EventArgs e)
        {
            Form_ToolBar toolBarForm = new Form_ToolBar();
            toolBarForm.Show();
        }

        private void toolStripMenuItem_SvgImageBox_Click(object sender, EventArgs e)
        {
            Control_SvgImageBox svgImageBoxForm = new Control_SvgImageBox();
            svgImageBoxForm.Show();
        }

        private void toolStripMenuItem_SimpleButton_Click(object sender, EventArgs e)
        {
            Control_SimpleButton formsimplebutton = new Control_SimpleButton();
            formsimplebutton.Show();
        }

        private void toolStripMenuItem_LabelControl_Click(object sender, EventArgs e)
        {
            Control_LabelControl labelForm = new Control_LabelControl();
            labelForm.Show();
        }

        private void toolStripMenuItem_TextEdit_Click(object sender, EventArgs e)
        {
            Control_TextEdit formtextEdit = new Control_TextEdit();
            formtextEdit.Show();
        }

        private void toolStripMenuItem_PictureEdit_Click(object sender, EventArgs e)
        {
            Control_PictureEdit pictureEdit = new Control_PictureEdit();
            pictureEdit.Show();
        }

        private void toolStripMenuItem_CheckListBoxControl_Click(object sender, EventArgs e)
        {
            Control_CheckedListBoxControl checkedListBoxControl = new Control_CheckedListBoxControl();
            checkedListBoxControl.Show();
        }

        private void toolStripMenuItem_ListBoxControl_Click(object sender, EventArgs e)
        {
            Control_ListBoxControl listBoxControl = new Control_ListBoxControl();
            listBoxControl.Show();
        }

        private void toolStripMenuItem_ImageListBoxControl_Click(object sender, EventArgs e)
        {
            Control_ImageListBoxControl imageListBoxContrl = new Control_ImageListBoxControl();
            imageListBoxContrl.Show();
        }

        private void toolStripMenuItem_SearchControl_Click(object sender, EventArgs e)
        {
            Control_SearchControl searchControl = new Control_SearchControl();
            searchControl.Show();
        }

        private void toolStripMenuItem_ImageSlider_Click(object sender, EventArgs e)
        {
            Control_ImageSlider imageSlider = new Control_ImageSlider();
            imageSlider.Show();
        }

        private void toolStripMenuItem_CheckEdit_Click(object sender, EventArgs e)
        {
            Control_CheckEdit checkEdit = new Control_CheckEdit();
            checkEdit.Show();
        }

        private void toolStripMenuItem_TimeEdit_Click(object sender, EventArgs e)
        {
            Control_TimeEdit timeEdit = new Control_TimeEdit();
            timeEdit.Show();
        }

        private void toolStripMenuItem_ComboBoxEdit_Click(object sender, EventArgs e)
        {
            Control_ComboBoxEditor comboBoxEditor = new Control_ComboBoxEditor();
            comboBoxEditor.Show();
        }

        private void toolStripMenuItem_ImageComboBoxEdit_Click(object sender, EventArgs e)
        {
            Control_ImageComboBoxEdit imageComboBoxEdit = new Control_ImageComboBoxEdit();
            imageComboBoxEdit.Show();
        }
    }
}
