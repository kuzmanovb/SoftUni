function calculatePurchasedBitcoin(arguments) {

    let totalMoney = 0;
    let firstDayForPurchased = 0;

    for (let day = 1; day <= arguments.length; day++) {

        let gold = arguments[day - 1];

        if (day % 3 === 0) {

            gold *= 0.7;
        }

        totalMoney += gold * 67.51;

        if (totalMoney >= 11949.16 && firstDayForPurchased === 0) {
            firstDayForPurchased = day;
        }
    }

    let bitcoin = Math.floor(totalMoney / 11949.16);
    let leftMoney = totalMoney % 11949.16;

    console.log(`Bought bitcoins: ${bitcoin}`);
    if (bitcoin > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstDayForPurchased}`);
    }
    console.log(`Left money: ${leftMoney.toFixed(2)} lv.`);

}

calculatePurchasedBitcoin([50, 100]);
console.log();
calculatePurchasedBitcoin([3124.15, 504.212, 2511.124]);
console.log();
calculatePurchasedBitcoin([100,200,300]);
