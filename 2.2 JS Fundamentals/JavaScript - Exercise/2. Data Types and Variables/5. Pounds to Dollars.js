function PoundsToDollars(pounds) {
    
    let dollars = pounds * 1.31;

    return dollars.toFixed(3);
}

console.log(PoundsToDollars(80));
