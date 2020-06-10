function piccolo(input) {

    let parking = [];

    for (const command of input) {

        let [direction, number] = command.split(', ');
        let indexCar = parking.findIndex(c => c == number);

        if (direction == 'IN') {

            if (indexCar == -1) {

                parking.push(number);
            }
        }
        else if (direction == 'OUT') {

            if (indexCar > -1) {

                parking.splice(indexCar, 1);
            }
        }
    }

    parking.sort((a, b) => a.localeCompare(b));

    if (parking.length == 0) {

        console.log('Parking Lot is Empty');
    }
    else {
        parking.forEach(p => console.log(p));
    }
}

piccolo(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU']
);

piccolo(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA']
)