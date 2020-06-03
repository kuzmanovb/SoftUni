function inventaryToHeroes(input) {

    let heroes = [];

    for (const hero of input) {

        let [name, level, items] = hero.split(' / ');
        items = items.split(', ');
        heroes.push({ name: name, lelev: level, items: items });
    }

    heroes.sort((a, b) => a.lelev - b.lelev);
    heroes.forEach(h => h.items.sort(function compare(a, b) {
        if (a < b) {
          return -1;
        }
        if (a > b) {
          return 1;
        }
        return 0;
      }));

    for (const her of heroes) {

        console.log(`Hero: ${her.name}`);
        console.log(`level => ${her.lelev}`);
        console.log(`items => ${her.items.join(', ')}`);
    }
}

inventaryToHeroes([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara"
]
);