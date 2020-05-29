function smallNumber(numOne, numTwo, numThree) {

    let numForPrint;

    if (numOne > numTwo) {
        numForPrint = numTwo;
    }
    else{
        numForPrint = numOne;
    }

    if (numForPrint > numThree) {
        numForPrint = numThree;
    }

    console.log(numForPrint);
    
}

smallNumber(2, 5, 3);
smallNumber(600, 342, 123);
smallNumber(25, 21, 4);