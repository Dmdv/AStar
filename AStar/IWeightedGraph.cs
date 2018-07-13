using System.Collections.Generic;

public interface IWeightedGraph
{
    double Cost(Location a, Location b);
    IEnumerable<Location> Neighbors(Location id);
}