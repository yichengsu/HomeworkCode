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
    public partial class LeftMenu : UserControl
    {
        public LeftMenu()
        {
            InitializeComponent();
            
            panelMenu.HorizontalScroll.Maximum = 0;
            panelMenu.AutoScroll = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        #region Menu Mouse Event
        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            Label lab = new Label();
            lab = (Label)sender;
            //this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            lab.BackColor = System.Drawing.Color.Silver;
        }

        private void Menu_MouseUp(object sender, MouseEventArgs e)
        {
            Label lab = new Label();
            lab = (Label)sender;
            //this.BackColor = System.Drawing.SystemColors.ControlDark;
            lab.BackColor = System.Drawing.Color.LightGray;
        }

        private void Menu_MouseEnter(object sender, EventArgs e)
        {
            Label lab = new Label();
            lab = (Label)sender;
            //this.BackColor = System.Drawing.SystemColors.ControlDark;
            lab.BackColor = System.Drawing.Color.LightGray;
        }

        private void Menu_MouseLeave(object sender, EventArgs e)
        {
            Label lab = new Label();
            lab = (Label)sender;
            //this.BackColor = System.Drawing.SystemColors.Control;
            lab.BackColor = System.Drawing.Color.Transparent;
        }
        #endregion

        #region Setting Mouse Event
        private void Setting_MouseDown(object sender, MouseEventArgs e)
        {
            panelSetting.BackColor = System.Drawing.Color.Silver;
        }

        private void Setting_MouseUp(object sender, MouseEventArgs e)
        {
            panelSetting.BackColor = System.Drawing.Color.LightGray;
        }

        private void Setting_MouseEnter(object sender, EventArgs e)
        {
            panelSetting.BackColor = System.Drawing.Color.LightGray;
        }

        private void Setting_MouseLeave(object sender, EventArgs e)
        {
            panelSetting.BackColor = System.Drawing.Color.Transparent;
        }
        #endregion

        private void labSetting_Click(object sender, EventArgs e)
        {
            LeftInfo li = new LeftInfo();
            li.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(li);
            li.BringToFront();
        }
    }
}
