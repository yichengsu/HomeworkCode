using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsForms
{
    class PCB
    {
        /// <summary>
        /// 数据缓冲 寄存器
        /// </summary>
        public int DR { set; get; }
        /// <summary>
        /// 进程标识符 只读
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 进程编号 只读
        /// </summary>
        public int Number { get; }
        /// <summary>
        /// 指令位置
        /// </summary>
        public int PC { get; set; }
        /// <summary>
        /// 进程状态
        /// </summary>
        public emState State { get; set; }
        /// <summary>
        /// 阻塞原因
        /// </summary>
        public char Event { get; set; }
        /// <summary>
        /// 时间片
        /// </summary>
        public int Timer { get; set; }
        /// <summary>
        /// 下一进程
        /// </summary>
        public PCB next { get; set; }
        /// <summary>
        /// 程序内容 只读
        /// </summary>
        public string Program { get; }
        /// <summary>
        /// 路径 只读
        /// </summary>
        public string path { get; }

        public PCB(string path,int number)
        {
            this.Name = Path.GetFileName(path);
            this.Number = number;
            this.State = emState.ready;
            using (FileStream stream=new FileStream(path,FileMode.Open))
            {
                this.path = path;
                byte[] buffer = new byte[1024 * 10];
                stream.Read(buffer, 0, buffer.Length);
                this.Program = Encoding.Default.GetString(buffer).Replace("\n", "").Replace("\r", "").Trim();
            }
            this.PC = 0;
            this.DR = 0;
        }
    }
}
