using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    /// <summary>
    /// 就绪队列类
    /// </summary>
    class ReadyQueue
    {
        static public PCB pcbStart { set; get; }
        static public PCB pcbEnd { set; get; }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static ReadyQueue()
        {
            pcbStart = null;
            pcbEnd = null;
        }

        /// <summary>
        /// 增加进就绪队列
        /// </summary>
        public static void Add(PCB pcb)
        {
            pcb.State = emState.ready;
            if (pcbEnd == null && pcbStart == null)
            {
                pcbStart = pcb;
                pcbEnd = pcb;
            }
            else
            {
                pcbEnd.next = pcb;
                pcbEnd = pcb;
            }
            pcbEnd.next = null;
        }
        /// <summary>
        /// 从就绪队列移除
        /// </summary>
        /// <returns></returns>
        public static PCB Get()
        {
            if (pcbEnd == null && pcbStart == null)
            {
                return null;
            }
            else
            {
                PCB pcbTemp = pcbStart;
                pcbStart = pcbStart.next;
                if (pcbStart == null) pcbEnd = null;
                return pcbTemp;
            }
        }
    }
}
