function searchNumber(arr, param) {

    let [take, del, number] = param;

    let newArr = arr.slice(0, take);
    newArr.splice(0, del);

    let count = 0;

    for (const num of newArr) {

        if (num == number) {
            count++;
        }
    }

    console.log(`Number ${number} occurs ${count} times.`);
}

searchNumber([5, 2, 3, 4, 1, 6], [5, 2, 3]);