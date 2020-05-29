function oddAndEvenSum(number){

    let numberArr = (number + '').split('');
    let odd = 0;
    let even = 0;

    for (let i = 0; i < numberArr.length; i++) {

        let curentNumber = Number(numberArr[i]);

        if (curentNumber % 2 === 0) {
            even += curentNumber;
        }
        else{
            odd += curentNumber;
        }
    }

    console.log(`Odd sum = ${odd}, Even sum = ${even}`);
}

oddAndEvenSum( 1000435);
oddAndEvenSum( 3495892137259234);