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
using DigitalSignature;
using System.IO;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getSocket();

            thread = new Thread(RecvDetail);
            thread.IsBackground = true;
            thread.Start();

            StatusEnum status = StatusEnum.getdetail;
            string strMsg = "";

            byte[] arrMsg = null;
            arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);

            byte[] newArr = new byte[arrMsg.Length + 1];
            //将当前对象的类型转成标识数值存入新数组的第一个元素
            newArr[0] = (byte)status;
            //将 数组的 数据 复制到 新数组中（从新数组第二个位置开始存放）
            arrMsg.CopyTo(newArr, 1);
            //发送 带标识位的 新消息数组
            socket.Send(newArr);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择下载路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                getSocket();

                this.txtFilePath.Text = Path.Combine(dialog.SelectedPath, this.comboBox1.SelectedItem.ToString());

                thread = new Thread(RecvFile);
                thread.IsBackground = true;
                thread.Start(txtFilePath.Text);

                StatusEnum status = StatusEnum.getfile;
                string strMsg = this.comboBox1.SelectedItem.ToString();

                byte[] arrMsg = null;
                arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);

                byte[] newArr = new byte[arrMsg.Length + 1];
                //将当前对象的类型转成标识数值存入新数组的第一个元素
                newArr[0] = (byte)status;
                //将 数组的 数据 复制到 新数组中（从新数组第二个位置开始存放）
                arrMsg.CopyTo(newArr, 1);
                //发送 带标识位的 新消息数组
                socket.Send(newArr);
            }
        }

        private void RecvFile(object objPath)
        {
            string FilePath = objPath as string;

            //1.接收
            //声明字节数组，一次接收数据的长度为 10240 字节  
            byte[] recvBytes = new byte[1024 * 10];
            //返回实际接收内容的字节数  
            int bytes = 0;

            int FileLength = 0; // 900866;
            int ReceivedLength = 0;

            //创建文件流，然后让文件流来根据路径创建一个文件
            FileStream fs = new FileStream(FilePath, FileMode.Create);

            //1.0 接收签名
            bytes = socket.Receive(recvBytes, 172, 0);
            string strSignature = Encoding.UTF8.GetString(recvBytes, 0, bytes);
            this.txtSignature.Text = strSignature;

            //1.1 接收文件长度
            bytes = socket.Receive(recvBytes, 20, 0);
            //将读取的字节数转换为字符串  
            string fileLength = Encoding.UTF8.GetString(recvBytes, 0, bytes);
            FileLength = Convert.ToInt32(fileLength);

            //1.2接收文件内容
            while (ReceivedLength < FileLength)
            {
                bytes = socket.Receive(recvBytes, recvBytes.Length, 0);
                ReceivedLength += bytes;
                fs.Write(recvBytes, 0, bytes);
            }

            fs.Flush();
            fs.Close();


            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        private void RecvDetail()
        {
            try
            {
                byte[] buffer = new byte[1024 * 5];
                int length = socket.Receive(buffer);

                string str = Encoding.UTF8.GetString(buffer, 1, length - 1);
                string[] s1 = str.Split('|');

                this.comboBox1.Items.Clear();
                foreach (string s in s1)
                {
                    this.comboBox1.Items.Add(s);
                }

                this.comboBox1.SelectedIndex = 0;
                this.btnDownload.Enabled = true;

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ReceMsg throw :" + e.Message);
            }
        }

        Socket socket;
        Thread thread;

        private void getSocket()
        {
            //IPAddress ip = IPAddress.Parse("127.0.0.1");    //本机
            IPAddress ip = IPAddress.Parse("123.206.24.215"); 
            int port = 8990;
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(ip, port);
            this.socket.Connect(endpoint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnDownload.Enabled = false;
        }

        private void btnGetRSAPub_Click(object sender, EventArgs e)
        {
            getSocket();

            thread = new Thread(RecvRSAPub);
            thread.IsBackground = true;
            thread.Start();

            StatusEnum status = StatusEnum.getRSAPub;
            string strMsg = "";

            byte[] arrMsg = null;
            arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);

            byte[] newArr = new byte[arrMsg.Length + 1];
            //将当前对象的类型转成标识数值存入新数组的第一个元素
            newArr[0] = (byte)status;
            //将 数组的 数据 复制到 新数组中（从新数组第二个位置开始存放）
            arrMsg.CopyTo(newArr, 1);
            //发送 带标识位的 新消息数组
            socket.Send(newArr);
        }

        private void RecvRSAPub()
        {
            byte[] buffer = new byte[1024];
            int length = socket.Receive(buffer);

            string str = Encoding.UTF8.GetString(buffer, 1, length - 1);

            this.txtRSAPub.Text = str;

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if(txtFilePath.Text == "" || txtRSAPub.Text == "" || txtSignature.Text == "")
            {
                return;
            }
            myRSA my = new myRSA();
            string publickey = this.txtRSAPub.Text;
            myMD5 m5 = new myMD5(1,this.txtFilePath.Text);
            //验证
            bool b = myRSA.VerifySigned(m5.getMD5(), this.txtSignature.Text, publickey);
            if(b)
                MessageBox.Show("验证成功");
            else
                MessageBox.Show("验证失败");
        }
    }
}
