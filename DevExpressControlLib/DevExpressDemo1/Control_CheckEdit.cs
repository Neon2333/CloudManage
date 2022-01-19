using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DevExpressDemo1
{
    public partial class Control_CheckEdit : DevExpress.XtraEditors.XtraForm
    {
        public Control_CheckEdit()
        {
            InitializeComponent();

            this.checkEdit2.Checked = true;
        }

        private void checkEdit43_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.checkEdit43.Checked == true)
            {
                this.checkEdit43.Properties.CheckBoxOptions.SvgImageSize = new Size(50,50);
            }
            else
            {
                this.checkEdit43.Properties.CheckBoxOptions.SvgImageSize = new Size(16, 16);    //svg默认大小16*16

            }
        }

      
private void CreateCheckEditors()
    {
            // creating and initializing the first check editor
            // setting the editor's check state depending upon the button's visibility
            if (!(this.simpleButton1.Visible))
                checkEdit42.Checked = true;
            // assigning a handler for the CheckChanged event of the first check editor
            checkEdit42.CheckedChanged += new EventHandler(CheckedChanged);
        this.Controls.Add((Control)checkEdit42);

        // creating and initializing the second check editor
        // setting the editor's check state depending upon the button's availability
        //if (!(this.simpleButton1.Enabled)) checkEdit44.Checked = true;
        //if (!(this.simpleButton1.Visible)) checkEdit44.Enabled = false;
         // assigning a handler for the CheckChanged event of the second check editor
         checkEdit44.CheckedChanged += new EventHandler(CheckedChanged);
        this.Controls.Add((Control)checkEdit44);
    }

    private void CheckedChanged(object sender, System.EventArgs e)
    {
        CheckEdit edit = sender as CheckEdit;
        switch (edit.Checked)
        {
            case true:
                if (edit == GetCheckEdit("chEdit1"))
                {
                    // hiding the button
                    this.simpleButton1.Visible = false;
                    // disabling the second check editor
                    GetCheckEdit("chEdit2").Enabled = false;
                }
                else if (edit == GetCheckEdit("chEdit2"))
                {
                    // enabling the button
                    this.simpleButton1.Enabled = false;
                }
                break;
            case false:
                if (edit == GetCheckEdit("chEdit1"))
                {
                    // showing the button
                    this.simpleButton1.Visible = true;
                    // enabling the second check editor
                    GetCheckEdit("chEdit2").Enabled = true;
                }
                else if (edit == GetCheckEdit("chEdit2"))
                {
                    // disabling the button
                    this.simpleButton1.Enabled = true;
                }
                break;
        }
    }

    private CheckEdit GetCheckEdit(string editName)
    {
        foreach (Control control in this.Controls)
        {
            if ((control is CheckEdit) && (control.Name == editName))
                return control as CheckEdit;
        }
        return null;
    }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateCheckEditors();

        }
    }
}