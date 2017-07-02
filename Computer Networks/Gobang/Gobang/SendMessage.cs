using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    class SendMessage
    {
        #region old
        //StatusEnum status;
        //string strMsg;
        //public SendMessage(int a)
        //{
        //    this.status = StatusEnum.login;
        //    this.strMsg = "";
        //}

        //public SendMessage(string str)
        //{
        //    this.status = StatusEnum.message;
        //    this.strMsg = str;
        //}

        //public SendMessage(int flag, int x, int y)
        //{
        //    if (flag == 1)
        //    {
        //        this.status = StatusEnum.whitechess;
        //    }
        //    else if (flag == 2)
        //    {
        //        this.status = StatusEnum.blackchess;
        //    }
        //    this.strMsg = x.ToString() + "," + y.ToString();
        //} 
        #endregion

        /// <summary>
        /// StatusEnum.login
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static byte[] MakeArrWithFlag(int a)
        {
            StatusEnum status = StatusEnum.login;
            string strMsg = "";

            byte[] arrMsg = null;
            arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);

            byte[] newArr = new byte[arrMsg.Length + 1];
            //将当前对象的类型转成标识数值存入新数组的第一个元素
            newArr[0] = (byte)status;
            //将 数组的 数据 复制到 新数组中（从新数组第二个位置开始存放）
            arrMsg.CopyTo(newArr, 1);
            //返回 带标识位的 新消息数组
            return newArr;
        }

        /// <summary>
        /// StatusEnum.message
        /// </summary>
        /// <param name="str">message</param>
        /// <returns></returns>
        public static byte[] MakeArrWithFlag(string str)
        {
            StatusEnum status = StatusEnum.message;
            string strMsg = str;

            byte[] arrMsg = null;
            arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);

            byte[] newArr = new byte[arrMsg.Length + 1];
            //将当前对象的类型转成标识数值存入新数组的第一个元素
            newArr[0] = (byte)status;
            //将 数组的 数据 复制到 新数组中（从新数组第二个位置开始存放）
            arrMsg.CopyTo(newArr, 1);
            //返回 带标识位的 新消息数组
            return newArr;
        }

        /// <summary>
        /// StatusEnum.whitechess or StatusEnum.blackchess
        /// </summary>
        /// <param name="flag">1=白,2=黑</param>
        /// <param name="x">point x</param>
        /// <param name="y">point y</param>
        /// <returns></returns>
        public static byte[] MakeArrWithFlag(int flag, int x, int y, int[,] cboard)
        {
            cboard[x, y] = flag;
            bool result = Referee.Result(flag, x, y, cboard);

            StatusEnum status;

            if (flag == 1)
            {
                if (result == true)
                    status = StatusEnum.whitewin;
                else
                    status = StatusEnum.whitechess;
            }
            else
            {
                if (result == true)
                    status = StatusEnum.blackwin;
                else
                    status = StatusEnum.blackchess;
            }
            

            //转换成string
            StringBuilder sb = new StringBuilder();
            foreach (int item in cboard)
            {
                sb.Append(item);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);

            // copy到byte数组
            byte[] arrMsg = null;
            arrMsg = System.Text.Encoding.UTF8.GetBytes(sb.ToString());

            byte[] newArr = new byte[arrMsg.Length + 1];
            //将当前对象的类型转成标识数值存入新数组的第一个元素
            newArr[0] = (byte)status;
            //将 数组的 数据 复制到 新数组中（从新数组第二个位置开始存放）
            arrMsg.CopyTo(newArr, 1);
            //返回 带标识位的 新消息数组
            return newArr;
        }
    }
}
