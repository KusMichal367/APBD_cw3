namespace Program3;

public class ContainerShip()
{
    public List<Container> Containers { get; set; } = [];
    public int MaxSpeed  { get; set; }
    public int MaxContainerCapacity { get; set; }
    public double MaxContainerWeightTons { get; set; }
    
    public string ShipName { get; set; }
    public static int ShipNameCounter = 1;

    public ContainerShip(int maxSpeed, int maxContainerCapacity, double maxContainerWeightTons) : this()
    {
        MaxSpeed = maxSpeed;
        MaxContainerCapacity = maxContainerCapacity;
        MaxContainerWeightTons = maxContainerWeightTons;
        ShipName = $"Ship{ShipNameCounter++}";
    }

    public void LoadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
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
        }
        else
        {
            throw new Exception("No container found with this serial number");
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null) Containers.Remove(container);
    }

    public override string ToString()
    {
        String output = $"{ShipName}\n\tMax Speed: {MaxSpeed} knots\n\tMax Container Capacity: {MaxContainerCapacity} containers\n\tMax Container Weight: {MaxContainerWeightTons} tons\n\t";
        output += "Containers on board:";

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
}