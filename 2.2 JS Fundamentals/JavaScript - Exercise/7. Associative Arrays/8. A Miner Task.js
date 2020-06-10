function minerTask(input) {

    let resurces = new Map();

    for (let i = 0; i < input.length; i += 2) {

        let resurce = input[i];
        let quantity = Number(input[i + 1]);

        if (resurces.hasOwnProperty(resurce)) {

            resurces[resurce] += quantity;
        }
        else {
            resurces[resurce] = quantity;
        }
    }

    for (const key in resurces) {

        console.log(`${key} -> ${resurces[key]}`);
    }
}

minerTask([
    'Gold',
    '155',
    'Silver',
    '10',
    'Copper',
    '17'
]);

minerTask([
    'gold',
    '155',
    'silver',
    '10',
    'copper',
    '17',
    'gold',
    '15'
]);