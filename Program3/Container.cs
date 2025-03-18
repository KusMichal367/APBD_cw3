namespace Program3;

public abstract class Container(int cargoMass, int height, int containerMass, int depth, int maxCargoMass)
{
    public int CargoMass { get; set; } = cargoMass;
    public int Height { get; set; } = height;
    public int ContainerMass { get; set; } = containerMass;
    public int Depth { get; set; } = depth;

    public required string SerialNumber { get; set; }
    protected static int SerialNumberCounter = 1;
    public int MaxCargoMass { get; set; } = maxCargoMass;
}