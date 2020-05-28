function magicSum(arr, number) {

    let print = '';

    for (let i = 0; i < arr.length; i++) {

        for (let y = i + 1; y < arr.length; y++) {

            if (arr[i] + arr[y] === number) {

                print = print + `${arr[i]} ${arr[y]}` + '\n';
                
            }
        }

    }

    console.log(print.trimEnd());
}

magicSum([1, 7, 6, 2, 19, 23], 8);
magicSum([14, 20, 60, 13, 7, 19, 8], 27);
magicSum([1, 2, 3, 4, 5, 6], 6);