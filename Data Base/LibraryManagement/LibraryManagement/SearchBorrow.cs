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
    public partial class SearchBorrow : Form
    {
        AdminForm f;

        public SearchBorrow()
        {
            InitializeComponent();
        }

        public SearchBorrow(AdminForm f) : this()
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
            txtID.Text = txtID.Text.Trim();
            txtName.Text = txtName.Text.Trim();
            if (txtID.Text == "" && txtName.Text == "")
            {
                dt = SQLHelper.ExecuteQuery("select id as '图书证号',ISBN,sName as '姓名',name as '书名',date as '借书日期',residue as '剩余日期' from Books_Borrow");
            }
            else if (txtID.Text != "" && txtName.Text == "")
            {
                dt = SQLHelper.ExecuteQuery("select id as '图书证号',ISBN,sName as '姓名',name as '书名',date as '借书日期',residue as '剩余日期' from Books_Borrow where id=@id", new SqlParameter("@id", txtID.Text));
            }
            else if (txtID.Text == "" && txtName.Text != "")
            {
                dt = SQLHelper.ExecuteQuery("select id as '图书证号',ISBN,sName as '姓名',name as '书名',date as '借书日期',residue as '剩余日期' from Books_Borrow where sName=@name", new SqlParameter("@name", txtName.Text));
            }
            else if (txtID.Text != "" && txtName.Text != "")
            {
                dt = SQLHelper.ExecuteQuery("select id as '图书证号',ISBN,sName as '姓名',name as '书名',date as '借书日期',residue as '剩余日期' from Books_Borrow where sName=@name and id=@id",
                    new SqlParameter("@name", txtName.Text),
                    new SqlParameter("@id", txtID.Text));
            }
            f.SetDT(dt, DataType.Borrow);
            this.Close();
        }
    }
}
