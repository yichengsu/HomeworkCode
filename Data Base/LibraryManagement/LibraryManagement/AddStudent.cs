using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class AddStudent : Form
    {
        string s;
        public AddStudent()
        {
            InitializeComponent();
            s = "";
        }

        public AddStudent(string s) : this()
        {
            this.s = s;
            DataTable dt = SQLHelper.ExecuteQuery("select * from Student where sID=@id",
                new System.Data.SqlClient.SqlParameter("@id", s));
            this.txtDep.Text = dt.Rows[0]["sDepartment"].ToString();
            this.txtID.Text = dt.Rows[0]["sID"].ToString();
            this.txtID.Enabled = false;
            this.txtLimit.Text = dt.Rows[0]["sLimit"].ToString();
            this.txtName.Text = dt.Rows[0]["sName"].ToString();
            this.txtSpe.Text = dt.Rows[0]["sSpecialty"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int res = 0;
            this.txtDep.Text = txtDep.Text.Trim();
            this.txtID.Text = txtID.Text.Trim();
            this.txtLimit.Text = txtLimit.Text.Trim();
            this.txtName.Text = txtName.Text.Trim();
            this.txtSpe.Text = txtSpe.Text.Trim();
            if (this.txtDep.Text == "" || txtID.Text == "" || txtLimit.Text == "" || txtName.Text == "" || txtSpe.Text == "")
            {
                return;
            }
            try
            {
                if (s == "")
                {
                    res = SQLHelper.ExecuteNonQuery("insert into Student values(@id,@name,@dep,@spe,@limit)",
                                            new System.Data.SqlClient.SqlParameter("@id", txtID.Text),
                                            new System.Data.SqlClient.SqlParameter("@name", txtName.Text),
                                            new System.Data.SqlClient.SqlParameter("@dep", txtDep.Text),
                                            new System.Data.SqlClient.SqlParameter("@spe", txtSpe.Text),
                                            new System.Data.SqlClient.SqlParameter("@limit", txtLimit.Text));
                    SQLHelper.ExecuteNonQuery("insert into Login values(@id,@pwd)",
                                            new System.Data.SqlClient.SqlParameter("@id", txtID.Text),
                                            new System.Data.SqlClient.SqlParameter("@pwd", txtID.Text));
                }
                else
                {
                    res = SQLHelper.ExecuteNonQuery("update Student set sName=@name,sDepartment=@dep,sSpecialty=@spe,sLimit=@limit where sID=@id",
                                            new System.Data.SqlClient.SqlParameter("@id", txtID.Text),
                                            new System.Data.SqlClient.SqlParameter("@name", txtName.Text),
                                            new System.Data.SqlClient.SqlParameter("@dep", txtDep.Text),
                                            new System.Data.SqlClient.SqlParameter("@spe", txtSpe.Text),
                                            new System.Data.SqlClient.SqlParameter("@limit", txtLimit.Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("未成功，请再次尝试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (res == 0)
                MessageBox.Show("未成功，请再次尝试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                MessageBox.Show("成功。", "提示", MessageBoxButtons.OK);
                if (s == "")
                {
                    this.txtDep.Text = "";
                    this.txtID.Text = "";
                    this.txtLimit.Text = "";
                    this.txtName.Text = "";
                    this.txtSpe.Text = "";
                }
                else
                    this.Close();
            }
        }
    }
}
