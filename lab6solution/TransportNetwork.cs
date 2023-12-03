// Class representing a transport network
class TransportNetwork
{
    private List<Vehicle> vehicles;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void MoveAllVehicles()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }

    public void PlanRoute(Vehicle vehicle, Route route)
    {
        Console.WriteLine($"Planning route for {vehicle.GetType().Name} from {route.StartPoint} to {route.EndPoint}.");
        // Add logic to calculate optimal route
    }

    public void BoardPassengers(Vehicle vehicle, int passengers)
    {
        Console.WriteLine($"Boarding {passengers} passengers on {vehicle.GetType().Name}.");
    }

    public void DisembarkPassengers(Vehicle vehicle, int passengers)
    {
        Console.WriteLine($"Disembarking {passengers} passengers from {vehicle.GetType().Name}.");
    }
}