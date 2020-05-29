function rangeChar(charOne, charTwo) {

    let asciiNumberToCharOne = charOne.charCodeAt(0);
    let asciiNumberToCharTwo = charTwo.charCodeAt(0);

    let start = asciiNumberToCharOne;
    let end = asciiNumberToCharTwo;

    if (asciiNumberToCharOne > asciiNumberToCharTwo) {

        start = asciiNumberToCharTwo;
        end = asciiNumberToCharOne;
    }

    let forPrint = '';

    for (let i = start + 1; i < end; i++) {

        forPrint += String.fromCharCode(i) + ' ';

    }

    console.log(forPrint);

}

rangeChar('a', 'd');
rangeChar('#', ':');
rangeChar('C', '#');