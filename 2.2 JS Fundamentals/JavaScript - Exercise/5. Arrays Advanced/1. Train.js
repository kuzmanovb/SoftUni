function train(arr) {

    let wagons = arr[0].split(' ').map(x => Number(x));
    let maxCapacity = Number(arr[1]);

    for (let i = 2; i < arr.length; i++) {

        let command = arr[i].split(' ');

        if (command[0] === 'Add') {

            wagons.push(Number(command[1]));
        }
        else {

            let passangersForAdd = Number(command[0]);

            for (let y = 0; y < wagons.length; y++) {

                if (wagons[y] + passangersForAdd <= maxCapacity) {

                    wagons[y] += passangersForAdd;
                    break;
                }
            }
        }
    }

    console.log(wagons.join(' '));
}

train(['32 54 21 12 4 0 23',
    '75',
    'Add 10',
    'Add 0',
    '30',
    '10',
    '75']
);

train(['0 0 0 10 2 4',
    '10',
    'Add 10',
    '10',
    '10',
    '10',
    '8',
    '6']
);