function party(input) {

    let partyArr = [];

    for (const guest of input) {

        let guestArr = guest.split(' ');
        let nameOfGuest = guestArr[0];

        if (guestArr.includes('not')) {

            if (partyArr.includes(nameOfGuest)) {

                let indexOfGuest = partyArr.indexOf(nameOfGuest);
                partyArr.splice(indexOfGuest, 1);
            }
            else{

                console.log(`${nameOfGuest} is not in the list!`);
            }
        }
        else{

            if (partyArr.includes(nameOfGuest)) {

                console.log(`${nameOfGuest} is already in the list!`);
            }
            else{

                partyArr.push(nameOfGuest);
            }
        }
    }

    console.log(partyArr.join('\n'));
}

party(['Allie is going!',
'George is going!',
'John is not going!',
'George is not going!']
);

party(['Tom is going!',
'Annie is going!',
'Tom is going!',
'Garry is going!',
'Jerry is going!']
);