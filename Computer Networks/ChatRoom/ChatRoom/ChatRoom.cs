using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class ChatRoom : Form
    {
        private string userName;
        private Socket socket;
        private Thread thread;

        private ChatRoom()
        {
            InitializeComponent();
        }

        public ChatRoom(string name) : this()
        {
            this.Text = this.Text + " - " + name;
            userName = name;

            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            //flpMessages
            //
            flpMessages.AutoScroll = false;
            flpMessages.FlowDirection = FlowDirection.TopDown;
            flpMessages.WrapContents = false;
            flpMessages.HorizontalScroll.Maximum = 0;
            flpMessages.AutoScroll = true;
            //
            //flpUsers
            //
            //flpUsers.AutoScroll = false;
            //flpUsers.FlowDirection = FlowDirection.TopDown;
            //flpUsers.WrapContents = false;
            //flpUsers.HorizontalScroll.Maximum = 0;
            //flpUsers.AutoScroll = true;
            //
            //socket
            //
            #region socket
            //IPAddress ip = IPAddress.Parse("123.206.24.215");  //服务器
            IPAddress ip = IPAddress.Parse("127.0.0.1");    //本机
            int port = 8990;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(ip, port);
            socket.Connect(endpoint);
            #endregion
            //
            //login
            //
            thread = new Thread(ReceMsg);
            thread.IsBackground = true;//设置后台线程
            thread.Start();
            byte[] arr = null;
            arr = System.Text.Encoding.UTF8.GetBytes(userName);
            byte[] newArr = new byte[arr.Length + 1];
            newArr[0] = (byte)StatusEnum.login;
            arr.CopyTo(newArr, 1);
            socket.Send(newArr);

            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        private void ReceMsg()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int length = socket.Receive(buffer);
                    if (buffer[0] == (byte)StatusEnum.message)
                    {
                        /// 普通消息
                        string str = Encoding.UTF8.GetString(buffer, 1, length - 1);
                        Console.WriteLine(str.Length);
                        string name = str.Substring(0, 50).Trim();
                        string msg = str.Substring(50, str.Length - 50);
                        Addmsg(name, msg);
                    }
                    else if (buffer[0] == (byte)StatusEnum.users)
                    {
                        /// 用户列表
                        string str = Encoding.UTF8.GetString(buffer, 1, length - 1);
                        updateUsers(str);
                    }
                    else
                    {
                        ;
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("ReceMsg throw :" + e.Message);
                }
            }
        }

        private static object addmsg = new object();
        private void Addmsg(string name, string msg)
        {
            try
            {
                lock (addmsg)
                {
                    string title = name + "  " + DateTime.Now.ToString();
                    // 解析消息，是否是自己发送的，如果是自己发送的则右对齐
                    Message m;
                    if (name == userName)
                        m = new Message(name, msg, true);
                    else
                        m = new Message(name, msg, false);
                    // 加入消息列表
                    if (this.flpMessages.InvokeRequired)
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            this.flpMessages.Controls.Add(m);
                        }));
                    }
                    else
                        this.flpMessages.Controls.Add(m);

                    flpMessages.ScrollControlIntoView(m);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Addmsg throw :" + e.Message);
            }
        }

        private void updateUsers(string str)
        {
            try
            {
                // 刷新用户列表
                listBox.Items.Clear();
                const int nameWidth = 50;
                string[] names = SplitByLen(str, nameWidth);
                foreach (string item in names)
                {
                    string name = " " + item.Trim();
                    this.listBox.Items.Add(name);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("updateUsers throw :" + e.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // 发送消息
            if (this.txtMsg.Text.Trim() == "")
                return;
            string s = userName.PadLeft(50) + this.txtMsg.Text;
            byte[] arr = null;
            arr = System.Text.Encoding.UTF8.GetBytes(s);
            byte[] newArr = new byte[arr.Length + 1];
            newArr[0] = (byte)StatusEnum.message;
            arr.CopyTo(newArr, 1);
            socket.Send(newArr);

            this.txtMsg.Text = "";
        }

        private void ChatRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>  
        /// 按字符串长度切分成数组  
        /// </summary>  
        /// <param name="str">原字符串</param>  
        /// <param name="separatorCharNum">切分长度</param>  
        /// <returns>字符串数组</returns>  
        private string[] SplitByLen(string str, int separatorCharNum)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= separatorCharNum)
            {
                return new string[] { str };
            }
            string tempStr = str;
            List<string> strList = new List<string>();
            int iMax = Convert.ToInt32(Math.Ceiling(str.Length / (separatorCharNum * 1.0)));//获取循环次数  
            for (int i = 1; i <= iMax; i++)
            {
                string currMsg = tempStr.Substring(0, tempStr.Length > separatorCharNum ? separatorCharNum : tempStr.Length);
                strList.Add(currMsg);
                if (tempStr.Length > separatorCharNum)
                {
                    tempStr = tempStr.Substring(separatorCharNum, tempStr.Length - separatorCharNum);
                }
            }
            return strList.ToArray();
        }

        private void flpMessages_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, flpMessages.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
    }
}
