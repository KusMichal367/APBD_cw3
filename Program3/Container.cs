namespace Program3;

public abstract class Container(int cargoMass, int height, int containerMass, int depth, int maxCargoMass)
{
    public double CargoMass { get; set; } = cargoMass;
    public int Height { get; set; } = height;
    public int ContainerMass { get; set; } = containerMass;
    public int Depth { get; set; } = depth;

    public required string SerialNumber { get; set; }
    protected static int SerialNumberCounter = 1;
    public double MaxCargoMass { get; set; } = maxCargoMass;

    public virtual void UnloadCargo()
    {
        CargoMass = 0;
    }

    public virtual void LoadCargo(double mass)
    {
        if (mass > MaxCargoMass)
        {
            throw new OverfillException("Provided mass must be less or equal to MaxCargoMass "+MaxCargoMass+ " tons");
        }
        CargoMass += mass;
    }
}