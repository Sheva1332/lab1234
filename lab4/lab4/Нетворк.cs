using System;
using System.Collections.Generic;

class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OSType { get; set; }

    public Computer(string ipAddress, int power, string osType)
    {
        IPAddress = ipAddress;
        Power = power;
        OSType = osType;
    }
}

class Server : Computer, IConnectable
{
    public int ConnectedComputers { get; private set; }

    public Server(string ipAddress, int power, string osType)
        : base(ipAddress, power, osType)
    {
        ConnectedComputers = 0;
    }

    public void Connect(Computer computer)
    {
        ConnectedComputers++;
        Console.WriteLine($"Server {IPAddress} connected to computer {computer.IPAddress}.");
    }

    public void Disconnect(Computer computer)
    {
        ConnectedComputers--;
        Console.WriteLine($"Server {IPAddress} disconnected from computer {computer.IPAddress}.");
    }

    public void SendData(Computer computer, string data)
    {
        Console.WriteLine($"Server {IPAddress} sent data to computer {computer.IPAddress}: {data}");
    }

    public void ReceiveData(string data)
    {
        Console.WriteLine($"Server {IPAddress} received data: {data}");
    }
}

class Workstation : Computer, IConnectable
{
    public Workstation(string ipAddress, int power, string osType)
        : base(ipAddress, power, osType)
    {
    }

    public void Connect(Computer computer)
    {
        Console.WriteLine($"Workstation {IPAddress} connected to computer {computer.IPAddress}.");
    }

    public void Disconnect(Computer computer)
    {
        Console.WriteLine($"Workstation {IPAddress} disconnected from computer {computer.IPAddress}.");
    }

    public void SendData(Computer computer, string data)
    {
        Console.WriteLine($"Workstation {IPAddress} sent data to computer {computer.IPAddress}: {data}");
    }

    public void ReceiveData(string data)
    {
        Console.WriteLine($"Workstation {IPAddress} received data: {data}");
    }
}

class Router : Computer, IConnectable
{
    public Router(string ipAddress, int power, string osType)
        : base(ipAddress, power, osType)
    {
    }

    public void Connect(Computer computer)
    {
        Console.WriteLine($"Router {IPAddress} connected to computer {computer.IPAddress}.");
    }

    public void Disconnect(Computer computer)
    {
        Console.WriteLine($"Router {IPAddress} disconnected from computer {computer.IPAddress}.");
    }

    public void SendData(Computer computer, string data)
    {
        Console.WriteLine($"Router {IPAddress} sent data to computer {computer.IPAddress}: {data}");
    }

    public void ReceiveData(string data)
    {
        Console.WriteLine($"Router {IPAddress} received data: {data}");
    }
}

interface IConnectable
{
    void Connect(Computer computer);
    void Disconnect(Computer computer);
    void SendData(Computer computer, string data);
    void ReceiveData(string data);
}

class Network
{
    private List<Computer> computers;

    public Network(List<Computer> computers)
    {
        this.computers = computers;
    }

    public void Interaction()
    {
        foreach (var computer1 in computers)
        {
            foreach (var computer2 in computers)
            {
                if (computer1 != computer2)
                {
                    computer1.SendData(computer2, "Sample data");
                    computer2.ReceiveData("Sample data");
                }
            }
        }
    }
}
