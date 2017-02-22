using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace chatServer
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
            try
            {
                while (true)
                {
                    byte[] arrMsg = new byte[1024 * 1024];
                    int length = soc.Receive(arrMsg);

                    string strSoc = soc.RemoteEndPoint.ToString();
                    string strMsg = Encoding.UTF8.GetString(arrMsg, 0, length);
                    if (strMsg == "!--LOGIN--!")
                    {
                        login(soc);
                    }
                    else
                    {
                        string strTo = ChatGroup[strSoc];
                        dgSendMsg(strSoc + " send to " + strTo + "\r\nMessage:" + strMsg);
                        Socket sendTo = ClientSocket[strTo];
                        sendTo.Send(Encoding.UTF8.GetBytes(strMsg));
                    }
                }
            }
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
                    socID.Send(Encoding.UTF8.GetBytes("!--OFFLINE--!"));
                    ClientStatus[groupID] = false;
                    Thread.Sleep(500);
                    login(socID);
                }
            }
        }

        void login(Socket soc)
        {
            string strSoc = soc.RemoteEndPoint.ToString();
            while (ClientStatus.Keys.Contains(strSoc) && ClientStatus[strSoc] == false)
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
                    soc.Send(Encoding.UTF8.GetBytes("!--LOGIN SUCCESS--!"));
                    ClientSocket[sendto.Key].Send(Encoding.UTF8.GetBytes("!--LOGIN SUCCESS--!"));
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        public string getCount()
        {
            return ClientSocket.Count().ToString();
        }
    }
}
