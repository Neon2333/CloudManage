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

namespace CloudManage.CommonControl
{
    public partial class NumberKeyboard : DevExpress.XtraEditors.XtraUserControl
    {
        private bool dotExistsInResultEachNum = false;  //dot是否已添加进resultEachNum
        private double MaxVal = 0.0;
        private double MinVal = 0.0;
        private char chNowInput;             //记录当前输入的字符
        private List<char> resultEachNum;    //保存每个字符
        private double resultNum = 0.0;      //保存数字结果
        private int resultNumDigitsMax = 15; //最多15位
        
        public NumberKeyboard(double min, double max)
        {
            InitializeComponent();

            initNumberKeyboard();
            this.minVal = min;
            this.maxVal = max;
        }

        public NumberKeyboard()
        {
            InitializeComponent();

            initNumberKeyboard();
        }

        private void initNumberKeyboard()
        {
            resultEachNum = new List<char>();
            resultEachNum.Add('+');             //resultEachNum第一位为符号位
            this.labelControl_display.Text = "";
        }

        public double maxVal
        {
            get
            {
                return this.MaxVal;
            }
            set
            {
                this.MaxVal = value;
                this.labelControl_max.Text = "最大值：" + this.MaxVal.ToString();
            }
        }

        public double minVal
        {
            get
            {
                return this.MinVal;
            }
            set
            {
                this.MinVal = value;
                this.labelControl_min.Text = "最小值：" + this.MinVal.ToString();
            }
        }

        private bool judgeOutOfRange()
        {
            bool flag = true;
            try
            {
                if (this.resultNum < this.MinVal || this.resultNum > this.MaxVal)
                {
                    flag = false;
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                flag = false;
            }
            return flag;
        }

        private bool pushIntoResultEachNum()
        {
            bool flag = true;
            try
            {
                if (this.resultEachNum.Count <= this.resultNumDigitsMax)    //最多输入15位
                {
                    if (chNowInput >= '0' && chNowInput <= '9')
                    {
                        resultEachNum.Add(chNowInput);
                        flag = true;
                    }
                    else if (chNowInput == '.')
                    {
                        if (resultEachNum.Count == 1)   //resultEachNum为空时,输入dot
                        {
                            resultEachNum.Add('0');
                            resultEachNum.Add('.');
                            this.dotExistsInResultEachNum = true;
                        }
                        else if (resultEachNum.Count > 1)
                        {
                            if (this.dotExistsInResultEachNum == false)
                            {
                                resultEachNum.Add('.');
                                this.dotExistsInResultEachNum = true;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                flag = false;
            }
            return flag;            
        }

        private bool refreshDisplay()
        {
            bool flag = true;
            try
            {
                this.labelControl_display.Text = "";
                if (this.resultEachNum.Count == 1)
                {
                    return flag;    //只有符号位没有数字时不显示
                }

                foreach (var v in this.resultEachNum)
                {
                    if (v == '+')
                    {
                        continue;
                    }
                    this.labelControl_display.Text += v;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                flag = false;
            }
            return flag;
        }

        private bool calcResultNum()
        {
            bool flag = true;
            try
            {
                this.resultNum = 0.0D;
                int len = this.resultEachNum.Count;
                if (this.dotExistsInResultEachNum == false)
                {
                    for(int i = 1; i < len; i++)
                    {
                        int val = this.resultEachNum.ElementAt(i) - '0';
                        this.resultNum += val * Math.Pow(10, len - 1 - i);
                    }

                    //加上符号位
                    if (resultEachNum.ElementAt(0) == '-' && this.resultNum > 0)
                    {
                        this.resultNum = 0 - this.resultNum;    //加上符号位
                    }
                    else if (resultEachNum.ElementAt(0) == '+' && this.resultNum < 0)
                    {
                        this.resultNum = 0 - this.resultNum;
                    }
                }
                else
                {
                    int dotPos = this.resultEachNum.IndexOf('.');
                    for(int i = 1; i < dotPos; i++)
                    {
                        int val = this.resultEachNum.ElementAt(i) - '0';
                        this.resultNum += val * Math.Pow(10, dotPos - 1 - i);
                    }
                    for (int i = dotPos + 1; i < len; i++)
                    {
                        int val = this.resultEachNum.ElementAt(i) - '0';
                        this.resultNum += val * Math.Pow(10, dotPos - i);
                    }

                    //加上符号位
                    if (resultEachNum.ElementAt(0) == '-' && this.resultNum > 0)
                    {
                        this.resultNum = 0 - this.resultNum;    //加上符号位
                    }
                    else if (resultEachNum.ElementAt(0) == '+' && this.resultNum < 0)
                    {
                        this.resultNum = 0 - this.resultNum;
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                flag = false;
            }
            return flag;
        }

        private void simpleButton_num0_Click(object sender, EventArgs e)
        {
            //刷新chNowInput
            chNowInput = '0';
            //push进ResultEachNum
            pushIntoResultEachNum();
            //刷新display
            refreshDisplay();

        }

        private void simpleButton_num1_Click(object sender, EventArgs e)
        {
            chNowInput = '1';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_num2_Click(object sender, EventArgs e)
        {
            chNowInput = '2';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_num3_Click(object sender, EventArgs e)
        {
            chNowInput = '3';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_num4_Click(object sender, EventArgs e)
        {
            chNowInput = '4';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_num5_Click(object sender, EventArgs e)
        {
            chNowInput = '5';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_num6_Click(object sender, EventArgs e)
        {
            chNowInput = '6';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_num7_Click(object sender, EventArgs e)
        {
            chNowInput = '7';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_num8_Click(object sender, EventArgs e)
        {
            chNowInput = '8';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_num9_Click(object sender, EventArgs e)
        {
            chNowInput = '9';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_dot_Click(object sender, EventArgs e)
        {
            chNowInput = '.';
            pushIntoResultEachNum();
            refreshDisplay();
        }

        private void simpleButton_plusMinus_Click(object sender, EventArgs e)
        {
            //改变符号位
            if (resultEachNum.ElementAt(0)=='+')
            {
                resultEachNum[0] = '-';
            }
            else if(resultEachNum.ElementAt(0)=='-')
            {
                resultEachNum[0] = '+';
            }
            refreshDisplay();
        }

        private void simpleButton_esc_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton_clr_Click(object sender, EventArgs e)
        {
            while (this.resultEachNum.Count != 1)
            {
                this.resultEachNum.RemoveAt(this.resultEachNum.Count - 1);
            }
            this.dotExistsInResultEachNum = false;  //清空后dot存在标志置false
            refreshDisplay();
        }

        private void simpleButton_backspace_Click(object sender, EventArgs e)
        {
            if (this.resultEachNum.Count > 1)
            {
                int removeChIndex = this.resultEachNum.Count - 1;
                char chRemove = this.resultEachNum.ElementAt(removeChIndex);
                this.resultEachNum.RemoveAt(this.resultEachNum.Count - 1);
                if (chRemove == '.')
                {
                    this.dotExistsInResultEachNum = false;  //退格删除的是dot的话，dot存在标志置false
                }
            }

            refreshDisplay();
        }

        private void simpleButton_enter_Click(object sender, EventArgs e)
        {
            //判断数据resultEachNum是否合法
            if (judgeOutOfRange() == true)
            {
                this.labelControl_outOfRange.Visible = true;
            }
            
            calcResultNum();
            MessageBox.Show(resultNum.ToString());
            
        }



    }
}
