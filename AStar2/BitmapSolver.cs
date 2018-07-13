using System;
using System.Collections.Generic;
using System.Drawing;

namespace AstarCore.AStar2
{
    public class BitmapSolver : AStar<Point, Cost>
    {
        private const int baseOrthogonalCost = 5;
        private const int baseDiagonalCost = 7;

        public Node? Solution { get; set; }

       // private Bitmap _bitmap;
        private Point _destination;
        private Dictionary<Point, Cost> closedList;

        /*public void Graph(Bitmap bitmap, PriorityQueue<Node> openList, Dictionary<Point, Cost> closedList)
        {
            this._bitmap = bitmap;
            this.closedList = closedList;
            _destination = new Point(bitmap.Width - 1, bitmap.Height - 1);
            Graph(new Node(Point.Empty, new Cost(-1, 0, GetDistance(Point.Empty, _destination))), openList, closedList);
        }*/

        public int ToIndex(Point position) => position.Y * _bitmap.Width + position.X;

        public Point ToPosition(int index) => new Point(index % _bitmap.Width, index / _bitmap.Width);

        protected override void AddNeighbours(Node node, PriorityQueue<Node> openList)
        {
            int parentIndex = ToIndex(node.position);
            for (int x = -1; x <= 1; x++)
                for (int y = -1; y <= 1; y++)
                    if (!(x == 0 && y == 0))
                    {
                        Point newPos = new Point(node.position.X + x, node.position.Y + y);

                        if (newPos.X >= 0 && newPos.X < _bitmap.Width && newPos.Y >= 0 && newPos.Y < _bitmap.Height)
                        {
                            if (_bitmap.GetPixel(newPos.X, newPos.Y).R != 0)
                            {
                                int distanceCost = node.cost.distanceTravelled + ((x == 0 || y == 0) ? baseOrthogonalCost : baseDiagonalCost);
                                openList.Insert(new Node(newPos, new Cost(parentIndex, distanceCost, distanceCost + GetDistance(newPos, _destination))));
                            }
                        }
                    }
        }

        private static int GetDistance(Point source, Point destination)
        {
            int dx = Math.Abs(destination.X - source.X);
            int dy = Math.Abs(destination.Y - source.Y);
            int diagonal = Math.Min(dx, dy);
            int orthogonal = dx + dy - 2 * diagonal;
            return diagonal * baseDiagonalCost + orthogonal * baseOrthogonalCost;
        }

        protected override bool IsDestination(Point position)
        {
            bool isSolved = position == _destination;

            if (isSolved)
            {
                _solution = new Node(position, closedList[position]);
            }

            return isSolved;
        }
    }
}
