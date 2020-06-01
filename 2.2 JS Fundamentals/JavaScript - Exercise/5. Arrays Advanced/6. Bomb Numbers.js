function bombNumber(arr, bomb) {

    let bombNum = bomb[0];
    let bombPower = bomb[1];

    for (let i = 0; i < arr.length; i++) {

        if (arr[i] == bombNum) {

            for (let y = 1; y <= bombPower; y++) {

                arr[i + y] = 0;
                arr[i - y] = 0;
            }

            arr[i] = 0;
        }
    }

    let sumArr = 0;
    for (const item of arr) {
        sumArr += item;
    }

    console.log(sumArr);
}

bombNumber([1, 2, 2, 4, 2, 2, 2, 9], [4, 2]);
bombNumber([1, 4, 4, 2, 8, 9, 1], [9, 3]);
bombNumber([1, 7, 7, 1, 2, 3], [7, 1]);
bombNumber([1, 1, 2, 1, 1, 1, 2, 1, 1, 1], [2, 1]);
bombNumber([2, 1, 1], [2, 1]);