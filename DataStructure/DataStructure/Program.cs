using DataStructure.AlgorithmFile;
using DataStructure.StructureFile;
using System;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                {
                    ArrayDemo.Show();

                    //StackDemo.Show();

                    //QueueDemo.Show();
                }
                {
                    //BasicSortDemo.Show();

                  //  BasicSearchDemo.Show();
                }

                {
                //    DictionaryDemo.Show();
                
                   // HashtableDemo.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
