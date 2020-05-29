function solve(numOne, numTwo, numThree) {

    let sumFirstTwoNumber = (a, b) => a + b;
    let result = (func, c) => func - c;

   console.log(result(sumFirstTwoNumber(numOne, numTwo), numThree));
    
}

solve(23, 6, 10);