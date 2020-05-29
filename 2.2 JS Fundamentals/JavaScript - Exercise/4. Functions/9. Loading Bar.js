function loadingBar(number) {

    let load = number / 10;

    let loadForPrint = '[..........]'.split('');

    for (let i = 0; i < load; i++) {

        loadForPrint[i + 1] = '%';
    }

    if (load === 10) {

        console.log('100% Complete!');
        console.log(loadForPrint.join(''));
    }
    else{

        console.log(`${number}% ${loadForPrint.join('')}`);
        console.log('Still loading...');
    }
}

loadingBar(30)
loadingBar(50)
loadingBar(100)