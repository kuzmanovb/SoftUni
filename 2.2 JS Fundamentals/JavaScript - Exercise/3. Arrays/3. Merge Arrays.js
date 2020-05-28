function margeArray(arrOne, arrTwo) {

    let outputArr = [];

    for (let i = 0; i < arrOne.length; i++) {

        if (i % 2 === 0) {
            
            let sum = Number(arrOne[i]) + Number(arrTwo[i]);
            outputArr.push(sum.toString());
        }
        else {
            outputArr.push(arrOne[i] + arrTwo[i]);
        }

    }

    console.log(outputArr.join(' - '));
}

console.log(margeArray(
    ['5', '15', '23', '56', '35'],
    ['17', '22', '87', '36', '11']
));
