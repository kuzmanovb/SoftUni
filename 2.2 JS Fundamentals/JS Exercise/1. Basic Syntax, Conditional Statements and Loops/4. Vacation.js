function vacation(people, type, dayOfWeek) {

    let price = 0;

    if (type === 'Students') {
        if (dayOfWeek === 'Friday') {
            price = 8.45;
        } else if (dayOfWeek === 'Saturday') {
            price = 9.80;
        } else if (dayOfWeek === 'Sunday') {
            price = 10.46;
        }
    }
    else if (type === 'Business') {
        if (dayOfWeek === 'Friday') {
            price = 10.90;
        } else if (dayOfWeek === 'Saturday') {
            price = 15.60;
        } else if (dayOfWeek === 'Sunday') {
            price = 16.00;
        }
    }
    else if (type === 'Regular') {
        if (dayOfWeek === 'Friday') {
            price = 15.00;
        } else if (dayOfWeek === 'Saturday') {
            price = 20.00;
        } else if (dayOfWeek === 'Sunday') {
            price = 22.50;
        }
    }

    let totalPrice = people * price;

    if (type === 'Students' && people >= 30) {
        totalPrice *= 0.85;
    }
    else if (type === 'Business' && people >= 100) {
        totalPrice = (people - 10) * price;
    }
    else if (type === 'Regular' && people >= 10 && people <= 20) {
        totalPrice *= 0.95;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

vacation(30, "Students", "Sunday");
vacation(40, "Regular", "Saturday");
