using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class Message : UserControl
    {
        private Message()
        {
            InitializeComponent();
            this.label1.ForeColor = Color.ForestGreen;

            CheckForIllegalCrossThreadCalls = false;
        }

        public Message(string name, string msg, bool b) : this()
        {
            this.label1.Text = name +"  "+ DateTime.Now.ToString();
            this.label2.Text = msg;
            if (b == true)
            {
                this.label1.TextAlign = ContentAlignment.MiddleRight;
                this.label1.ForeColor = Color.Red;

                this.label2.TextAlign = ContentAlignment.MiddleRight;
            }
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
