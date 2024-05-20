class Event:
    def __init__(self, name):
        self.name = name

class EventListener:
    def update(self, event):
        pass

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

    def click(self):
        event = Event("click")
        self.notify_event_listeners(event)

    def mouseover(self):
        event = Event("mouseover")
        self.notify_event_listeners(event)

class ClickListener(EventListener):
    def update(self, event):
        if event.name == "click":
            print(f"{event.name} event received by ClickListener")

class MouseOverListener(EventListener):
    def update(self, event):
        if event.name == "mouseover":
            print(f"{event.name} event received by MouseOverListener")

def main():
    div = LightHTMLElement("div")
    button = LightHTMLElement("button")

    click_listener = ClickListener()
    mouseover_listener = MouseOverListener()

    button.add_event_listener("click", click_listener)
    button.add_event_listener("mouseover", mouseover_listener)

    div.append_child(button)

    print("Simulating click event on button:")
    button.click()

    print("Simulating mouseover event on button:")
    button.mouseover()

if __name__ == "__main__":
    main()
