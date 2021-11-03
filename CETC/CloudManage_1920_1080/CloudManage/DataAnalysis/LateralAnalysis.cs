using CefSharp;
using CefSharp.WinForms;
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

namespace CloudManage.DataAnalysis
{
    public partial class LateralAnalysis : DevExpress.XtraEditors.XtraUserControl
    {
        private CefSharp.WinForms.ChromiumWebBrowser chromeBrowser_lateralAnalysis;
        public LateralAnalysis()
        {
            InitializeComponent();
            initLateralAnalysis();
        }

        void initLateralAnalysis()
        {
            this.sideTileBarControl_lateralAnalysis.dtInitSideTileBar = Global.dtTestingDeviceName;
            this.sideTileBarControl_lateralAnalysis.colTagDT = "DeviceNO";
            this.sideTileBarControl_lateralAnalysis.colTextDT = "DeviceName";
            this.sideTileBarControl_lateralAnalysis.colNumDT = null;
            this.sideTileBarControl_lateralAnalysis._initSideTileBar();

            //CefSettings settings = new CefSettings();
            //Cef.Initialize(settings);

            chromeBrowser_lateralAnalysis = new CefSharp.WinForms.ChromiumWebBrowser("www.baidu.com");
            this.chromeBrowser_lateralAnalysis.ActivateBrowserOnCreation = false;
            this.chromeBrowser_lateralAnalysis.Location = new System.Drawing.Point(240, 0);
            this.chromeBrowser_lateralAnalysis.Name = "chromeBrowser";
            this.chromeBrowser_lateralAnalysis.Size = new System.Drawing.Size(1118, 800);
            chromeBrowser_lateralAnalysis.Dock = DockStyle.Fill;
            this.Controls.Add(this.chromeBrowser_lateralAnalysis);

            //chromeBrowser_lateralAnalysis.LifeSpanHandler = new CefSharpOpenPageSelf();
        }

        private void sideTileBarControl_lateralAnalysis_sideTileBarItemSelectedChanged(object sender, EventArgs e)
        {
            string url = "http://127.0.0.1:8080/analysis_lateral/?device_id=" + this.sideTileBarControl_lateralAnalysis.tagSelectedItem.ToString();
            chromeBrowser_lateralAnalysis.Load(url);
        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            if (this.timeEdit_endTime.Time <= this.timeEdit_startTime.Time)
            {
                MessageBox.Show("无效时间区间，请重新选择...");
            }
            else
            {
                chromeBrowser_lateralAnalysis.ExecuteScriptAsync("ShowShiftAllBtn()");
                string strScrip = "get_analysis_lateral_shift_data('get_analysis_lateral_shift_data?device_id=" + this.sideTileBarControl_lateralAnalysis.tagSelectedItem.ToString() + "&shift=all&start_time=" + timeEdit_startTime.Time.ToLocalTime() + "&end_time=" + timeEdit_endTime.Time.ToLocalTime() + "')";
                chromeBrowser_lateralAnalysis.ExecuteScriptAsync(strScrip);

            }
        }
    }

    internal class CefSharpOpenPageSelf : ILifeSpanHandler
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
