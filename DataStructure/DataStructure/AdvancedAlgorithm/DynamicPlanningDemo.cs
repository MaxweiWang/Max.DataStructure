using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataStructure.AdvancedAlgorithm
{
    public class DynamicPlanningDemo
    {
        public static void Show()
        {
            #region Fibonacci
            //int n = 5;
            //{
            //    {
            //        Stopwatch stopwatch = new Stopwatch();
            //        stopwatch.Start();
            //        long lResult = RecursionFibonacci(n);
            //        stopwatch.Stop();
            //        Console.WriteLine($"RecursionFibonacci {n}  Time{stopwatch.ElapsedMilliseconds}");
            //    }
            //    {
            //        Stopwatch stopwatch = new Stopwatch();
            //        stopwatch.Start();
            //        long lResult = DynamicFibonacci(n);
            //        stopwatch.Stop();
            //        Console.WriteLine($"DynamicFibonacci {n}  Time{stopwatch.ElapsedMilliseconds}");
            //    }
            //    {
            //        Stopwatch stopwatch = new Stopwatch();
            //        stopwatch.Start();
            //        long lResult = DynamicFibonacciWithoutArray(n);
            //        stopwatch.Stop();
            //        Console.WriteLine($"DynamicFibonacciWithoutArray {n}  Time{stopwatch.ElapsedMilliseconds}");
            //    }
            //}
            #endregion

            #region 公共字符串
            //string wordLeft = "eleven";
            //string wordRight = "seven";// "secen";// "sevem";
            //string result = FindLongCommonSubString(wordLeft, wordRight);

            //if (string.IsNullOrWhiteSpace(result))
            //{
            //    Console.WriteLine("没有共同字符串");
            //}
            //else
            //{
            //    Console.WriteLine("最长共同字符串: " + result);
            //}
            #endregion

            #region MyRegion
            Package();
            #endregion
        }

        #region Fibonacci
        /// <summary>
        /// 递归--0 1 1 2 3 5 8
        /// </summary>
        /// <param name="n">从1开始</param>
        /// <returns></returns>
        public static long RecursionFibonacci(int n)
        {
            if (n < 2)
            {
                return n;
            }
            else
            {
                return RecursionFibonacci(n - 1) + RecursionFibonacci(n - 2);
            }
        }
        /// <summary>
        /// 动态规划-0 1 1 2 3 5 8
        /// </summary>
        /// <param name="n">从1开始</param>
        /// <returns></returns>
        public static long DynamicFibonacci(int n)
        {
            int[] totalArray = new int[n];
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                totalArray[1] = 1;
                totalArray[2] = 2;
                for (int i = 3; i <= n - 1; i++)
                {
                    totalArray[i] = totalArray[i - 1] + totalArray[i - 2];
                }
            }
            return totalArray[n - 1];
        }
        /// <summary>
        /// 动态规划-0 1 1 2 3 5 8
        /// </summary>
        /// <param name="n">从1开始</param>
        /// <returns></returns>
        public static long DynamicFibonacciWithoutArray(int n)
        {
            long last = 1;
            long nextLast = 1;
            long result = 1;
            for (int i = 2; i <= n - 1; i++)
            {
                result = last + nextLast;
                nextLast = last;
                last = result;
            }
            return result;
        }
        #endregion

        #region 公共字符串
        public static string FindLongCommonSubString(string wordLeft, string wordRight)
        {
            string[] warrayLeft = new string[wordLeft.Length];
            string[] warrayRight = new string[wordRight.Length];
            string subString;
            int[,] larray = new int[wordLeft.Length, wordRight.Length];
            CompareString(wordLeft, wordRight, warrayLeft, warrayRight, larray);
            Console.WriteLine();
            ShowArray(larray);
            subString = GetString(larray, warrayLeft);
            Console.WriteLine();
            Console.WriteLine("The strings are: " + wordLeft + " " + wordRight);

            return subString;
        }

        /// <summary>
        /// 分组比较
        /// </summary>
        /// <param name="wordLeft"></param>
        /// <param name="wordRight"></param>
        /// <param name="wordArrayLeft"></param>
        /// <param name="wordArrayRight"></param>
        /// <param name="arr"></param>
        private static void CompareString(string wordLeft, string wordRight, string[] wordArrayLeft, string[] wordArrayRight, int[,] arr)
        {
            int lenLeft = wordLeft.Length;
            int lenRight = wordRight.Length;
            for (int k = 0; k <= wordLeft.Length - 1; k++)
            {
                wordArrayLeft[k] = wordLeft.Substring(k, 1);
            }
            for (int k = 0; k <= wordRight.Length - 1; k++)
            {
                wordArrayRight[k] = wordRight.Substring(k, 1);
            }
            for (int i = lenLeft - 1; i >= 0; i--)
            {
                for (int j = lenRight - 1; j >= 0; j--)
                {
                    if (wordArrayLeft[i] == wordArrayRight[j])
                    {
                        if (i == lenLeft - 1 || j == lenRight - 1)//最右边
                        {
                            arr[i, j] = 1;
                        }
                        else
                        {
                            arr[i, j] = 1 + arr[i + 1, j + 1];
                        }
                        //arr[i, j] = 1;
                    }
                    else
                    {
                        arr[i, j] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// 寻找最长字符串
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="wordArrayLeft"></param>
        /// <returns></returns>
        private static string GetString(int[,] arr, string[] wordArrayLeft)
        {
            string subString = "";
            int max = 0;
            int leftIndex = 0;
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        leftIndex = i;
                    }
                }
            }
            for (int i = 0; i < max; i++)
            {
                subString += wordArrayLeft[leftIndex + i];
            }
            return subString;
        }
        /// <summary>
        /// 二维数组展示
        /// </summary>
        /// <param name="arr"></param>
        private static void ShowArray(int[,] arr)
        {
            Console.WriteLine("展示比对结果");
            for (int row = 0; row <= arr.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= arr.GetUpperBound(1); col++)
                {
                    Console.Write(arr[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region 背包问题
        public static void Package()
        {
            int capacity = 16;
            int[] size = new int[] { 3, 4, 7, 8, 9 };//财宝尺寸
            int[] values = new int[] { 4, 5, 10, 11, 13 };//财宝价值
            int[] totleValue = new int[capacity + 1];//价值组--用来保存当时的最大价值

            for (int j = 0; j <= values.Length - 1; j++)//假如只有一件宝物--然后再慢慢增加
            {
                for (int i = 0; i <= capacity; i++)//假如只有一个单位的空间--然后再慢慢增加
                {
                    if (i >= size[j])
                    {
                        if (totleValue[i] < (totleValue[i - size[j]] + values[j]))
                        {
                            totleValue[i] = totleValue[i - size[j]] + values[j];
                        }
                    }
                }
            }
            Console.WriteLine("The Max value is: " + totleValue[capacity]);
        }
        #endregion
    }
}
