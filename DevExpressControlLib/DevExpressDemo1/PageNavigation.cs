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
using DevExpress.XtraBars.Docking2010;

namespace DevExpressDemo1
{
    public partial class PageNavigation : DevExpress.XtraEditors.XtraForm
    {
        public PageNavigation()
        {
            InitializeComponent();
        }

        private void windowsUIButtonPanel2_ButtonChecked(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Contacts":
                    navigationFrame1.SelectedPage = navigationPage1;
                    break;
                case "Calendar":
                    navigationFrame1.SelectedPage = navigationPage2;

                    break;
                case "Mail":
                    navigationFrame1.SelectedPage = navigationPage3;

                    break;
            }
        }

        private void windowsUIButtonPanel3_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Page1":
                    navigationFrame_Push.SelectedPage = navigationPage5;
                    break;
                case "Page2":
                    navigationFrame_Push.SelectedPage = navigationPage6;
                    break;
            }
        }

        private void windowsUIButtonPanel4_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Page1":
                    navigationFrame_Shape.SelectedPage = navigationPage7;
                    break;
                case "Page2":
                    navigationFrame_Shape.SelectedPage = navigationPage8;
                    break;
            }
        }

        private void windowsUIButtonPanel5_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Page1":
                    navigationFrame_Fade.SelectedPage = navigationPage9;
                    break;
                case "Page2":
                    navigationFrame_Fade.SelectedPage = navigationPage10;
                    break;
            }
        }

        private void windowsUIButtonPanel6_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Page1":
                    navigationFrame_Clock.SelectedPage = navigationPage11;
                    break;
                case "Page2":
                    navigationFrame_Clock.SelectedPage = navigationPage11;
                    break;
            }
        }

        private void windowsUIButtonPanel7_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Page1":
                    navigationFrame_Dissolve.SelectedPage = navigationPage25;
                    break;
                case "Page2":
                    navigationFrame_Dissolve.SelectedPage = navigationPage26;
                    break;
            }
        }

        private void windowsUIButtonPanel8_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Page1":
                    navigationFrame_Cover.SelectedPage = navigationPage29;
                    break;
                case "Page2":
                    navigationFrame_Cover.SelectedPage = navigationPage30;
                    break;
            }
        }

        private void windowsUIButtonPanel9_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Page1":
                    navigationFrame_Comb.SelectedPage = navigationPage17;
                    break;
                case "Page2":
                    navigationFrame_Comb.SelectedPage = navigationPage18;
                    break;
            }
        }

        private void windowsUIButtonPanel10_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Page1":
                    navigationFrame_PushFade.SelectedPage = navigationPage19;
                    break;
                case "Page2":
                    navigationFrame_PushFade.SelectedPage = navigationPage20;
                    break;
            }
        }

        private void windowsUIButtonPanel11_ButtonChecked(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();	//checkButton时Caption被禁用了
            switch (tag)
            {
                case "Page1":
                    navigationFrame_Zoom.SelectedPage = navigationPage21;
                    break;
                case "Page2":
                    navigationFrame_Zoom.SelectedPage = navigationPage22;
                    break;
            }
        }
    }
}