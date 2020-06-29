using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.StructureFile
{
    public class HashtableDemo
    {
        public static void Show()
        {
            //Hashtable key-value  体积可以动态增加 拿着key计算一个地址，然后放入key - value
            //object-装箱拆箱  如果不同的key得到相同的地址，第二个在前面地址上 + 1
            //查找的时候，如果地址对应数据的key不对，那就 + 1查找。。
            //浪费了空间，Hashtable是基于数组实现
            //查找个数据  一次定位； 增删 一次定位；  增删查改 都很快
            //浪费空间，数据太多，重复定位定位，效率就下去了
            Console.WriteLine("***************Hashtable******************");
            Hashtable table = new Hashtable();
            table.Add("123", "456");
            table[234] = 456;
            table[234] = 567;
            table[32] = 4562;
            table[1] = 456;
            table["eleven"] = 456;
            foreach (DictionaryEntry objDE in table)
            {
                Console.WriteLine(objDE.Key.ToString());
                Console.WriteLine(objDE.Value.ToString());
            }
            //线程安全
            Hashtable.Synchronized(table);//只有一个线程写  多个线程读
        }
    }
}
