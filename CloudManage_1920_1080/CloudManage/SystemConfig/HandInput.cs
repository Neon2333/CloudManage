using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManage.SystemConfig
{
    public partial class HandInput : DevExpress.XtraEditors.XtraForm
    {
        private VisionSystemControlLibrary.StandardKeyboard standardKeyboard1;

        public HandInput()
        {
            InitializeComponent();
            initStandardKeyboard();
        }

        private void initStandardKeyboard()
        {
            if (this.standardKeyboard1 != null)
                this.standardKeyboard1.Dispose();
            this.standardKeyboard1 = new VisionSystemControlLibrary.StandardKeyboard();
            this.standardKeyboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.standardKeyboard1.CapsLock = false;
            this.standardKeyboard1.Language = VisionSystemClassLibrary.Enum.InterfaceLanguage.Chinese;
            //this.standardKeyboard1.Chinese_Caption = title;
            this.standardKeyboard1.FirstInitialStringValue = false;
            this.standardKeyboard1.InvalidCharacter = null;
            this.standardKeyboard1.IsPassword = false;
            this.standardKeyboard1.Location = new System.Drawing.Point(444, 100);
            this.standardKeyboard1.MaxLength = ((byte)(30));
            this.standardKeyboard1.Name = "standardKeyboard1";
            this.standardKeyboard1.Password = "";
            this.standardKeyboard1.PasswordStyle = 0;
            this.standardKeyboard1.Shift = false;
            this.standardKeyboard1.Size = new System.Drawing.Size(710, 406);
            this.standardKeyboard1.StringValue = "";
            this.standardKeyboard1.StringValueBuf = "";
            this.standardKeyboard1.TabIndex = 0;
            this.Controls.Add(this.standardKeyboard1);
            this.standardKeyboard1.BringToFront();
            this.standardKeyboard1.Visible = true;
            this.standardKeyboard1.Close_Click += new System.EventHandler(standardKeyboard_ESC);
        }

        public void showStandardKeyboard()
        {
            this.Show();
        }

        public void setStandardKeyboardTitle(string title)
        {
            this.standardKeyboard1.Chinese_Caption = title;
        }

        private void standardKeyboard_ESC(object sender, EventArgs e)
        {
            if (this.standardKeyboard1.EnterNewValue == false)
            {
                this.Close();
            }
        }
    }
}