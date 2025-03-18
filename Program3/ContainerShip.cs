namespace Program3;

public class ContainerShip(int maxSpeed, int maxContainerCapacity, double maxContainerWeight)
{
    public List<Container> Containers { get; set; } = [];
    public int MaxSpeed  { get; set; } = maxSpeed;
    public int MaxContainerCapacity { get; set; } = maxContainerCapacity;
    public double MaxContainerWeight { get; set; } = maxContainerWeight;
}