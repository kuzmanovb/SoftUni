function equalSums(inputArr) {

    let sum = inputArr.reduce((acc, cur) => acc + cur, 0);
    let indexForPrint = -1;

    if (sum - inputArr[0] === 0 || inputArr.length === 1) {
        indexForPrint = 0;
    }
    else {

        for (let i = 0; i < inputArr.length; i++) {

            let curentSum = 0;

            for (let y = 0; y <= i; y++) {
                curentSum += inputArr[y];
            }

            if (curentSum === sum - inputArr[i + 1] - curentSum) {
                indexForPrint = i + 1;
            }
        }
    }

    if (indexForPrint === -1) {
        console.log('no');
    }
    else {
        console.log(indexForPrint);
    }

}

equalSums([1, 2, 3, 3]);
equalSums([10, 5, 5, 99, 3, 4, 2, 5, 1, 1, 4]);

equalSums([1]);
equalSums([1, 2, 3, -5]);

equalSums([1, 2]);
equalSums([1, 2, 3]);
