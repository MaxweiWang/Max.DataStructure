using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataStructure.AlgorithmFile
{
    /// <summary>
    /// 进阶排序算法
    /// </summary>
    public static class AdvancedSortDemo
    {
        public static void Show()
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                Thread.Sleep(100);
                array[i] = new Random(i + 100 + DateTime.Now.Millisecond).Next(100, 999);
            }

            Console.WriteLine("before AdvancedSort");
            array.Show();
            Console.WriteLine("start AdvancedSort");
            //array.ShellSort();
            //array.MergeSort();
            //array.HeapSort();
            array.QuickSort();
            Console.WriteLine("  end AdvancedSort");
            array.Show();
        }

        #region 希尔排序
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="arr"></param>
        private static void InsertionSortOld(this int[] arr)
        {
            int inner, temp;
            for (int outer = 1; outer <= arr.Length - 1; outer++)
            {
                temp = arr[outer];//6
                inner = outer;
                while (inner > 0 && arr[inner - 1] >= temp)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }
                arr[inner] = temp;
                arr.Show();
            }
        }
        private static void ShellSort(this int[] arr)
        {
            int inner = 0;
            int temp = 0;
            int increment = 0;

            while (increment <= arr.Length / 3)//10--4      20    13
            {
                increment = increment * 3 + 1;
            }
            while (increment > 0)//4--1
            {
                for (int outer = increment; outer <= arr.Length - 1; outer++)
                {
                    temp = arr[outer];
                    inner = outer;
                    while ((inner > increment - 1) && arr[inner - increment] >= temp)
                    {
                        arr[inner] = arr[inner - increment];
                        inner -= increment;
                    }
                    arr[inner] = temp;
                    arr.Show();
                }//increment=1时就是插入排序一样的代码
                increment = (increment - 1) / 3;
                arr.Show();
            }
        }
        #endregion

        #region 归并排序
        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(this int[] arr)
        {
            int[] temp = new int[arr.Length];//准备空数组
            PartSort(arr, 0, arr.Length - 1, temp);
        }
        /// <summary>
        /// 递归分治
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="temp"></param>
        private static void PartSort(int[] arr, int left, int right, int[] temp)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                PartSort(arr, left, middle, temp);//左边归并排序
                PartSort(arr, middle + 1, right, temp);//右边归并排序
                Merge(arr, left, middle, right, temp);//合并操作
            }
        }
        private static void Merge(int[] arr, int left, int mid, int right, int[] temp)
        {
            int i = left;
            int j = mid + 1;
            int t = 0;
            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    //temp[t++] = arr[i++];
                    temp[t] = arr[i];
                    t++;
                    i++;
                }
                else
                {
                    //temp[t++] = arr[j++];
                    temp[t] = arr[j];
                    t++;
                    j++;
                }
            }
            while (i <= mid)
            {
                temp[t++] = arr[i++];//将左边剩余元素填充进temp中
            }
            while (j <= right)
            {
                temp[t++] = arr[j++];//将右序列剩余元素填充进temp中
            }
            t = 0;
            while (left <= right)
            {
                arr[left++] = temp[t++];//将temp中的元素全部拷贝到原数组中
            }
            arr.Show();
        }
        #endregion

        #region 堆排序
        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="arr"></param>
        public static void HeapSort(this int[] arr)
        {
            //1.构建大顶堆
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                BuildHeap(arr, i, arr.Length);
            }
            Console.WriteLine("堆构建完成");
            //2.交换堆顶元素与末尾元素
            for (int j = arr.Length - 1; j > 0; j--)
            {
                Swap(arr, 0, j);
                BuildHeap(arr, 0, j);
            }
        }

        /// <summary>
        /// 保证局部大小符合
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="Length"></param>
        private static void BuildHeap(int[] arr, int i, int Length)
        {
            int temp = arr[i];//枝干节点
            for (int k = i * 2 + 1; k < Length; k = k * 2 + 1)
            {
                //arr[k]子节点  arr[k+1]子节点
                if (k + 1 < Length && arr[k] < arr[k + 1])
                {//两个子节点对比  要最大的k<k+1就把k++
                    k++;
                }
                if (arr[k] > temp)
                {//最大如果大于枝干节点
                    arr[i] = arr[k];
                    i = k;//把i换成k 下面再替换，等于交换值
                }
                else
                {
                    break;
                }
                //继续循环就以刚才节点为枝干节点去比较其子节点，持续交换下去
            }
            arr[i] = temp;
            arr.Show();
        }
        private static void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
        #endregion

        #region 快排
        public static void QuickSort(this int[] arr)
        {
            QuickSortRecursion(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// 递归排序单个数组
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void QuickSortRecursion(int[] arr, int left, int right)
        {
            if (left < right)
            {
                SetReference(arr, left, right);//获取参照物
                int referenceIndex = right - 1;
                int i = left;
                int j = right - 1;
                while (true)
                {
                    while (arr[++i] < arr[referenceIndex])
                    {
                    }
                    while (j > left && arr[--j] > arr[referenceIndex])
                    {
                    }
                    if (i < j)
                    {
                        Swap(arr, i, j);
                        arr.Show();
                    }
                    else
                    {
                        break;
                    }
                }
                if (i < right)
                {
                    Swap(arr, i, right - 1);
                    arr.Show();
                }
                QuickSortRecursion(arr, left, i - 1);
                QuickSortRecursion(arr, i + 1, right);
            }
        }
        private static void SetReference(int[] arr, int left, int right)
        {
            int mid = (left + right) / 2;
            if (arr[left] > arr[mid])
            {
                Swap(arr, left, mid);
            }
            if (arr[left] > arr[right])
            {
                Swap(arr, left, right);
            }
            if (arr[right] < arr[mid])
            {
                Swap(arr, right, mid);
            }
            arr.Show();
            Swap(arr, right - 1, mid);
            arr.Show();
        }

        #endregion

        private static void Show(this int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}
