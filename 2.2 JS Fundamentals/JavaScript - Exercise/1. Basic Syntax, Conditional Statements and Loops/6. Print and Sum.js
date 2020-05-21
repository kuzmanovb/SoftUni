function printAndSum(startNumber, endNumber) {
    
    let sum = 0;
    let numberForPrint = '';

    for (let index = startNumber; index <= endNumber; index++) {
       
        sum += index;
        numberForPrint += index + ' ';
    }

    console.log(numberForPrint.trimEnd());
    console.log(`Sum: ${sum}`);
}

printAndSum(5, 10)