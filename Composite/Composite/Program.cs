using System;
using System.Collections.Generic;

public interface Unit
{
    void Move();
    void Attack();
}

public class Soldier : Unit
{
    public void Move()
    {
        Console.WriteLine("Soldier is moving");
    }

    public void Attack()
    {
        Console.WriteLine("Soldier is attacking");
    }
}

public class Squad : Unit
{
    private List<Unit> units = new List<Unit>();

    public void AddUnit(Unit unit)
    {
        units.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        units.Remove(unit);
    }

    public void Move()
    {
        Console.WriteLine("Squad is moving");
        foreach (var unit in units)
        {
            unit.Move();
        }
    }

    public void Attack()
    {
        Console.WriteLine("Squad is attacking");
        foreach (var unit in units)
        {
            unit.Attack();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var soldier1 = new Soldier();
        var soldier2 = new Soldier();

        var squad1 = new Squad();
        squad1.AddUnit(soldier1);
        squad1.AddUnit(soldier2);

        var soldier3 = new Soldier();

        var squad2 = new Squad();
        squad2.AddUnit(soldier3);
        squad2.AddUnit(squad1);

        squad2.Move();
        Console.WriteLine();
        squad2.Attack();
        Console.ReadKey();
    }
}
