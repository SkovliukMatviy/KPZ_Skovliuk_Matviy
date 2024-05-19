const fs = require('fs');

class BaseNode {
    constructor() {}

    getMemoryUsage() {
        let memory = 0;

        if (this.children) {
            this.children.forEach(child => {
                memory += child.getMemoryUsage();
            });
        }

        return memory;
    }
}

class TextNode extends BaseNode {
    constructor(content) {
        super();
        this.content = content;
    }

    getMemoryUsage() {
        return Buffer.byteLength(this.content, 'utf8');
    }
}

class ElementNode extends BaseNode {
    constructor(tag, style, closure, classes) {
        super();
        this.tag = tag;
        this.style = style;
        this.closure = closure;
        this.classes = classes;
        this.children = [];
    }

    appendChild(node) {
        this.children.push(node);
    }

    renderOuterHtml() {
        let output = `<${this.tag} class="${this.classes.join(" ")}" style="${this.style}" closure="${this.closure}">\n`;
        this.children.forEach(child => {
            output += `\t${child.renderOuterHtml()}\n`;
        });
        if (this.closure === "closed") {
            output += `</${this.tag}>`;
        }
        return output;
    }

    renderInnerHtml() {
        let output = "";
        this.children.forEach(child => {
            output += child.renderInnerHtml();
        });
        return output;
    }

    getMemoryUsage() {
        let memory = 0;

        this.children.forEach(child => {
            memory += child.getMemoryUsage();
        });

        return memory;
    }
}

class TextFactory {
    constructor() {
        this.textCache = {};
    }

    createText(content) {
        if (!this.textCache[content]) {
            this.textCache[content] = new TextNode(content);
        }
        return this.textCache[content];
    }
}

function loadTextFromFile(filePath) {
    try {
        return fs.readFileSync(filePath, 'utf8');
    } catch (error) {
        console.error('Error reading the file:', error);
        return null;
    }
}

function convertTextToHTML(content, textFactory) {
    const lines = content.split('\n');
    let html = '';

    lines.forEach((line, index) => {
        if (index === 0) {
            html += `<h1>${line.trim()}</h1>\n`;
        } else if (line.trim() === '') {
            return;
        } else if (line.trim().length < 20) {
            html += `<h2>${line.trim()}</h2>\n`;
        } else if (line.startsWith(' ')) {
            html += `<blockquote>${line.trim()}</blockquote>\n`;
        } else {
            html += `<p>${line.trim()}</p>\n`;
        }
    });

    html = `<div>\n${html}</div>`;
    return html;
}

const filePath = 'D:\\Лаби ІПЗ_22_4\\2 Курс\\2 Семестр\\Конструювання програмного забезпеч\\KPZ_Skovliuk_Matviy\\Lab3\\task6\\TEXT.txt';
const bookContent = loadTextFromFile(filePath);

if (bookContent) {
    const textFactory = new TextFactory(); // Creating text factory

    const header1Text = textFactory.createText("Primary Header");
    const header2Text = textFactory.createText("Secondary Header");
    const paragraphText = textFactory.createText("Sample paragraph text");

    const generatedHTML = convertTextToHTML(bookContent, textFactory);
    console.log(generatedHTML);

    const htmlStructure = new ElementNode("div", "block", "closed", ["container"]);

    const header1 = new ElementNode("h1", "block", "closed", ["main-title"]);
    const header2 = new ElementNode("h2", "block", "closed", ["sub-title"]);
    const paragraph = new ElementNode("p", "block", "closed", ["paragraph"]);

    header1.appendChild(header1Text);
    header2.appendChild(header2Text);
    paragraph.appendChild(paragraphText);

    htmlStructure.appendChild(header1);
    htmlStructure.appendChild(header2);
    htmlStructure.appendChild(paragraph);

    const totalMemoryUsage = htmlStructure.getMemoryUsage();
    console.log(`Memory Usage: ${totalMemoryUsage} bytes`);
}
