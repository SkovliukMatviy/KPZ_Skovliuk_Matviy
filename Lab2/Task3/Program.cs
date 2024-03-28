using System;

public class Authenticator
{
    // Приватний статичний екземпляр класу
    private static Authenticator _instance;

    // Частково приватний конструктор для уникнення прямого створення екземплярів ззовні
    private Authenticator()
    {
    }

    // Публічний статичний метод для отримання єдиного екземпляру класу
    public static Authenticator GetInstance()
    {
        // Перевіряємо, чи екземпляр вже був створений
        if (_instance == null)
        {
            // Якщо ні, то створюємо новий екземпляр
            _instance = new Authenticator();
        }

        // Повертаємо єдиний екземпляр класу
        return _instance;
    }

    // Метод для демонстрації роботи класу
    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"Authenticating user: {username}");
        // Ваш код для аутентифікації
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Отримання єдиного екземпляру Authenticator
        Authenticator authenticator1 = Authenticator.GetInstance();
        Authenticator authenticator2 = Authenticator.GetInstance();

        // Перевірка, що authenticator1 та authenticator2 є одним і тим же екземпляром
        Console.WriteLine($"authenticator1 == authenticator2: {authenticator1 == authenticator2}");

        // Виклик методу Authenticate для демонстрації роботи класу Authenticator
        authenticator1.Authenticate("user123", "password123");
    }
}
