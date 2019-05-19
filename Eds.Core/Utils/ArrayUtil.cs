using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.Core.Utils
{
    public class ArrayUtil
    {
        public void PrintArray()
        {
            //规则二维数组
            int[,] cells = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("规则二维数组输出");
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    Console.Write(Convert.ToString(cells[i, j]));
                }
            }
            Console.WriteLine();

            //不规则二维数组
            int[][] cellsTwo = new int[2][];
            cellsTwo[0] = new int[2];
            cellsTwo[0][0] = 1;
            cellsTwo[0][1] = 2;
            cellsTwo[1] = new int[] { 4, 5, 6 };

            Console.WriteLine("不规则二维数组输出");
            for (int i = 0; i < cellsTwo.Length; i++)
            {
                foreach (int item in cellsTwo[i])
                {
                    Console.Write(Convert.ToString(item));
                }
            }

            //注意 cells.Length=9;cellsTwo.Length=2;
        }


        public void FindData(int searchData)
        {
            int evenCount = 0;
            int[,] arrys = { { 1, 2, 3, 4 }, { 5, 5, 7, 8 }, { 9, 10, 11, 12 } };
            //GetLongLength(0)取数组的行数，GetLongLength(1)列数
            for (int i = 0; i < arrys.GetLongLength(0); i++)
            {
                for (int j = 0; j < arrys.GetLongLength(1); j++)
                {
                    if (arrys[i, j] % 2 == 0)
                        evenCount++;
                }
            }
            Console.WriteLine("当前二维数组中偶数个数为：" + evenCount);
        }
    }
}
