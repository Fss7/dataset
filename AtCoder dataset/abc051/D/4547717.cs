using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_D
{
    class D051
    {
        public static void Main(string[] args)
        {

            int[] h = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int N = h[0], M = h[1];
            ContestLibraryD51.Graph g = new ContestLibraryD51.Graph(N, useMatrix: true);

            for (int i = 0; i < M; i++)
            {
                int[] p = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                int a = p[0], b = p[1], c = p[2];
                if (a > b)
                {
                    int z = a; a = b; b = z;
                }
                g.AddEdge(a, b, c);
            }
            int[,] pm;
            var v = g.WarshallFloyd(out pm);

            var edges = g.Edges.Select(x => x.VertexL.Id + "-" + x.VertexR.Id);
            HashSet<string> set = new HashSet<string>(edges);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (pm[i, j] <= 0) continue;
                    int edgeL = Math.Min(j + 1, pm[i, j]);
                    int edgeR = Math.Max(j + 1, pm[i, j]);
                    string edge = edgeL + "-" + edgeR;
                    set.Remove(edge);
                }
            }
            Console.WriteLine(set.Count);
        }
    }

    namespace ContestLibraryD51
    {

        class Graph
        {
            public bool UseMatrix { get; set; }
            private bool idZeroStart;
            public List<Vertex> Vertices { get; }
            public List<Edge> Edges { get; }
            public double[,] Matrix { get; private set; }
            public bool IsDirectedGraph { get; }

            public Graph(int N, bool isDirectedGraph = false, bool idZeroStart = false, bool useMatrix = false)
            {
                IsDirectedGraph = isDirectedGraph;
                this.idZeroStart = idZeroStart;
                Vertices = new List<Vertex>();
                Edges = new List<Edge>();

                if (useMatrix)
                {
                    Matrix = new double[N, N];
                    for(int i = 0; i < N; i++)
                    {
                        for(int j = 0; j < N; j++)
                        {
                            Matrix[i, j] = double.PositiveInfinity;
                        }
                    }
                }

                for (int i = 0; i < N; i++)
                {
                    int id = idZeroStart ? i : i + 1;
                    Vertex n = new Vertex(id);
                    Vertices.Add(n);
                }
            }

            //??????????????
            public void SetAdjancencyMatrix(double[,] matrix)
            {
                Matrix = matrix;

                if (matrix.GetLength(0) != Vertices.Count || matrix.GetLength(1) != Vertices.Count)
                {
                    throw new Exception("Invalid Matrix Size");
                }

                for (int i = 0; i < Vertices.Count; i++)
                {
                    Vertex vertexL = Vertices[i];
                    for (int j = 0; j < Vertices.Count; j++)
                    {
                        if (i > j && !IsDirectedGraph) continue;
                        if (matrix[i, j] != double.PositiveInfinity)
                        {
                            Vertex vertexR = Vertices[j];
                            Edge edge = new Edge(vertexL, vertexR, matrix[i, j], IsDirectedGraph);
                            Edges.Add(edge);
                        }
                    }
                }

            }


            //???????????????
            public void AddAdjacencyList(int idVertex, Dictionary<int, double> adjDictionary)
            {
                int indexL = idZeroStart ? idVertex : idVertex - 1;
                Vertex vertexL = Vertices[indexL];

                foreach (var v in adjDictionary)
                {
                    int idR = v.Key;
                    double weight = v.Value;
                    int indexR = idZeroStart ? idR : idR - 1;
                    Vertex vertexR = Vertices[indexR];
                    Edge edge = new Edge(vertexL, vertexR, weight, IsDirectedGraph);
                    Edges.Add(edge);
                    if (Matrix != null)
                    {
                        Matrix[indexL, indexR] = weight;
                        if (!IsDirectedGraph) Matrix[indexR, indexL] = weight;
                    }
                }
            }
            public void AddAdjacencyList(int idVertex, List<int> adjList)
            {
                Dictionary<int, double> dic = new Dictionary<int, double>();
                foreach (int x in adjList)
                {
                    dic.Add(x, 1);
                }
                AddAdjacencyList(idVertex, dic);
            }

            //???????????
            public void AddEdge(int idL, int idR, int weight = 1)
            {
                int indexL = idZeroStart ? idL : idL - 1;
                int indexR = idZeroStart ? idR : idR - 1;

                Vertex vertexL = Vertices[indexL];
                Vertex vertexR = Vertices[indexR];
                Edge edge = new Edge(vertexL, vertexR, weight, IsDirectedGraph);
                Edges.Add(edge);
                if (Matrix != null)
                {
                    Matrix[indexL, indexR] = weight;
                    if (!IsDirectedGraph) Matrix[indexR, indexL] = weight;
                }
            }


            //???????????????????
            //???????????????????????Dictionary???
            public Dictionary<int, int> BreadthFirstSearch(int idS)
            {
                Dictionary<int, int> distances = new Dictionary<int, int>();
                distances.Add(idS, 0);
                int index = idZeroStart ? idS : idS - 1;

                List<Vertex> nodes = new List<Vertex>();
                Vertex nodeStart = Vertices[index];
                nodeStart.Visited = true;
                nodes.Add(nodeStart);
                int depth = 1;
                while (nodes.Count > 0)
                {
                    List<Vertex> nextNodes = new List<Vertex>();
                    foreach (Vertex node in nodes)
                    {
                        foreach (Vertex cn in node.ConnectedVertices)
                        {
                            if (!cn.Visited)
                            {
                                nextNodes.Add(cn);
                                cn.Visited = true;
                                distances.Add(cn.Id, depth);
                            }
                        }
                    }
                    nodes = nextNodes;
                    depth++;
                }
                return distances;
            }

            //??????????????
            //TimeFound(????)?TimeProcessed(??????)???
            public int DepthFirstSearch(int idS, int connectGraphNo = 1, int time = 0)
            {
                Stack<Vertex> stack = new Stack<Vertex>();
                int index = idZeroStart ? idS : idS - 1;
                List<Vertex> nodes = new List<Vertex>();
                Vertex nodeStart = Vertices[index];
                nodeStart.Visited = true;

                stack.Push(nodeStart);
                nodeStart.TimeVisited = time;
                nodeStart.ConnectGraphNo = connectGraphNo;

                while (stack.Count > 0)
                {
                    Vertex v = stack.Peek();

                    if (v.IndexNextSearch >= v.ConnectedVertices.Count)
                    {
                        time++;
                        v.TimeProcessed = time;
                        stack.Pop();
                    }
                    else
                    {
                        Vertex vn = v.ConnectedVertices[v.IndexNextSearch];
                        if (!vn.Visited)
                        {
                            time++;
                            stack.Push(vn);
                            vn.Visited = true;
                            vn.TimeVisited = time;
                            vn.ConnectGraphNo = connectGraphNo;
                        }
                        v.IndexNextSearch++;
                    }
                }
                return time;
            }

            //??????
            public void DFS()
            {
                int time = 1;
                int connectNo = 1;
                int index = 0;
                while (index < Vertices.Count)
                {
                    int id = idZeroStart ? index : index + 1;
                    time = DepthFirstSearch(id, connectNo, time);

                    while (index < Vertices.Count && Vertices[index].Visited) index++;
                    connectNo++;
                    time++;
                }
            }


            //Prim???????????????????(PriorityQueue??????)
            //????????O(m log(m))?????????????????????
            public double MinimumSpanningTree()
            {
                //?????????????
                Vertex v0 = Vertices[0];

                bool[] includedVertex = new bool[Vertices.Count + 1];
                double sumWeight = 0;

                //??????????Edge
                List<Edge> mstEdges = new List<Edge>();
                //???????????Edge?????????
                PriorityQueue<Edge> pq = new PriorityQueue<Edge>();

                includedVertex[v0.Id] = true;
                foreach (Edge en in v0.ConnectedEdges)
                {
                    pq.Enqueue(en, -en.Weight);
                }

                int counter = 1;
                while (counter < Vertices.Count)
                {
                    Edge edge = pq.Dequeue();
                    Vertex v;
                    //????????????????Edge?????????????????)
                    if (includedVertex[edge.VertexL.Id] && includedVertex[edge.VertexR.Id]) continue;
                    else if (includedVertex[edge.VertexL.Id]) v = edge.VertexR;
                    else v = edge.VertexL;
                    mstEdges.Add(edge);
                    sumWeight += edge.Weight;
                    includedVertex[v.Id] = true;

                    //???????????????Edge???????
                    foreach (Edge e1 in v.ConnectedEdges)
                    {
                        if (includedVertex[e1.VertexL.Id] && includedVertex[e1.VertexR.Id]) continue;
                        pq.Enqueue(e1, -e1.Weight);
                    }

                    counter++;
                }

                return sumWeight;
            }

            public double[] Dijkstra(int idS)
            {
                double[] distances = Enumerable.Repeat(double.PositiveInfinity, Vertices.Count + 1).ToArray();
                int index = idZeroStart ? idS : idS - 1;
                distances[idS] = 0;

                List<Vertex> confirmedVertices = new List<Vertex>();
                Vertex v0 = Vertices[index];

                PriorityQueue<Vertex> pq = new PriorityQueue<Vertex>();
                pq.Enqueue(v0, 0);

                while (pq.Count > 0)
                {
                    Vertex v = pq.Dequeue();
                    foreach (Edge e in v.ConnectedEdges)
                    {
                        Vertex vn = e.VertexL == v ? e.VertexR : e.VertexL;
                        double distanceNew = distances[v.Id] + e.Weight;
                        if (distanceNew < distances[vn.Id])
                        {
                            distances[vn.Id] = distanceNew;
                            //distance??????????????
                            //???Vertex????????????????
                            //???????????????????????????
                            pq.Enqueue(vn, -distances[vn.Id]);
                        }
                    }
                }


                return distances;
            }

            //??????????????????? ?matrix
            public double[,] WarshallFloyd(out int[,] predecessorMatrix)
            {
                int N = Vertices.Count;
                double[,] d = (double[,])Matrix.Clone();

                int[,] p = new int[N, N]; //?????
                for(int i = 0; i < N; i++)
                {
                    for(int j = 0; j < N; j++)
                    {
                        if (d[i, j] != double.PositiveInfinity && i != j)
                        {
                            p[i, j] = i; if (!idZeroStart) p[i, j]++;
                        }
                    }
                }

                for (int k = 0; k < N; k++)
                {
                    double[,] dn = new double[N, N];
                    int[,] pn = new int[N, N];
                    for(int i = 0; i < N; i++)
                    {
                        for(int j = 0; j < N; j++)
                        {
                            if (i == j) continue;
                            //k??????????????
                            if(d[i, j]>d[i, k] + d[k, j])
                            {
                                dn[i, j] = d[i, k] + d[k, j];
                                pn[i, j] = p[k, j];
                            }
                            else
                            {
                                dn[i, j] = d[i, j];
                                pn[i, j] = p[i, j];
                            }
                        }
                    }
                    d = dn; p = pn;
                }
                predecessorMatrix = p;
                return d;
            }

        }

        class Vertex
        {
            public int Id { get; }
            public List<Edge> ConnectedEdges { get; private set; }
            public List<Vertex> ConnectedVertices { get; private set; }
            public bool Visited { get; set; }
            public int TimeVisited { get; set; }
            public int TimeProcessed { get; set; }
            public int IndexNextSearch { get; set; } //??????Vertex??
            public int ConnectGraphNo { get; set; } //?????????????


            public Vertex(int id)
            {
                Id = id;
                ConnectedEdges = new List<Edge>();
                ConnectedVertices = new List<Vertex>();
            }


        }

        class Edge
        {
            public Vertex VertexL { get; }
            public Vertex VertexR { get; }
            public double Weight { get; }

            public Edge(Vertex vertexL, Vertex vertexR, double weight, bool isDirected)
            {
                VertexL = vertexL;
                VertexR = vertexR;
                vertexL.ConnectedEdges.Add(this);
                vertexL.ConnectedVertices.Add(vertexR);
                if (!isDirected)
                {
                    vertexR.ConnectedEdges.Add(this);
                    vertexR.ConnectedVertices.Add(vertexL);
                }
                Weight = weight;
            }
        }

        //???????????????)
        class PriorityQueue<T>
        {
            private List<HeapNode> heap = new List<HeapNode>();

            public int Count
            {
                get
                {
                    return heap.Count;
                }
            }

            public void Enqueue(T item, double priority)
            {
                HeapNode node = new HeapNode(item, priority);
                heap.Add(node);

                int index = heap.Count - 1;

                while (index > 0)
                {
                    int indexParent = (index - 1) / 2;
                    HeapNode parent = heap[indexParent];
                    if (priority > parent.Priority)
                    {
                        Swap(index, indexParent);
                        index = indexParent;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            public T Dequeue()
            {
                if (heap.Count == 0)
                {
                    throw new Exception("No item in priorityQueue");
                }

                T item = heap[0].Node;
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                if (heap.Count > 0)
                {
                    HeapNode node = heap[0];
                    int index = 0;
                    while (true)
                    {
                        int indexL = 2 * index + 1;
                        int indexR = 2 * index + 2;
                        if (indexL >= heap.Count) //???(Leaf)
                        {
                            break;
                        }
                        else //????
                        {
                            HeapNode childBetter = heap[indexL];
                            int indexBetter = indexL;
                            if (indexR < heap.Count && heap[indexL].Priority < heap[indexR].Priority)
                            {
                                childBetter = heap[indexR];
                                indexBetter = indexR;
                            }

                            if (node.Priority < childBetter.Priority)
                            {
                                Swap(index, indexBetter);
                                //node = childBetter; ?????????????????????
                                index = indexBetter;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                return item;
            }

            public T Peek()
            {
                if (heap.Count == 0)
                {
                    throw new Exception("No item in priorityQueue");
                }
                return heap[0].Node;
            }

            private void Swap(int i, int j)
            {
                HeapNode hn = heap[i];
                heap[i] = heap[j];
                heap[j] = hn;
            }


            class HeapNode
            {
                public T Node { get; }
                public double Priority { get; }
                public HeapNode(T item, double priority)
                {
                    Node = item;
                    Priority = priority;
                }
            }

        }


    }

}