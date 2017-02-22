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
    public partial class ChangePwd : Form
    {
        MainForm m;

        public ChangePwd()
        {
            InitializeComponent();
        }
        public ChangePwd(MainForm m) : this()
        {
            this.m = m;
        }
        public ChangePwd(MainForm m, string stuID) : this()
        {
            this.m = m;
            this.txtId.Text = stuID;
            this.txtId.Enabled = false;
        }

        public ChangePwd(string stuID) : this()
        {
            this.txtId.Text = stuID;
            this.txtId.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Text = txtId.Text.Trim();
            txtPwd.Text = txtPwd.Text.Trim();
            txtPwd2.Text = txtPwd2.Text.Trim();
            if (txtId.Text == "" || txtPwd.Text == "" || txtPwd2.Text == "")
            {
                return;
            }
            if (this.txtId.Enabled == true)
            {

            }
            if (this.txtPwd.Text != this.txtPwd2.Text)
            {
                MessageBox.Show("密码输入不一致，请重新输入。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPwd.Text = "";
                txtPwd2.Text = "";
                return;
            }
            int res = SQLHelper.ExecuteNonQuery("update Login set Password=@pwd where ID=@id",
                new SqlParameter("@pwd", txtPwd.Text),
                new SqlParameter("@id", txtId.Text));
            if (res == 1)
            {
                MessageBox.Show("修改成功。", "成功");
                if (m != null)
                    m.Close();
                else
                    this.Close();
            }
            else
            {
                MessageBox.Show("修改失败，请再次尝试。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPwd.Text = "";
                txtPwd2.Text = "";
            }
        }
    }
}
