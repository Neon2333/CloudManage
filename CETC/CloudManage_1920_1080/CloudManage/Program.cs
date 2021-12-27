using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace CloudManage
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            SplashScreenManager.ShowForm(typeof(SplashScreen1));    //ShowForm方法显示LoadIng窗口
            Thread.Sleep(3000);

            //Application.Run(new testSideTileBarControl());
            //Application.Run(new test.testSideTileBarWithSubControl());
            Application.Run(new MainForm());

        }
    }
}
