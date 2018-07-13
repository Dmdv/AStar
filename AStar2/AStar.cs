using System;
using System.Collections.Generic;

namespace AstarCore.AStar2
{
    public abstract partial class AStar<TKey, TValue> where TValue : IComparable<TValue>
    {
        protected void Graph(Node start, PriorityQueue<Node> openList, Dictionary<TKey, TValue> closedList)
        {
            openList.Insert(start);

            while (openList.Count > 0)
            {
                Node node = openList.RemoveRoot();

                if (closedList.ContainsKey(node.position)) 
                { 
                    continue;
                }

                closedList.Add(node.position, node.cost);

                if (IsDestination(node.position)) 
                { 
                    return; 
                }

                AddNeighbours(node, openList);
            }
        }

        protected abstract void AddNeighbours(Node node, PriorityQueue<Node> openList);

        protected abstract bool IsDestination(TKey position);
    }
}
