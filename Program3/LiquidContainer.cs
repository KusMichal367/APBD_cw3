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
        double SafeMass;
        if (IsDangerous)
        {
            SafeMass = MaxCargoMass * 0.5;
        }
        else
        {
            SafeMass = MaxCargoMass * 0.9;
        }

        if (mass>SafeMass)
        {
            NotifyHazard();
            throw new OverfillException("Provided mass is over safety limit");
        }
        
        CargoMass += mass;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Container {SerialNumber} is notifying hazard");
    }
}