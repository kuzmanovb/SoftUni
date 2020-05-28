function arrayRotation(arr, number) {

    let outputArr = arr;

    for (let i = number; i > 0; i--) {

        let lastElements = outputArr.shift();
        outputArr.push(lastElements);
    }

    console.log(outputArr.join(' '));
}

arrayRotation([51, 47, 32, 61, 21], 2);
arrayRotation([32, 21, 61, 1], 4);
arrayRotation([2, 4, 15, 31], 5);