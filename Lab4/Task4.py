from abc import ABC, abstractmethod

# Стратегії для завантаження зображень
class ImageLoadingStrategy(ABC):
    @abstractmethod
    def load(self, href):
        pass

class FileSystemImageLoadingStrategy(ImageLoadingStrategy):
    def load(self, href):
        return f"Loading image from file system: {href}"

class NetworkImageLoadingStrategy(ImageLoadingStrategy):
    def load(self, href):
        return f"Loading image from network: {href}"

# Клас для HTML елементів з підтримкою подій
class LightHTMLElement:
    def __init__(self, tag):
        self.tag = tag
        self.children = []
        self.attributes = {}
        self.event_listeners = {}

    def set_attribute(self, key, value):
        self.attributes[key] = value

    def append_child(self, child):
        self.children.append(child)

    def add_event_listener(self, event_type, listener):
        if event_type not in self.event_listeners:
            self.event_listeners[event_type] = []
        self.event_listeners[event_type].append(listener)

    def notify_event_listeners(self, event):
        if event.name in self.event_listeners:
            for listener in self.event_listeners[event.name]:
                listener.update(event)

# Клас для подій
class Event:
    def __init__(self, name):
        self.name = name

class EventListener(ABC):
    @abstractmethod
    def update(self, event):
        pass

class ClickListener(EventListener):
    def update(self, event):
        if event.name == "click":
            print(f"{event.name} event received by ClickListener")

class MouseOverListener(EventListener):
    def update(self, event):
        if event.name == "mouseover":
            print(f"{event.name} event received by MouseOverListener")

# Клас для зображення з підтримкою стратегій
class Image(LightHTMLElement):
    def __init__(self, href, strategy):
        super().__init__("img")
        self.href = href
        self.strategy = strategy

    def load_image(self):
        return self.strategy.load(self.href)

def main():
    # Створюємо HTML елементи
    div = LightHTMLElement("div")
    button = LightHTMLElement("button")

    # Додаємо слухачів подій
    click_listener = ClickListener()
    mouseover_listener = MouseOverListener()

    button.add_event_listener("click", click_listener)
    button.add_event_listener("mouseover", mouseover_listener)

    div.append_child(button)

    # Стратегії для завантаження зображень
    file_strategy = FileSystemImageLoadingStrategy()
    network_strategy = NetworkImageLoadingStrategy()

    # Створюємо зображення з різними стратегіями
    img1 = Image("/path/to/local/image.jpg", file_strategy)
    img2 = Image("http://example.com/image.jpg", network_strategy)

    # Завантажуємо зображення
    print(img1.load_image())
    print(img2.load_image())

    # Симулюємо події
    print("Simulating click event on button:")
    button.notify_event_listeners(Event("click"))

    print("Simulating mouseover event on button:")
    button.notify_event_listeners(Event("mouseover"))

if __name__ == "__main__":
    main()
