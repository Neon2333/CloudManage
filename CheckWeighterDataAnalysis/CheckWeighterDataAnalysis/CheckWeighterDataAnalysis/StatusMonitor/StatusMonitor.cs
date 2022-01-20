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

namespace CheckWeighterDataAnalysis.StatusMonitor
{
    public partial class StatusMonitor : DevExpress.XtraEditors.XtraUserControl
    {
        //状态参数
        private struct Status
        {
            string brand;               //品牌
            double curWeight;           //当前重量
            string OK;                  //结果
            double lastOverWeight;      //上次超重
            double lastUnderWeight;     //上次欠重
            double countDetection;      //检测数量
            double countOverWeight;     //超重数量
            double countUnderWeight;    //欠重数量
            double maxWeight;           //最大值
            double minWeight;           //最小值
        };

        public StatusMonitor()
        {
            InitializeComponent();
        }

      
    }
}
