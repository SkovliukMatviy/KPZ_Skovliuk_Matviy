using System;
using System.Collections.Generic;

// Інтерфейс спостерігача
interface IEventListener
{
    void OnEvent(string eventType);
}

// Інтерфейс суб'єкта
interface ISubject
{
    void AddListener(IEventListener listener);
    void RemoveListener(IEventListener listener);
    void NotifyListeners(string eventType);
}

// Конкретний клас спостерігача
class EventListener : IEventListener
{
    private string _listenedEventType;

    public EventListener(string eventType)
    {
        _listenedEventType = eventType;
    }

    public void OnEvent(string eventType)
    {
        if (eventType == _listenedEventType)
        {
            Console.WriteLine($"Подія {_listenedEventType} сталася!");
        }
    }
}

// Реалізація LightHTML
class LightNode
{
    public virtual string RenderOuterHtml() { return ""; }
    public virtual string RenderInnerHtml() { return ""; }
}

class LightTextNode : LightNode
{
    private string _text;
    public LightTextNode(string text)
    {
        _text = text;
    }
    public override string RenderOuterHtml()
    {
        return _text;
    }
    public override string RenderInnerHtml()
    {
        return _text;
    }
}

class LightElementNode : LightNode, ISubject
{
    private List<IEventListener> _listeners = new List<IEventListener>();
    private string _tagName;
    private string _displayType;
    private string _closingType;
    private List<LightNode> _children;
    private List<string> _cssClasses;

    public LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses)
    {
        _tagName = tagName;
        _displayType = displayType;
        _closingType = closingType;
        _cssClasses = cssClasses;
        _children = new List<LightNode>();
    }

    public void AddChild(LightNode node)
    {
        _children.Add(node);
    }

    public override string RenderOuterHtml()
    {
        string result = $"<{_tagName} class=\"{string.Join(" ", _cssClasses)}\" style=\"display:{_displayType}\" {(_closingType == "self-closing" ? "/" : "")}>\n";
        foreach (var child in _children)
        {
            result += $"\t{child.RenderOuterHtml()}\n";
        }
        if (_closingType == "closing")
        {
            result += $"</{_tagName}>";
        }
        return result;
    }

    public override string RenderInnerHtml()
    {
        string result = "";
        foreach (var child in _children)
        {
            result += child.RenderInnerHtml();
        }
        return result;
    }

    public void AddListener(IEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(IEventListener listener)
    {
        _listeners.Remove(listener);
    }

    public void NotifyListeners(string eventType)
    {
        foreach (var listener in _listeners)
        {
            listener.OnEvent(eventType);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LightElementNode title = new LightElementNode("h1", "block", "closing", new List<string>());
        LightTextNode titleText = new LightTextNode("Welcome to my website!");
        title.AddChild(titleText);

        // Додавання слухачів подій до HTML елементів
        EventListener clickListener = new EventListener("click");
        EventListener hoverListener = new EventListener("hover");

        title.AddListener(clickListener);
        title.AddListener(hoverListener);

        // Сповіщення слухачів про події
        title.NotifyListeners("click");
        title.NotifyListeners("hover");

        // Виведення HTML коду елементів
        Console.WriteLine(title.RenderOuterHtml());
    }
}
