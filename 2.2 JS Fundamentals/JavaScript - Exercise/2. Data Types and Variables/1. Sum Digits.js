function SumDigits(number) {
    let sum = 0;

    while (number > 0) {
        sum += number % 10;
        number = parseInt(number / 10);
    }

    return sum;
}

console.log(SumDigits(245678));
