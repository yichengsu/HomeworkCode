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

namespace Server
{
    public partial class Server : Form
    {
        Socket socket = null;
        Thread thread = null;

        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            tbLog.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ip = IPAddress.Parse("0.0.0.0");
                IPEndPoint point = new IPEndPoint(ip, int.Parse("8990"));

                socket.Bind(point);
                socket.Listen(5);

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

        #region AddMsg to Log
        private static object addmsg = new object();
        void AddMsg(string str)
        {
            lock (addmsg)
            {
                tbLog.AppendText("[TIME] " + DateTime.Now.ToString() + "\r\n");
                tbLog.AppendText(str + "\r\n\r\n");
            }
        }
        #endregion

        private void watching()
        {
            try
            {
                while (true)
                {
                    Socket soc = socket.Accept();

                    Thread thread = new Thread(Dealwith);
                    thread.IsBackground = true;
                    thread.Start(soc);
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

        private void Dealwith(object socObj)
        {
            Socket soc = socObj as Socket;
            try
            {
                byte[] arrMsg = new byte[1024];
                int length = soc.Receive(arrMsg);
                string strSoc = soc.RemoteEndPoint.ToString();

                #region 获取文件信息
                if (arrMsg[0] == (byte)StatusEnum.getdetail)
                {
                    AddMsg(strSoc + " is geting details.");

                    string path = @"./doc/";

                    var files = Directory.GetFiles(path);

                    StringBuilder sb = new StringBuilder();
                    foreach (var file in files)
                    {
                        FileInfo fi = new FileInfo(file);

                        sb.Append(fi.Name);
                        sb.Append("|");
                    }
                    sb.Remove(sb.Length - 1, 1);

                    byte[] arr = null;
                    arr = System.Text.Encoding.UTF8.GetBytes(sb.ToString());

                    byte[] newArr = new byte[arr.Length + 1];
                    newArr[0] = (byte)StatusEnum.detail;
                    arr.CopyTo(newArr, 1);
                    soc.Send(newArr);

                    soc.Shutdown(SocketShutdown.Both);
                    soc.Close();
                } 
                #endregion
                #region 下载文件
                else if (arrMsg[0] == (byte)StatusEnum.getfile)
                {
                    string strFile = Encoding.UTF8.GetString(arrMsg, 1, length - 1);

                    AddMsg(strSoc + " is download \"" + strFile + "\" .");

                    string path1 = @"./doc/";
                    string path = Path.Combine(path1, strFile);
                    FileStream fs = File.Open(path, FileMode.Open);

                    //文件内容
                    byte[] bdata = new byte[fs.Length];
                    fs.Read(bdata, 0, bdata.Length);
                    fs.Close();

                    //172位签名
                    int RSALength = 172;
                    myRSA my = new myRSA();
                    string privatekey = my.ReadPrivateKey("./RSA/my.rsa");
                    myMD5 m5 = new myMD5(1, path);
                    string Signature = myRSA.HashAndSignString(m5.getMD5(), privatekey);
                    byte[] arrSignature = Encoding.UTF8.GetBytes(Signature);

                    //文件长度, 固定为20字节，前面会自动补零
                    byte[] fileLengthArray = Encoding.UTF8.GetBytes(bdata.Length.ToString("D20"));


                    byte[] arrFile = new byte[fileLengthArray.Length + bdata.Length + RSALength];
                    arrSignature.CopyTo(arrFile, 0);
                    fileLengthArray.CopyTo(arrFile, RSALength);
                    bdata.CopyTo(arrFile, fileLengthArray.Length + RSALength);

                    //发文件长度+文件内容
                    soc.Send(arrFile);

                    //禁用 Socket  
                    soc.Shutdown(SocketShutdown.Both);
                    //关闭 Socket  
                    soc.Close();
                }
                #endregion
                #region 获取RSA公钥
                else if (arrMsg[0] == (byte)StatusEnum.getRSAPub)
                {
                    AddMsg(strSoc + " is geting RSAPub.");

                    myRSA my = new myRSA();
                    string publickey = my.ReadPublicKey("./RSA/my.rsa.pub");

                    byte[] arr = null;
                    arr = System.Text.Encoding.UTF8.GetBytes(publickey);

                    byte[] newArr = new byte[arr.Length + 1];
                    newArr[0] = (byte)StatusEnum.RSAPub;
                    arr.CopyTo(newArr, 1);
                    soc.Send(newArr);

                    //禁用 Socket  
                    soc.Shutdown(SocketShutdown.Both);
                    //关闭 Socket  
                    soc.Close();
                }
                #endregion
                else
                {

                }
            }
            catch (Exception ex)
            {
                AddMsg("[!!!!] Exception(Dealwith)：" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myRSA myrsa = new myRSA();
            myrsa.RSAKey(@"./RSA/my.rsa", @"./RSA/my.rsa.pub");
        }
    }
}
