namespace Program3;

public class CoolerContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }
    
    public CoolerContainer(int cargoMass, int height, int containerMass, int depth, int maxCargoMass, bool isDangerous, string productType, double temperature) : base(cargoMass, height, containerMass, depth, maxCargoMass)
    {
        SerialNumber = "KON-C-"+SerialNumberCounter++;
        ProductType = productType;
        Temperature = temperature;
    }
}