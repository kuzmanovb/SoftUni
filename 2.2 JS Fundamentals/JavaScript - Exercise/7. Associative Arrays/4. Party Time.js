function partyTime(input) {

    let vipList = [];
    let regularList = [];


    while (true) {

        let guest = input.shift();

        if (guest === 'PARTY') {
            break;
        }
        else if (Number(guest.substring(0, 1))) {

            vipList.push(guest);
        }
        else {

            regularList.push(guest);
        }
    }

    while (input.length > 0) {

        let guestCome = input.shift();

        let indexFromVip = vipList.findIndex(x => x == guestCome);
        let indexFromregular = regularList.findIndex(x => x == guestCome);

        if (indexFromVip > -1) {

            vipList.splice(indexFromVip, 1);
        }
        if (indexFromregular > -1) {

            regularList.splice(indexFromregular, 1);
        }
    }

    console.log(vipList.length + regularList.length);
    if (vipList.length > 0) {

        console.log(vipList.join('\n'));
    }
    if (regularList.length > 0) {

        console.log(regularList.join('\n'));
    }
}

partyTime(['7IK9Yo0h',
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc',
    'tSzE5t0p',
    'PARTY',
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc']);

partyTime(['m8rfQBvl',
    'fc1oZCE0',
    'UgffRkOn',
    '7ugX7bm0',
    '9CQBGUeJ',
    '2FQZT3uC',
    'dziNz78I',
    'mdSGyQCJ',
    'LjcVpmDL',
    'fPXNHpm1',
    'HTTbwRmM',
    'B5yTkMQi',
    '8N0FThqG',
    'xys2FYzn',
    'MDzcM9ZK',
    'PARTY',
    '2FQZT3uC',
    'dziNz78I',
    'mdSGyQCJ',
    'LjcVpmDL',
    'fPXNHpm1',
    'HTTbwRmM',
    'B5yTkMQi',
    '8N0FThqG',
    'm8rfQBvl',
    'fc1oZCE0',
    'UgffRkOn',
    '7ugX7bm0',
    '9CQBGUeJ'
]);