using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Manager
    {
        public delegate void DGSendMsg(string str);

        DGSendMsg dgSendMsg;

        // Client <ip, socket>
        private Dictionary<string, Socket> ClientSocket;
        // <ip, name>
        private Dictionary<string, string> UserName;

        public Manager(DGSendMsg dgSendMsg)
        {
            this.dgSendMsg = dgSendMsg;
            ClientSocket = new Dictionary<string, Socket>();
            UserName = new Dictionary<string, string>();
        }

        /// <summary>
        /// 增加新的socket
        /// </summary>
        /// <param name="soc"></param>
        public void AddClient(Socket soc)
        {
            string strEndPoint = soc.RemoteEndPoint.ToString();
            ClientSocket[strEndPoint] = soc;

            Thread thread = new Thread(ReciveMsg);
            thread.IsBackground = true;
            thread.Start(soc);
        }

        void ReciveMsg(object socObj)
        {
            Socket soc = socObj as Socket;
            #region send
            try
            {
                while (true)
                {
                    /// 接收消息
                    byte[] arrMsg = new byte[1024 * 1024];
                    int length = soc.Receive(arrMsg);
                    /// 登陆
                    if (arrMsg[0] == (byte)StatusEnum.login)
                    {
                        string str = Encoding.UTF8.GetString(arrMsg, 1, length - 1);
                        string strEndPoint = soc.RemoteEndPoint.ToString();
                        UserName[strEndPoint] = str;
                        string s = str + "(" + strEndPoint + ")" + " is client.";
                        dgSendMsg(s);
                    }
                    /// 普通消息
                    else
                    {
                        Socket s;
                        foreach (var item in ClientSocket)
                        {
                            s = item.Value;
                            s.Send(arrMsg, length, SocketFlags.None);
                        }
                    }
                }
            }
            #endregion
            #region offline
            catch
            {
                string clientId = soc.RemoteEndPoint.ToString();
                string name = UserName[clientId];
                dgSendMsg(name + "(" + clientId + ")" + " is offline.");

                if (ClientSocket.Keys.Contains(clientId))
                {
                    ClientSocket[clientId].Shutdown(SocketShutdown.Both);
                    ClientSocket[clientId].Close();
                    ClientSocket.Remove(clientId);
                }
                if (UserName.Keys.Contains(clientId))
                {
                    UserName.Remove(clientId);
                }
            }
            #endregion
        }

        public string getCount()
        {
            return ClientSocket.Count().ToString();
        }

        /// <summary>
        /// 检测socket是否还在连接状态
        /// </summary>
        /// <param name="_socket"></param>
        /// <returns></returns>
        private bool SocketConnected(Socket _socket)
        {
            try
            {
                return !_socket.Poll(1, SelectMode.SelectRead) && (_socket.Available == 0);
            }
            catch (SocketException)
            {
                return false;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }

        /// <summary>
        /// 向所有的客户端同步用户列表
        /// </summary>
        private static object update = new object();
        public void updateUser()
        {
            lock (update)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in UserName)
                {
                    sb.Append(item.Value.PadLeft(50));
                }

                byte[] arr = null;
                arr = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
                byte[] newArr = new byte[arr.Length + 1];
                newArr[0] = (byte)StatusEnum.users;
                arr.CopyTo(newArr, 1);

                foreach (var item in ClientSocket)
                {
                    Socket s = item.Value;
                    s.Send(newArr);
                }
            }
        }
    }
}
