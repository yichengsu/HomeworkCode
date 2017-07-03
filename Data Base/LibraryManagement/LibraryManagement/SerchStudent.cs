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
    public partial class SerchStudent : Form
    {
        AdminForm f;

        public SerchStudent()
        {
            InitializeComponent();
        }

        public SerchStudent(AdminForm f) : this()
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
                dt = SQLHelper.ExecuteQuery("select sID as '图书证号',sName as '姓名',sDepartment as '学院',sSpecialty as '专业' from Student");
            }
            else if (txtID.Text != "" && txtName.Text == "")
            {
                dt = SQLHelper.ExecuteQuery("select sID as '图书证号',sName as '姓名',sDepartment as '学院',sSpecialty as '专业' from Student where sID=@id", new SqlParameter("@id", txtID.Text));
            }
            else if (txtID.Text == "" && txtName.Text != "")
            {
                dt = SQLHelper.ExecuteQuery("select sID as '图书证号',sName as '姓名',sDepartment as '学院',sSpecialty as '专业' from Student where sName=@name", new SqlParameter("@name", txtName.Text));
            }
            else if (txtID.Text != "" && txtName.Text != "")
            {
                dt = SQLHelper.ExecuteQuery("select sID as '图书证号',sName as '姓名',sDepartment as '学院',sSpecialty as '专业' from Student where sName=@name and sID=@id",
                    new SqlParameter("@name", txtName.Text),
                    new SqlParameter("@id", txtID.Text));
            }
            f.SetDT(dt, DataType.Students);
            this.Close();
        }
    }
}
