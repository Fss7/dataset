// ABC 070 D Transit Tree Path

//#define TEST

using System;
using System.Collections.Generic;
using System.Linq;
using MS.Internal; //PriorityQueue????

class Program
{
    static int N;
    static Tree t;
    static int Q;
    static int K;

    static void Main()
    {
        /* ??????? */
        N = int.Parse(Console.ReadLine());
        t = new Tree(N);
        int[] input;
        for (int i = 0; i < N - 1; i++)
        {
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int a = input[0] - 1;
            int b = input[1] - 1;
            int c = input[2];
            t.SetEdge(a, b, c);
        }
        input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Q = input[0];
        K = input[1] - 1;

        /* Dijkstra???????K???????????????? */
        long[] dis = t.Dijkstra(K);

#if TEST
        foreach (var i in dis) Console.WriteLine(i);
#endif

        /* ???????????? */
        for (int i = 0; i < Q; i++)
        {
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int x = input[0] - 1;
            int y = input[1] - 1;
            Console.WriteLine(dis[x] + dis[y]);
        }
    }
}

struct Node
{
    public int n; //???number
    public List<int> next; //??????
    public List<int> length; //???????????

    public Node(int n) //???????
    {
        this.n = n;
        next = new List<int>();
        length = new List<int>();
    }
}

struct Tree
{
    public int n; //???
    public Node[] nodes; //??

    public Tree(int n) //???????
    {
        this.n = n;
        nodes = new Node[n];
        for (int i = 0; i < n; i++)
            nodes[i] = new Node(i);
    }

    public void SetEdge(int s, int g, int l) //??s,g????l?????
    {
        nodes[s].next.Add(g);
        nodes[s].length.Add(l);
        nodes[g].next.Add(s);
        nodes[g].length.Add(l);
    }

    public long[] Dijkstra(int k) //??k??????????????
    {
        /* ??? */
        Pair[] p = new Pair[n];
        for (int i = 0; i < n; i++)
            p[i] = new Pair(i, (long)1e15);
        p[k].dis = 0;
        PriorityQueue<Pair> Q = new PriorityQueue<Pair>(0, p[0]);
        foreach (var i in p) Q.Push(i);
        /* ??? */
        while (Q.Count > 0)
        {
            var up = Q.Top;
            Q.Pop();
            int u = up.n;
            for (int i = 0; i < nodes[u].next.Count; i++)
            {
                var v = nodes[u].next[i];
                var l = nodes[u].length[i];
                if (p[v].dis > p[u].dis + l)
                {
                    p[v].dis = p[u].dis + l;
                    Q.Push(p[v]);
                }
            }
        }
        long[] dis = new long[n];
        for (int i = 0; i < n; i++)
            dis[i] = p[i].dis;
        return dis;
    }
}

struct Pair : IComparer<Pair>
{
    public int n; //????
    public long dis; //??

    public Pair(int n, long dis) //???????
    {
        this.n = n;
        this.dis = dis;
    }

    public int Compare(Pair x, Pair y) //Pair???
    {
        if (x.dis == y.dis) return 0;
        return x.dis - y.dis > 0 ? 1 : -1;
    }
}

namespace MS.Internal
{
    using System.Diagnostics;
    using System.Collections.Generic;

    /// <summary>
    /// PriorityQueue provides a stack-like interface, except that objects
    /// "pushed" in arbitrary order are "popped" in order of priority, i.e., 
    /// from least to greatest as defined by the specified comparer.
    /// </summary>
    /// <remarks>
    /// Push and Pop are each O(log N). Pushing N objects and them popping
    /// them all is equivalent to performing a heap sort and is O(N log N).
    /// </remarks>
    internal class PriorityQueue<T>
    {
        //
        // The _heap array represents a binary tree with the "shape" property.
        // If we number the nodes of a binary tree from left-to-right and top-
        // to-bottom as shown,
        //
        //             0
        //           /   \
        //          /     \
        //         1       2
        //       /  \     / \
        //      3    4   5   6
        //     /\    /
        //    7  8  9
        //
        // The shape property means that there are no gaps in the sequence of
        // numbered nodes, i.e., for all N > 0, if node N exists then node N-1
        // also exists. For example, the next node added to the above tree would
        // be node 10, the right child of node 4.
        //
        // Because of this constraint, we can easily represent the "tree" as an
        // array, where node number == array index, and parent/child relationships
        // can be calculated instead of maintained explicitly. For example, for
        // any node N > 0, the parent of N is at array index (N - 1) / 2.
        //
        // In addition to the above, the first _count members of the _heap array
        // compose a "heap", meaning each child node is greater than or equal to
        // its parent node; thus, the root node is always the minimum (i.e., the
        // best match for the specified style, weight, and stretch) of the nodes 
        // in the heap.
        //
        // Initially _count < 0, which means we have not yet constructed the heap.
        // On the first call to MoveNext, we construct the heap by "pushing" all
        // the nodes into it. Each successive call "pops" a node off the heap
        // until the heap is empty (_count == 0), at which time we've reached the
        // end of the sequence.
        //

        #region constructors

        internal PriorityQueue(int capacity, IComparer<T> comparer)
        {
            _heap = new T[capacity > 0 ? capacity : DefaultCapacity];
            _count = 0;
            _comparer = comparer;
        }

        #endregion

        #region internal members

        /// <summary>
        /// Gets the number of items in the priority queue.
        /// </summary>
        internal int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Gets the first or topmost object in the priority queue, which is the
        /// object with the minimum value.
        /// </summary>
        internal T Top
        {
            get
            {
                Debug.Assert(_count > 0);
                return _heap[0];
            }
        }

        /// <summary>
        /// Adds an object to the priority queue.
        /// </summary>
        internal void Push(T value)
        {
            // Increase the size of the array if necessary.
            if (_count == _heap.Length)
            {
                T[] temp = new T[_count * 2];
                for (int i = 0; i < _count; ++i)
                {
                    temp[i] = _heap[i];
                }
                _heap = temp;
            }

            // Loop invariant:
            //
            //  1.  index is a gap where we might insert the new node; initially
            //      it's the end of the array (bottom-right of the logical tree).
            //
            int index = _count;
            while (index > 0)
            {
                int parentIndex = HeapParent(index);
                if (_comparer.Compare(value, _heap[parentIndex]) < 0)
                {
                    // value is a better match than the parent node so exchange
                    // places to preserve the "heap" property.
                    _heap[index] = _heap[parentIndex];
                    index = parentIndex;
                }
                else
                {
                    // we can insert here.
                    break;
                }
            }

            _heap[index] = value;
            _count++;
        }

        /// <summary>
        /// Removes the first node (i.e., the logical root) from the heap.
        /// </summary>
        internal void Pop()
        {
            Debug.Assert(_count != 0);

            if (_count > 1)
            {
                // Loop invariants:
                //
                //  1.  parent is the index of a gap in the logical tree
                //  2.  leftChild is
                //      (a) the index of parent's left child if it has one, or
                //      (b) a value >= _count if parent is a leaf node
                //
                int parent = 0;
                int leftChild = HeapLeftChild(parent);

                while (leftChild < _count)
                {
                    int rightChild = HeapRightFromLeft(leftChild);
                    int bestChild =
                        (rightChild < _count && _comparer.Compare(_heap[rightChild], _heap[leftChild]) < 0) ?
                        rightChild : leftChild;

                    // Promote bestChild to fill the gap left by parent.
                    _heap[parent] = _heap[bestChild];

                    // Restore invariants, i.e., let parent point to the gap.
                    parent = bestChild;
                    leftChild = HeapLeftChild(parent);
                }

                // Fill the last gap by moving the last (i.e., bottom-rightmost) node.
                _heap[parent] = _heap[_count - 1];
            }

            _count--;
        }

        #endregion

        #region private members

        /// <summary>
        /// Calculate the parent node index given a child node's index, taking advantage
        /// of the "shape" property.
        /// </summary>
        private static int HeapParent(int i)
        {
            return (i - 1) / 2;
        }

        /// <summary>
        /// Calculate the left child's index given the parent's index, taking advantage of
        /// the "shape" property. If there is no left child, the return value is >= _count.
        /// </summary>
        private static int HeapLeftChild(int i)
        {
            return (i * 2) + 1;
        }

        /// <summary>
        /// Calculate the right child's index from the left child's index, taking advantage
        /// of the "shape" property (i.e., sibling nodes are always adjacent). If there is
        /// no right child, the return value >= _count.
        /// </summary>
        private static int HeapRightFromLeft(int i)
        {
            return i + 1;
        }

        private T[] _heap;
        private int _count;
        private IComparer<T> _comparer;
        private const int DefaultCapacity = 6;

        #endregion
    }
}