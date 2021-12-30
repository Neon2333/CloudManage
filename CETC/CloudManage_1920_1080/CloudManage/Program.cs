using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraEditors;

namespace CloudManage
{
    static class Program
    {
        public static int progressPercentVal = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreenManager.ShowForm(typeof(SplashScreen_startup));    //ShowForm方法显示LoadIng窗口
            Thread.Sleep(3000);

            Application.Run(new MainForm());

        }
    }
}
