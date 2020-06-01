function sortArrByTwoCriteria(arr) {

    arr.sort(function (a, b) {
        if (a.length < b.length) {
            return -1;
        }
        if (a.length > b.length) {
            return 1;
        }
        if (a.length == b.length) {
            if (a < b) {
                return -1;
            }
            if (a > b) {
                return 1;
            }
        }
        return 0;
    });
    
    console.log(arr.join('\n'));

}

sortArrByTwoCriteria(["alpha", "beta", "gamma"]);
sortArrByTwoCriteria(["Isacc", "Theodor", "Jack", "Harrison", "George"]);