using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.StructureFile
{
    public class LinkedListDemo
    {
        public static void Show()
        {
            #region MyRegion
            {
                CustomStack<string> stack = new CustomStack<string>();
                foreach (var item in "wxw-Ivy-NE-Hide".Split("-"))
                {
                    stack.Push(item);
                }

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(stack.Pop());
                    Console.WriteLine(stack.Peek());
                    Console.WriteLine(stack.Pop());
                }
            }
            #endregion


            #region 双向链表
            //1.链表的声明以及节点的定义
            LinkedList<string> link = new LinkedList<string>(); //定义链表
            LinkedListNode<string> node1 = new LinkedListNode<string>("E1"); //第一个节点
            LinkedListNode<string> node2 = new LinkedListNode<string>("E2"); //第二个节点s
            LinkedListNode<string> node3 = new LinkedListNode<string>("E3");
            LinkedListNode<string> node4 = new LinkedListNode<string>("E4");

            //2.节点的加入
            link.AddFirst(node1); //加入第一个节点
            link.AddAfter(node1, node2);
            link.AddAfter(node2, node3);
            link.AddAfter(node3, node4);

            //3.计算包含的数量
            Console.WriteLine(link.Count);

            //4.显示
            LinkedListNode<string> current = link.First;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }

            //5.查找
            LinkedListNode<string> temp = link.Find("jiajia2");
            if (temp != null)
            {
                Console.WriteLine("找到这个节点" + temp.Value);
            }

            //6.定位最后节点
            temp = link.Last;
            Console.WriteLine("最后这个节点" + temp.Value);

            //7.一些删除操作
            link.RemoveFirst();
            link.Remove("jiajia2");
            link.Clear();


            #endregion
        }

        /// <summary>
        /// 链表--单向链表够用了
        /// </summary>
        private class CustomNode<T>
        {
            public T Element;//当前的值
            public CustomNode<T> NextNode;//下个节点
            public CustomNode()
            {
                Element = default(T);
                NextNode = null;
            }
            public CustomNode(T theElement)
            {
                Element = theElement;
                NextNode = null;
            }
        }
        /// <summary>
        /// 单向链表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class CustomeLinkedList<T>
        {
            private CustomNode<T> _CurrentHeader;
            public CustomeLinkedList()
            {
                this._CurrentHeader = new CustomNode<T>(default(T));
            }
            public CustomeLinkedList(CustomNode<T> header)
            {
                this._CurrentHeader = header;
            }
            public void Add(T t)
            {
                CustomNode<T> node = new CustomNode<T>(t);
                node.NextNode = _CurrentHeader;
                _CurrentHeader = node;
            }
            public T GetAndRemove()
            {
                T t = _CurrentHeader.Element;
                CustomNode<T> node = _CurrentHeader.NextNode;
                _CurrentHeader = node;
                return t;
            }
            //其实应该检查还有没有
            public T Get()
            {
                T t = _CurrentHeader.Element;
                return t;
            }
        }
        private class CustomStack<T>
        {
            private CustomeLinkedList<T> _Container = new CustomeLinkedList<T>();
            public void Push(T t)
            {
                this._Container.Add(t);
            }
            public T Pop()
            {
                return this._Container.GetAndRemove();
            }
            public T Peek()
            {
                return this._Container.Get();
            }
        }

    }
}
