namespace Program3;

public class OverfillException(double maxCargoMass) : Exception("Provided mass must be less or equal to "+maxCargoMass+" kilograms");