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
    public partial class Borrow : Form
    {
        string id;

        public Borrow()
        {
            InitializeComponent();
        }

        public Borrow(string id) : this()
        {
            this.id = id;
            this.labID.Text = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = SQLHelper.ExecuteQuery("select * from Books where bName=@name", new System.Data.SqlClient.SqlParameter("@name", this.textBox1.Text.Trim()));
            if (dt.Rows.Count == 0)
            {
                this.labISBN.Text = "不存在";
            }
            else
            {
                this.labISBN.Text = dt.Rows[0]["bISBN"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.labISBN.Text == "" || this.labISBN.Text == "不存在")
                return;
            DialogResult dr = MessageBox.Show("是否借书？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                DataTable dtNum = SQLHelper.ExecuteQuery("select bNumber from Books where bISBN=@isbn", new SqlParameter("@isbn", this.labISBN.Text.Trim()));
                int num = Convert.ToInt32(dtNum.Rows[0]["bNumber"].ToString());
                if (num == 0)
                {
                    MessageBox.Show("未成功,此书已无剩余。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    SQLHelper.ExecuteNonQuery("update Books set bNumber=@number where bISBN=@bISBN",
                        new SqlParameter("@number", num - 1),
                        new SqlParameter("@bISBN", labISBN.Text.Trim()));
                    int res = SQLHelper.ExecuteNonQuery("insert into Borrow values('" + labID.Text.Trim() + "','" + labISBN.Text.Trim() + "',GETDATE())");
                    if (res == 0)
                        MessageBox.Show("未成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else
                    {
                        MessageBox.Show("成功", "提示", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
        }
    }
}
