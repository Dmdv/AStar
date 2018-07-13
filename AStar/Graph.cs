using System.Collections.Generic;

public class Graph
{
    public Dictionary<Location, Location[]> edges = new Dictionary<Location, Location[]>();

    public Location[] Neighbors(Location location)
    {
        return edges[location];
    }
}