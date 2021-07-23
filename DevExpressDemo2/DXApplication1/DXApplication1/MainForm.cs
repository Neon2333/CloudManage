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
            this.ClientSize = new System.Drawing.Size(1366, 768);
            disableTitle();
            initSidePanel();
            initTilebar_mainMenu();
            initLabelControl_title();
            initPictureEdit_title();
            initnavigationFrame_mainMenu();
            initLabelControl_datetime();
        }

        public void disableTitle()
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void initSidePanel()
        {
            this.sidePanel_title.Location = new System.Drawing.Point(0, 0);
            this.sidePanel_title.Size = new System.Drawing.Size(1366, 60);
            this.sidePanel_title.Dock = DockStyle.Top;
            this.tileBar_mainMenu.AllowSelectedItem = true;
        }

        public void initTilebar_mainMenu()
        {
            this.tileBar_mainMenu.Size = new System.Drawing.Size(1366, 130);    
            this.tileBar_mainMenu.Location = new System.Drawing.Point(0, 60);
            this.tileBar_mainMenu.ItemSize = 90;    //按钮高度
            this.tileBar_mainMenu.WideTileWidth = 230;  //按钮宽度
            this.tileBar_mainMenu.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Center; //磁贴的竖直方向的位置
            this.tileBar_mainMenu.IndentBetweenItems = 35;  //磁贴间距
            this.tileBar_mainMenu.Padding = new System.Windows.Forms.Padding(32, 3, 0, 0); //磁贴距四边距离

        }

        public void initLabelControl_title()
        {
            this.labelControl_title.Location = new System.Drawing.Point(295, 0);    //标题位置
            this.labelControl_title.Size = new System.Drawing.Size(766, 60);    //标题尺寸
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;   //标题文字居中

        }

        public void initPictureEdit_title()
        {
            this.pictureEdit_CETC.Size = new System.Drawing.Size(90, 30);
            this.pictureEdit_CETC.Location = new System.Drawing.Point(12, 12);

        }

        public void initnavigationFrame_mainMenu()
        {
            this.navigationFrame_mainMenu.Location = new System.Drawing.Point(0, 190);
            this.navigationFrame_mainMenu.Size = new System.Drawing.Size(1366, 546);

            //设置1~5页尺寸
            this.navigationPage_statusMonitoring.Size = new System.Drawing.Size(1366, 546);
            this.navigationPage_dataAnalysis.Size = new System.Drawing.Size(1366, 546);
            this.navigationPage_dataAnalysis.Size = new System.Drawing.Size(1366, 546);
            this.navigationPage_dataAnalysis.Size = new System.Drawing.Size(1366, 546);
            this.navigationPage_dataAnalysis.Size = new System.Drawing.Size(1366, 546);

            this.navigationFrame_mainMenu.TransitionType = DevExpress.Utils.Animation.Transitions.SlideFade;    //幻灯片效果
            this.navigationFrame_mainMenu.TransitionAnimationProperties.FrameInterval = 10000;  //切换效果速度

        }

        public void initLabelControl_datetime()
        {
            this.labelControl_datetime.Location = new System.Drawing.Point(1086, 0);    
            this.labelControl_datetime.Size = new System.Drawing.Size(280, 60);    
            this.labelControl_datetime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;   
        }

        /**
         *************************************************************************************************
        */


        private void tileBarItem_system_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_statusMonitoring;
        }

        private void tileBarItem_status_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_dataAnalysis;
        }

        private void tileBarItem_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_twinDetection;
        }

        private void tileBarItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deepLearning;
        }

        private void tileBarItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainMenu.SelectedPage = navigationPage_deviceManagement;
        }

        private void timer_datetime_Tick(object sender, EventArgs e)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            this.labelControl_datetime.Text = now.ToString("yyyy-MM-dd  HH:mm:ss");
        }


    }
}
