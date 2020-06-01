function buildWall(input) {

    let days = [];
    let costCubic = 1900;
    let usingCubicPerDay = 195;

    while (input.some(x => x < 30)) {

        let cubicOfday = 0;

      for (let i = 0; i < input.length; i++) {
         
        if (input[i] < 30) {
            cubicOfday += usingCubicPerDay;
            input[i]++;
        }
      }
      
        days.push(cubicOfday);
    }

    let cost = days.length == 0 ? 0 : days.reduce((acc, el) => acc + el) * costCubic;

    console.log(days.join(', '));
    console.log(`${cost} pesos`);
}

buildWall([21, 25, 28]);
buildWall([17]);
buildWall([17, 22, 17, 19, 17]);
buildWall([30]);
