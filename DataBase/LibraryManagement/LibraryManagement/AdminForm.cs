using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class AdminForm : Form
    {
        Login l;
        System.Data.DataTable dt;
        DataType dtype;

        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(Login l) : this()
        {
            this.l = l;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerchStudent ss = new SerchStudent(this);
            ss.ShowDialog();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            l.back();
        }

        public void SetDT(System.Data.DataTable dt, DataType dtype)
        {
            this.dt = dt;
            this.dataGridView1.DataSource = dt.DefaultView;
            this.dtype = dtype;

            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnReturn.Enabled = false;
            this.btnBorrow.Enabled = false;
            this.btnChangePwd.Enabled = false;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            string strSql = "select bISBN as 'ISBN',bName as '书名',bPlace as '位置',bNumber as '剩余数量' from Books";
            dt = SQLHelper.ExecuteQuery(strSql);
            this.SetDT(dt, DataType.Books);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchBooks sb = new SearchBooks(this);
            sb.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchBorrow sb = new SearchBorrow(this);
            sb.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtype == DataType.Books)
            {
                this.btnDelete.Enabled = true;
                this.btnUpdate.Enabled = true;
            }
            else if (this.dtype == DataType.Borrow)
            {
                this.btnReturn.Enabled = true;
            }
            else if (this.dtype == DataType.Students)
            {
                this.btnDelete.Enabled = true;
                this.btnUpdate.Enabled = true;
                this.btnBorrow.Enabled = true;
                this.btnChangePwd.Enabled = true;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string strResidue = this.dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["剩余日期"].Value.ToString();
            int residu = Convert.ToInt32(strResidue);
            DialogResult dr;
            if (residu > 0)
            {
                dr = MessageBox.Show("未欠费，是否还书？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                double free = Math.Abs(residu) * 0.2;
                dr = MessageBox.Show("已欠费" + free.ToString() + "元，是否还书？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
            }
            if (dr == DialogResult.OK)
            {
                string ISBN = this.dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["ISBN"].Value.ToString();
                string id = this.dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["图书证号"].Value.ToString();
                SQLHelper.ExecuteNonQuery("update Books set bNumber=bNumber+1 where bISBN=@ISBN", new SqlParameter("@ISBN", ISBN));
                int res = SQLHelper.ExecuteNonQuery("delete from Borrow where bID=@id and bISBN=@ISBN",
                    new SqlParameter("@id", id),
                    new SqlParameter("@ISBN", ISBN));
                if (res == 0)
                {
                    MessageBox.Show("未删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            ChangePwd p = new ChangePwd(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["图书证号"].Value.ToString());
            p.ShowDialog();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            string id = this.dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["图书证号"].Value.ToString();
            System.Data.DataTable d = SQLHelper.ExecuteQuery("select * from Books_Borrow where id=@id", new SqlParameter("@id", id));
            foreach (DataRow i in d.Rows)
            {
                int s = Convert.ToInt32(i["residue"].ToString());
                if (s < 0)
                {
                    MessageBox.Show("有欠款，请还清欠款后再借书。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            System.Data.DataTable d2 = SQLHelper.ExecuteQuery("select * from Student where sID=@id", new SqlParameter("@id", id));
            int limit = Convert.ToInt32(d2.Rows[0]["sLimit"].ToString());
            if (d.Rows.Count >= limit)
            {
                MessageBox.Show("无法借书，请还书后再借。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            Borrow b = new Borrow(id);
            b.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
            if (dr == DialogResult.OK)
            {
                int res = 0;
                if (this.dtype == DataType.Books)
                {
                    string ISBN = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ISBN"].Value.ToString();
                    try
                    {
                        res = SQLHelper.ExecuteNonQuery("delete from Books where bISBN=@isbn",
                                    new SqlParameter("@isbn", ISBN));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("该图书已被借出，无法删除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (this.dtype == DataType.Borrow)
                {
                    return;
                }
                else if (this.dtype == DataType.Students)
                {
                    string id = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["图书证号"].Value.ToString();
                    try
                    {
                        SQLHelper.ExecuteNonQuery("delete from Login where ID=@id",
                                    new SqlParameter("@id", id));
                        res = SQLHelper.ExecuteNonQuery("delete from Student where sID=@id",
                                    new SqlParameter("@id", id));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("该学生有书未还，无法删除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                if (res == 0)
                    MessageBox.Show("未删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                else
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }

        private void btnAddStu_Click(object sender, EventArgs e)
        {
            AddStudent a = new AddStudent();
            a.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dtype == DataType.Books)
            {
                string id = this.dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["ISBN"].Value.ToString();
                AddBook b = new AddBook(id);
                b.Text = "修改图书";
                b.ShowDialog();
            }
            else if (this.dtype == DataType.Borrow)
            {
                return;
            }
            else if (this.dtype == DataType.Students)
            {
                string id = this.dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["图书证号"].Value.ToString();
                AddStudent s = new AddStudent(id);
                s.Text = "修改学生";
                s.ShowDialog();
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBook b = new AddBook();
            b.ShowDialog();
        }

        private void ToWps()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Office2007-2013(*.xlsx)|*.xlsx|Office2003(*.xls)|*.xls|WPS(*.et)|*.et";
            save.Title = "请选择要导出数据的位置";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string fileName = save.FileName;
                try
                {
                    StreamWriter sw = new StreamWriter(fileName, false, Encoding.GetEncoding("gb2312"));

                    StringBuilder sb = new StringBuilder();
                    for (int k = 0; k < dataGridView1.ColumnCount; k++)
                    {
                        // 添加列名称  
                        sb.Append(dataGridView1.Columns[k].HeaderText + "\t");
                    }
                    sb.Append(Environment.NewLine);
                    // 添加行数据  
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        DataRow row = dt.Rows[i];
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            // 根据列数追加行数据  
                            sb.Append(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t");
                        }
                        sb.Append(Environment.NewLine);
                    }
                    sw.Write(sb.ToString());
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                catch
                {
                    MessageBox.Show("请保存或关闭可能已打开的Excel文件。", "提示");
                }
                finally
                {
                    dt.Dispose();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ToWps();
        }
    }
}

