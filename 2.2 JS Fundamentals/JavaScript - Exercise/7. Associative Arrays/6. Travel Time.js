function travelTime(input) {

    let countries = {};

    for (const token of input) {

        let [country, city, cost] = token.split(' > ').filter(e => e !== "");

        if (countries.hasOwnProperty(country)) {

            if (countries[country].hasOwnProperty(city)) {

                if (countries[country][city] > +cost) {
                    
                    countries[country][city] = +cost;
                }
            }
            else {

                countries[country][city] = +cost;
            }
        }
        else {

            countries[country] = { [city]: +cost }
        }
    }
    
    let countriesKeys = Object.keys(countries).sort((a, b) => a.localeCompare(b));

    for (const country of countriesKeys) {

        let forPrint = `${country} ->`;

        let curentSities = Object.entries(countries[country]);
        curentSities.sort((a, b) => a[1] - b[1]);

        for (const [sity, cost] of curentSities) {

            forPrint += ` ${sity} -> ${cost}`
        }

        console.log(forPrint);
    }
}



travelTime([
    "Bulgaria > Sofia > 500",
    "Bulgaria > Sopot > 800",
    "France > Paris > 2000",
    "Albania > Tirana > 1000",
    "Bulgaria > Sofia > 200"
]
)
console.log();

travelTime(['Bulgaria > Sofia > 25000',
'aaa > Sofia > 1',
'aa > Orgrimar > 0',
'Albania > Tirana > 25000',
'zz > Aarna > 25010',
'Bulgaria > Lukovit > 10']
)
console.log();

travelTime(['Bulgaria > Sofia > 25000',
'Bulgaria > Sofia > 25000',
'Kalimdor > Orgrimar > 25000',
'Albania > Tirana > 25000',
'Bulgaria > Aarna > 25010',
'Bulgaria > Lukovit > 10']
)