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
    public partial class AddBook : Form
    {
        string id;

        public AddBook()
        {
            InitializeComponent();
            id = "";
        }

        public AddBook(string id) : this()
        {
            this.id = id;
            DataTable dt = SQLHelper.ExecuteQuery("select * from Books where bISBN=@id",
                        new System.Data.SqlClient.SqlParameter("@id", id));
            this.txtISBN.Text = dt.Rows[0]["bISBN"].ToString();
            this.txtISBN.Enabled = false;
            this.txtName.Text = dt.Rows[0]["bName"].ToString();
            this.txtDate.Text = Convert.ToDateTime(dt.Rows[0]["bDate"]).ToString("yyyy-MM-dd");
            this.txtPress.Text = dt.Rows[0]["bPress"].ToString();
            this.txtPlace.Text = dt.Rows[0]["bPlace"].ToString();
            this.txtNumber.Text = dt.Rows[0]["bNumber"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int res = 0;
            this.txtISBN.Text = txtISBN.Text.Trim();
            this.txtName.Text = txtName.Text.Trim();
            this.txtDate.Text = txtDate.Text.Trim();
            this.txtPress.Text = txtPress.Text.Trim();
            this.txtPlace.Text = txtPlace.Text.Trim();
            this.txtNumber.Text = txtNumber.Text.Trim();
            if (txtISBN.Text == "" || txtName.Text == "" || txtDate.Text == "" || txtPress.Text == "" || txtPlace.Text == "" || txtNumber.Text == "")
            {
                return;
            }

            try
            {
                if (id == "")
                {
                    res = SQLHelper.ExecuteNonQuery("insert into Books values(@isbn,@name,@date,@press,@place,@num)",
                                            new System.Data.SqlClient.SqlParameter("@isbn", txtISBN.Text),
                                            new System.Data.SqlClient.SqlParameter("@name", txtName.Text),
                                            new System.Data.SqlClient.SqlParameter("@date", txtDate.Text),
                                            new System.Data.SqlClient.SqlParameter("@press", txtPress.Text),
                                            new System.Data.SqlClient.SqlParameter("@place", txtPlace.Text),
                                            new System.Data.SqlClient.SqlParameter("@num", txtNumber.Text));
                }
                else
                {
                    res = SQLHelper.ExecuteNonQuery("update Books set bName=@name,bDate=@date,bPress=@press,bPlace=@place,bNumber=@num where bISBN=@isbn",
                                            new System.Data.SqlClient.SqlParameter("@isbn", txtISBN.Text),
                                            new System.Data.SqlClient.SqlParameter("@name", txtName.Text),
                                            new System.Data.SqlClient.SqlParameter("@date", txtDate.Text),
                                            new System.Data.SqlClient.SqlParameter("@press", txtPress.Text),
                                            new System.Data.SqlClient.SqlParameter("@place", txtPlace.Text),
                                            new System.Data.SqlClient.SqlParameter("@num", txtNumber.Text));
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
                if (id == "")
                {
                    this.txtISBN.Text = "";
                    this.txtDate.Text = "";
                    this.txtName.Text = "";
                    this.txtPlace.Text = "";
                    this.txtNumber.Text = "";
                    this.txtPress.Text = "";
                }
                else
                    this.Close();
            }
        }
    }
}
