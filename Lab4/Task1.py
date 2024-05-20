class SupportHandler:
    def __init__(self, next_handler=None):
        self.next_handler = next_handler

    def handle_request(self, request):
        if self.next_handler:
            return self.next_handler.handle_request(request)
        return "Зверніться до служби підтримки повторно."


class BillingSupportHandler(SupportHandler):
    def handle_request(self, request):
        if request == "billing":
            return "Зв'яжіться з відділом розрахунків."
        return super().handle_request(request)


class TechnicalSupportHandler(SupportHandler):
    def handle_request(self, request):
        if request == "technical":
            return "Зв'яжіться з технічною підтримкою."
        return super().handle_request(request)


class GeneralSupportHandler(SupportHandler):
    def handle_request(self, request):
        if request == "general":
            return "Зв'яжіться з загальною підтримкою."
        return super().handle_request(request)


def main():
    # Створюємо ланцюжок обробників
    general_handler = GeneralSupportHandler()
    technical_handler = TechnicalSupportHandler(general_handler)
    billing_handler = BillingSupportHandler(technical_handler)

    # Початковий обробник
    handler = billing_handler

    while True:
        print("\nСистема підтримки користувачів")
        print("1. Проблеми з оплатою")
        print("2. Технічні проблеми")
        print("3. Загальні питання")
        print("4. Вихід")
        choice = input("Виберіть опцію: ")

        if choice == "1":
            response = handler.handle_request("billing")
        elif choice == "2":
            response = handler.handle_request("technical")
        elif choice == "3":
            response = handler.handle_request("general")
        elif choice == "4":
            print("Дякуємо за використання системи підтримки користувачів. До побачення!")
            break
        else:
            response = "Некоректний вибір. Будь ласка, спробуйте ще раз."

        print(response)


if __name__ == "__main__":
    main()
