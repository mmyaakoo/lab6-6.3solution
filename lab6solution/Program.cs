using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        TransportNetwork transportNetwork = new TransportNetwork();

        // Adding vehicles to the network
        Car car = new Car { Speed = 60, Capacity = 4 };
        Bus bus = new Bus { Speed = 40, Capacity = 20 };
        Train train = new Train { Speed = 80, Capacity = 1000 };

        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        // Moving all vehicles in the network
        transportNetwork.MoveAllVehicles();

        // Planning routes for vehicles
        Route carRoute = new Route { StartPoint = "A", EndPoint = "B" };
        Route busRoute = new Route { StartPoint = "X", EndPoint = "Y" };
        Route trainRoute = new Route { StartPoint = "P", EndPoint = "Q" };

        transportNetwork.PlanRoute(car, carRoute);
        transportNetwork.PlanRoute(bus, busRoute);
        transportNetwork.PlanRoute(train, trainRoute);

        // Boarding and disembarking passengers
        transportNetwork.BoardPassengers(bus, 15);
        transportNetwork.DisembarkPassengers(train, 50);

        // Keep the console window open
        Console.ReadLine();
    }
}
