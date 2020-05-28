function commonElements(arrOne, arrTwo) {
   
let output = '';

    for (let i = 0; i < arrOne.length; i++) {
        
        let curentElement = arrOne[i];

        for (let y = 0; y < arrTwo.length; y++) {
            
            if (curentElement === arrTwo[y]) {
                
                output += curentElement + '\n';
            }
        }
    }
   
    return output;
}



console.log(
commonElements(
    ['Hey', 'hello', 2, 4, 'Peter', 'e'],
    ['Petar', 10, 'hey', 4, 'hello', '2']
    )
);