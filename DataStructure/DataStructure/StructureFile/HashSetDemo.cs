using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.StructureFile
{
    public class HashSetDemo
    {
        public static void Show()
        {
            #region Set
            {
                Console.WriteLine("***************HashSet<string>******************");
                HashSet<string> hashSet = new HashSet<string>();
                hashSet.Add("123");
                hashSet.Add("689");
                hashSet.Add("456");
                hashSet.Add("12435");
                hashSet.Add("12435");
                hashSet.Add("12435");
                //hashSet[0];
                foreach (var item in hashSet)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(hashSet.Count);
                Console.WriteLine(hashSet.Contains("12345"));

                {
                    HashSet<string> hashSet1 = new HashSet<string>();
                    hashSet1.Add("123");
                    hashSet1.Add("689");
                    hashSet1.Add("789");
                    hashSet1.Add("12435");
                    hashSet1.Add("12435");
                    hashSet1.Add("12435");
                    hashSet1.SymmetricExceptWith(hashSet);//补
                    hashSet1.UnionWith(hashSet);//并
                    hashSet1.ExceptWith(hashSet);//差
                    hashSet1.IntersectWith(hashSet);//交
                    //风--亡五  找出共同的好友
                }
                hashSet.ToList();
                hashSet.Clear();
            }
            {
                //排序的集合：去重  而且排序  
                //统计排名--每统计一个就丢进去集合
                Console.WriteLine("***************SortedSet<string>******************");
                SortedSet<string> sortedSet = new SortedSet<string>();
                //IComparer<T> comparer  自定义对象要排序，就用这个指定
                sortedSet.Add("123");
                sortedSet.Add("689");
                sortedSet.Add("456");
                sortedSet.Add("12435");
                sortedSet.Add("12435");
                sortedSet.Add("12435");

                foreach (var item in sortedSet)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(sortedSet.Count);
                Console.WriteLine(sortedSet.Contains("12345"));
                {
                    SortedSet<string> sortedSet1 = new SortedSet<string>();
                    sortedSet1.Add("123");
                    sortedSet1.Add("689");
                    sortedSet1.Add("456");
                    sortedSet1.Add("12435");
                    sortedSet1.Add("12435");
                    sortedSet1.Add("12435");
                    sortedSet1.SymmetricExceptWith(sortedSet);//补
                    sortedSet1.UnionWith(sortedSet);//并
                    sortedSet1.ExceptWith(sortedSet);//差
                    sortedSet1.IntersectWith(sortedSet);//交
                }

                sortedSet.ToList();
                sortedSet.Clear();
            }
            #endregion
        }
    }
}
