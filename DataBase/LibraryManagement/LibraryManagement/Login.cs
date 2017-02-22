using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbPwd.Text == "" || tbID.Text == "")
            {
                return;
            }
            // admin
            DataTable dt = SQLHelper.ExecuteQuery("select * from Admin where ID=@name and Password=@pwd",
                new SqlParameter("@name", this.tbID.Text),
                new SqlParameter("@pwd", this.tbPwd.Text));
            if (dt.DefaultView.Count == 1)
            {
                AdminForm f = new AdminForm(this);
                f.Show();
                this.Hide();
            }
            else
            {
                // student
                dt = SQLHelper.ExecuteQuery("select * from Login where ID=@name and Password=@pwd", 
                    new SqlParameter("@name", this.tbID.Text), 
                    new SqlParameter("@pwd", this.tbPwd.Text));
                if (dt.DefaultView.Count == 1)
                {
                    MainForm mf = new MainForm(this, dt.Rows[0]["ID"].ToString());
                    mf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("您输入的账号或密码有误，请核对后仔细输入。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.tbPwd.Text = "";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label.Left = (this.label.Left + 1) % 450;
        }

        public void back()
        {
            this.Show();
            this.tbPwd.Text = "";
            this.tbID.Text = "";
        }
    }
}
