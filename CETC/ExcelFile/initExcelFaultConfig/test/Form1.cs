using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //FileStream filestream = new FileStream(@"D:\WorkSpace\EI41\DevExpressDemo\CETC\ExcelFile\faultsConfig.xlsx", FileMode.OpenOrCreate);
            FileStream filestream = new FileStream(@"C:\Users\25224\Desktop\faultsConfig.xlsx", FileMode.OpenOrCreate); 
            XSSFWorkbook wb = new XSSFWorkbook();   //创建表对象wk
            ISheet isheet = wb.CreateSheet("Sheet1");   //在wk中创建sheet1

            int rowIndex = 1;
            IRow row = null;
            ICell cell = null;
            string str = String.Empty;

            for(int LineNO = 1; LineNO <= 24; LineNO++)
            {
                for(int DeviceNO = 1; DeviceNO <= 18; DeviceNO++)
                {
                    for(int FaultNO = 1; FaultNO <= 10; FaultNO++)
                    {
                        row = isheet.CreateRow(rowIndex);

                        cell = row.CreateCell(0);
                        if (LineNO < 10)
                        {
                            str = "00" + LineNO.ToString();
                        }
                        else if (LineNO >= 10)
                        {
                            str = "0" + LineNO.ToString();
                        }
                        cell.SetCellValue(str);


                        cell = row.CreateCell(1);
                        if (DeviceNO < 10)
                        {
                            str = "00" + DeviceNO.ToString();
                        }
                        else if (DeviceNO >= 10)
                        {
                            str = "0" + DeviceNO.ToString();
                        }
                        cell.SetCellValue(str);


                        cell = row.CreateCell(2);
                        cell.SetCellValue(FaultNO.ToString());


                        cell = row.CreateCell(3);
                        cell.SetCellValue("1");

                        ++rowIndex;
                    }
                }
            }

            wb.Write(filestream);   //通过流filestream将表wk写入文件
            filestream.Close(); //关闭文件流filestream
            wb.Close(); //关闭Excel表对象wk

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            MessageBox.Show("all done!  ,   " + ts.TotalMilliseconds + "ms");


        }
    }
}
