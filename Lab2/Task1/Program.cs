using System;
using System.Collections.Generic;

// Abstract Product
abstract class Subscription
{
    public decimal MonthlyFee { get; protected set; }
    public int MinSubscriptionPeriod { get; protected set; }
    public List<string> Channels { get; protected set; }

    public Subscription(decimal monthlyFee, int minSubscriptionPeriod, List<string> channels)
    {
        MonthlyFee = monthlyFee;
        MinSubscriptionPeriod = minSubscriptionPeriod;
        Channels = channels;
    }
}

// Concrete Products
class DomesticSubscription : Subscription
{
    public DomesticSubscription(List<string> channels) : base(10, 1, channels)
    {
    }
}

class EducationalSubscription : Subscription
{
    public EducationalSubscription(List<string> channels) : base(15, 3, channels)
    {
    }
}

class PremiumSubscription : Subscription
{
    public PremiumSubscription(List<string> channels) : base(25, 6, channels)
    {
    }
}

// Abstract Factory
abstract class SubscriptionFactory
{
    public abstract Subscription CreateSubscription(List<string> channels);
}

// Concrete Factories
class WebSite : SubscriptionFactory
{
    public override Subscription CreateSubscription(List<string> channels)
    {
        return new DomesticSubscription(channels);
    }
}

class MobileApp : SubscriptionFactory
{
    public override Subscription CreateSubscription(List<string> channels)
    {
        return new EducationalSubscription(channels);
    }
}

class ManagerCall : SubscriptionFactory
{
    public override Subscription CreateSubscription(List<string> channels)
    {
        return new PremiumSubscription(channels);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating subscriptions using different methods
        SubscriptionFactory websiteFactory = new WebSite();
        SubscriptionFactory mobileAppFactory = new MobileApp();
        SubscriptionFactory managerCallFactory = new ManagerCall();

        Subscription domesticSubscription = websiteFactory.CreateSubscription(new List<string> { "News", "Entertainment" });
        Subscription educationalSubscription = mobileAppFactory.CreateSubscription(new List<string> { "Documentaries", "Educational" });
        Subscription premiumSubscription = managerCallFactory.CreateSubscription(new List<string> { "Sports", "Movies" });

        // Displaying subscription details
        Console.WriteLine("Domestic Subscription:");
        Console.WriteLine($"Monthly Fee: ${domesticSubscription.MonthlyFee}");
        Console.WriteLine($"Minimum Subscription Period: {domesticSubscription.MinSubscriptionPeriod} months");
        Console.WriteLine($"Channels: {string.Join(", ", domesticSubscription.Channels)}");
    }
}
