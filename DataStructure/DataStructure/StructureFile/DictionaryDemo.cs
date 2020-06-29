using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.StructureFile
{
    public class DictionaryDemo
    {
        public static void Show()
        {
            {
                //字典：泛型；key - value，增删查改 都很快；有序的
                //  字典不是线程安全 ConcurrentDictionary
                Console.WriteLine("***************Dictionary******************");
                Dictionary<int, string> dic = new Dictionary<int, string>();
                dic.Add(1, "HaHa");
                dic.Add(5, "HoHo");
                dic.Add(3, "HeHe");
                dic.Add(2, "HiHi");
                dic.Add(4, "HuHu1");
                dic[4] = "HuHu";
                dic.Add(4, "HuHu");
                foreach (var item in dic)
                {
                    Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
                }
            }
            {
                Console.WriteLine("***************SortedDictionary******************");
                SortedDictionary<int, string> dic = new SortedDictionary<int, string>();
                dic.Add(1, "HaHa");
                dic.Add(5, "HoHo");
                dic.Add(3, "HeHe");
                dic.Add(2, "HiHi");
                dic.Add(4, "HuHu1");
                dic[4] = "HuHu";
                dic.Add(4, "HuHu");
                foreach (var item in dic)
                {
                    Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
                }
            }
            {
                Console.WriteLine("***************SortedList******************");
                SortedList<string,string> sortedList = new SortedList<string, string>();//IComparer
                sortedList.Add("First", "Hello");
                sortedList.Add("Second", "World");
                sortedList.Add("Third", "!");

                sortedList["Third"] = "~~";//
                sortedList.Add("Fourth", "!");
                sortedList.Add("Fourth", "!");//重复的Key Add会错
                sortedList["Fourth"] = "!!!";
                var keyList = sortedList.Keys;
                var valueList = sortedList.Values;

                sortedList.TrimExcess();//用于最小化集合的内存开销

                sortedList.Remove("Third");
                sortedList.RemoveAt(0);
                sortedList.Clear();
            }
        }
    }
}
