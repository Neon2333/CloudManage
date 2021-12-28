using CefSharp;
using CefSharp.WinForms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManage.DataAnalysis
{
    public partial class LateralAnalysis : DevExpress.XtraEditors.XtraUserControl
    {

        private CefSharp.WinForms.ChromiumWebBrowser chromeBrowser;
        public LateralAnalysis()
        {
            InitializeComponent();
            //initLateralAnalysis();
            SplashScreenManager.Default.SendCommand(SplashScreen1.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);

        }

        void initLateralAnalysis()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            chromeBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            chromeBrowser.MenuHandler = new MenuHandler();
            chromeBrowser.LifeSpanHandler = new CefSharpOpenPageSelf();
            chromeBrowser.Dock = DockStyle.Fill;

            panelControl_chromeBrowser.Controls.Add(chromeBrowser);

            this.sideTileBarControl_lateralAnalysis.dtInitSideTileBar = Global.dtTestingDeviceName;
            this.sideTileBarControl_lateralAnalysis.colTagDT = "DeviceNO";
            this.sideTileBarControl_lateralAnalysis.colTextDT = "DeviceName";
            this.sideTileBarControl_lateralAnalysis.colNumDT = null;
            this.sideTileBarControl_lateralAnalysis._initSideTileBar();
        }

        private void sideTileBarControl_lateralAnalysis_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            //string url = "http://192.168.111.12:8080/analysis_lateral/?device_id=" + this.sideTileBarControl_lateralAnalysis.tagSelectedItem.ToString() + "&shift=all&start_time=" + timeEdit_startTime.Time.ToLocalTime() + "&end_time=" + timeEdit_endTime.Time.ToLocalTime();
            //chromeBrowser.Load(url);
        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            if (this.timeEdit_endTime.Time <= this.timeEdit_startTime.Time)
            {
                MessageBox.Show("无效时间区间，请重新选择...");
            }
            else
            {
                chromeBrowser.ExecuteScriptAsync("ShowShiftAllBtn()");
                string strScrip = "get_analysis_lateral_shift_data('get_analysis_lateral_shift_data?device_id=" + this.sideTileBarControl_lateralAnalysis.tagSelectedItem.ToString() + "&shift=all&start_time=" + timeEdit_startTime.Time.ToLocalTime() + "&end_time=" + timeEdit_endTime.Time.ToLocalTime() + "')";
                chromeBrowser.ExecuteScriptAsync(strScrip);

            }
        }
    }
    /// <summary>
    /// 禁用右键菜单
    /// </summary>
    partial class MenuHandler : IContextMenuHandler
    {

        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
    /// <summary>
    /// 禁止打开新窗口
    /// </summary>
    partial class CefSharpOpenPageSelf : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }
        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
        }
        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }
        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            return true;
        }
    }
}
