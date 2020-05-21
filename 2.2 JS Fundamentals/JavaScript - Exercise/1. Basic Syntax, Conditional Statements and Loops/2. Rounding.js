function rounding(number, precision) {

    if (precision > 15) {
        precision = 15;
    }

    let precisionNumber = number.toFixed(precision);
    console.log(parseFloat(precisionNumber));
}

