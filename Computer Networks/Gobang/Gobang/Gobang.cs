using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gobang
{
    public partial class Gobang : Form
    {
        public Gobang()
        {
            InitializeComponent();

            this.splitContainer1.Panel1.BackColor = Color.FromArgb(249, 241, 91);
            ResetDrawPanel();
        }

        GobangManeger man = null;

        private void Gobang_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            this.labBlackorWhite.Text = "";
            this.labNow.Text = "";

            this.btnSend.Enabled = false;
            this.DrawPanel.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            man = new GobangManeger(ReceiveMessage);
            this.btnStart.Enabled = false;
        }

        #region TODO
        void AddMsg(string str)
        {
            if (txtMsgAll.Text != "")
            {
                txtMsgAll.AppendText("\r\n\r\n");
            }
            txtMsgAll.AppendText(DateTime.Now.ToString() + "\r\n");
            txtMsgAll.AppendText(str);
        }

        #endregion

        private Panel DrawPanel;

        private static int start = 20;
        private static int width = 40;
        private static int num = 15;
        private static int end = start + width * num;
        private static int piece = 30;

        private int[,] cboard = new int[num + 1, num + 1];

        ChessEnum chess = ChessEnum.none;

        /// <summary>
        /// DrawPanel层点击事件，点击后判断是否有效，有效则发送到server同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (chess == ChessEnum.none)
            {
                return;
            }
            else
            {
                Graphics g = this.DrawPanel.CreateGraphics();

                //find position
                int relaX = (e.X - start) % width;
                int relaY = (e.Y - start) % width;

                int absoPoiX = (relaX > width / 2) ? (e.X - start) / width + 1 : (e.X - start) / width;
                int absoPoiY = (relaY > width / 2) ? (e.Y - start) / width + 1 : (e.Y - start) / width;

                if (cboard[absoPoiX, absoPoiY] != 0)
                    return;

                DrawPanel.MouseClick -= new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseClick);

                if (chess == ChessEnum.black)
                {
                    man.SendCheckerboard(2, absoPoiX, absoPoiY, cboard);
                    //cboard[absoPoiX, absoPoiY] = 2;
                }
                else if (chess == ChessEnum.white)
                {
                    man.SendCheckerboard(1, absoPoiX, absoPoiY, cboard);
                    //cboard[absoPoiX, absoPoiY] = 1;
                }
            }
        }

        private static object obj = new object();
        /// <summary>
        /// 在DrawPanel层画棋子，1为白子，2为黑子
        /// </summary>
        /// <param name="cboard">棋盘数组</param>
        /// <param name="length">棋盘大小</param>
        private void DrawCheckerboard(byte[] buffer, int length)
        {
            lock (obj)
            {
                //解析接受的棋盘byte[]
                string str = Encoding.UTF8.GetString(buffer, 1, length - 1);
                string[] s1 = str.Split(' ');
                int lineNums = Convert.ToInt32(Math.Sqrt(s1.Length));
                int[,] cboard = new int[lineNums, lineNums];
                for (int i = 0; i < lineNums; i++)
                {
                    for (int j = 0; j < lineNums; j++)
                    {
                        cboard[i, j] = Convert.ToInt32(s1[i * lineNums + j]);
                    }
                }

                this.cboard = cboard;
                DrawPanel.Dispose();
                ResetDrawPanel();

                Graphics g = DrawPanel.CreateGraphics();
                int absoX;
                int absoY;
                for (int i = 0; i < lineNums; i++)
                {
                    for (int j = 0; j < lineNums; j++)
                    {
                        if (cboard[i, j] == 1)
                        {
                            absoX = start + i * width;
                            absoY = start + j * width;
                            g.FillEllipse(Brushes.White, absoX - piece / 2, absoY - piece / 2, piece, piece);
                        }
                        else if (cboard[i, j] == 2)
                        {
                            absoX = start + i * width;
                            absoY = start + j * width;
                            g.FillEllipse(Brushes.Black, absoX - piece / 2, absoY - piece / 2, piece, piece);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checkerboard 画棋盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Checkerboard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //border
            Pen p = new Pen(Color.Black, 5);
            g.DrawRectangle(p, 10, 10, 620, 620);

            p = new Pen(Color.Black, 2);

            for (int i = 0; i <= num; i++)
            {
                g.DrawLine(p, start, start + i * width, end, start + i * width);
                g.DrawLine(p, start + i * width, start, start + i * width, end);
            }
        }

        /// <summary>
        /// 重绘DrawPanel层
        /// </summary>
        private void ResetDrawPanel()
        {
            try
            {
                DrawPanel = new Panel();
                DrawPanel.BackColor = Color.Transparent;
                DrawPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseClick);
                DrawPanel.Dock = DockStyle.Fill;

                if (this.Checkerboard.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        this.Checkerboard.Controls.Add(DrawPanel);
                    }));
                }
                else
                    this.Checkerboard.Controls.Add(DrawPanel);
            }
            catch (Exception e)
            {
                MessageBox.Show("ResetDrawPanel throw : " + e.Message);
            }
        }

        private static object Rcvmsg = new object();
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="buffer">接收到的buffer数组</param>
        /// <param name="length">接收到的长度</param>
        private void ReceiveMessage(byte[] buffer, int length)
        {
            //Console.WriteLine("ReceiveMessage 0 :" + buffer[0].ToString());
            lock (Rcvmsg)
            {
                //string str = Encoding.UTF8.GetString(buffer, 0, length);
                //Console.WriteLine("ReceiveMessage 1 :" + str);
                #region 寻找玩家
                if (buffer[0] == (byte)StatusEnum.wait)
                {

                    this.labNow.Text = "正在寻找玩家。";
                    this.labBlackorWhite.Text = "";
                    DrawPanel.Dispose();
                    try
                    {
                        //TODO : 
                        ResetDrawPanel();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("ReceiveMessage throw : " + e.Message);
                    }

                    this.labBlackorWhite.Text = "";

                    this.btnSend.Enabled = false;
                    this.DrawPanel.Enabled = false;

                }
                #endregion
                #region 执白子
                else if (buffer[0] == (byte)StatusEnum.getwhite)
                {
                    this.chess = ChessEnum.white;
                    this.labBlackorWhite.Text = "执：白子";
                    this.labNow.Text = "白子走。";
                    this.btnSend.Enabled = true;
                    this.DrawPanel.Enabled = true;
                }
                #endregion
                #region 执黑子
                else if (buffer[0] == (byte)StatusEnum.getblack)
                {
                    this.chess = ChessEnum.black;
                    this.labBlackorWhite.Text = "执：黑子";
                    this.labNow.Text = "白子走。";
                    this.btnSend.Enabled = true;
                }
                #endregion
                #region 当前得到白子，该黑子走
                else if (buffer[0] == (byte)StatusEnum.whitechess)
                {
                    DrawCheckerboard(buffer, length);
                    if (chess == ChessEnum.white)
                    {
                        DrawPanel.MouseClick -= new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseClick);
                        //this.DrawPanel.Enabled = false;
                    }
                    else
                    {
                        //DrawPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseClick);
                        //this.DrawPanel.Enabled = true;
                    }
                    this.labNow.Text = "黑子走。";
                }
                #endregion
                #region 当前得到黑子，该白子走
                else if (buffer[0] == (byte)StatusEnum.blackchess)
                {
                    DrawCheckerboard(buffer, length);
                    if (chess == ChessEnum.white)
                    {
                        //DrawPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseClick);
                        //this.DrawPanel.Enabled = true;
                    }
                    else
                    {
                        DrawPanel.MouseClick -= new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseClick);
                        //this.DrawPanel.Enabled = false;
                    }
                    this.labNow.Text = "白子走。";
                }
                #endregion
                #region 白子胜
                else if (buffer[0] == (byte)StatusEnum.whitewin)
                {
                    DrawCheckerboard(buffer, length);
                    MessageBox.Show("白子胜");
                    Application.Exit();
                }
                #endregion
                #region 黑子胜
                else if (buffer[0] == (byte)StatusEnum.blackwin)
                {
                    DrawCheckerboard(buffer, length);
                    MessageBox.Show("黑子胜");
                    Application.Exit();
                }
                #endregion
                #region 接收普通消息
                else if (buffer[0] == (byte)StatusEnum.message)
                {
                    string ReceiveMsg = Encoding.UTF8.GetString(buffer, 1, length - 1);
                    AddMsg(ReceiveMsg);
                }
                #endregion
                #region 报错了
                else
                {
                    MessageBox.Show("接收文件解析失败，\r\n服务器断开,请重新连接");
                }

                #endregion
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.txtMsg.Text == "")
            {
                return;
            }
            AddMsg(this.txtMsg.Text);
            man.SendMsg(this.txtMsg.Text);
            this.txtMsg.Text = "";
        }

        private void Gobang_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (man != null)
                man.Dispose();
        }
    }
}
