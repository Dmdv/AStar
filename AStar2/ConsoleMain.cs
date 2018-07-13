using System.Collections.Generic;
using System.Drawing;

namespace AstarCore.AStar2
{
    public class ConsoleMain
    {
        readonly PriorityQueue<AStar<Point, Cost>.Node> openList = new PriorityQueue<AStar<Point, Cost>.Node>();

        readonly Dictionary<Point, Cost> closedList = new Dictionary<Point, Cost>();

        static void Main(string[] args) => new ConsoleMain().Run(args);

        public void Run(string[] files)
        {
            BitmapSolver bitmapSolver = new BitmapSolver();

            for (int x = 0; x < files.Length; x++)
            {
                using (Bitmap bitmap = (Bitmap)Bitmap.FromFile(files[x]))
                {
                    bitmapSolver.Graph(bitmap, openList, closedList);
                    if (!bitmapSolver.Solution.HasValue)
                    {
                        continue;
                    }

                    int itr = 0;

                    foreach (KeyValuePair<Point, Cost> pair in closedList)
                    {
                        Point pt = pair.Key;
                        int val = (byte.MaxValue * (itr++)) / closedList.Count;
                        bitmap.SetPixel(pt.X, pt.Y, Color.FromArgb(byte.MaxValue - val, 0, val));
                    }

                    Point pos = bitmapSolver.Solution.Value.position;
                    Cost cost = bitmapSolver.Solution.Value.cost;

                    bitmap.SetPixel(pos.X, pos.Y, Color.Green);

                    do
                    {
                        pos = bitmapSolver.ToPosition(cost.parentIndex);
                        cost = closedList[pos];
                        bitmap.SetPixel(pos.X, pos.Y, Color.Green);
                    }
                    while (cost.parentIndex >= 0);

                    bitmap.Save("Output" + (x + 1) + ".png");
                    bitmapSolver.Solution = null;
                    openList.Clear();
                    closedList.Clear();
                }
            }
        }
    }
}
