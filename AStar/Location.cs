public struct Location
{
    public readonly int y;
    public readonly int x;

    public Location(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Location))
        {
            return false;
        }

        var other = (Location)obj;

        return other.x == x && other.y == y;
    }

    public override int GetHashCode()
    {
        return y.GetHashCode() ^ x.GetHashCode();
    }

    public override string ToString()
    {
        return string.Format("({0}-{1})", x, y);
    }
}