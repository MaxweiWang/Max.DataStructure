using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.StructureFile
{
    public class StackDemo
    {
        public static void Show()
        {
            Console.WriteLine("***************Stack<T>******************");
            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");//放进去

            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"Pop '{numbers.Pop()}'");//获取并移除
            Console.WriteLine($"Peek at next item to dequeue: { numbers.Peek()}");//获取不移除
            Console.WriteLine($"Pop '{numbers.Pop()}'");

            Stack<string> stackCopy = new Stack<string>(numbers.ToArray());
            foreach (string number in stackCopy)
            {
                Console.WriteLine(number);
            }

            //stackCopy.Capacity;
            stackCopy.TrimExcess();

            Console.WriteLine($"stackCopy.Contains(\"four\") = {stackCopy.Contains("four")}");
            stackCopy.Clear();
            Console.WriteLine($"stackCopy.Count = {stackCopy.Count}");


            {
                //进制转换

            }
        }
        /// <summary>
        ///   
        /// </summary>
        /// <param name="number">原进制的值</param>
        /// <param name="b">目标进制</param>
        private static void BinaryConversion(int number, int format)
        {
            Stack<int> targetStack = new Stack<int>();
            do
            {
                targetStack.Push(number % format);
                number = number / format;
            } 
            while (number != 0);

            while (targetStack.Count > 0)
            {
                Console.Write(targetStack.Pop());
            }
        }
    }
}
