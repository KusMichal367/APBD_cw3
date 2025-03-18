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

    public override void LoadCargo(double mass)
    {
        double safeTemperature = GetSafeTemperature(ProductType);
        if (Temperature < safeTemperature)
        {
            throw new Exception($"Temperature {safeTemperature} is below safe temperature for {ProductType} \t {Temperature} < {safeTemperature}");
        }

        if (mass > MaxCargoMass)
        {
            throw new OverfillException(MaxCargoMass);
        }
        
        CargoMass += mass;
    }

    private double GetSafeTemperature(string productType)
    {
        if (TemperatureDictionary.Temperatures.TryGetValue(productType.ToLower(), out double safeTemperature))
        {
            return safeTemperature;
        }
        else
        {
            throw new Exception($"Unknown temperature type: {productType}");
        }
    }
}