using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class BigODemo
    {
        public static void Show()
        {
            Console.WriteLine("This is 大O");

        }
        //单位时间 --标准--一行代码---就是执行的代码行数

        /// <summary>
        /// 分析执行时间：
        /// 2n+2 
        /// O(n)
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static long Method1(int iNumber)
        {
            long lResult = 0;
            for (int i = 0; i < iNumber; i++)
            {
                lResult += i;
            }
            return lResult;
        }
        /// <summary>
        /// 分析执行时间：
        /// 2n^2+2n+3
        /// 
        /// O(n^2)
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static long Method2(int iNumber)
        {
            long lResult = 0;
            for (int i = 0; i < iNumber; i++)
            {
                for (int j = 0; j < iNumber; j++)
                {
                    lResult += i + j;
                }
            }
            return lResult;
        }
        /// <summary>
        /// 分析执行时间：
        /// log2n+1
        /// O(logn)
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static int Method3(int iNumber)
        {
            int iResult = 1;
            while (iResult <= iNumber)
            {
                iResult = iResult * 2;
            }
            return iResult;
            //iResult: 1   2   4  8  16  32  
            //2^x=n     x = log2N
        }
        /// <summary>
        /// O(logn)
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static int Method3_1(int iNumber)
        {
            int iResult = 1;
            while (iResult <= iNumber)
            {
                iResult = iResult * 3;
            }
            return iResult;
            //iResult: 1   2   4  8  16  32  
            //2^x=n     x = log2N
        }


        /// <summary>
        /// 分析执行时间：
        /// O(nlogn)
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static long Method4(int iNumber)
        {
            long lResult = 0;
            int iResult = 1;
            for (int i = 0; i < iNumber; i++)
            {
                while (iResult <= iNumber)
                {
                    iResult = iResult * 2;
                }
                lResult += iResult;
                iResult = 1;
            }
            return lResult;
        }

        /// <summary>
        /// 分析执行时间：
        /// O(1)
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static long Method5(int iNumber)
        {
            long lResult = 0;
            return lResult + iNumber * iNumber + iNumber;
        }

        /// <summary>
        /// 分析执行时间：
        /// O(2^n)           
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static long Method6(int iNumber)
        {
            long lResult = 1;
            for (int i = 1; i <= iNumber; i++)//O(n) lResult=2^n
            {
                lResult *= 2;
            }

            long lResultTarget = 0;
            for (int i = 0; i < lResult; i++)
            {
                lResultTarget = lResultTarget + i;//2^n    O(2^n)
            }

            return lResult;
        }

        /// <summary>
        /// 分析执行时间：O(n!)     
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static long Method7(int iNumber)
        {
            long lResult = 1;
            //for (int i = 1; i <= iNumber; i++)
            //{
            //    lResult *= 2;
            //}
            for (int i = 1; i <= iNumber; i++)//1*2*3*4....*N  阶乘  n!    复杂度O(n)
            {
                lResult *= i;
            }

            long lResultTarget = 0;
            for (int i = 0; i < lResult; i++)
            {
                lResultTarget = lResultTarget + i;//1*2*3*4....*N  阶乘  n!  O(n!)
            }

            return lResult;
        }

        /// <summary>
        /// 分析执行时间：
        /// </summary>
        /// <param name="iNumber"></param>
        /// <param name="mNumber"></param>
        /// <returns></returns>
        private static long Method8(int iNumber, int mNumber)
        {
            long lResulti = 0;
            for (int i = 0; i < iNumber; i++)
            {
                lResulti += i;
            }

            long lResultm = 0;
            for (int j = 0; j < iNumber; j++)
            {
                lResultm += +j;
            }
            return lResulti + lResultm;
        }

        /// <summary>
        /// 分析执行时间：
        /// 
        /// </summary>
        /// <param name="iNumber"></param>
        /// <param name="mNumber"></param>
        /// <returns></returns>
        private static long Method9(int iNumber, int mNumber)
        {
            long lResult = 0;
            for (int i = 1; i <= iNumber; i++)
            {
                for (int m = 1; m <= mNumber; m++)
                {
                    lResult += i + m;
                }
            }
            return lResult;
        }


        /// <summary>
        /// 分析执行空间：
        /// O(n)
        /// </summary>
        /// <param name="iNumber"></param>
        /// <param name="mNumber"></param>
        /// <returns></returns>
        private static int[] Method10(int iNumber)
        {
            int[] array = new int[iNumber];
            for (int i = 0; i < iNumber; i++)
            {
                array[i] = 1;
            }
            return array;
        }

        /// <summary>
        /// 分析执行空间：O(n^2)
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static int[][] Method11(int iNumber)
        {
            int[][] arrayMatrix = new int[iNumber][];
            for (int i = 0; i < iNumber; i++)
            {
                int[] array = new int[iNumber];
                for (int j = 0; j < iNumber; j++)
                {
                    array[j] = 1;
                }
                arrayMatrix[i] = array;
            }
            return arrayMatrix;
        }
    }
}
