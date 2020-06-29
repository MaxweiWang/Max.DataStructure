using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.StructureFile
{
    /// <summary>
    /// 
    /// </summary>
    public class GraphDemo
    {
        public static void Show()
        {
            {
                ////构建图基础测试
                //Graph graph = new Graph(4);
                //graph.AddVertex("A");
                //graph.AddVertex("B");
                //graph.AddVertex("C");
                //graph.AddVertex("D");

                //graph.AddEdge(0, 1);
                //graph.AddEdge(1, 0);
                //graph.AddEdge(1, 3);
                //graph.AddEdge(3, 1);

                //graph.Show();
            }
            {
                //深度优先-广度优先
                Graph aGraph = new Graph(13);
                aGraph.AddVertex("A");
                aGraph.AddVertex("B");
                aGraph.AddVertex("C");
                aGraph.AddVertex("D");
                aGraph.AddVertex("E");
                aGraph.AddVertex("F");
                aGraph.AddVertex("G");
                aGraph.AddVertex("H");
                aGraph.AddVertex("I");
                aGraph.AddVertex("J");
                aGraph.AddVertex("K");
                aGraph.AddVertex("L");
                aGraph.AddVertex("M");
                aGraph.AddEdge(0, 1);
                aGraph.AddEdge(1, 2);
                aGraph.AddEdge(2, 3);
                aGraph.AddEdge(0, 4);
                aGraph.AddEdge(4, 5);
                aGraph.AddEdge(5, 6);
                aGraph.AddEdge(0, 7);
                aGraph.AddEdge(7, 8);
                aGraph.AddEdge(8, 9);
                aGraph.AddEdge(0, 10);
                aGraph.AddEdge(10, 11);
                aGraph.AddEdge(11, 12);
                aGraph.DepthFirstSearch();
                Console.WriteLine();
                aGraph.BreadthFirstSearch();
                Console.WriteLine();
                Console.WriteLine("Finished.");
            }
            {
                //最小生成树
                Graph aGraph = new Graph(7);
                aGraph.AddVertex("A");
                aGraph.AddVertex("B");
                aGraph.AddVertex("C");
                aGraph.AddVertex("D");
                aGraph.AddVertex("E");
                aGraph.AddVertex("F");
                aGraph.AddVertex("G");
                aGraph.AddEdge(0, 1);
                aGraph.AddEdge(0, 2);
                aGraph.AddEdge(0, 3);
                aGraph.AddEdge(1, 2);
                aGraph.AddEdge(1, 3);
                aGraph.AddEdge(1, 4);
                aGraph.AddEdge(2, 3);
                aGraph.AddEdge(2, 5);
                aGraph.AddEdge(3, 5);
                aGraph.AddEdge(3, 4);
                aGraph.AddEdge(3, 6);
                aGraph.AddEdge(4, 5);
                aGraph.AddEdge(4, 6);
                aGraph.AddEdge(5, 6);
                Console.WriteLine();
                aGraph.MinimumSpanningTree();
            }
            {
                //有向图+top排序
                Graph theGraph = new Graph(4);
                theGraph.AddVertex("A");
                theGraph.AddVertex("B");
                theGraph.AddVertex("C");
                theGraph.AddVertex("D");
                theGraph.AddEdge(0, 1);
                theGraph.AddEdge(1, 2);
                theGraph.AddEdge(2, 3);
                theGraph.TopologicalSort();
                Console.WriteLine();
                Console.WriteLine("Finished.");
            }
            {
                //带前奏顺序要求
                Graph theGraph = new Graph(6);
                theGraph.AddVertex("CS1");
                theGraph.AddVertex("CS2");
                theGraph.AddVertex("DS");
                theGraph.AddVertex("OS");
                theGraph.AddVertex("ALG");
                theGraph.AddVertex("AL");
                theGraph.AddEdge(0, 1);
                theGraph.AddEdge(1, 2);
                theGraph.AddEdge(1, 5);
                theGraph.AddEdge(2, 3);
                theGraph.AddEdge(2, 4);
                theGraph.TopologicalSort();
                Console.WriteLine();
                Console.WriteLine("Finished.");
            }
        }


        #region CustomGraph
        /// <summary>
        /// 顶点
        /// </summary>
        public class Vertex
        {
            public bool IsVisited;
            public string Label;
            public Vertex(string label)
            {
                this.Label = label;
                this.IsVisited = false;
            }
        }
        /// <summary>
        /// 图
        /// </summary>
        public class Graph
        {
            #region 初始化
            private int _NumVertices = 6;
            private Vertex[] _Vertices;
            private int[,] _AdjMatrix;
            int numVerts;
            public Graph(int numVertices)
            {
                _NumVertices = numVertices;
                _Vertices = new Vertex[_NumVertices];
                _AdjMatrix = new int[_NumVertices, _NumVertices];
                numVerts = 0;
                for (int j = 0; j <= _NumVertices - 1; j++)
                    for (int k = 0; k <= _NumVertices - 1; k++)
                        _AdjMatrix[j, k] = 0;
            }
            public void AddVertex(string label)
            {
                _Vertices[numVerts] = new Vertex(label);
                numVerts++;
            }
            public void AddEdge(int start, int end)
            {
                _AdjMatrix[start, end] = 1;
            }
            #endregion

            #region 展示
            private void ShowVertex(int v)
            {
                Console.Write(_Vertices[v].Label + " ");
            }
            public void Show()
            {
                foreach (var item in this._Vertices)
                {
                    Console.WriteLine(item.Label);
                }
                for (int j = 0; j <= _NumVertices - 1; j++)
                {
                    for (int k = 0; k <= _NumVertices - 1; k++)
                    {
                        Console.Write(_AdjMatrix[j, k] + " ");
                    }
                    Console.WriteLine();
                }
            }
            /// <summary>
            /// 拓扑排序
            /// </summary>
            public void TopologicalSort()
            {
                Stack<string> gStack = new Stack<string>();
                while (_NumVertices > 0)
                {
                    int currVertex = NoSuccessors();
                    if (currVertex == -1)
                    {
                        Console.WriteLine("该图中有环");
                        return;
                    }
                    gStack.Push(_Vertices[currVertex].Label);
                    DelVertex(currVertex);
                }
                Console.Write("拓扑排序后: ");
                while (gStack.Count > 0)
                    Console.Write(gStack.Pop() + " ");
            }
            #endregion

            #region 管理
            /// <summary>
            /// 检测是否有环
            /// 找出没有前奏依赖的row
            /// -1就是没找到
            /// </summary>
            /// <returns></returns>
            private int NoSuccessors()
            {
                bool isEdge;
                for (int row = 0; row <= _NumVertices - 1; row++)
                {
                    isEdge = false;
                    for (int col = 0; col <= _NumVertices - 1; col++)
                    {
                        if (_AdjMatrix[row, col] > 0)
                        {
                            isEdge = true;
                            break;
                        }
                    }
                    if (!isEdge)
                        return row;
                }
                return -1;
            }
            /// <summary>
            /// 删除节点后移动
            /// 删除你指向别人
            /// </summary>
            /// <param name="vert"></param>
            private void DelVertex(int vert)
            {
                if (vert != _NumVertices - 1)
                {
                    for (int j = vert; j < _NumVertices - 1; j++)
                        _Vertices[j] = _Vertices[j + 1];
                    for (int row = vert; row < _NumVertices - 1; row++)
                        MoveRow(row, _NumVertices);
                    for (int col = vert; col < _NumVertices - 1; col++)
                        MoveCol(col, _NumVertices);
                }
                _NumVertices--;
            }
            private void MoveRow(int row, int length)
            {
                for (int col = 0; col <= length - 1; col++)
                    _AdjMatrix[row, col] = _AdjMatrix[row + 1, col];
            }
            private void MoveCol(int col, int length)
            {
                for (int row = 0; row <= length - 1; row++)
                    _AdjMatrix[row, col] = _AdjMatrix[row, col + 1];
            }
            #endregion

            #region 深度优先&广度优先
            /// <summary>
            /// 找到相邻未被访问的节点
            /// </summary>
            /// <param name="v"></param>
            /// <returns></returns>
            private int GetAdjUnvisitedVertex(int v)
            {
                for (int j = 0; j <= _NumVertices - 1; j++)
                    if ((_AdjMatrix[v, j] == 1) && (_Vertices[j].IsVisited == false))
                        return j;
                return -1;
            }
            public void DepthFirstSearch()
            {
                Stack<int> gStack = new Stack<int>();
                _Vertices[0].IsVisited = true;
                ShowVertex(0);
                gStack.Push(0);
                int v;
                while (gStack.Count > 0)
                {
                    v = GetAdjUnvisitedVertex(gStack.Peek());
                    if (v == -1)
                        gStack.Pop();
                    else
                    {
                        _Vertices[v].IsVisited = true;
                        ShowVertex(v);
                        gStack.Push(v);
                    }
                }
                for (int j = 0; j <= _NumVertices - 1; j++)
                    _Vertices[j].IsVisited = false;
            }
            public void BreadthFirstSearch()
            {
                Queue<int> gQueue = new Queue<int>();
                _Vertices[0].IsVisited = true;
                ShowVertex(0);
                gQueue.Enqueue(0);
                int vert1, vert2;
                while (gQueue.Count > 0)
                {
                    vert1 = gQueue.Dequeue();
                    vert2 = GetAdjUnvisitedVertex(vert1);
                    while (vert2 != -1)
                    {
                        _Vertices[vert2].IsVisited = true;
                        ShowVertex(vert2);
                        gQueue.Enqueue(vert2);
                        vert2 = GetAdjUnvisitedVertex(vert1);
                    }
                }
                for (int i = 0; i <= _NumVertices - 1; i++)
                    _Vertices[i].IsVisited = false;
            }
            #endregion

            #region 最小生成树
            public void MinimumSpanningTree()
            {
                Stack<int> gStack = new Stack<int>();
                _Vertices[0].IsVisited = true;
                gStack.Push(0);
                int currVertex, ver;
                while (gStack.Count > 0)
                {
                    currVertex = gStack.Peek();
                    ver = GetAdjUnvisitedVertex(currVertex);
                    if (ver == -1)
                        gStack.Pop();
                    else
                    {
                        _Vertices[ver].IsVisited = true;
                        gStack.Push(ver);
                        ShowVertex(currVertex);
                        ShowVertex(ver);
                        Console.Write(" ");
                    }
                }
                for (int j = 0; j <= _NumVertices - 1; j++)
                    _Vertices[j].IsVisited = false;
            }
            #endregion
        }
        #endregion
    }
}
