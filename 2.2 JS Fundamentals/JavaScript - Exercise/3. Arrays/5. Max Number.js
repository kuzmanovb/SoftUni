function maxNumbers(arr) {

    let outputArr = arr;

    for (let i = 0; i < outputArr.length; i++) {

        let curentNumber = outputArr[i];
        let biggerNumberRight = Number.MIN_SAFE_INTEGER;

        for (let y = i + 1; y < outputArr.length; y++) {

            if (biggerNumberRight < outputArr[y]) {
                biggerNumberRight = outputArr[y];
            }
        }

        if (curentNumber <= biggerNumberRight) {
            outputArr.splice(i, 1);
            i -= 1;
        }
       
    }

    console.log(outputArr.join(' '));
}


maxNumbers([1, 4, 3, 2]);
maxNumbers([14, 24, 3, 19, 15, 17]);
maxNumbers([41, 41, 34, 20]);
maxNumbers([27, 19, 42, 2, 13, 45, 48]);
maxNumbers([5, 7, 1, 7]);
maxNumbers([-2, -2]);