function catalogue(input) {

    let products = {};

    for (const token of input) {

        let curentToken = token.split(' : ');

        let curentKey = curentToken[0].substring(0, 1);

        if (Object.keys(products).some(x => x == curentKey)) {

            products[curentKey].push({ name: curentToken[0], price: curentToken[1] });
        }
        else {

            products[curentKey] = [{ name: curentToken[0], price: curentToken[1] }];
        }
    }

    let sortedKey = Object.keys(products).sort((a, b) => a.localeCompare(b))

    for (const key of sortedKey) {

        console.log(key);

        products[key].sort((a, b) => a.name.localeCompare(b.name));

        for (const product of products[key]) {
            
            console.log(`  ${product.name}: ${product.price}`);
        }
    }
}

catalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'

])