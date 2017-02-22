using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatServer
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        Socket socket = null;
        Thread thread = null;
        int Log = 0;

        Manager man = null;


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tbStatus.Text.ToString().Trim() == "Running")
                return;
            try
            {
                tbStatus.Text = "Running";

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ip = IPAddress.Parse(tbIP.Text.Trim());
                IPEndPoint point = new IPEndPoint(ip, int.Parse(tbPort.Text.Trim()));

                socket.Bind(point);
                socket.Listen(5);
                
                man = new Manager(AddMsg);

                thread = new Thread(watching);
                thread.IsBackground = true;
                thread.Start();

                AddMsg("[--->] Start watching.");
            }
            catch (Exception ex)
            {
                AddMsg("[!!!!] Exception(Start)：" + ex.Message);
            }
        }

        bool isWatching = true;

        void watching()
        {
            try
            {
                while (isWatching)
                {
                    Socket soc = socket.Accept();
                    man.AddClient(soc);
                }
            }
            catch (SocketException ex1)
            {
                AddMsg("[!!!!] Exception(Socket)：" + ex1.Message);
            }
            catch (Exception ex)
            {
                AddMsg("[!!!!] Exception(Watching)：" + ex.Source + "@" + ex.Message + "@" + ex.TargetSite + "@" + ex.InnerException + "@" + ex.Data);
            }
        }

        void AddMsg(string str)
        {
            tbLog.AppendText("[TIME] " + DateTime.Now.ToString() + "\r\n");
            tbLog.AppendText(str + "\r\n\r\n");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (tbStatus.Text.ToString().Trim() == "Stop")
                return;
            isWatching = false;
            socket.Close();
            tbStatus.Text = "Stop";
            AddMsg("[--->] Stop watching.");
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (man != null)
            {
                tbPeopleCount.Text = man.getCount().ToString();
            }
        }

        private void tmLog_Tick(object sender, EventArgs e)
        {
            if (tbLog.TextLength > 20480)
            {
                string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Log" + (Log++) + ".txt";
                using (FileStream fsm = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    byte[] newbuffer = Encoding.UTF8.GetBytes(tbLog.Text);
                    fsm.Write(newbuffer, 0, newbuffer.Length);
                }
                tbLog.Text = "";
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            tbIP.Text = "0.0.0.0";
            tbStatus.Text = "Stop";
            tbPort.Text = "8990";
            tbPeopleCount.Text = "0";
            tbStatus.ReadOnly = true;
            tbPeopleCount.ReadOnly = true;
            tbLog.ReadOnly = true;
        }
    }
}
