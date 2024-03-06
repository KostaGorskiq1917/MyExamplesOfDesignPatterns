using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class Weapon
{
    public abstract void Attack();
}

// Concrete products for Weapon Class
class Bow : Weapon
{
    public override void Attack()
    {
        Console.WriteLine("Attacking with Bow!");
    }
}

class Axe : Weapon
{
    public override void Attack()
    {
        Console.WriteLine("Attacking with Axe!");
    }
}

// Abstract product B
abstract class Armor
{
    public abstract void Defend();
}

// Concrete products for Armor class
class LeatherArmor : Armor
{
    public override void Defend()
    {
        Console.WriteLine("Defending with Leather Armor!");
    }
}

class PlateArmor : Armor
{
    public override void Defend()
    {
        Console.WriteLine("Defending with Plate Armor!");
    }
}

// Abstract factory
abstract class EquipmentFactory
{
    public abstract Weapon CreateWeapon();
    public abstract Armor CreateArmor();
}

// Concrete factory for creating fantasy equipment
class FantasyEquipmentFactory : EquipmentFactory
{
    public override Weapon CreateWeapon()
    {
        return new Bow();
    }

    public override Armor CreateArmor()
    {
        return new LeatherArmor();
    }
}

// Concrete factory for creating medieval equipment
class MedievalEquipmentFactory : EquipmentFactory
{
    public override Weapon CreateWeapon()
    {
        return new Axe();
    }

    public override Armor CreateArmor()
    {
        return new PlateArmor();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a fantasy equipment factory
        EquipmentFactory fantasyFactory = new FantasyEquipmentFactory();
        // Create fantasy weapon and armor
        Weapon fantasyWeapon = fantasyFactory.CreateWeapon();
        Armor fantasyArmor = fantasyFactory.CreateArmor();
        // Use fantasy equipment
        fantasyWeapon.Attack();
        fantasyArmor.Defend();

        Console.WriteLine("------------------------------");

        // Create a medieval equipment factory
        EquipmentFactory medievalFactory = new MedievalEquipmentFactory();
        // Create medieval weapon and armor
        Weapon medievalWeapon = medievalFactory.CreateWeapon();
        Armor medievalArmor = medievalFactory.CreateArmor();
        // Use medieval equipment
        medievalWeapon.Attack();
        medievalArmor.Defend();

        Console.ReadKey();
    }
}