using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScanner
{
    public partial class Form1 : Form
    {
        private IPAddress ipStart;  //开始IP
        private IPAddress ipEnd;    //结束IP
        private int portStart;      //开始端口号
        private int portEnd;        //结束端口号
        private int overTime = 15;  //延迟
        private Thread scanthread;  //扫描线程
        private bool IsScan;        //是否扫描
        private int scannedCount = 0;//已扫描的线程数
        private long scanNumber;    //需要扫描的线程数
        private int runningThreadCount = 0;//正在运行的扫描线程
        private int maxThread = 100; //最大扫描线程

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.Visible == true)
            {
                textBox2.Visible = false;
                label2.Text = "";
            }
            else
            {
                textBox2.Visible = true;
                textBox1.Text = textBox2.Text = "";
                label2.Text = "-";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox4.Visible == true)
            {
                textBox4.Visible = false;
                label3.Text = "";
            }
            else
            {
                textBox4.Visible = true;
                textBox3.Text = textBox4.Text = "";
                label3.Text = "-";
            }
        }

        /// <summary>
        /// 结束扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            this.IsScan = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddListbox("IP", "Port", "State");
            btnStop.Enabled = false;
        }

        /// <summary>
        /// 开始扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            txtRes.Clear();

            listBox1.Items.Clear();
            AddListbox("IP", "Port", "State");

            if (checkBox1.Checked)
            {
                textBox2.Text = textBox1.Text;
            }
            if (checkBox2.Checked)
            {
                textBox4.Text = textBox3.Text;
            }

            AddTxtRes("Start scan...");

            //检查IP地址和端口号是否有效
            if (IPAddress.TryParse(textBox1.Text, out ipStart) && IPAddress.TryParse(textBox2.Text, out ipEnd))
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("请输入端口号！");
                    return;
                }
                else if (portEnd < portStart || portEnd > 65535 || portStart < 0)
                {
                    MessageBox.Show("请填写正确端口范围");
                    return;
                }
                else
                {
                    //    this.ipStart = IPAddress.Parse(this.textBox1.Text);
                    //    this.ipEnd = IPAddress.Parse(this.textBox2.Text);
                    this.portStart = Int32.Parse(textBox3.Text);
                    this.portEnd = Int32.Parse(textBox4.Text);
                }
            }
            else
            {
                MessageBox.Show("请输入正确格式的IP。");
                return;
            }

            //开始扫描
            this.IsScan = true;
            this.scanthread = new Thread(new ThreadStart(IPing));
            scanthread.IsBackground = true;
            scanthread.Start();

            //string ip1 = "10.0.3.193";
            //long ipInt = IpToInt(ip1);
            //Console.WriteLine(ipInt);
            //Console.WriteLine(IntToIp(ipInt));

            ////使用long ulong int 会溢出，使用uint就没问题
            //uint netInt = (uint)IPAddress.HostToNetworkOrder((Int32)ipInt);
            //IPAddress ipaddr = new IPAddress((long)netInt);
            //IPAddress ipaddr1 = IPAddress.Parse(ip1);
            //Console.WriteLine(ipaddr.ToString());
            //Console.WriteLine(ipaddr1.ToString());

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        public void IPing()
        {
            //把ip地址格式转换成大整数
            long longStart = IpToInt(ipStart.ToString());
            long longEnd = IpToInt(ipEnd.ToString());

            //计算要扫描的端口号数量
            long ipRange = longEnd - longStart + 1;
            long portRange = portEnd - portStart + 1;
            this.scanNumber = ipRange * portRange;

            for (long longIp = longStart; longIp <= longEnd && IsScan == true; longIp++)
            {
                //通过ping来确定目标主机是否可达
                //---------------------ping-------------------//
                string strIP = IntToIp(longIp);
                IPAddress ip = IPAddress.Parse(strIP);

                Ping ping = new Ping();
                PingReply reply = ping.Send(ip, overTime);

                if (reply.Status == IPStatus.Success)
                {
                    string s = ip.ToString() + " Ping时间 " + reply.RoundtripTime + "ms";
                    AddTxtRes(s);
                    //IPHostEntry host = Dns.GetHostEntry(ip);
                    //txtRes.AppendText("主机名为 " + host.HostName + "\n");
                }
                else
                {
                    //主机号不可达，从要扫描的端口号数量中减去该部分
                    this.scanNumber -= portRange;
                    //this.scannedCount += (int)portRange;
                    string s = ip.ToString() + " 不可达";
                    AddTxtRes(s);
                    continue;
                }
                //---------------------end-------------------//


                //开始扫描
                //---------------------Scan------------------//
                for (int port = portStart; port <= portEnd; port++)
                {
                    ipport i = new ipport();
                    i.ip = ip;
                    i.port = port;
                    Thread thread = new Thread(new ParameterizedThreadStart(Scan));
                    thread.Name = port.ToString();
                    thread.IsBackground = true;
                    thread.Start(i);

                    runningThreadCount++;

                    Thread.Sleep(10);
                    //循环，直到某个线程工作完毕才启动另一新线程，也可以叫做推拉窗技术
                    while (runningThreadCount >= maxThread) ;
                }

                //------------------------end----------------//
            }
            //等到所有的线程结束
            while (scannedCount < scanNumber) ;

            string result = string.Format("Scan has been completed , total {0} ports scanned, opened ports :{1}.", scanNumber, listBox1.Items.Count - 1);

            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            MessageBox.Show(result);
            this.AddTxtRes(result);
        }

        //把ip转换成大整数
        private long IpToInt(string ip)
        {
            char[] separator = new char[] { '.' };
            string[] items = ip.Split(separator);
            return long.Parse(items[0]) << 24
                    | long.Parse(items[1]) << 16
                    | long.Parse(items[2]) << 8
                    | long.Parse(items[3]);
        }

        //把合法的大整数转换成ip地址
        private string IntToIp(long ipInt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((ipInt >> 24) & 0xFF).Append(".");
            sb.Append((ipInt >> 16) & 0xFF).Append(".");
            sb.Append((ipInt >> 8) & 0xFF).Append(".");
            sb.Append(ipInt & 0xFF);
            return sb.ToString();
        }

        static object addtxt = new object();
        private void AddTxtRes(string s)
        {
            lock (addtxt)
            {
                txtRes.AppendText(s + "\n");
            }
        }

        static object addlistbox = new object();
        private void AddListbox(string ip, string port, string state)
        {
            lock (addlistbox)
            {
                listBox1.Items.Add(ip.PadRight(25) + port.PadRight(20) + state.PadRight(10));
            }
        }

        //ip和port结构体
        struct ipport
        {
            public IPAddress ip;
            public int port;
        }

        //扫描线程
        private void Scan(object rc)
        {
            IPAddress m_host = ((ipport)rc).ip;
            int m_port = ((ipport)rc).port;

            //我们直接使用比较高级的TcpClient类
            TcpClient tc = new TcpClient();
            //设置超时时间
            tc.SendTimeout = tc.ReceiveTimeout = 2000;
            try
            {
                //尝试连接
                tc.Connect(m_host, m_port);
                if (tc.Connected)
                {
                    //如果连接上，证明此商品为开放状态           
                    //Console.WriteLine("Port {0} is Open", m_port.ToString().PadRight(6));
                    //Program.openedPorts.Add(m_port);
                    string s = m_host.ToString() + ":" + m_port.ToString() + " is Open.";
                    AddTxtRes(s);
                    AddListbox(m_host.ToString(), m_port.ToString(), "Open");

                }
            }
            catch (System.Net.Sockets.SocketException e)
            {
                //容错处理
                //Console.WriteLine("Port {0} is closed", m_port.ToString().PadRight(6));
                //Console.WriteLine(e.Message);
                string s = m_host.ToString() + ":" + m_port.ToString() + " is Closed.";
                AddTxtRes(s);
            }
            finally
            {
                tc.Close();
                tc = null;
                scannedCount++;
                runningThreadCount--;
            }
        }
    }
}
