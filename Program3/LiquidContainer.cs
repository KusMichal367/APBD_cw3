namespace Program3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsDangerous;
    
    public LiquidContainer(int cargoMass, int height, int containerMass, int depth, int maxCargoMass, bool isDangerous) : base(cargoMass, height, containerMass, depth, maxCargoMass)
    {
        SerialNumber = "KON-L-"+SerialNumberCounter++;
        IsDangerous = isDangerous;
    }

    public override void LoadCargo(double mass)
    {
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

        if (mass > MaxCargoMass)
        {
            throw new OverfillException(MaxCargoMass);
        }

        CargoMass += mass;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Container {SerialNumber} is trying to fill over safety limit");
    }
    
    public override string ToString()
    {
        return $"Container {SerialNumber} \n \t Cargo Mass: {CargoMass} \n \t Max Cargo Mass: {MaxCargoMass}" +
               $"\n \t Height: {Height} \n \t Depth: {Depth} \n \t container mass: {CargoMass}" +
               $"\n \t Dangerous: {IsDangerous}";
    }
}