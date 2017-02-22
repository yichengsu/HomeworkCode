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
    public partial class History : UserControl
    {
        public History(string equation, string result)
        {
            InitializeComponent();
            this.label1.Text = equation;
            this.label2.Text = result;
        }

        private void History_MouseDown(object sender, MouseEventArgs e)
        {
            //this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackColor = System.Drawing.Color.Silver;
        }

        private void History_MouseUp(object sender, MouseEventArgs e)
        {
            //this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackColor = System.Drawing.Color.LightGray;
        }

        private void History_MouseEnter(object sender, EventArgs e)
        {
            //this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackColor = System.Drawing.Color.LightGray;
        }

        private void History_MouseLeave(object sender, EventArgs e)
        {
            //this.BackColor = System.Drawing.SystemColors.Control;
            this.BackColor = System.Drawing.Color.White;
        }
    }
}
