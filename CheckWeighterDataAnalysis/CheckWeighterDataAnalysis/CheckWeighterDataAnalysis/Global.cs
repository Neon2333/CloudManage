using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckWeighterDataAnalysis
{
    class Global
    {
        public static MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "check_weighter_data_analysis", "root", "ei41");

        //状态参数
        public struct Status{
           public string brand;               //品牌
           public double curWeight;           //当前重量
           public string flagOverWeightOrUnderWeight;  //超重、欠重标志字符串
           public double lastOverWeight;      //上次超重
           public double lastUnderWeight;     //上次欠重
           public Int32 countDetection;      //检测数量
           public Int32 countOverWeight;     //超重数量
           public Int32 countUnderWeight;    //欠重数量
           public double maxWeightInHistory;           //最大值
           public double minWeightInHistory;           //最小值
        };
        public static Status curStatus = new Status();      //当前状态

        public static void initMySQL()
        {
            if (!mysqlHelper1._connectMySQL())
            {
                MessageBox.Show("数据库连接失败");
            }
        }

        //将当前状态写入MySQL
        public static void insertCurStatusMySQL()
        {
            string cmdInsertStatus = "INSERT INTO weight_history (Brand, Weight, Status, DateTime) VALUES ("
                                     + "'" + curStatus.brand + "'" + ", " + curStatus.curWeight.ToString() + ", " + "'" + curStatus.flagOverWeightOrUnderWeight + "'" + ", CURRENT_TIMESTAMP());";
            bool flag = mysqlHelper1._insertMySQL(cmdInsertStatus);
        }

        

    }
}
