using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataStructure.StructureFile
{
    /// <summary>
    /// 
    /// </summary>
    public class AVLTreeDemo
    {
        public static void Show()
        {

            //***************************************************************
            int[] arr = { 3, 2, 1, 4, 5, 6, 7, 16, 15, 14, 13, 12, 11, 10, 8, 9 };

            int i;
            AVLTree tree = new AVLTree();

            Console.WriteLine("*******依次添加: ");
            for (i = 0; i < arr.Length; i++)
            {
                tree.Insert(arr[i]);
            }

            Console.WriteLine("*******前序遍历: ");
            tree.PreTraversal();
            Console.WriteLine();


            Console.WriteLine("*******中序遍历: ");
            tree.SequentialTraversal();
            Console.WriteLine();


            Console.WriteLine("*******后序遍历: ");
            tree.PostTraversal();
            Console.WriteLine();


            Console.WriteLine("*******高度:" + tree.TreeHeight());
            Console.WriteLine("*******最小值:" + tree.Min().Value);
            Console.WriteLine("*******最大值:" + tree.Max().Value);
            Console.WriteLine("*******树的详细信息:");
            tree.Show();
            Console.WriteLine();


            i = 8;
            Console.WriteLine($"*******删除根节点: {i}");
            tree.Remove(i);
            tree.Show();
            Console.WriteLine("*******高度:" + tree.TreeHeight());
            Console.WriteLine("*******中序遍历: ");
            tree.SequentialTraversal();
            Console.WriteLine();

            i = 17;
            Console.WriteLine($"*******增加根节点: {i}");
            tree.Insert(i);
            tree.Show();
            Console.WriteLine("*******高度:" + tree.TreeHeight());
            Console.WriteLine("*******中序遍历: ");
            tree.SequentialTraversal();
            Console.WriteLine();

            Console.WriteLine("*******树的详细信息:");
            tree.Show();
            Console.WriteLine();

            // 销毁二叉树
            tree.Destroy();
        }


        #region AVLTree
        public class Node : IComparable
        {
            public int Value;
            public int Height;//结点的高度
            public Node Left;
            public Node Right;

            public Node(int value)
            {
                this.Value = value;
                this.Left = null;
                this.Right = null;
                Height = 1;
            }
            /// <summary>
            /// 拿value比对本节点，
            /// value大为1  小为-1
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public int CompareTo(object value)
            {
                int.TryParse(value.ToString(), out int targetValue);
                if (targetValue > this.Value)
                    return 1;
                else if (targetValue == this.Value)
                    return 0;
                else
                    return -1;
            }
        }

        public class AVLTree
        {
            #region 构造
            private Node _Root;
            public AVLTree()
            {
                _Root = null;
            }
            #endregion

            #region 高度
            private int NodeHeight(Node node)
            {
                if (node != null)
                {
                    return node.Height;
                }
                return 0;
            }
            public int TreeHeight()
            {
                return NodeHeight(_Root);
            }
            #endregion

            #region private
            private int ChooseMax(int a, int b)
            {
                return a > b ? a : b;
            }
            private void ReplaceNode(Node src, Node tar)
            {
                tar.Value = src.Value;
            }
            #endregion

            #region 三种遍历

            private void PreTraversal(Node node)
            {
                if (node != null)
                {
                    Console.Write(node.Value + " ");
                    PreTraversal(node.Left);
                    PreTraversal(node.Right);
                }
            }

            public void PreTraversal()
            {
                PreTraversal(_Root);
            }

            private void SequentialTraversal(Node node)
            {
                if (node != null)
                {
                    SequentialTraversal(node.Left);
                    Console.Write(node.Value + " ");
                    SequentialTraversal(node.Right);
                }
            }

            public void SequentialTraversal()
            {
                SequentialTraversal(_Root);
            }

            private void PostTraversal(Node node)
            {
                if (node != null)
                {
                    PostTraversal(node.Left);
                    PostTraversal(node.Right);
                    Console.Write(node.Value + " ");
                }
            }

            public void PostTraversal()
            {
                PostTraversal(_Root);
            }
            #endregion

            #region 查找-最大-最小
            /// <summary>
            /// 查找 node根节点
            /// </summary>
            /// <param name="node"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            private Node Search(Node node, int value)
            {
                if (node == null)
                {
                    return null;
                }
                int compare = node.CompareTo(value);
                if (compare == 0)
                {
                    return node;
                }
                else if (compare < 0)
                {
                    return Search(node.Left, value);
                }
                else
                {
                    return Search(node.Right, value);
                }
            }

            public Node Search(int value)
            {
                return Search(_Root, value);
            }

            private Node Min(Node node)
            {
                if (node == null)
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    return node;
                }
                else
                {
                    return Min(node.Left);
                }
            }

            public Node Min()
            {
                return Min(_Root);
            }

            private Node Max(Node node)
            {
                if (node == null)
                {
                    return null;
                }
                else if (node.Right == null)
                {
                    return node;
                }
                else
                {
                    return Max(node.Right);
                }
            }

            public Node Max()
            {
                return Max(_Root);
            }
            #endregion

            #region 4种旋转
            // 对如下的LL情况
            //
            //         k1                 k2
            //        /  \               /  \
            //       k2   z    LL单转   x    k1
            //      /  \       ----\   /    / \
            //     x    y      ----/  o    y   z
            //    //    /      k1右旋
            //   o
            //
            //   或
            //
            //         k1                 k2
            //        /  \               /  \
            //       k2   z    LL单转    x   k1
            //      /  \       ----\     \  / \
            //     x    y      ----/      o y  z
            //      \          k1右旋
            //       o
            //
            private Node LeftLeftRotation(Node k1)
            {
                Node k2 = k1.Left; //k2是k1的左子树

                k1.Left = k2.Right;//k2的右子树 变为k1的左子树
                k2.Right = k1; //k1变为k2的右子树

                k1.Height = ChooseMax(NodeHeight(k1.Left), NodeHeight(k1.Right)) + 1;//计算k1的高度
                k2.Height = ChooseMax(NodeHeight(k2.Left), k1.Height) + 1;//计算k2的高度

                return k2;//返回新的根k2
            }

            // 对如下的RR情况
            //
            //         k1                      k2
            //        /  \                    /  \
            //       x    k2      RR单转     k1   k3
            //           / \      ----\     / \    \
            //          y   k3    ----/    x   y    z
            //               \    k1左旋
            //                z
            //
            //   或
            //
            //         k1                      k2
            //        /  \                    /  \
            //       x    k2      RR单转     k1   k3
            //           / \      ----\     / \   /
            //          y  k3     ----/    x   y z
            //             /      k1左旋
            //            z
            //
            public Node RightRightRotation(Node k1)
            {
                Node k2 = k1.Right;

                k1.Right = k2.Left;
                k2.Left = k1;

                k1.Height = ChooseMax(NodeHeight(k1.Left), NodeHeight(k1.Right)) + 1;
                k2.Height = ChooseMax(k1.Height, NodeHeight(k2.Right)) + 1;

                return k2;
            }

            // 对如下的LR情况
            //      k1                k1                k3
            //     /  \              /  \              /  \
            //    k2   z  RR单转    k3   z   LL单转    k2  k1
            //   /  \     -----\   / \      -----\   / \  / \
            //  w   k3    -----/  k2  y     -----/  w  x y   z
            //     /  \   k2左旋  / \        k1右旋
            //    x    y         w  x
            //
            public Node LeftRightRotation(Node k1)
            {
                k1.Left = RightRightRotation(k1.Left);
                return LeftLeftRotation(k1);
            }

            // 对如下的RL情况
            //    k1                k1                  k3
            //   /  \     LL单转    / \      RR单旋     /  \
            //  w   k2    -----\   w  k3    -----\    k1  k2
            //      / \   -----/     / \    -----/   / \  / \
            //     k3  z  k2右旋     x  k2   k1左旋  w   x y  z
            //    / \                  / \
            //   x   y                y   z
            //
            public Node RightLeftRotation(Node k1)
            {
                k1.Right = LeftLeftRotation(k1.Right);
                return RightRightRotation(k1);
            }
            #endregion

            #region 插入
            private Node Insert(Node node, int value)
            {
                if (node == null) return new Node(value);

                if (node.CompareTo(value) == 0)
                {//如果key相同则更新该节点
                    node.Value = value;//可以记录个count
                }
                else if (node.CompareTo(value) < 0)
                {//如果key比当前根小，则去左子树找。即一步Left
                    node.Left = Insert(node.Left, value);
                    if (NodeHeight(node.Left) - NodeHeight(node.Right) == 2)
                    {//插在左边所以肯定是左-右，高度差2表示已经不平衡
                        if (node.Left.CompareTo(value) < 0)
                        {// 又一步Left，所以是LeftLeft
                            node = LeftLeftRotation(node);
                        }
                        else
                        { //一步Right，所以是LeftRight
                            node = LeftRightRotation(node);
                        }
                    }
                }
                else
                {   // node.key < key,那么去右子树找.即一步Right
                    node.Right = Insert(node.Right, value);
                    if (NodeHeight(node.Right) - NodeHeight(node.Left) == 2)
                    {//插在右边所以肯定是右-左，高度差2表示已经不平衡
                        if (node.Right.CompareTo(value) > 0)
                        {//又一步Right,所以是RightRight
                            node = RightRightRotation(node);
                        }
                        else
                        {//一步Left，所以是RightLeft
                            node = RightLeftRotation(node);
                        }
                    }
                }

                node.Height = ChooseMax(NodeHeight(node.Left), NodeHeight(node.Right)) + 1;
                return node;
            }
            public void Insert(int value)
            {
                this._Root = Insert(this._Root, value);
            }
            #endregion

            #region 删除
            public Node Remove(Node node, Node target)
            {
                if (node == null || target == null) return node;
                int compare = node.CompareTo(target.Value);

                if (compare < 0)
                {//待删除key的比根的key小，那么继续在左子树查找
                    node.Left = Remove(node.Left, target);
                    if (NodeHeight(node.Right) - NodeHeight(node.Left) == 2)
                    {//如果在删除后失去平衡
                        if (NodeHeight(node.Right.Left) <= NodeHeight(node.Right.Right))
                        {
                            node = RightRightRotation(node);
                        }
                        else
                        {
                            node = RightLeftRotation(node);
                        }
                    }
                }
                else if (compare > 0)
                {//待删除key的比根的key大，那么继续在右子树查找
                    node.Right = Remove(node.Right, target);
                    if (NodeHeight(node.Left) - NodeHeight(node.Right) == 2)
                    {
                        if (NodeHeight(node.Left.Right) <= NodeHeight(node.Left.Left))
                        {
                            node = LeftLeftRotation(node);
                        }
                        else
                        {
                            node = RightRightRotation(node);
                        }
                    }
                }
                else
                { // node.key == target.key
                    if (node.Left == null)
                    { // 如果node的左子树为空，那么删除node后，新的根就是node.right
                        return node.Right;
                    }
                    else if (node.Right == null)
                    {// 如果node的右子树为空，那么删除node后，新的根就是node.left
                        return node.Left;
                    }
                    else
                    { // 如果node既有左子树，又有右子树
                        if (NodeHeight(node.Left) > NodeHeight(node.Right))
                        {//如果左子树比右子树深
                            Node predecessor = Max(node.Left);//找node的前继结点predecessor
                            ReplaceNode(predecessor, node);//predecessor替换node
                            node.Left = Remove(node.Left, predecessor);//再把原来的predecessor删掉
                        }
                        else
                        {//如果右子树比左子树深(一样深的话无所谓了)
                            Node successor = Min(node.Right);//找node的后继结点successor
                            ReplaceNode(successor, node);//successor替换node
                            node.Right = Remove(node.Right, successor);//再把原来的successor删掉
                        }
                    }
                }
                return node;
            }
            public void Remove(int value)
            {
                Node z = Search(_Root, value);
                if (z != null)
                    _Root = Remove(_Root, z);
            }
            #endregion

            #region Show-Destroy
            private void Destroy(Node node)
            {
                if (node == null)
                    return;

                if (node.Left != null)
                    Destroy(node.Left);
                if (node.Right != null)
                    Destroy(node.Right);

                node = null;
            }
            public void Destroy()
            {
                Destroy(_Root);
            }
            private void Show(Node node, int value, string pos)
            {
                if (node != null)
                {
                    if (pos.Equals(""))    // tree是根节点
                        Console.WriteLine($"{node.Value} is root");
                    else                // tree是某个value的分支节点
                        Console.WriteLine($"{node.Value} is  {value}  {pos} child,height={node.Height}");

                    Show(node.Left, node.Value, "left");
                    Show(node.Right, node.Value, "right");
                }
            }
            public void Show()
            {
                if (_Root != null) Show(_Root, _Root.Value, "");
            }
            #endregion
            
        }
        #endregion
    }
}

