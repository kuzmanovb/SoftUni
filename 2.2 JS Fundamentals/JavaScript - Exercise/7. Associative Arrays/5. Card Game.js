function cardGame(input) {

    let players = [];

    for (const token of input) {

        let [name, cards] = token.split(': ');
        cards = cards.split(', ');

        let indexPlayer = players.findIndex(x => Object.keys(x)[0] == name);

        if (indexPlayer > -1) {
            cards.forEach(i => players[indexPlayer][name].add(i));
        }
        else {
            let newSet = new Set(cards);
            players.push({ [name]: newSet });
        }

    }

    players.forEach(x => console.log(printWhitSumCards(x)));
    
    function printWhitSumCards(input) {

        let name = Object.keys(input);
        let allCard = Object.values(input)[0].values();
        let sumCard = 0;

        for (const card of allCard) {

            let power;
            let type;
            if (card.length == 2) {
                
                power = card.split('')[0];
                type = card.split('')[1];
            }
            else{

                power = 10;
                type = card.substring(2, 3);

            }

            switch (power) {
                case 'J': power = 11; break;
                case 'Q': power = 12; break;
                case 'K': power = 13; break;
                case 'A': power = 14; break;
            }

            switch (type) {
                case 'S': type = 4; break;
                case 'H': type = 3; break;
                case 'D': type = 2; break;
                case 'C': type = 1; break;
            }

            sumCard += power * type;
        }

        return `${name}: ${sumCard}`;
    }
}

cardGame([
    'Peter: 2C, 4H, 9H, AS, QS',
    'Tomas: 3H, 10S, JC, KD, 5S, 10S',
    'Andrea: QH, QC, QS, QD',
    'Tomas: 6H, 7S, KC, KD, 5S, 10C',
    'Andrea: QH, QC, JS, JD, JC',
    'Peter: JD, JD, JD, JD, JD, JD'
]);

