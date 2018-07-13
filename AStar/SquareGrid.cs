using System.Collections.Generic;

public class SquareGrid : IWeightedGraph
{
    public static readonly Location[] Directions = new[]
    {
        new Location(1, 0),
        new Location(0, -1),
        new Location(-1, 0),
        new Location(0, 1)
    };

    private int height;

    private int width;

    private HashSet<Location> walls = new HashSet<Location>();

    private HashSet<Location> forests = new HashSet<Location>();

    public HashSet<Location> Walls { get => walls; set => walls = value; }
    public HashSet<Location> Forests { get => forests; set => forests = value; }

    public SquareGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public bool InBounds(Location id)
    {
        return 0 <= id.x && id.x < width && 0 <= id.y && id.y < height;
    }

    public bool Passable(Location id)
    {
        return !Walls.Contains(id);
    }

    public double Cost(Location a, Location b)
    {
        return Forests.Contains(b) ? 5 : 1;
    }
    
    public IEnumerable<Location> Neighbors(Location id)
    {
        foreach (var dir in Directions) 
        {
            Location next = new Location(id.x + dir.x, id.y + dir.y);
            
            if (InBounds(next) && Passable(next)) 
            {
                yield return next;
            }
        }
    }
}


