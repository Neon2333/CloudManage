using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            //initMainForm_1366_768();
        }

        //public void initMainForm_1366_768()
        //{
        //    this.ClientSize = new System.Drawing.Size(1366, 768);
        //    disableTitle_1366_768();
        //    initSidePanel_1366_768();
        //    initTilebar_mainMenu_1366_768();
        //    initLabelControl_title_1366_768();
        //    initPictureEdit_title_1366_768();
        //    initNavigationFrame_mainMenu_1366_768();
        //    initLabelControl_datetime_1366_768();
        //    initTileBarDropDown_1366_768();
        //}

        ///**
        //*************************************************************************************************
        //*1366*768设置
        //*************************************************************************************************
        //*/

        //public void disableTitle_1366_768()
        //{
        //    this.FormBorderStyle = FormBorderStyle.None;
        //}

        //public void initSidePanel_1366_768()
        //{
        //    this.sidePanel_title.Location = new System.Drawing.Point(0, 0);
        //    this.sidePanel_title.Size = new System.Drawing.Size(1366, 60);  //title容器尺寸
        //    this.sidePanel_title.Dock = DockStyle.Top;
        //}

        //public void initTilebar_mainMenu_1366_768()
        //{
        //    this.tileBar_mainMenu.AllowSelectedItem = true;
        //    this.tileBar_mainMenu.Size = new System.Drawing.Size(1366, 90);    //tilebar尺寸
        //    this.tileBar_mainMenu.Location = new System.Drawing.Point(0, 60);
        //    this.tileBar_mainMenu.ItemSize = 60;    //磁贴高度
        //    this.tileBar_mainMenu.WideTileWidth = 160;  //磁贴宽度
        //    this.tileBar_mainMenu.IndentBetweenItems = 20;  //磁贴间距
        //    this.tileBar_mainMenu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0); //磁贴距四边距离
        //    this.tileBar_mainMenu.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Center; //磁贴的竖直方向的位置

        //    this.tileBarItem_statusMonitoring.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    this.tileBarItem_dataAnalysis.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    this.tileBarItem_twinDetection.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    this.tileBarItem_deepLearning.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    this.tileBarItem_deviceManagement.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    this.tileBarItem_systemConfig.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        //}

        //public void initLabelControl_title_1366_768()
        //{
        //    this.labelControl_title.Location = new System.Drawing.Point(300, 0);    //标题位置
        //    this.labelControl_title.Size = new System.Drawing.Size(766, 55);    //标题尺寸，左右各留300。55是因为设置60时，文字有点偏下
        //    this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;   //标题文字居中

        //}

        //public void initPictureEdit_title_1366_768()
        //{
        //    this.pictureEdit_CETC.Location = new System.Drawing.Point(0, 0);
        //    this.pictureEdit_CETC.Size = new System.Drawing.Size(90, 30);

        //}

        //public void initLabelControl_datetime_1366_768()
        //{
        //    this.labelControl_datetime.Location = new System.Drawing.Point(1086, 0);
        //    this.labelControl_datetime.Size = new System.Drawing.Size(280, 55);
        //    this.labelControl_datetime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //}

        //public void initNavigationFrame_mainMenu_1366_768()
        //{
            
        //    int heightSidePanel_title = this.sidePanel_title.Size.Height;   //60
        //    int heightTileBar_mainMenu = this.tileBar_mainMenu.Size.Height; //90
        //    this.navigationFrame_mainMenu.Location = new System.Drawing.Point(0, heightSidePanel_title + heightTileBar_mainMenu);
        //    this.navigationFrame_mainMenu.Size = new System.Drawing.Size(1366, 768 - heightSidePanel_title - heightTileBar_mainMenu);
        //    this.navigationPage_statusMonitoring.Size = new System.Drawing.Size(1366, 768 - heightSidePanel_title - heightTileBar_mainMenu);
        //    this.navigationPage_dataAnalysis.Size = new System.Drawing.Size(1366, 768 - heightSidePanel_title - heightTileBar_mainMenu);
        //    this.navigationPage_twinDetection.Size = new System.Drawing.Size(1366, 768 - heightSidePanel_title - heightTileBar_mainMenu);
        //    this.navigationPage_deepLearning.Size = new System.Drawing.Size(1366, 768 - heightSidePanel_title - heightTileBar_mainMenu);
        //    this.navigationPage_deviceManagement.Size = new System.Drawing.Size(1366, 768 - heightSidePanel_title - heightTileBar_mainMenu);

        //    this.navigationFrame_mainMenu.TransitionType = DevExpress.Utils.Animation.Transitions.SlideFade;    //幻灯片效果
        //    this.navigationFrame_mainMenu.TransitionAnimationProperties.FrameInterval = 7000;  //切换效果速度

        //}

        //public void initTileBarDropDown_1366_768()
        //{
        //    //statusMonitoring
        //    this.tileBarDropDownContainer_statusMonitoring.Size = new System.Drawing.Size(1366, 100);   //容器尺寸,不小于tileBar尺寸
        //    this.tileBar_statusMonitoring.Location = new System.Drawing.Point(0, 0);    //tileBar的位置是相对于容器的来说
        //    this.tileBar_statusMonitoring.Size = new System.Drawing.Size(1366, 100); //tileBar尺寸
        //    this.tileBar_statusMonitoring.ItemSize = 50;    //磁贴高度
        //    this.tileBar_statusMonitoring.WideTileWidth = 160;  //磁贴宽度
        //    this.tileBar_statusMonitoring.IndentBetweenItems = 15;  //磁贴间距
        //    this.tileBar_statusMonitoring.Padding = new System.Windows.Forms.Padding(40, 1, 0, 0);

        //    //dataAnalysis
        //    this.tileBarDropDownContainer_dataAnalysis.Size = new System.Drawing.Size(1366, 100);   
        //    this.tileBar_dataAnalysis.Size = new System.Drawing.Size(1366, 100); 
        //    this.tileBar_dataAnalysis.ItemSize = 50;    
        //    this.tileBar_dataAnalysis.WideTileWidth = 160;  
        //    this.tileBar_dataAnalysis.IndentBetweenItems = 15;  
        //    this.tileBar_dataAnalysis.Padding = new System.Windows.Forms.Padding(40, 1, 0, 0);
        //    this.tileBar_dataAnalysis.Location = new System.Drawing.Point(0, 0);

        //    //twinDetection      
        //    this.tileBarDropDownContainer_twinDetection.Size = new System.Drawing.Size(1366, 100);
        //    this.tileBar_twinDetection.Size = new System.Drawing.Size(1366, 100);
        //    this.tileBar_twinDetection.ItemSize = 50;
        //    this.tileBar_twinDetection.WideTileWidth = 160;
        //    this.tileBar_twinDetection.IndentBetweenItems = 15;
        //    this.tileBar_twinDetection.Padding = new System.Windows.Forms.Padding(40, 1, 0, 0);
        //    this.tileBar_twinDetection.Location = new System.Drawing.Point(0, 0);
        //}


        /**
        *************************************************************************************************
        *事件
        *************************************************************************************************
        */

        private void tileBarItem_statusMonitoring_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_statusMonitoring);
            //this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
        }

        private void tileBarItem_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_dataAnalysis);
            //this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
        }

        private void tileBarItem_twinDetection_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_twinDetection);
            //this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
        }

        private void tileBarItem_deepLearning_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_deepLearning);
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
        }

        private void tileBarItem_deviceManagement_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_deviceManagement);
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
        }

        private void tileBarItem_systemConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_systemConfig);
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_systemConfig;
        }

        private void timer_datetime_Tick(object sender, EventArgs e)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            this.labelControl_datetime.Text = now.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        private void tileBar_statusMonitoring_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
        }

        private void tileBar_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
        }

        private void tileBar_twinDetection_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
        }

        private void tileBarItem_statusMonitoring_state_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
        }

        private void tileBarItem_statusMonitoring_statistics_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;

        }

        private void tileBarItem_statusMonitoring_historyQuery_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
        }

        private void tileBarItem_dataAnalysis_HorizontalAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
        }

        private void tileBarItem_dataAnalysis_VerticalAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
        }

        private void tileBarItem_dataAnalysis_paraOptimization_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
        }

        private void tileBarItem_twinDetection_paraSyn_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
        }

        private void tileBarItem_statusWatch_intelligentReasoning_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
        }

        private void tileBarItem_twinDetection_paraUpdate_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
        }


    }
}
