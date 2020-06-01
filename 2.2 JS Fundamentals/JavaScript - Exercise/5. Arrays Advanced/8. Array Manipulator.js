function arrManipulator(arr, commands) {

    for (const command of commands) {

        let curentCommand = command.split(' ');

        if (curentCommand[0] == 'add') {

            let index = +curentCommand[1];
            let element = +curentCommand[2];

            arr.splice(index, 0, element);
        }
        else if (curentCommand[0] == 'addMany') {

            let index = +curentCommand[1];
            let elements = curentCommand.slice(2).map(x => Number(x));

            arr.splice(index, 0, ...elements);
        }
        else if (curentCommand[0] == 'contains') {

            let element = +curentCommand[1];

            console.log(arr.indexOf(element));
        }
        else if (curentCommand[0] == 'remove') {

            let index = +curentCommand[1];
            arr.splice(index, 1);
        }
        else if (curentCommand[0] == 'shift') {

            let positions = +curentCommand[1];

            for (let i = 0; i < positions; i++) {

                let first = arr.shift();
                arr.push(first);
            }
        }
        else if (curentCommand[0] == 'sumPairs') {

            for (let i = 0; i < arr.length; i++) {

                let firstElement = arr[i];
                let secondElement = arr[i + 1];

                if (firstElement !== undefined && secondElement !== undefined) {

                    let sum = firstElement + secondElement;
                    arr.splice(i, 2, sum);
                }
            }
        }
        else if (curentCommand[0] == 'print') {

            console.log('[ ' + arr.join(', ') + ' ]');
            break;
        }
    }
}

arrManipulator([1, 2, 4, 5, 6, 7], ['add 1 8', 'contains 1', 'contains 3', 'print']);
arrManipulator([1, 2, 3, 4, 5], ['addMany 5 9 8 7 6 5', 'contains 15', 'remove 3', 'shift 1', 'print']);
arrManipulator([1, 2, 3, 4, 5], ['sumPairs', 'print', 'contains 1']);
rManipulator([1, 2, 3, 4, 5, 6], ['addMany 5 9 8 7 6 5', 'print', 'contains 1']);