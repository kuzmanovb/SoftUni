function factorialDivision(numOne, numTwo) {

    function factorialize(num) {
        if (num === 0 || num === 1)
            return 1;
        for (var i = num - 1; i >= 1; i--) {
            num *= i;
        }
        return num;
    }

    let factorialNumOne = factorialize(numOne);
    let factorialNumTwo = factorialize(numTwo);

    let result = factorialNumOne / factorialNumTwo

    console.log(result.toFixed(2));
}

factorialDivision(5, 2);
factorialDivision(6, 2);