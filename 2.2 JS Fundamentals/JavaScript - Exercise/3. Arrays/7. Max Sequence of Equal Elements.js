function maxSequence(arr) {

    let firstIndex = 0;
    let bestSequence = 0;

    for (let i = 0; i < arr.length; i++) {

        let curentSequemce = 1;

        for (let y = i; y < arr.length; y++) {

            let one = arr[y];
            let two = arr[+y + 1];
            
            if (arr[y] === arr[y + 1]) {
                curentSequemce++;
            }
            else {
                break;
            }
        }

        if (curentSequemce > bestSequence) {
            bestSequence = curentSequemce;
            firstIndex = i;
        }

    }

    console.log(arr.slice(firstIndex, firstIndex + bestSequence).join(' '));
}
    

maxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
maxSequence([1, 1, 1, 2, 3, 1, 3, 3]);
maxSequence([4, 4, 4, 4]);
maxSequence([0, 1, 1, 5, 2, 2, 6, 3, 3]);