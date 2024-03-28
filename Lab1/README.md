# Лабораторна робота 1, Сковлюка Матвія

## Принципи програмування в коді

### 1. DRY (Don't Repeat Yourself):

**Опис:**
DRY означає уникання дублювання коду. Це забезпечує легку зміну і підтримку коду.

**Демонстрація в коді:**
В коді, який стосується створення об'єктів та їх взаємодії, використовується ([спільний шаблон класу](https://github.com/SkovliukMatviy/KPZ_Skovliuk_Matviy/blob/main/Lab1/documents.js#L2)) для всіх документів, забезпечуючи перевикористання коду.

### 2. KISS (Keep It Simple, Stupid):

**Опис:**
KISS стверджує, що простий код – це кращий код. Складність повинна бути уникнена.

**Демонстрація в коді:**
Код для створення документів і їхніх взаємодій є ([простим і зрозумілим](https://github.com/SkovliukMatviy/KPZ_Skovliuk_Matviy/blob/main/Lab1/documents.js#L14)), що полегшує розширення і підтримку.

### 3. SOLID (Single Responsibility Principle):

**Опис:**
SOLID - це аббревіатура п'яти принципів: Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion. Кожен з цих принципів спрямований на створення гнучких, розширюваних та підтримуваних систем.

**Демонстрація в коді:**
Один з SOLID принципів, наприклад, ([Single Responsibility Principle](https://github.com/SkovliukMatviy/KPZ_Skovliuk_Matviy/blob/main/Lab1/documents.js#L22)), можна побачити в тому, як кожен клас в коді виконує лише одну задачу.

### 4. Composition Over Inheritance:

**Опис:**
Composition Over Inheritance вказує на те, що краще використовувати композицію об'єктів, ніж успадкування класів, для досягнення більшої гнучкості та обмеження залежностей.

**Демонстрація в коді:**
У коді використовується ([композиція](https://github.com/SkovliukMatviy/KPZ_Skovliuk_Matviy/blob/main/Lab1/documents.js#L2)), яка дозволяє динамічно складати функціональність документів.

### 5. Program to Interfaces not Implementations:

**Опис:**
Цей принцип підказує націлювати програмування на інтерфейси, а не конкретні реалізації.

**Демонстрація в коді:**
Класи документів взаємодіють через ([спільний інтерфейс](https://github.com/SkovliukMatviy/KPZ_Skovliuk_Matviy/blob/main/Lab1/documents.js#L2)), що дозволяє легко додавати нові типи документів.

### 6. Fail Fast:

**Опис:**
Fail Fast вказує на те, що програма має негайно виявляти помилки та завершувати виконання.

**Демонстрація в коді:**
Код ([відображення документів в контейнері](https://github.com/SkovliukMatviy/KPZ_Skovliuk_Matviy/blob/main/Lab1/documents.js#L42)) має перевірку на наявність контейнера перед додаванням документів.
