namespace Program3;

public class GasContainer : Container, IHazardNotifier
{ 
    public double Pressure { get; set; }
    
    public GasContainer(int heightCm, int depthCm, int containerMassKg,  int maxCargoMass, double pressure) : base(heightCm,depthCm,containerMassKg,maxCargoMass)
    {
        SerialNumber = "KON-G-"+SerialNumberCounter++;
        Pressure = pressure;
    }

    public override void UnloadCargo()
    {
        CargoMassKg *= 0.05;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Container {SerialNumber} is notifying hazard");
    }

    public override string ToString()
    {
        return $"Container {SerialNumber} \n \t Cargo Mass: {CargoMassKg} kg \n \t Max Cargo Mass: {MaxCargoMass} kg" +
               $"\n \t Height: {HeightCm} cm \n \t Depth: {DepthCm} cm \n \t container mass: {ContainerMassKg} kg\n\t Total Mass: {ContainerMassKg+CargoMassKg}kg" +
               $"\n \t Pressure: {Pressure} atm \n";
    }
    
    public override string ContainerInfo()
    {
        return $"Container {SerialNumber} (Cargo Mass: {CargoMassKg} kg Max Cargo Mass: {MaxCargoMass} kg" +
               $" Height: {HeightCm} cm Depth: {DepthCm} cm container mass: {ContainerMassKg} kg Total Mass: {ContainerMassKg+CargoMassKg}kg" +
               $" Pressure: {Pressure} atm) \n";
    }
}