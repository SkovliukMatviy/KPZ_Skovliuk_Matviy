from abc import ABC, abstractmethod

# Інтерфейс стратегії
class ImageLoadingStrategy(ABC):
    @abstractmethod
    def load_image(self, href):
        pass

# Конкретна стратегія для завантаження картинки з файлової системи
class FilesystemImageLoadingStrategy(ImageLoadingStrategy):
    def load_image(self, href):
        # Реалізація завантаження з файлової системи
        return f"Image loaded from filesystem: {href}"

# Конкретна стратегія для завантаження картинки з мережі
class NetworkImageLoadingStrategy(ImageLoadingStrategy):
    def load_image(self, href):
        # Реалізація завантаження з мережі
        return f"Image loaded from network: {href}"

# Клас Image, який використовує стратегію
class Image:
    def __init__(self, href, loading_strategy):
        self.href = href
        self.loading_strategy = loading_strategy

    def display(self):
        image_data = self.loading_strategy.load_image(self.href)
        print(image_data)


class TextMemento:
    def __init__(self, content):
        self.content = content

    def get_content(self):
        return self.content


class TextDocument:
    def __init__(self):
        self.content = ""

    def add_text(self, text):
        self.content += text

    def delete_text(self, start, end):
        self.content = self.content[:start] + self.content[end:]

    def get_content(self):
        return self.content

    def create_memento(self):
        return TextMemento(self.content)

    def restore(self, memento):
        self.content = memento.get_content()


class TextEditor:
    def __init__(self):
        self.document = TextDocument()
        self.history = []
        self.undo_stack = []

    def type_text(self, text):
        self.document.add_text(text)
        self.history.append(("add", text))
        self.undo_stack.append(self.document.create_memento())

    def delete_text(self, start, end):
        deleted_text = self.document.get_content()[start:end]
        self.document.delete_text(start, end)
        self.history.append(("delete", deleted_text))
        self.undo_stack.append(self.document.create_memento())

    def undo(self):
        if self.history:
            action, data = self.history.pop()
            if action == "add":
                self.document.delete_text(len(self.document.get_content()) - len(data), len(self.document.get_content()))
            elif action == "delete":
                self.document.add_text(data)
            self.undo_stack.pop()

    def redo(self):
        if self.undo_stack:
            memento = self.undo_stack.pop()
            self.document.restore(memento)

    def print_content(self):
        print("Current content:")
        print(self.document.get_content())


if __name__ == "__main__":
    # Створення об'єктів Image з різними стратегіями
    image_from_filesystem = Image("path/to/image.jpg", FilesystemImageLoadingStrategy())
    image_from_network = Image("http://example.com/image.jpg", NetworkImageLoadingStrategy())

    # Виведення зображень
    image_from_filesystem.display()
    image_from_network.display()

    # Створення редактора
    editor = TextEditor()

    # Виконання дій з текстом
    editor.type_text("Hello, ")
    editor.type_text("world!")
    editor.print_content()  # Виведе: "Current content: Hello, world!"

    editor.delete_text(7, 13)  # Видаляє слово "world!"
    editor.print_content()  # Виведе: "Current content: Hello, "

    editor.undo()  # Відміняє видалення
    editor.print_content()  # Виведе: "Current content: Hello, world!"

    editor.redo()  # Повертає видалення
    editor.print_content()  # Виведе: "Current content: Hello, "