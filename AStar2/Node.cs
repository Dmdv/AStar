using System;

namespace AstarCore.AStar2
{
    public abstract partial class AStar<TKey, TValue> where TValue : IComparable<TValue>
    {
        public struct Node : IComparable<Node>
        {
            public TKey position;
            public TValue cost;

            public Node(TKey position, TValue cost)
            {
                this.position = position;
                this.cost = cost;
            }

            public int CompareTo(Node other) => cost.CompareTo(other.cost);
        }
    }
}
