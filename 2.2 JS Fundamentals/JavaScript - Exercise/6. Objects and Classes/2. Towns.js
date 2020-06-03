function townsInfo(input) {

    for (const item of input) {

        let info = item.split(' | ');

        let newObj = {

            town: info[0],
            latitude: parseFloat(+info[1]).toFixed(2),
            longitude: parseFloat(+info[2]).toFixed(2),
        };

        console.log(newObj);
    }
}

townsInfo(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']
);