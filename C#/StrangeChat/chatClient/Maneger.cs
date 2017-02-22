using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace chatClient
{
    class Maneger
    {
        Socket socket;
        Thread thread;

        public delegate void DGSendMsg(string str);
        DGSendMsg dgSendMsg;

        public Maneger(DGSendMsg dgSendMsg)
        {
            this.dgSendMsg = dgSendMsg;
            //IPAddress ip = IPAddress.Parse("123.206.24.215");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 8990;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(ip, port);
            socket.Connect(endpoint);

            thread = new Thread(ReceMsg);
            thread.IsBackground = true;//设置后台线程
            thread.Start();

            socket.Send(Encoding.UTF8.GetBytes("!--LOGIN--!"));
            dgSendMsg("正在匹配，请稍后...");
        }

        private void ReceMsg()
        {
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024];
                int length = socket.Receive(buffer);
                string ReceiveMsg = Encoding.UTF8.GetString(buffer, 0, length);
                if (ReceiveMsg == "!--LOGIN SUCCESS--!")
                {
                    dgSendMsg("匹配成功。");
                }
                else if (ReceiveMsg == "!--OFFLINE--!")
                {
                    dgSendMsg("正在重新匹配，请稍后...");
                }
                else
                {
                    dgSendMsg("[RECV] " + ReceiveMsg);
                }
            }
        }

        public void SendMsg(string str)
        {
            dgSendMsg("[SEND] " + str);
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            socket.Send(buffer);//发送新数组中的数据
        }
    }
}
