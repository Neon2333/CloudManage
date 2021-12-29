using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CloudManage
{
    public partial class SplashScreen_startup : SplashScreen
    {
        public SplashScreen_startup()
        {
            InitializeComponent();
            //this.labelCopyright.Text = "Copyright © 1998-" + DateTime.Now.Year.ToString();
            this.labelCopyright.Text = "中国电子科技集团公司第四十一研究所\n" + "版权所有";
        }

        private void initProgressBar()
        {
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Maximum = 100;
            progressBarControl1.Properties.Minimum = 0;
            progressBarControl1.Position = 0;
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            SplashScreenCommand command = (SplashScreenCommand)cmd;
            if(command == SplashScreenCommand.SetProgress)
            {
                int pos = (int)arg;
                progressBarControl1.Position = pos;
                progressBarControl1.Update();
            }
            if(command == SplashScreenCommand.SetLabelStatus)
            {
                labelStatus.Text = (string)arg;
            }
        }

        #endregion

        public enum SplashScreenCommand
        {
            SetProgress, //设置progressBar的position
            SetLabelStatus      //设置label.text
        }
    }
}