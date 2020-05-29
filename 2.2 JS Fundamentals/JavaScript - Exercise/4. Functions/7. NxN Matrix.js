function printMatix(number) {

    for (let i = 0; i < number; i++) {

        let printRow = '';

        for (let y = 0; y < number; y++) {

            printRow += number + ' '
        }

        console.log(printRow.trimEnd());
    }
}

printMatix(3)
printMatix(7)
printMatix(2)