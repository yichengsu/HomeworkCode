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

        // Client chat status <ip, isChat>
        private Dictionary<string, bool> ClientStatus;

        // Client group <ip1, ip2>
        private Dictionary<string, string> ChatGroup;

        public Manager(DGSendMsg dgSendMsg)
        {
            this.dgSendMsg = dgSendMsg;
            ClientSocket = new Dictionary<string, Socket>();
            ClientStatus = new Dictionary<string, bool>();
            ChatGroup = new Dictionary<string, string>();
        }

        /// <summary>
        /// 增加新的socket
        /// </summary>
        /// <param name="soc"></param>
        public void AddClient(Socket soc)
        {
            string strEndPoint = soc.RemoteEndPoint.ToString();

            //ClientSocket.Add(strEndPoint, soc);
            //ClientStatus.Add(strEndPoint, false);
            ClientSocket[strEndPoint] = soc;
            ClientStatus[strEndPoint] = false;

            Thread thread = new Thread(ReciveMsg);
            thread.IsBackground = true;
            thread.Start(soc);

            dgSendMsg(strEndPoint + " is client.");
        }

        void ReciveMsg(object socObj)
        {
            Socket soc = socObj as Socket;
            #region send
            try
            {
                while (true)
                {
                    byte[] arrMsg = new byte[1024 * 1024];
                    int length = soc.Receive(arrMsg);

                    if (arrMsg[0] == (byte)StatusEnum.login)
                    {
                        string strMsg = "";
                        byte[] arr = null;
                        arr = System.Text.Encoding.UTF8.GetBytes(strMsg);

                        byte[] newArr = new byte[arr.Length + 1];
                        newArr[0] = (byte)StatusEnum.wait;
                        arr.CopyTo(newArr, 1);
                        soc.Send(newArr);

                        login(soc);
                    }
                    else
                    {
                        string strSoc = soc.RemoteEndPoint.ToString();
                        string strTo = ChatGroup[strSoc];
                        //dgSendMsg(strSoc + " send to " + strTo + "\r\nMessage:" + strMsg);
                        Socket sendTo = ClientSocket[strTo];
                        sendTo.Send(arrMsg, length, SocketFlags.None);
                    }
                }
            }
            #endregion
            #region offline
            catch
            {
                string clientId = soc.RemoteEndPoint.ToString();
                dgSendMsg(clientId + " is offline.");

                string groupID = null;
                Socket socID = null;
                if (ClientSocket.Keys.Contains(clientId))
                {
                    ClientSocket[clientId].Close();
                    ClientSocket.Remove(clientId);
                }
                if (ClientStatus.Keys.Contains(clientId))
                {
                    ClientStatus.Remove(clientId);
                }
                if (ChatGroup.Keys.Contains(clientId))
                {
                    groupID = ChatGroup[clientId];
                    ChatGroup.Remove(clientId);
                }

                if (groupID != null && ClientSocket.Keys.Contains(groupID))
                {
                    socID = ClientSocket[groupID];
                    dgSendMsg(groupID + " is reclienting...");

                    string strMsg = "";
                    byte[] arrMsg = null;
                    arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);

                    byte[] newArr = new byte[arrMsg.Length + 1];
                    newArr[0] = (byte)StatusEnum.wait;
                    arrMsg.CopyTo(newArr, 1);
                    socID.Send(newArr);

                    ClientStatus[groupID] = false;
                    Thread.Sleep(500);
                    login(socID);
                }
            }
            #endregion
        }

        private static object log = new object();
        void login(Socket soc)
        {
            string strSoc = soc.RemoteEndPoint.ToString();
            while (ClientStatus.Keys.Contains(strSoc) && ClientStatus[strSoc] == false)
            {
                if (!SocketConnected(ClientSocket[strSoc]))
                {
                    throw new Exception("已断开");
                }
                lock (log)
                {
                    var sendto = ClientStatus.Where(w => (w.Value == false && w.Key != strSoc)).FirstOrDefault();
                    if (sendto.Key != null)
                    {
                        ClientStatus[strSoc] = true;
                        ClientStatus[sendto.Key] = true;
                        //ChatGroup.Add(strSoc, sendto.Key);
                        //ChatGroup.Add(sendto.Key, strSoc);
                        ChatGroup[sendto.Key] = strSoc;
                        ChatGroup[strSoc] = sendto.Key;
                        dgSendMsg(strSoc + " is connected with " + sendto.Key + ".");

                        string strMsg = "";
                        byte[] arrMsg = null;
                        arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);

                        byte[] newArr = new byte[arrMsg.Length + 1];
                        newArr[0] = (byte)StatusEnum.getwhite;
                        arrMsg.CopyTo(newArr, 1);
                        soc.Send(newArr);

                        newArr[0] = (byte)StatusEnum.getblack;
                        ClientSocket[sendto.Key].Send(newArr);

                        break;
                    }
                }
                Thread.Sleep(1000);
            }
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
    }
}
