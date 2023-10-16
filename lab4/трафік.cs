using System;
using System.Collections.Generic;
class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public double CurrentTrafficLevel { get; set; }

    public Road(double length, double width, int numberOfLanes)
    {
        Length = length;
        Width = width;
        NumberOfLanes = numberOfLanes;
        CurrentTrafficLevel = 0;
    }
}
class Vehicle
{
    public double Speed { get; set; }
    public double Size { get; set; }
    public string Type { get; set; }

    public Vehicle(double speed, double size, string type)
    {
        Speed = speed;
        Size = size;
        Type = type;
    }
}
interface IDriveable
{
    void Move();
    void Stop();
}
class TrafficSimulation
{
    private List<Vehicle> vehicles;
    private Road road;

    public TrafficSimulation(Road road)
    {
        this.road = road;
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void SimulateTraffic()
    {
    }
}
class Simulation
{
    private List<Road> roads;
    private List<TrafficSimulation> simulations;

    public Simulation(List<Road> roads)
    {
        this.roads = roads;
        simulations = new List<TrafficSimulation>();

        foreach (var road in roads)
        {
            simulations.Add(new TrafficSimulation(road));
        }
    }

    public void OptimizeTraffic()
    {
    }

    public void StartSimulation()
    {
        foreach (var simulation in simulations)
        {
            simulation.SimulateTraffic();
        }
    }
}
