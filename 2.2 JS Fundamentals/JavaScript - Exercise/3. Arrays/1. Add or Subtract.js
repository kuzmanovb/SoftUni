function addOrSubtract(input) {

    let inputArr = input;
    let inputArraySum = input.reduce((acc, cur) => acc + cur, 0);

    for (let i = 0; i < inputArr.length; i++) {

        if (inputArr[i] % 2 === 0) {
            inputArr[i] += i;
        }
        else{
            inputArr[i] -= i;
        }

    }

    endArraySum = inputArr.reduce((acc, cur) => acc + cur, 0);

    console.log(inputArr);
    console.log(inputArraySum);
    console.log(endArraySum);
}

addOrSubtract([5, 15, 23, 56, 35]);
addOrSubtract([-5, 11, 3, 0, 2]);