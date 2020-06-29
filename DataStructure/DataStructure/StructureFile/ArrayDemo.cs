using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.StructureFile
{
    public class ArrayDemo
    {
        public static void Show()
        {
            {
                Console.WriteLine("***************Array******************");
                int[] intArray = new int[3];
                intArray[0] = 123;
                string[] stringArray = new string[] { "123", "234" };
            }
            {
                Console.WriteLine("***************多维Array******************");
           
                int[,] a = new int[3, 4] {
                                 {0, 1, 2, 3} ,   /*  初始化索引号为 0 的行 */
                                 {4, 5, 6, 7} ,   /*  初始化索引号为 1 的行 */
                                 {8, 9, 10, 11}   /*  初始化索引号为 2 的行 */
                                };
            }

            {
                Console.WriteLine("***************锯齿Array******************");
                int[][] a = new int[2][];  //每个数组的元素不确定
                a[0] = new int[] { 1, 2, 3 }; /*  初始化索引号为 0 的行 */
                a[1] = new int[] { 2 };  /*  初始化索引号为 1 的行 */
            }

            {

                Console.WriteLine("***************ArrayList******************");
                ArrayList arrayList = new ArrayList();
                arrayList.Add("wxw");
                arrayList.Add("Is");
                arrayList.Add("wxw");
                arrayList.Add(3);//add增加长度
                ArrayList list2 = new ArrayList();
                list2.Add("tt");
                list2.Add("dd");
                arrayList.InsertRange(2, list2);
                foreach (var item in arrayList)
                {
                    Console.WriteLine(item.ToString()+",");
                }
                Console.WriteLine(arrayList.Count);
                Console.WriteLine(arrayList.Capacity);
                //arrayList[4] = 26;//索引复制，不会增加长度
                //删除数据
                //arrayList.RemoveAt(4);
                var value = arrayList[2];
                arrayList.RemoveAt(0);//开辟空间--copy
                arrayList.Remove("wxw");
                arrayList.RemoveRange(1, 3); //Index表示索引，count表示从索引处开始的数目
                arrayList.Sort();//排序
                arrayList.Reverse(); //反转
                arrayList.IndexOf("wxw");
                arrayList.LastIndexOf("wxw");  //从最后面找

                //Capacity 每次都是增长一倍 *2，默认大小是4
                //Capacity是ArrayList可以存储的元素数。Count是ArrayList中实际包含的元素数。Capacity总是大于或等于Count。如果在添加元素时，Count超过Capacity，则该列表的容量会通过自动重新分配内部数组加倍。  如果Capacity的值显式设置，则内部数组也需要重新分配以容纳指定的容量。如果Capacity被显式设置为0，则公共语言运行库将其设置为默认容量。默认容量为16。
                {
                    ArrayList arrayList1 = new ArrayList();
                    arrayList1.Add("wxw");
                    arrayList1.Add("Is");
                    Console.WriteLine(arrayList1.Capacity);
                    arrayList1.TrimToSize();
                    Console.WriteLine(arrayList1.Capacity);
                }
                {
                    ArrayList arrayList1 = new ArrayList(6);
                    arrayList1.Add("wxw");
                    arrayList1.Add("Is");
                    arrayList1.Add("wxw");
                    arrayList1.Add("Is");
                    Console.WriteLine(arrayList1.Capacity);
                    arrayList1.TrimToSize();
                    Console.WriteLine(arrayList1.Capacity);
                }
            }
            {
                //List:也是Array，内存上都是连续摆放;不定长；泛型，保证类型安全，避免装箱拆箱
                //读取快--增删慢
                Console.WriteLine("***************List<T>******************");
                List<int> intList = new List<int>() { 1, 2, 3, 4 };
                intList.Add(123);
                intList.Add(123);
                //intList.Add("123");
                //intList[0] = 123;
                List<string> stringList = new List<string>();
                //stringList[0] = "123";//异常的

                {
                    List<int> intList1 = new List<int>() { 1, 2, 3, 4, 5 };
                    intList1.Add(123);
                    intList1.Add(123);
                    intList1.Add(123);
                    intList1.Add(123);
                    Console.WriteLine(intList1.Capacity);
                    intList1.TrimExcess();
                    Console.WriteLine(intList1.Capacity);
                }
                {
                    List<int> intList1 = new List<int>(3) { 1, 2, 3, 4 };
                    intList1.Add(123);
                    intList1.Add(123);
                    intList1.Add(123);
                    Console.WriteLine(intList1.Capacity);
                    //intList1.TrimToSize();
                    Console.WriteLine(intList1.Capacity);
                }
            }
        }

    }
}
