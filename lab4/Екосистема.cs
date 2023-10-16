using System;
using System.Collections.Generic;

class LivingOrganism
{
    public int Energy { get; set; }
    public int Age { get; set; }
    public int Size { get; set; }

    public LivingOrganism(int energy, int age, int size)
    {
        Energy = energy;
        Age = age;
        Size = size;
    }
}
class Animal : LivingOrganism, IReproducible, IPredator
{
    public int Speed { get; set; }
    public bool Carnivore { get; set; }

    public Animal(int energy, int age, int size, int speed, bool carnivore)
        : base(energy, age, size)
    {
        Speed = speed;
        Carnivore = carnivore;
    }

    public void Hunt(LivingOrganism prey)
    {
        if (Energy > 0 && Carnivore)
        {
            Energy += prey.Energy;
        }
    }

    public void Reproduce()
    {
    }
}

class Plant : LivingOrganism, IReproducible
{
    public string Species { get; set; }

    public Plant(int energy, int age, int size, string species)
        : base(energy, age, size)
    {
        Species = species;
    }

    public void Reproduce()
    {
    }
}

class Microorganism : LivingOrganism, IReproducible
{
    public bool SingleCell { get; set; }

    public Microorganism(int energy, int age, int size, bool singleCell)
        : base(energy, age, size)
    {
        SingleCell = singleCell;
    }

    public void Reproduce()
    {
    }
}

interface IReproducible
{
    void Reproduce();
}

interface IPredator
{
    void Hunt(LivingOrganism prey);
}

class Ecosystem
{
    private List<LivingOrganism> organisms;

    public Ecosystem(List<LivingOrganism> organisms)
    {
        this.organisms = organisms;
    }

    public void Interaction()
    {
        foreach (var organism1 in organisms)
        {
            foreach (var organism2 in organisms)
            {
                if (organism1 != organism2)
                {
                    if (organism1 is IPredator && organism2 is LivingOrganism)
                    {
                        var predator = (IPredator)organism1;
                        if (organism1.Energy > 0)
                        {
                            predator.Hunt((LivingOrganism)organism2);
                            organisms.Remove(organism2);
                        }
                    }
                    if (organism1 is IReproducible && organism2 is IReproducible)
                    {
                        if (organism1.Energy > 100 && organism2.Energy > 100)
                        {
                            var reproducer1 = (IReproducible)organism1;
                            var reproducer2 = (IReproducible)organism2;
                            reproducer1.Reproduce();
                            reproducer2.Reproduce();
                        }
                    }
                }
            }
        }
    }
}

