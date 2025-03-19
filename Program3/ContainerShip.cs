namespace Program3;

public class ContainerShip
{
    public List<Container> Containers { get; set; } = [];
    public int MaxSpeed  { get; set; }
    public int MaxContainerCapacity { get; set; }
    public double MaxContainerWeightTons { get; set; }
    
    public string ShipName { get; set; }
    public static int ShipNameCounter = 1;

    public ContainerShip(int maxSpeed, int maxContainerCapacity, double maxContainerWeightTons)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCapacity = maxContainerCapacity;
        MaxContainerWeightTons = maxContainerWeightTons;
        ShipName = $"Ship-{ShipNameCounter++}";
    }

    public void LoadContainer(Container container)
    { 
        if (Containers.Count >= MaxContainerCapacity)
        { 
            throw new Exception("Too many containers");
        }
        var currentWeight = Containers.Sum(con => con.ContainerMassKg + con.CargoMassKg);
        if (currentWeight + container.ContainerMassKg + container.CargoMassKg > MaxContainerWeightTons*1000) 
        { 
            throw new Exception("Weight exceeds max capacity");
        }
        Containers.Add(container);
        Console.WriteLine($"Loaded container {container.SerialNumber} to {ShipName}");
    }
    
    public void LoadContainer(List<Container> containerList)
    {
        foreach (var container in containerList)
        {
            try
            {
                LoadContainer(container);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Problem with adding container {container.SerialNumber}: {ex.Message}");
            }
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            Console.WriteLine($"Removed container {serialNumber} from {ShipName}");  
        }
        
        else
            throw new Exception($"No container found for serial number {serialNumber}");
    }

    public override string ToString()
    {
        String output = $"{ShipName}\n\tMax Speed: {MaxSpeed} knots\n\tMax Container Capacity: {MaxContainerCapacity} containers\n\tMax Container Weight: {MaxContainerWeightTons} tons\n\tTotal Cargo Weight {GetTotalMass()/1000} tons\n\t";
        output += "Containers on board:\n";

        if (Containers.Count > 0)
        {
            foreach (var container in Containers)
            {
                output += $"\n\t{container.ToString()}";
            } 
        }
        else
        {
            output += "\n\tNo containers";
        }
        return output;
    }

    public double GetTotalMass()
    {
        double totalMass = 0;
        foreach (var container in Containers)
        {
            totalMass += container.ContainerMassKg + container.CargoMassKg;
        }
        
        return totalMass;
    }
}