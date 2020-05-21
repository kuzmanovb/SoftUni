function checkLeapYear(year){
    if (year % 4 === 0 && year % 100 !== 0 || year % 400 === 0 ) {
        return 'yes';
    }
    else{
        return 'no';
    }
}

console.log(checkLeapYear(1984));
console.log(checkLeapYear(2003));
console.log(checkLeapYear(2000));
console.log(checkLeapYear(4));
