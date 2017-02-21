using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    /// <summary>
    /// 阻塞队列类
    /// </summary>
    class BlockQueue
    {
        static public PCB pcbStart { set; get; }
        static public PCB pcbEnd { set; get; }

        static BlockQueue()
        {
            pcbStart = null;
            pcbEnd = null;
        }

        /// <summary>
        /// 增加进阻塞队列
        /// </summary>
        public static void Add(PCB pcb)
        {
            pcb.State = emState.block;
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
    }
}
