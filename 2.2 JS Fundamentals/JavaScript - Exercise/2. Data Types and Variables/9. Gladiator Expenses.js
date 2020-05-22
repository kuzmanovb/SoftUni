function repaierEquipment(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice) {

    let expenses = 0;
    let count = 0;

    for (let i = 1; i <= lostFights; i++) {

        if (i % 2 === 0) {
            expenses += helmetPrice;
        }
        if (i % 3 === 0) {
            expenses += swordPrice;
        }
        if (i % 3 === 0 && i % 2 === 0) {
            expenses += shieldPrice;
            count++;
        }
        if (count === 2) {
            expenses += armorPrice;
            count = 0;
        }
    }

    return `Gladiator expenses: ${expenses.toFixed(2)} aureus`

}

console.log(repaierEquipment(7, 2, 3, 4, 5));
console.log(repaierEquipment(23, 12.50, 21.50, 40, 200));
