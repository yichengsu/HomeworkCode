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
    public partial class MainForm : Form
    {
        DataTable dtBooks;
        DataTable dt;
        Login l;

        public MainForm(Login l, string strID)
        {
            InitializeComponent();
            this.l = l;
            dt = SQLHelper.ExecuteQuery("select * from Student where sID=@id", new SqlParameter("@id", strID));
            dtBooks = SQLHelper.ExecuteQuery("select name,date,residue from Books_Borrow where id=@id", new SqlParameter("@id", strID));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            l.back();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.labName.Text = dt.Rows[0]["sName"].ToString();
            this.labID.Text = dt.Rows[0]["sID"].ToString();
            this.labDep.Text = dt.Rows[0]["sDepartment"].ToString();
            this.labSpe.Text = dt.Rows[0]["sSpecialty"].ToString();
            this.dataGridView1.DataSource = dtBooks.DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePwd cp = new ChangePwd(this, this.labID.Text);
            cp.ShowDialog();
        }
    }
}
