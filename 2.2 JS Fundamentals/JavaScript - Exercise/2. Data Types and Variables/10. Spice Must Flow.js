function calcolateSpiceAmount(yield) {

    let totalAmount = 0;
    let day = 0;

    while (yield >= 100) {

        totalAmount += yield;
        day ++;
        yield -= 10;

        totalAmount -= 26;
        if (totalAmount < 0) {
            totalAmount = 0;
        }
    }

    totalAmount -= 26;
    if (totalAmount < 0) {
        totalAmount = 0;
    }


    console.log(day);
    console.log(totalAmount);
}

console.log(calcolateSpiceAmount(111));
console.log(calcolateSpiceAmount(90));
