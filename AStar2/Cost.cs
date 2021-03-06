﻿using System;

namespace AstarCore.AStar2
{
    public struct Cost : IComparable<Cost>
    {
        public readonly int parentIndex;
        public readonly int distanceTravelled; /*g(x)*/
        public readonly int totalCost; /*f(x)*/

        public Cost(int parentIndex, int distanceTravelled, int totalCost)
        {
            this.parentIndex = parentIndex;
            this.distanceTravelled = distanceTravelled;
            this.totalCost = totalCost;
        }
        public int CompareTo(Cost other) { return this.totalCost.CompareTo(other.totalCost); }
    }
}
