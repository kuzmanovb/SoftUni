function distinctArr(arr) {

    for (let i = 0; i < arr.length; i++) {

        let curentNumber = arr[i];
       
        for (let y = 0; y < i; y++) {
            
            if (arr[y] === curentNumber) {
                arr.splice(i,1);
                i--;
            }

        }
    }

    console.log(arr.join(' '));
    
}

distinctArr([1, 2, 3, 4]);
distinctArr([7, 8, 9, 7, 2, 3, 4, 1, 2]);
distinctArr([20, 8, 12, 13, 4, 4, 8, 5]);
