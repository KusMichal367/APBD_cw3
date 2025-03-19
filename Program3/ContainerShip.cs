namespace Program3;

public class ContainerShip(int maxSpeed, int maxContainerCapacity, double maxContainerWeight)
{
    public List<Container> Containers { get; set; } = [];
    public int MaxSpeed  { get; set; } = maxSpeed;
    public int MaxContainerCapacity { get; set; } = maxContainerCapacity;
    public double MaxContainerWeight { get; set; } = maxContainerWeight;

    public void LoadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {

            if (Containers.Count >= MaxContainerCapacity)
            {
                throw new Exception("Too many containers");
            }

            var currentWeight = Containers.Sum(con => con.ContainerMass + con.CargoMass);

            if (currentWeight + container.ContainerMass + container.CargoMass > MaxContainerWeight)
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
        String output = $"\n\tMax Speed: {MaxSpeed}+\n\tMax Container Capacity: {MaxContainerCapacity}+\n\tMax Container Weight: {MaxContainerWeight}";
        output += "Containers:";
        foreach (var container in Containers)
        {
            output += $"\n\t{container.ToString()}";
        }
        
        return output;
    }
}