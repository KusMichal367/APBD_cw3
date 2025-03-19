namespace Program3;

public abstract class Container
{
    public double CargoMass { get; set; }
    public int Height { get; set; }
    public int ContainerMass { get; set; }
    public int Depth { get; set; }

    public string SerialNumber { get; set; }
    protected static int SerialNumberCounter = 1;
    public double MaxCargoMass { get; set; }

    protected Container(double cargoMass, int height, int containerMass, int depth, double maxCargoMass)
    {
        if (CargoMass>MaxCargoMass)
        {
            throw new OverflowException("Cargo mass cannot be greater than max cargo mass");
        }
        
        CargoMass = cargoMass;
        Height = height;
        ContainerMass = containerMass;
        Depth = depth;
        MaxCargoMass = maxCargoMass;
    }

    public virtual void UnloadCargo()
    {
        CargoMass = 0;
    }

    public virtual void LoadCargo(double mass)
    {
        if (mass > MaxCargoMass)
        {
            throw new OverfillException(MaxCargoMass);
        }
        CargoMass += mass;
    }

    public override string ToString()
    {
        return $"Container {SerialNumber} \n \t Cargo Mass: {CargoMass} kg \n \t Max Cargo Mass: {MaxCargoMass} kg" +
               $"\n \t Height: {Height} cm \n \t Depth: {Depth} cm\n \t container mass: {CargoMass}kg";
    }
}