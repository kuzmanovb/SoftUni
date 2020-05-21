function numberDivisibleTo(number) {
    
    let division = 0; 

    if (number % 10 === 0) {
        division = 10;
    } else if (number % 7 === 0) {
        division = 7;
    } else if (number % 6 === 0) {
        division = 6;
    } else if (number % 3 === 0) {
        division = 3;
    } else if (number % 2 === 0) {
        division = 2;
    }

    if (division > 0) {
        return `The number is divisible by ${division}`;
    } else {
        return 'Not divisible';
    }
}


console.log(numberDivisibleTo(30));
console.log(numberDivisibleTo(15));
console.log(numberDivisibleTo(12));
console.log(numberDivisibleTo(1643));
