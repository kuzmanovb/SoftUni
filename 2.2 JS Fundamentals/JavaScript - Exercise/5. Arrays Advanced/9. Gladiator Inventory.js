function gladiator(input) {
    let inventory = input.shift().split(' ');

    for (const item of input) {

        let command = item.split(' ')[0];
        let element = item.split(' ')[1];

        if (command == 'Buy') {

            if (!inventory.includes(element)) {
                inventory.push(element);
            }
        }
        else if (command == 'Trash') {

            if (inventory.includes(element)) {
                let indexElement = inventory.indexOf(element);
                inventory.splice(indexElement, 1);
            }
        }
        else if (command == 'Repair') {

            if (inventory.includes(element)) {
                let indexElement = inventory.indexOf(element);
                let repairElement = inventory.splice(indexElement, 1);
                inventory.push(repairElement);
            }
        }
        else if (command == 'Upgrade') {

            let nameElement = element.split('-')[0];

            if (inventory.includes(nameElement)) {

                let indexElement = inventory.indexOf(nameElement);
                inventory.splice(indexElement + 1, 0, element.replace('-', ':'));
            }
        }
    }

    console.log(inventory.join(' '));
}

gladiator(['SWORD Shield Spear',
    'Buy Bag',
    'Trash Shield',
    'Repair Spear',
    'Upgrade SWORD-Steel']
);

gladiator(['SWORD Shield Spear',
    'Trash Bow',
    'Repair Shield',
    'Upgrade Helmet-V']
);