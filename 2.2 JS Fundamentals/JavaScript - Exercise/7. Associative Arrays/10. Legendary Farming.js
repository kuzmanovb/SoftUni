function farming(input) {

    let arrInput = input.split(' ');

    let items = { 'fragments': 0, 'shards': 0, 'motes': 0 };

    for (let i = 0; i < arrInput.length; i += 2) {

        let quantity = Number(arrInput[i]);
        let currentItem = arrInput[i + 1].toLowerCase();

        if (items.hasOwnProperty(currentItem)) {

            items[currentItem] += quantity;
        }
        else {

            items[currentItem] = quantity;
        }

        if (items[currentItem] >= 250 && currentItem == 'shards') {

            console.log('Shadowmourne obtained!');
            items[currentItem] -= 250;
            break;
        }
        if (items[currentItem] >= 250 && currentItem == 'fragments') {

            console.log('Valanyr obtained!');
            items[currentItem] -= 250;
            break;
        }
        if (items[currentItem] >= 250 && currentItem == 'motes') {

            console.log('Dragonwrath obtained!');
            items[currentItem] -= 250;
            break;
        }
    }

    print();

    function print() {

        let arrItems = Object.entries(items).filter(x => x[0] == 'fragments' || x[0] == 'shards' || x[0] == 'motes');
        let arrJunk = Object.entries(items).filter(x => x[0] !== 'fragments' && x[0] != 'shards' && x[0] != 'motes');

        arrItems.sort(function compare(a, b) {
            if (a[1] > b[1]) {
                return -1;
            }
            if (a[1] < b[1]) {
                return 1;
            }
            return a[0].localeCompare(b[0]);
        });

        arrJunk.sort((a, b) => a[0].localeCompare(b[0]))

        arrItems.forEach(x => console.log(`${x[0]}: ${x[1]}`));
        arrJunk.forEach(x => console.log(`${x[0]}: ${x[1]}`));
    }
}

farming('3 Motes 5 stones 5 Shards 6 leathers 255 fragments 7 Shards');
console.log();
farming('123 silver 6 shards 8 shards 5 motes 9 fangs 75 motes 103 MOTES 8 Shards 86 Motes 7 stones 19 silver')
