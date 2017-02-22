using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Standard : UserControl
    {
        private string divideZero = "Cannot divide by zero";
        private Label label1;
        private Label label2;
        private bool flag;
        private bool flagDot;
        private double result1 = 0;
        private double result2 = 0;
        private char symbol;

        public delegate void AddNewHistory(string str1, string str2);
        AddNewHistory addhis;

        public Standard(Label l1, Label l2, AddNewHistory addhis)
        {
            InitializeComponent();
            this.label1 = l1;
            this.label2 = l2;
            this.flag = false;
            this.flagDot = false;
            this.addhis = addhis;
        }

        #region Mouse Event
        private void Standard_MouseDown(object sender, MouseEventArgs e)
        {
            Label lab = new Label();
            lab = (Label)sender;
            //this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            lab.BackColor = System.Drawing.Color.Silver;
        }

        private void Standard_MouseUp(object sender, MouseEventArgs e)
        {
            Label lab = new Label();
            lab = (Label)sender;
            //this.BackColor = System.Drawing.SystemColors.ControlDark;
            lab.BackColor = System.Drawing.Color.LightGray;
        }

        private void Standard_MouseEnter(object sender, EventArgs e)
        {
            Label lab = new Label();
            lab = (Label)sender;
            //this.BackColor = System.Drawing.SystemColors.ControlDark;
            lab.BackColor = System.Drawing.Color.LightGray;
        }

        private void Standard_MouseLeave(object sender, EventArgs e)
        {
            Label lab = new Label();
            lab = (Label)sender;
            //this.BackColor = System.Drawing.SystemColors.Control;
            lab.BackColor = System.Drawing.Color.White;
        }

        private void Standard_Gainsboro_MouseLeave(object sender, EventArgs e)
        {
            Label lab = new Label();
            lab = (Label)sender;
            //this.BackColor = System.Drawing.SystemColors.Control;
            lab.BackColor = Color.FromArgb(242, 244, 244);
        }
        #endregion

        private void Numbers_Click(object sender, EventArgs e)
        {
            ((Label)sender).Focus();
            if (!flag)
            {
                flag = true;
                this.label2.Text = "";
            }
            if (this.label2.Text.Length < 9)
            {
                Label lab = (Label)sender;
                this.label2.Text += lab.Text;
            }
            else
                return;
        }

        private void labDot_Click(object sender, EventArgs e)
        {
            ((Label)sender).Focus();
            if (!flag) flag = true;
            if (!flagDot)
            {
                flagDot = true;
                Label lab = (Label)sender;
                this.label2.Text += lab.Text;
            }
            else
                return;
        }

        private void labCE_Click(object sender, EventArgs e)
        {
            labCE.Focus();
            this.label2.Text = "0";
            flag = false;
            flagDot = false;
        }

        public void labC_Click(object sender, EventArgs e)
        {
            labC.Focus();
            this.flagDot = false;
            this.flag = false;
            this.label1.Text = "";
            this.label2.Text = "0";
            this.result1 = 0;
            this.result2 = 0;
            this.symbol = ' ';
        }

        private void labDel_Click(object sender, EventArgs e)
        {
            labDel.Focus();
            string s = this.label2.Text.Substring(label2.Text.Length - 1);
            if (s == ".") flagDot = false;
            this.label2.Text = this.label2.Text.Remove(this.label2.Text.Length - 1);
            if (this.label2.Text == "")
            {
                this.label2.Text = "0";
                flag = false;
            }
        }

        private void labPorM_Click(object sender, EventArgs e)
        {
            ((Label)sender).Focus();
            string s = label2.Text.Substring(0, 1);
            if (s == "-")
                label2.Text = label2.Text.Substring(1);
            else
                label2.Text = "-" + label2.Text;
        }

        private double compute()
        {
            double res = 0;
            switch (symbol)
            {
                case '+':
                    res = result1 + result2;
                    break;
                case '-':
                    res = result1 - result2;
                    break;
                case '×':
                    res = result1 * result2;
                    break;
                case '÷':
                    if (result2 == 0)
                        throw new Exception();
                    res = result1 / result2;
                    break;
                default:
                    break;
            }
            return res;
        }

        private void labSymbol_Click(object sender, EventArgs e)
        {
            ((Label)sender).Focus();
            string sym = ((Label)sender).Text;
            if (label2.Text.Substring(label2.Text.Length - 1) == ".")
                label2.Text = label2.Text.Remove(label2.Text.Length - 1);
            if (label1.Text == "")
            {
                label1.Text += label2.Text + " " + sym + " ";
                result1 = Convert.ToDouble(label2.Text);
            }
            else
            {
                label1.Text += label2.Text + " " + sym + " ";
                result2 = Convert.ToDouble(label2.Text);
                try
                {
                    result1 = compute();
                }
                catch (Exception ex)
                {
                    labC_Click(sender, e);
                    this.label2.Text = this.divideZero;
                    return;
                }
                label2.Text = result1.ToString();
            }
            flag = false;
            flagDot = false;
            symbol = Convert.ToChar(sym);
        }

        private void labEqual_Click(object sender, EventArgs e)
        {
            labEqual.Focus();
            if (label2.Text.Substring(label2.Text.Length - 1) == ".")
                label2.Text = label2.Text.Remove(label2.Text.Length - 1);
            string res;
            if (label1.Text == "")
            {
                label1.Text += label2.Text + " = ";
                res = label2.Text;
            }
            else
            {
                label1.Text += label2.Text + " = ";
                result2 = Convert.ToDouble(label2.Text);
                try
                {
                    result1 = compute();
                }
                catch (Exception ex)
                {
                    labC_Click(sender, e);
                    this.label2.Text = this.divideZero;
                    return;
                }
                label2.Text = result1.ToString();
                res = label2.Text;
            }
            addhis(label1.Text, label2.Text);
            labC_Click(new object(), new EventArgs());
            label2.Text = res;
        }
    }
}
