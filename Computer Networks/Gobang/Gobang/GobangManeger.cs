using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gobang
{
    class GobangManeger
    {
        Socket socket;
        Thread thread;

        #region delegete
        public delegate void DGReceiveMessage(byte[] buffer, int length);
        DGReceiveMessage dgReceiveMessage;
        #endregion

        public GobangManeger(DGReceiveMessage dgReceiveMessage)
        {
            this.dgReceiveMessage = dgReceiveMessage;

            #region socket
            //IPAddress ip = IPAddress.Parse("123.206.24.215");  //服务器
            IPAddress ip = IPAddress.Parse("127.0.0.1");    //本机
            int port = 8990;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(ip, port);
            socket.Connect(endpoint);
            #endregion

            thread = new Thread(ReceMsg);
            thread.IsBackground = true;//设置后台线程
            thread.Start();

            byte[] buffer = SendMessage.MakeArrWithFlag(0);

            socket.Send(buffer);
        }

        private void ReceMsg()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int length = socket.Receive(buffer);

                    this.dgReceiveMessage(buffer, length);
                }
                catch (Exception e)
                {
                    MessageBox.Show("ReceMsg throw :" + e.Message);
                }
            }
        }

        public void SendMsg(string str)
        {
            byte[] buffer = SendMessage.MakeArrWithFlag(str);
            socket.Send(buffer);
        }

        public void SendCheckerboard(int flag, int x, int y, int[,] cboard)
        {
            byte[] buffer = SendMessage.MakeArrWithFlag(flag, x, y, cboard);
            // 先发送再处理
            socket.Send(buffer);
            this.dgReceiveMessage(buffer, buffer.Length);
        }

        public void Dispose()
        {
            this.socket.Close();
        }
    }
}
