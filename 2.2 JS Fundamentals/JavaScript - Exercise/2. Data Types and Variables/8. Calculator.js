function calculator(numberOne, symbol, numberTwo){
    let result = 0;
    
    if(symbol === '+'){
       result = numberOne + numberTwo;
    }
    else if (symbol === '-') {
        result = numberOne - numberTwo;
    }
    else if (symbol === '*') {
        result = numberOne * numberTwo;
    }
    else if (symbol === '/') {
        result = numberOne / numberTwo;
    }

    return result.toFixed(2);
}

console.log(calculator(5, '+', 10));
console.log(calculator(5, '-', 10));
console.log(calculator(5, '*', 10));
console.log(calculator(5, '/', 10));
