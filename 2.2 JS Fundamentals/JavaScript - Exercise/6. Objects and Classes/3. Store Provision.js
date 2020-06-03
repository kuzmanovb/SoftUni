function storeProvision(arrOne, arrTwo) {

    let store = [];

    for (let i = 0; i < arrOne.length; i += 2) {

        let name = arrOne[i];
        let quantity = +arrOne[i + 1];

        store.push({ name: name, quantity: quantity });
    }

    for (let y = 0; y < arrTwo.length; y += 2) {

        let indexProduct = store.findIndex(x => x.name === arrTwo[y]);

        if (indexProduct > -1) {

            store[indexProduct].quantity += Number(arrTwo[y + 1]);
        }
        else {

            let name = arrTwo[y];
            let quantity = +arrTwo[y + 1];
            store.push({ name: name, quantity: quantity });
        }
    }

    store.forEach(x => console.log(`${x.name} -> ${x.quantity}`));
}

storeProvision([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
)