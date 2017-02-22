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

namespace Calculator
{
    public partial class Calculator : Form
    {
        private System.Windows.Forms.FlowLayoutPanel flpHistory;
        private System.Windows.Forms.FlowLayoutPanel flpMemory;
        private Standard standard;
        private LeftMenu lm;

        #region 防止因窗体控件太多出现闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!DesignMode)
                {
                    if (MaximizeBox) { cp.Style |= (int)0x00010000; }
                    if (MinimizeBox) { cp.Style |= (int)0x00020000; }
                    cp.ExStyle |= (int)0x02000000;  //防止因窗体控件太多出现闪烁
                    cp.ExStyle |= (int)0x02000000L;
                    //cp.ClassStyle |= (int)ClassStyle.CS_DropSHADOW;  //实现窗体边框阴影效果
                }
                return cp;
            }
        } 
        #endregion

        public Calculator()
        {
            InitializeComponent();

            flpHistory = new FlowLayoutPanel();
            flpMemory = new FlowLayoutPanel();
            standard = new Standard(labEquation, labResult, AddNewHistory);
            standard = new Standard(labEquation, labResult, AddNewHistory);
            lm = new LeftMenu();
            //
            //lm
            //
            lm.BringToFront();
            lm.Dock = DockStyle.Left;
            lm.Visible = false;
            //
            // flpHistory
            //
            flpHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            flpHistory.Margin = new System.Windows.Forms.Padding(0);
            flpHistory.BackColor = System.Drawing.Color.Transparent;
            flpHistory.AutoScroll = false;
            flpHistory.FlowDirection = FlowDirection.TopDown;
            flpHistory.WrapContents = false;
            flpHistory.HorizontalScroll.Maximum = 0;
            flpHistory.AutoScroll = true;
            flpHistory.Visible = true;
            //
            // flpMemory
            //
            flpHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            flpHistory.Margin = new System.Windows.Forms.Padding(0);
            flpHistory.BackColor = System.Drawing.Color.Transparent;
            flpHistory.AutoScroll = false;
            flpHistory.FlowDirection = FlowDirection.TopDown;
            flpHistory.WrapContents = false;
            flpHistory.HorizontalScroll.Maximum = 0;
            flpHistory.AutoScroll = true;
            flpMemory.Visible = false;
            //
            // standard
            //
            standard.Dock = System.Windows.Forms.DockStyle.Fill;
            standard.Margin = new System.Windows.Forms.Padding(0);
            standard.Visible = true;
            //
            //
            //
            this.spc1RT.Panel2.Controls.Add(this.flpHistory);
            this.spc1RT.Panel2.Controls.Add(this.flpMemory);
            this.panel1L5.Controls.Add(this.standard);
            this.Controls.Add(this.lm);

            this.labEquation.Text = "";
            this.labResult.Text = "0";
            this.MinimumSize = new Size(350, 555);
            this.Size = new Size(750, 600);
            this.btnMC.Enabled = false;
            this.btnMR.Enabled = false;
            this.btnTrash.Visible = false;
        }

        #region Add New History
        private void AddNewHistory(string str1, string str2)
        {
            History his = new History(str1, str2);
            his.Click += new System.EventHandler(this.History_Click);
            his.label1.Click += new System.EventHandler(this.History_Click);
            his.label2.Click += new System.EventHandler(this.History_Click);
            his.Leave += new System.EventHandler(this.History_Leave);
            flpHistory.Controls.Add(his);
            flpHistory.ScrollControlIntoView(his);
            this.btnTrash.Visible = true;
        }

        private void History_Click(object sender, EventArgs e)
        {
            History his = new History("", "");
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                Label lab = (Label)sender;
                his = (History)lab.Parent;
            }
            else if (sender.GetType().ToString() == "Calculator.History")
            {
                his = (History)sender;
            }
            his.Focus();
            this.labEquation.Text = his.label1.Text;
            this.labResult.Text = his.label2.Text;
        }

        private void History_Leave(object sender, EventArgs e)
        {
            standard.labC_Click(new object(), new EventArgs());
        }
        #endregion

        #region Hide spc1.Panel2
        private void Calculator_Resize(object sender, EventArgs e)
        {
            //Console.WriteLine(this.Size.Width.ToString() + "  " + this.Size.Height.ToString());
            int collapsedNum = 500;
            if (this.Size.Width < collapsedNum)
            {
                spc1.Panel2Collapsed = true;
            }
            if (this.Size.Width >= collapsedNum)
            {
                spc1.Panel2Collapsed = false;
            }
        }
        #endregion

        #region History And Memory

        private void btnHistory_Click(object sender, EventArgs e)
        {
            flpMemory.Visible = false;
            flpHistory.Visible = true;

            this.btnMemory.ForeColor = System.Drawing.Color.Gray;
            this.btnHistory.ForeColor = System.Drawing.Color.Black;
        }

        private void btnMemory_Click(object sender, EventArgs e)
        {
            flpMemory.Visible = true;
            flpHistory.Visible = false;

            this.btnMemory.ForeColor = System.Drawing.Color.Black;
            this.btnHistory.ForeColor = System.Drawing.Color.Gray;
        }

        #endregion

        private void btnTrash_Click(object sender, EventArgs e)
        {
            this.btnTrash.Visible = false;
            this.flpHistory.Controls.Clear();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            lm.BringToFront();
            lm.Visible = true;
        }
    }
}
