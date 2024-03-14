using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Product class representing a game character
class Character
{
    public string Name { get; set; }
    public string Class { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public string Weapon { get; set; }
    public string Ability { get; set; }

    public void Display()
    {
        Console.WriteLine($"Character: {Name}, Class: {Class}");
        Console.WriteLine($"Health: {Health}, Mana: {Mana}");
        Console.WriteLine($"Weapon: {Weapon}, Ability: {Ability}");
    }
}

// Builder interface for building characters
interface ICharacterBuilder
{
    void BuildName();
    void BuildClass();
    void BuildHealth();
    void BuildMana();
    void BuildWeapon();
    void BuildAbility();
    Character GetCharacter();
}

// Concrete builder for building a warrior character
class WarriorBuilder : ICharacterBuilder
{
    private Character character = new Character();

    public void BuildName()
    {
        character.Name = "Warrior";
    }

    public void BuildClass()
    {
        character.Class = "Warrior";
    }

    public void BuildHealth()
    {
        character.Health = 100;
    }

    public void BuildMana()
    {
        character.Mana = 50;
    }

    public void BuildWeapon()
    {
        character.Weapon = "Sword";
    }

    public void BuildAbility()
    {
        character.Ability = "Slash";
    }

    public Character GetCharacter()
    {
        return character;
    }
}

class HealerBuilder : ICharacterBuilder
{
    private Character character = new Character();

    public void BuildName()
    {
        character.Name = "Healer";
    }

    public void BuildClass()
    {
        character.Class = "Healer";
    }

    public void BuildHealth()
    {
        character.Health = 75;
    }

    public void BuildMana()
    {
        character.Mana = 100;
    }

    public void BuildWeapon()
    {
        character.Weapon = "Staff";
    }

    public void BuildAbility()
    {
        character.Ability = "Heal";
    }

    public Character GetCharacter()
    {
        return character;
    }
}
// Director class responsible for directing the construction process
class CharacterDirector
{
    private ICharacterBuilder characterBuilder;

    public CharacterDirector(ICharacterBuilder builder)
    {
        characterBuilder = builder;
    }

    public void ConstructCharacter()
    {
        characterBuilder.BuildName();
        characterBuilder.BuildClass();
        characterBuilder.BuildHealth();
        characterBuilder.BuildMana();
        characterBuilder.BuildWeapon();
        characterBuilder.BuildAbility();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a warrior character builder
        ICharacterBuilder warriorBuilder = new WarriorBuilder();
        // Create a healer charecter builder
        ICharacterBuilder healerBuilder = new HealerBuilder();
        // Create a director
        CharacterDirector directorW = new CharacterDirector(warriorBuilder);
        CharacterDirector directorH = new CharacterDirector(healerBuilder);    
        // Construct the characters
        directorW.ConstructCharacter();
        directorH.ConstructCharacter();
        // Get the constructed characters
        Character warrior = warriorBuilder.GetCharacter();
        Character healer = healerBuilder.GetCharacter();
        // Display the characters
        warrior.Display();
        healer.Display();

        Console.ReadKey();
    }
}