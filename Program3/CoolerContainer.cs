namespace Program3;

public class CoolerContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }
    
    public CoolerContainer(int heightCm,int depthCm, int containerMassKg,  int maxCargoMass, string productType, double temperature) : base(heightCm,depthCm,containerMassKg, maxCargoMass)
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
        
        CargoMassKg += mass;
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
    
    public override string ToString()
    {
        return $"Container {SerialNumber} \n \t Cargo Mass: {CargoMassKg} kg \n \t Max Cargo Mass: {MaxCargoMass} kg" +
               $"\n \t Height: {HeightCm} cm \n \t Depth: {DepthCm} cm \n \t container mass: {CargoMassKg} kg" +
               $"\n \t Product: {ProductType} \n \t Temperature: {Temperature}\u2103";
    }
}