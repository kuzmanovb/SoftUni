function dungeonestDark(input) {

    let rooms = input[0].split('|');
    let health = 100;
    let coins = 0;
    let check = true;

    for (let i = 0; i < rooms.length; i++) {

        let room = rooms[i].split(' ');

        if (room[0] === 'potion') {

            let healthForAdd = Number(room[1]);

            if (health + healthForAdd > 100) {

                console.log(`You healed for ${100 - health} hp.`);
                health = 100;
            }
            else {

                console.log(`You healed for ${healthForAdd} hp.`);
                health += healthForAdd;
            }

            console.log(`Current health: ${health} hp.`);

        }
        else if (room[0] === 'chest') {

            let foundCoins = Number(room[1]);
            coins += foundCoins;

            console.log(`You found ${foundCoins} coins.`);

        }
        else {

            let monsterName = room[0];
            let damage = room[1];

            if (health - damage <= 0) {

                console.log(`You died! Killed by ${monsterName}.`);
                console.log(`Best room: ${i + 1}`);
                check = false;
                break;
            }
            else {

                health -= damage;
                console.log(`You slayed ${monsterName}.`);
            }

        }
    }

    if (check) {

        console.log(`You've made it!`);
        console.log(`Coins: ${coins}`);
        console.log(`Health: ${health}`);
    }
}

dungeonestDark(['rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000']);
console.log();
dungeonestDark(['cat 10|potion 30|orc 10|chest 10|snake 25|chest 110']);