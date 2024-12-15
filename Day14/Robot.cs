namespace Day14;

public class Robot
{
    public Robot(Location location, Velocity velocity)
    {
        Location = location;
        Velocity = velocity;
    }

    public Location Location { get; private set; }

    public Velocity Velocity { get; }

    public void Tick(Map map)
    {
        var newX = Location.X + Velocity.X;
        while (newX < 0)
            newX += map.ColCount;
        while (newX >= map.ColCount)
            newX -= map.ColCount;

        var newY = Location.Y + Velocity.Y;
        while (newY < 0)
            newY += map.RowCount;
        while (newY >= map.RowCount)
            newY -= map.RowCount;

        Location = new Location(newX, newY);
    }

    public override string ToString()
    {
        return $"{Location}, {Velocity}";
    }
}