function sortingArray(arr) {

    arr.sort((a, b) => a - b);

    let smallNumber = arr.slice(0, arr.length / 2);
    let bigNumber = arr.slice(arr.length / 2);
    bigNumber.reverse();

    let arrForPrint = [];

    for (let i = 0; i < bigNumber.length; i++) {

        arrForPrint.push(bigNumber[i]);
        arrForPrint.push(smallNumber[i]);
    }

    console.log(arrForPrint.join(' '));
}


sortingArray([1, 21, 3, 52, 69, 63, 31, 2, 18, 94]);