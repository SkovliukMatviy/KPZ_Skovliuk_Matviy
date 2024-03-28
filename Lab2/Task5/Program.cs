using System;
using System.Collections.Generic;

// Клас, який представляє персонажа гри
class Character
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Height { get; set; }
    public string Build { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public List<string> Inventory { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Build: {Build}");
        Console.WriteLine($"Hair Color: {HairColor}");
        Console.WriteLine($"Eye Color: {EyeColor}");
        Console.WriteLine("Inventory:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"- {item}");
        }
    }
}

// Інтерфейс будівельника персонажа гри
interface ICharacterBuilder
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetType(string type);
    ICharacterBuilder SetHeight(string height);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHairColor(string hairColor);
    ICharacterBuilder SetEyeColor(string eyeColor);
    ICharacterBuilder AddToInventory(string[] items);
    Character Build();
}

// Реалізація будівельника персонажа гри
class HeroBuilder : ICharacterBuilder
{
    private Character _character;

    public HeroBuilder()
    {
        _character = new Character();
        _character.Type = "Hero";
        _character.Inventory = new List<string>();
    }

    public ICharacterBuilder SetName(string name)
    {
        _character.Name = name;
        return this;
    }

    public ICharacterBuilder SetType(string type)
    {
        _character.Type = type;
        return this;
    }

    public ICharacterBuilder SetHeight(string height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        _character.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        _character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string eyeColor)
    {
        _character.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder AddToInventory(string[] items)
    {
        _character.Inventory.AddRange(items);
        return this;
    }

    public Character Build()
    {
        return _character;
    }
}

// Директор будівельника персонажа гри
class CharacterDirector
{
    private ICharacterBuilder _builder;

    public CharacterDirector(ICharacterBuilder builder)
    {
        _builder = builder;
    }

    public Character BuildCharacter(string name, string height, string build, string hairColor, string eyeColor, string[] inventory)
    {
        return _builder.SetName(name)
                       .SetHeight(height)
                       .SetBuild(build)
                       .SetHairColor(hairColor)
                       .SetEyeColor(eyeColor)
                       .AddToInventory(inventory)
                       .Build();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення будівельника для героя
        HeroBuilder heroBuilder = new HeroBuilder();
        CharacterDirector director = new CharacterDirector(heroBuilder);

        // Створення героя
        Character hero = director.BuildCharacter("John", "6'2\"", "Athletic", "Blonde", "Blue", args);

        // Відображення інформації про героя
        Console.WriteLine("Hero Character:");
        hero.DisplayInfo();
    }
}
