/******************************/
/*  苏义成                    */
/*  suyicheng1995@gmail.com   */
/*  2016-6-14 00:00  finished */
/******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsForms
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// CPU线程
        /// </summary>
        Thread thread;

        private void btnStart_Click(object sender, EventArgs e)
        {
            thread = new Thread(CPU);
            thread.IsBackground = true;
            thread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (thread != null)
                thread.Abort();
        }

        /// <summary>
        /// 数据缓冲 寄存器
        /// </summary>
        private int DR;
        /// <summary>
        /// 指令 寄存器
        /// </summary>
        private char[] IR;
        /// <summary>
        /// 程序状态字 寄存器
        /// </summary>
        private int PSW;
        /// <summary>
        /// 指令位置 寄存器
        /// </summary>
        private int PC;
        /// <summary>
        /// 时间片
        /// </summary>
        private int Timer;
        /// <summary>
        /// 时间片大小
        /// </summary>
        private const int TIME = 5;
        /// <summary>
        /// 暂停时间
        /// </summary>
        private const int SLEEP = 1000;
        /// <summary>
        /// 当前进程
        /// </summary>
        private PCB pcbNow;
        //249528401
        /// <summary>
        /// CPU
        /// </summary>
        private void CPU()
        {
            if (ReadyQueue.pcbStart == null)
            {
                this.PSW = 4;
                Idle();
            }
            while (true)
            {
                if (this.PSW != 0)
                {
                    #region 时间片到，进程调度 PSW=1
                    if (this.PSW == 1)
                    {
                        this.labCommand.Text = "中断，时间片到";
                        this.pcbNow.DR = DR;
                        this.pcbNow.PC = PC;
                        ReadyQueue.Add(this.pcbNow);
                        this.PSW = 4;
                    }
                    #endregion

                    #region 唤醒阻塞进程 PSW=2 PSW=3
                    else if (this.PSW == 2 || this.PSW == 3)
                    {
                        this.labCommand.Text = "中断，唤醒进程";
                        wake();
                        if (this.PSW != 4)
                            this.PSW -= 2;
                    }
                    #endregion

                    #region 程序执行软中断,撤销进程，进程调度 PSW>=4
                    else if (this.PSW >= 4)
                    {
                        this.pcbNow = null;
                        this.labCommand.Text = "中断，进程调度";
                        if (ReadyQueue.pcbStart == null)
                        {
                            Idle();
                        }
                        this.pcbNow = ReadyQueue.Get();
                        this.PC = this.pcbNow.PC;
                        this.Timer = TIME;
                        this.DR = this.pcbNow.DR;
                        this.pcbNow.State = emState.operation;
                        this.PSW -= 4;
                    }
                    #endregion
                }
                else
                {
                    #region 取PC指令，放入IR寄存器
                    this.IR = new char[4];
                    this.IR[0] = this.pcbNow.Program[this.PC];
                    this.IR[1] = this.pcbNow.Program[this.PC + 1];
                    this.IR[2] = this.pcbNow.Program[this.PC + 2];
                    this.IR[3] = this.pcbNow.Program[this.PC + 3];
                    #endregion

                    #region pc++
                    this.PC += 4;
                    #endregion

                    #region 执行IR指令
                    if (Regex.IsMatch(new string(this.IR), @"x=\d;") == true)
                    {
                        this.DR = Convert.ToInt32(IR[2]) - 48;
                    }
                    else if (Regex.IsMatch(new string(this.IR), @"x\+\+;") == true)
                    {
                        this.DR++;
                    }
                    else if (Regex.IsMatch(new string(this.IR), @"x--;") == true)
                    {
                        this.DR--;
                    }
                    else if (Regex.IsMatch(new string(this.IR), @"![AB]\d;") == true)
                    {
                        this.pcbNow.Event = this.IR[1];
                        this.pcbNow.Timer = Convert.ToInt32(IR[2]) - 48;
                        this.pcbNow.DR = DR;
                        this.pcbNow.PC = PC;
                        BlockQueue.Add(pcbNow);
                        this.PSW = 4;
                    }
                    else if (Regex.IsMatch(new string(this.IR), @"end.") == true)
                    {
                        string path = Path.ChangeExtension(this.pcbNow.path, "out");
                        using (FileStream stream = new FileStream(path, FileMode.Create))
                        {
                            string str = Path.GetFullPath(path) + "\r\n" + "x=" + this.DR.ToString();
                            byte[] buffer = Encoding.UTF8.GetBytes(str);
                            stream.Write(buffer, 0, buffer.Length);
                        }
                        this.labEndResult.Text = DR.ToString();
                        this.PSW = 4;
                    }
                    else if (Regex.IsMatch(new string(this.IR), @"gob;") == true)
                    {
                        this.PC = 0;
                    }
                    #endregion

                    #region 时间片--，阻塞进程的时间--
                    this.Timer--;
                    if (this.Timer == 0 && this.PSW == 0) this.PSW = 1;
                    blockTime();
                    #endregion

                    #region 页面更新
                    this.labNumber.Text = pcbNow.Number.ToString();
                    this.labRunning.Text = pcbNow.Name.ToString();
                    this.labTimer.Text = this.Timer.ToString();
                    this.labCommand.Text = new string(IR);
                    this.labResult.Text = this.DR.ToString();
                    #endregion
                }
                ReadyQueueReset();
                BlockQueueReset();
                //延时；
                Thread.Sleep(SLEEP);
            }
        }

        private void btnCreatProcess_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string path;
            string str;

            for (int j = 0; j < 10; j++)
            {
                #region 自动生成
                str = "x=" + r.Next(0, 10) + ";" + "\r\n";
                int lines = r.Next(8, 15);
                for (int i = 0; i < lines; i++)
                {
                    int line = r.Next(0, 3);
                    switch (line)
                    {
                        case 0:
                            str = str + "x++;\r\n";
                            break;
                        case 1:
                            str = str + "x--;\r\n";
                            break;
                        case 2:
                            str += "!";
                            int rea = r.Next(0, 2);
                            if (rea == 0) str += "A";
                            else str += "B";
                            int tim = r.Next(1, 10);
                            str = str + tim.ToString() + ";\r\n";
                            break;
                        default:
                            break;
                    }
                }
                str = str + "end.";
                #endregion

                #region 写入
                path = @"../data/" + j.ToString() + ".in";
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(str);
                    stream.Write(buffer, 0, buffer.Length);
                }
                #endregion
            }

            MessageBox.Show("重新生成成功。");
        }

        /// <summary>
        /// 进程编号 
        /// 从1开始，闲逛进程为0
        /// </summary>
        private int pcbNumber = 1;

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (thread != null)
            {
                string text = sender.ToString();
                text = text.Substring(text.Length - 1, 1);
                string path = @"../data/" + text + ".in";
                PCB pcb = new PCB(path, pcbNumber++);
                ReadyQueue.Add(pcb);

                //当前进程是闲逛进程时，中断
                if (this.pcbNow.Number == 0)
                {
                    this.PSW = 4;
                }
                ReadyQueueReset();
            }
            else
                MessageBox.Show("请先开机。");
        }

        /// <summary>
        /// 重写就绪队列内容
        /// </summary>
        private void ReadyQueueReset()
        {
            //跨线程
            lock (this)
            {
                lvReday.Items.Clear();
                ListViewItem item = null;
                PCB pcb = ReadyQueue.pcbStart;
                while (pcb != null)
                {
                    item = new ListViewItem();
                    item.Text = pcb.Name;
                    item.SubItems.Add(pcb.Number.ToString());
                    lvReday.Items.Add(item);
                    pcb = pcb.next;
                }
            }
        }

        /// <summary>
        /// 重写阻塞队列内容
        /// </summary>
        private void BlockQueueReset()
        {
            //跨线程
            lock (this)
            {
                lvBlock.Items.Clear();
                ListViewItem item = null;
                PCB pcb = BlockQueue.pcbStart;
                while (pcb != null)
                {
                    item = new ListViewItem();
                    item.Text = pcb.Name;
                    item.SubItems.Add(pcb.Number.ToString());
                    item.SubItems.Add(pcb.Event.ToString());
                    item.SubItems.Add(pcb.Timer.ToString());
                    lvBlock.Items.Add(item);
                    pcb = pcb.next;
                }
            }
        }

        /// <summary>
        /// 写入闲逛进程
        /// </summary>
        private void Idle()
        {
            string path = @"idle.bin";
            PCB pcb = new PCB(path, 0);
            ReadyQueue.Add(pcb);
            ReadyQueueReset();
        }

        /// <summary>
        /// 减少阻塞队列时间片
        /// </summary>
        private void blockTime()
        {
            PCB pcb = BlockQueue.pcbStart;
            while (pcb != null)
            {
                pcb.Timer--;
                if (pcb.Timer == 0)
                {
                    //防止5出现陷入死循环
                    if (this.PSW == 1 || this.PSW == 0 || this.PSW == 4)
                    {
                        this.PSW += 2;
                    }
                }
                pcb = pcb.next;
            }
        }

        /// <summary>
        /// 进程唤醒
        /// </summary>
        private void wake()
        {
            PCB pcb = new PCB(@"idle.bin", 0);
            pcb.next = BlockQueue.pcbStart;
            while (pcb.next != null)
            {
                if (pcb.next.Timer == 0)
                {
                    if (pcb.next == BlockQueue.pcbStart)
                    {
                        BlockQueue.pcbStart = BlockQueue.pcbStart.next;
                        if (BlockQueue.pcbStart == null) BlockQueue.pcbEnd = null;
                    }
                    PCB temp = pcb.next;
                    pcb.next = temp.next;
                    ReadyQueue.Add(temp);
                }
                else
                    pcb = pcb.next;
            }
            if (BlockQueue.pcbEnd != null)
            {
                BlockQueue.pcbEnd = pcb;
            }
            //当前进程是闲逛进程时，中断
            if (this.pcbNow.Number == 0)
            {
                this.PSW = 4;
            }
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            //打开结果
            Form2 f = Form2.GetSingle();
            f.Show();
        }
    }
}
