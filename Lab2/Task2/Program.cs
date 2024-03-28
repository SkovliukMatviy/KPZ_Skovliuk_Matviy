using System;

// Abstract Product
abstract class Device
{
    public abstract void DisplayInfo();
}

// Concrete Products
class Laptop : Device
{
    private string _brand;

    public Laptop(string brand)
    {
        _brand = brand;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Laptop from {_brand}");
    }
}

class Netbook : Device
{
    private string _brand;

    public Netbook(string brand)
    {
        _brand = brand;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Ebook from {_brand}");
    }
}

class EBook : Device
{
    private string _brand;

    public EBook(string brand)
    {
        _brand = brand;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Ebook from {_brand}");
    }
}

class Smartphone : Device
{
    private string _brand;

    public Smartphone(string brand)
    {
        _brand = brand;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Smartphone from {_brand}");
    }
}

// Abstract Factory
abstract class TechFactory
{
    public abstract Device CreateDevice(string deviceType);
}

// Concrete Factories
class IProneFactory : TechFactory
{
    public override Device CreateDevice(string deviceType)
    {
        switch (deviceType)
        {
            case "Laptop":
                return new Laptop("Iphone");
            case "Netbook":
                return new Netbook("Iphone");
            case "EBook":
                return new EBook("Iphone");
            case "Smartphone":
                return new Smartphone("Iphone");
            default:
                throw new ArgumentException($"Unknown device type: {deviceType}");
        }
    }
}

class KiaomiFactory : TechFactory
{
    public override Device CreateDevice(string deviceType)
    {
        switch (deviceType)
        {
            case "Laptop":
                return new Laptop("Xiaomi");
            case "Netbook":
                return new Netbook("Xiaomi");
            case "EBook":
                return new EBook("Xiaomi");
            case "Smartphone":
                return new Smartphone("Xiaomi");
            default:
                throw new ArgumentException($"Unknown device type: {deviceType}");
        }
    }
}

class BalaxyFactory : TechFactory
{
    public override Device CreateDevice(string deviceType)
    {
        switch (deviceType)
        {
            case "Laptop":
                return new Laptop("Galaxy");
            case "Netbook":
                return new Netbook("Galaxy");
            case "EBook":
                return new EBook("Galaxy");
            case "Smartphone":
                return new Smartphone("Galaxy");
            default:
                throw new ArgumentException($"Unknown device type: {deviceType}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating devices using different factories
        TechFactory iproneFactory = new IProneFactory();
        TechFactory kiaomiFactory = new KiaomiFactory();
        TechFactory balaxyFactory = new BalaxyFactory();

        Device iproneLaptop = iproneFactory.CreateDevice("Laptop");
        Device kiaomiSmartphone = kiaomiFactory.CreateDevice("Smartphone");
        Device balaxyEBook = balaxyFactory.CreateDevice("Ebook");

        // Displaying device info
        iproneLaptop.DisplayInfo();
        kiaomiSmartphone.DisplayInfo();
        balaxyEBook.DisplayInfo();
    }
}
