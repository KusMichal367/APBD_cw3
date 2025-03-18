namespace Program3;

public class LiquidContainer : Container
{
    public bool IsDangerous;
    
    public LiquidContainer(int cargoMass, int height, int containerMass, int depth, int maxCargoMass, bool isDangerous) : base(cargoMass, height, containerMass, depth, maxCargoMass)
    {
        SerialNumber = "KON-L-"+SerialNumberCounter++;
        IsDangerous = isDangerous;
    }
}