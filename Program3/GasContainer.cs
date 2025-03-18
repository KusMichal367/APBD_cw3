namespace Program3;

public class GasContainer : Container
{ 
    public double Pressure { get; set; }
    
    public GasContainer(int cargoMass, int height, int containerMass, int depth, int maxCargoMass, double pressure) : base(cargoMass, height, containerMass, depth, maxCargoMass)
    {
        SerialNumber = "KON-G-"+SerialNumberCounter++;
        Pressure = pressure;
    }
    
}