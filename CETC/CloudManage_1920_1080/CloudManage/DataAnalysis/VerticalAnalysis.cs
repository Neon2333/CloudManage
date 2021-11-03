using CefSharp;
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
    public partial class VerticalAnalysis : DevExpress.XtraEditors.XtraUserControl
    {
        private CefSharp.WinForms.ChromiumWebBrowser chromeBrowser_verticalAnalysis;
        public VerticalAnalysis()
        {
            InitializeComponent();

            this.sideTileBarControlWithSub_verticalAnalysis.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_verticalAnalysis.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_verticalAnalysis.colTextDT = "LineName";
            this.sideTileBarControlWithSub_verticalAnalysis.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_verticalAnalysis.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_verticalAnalysis.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_verticalAnalysis.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_verticalAnalysis._initSideTileBarWithSub();

            //initChromeBrowser();
        }

        private void initChromeBrowser()
        {
            //chromeBrowser_verticalAnalysis.Load("www.baidu.com");
            //chromeBrowser_verticalAnalysis.LifeSpanHandler = new CefSharpOpenPageSelf();

            chromeBrowser_verticalAnalysis = new CefSharp.WinForms.ChromiumWebBrowser("www.baidu.com");
            this.chromeBrowser_verticalAnalysis.ActivateBrowserOnCreation = false;
            this.chromeBrowser_verticalAnalysis.Location = new System.Drawing.Point(240, 0);
            this.chromeBrowser_verticalAnalysis.Name = "chromeBrowser";
            this.chromeBrowser_verticalAnalysis.Size = new System.Drawing.Size(1118, 800);
            chromeBrowser_verticalAnalysis.Dock = DockStyle.Fill;
            this.panelControl_chromeBrowser.Controls.Add(this.chromeBrowser_verticalAnalysis);
            this.chromeBrowser_verticalAnalysis.LifeSpanHandler = new CefSharpOpenPageSelf();
        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            if (this.timeEdit_endTime.Time <= this.timeEdit_startTime.Time)
            {
                MessageBox.Show("无效时间区间，请重新选择...");
            }
            else
            {
                chromeBrowser_verticalAnalysis.ExecuteScriptAsync("ShowShiftAllBtn()");
                string strScrip = "get_analysis_vertical_shift_data('get_analysis_vertical_shift_data?packer_id=" + this.sideTileBarControlWithSub_verticalAnalysis.tagSelectedItem.ToString() + "&device_id=" + this.sideTileBarControlWithSub_verticalAnalysis.tagSelectedItemSub.ToString() + "&shift=all&start_time=" + timeEdit_startTime.Time.ToLocalTime() + "&end_time=" + timeEdit_endTime.Time.ToLocalTime() + "')";
                chromeBrowser_verticalAnalysis.ExecuteScriptAsync(strScrip);

            }
        }

        private void sideTileBarControlWithSub_verticalAnalysis_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            string url = "http://127.0.0.1:8080/analysis_vertical/?packer_id=" + this.sideTileBarControlWithSub_verticalAnalysis.tagSelectedItem.ToString() + "&device_id=" + this.sideTileBarControlWithSub_verticalAnalysis.tagSelectedItemSub.ToString();
            chromeBrowser_verticalAnalysis.Load(url);
        }
    }
}
