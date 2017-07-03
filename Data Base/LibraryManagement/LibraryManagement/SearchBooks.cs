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
    public partial class SearchBooks : Form
    {
        AdminForm f;

        public SearchBooks()
        {
            InitializeComponent();
        }

        public SearchBooks(AdminForm f) : this()
        {
            this.f = f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            txtName.Text = txtName.Text.Trim();
            if (txtName.Text == "")
            {
                string strSql = "select bISBN as 'ISBN',bName as '书名',bPlace as '位置',bNumber as '剩余数量' from Books";
                dt = SQLHelper.ExecuteQuery(strSql);
            }
            else
            {
                string strSql = "select bISBN as 'ISBN',bName as '书名',bPlace as '位置',bNumber as '剩余数量' from Books where bName=@name";
                dt = SQLHelper.ExecuteQuery(strSql, new System.Data.SqlClient.SqlParameter("@name", txtName.Text));
            }
            f.SetDT(dt, DataType.Books);
            this.Close();
        }
    }
}
