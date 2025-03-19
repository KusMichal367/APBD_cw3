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
        return $"Container {SerialNumber} \n \t Cargo Mass: {CargoMass} kg \n \t Max Cargo Mass: {MaxCargoMass} kg" +
               $"\n \t Height: {Height} cm \n \t Depth: {Depth} cm \n \t container mass: {CargoMass} kg" +
               $"\n \t Dangerous: {IsDangerous}";
    }
}