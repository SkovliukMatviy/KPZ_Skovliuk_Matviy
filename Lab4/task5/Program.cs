using System;
using System.Collections.Generic;

public class Document
{
    private string _content;

    public Document(string initialContent)
    {
        _content = initialContent;
    }

    public void AddContent(string text)
    {
        _content += text;
    }

    public string GetContent()
    {
        return _content;
    }

    public class DocumentMemento
    {
        private readonly string _state;

        public DocumentMemento(string state)
        {
            _state = state;
        }

        public string GetState()
        {
            return _state;
        }
    }

    public DocumentMemento SaveState()
    {
        return new DocumentMemento(_content);
    }

    public void RestoreState(DocumentMemento memento)
    {
        _content = memento.GetState();
    }
}

public interface IHistoryManager
{
    void SaveState(Document.DocumentMemento memento);
    Document.DocumentMemento RetrieveLastState();
}

public class Editor : IHistoryManager
{
    private Document _document;
    private Stack<Document.DocumentMemento> _history = new Stack<Document.DocumentMemento>();

    public Editor(Document document)
    {
        _document = document;
    }

    public void AddText(string text)
    {
        Document.DocumentMemento memento = _document.SaveState();
        _document.AddContent(text);
        SaveState(memento);
    }

    public void Undo()
    {
        Document.DocumentMemento lastState = RetrieveLastState();
        if (lastState != null)
        {
            _document.RestoreState(lastState);
            Console.WriteLine("Document has been reverted to the previous state.");
        }
        else
        {
            Console.WriteLine("No previous state to revert to.");
        }
    }

    public void DisplayDocument()
    {
        string content = _document.GetContent();
        if (string.IsNullOrEmpty(content))
        {
            Console.WriteLine("The document is currently empty.");
        }
        else
        {
            Console.WriteLine("Document Content: \n" + content);
        }
    }

    public void SaveState(Document.DocumentMemento memento)
    {
        _history.Push(memento);
    }

    public Document.DocumentMemento RetrieveLastState()
    {
        if (_history.Count > 0)
        {
            return _history.Pop();
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Simple Text Editor!");
        Document document = new Document("");
        Editor editor = new Editor(document);

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Add text to document");
            Console.WriteLine("2 - Undo last change");
            Console.WriteLine("3 - View document");
            Console.WriteLine("4 - Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter the text you want to add:");
                    string text = Console.ReadLine();
                    editor.AddText(text);
                    break;
                case "2":
                    editor.Undo();
                    break;
                case "3":
                    editor.DisplayDocument();
                    break;
                case "4":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
