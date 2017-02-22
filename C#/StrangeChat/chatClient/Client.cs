using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        Maneger man;

        private void Client_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            man = new Maneger(AddMsg);
        }

        void AddMsg(string str)
        {
            if (str.Equals("正在重新匹配，请稍后...") || str.Equals("匹配成功。"))
            {
                tbMsgAll.Text = "";
            }
            tbMsgAll.AppendText("[TIME] " + DateTime.Now.ToString() + "\r\n");
            tbMsgAll.AppendText(str + "\r\n\r\n");
        }

        private void button_Click(object sender, EventArgs e)
        {
            man.SendMsg(tbMsg.Text);
            tbMsg.Text = "";
        }
    }
}
