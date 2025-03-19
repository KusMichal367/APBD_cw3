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
        return $"Container {SerialNumber} \n \t Cargo Mass: {CargoMass} kg \n \t Max Cargo Mass: {MaxCargoMass} kg" +
               $"\n \t Height: {Height} cm \n \t Depth: {Depth} cm \n \t container mass: {CargoMass} kg" +
               $"\n \t Pressure: {Pressure} atm";
    }
}