using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataStructure.StructureFile
{
    /// <summary>
    /// 
    /// </summary>
    public class TreeDemo
    {
        public static void Show()
        {
            Expression<Func<int, int, int, int>> expression = (i, m, n) => i * 3 + m + 2 + n / 4;
            CustomTreeNode tree = new CustomTreeNode()
            {
                iData = 123,
                Left = new CustomTreeNode()
                {
                    iData = 12,
                    Left = new CustomTreeNode()
                    {
                        iData = 11,
                        Left = null,
                        Right = null
                    },
                    Right = new CustomTreeNode()
                    {
                        iData = 12,
                        Left = null,
                        Right = null
                    }
                },
                Right = new CustomTreeNode()
                {
                    iData = 15,
                    Left = new CustomTreeNode()
                    {
                        iData = 13,
                        Left = null,
                        Right = null
                    },
                    Right = new CustomTreeNode()
                    {
                        iData = 17,
                        Left = null,
                        Right = null
                    }
                }
            };

            CustomBinarySearchTree tree1 = new CustomBinarySearchTree();
            tree1.Insert(10);
            tree1.SequentialTraversal();
            Console.WriteLine();
            tree1.Insert(5);
            tree1.SequentialTraversal();
            Console.WriteLine();
            tree1.Insert(1);
            tree1.SequentialTraversal();
            Console.WriteLine();
            tree1.Insert(8);
            tree1.SequentialTraversal();
            Console.WriteLine();
            tree1.Insert(20);
            tree1.SequentialTraversal();
            Console.WriteLine();
            tree1.Insert(28);
            tree1.SequentialTraversal();
            Console.WriteLine();
            tree1.Insert(12);
            tree1.SequentialTraversal();
            Console.WriteLine();
            tree1.Insert(6);
            tree1.SequentialTraversal();
            Console.WriteLine();
            tree1.Insert(7);
            tree1.SequentialTraversal();
            Console.WriteLine();
            tree1.Insert(25);
            tree1.SequentialTraversal();
            Console.WriteLine();


            Console.WriteLine(tree1.Min());
            Console.WriteLine(tree1.Max());
            Console.WriteLine(tree1.Find(25).iData);
        }

        private class CustomTreeNode
        {
            public int iData { get; set; }
            //public CustomTreeNode[] Child { get; set; }//任意树
            public CustomTreeNode Left { get; set; }
            public CustomTreeNode Right { get; set; }
            public void Show()
            {
                this.Left?.Show();
                Console.Write(this.iData + " ");//中序
                this.Right?.Show();

                //Console.Write(this.iData + " ");//先序
                //this.Left?.Show();
                //this.Right?.Show();

                //this.Left?.Show();
                //this.Right?.Show();
                //Console.Write(this.iData + " ");//后序
            }
        }
        /// <summary>
        /// 自定义二元查找树
        /// </summary>
        private class CustomBinarySearchTree
        {
            private CustomTreeNode _Root;
            public CustomBinarySearchTree()
            {
                this._Root = null;
            }
            public CustomBinarySearchTree(CustomTreeNode rootNode)
            {
                this._Root = rootNode;
            }

            public int Min()
            {
                CustomTreeNode current = this._Root;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current.iData;
            }
            public int Max()
            {
                CustomTreeNode current = this._Root;
                while (current.Right != null)
                {
                    current = current.Right;
                }
                return current.iData;
            }
            public CustomTreeNode Find(int i)
            {
                CustomTreeNode current = this._Root;
                while (current != null)
                {
                    if (i == current.iData)
                    {
                        return current;
                    }
                    if (i > current.iData)
                    {
                        current = current.Right;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
                return null;//没有
            }

            public void SequentialTraversal()
            {
                _Root.Show();
            }

            public void Insert(int i)
            {
                CustomTreeNode newNode = new CustomTreeNode();
                newNode.iData = i;
                if (_Root == null)
                {
                    _Root = newNode;//先初始化root
                    return;
                }
                else
                {
                    CustomTreeNode current = this._Root;
                    CustomTreeNode parent;
                    while (true)
                    {
                        parent = current;
                        if (i < current.iData)
                        {
                            current = current.Left;//再跟左边的比
                            if (current == null)
                            {
                                parent.Left = newNode;
                                break;
                            }
                        }
                        else
                        {
                            current = current.Right;//跟右边的比
                            if (current == null)
                            {
                                parent.Right = newNode;
                                break;
                            }
                        }
                    }
                }
            }

            #region Delete
            public bool Delete(int key)
            {
                CustomTreeNode current = this._Root;
                CustomTreeNode parent = _Root;
                bool isLeftChild = true;
                while (current.iData != key)
                {
                    parent = current;
                    if (key < current.iData)
                    {
                        isLeftChild = true;
                        current = current.Right;
                    }
                    else
                    {
                        isLeftChild = false;
                        current = current.Right;
                    }
                    if (current == null)
                        return false;
                }
                if ((current.Left == null) & (current.Right == null))
                    if (current == this._Root)
                        this._Root = null;
                    else if (isLeftChild)
                        parent.Left = null;
                    else if (current.Right == null)
                    {
                        if (current == this._Root)
                            this._Root = current.Left;
                        else if (isLeftChild)
                            parent.Left = current.Left;
                        else
                            parent.Right = current.Right;
                    }
                    else if (current.Left == null)
                    {
                        if (current == this._Root)
                            this._Root = current.Right;
                        else if (isLeftChild)
                            parent.Left = parent.Right;
                        else
                            parent.Right = current.Right;
                    }
                    else
                    {
                        CustomTreeNode successor = GetSubstitute(current);
                        if (current == this._Root)
                            this._Root = successor;
                        else if (isLeftChild)
                            parent.Left = successor;
                        else
                            parent.Right = successor;
                        successor.Left = current.Left;
                    }
                return true;
            }
            /// <summary>
            /// 找替补节点
            /// </summary>
            /// <param name="delNode"></param>
            /// <returns></returns>
            private CustomTreeNode GetSubstitute(CustomTreeNode delNode)
            {
                CustomTreeNode substituteParent = delNode;
                CustomTreeNode substitute = delNode;
                CustomTreeNode current = delNode.Right;
                while (!(current == null))
                {
                    substituteParent = current;
                    substitute = current;
                    current = current.Left;
                }
                if (!(substitute == delNode.Right))
                {
                    substituteParent.Left = substitute.Right;
                    substitute.Right = delNode.Right;
                }
                return substitute;
            }
            #endregion
        }
    }
}
