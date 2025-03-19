namespace Program3;

public class GasContainer : Container, IHazardNotifier
{ 
    public double Pressure { get; set; }
    
    public GasContainer(int cargoMass, int height, int containerMass, int depth, int maxCargoMass, double pressure) : base(cargoMass, height, containerMass, depth, maxCargoMass)
    {
        SerialNumber = "KON-G-"+SerialNumberCounter++;
        Pressure = pressure;
    }

    public override void UnloadCargo()
    {
        CargoMass = CargoMass * 0.05;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Container {SerialNumber} is notifying hazard");
    }

    public override string ToString()
    {
        return $"Container {SerialNumber} \n \t Cargo Mass: {CargoMass} \n \t Max Cargo Mass: {MaxCargoMass}" +
               $"\n \t Height: {Height} \n \t Depth: {Depth} \n \t container mass: {CargoMass}" +
               $"\n \t Pressure: {Pressure}";
    }
}