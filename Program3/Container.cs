namespace Program3;

public abstract class Container
{
    public double CargoMassKg { get; set; }
    public int HeightCm { get; set; }
    public int ContainerMassKg { get; set; }
    public int DepthCm { get; set; }

    public string SerialNumber { get; set; }
    protected static int SerialNumberCounter = 1;
    public double MaxCargoMass { get; set; }

    protected Container(int heightCm, int depthCm, int containerMassKg, double maxCargoMass)
    {
        HeightCm = heightCm;
        ContainerMassKg = containerMassKg;
        DepthCm = depthCm;
        MaxCargoMass = maxCargoMass;
    }

    public virtual void UnloadCargo()
    {
        CargoMassKg = 0;
    }

    public virtual void LoadCargo(double mass)
    {
        if (CargoMassKg + mass > MaxCargoMass)
        {
            throw new OverfillException(MaxCargoMass);
        }

        CargoMassKg += mass;
    }

    public override string ToString()
    {
        return $"Container {SerialNumber} \n \t Cargo Mass: {CargoMassKg} kg \n \t Max Cargo Mass: {MaxCargoMass} kg" +
               $"\n \t Height: {HeightCm} cm \n \t Depth: {DepthCm} cm\n \t container mass: {ContainerMassKg}kg \n\t Total Mass: {ContainerMassKg+CargoMassKg}kg\n";
    }
}