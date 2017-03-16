using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    /// <summary>
    /// 落子后判断输赢
    /// </summary>
    class Referee
    {
        private const int CHESS = 5;
        private static int[,] cboard;
        public static bool Result(int flag, int x, int y, int[,] cboard)
        {
            Referee.cboard = cboard;
            int temp;
            // 竖
            temp = cc(0, -1, flag, x, y, 0) + cc(0, 1, flag, x, y, 0) - 1;
            if (temp == CHESS) { return true; }
            // 横
            temp = cc(-1, 0, flag, x, y, 0) + cc(1, 0, flag, x, y, 0) - 1;
            if (temp == CHESS) { return true; }
            // 右斜
            temp = cc(-1, -1, flag, x, y, 0) + cc(1, 1, flag, x, y, 0) - 1;
            if (temp == CHESS) { return true; }
            // 左斜
            temp = cc(1, -1, flag, x, y, 0) + cc(-1, 1, flag, x, y, 0) - 1;
            if (temp == CHESS) { return true; }

            return false;
        }

        private static int cc(int posx, int posy, int flag, int x, int y, int tot)
        {
            if (cboard[x, y] == flag)
            {
                return cc(posx, posy, flag, x + posx, y + posy, tot + 1);
            }
            else
                return tot;
        }
    }
}
