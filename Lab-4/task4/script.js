
// Абстрактний клас для загальної стратегії завантаження зображень
class AbstractImageLoadingStrategy {
    loadImage(src) {
        const image = document.createElement("img");
        image.src = src;
        image.onerror = () => {
            console.error("Не вдалося завантажити зображення:", src);
        };
        return image;
    }
}

// Стратегія завантаження зображень з локальної файлової системи
class LocalFileSystemImageStrategy extends AbstractImageLoadingStrategy {}

// Стратегія завантаження зображень з Інтернету
class InternetImageStrategy extends AbstractImageLoadingStrategy {
    loadImage(src) {
        const image = document.createElement("img");
        image.onload = () => {
            document.body.appendChild(image);
        };
        image.onerror = () => {
            console.error("Не вдалося завантажити зображення:", src);
        };
        image.src = src;
    }
}

// Клас, що представляє зображення та застосовує певну стратегію для його завантаження
class Image {
    constructor(strategy) {
        this.strategy = strategy;
    }

    // Метод для завантаження зображення
    loadImage(src) {
        if (!this.strategy) {
            console.error("Стратегія завантаження зображення не вказана.");
            return;
        }
        const image = this.strategy.loadImage(src);
        if (!(this.strategy instanceof InternetImageStrategy)) {
            document.body.appendChild(image);
        }
    }
}

// Створення екземплярів стратегій завантаження зображень
const localFileSystemStrategy = new LocalFileSystemImageStrategy();
const internetStrategy = new InternetImageStrategy();

// Створення екземплярів зображень та використання різних стратегій завантаження
const localImage = new Image(localFileSystemStrategy);
const onlineImage = new Image(internetStrategy);

// Завантаження зображень за допомогою створених екземплярів
localImage.loadImage("/picture/dog.jpg");
onlineImage.loadImage("https://wellbeloved.com/cdn/shop/articles/cat.jpg");
