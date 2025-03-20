namespace Program3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsDangerous;
    
    public LiquidContainer(int heightCm, int depthCm, int containerMassKg, int maxCargoMass, bool isDangerous) : base(heightCm,depthCm,containerMassKg,maxCargoMass)
    {
        SerialNumber = "KON-L-"+SerialNumberCounter++;
        IsDangerous = isDangerous;
    }

    public override void LoadCargo(double mass)
    {
        
        if (mass <= 0)
        {
            throw new Exception("Invalid mass");
        }

        double safeMass;
        if (IsDangerous)
        {
            safeMass = MaxCargoMass * 0.5;
        }
        else
        {
            safeMass = MaxCargoMass * 0.9;
        }

        if (mass>safeMass)
        {
            NotifyHazard();
        }

        if (CargoMassKg + mass > MaxCargoMass)
        {
            throw new OverfillException(MaxCargoMass);
        }

        CargoMassKg += mass;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Container {SerialNumber} is trying to fill over safety limit");
    }
    
    public override string ToString()
    {
        return $"Container {SerialNumber} \n \t Cargo Mass: {CargoMassKg} kg \n \t Max Cargo Mass: {MaxCargoMass} kg" +
               $"\n \t Height: {HeightCm} cm \n \t Depth: {DepthCm} cm \n \t container mass: {ContainerMassKg} kg\n\t Total Mass: {ContainerMassKg+CargoMassKg}kg" +
               $"\n \t Dangerous: {IsDangerous} \n";
    }
    
}