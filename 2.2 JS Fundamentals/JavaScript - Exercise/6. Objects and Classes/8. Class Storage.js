class Storage {

    constructor(capacity) {

        this.capacity = capacity;
        this.storage = [];
        this.totalCost = 0;
    }

    addProduct(product) {

        if (typeof (product.quantity) == 'number' && typeof (product.name) == 'string' &&
            typeof (product.price) == 'number' && this.capacity - product.quantity >= 0) {

            this.storage.push(product);
            this.capacity -= product.quantity;
            this.totalCost += product.price * product.quantity;
        }
    }

    getProducts() {

        let output =[];

        this.storage.forEach(product => {

            output.push(JSON.stringify(product));
        });

        return output.join('\n');
    }
}

let productOne = { name: 'Cucamber', price: 1.50, quantity: 15 };
let productTwo = { name: 'Tomato', price: 0.90, quantity: 25 };
let productThree = { name: 'Bread', price: 1.10, quantity: 8 };
let product0 = { name: 'Bread', price: 1.10, quantity: 4 };
let storage = new Storage(50);
storage.addProduct(productOne);
storage.addProduct(productTwo);
storage.addProduct(productThree);
storage.addProduct(product0);
storage.getProducts();
console.log(storage.capacity);
console.log(storage.totalCost);
