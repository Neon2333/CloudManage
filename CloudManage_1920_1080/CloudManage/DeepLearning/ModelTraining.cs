﻿using AutoIt;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManage.DeepLearning
{
    public partial class ModelTraining : DevExpress.XtraEditors.XtraUserControl
    {
        public static ushort currentPageIndex = 10;

        public ModelTraining()
        {
            InitializeComponent();
            MainForm.modelTrainingDialogShow += createShowDialogThread;
            MainForm.modelTrainingDialogHide += hideDialog;
            MainForm.deviceOrLineAdditionDeletionReinitModelTraining += reInitDataPreparation;
        }


        public void reInitDataPreparation(object sender, EventArgs e)
        {

            Global.SetBitValueInt32(Global.ifLineAdditionOrDeletionDeviceAdditionOrDeletion, currentPageIndex, false);  //刷新页面后将该页面的标志位重置
        }


        private void createShowDialogThread(object sender, EventArgs e)
        {
            Thread threadShowDialog = new Thread(showDialog);
            threadShowDialog.IsBackground = true;
            threadShowDialog.Name = "showDialogThread";
            threadShowDialog.Start();
        }

        private void showDialog()
        {
            //Thread.Sleep(1);
            AutoItX.WinMove("deeplearning_train", "", 240, 300, -1, -1);

            AutoItX.WinActivate("deeplearning_train");
            AutoItX.WinSetOnTop("deeplearning_train", "", 1);
            AutoItX.WinSetState("deeplearning_train", "", AutoItX.SW_SHOW);
        }

        private void hideDialog(object sender, EventArgs e)
        {
            AutoItX.WinSetState("deeplearning_train", "", AutoItX.SW_HIDE);
        }

        private void showDialogState()
        {
            int nState = AutoItX.WinGetState("deeplearning_train");
            MessageBox.Show("SHOW:" + nState.ToString());
        }


    }
}
