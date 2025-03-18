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
}