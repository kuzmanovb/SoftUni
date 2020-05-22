function ConvertMeters(meters) {
    
    let kilometers = meters / 1000;

    return kilometers.toFixed(2);
}

console.log(ConvertMeters(1852));
