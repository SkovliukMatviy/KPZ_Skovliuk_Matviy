using System;
using System.Collections.Generic;

// Клас вірусу, який реалізує клонування
public class Virus : ICloneable
{
    public int Weight { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Virus> Children { get; set; }

    // Конструктор класу
    public Virus(int weight, int age, string name, string type)
    {
        Weight = weight;
        Age = age;
        Name = name;
        Type = type;
        Children = new List<Virus>();
    }

    // Метод для додавання дитини вірусу
    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    // Метод клонування вірусу
    public object Clone()
    {
        // Створюємо новий об'єкт вірусу та копіюємо всі властивості
        Virus clone = new Virus(Weight, Age, Name, Type);

        // Клонуємо всі діти
        foreach (var child in Children)
        {
            clone.AddChild((Virus)child.Clone());
        }

        return clone;
    }

    // Метод для відображення інформації про вірус
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Type: {Type}, Weight: {Weight}, Age: {Age}");
        Console.WriteLine($"Children:");
        foreach (var child in Children)
        {
            child.DisplayInfo();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення вірусів
        Virus firstGenerationVirus = new Virus(10, 1, "Virus1", "Type1");
        firstGenerationVirus.AddChild(new Virus(8, 1, "Virus1Child1", "Type1"));
        firstGenerationVirus.AddChild(new Virus(7, 1, "Virus1Child2", "Type2"));

        // Клонування вірусу
        Virus clonedVirus = (Virus)firstGenerationVirus.Clone();

        // Відображення інформації про клонований вірус та його дітей
        Console.WriteLine("Original Virus:");
        firstGenerationVirus.DisplayInfo();
        Console.WriteLine("\nCloned Virus:");
        clonedVirus.DisplayInfo();
    }
}
