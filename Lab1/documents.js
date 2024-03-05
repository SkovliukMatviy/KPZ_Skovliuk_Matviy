class Document {
    constructor(name, photo, ownerName) {
        this.name = name;
        this.photo = photo;
        this.ownerName = ownerName;
    }

    showInfo() {
        console.log(`Показати інформацію для ${this.name}`);
    }

    generateQR() {
        console.log(`Згенерувати QR-код для ${this.name}`);
    }
}

class DriverLicense extends Document {
    registerCar() {
        console.log(`Зареєструвати авто для власника ${this.name}`);
    }
}

class MilitaryID extends Document {
    hideInfo() {
        console.log(`Приховати інформацію для ${this.name}`);
    }

    copyID() {
        console.log(`Скопіювати ID для ${this.name}`);
    }
}

class DocumentContainer {
    constructor() {
        this.documents = [];
    }

    addDocument(document) {
        this.documents.push(document);
    }

    render() {
        const container = document.getElementById('documentContainer');
        container.innerHTML = '';

        this.documents.forEach((document) => {
            const documentElement = this.createDocumentElement(document);
            container.appendChild(documentElement);
        });
    }

    createDocumentElement(document) {
        const element = document.createElement('div');
        element.classList.add('document');
        element.innerHTML = `
      <h2>${document.name}</h2>
      <img src="${document.photo}" alt="${document.name} фото">
      <p>Ім'я: ${document.ownerName}</p>
      <button onclick="documents['${document.name.toLowerCase()}'].showInfo()">Показати інфо</button>
      <button onclick="documents['${document.name.toLowerCase()}'].generateQR()">Згенерувати QR</button>
    `;
        return element;
    }
}

const documents = {
    passport: new Document('Паспорт', 'паспорт.jpg', 'Сковлюк Матвій'),
    driverLicense: new DriverLicense('Водійське посвідчення', 'водійське.jpeg', 'Сковлюк Матвій'),
    militaryID: new MilitaryID('Військовий квиток', 'military_id.jpg', 'Сковлюк Матвій'),
};

const documentContainer = new DocumentContainer();
Object.values(documents).forEach((document) => documentContainer.addDocument(document));
documentContainer.render();
