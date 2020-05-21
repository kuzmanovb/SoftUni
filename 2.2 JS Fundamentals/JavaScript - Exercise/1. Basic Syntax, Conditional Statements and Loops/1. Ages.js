function  determinesPerson(age) {

    if (age >= 0 && age <= 2) {
        return 'baby';
    } else if (age >= 3 && age <= 13) {
        return 'child';
    } else if (age >= 14 && age <= 19) {
        return 'teenager';
    } else if (age >= 20 && age <= 65) {
        return 'adult';
    } else if (age >= 66) {
        return 'elder';
    } else {
        return 'out of bounds';
    }

}

console.log(determinesPerson(-1));
console.log(determinesPerson(3));
console.log(determinesPerson(14));
console.log(determinesPerson(20));
console.log(determinesPerson(67));
