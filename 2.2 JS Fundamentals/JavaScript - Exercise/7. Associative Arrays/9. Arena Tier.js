function arenaTier(input) {

    let gladiators = new Map();

    for (const info of input) {

        let curentInfo = info.split(' -> ');

        if (curentInfo.length === 1) {

            if (curentInfo == 'Ave Cesar') {

                break;
            }

            let [firstGladiator, secondGladiator] = curentInfo[0].split(' vs ');

            for (const itemOne in gladiators[firstGladiator]) {

                for (const itemTwo in gladiators[secondGladiator]) {

                    if (itemOne == itemTwo) {

                        let totalSkillFirstGadiator = totalSkill(firstGladiator);
                        let totalSkillSecondGadiator = totalSkill(secondGladiator);

                        if (totalSkillFirstGadiator > totalSkillSecondGadiator) {

                            delete gladiators[secondGladiator];
                        }
                        else {

                            delete gladiators[firstGladiator]
                        }
                    }
                }
            }
        }
        else {

            let name = curentInfo[0];
            let technique = curentInfo[1];
            let skill = +curentInfo[2];

            if (gladiators.hasOwnProperty(name)) {

                if (gladiators[name].hasOwnProperty(technique)) {

                    if (gladiators[name][technique] < skill) {

                        gladiators[name][technique] = skill;
                    }
                }
                else {

                    gladiators[name][technique] = skill;
                }
            }
            else {

                gladiators[name] = { [technique]: skill };
            }
        }
    }

    printResult();


    function printResult() {

        let arrayWithTotalSkill = [];

        for (const key in gladiators) {

            let curentTotalSkill = totalSkill(key);

            arrayWithTotalSkill.push([key, curentTotalSkill]);
        }

        arrayWithTotalSkill.sort((a, b) => b[1] - a[1]);


        for (const gladiator of arrayWithTotalSkill) {

            console.log(`${gladiator[0]}: ${gladiator[1]} skill`);

            let arrSkills = Object.entries(gladiators[gladiator[0]]);
            arrSkills.sort(function compare(a, b) {
                if (a[1] > b[1]) {
                    return -1;
                }
                if (a[1] < b[1]) {
                    return 1;
                }
                return a[0].localeCompare(b[0]);
            });

            for (const [key, value] of arrSkills) {

                console.log(`- ${key} <!> ${value}`);
            }
        }
    }

    function totalSkill(gladiatorName) {

        let sum = 0;

        for (const key in gladiators[gladiatorName]) {

            sum += gladiators[gladiatorName][key];
        }

        return sum;
    }
}


arenaTier([
    'Peter -> BattleCry -> 400',
    'Alex -> PowerPunch -> 300',
    'Stefan -> Duck -> 200',
    'Stefan -> Tiger -> 250',
    'Ave Cesar'
]);
console.log();


arenaTier([
    'Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Peter vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Maximilian',
    'Ave Cesar'
]);