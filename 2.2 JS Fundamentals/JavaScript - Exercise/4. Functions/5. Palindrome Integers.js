function palindrome(numbers) {

    for (let i = 0; i < numbers.length; i++) {

        let curentNum = numbers[i];
        let mirrorNum = Number((numbers[i] + '').split('').reverse().join(''));

        if (curentNum === mirrorNum) {

            console.log('true');
        }
        else{

            console.log('false');
        }
    }
}

palindrome([123,323,421,121]);
console.log();
palindrome([32,2,232,1010]);