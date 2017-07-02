using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() != "")
            {
                byte[] arr = null;
                arr = System.Text.Encoding.UTF8.GetBytes(textBox1.Text.Trim());
                if (arr.Length > 50)
                {
                    MessageBox.Show("用户名过长");
                }
                else
                {
                    ChatRoom f = new ChatRoom(textBox1.Text.Trim());
                    f.Show();
                    this.Hide();
                }
            }
        }
    }
}
