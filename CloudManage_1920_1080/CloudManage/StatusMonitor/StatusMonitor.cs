﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraSplashScreen;

namespace CloudManage.StatusMonitor
{
    public partial class StatusMonitor : DevExpress.XtraEditors.XtraUserControl
    {
        private NavigationPage navigationPage_workState;
        private NavigationPage navigationPage_realTimeData;
        private NavigationPage navigationPage_historyQuery;
        private NavigationPage[] statusMonitorPages = new NavigationPage[3];

        public StatusMonitor()
        {
            InitializeComponent();
            initStatusMonitorPage();
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5); //进度条+5
            //this.FaultNumStatusMonitor = this.historyQueryControl1.faultNumHistoryQuery;
        }

        public Boolean frameVisible
        {
            get
            {
                return this.navigationFrame_statusMonitor.Visible;
            }
            set
            {
                this.navigationFrame_statusMonitor.Visible = value;
            }
        }

        ///<summary>
        ///初始化数组statusMonitorPages，存3个navigationPage
        ///</summary>
        private void initStatusMonitorPage()
        {
            statusMonitorPages[0] = navigationPage_workState;
            statusMonitorPages[1] = navigationPage_realTimeData;
            statusMonitorPages[2] = navigationPage_historyQuery;
        }

        /// <summary>
        /// 设置/获取statusMonitor中NavigationFrame当前显示页
        /// </summary>
        public int selectedFramePage
        {
            get
            {
                //return (NavigationPage)this.navigationFrame_statusMonitor.SelectedPage; //SelectedPage是InavigationPage，时NavigationPage的父类
                for(int i = 0; i < statusMonitorPages.Length; i++)
                {
                    if (this.navigationFrame_statusMonitor.SelectedPage == statusMonitorPages[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
            set
            {
                this.navigationFrame_statusMonitor.SelectedPage = statusMonitorPages[value];
            }
        }

        ///<summary>
        ///设置statusMonitor中NavigationFrame当前显示页
        ///</summary>
        ///<param name="pageIndex">要显示页的索引0~2</param>
        public void setSelectedFramePage(int pageIndex)
        {
            this.navigationFrame_statusMonitor.SelectedPage = statusMonitorPages[pageIndex];
        }

        public void doubleClickTileViewEach_informStatusMonitorChangePage()
        {
            setSelectedFramePage(1);    //RealTimeData
        }

    }
}
