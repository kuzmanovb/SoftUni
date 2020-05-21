function triangleOfNumbers(number) {
    
    for (let i = 1; i <= number; i++) {
       
        let rowForPrint = '';
        for (let y = 0; y < i ; y++) {
           
            rowForPrint += i + ' ';
        }

        console.log(rowForPrint.trimEnd());
    }
}

triangleOfNumbers(6);