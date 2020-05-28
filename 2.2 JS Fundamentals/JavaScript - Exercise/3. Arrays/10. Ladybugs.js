function bugs(input) {

    let lengthArr = input[0];
    let indexesToBugs = input[1].split(' ');

    let arr = [];
    arr[lengthArr - 1] = 0;
    arr.fill(0, 0);

    for (let i = 0; i < indexesToBugs.length; i++) {

        if (indexesToBugs[i] >= 0 && indexesToBugs[i] < lengthArr) {

            arr[indexesToBugs[i]] = 1;
        }
    }

    for (let y = 2; y < input.length; y++) {

        let token = input[y].split(' ');
        let position = Number(token[0]);
        let direction = token[1];
        let numberToMove = Number(token[2]);


        if (arr[position] === 1) {

            arr[position] = 0;

            if (direction === 'right') {

                while (position + numberToMove < arr.length && position + numberToMove >= 0) {

                    if (arr[position + numberToMove] === 0) {
                        arr[position + numberToMove] = 1;
                        break;
                    }
                    else {
                        position += numberToMove;
                    }
                }
            }
            else {

                while (position - numberToMove >= 0 && position - numberToMove < arr.length) {

                    if (arr[position - numberToMove] === 0) {
                        arr[position - numberToMove] = 1;
                        break;
                    }
                    else {
                        position -= numberToMove;
                    }
                }
            }
        }
    }

    console.log(arr.join(' '));
}

bugs([3, '0 1', '0 right 1', '2 right 1']);
console.log();
bugs([3, '0 1 2', '0 right 1', '1 right 1', '2 right 1']);
console.log();
bugs([5, '3', '3 left 2', '1 left -2']);
