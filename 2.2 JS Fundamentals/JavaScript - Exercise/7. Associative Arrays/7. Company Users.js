function companyEmployees(input) {

    let companies = {};

    for (const info of input) {

        let [company, id] = info.split(' -> ');

        if (companies.hasOwnProperty(company)) {

            if (!companies[company].some(x => x == id)) {

                companies[company].push(id);
            }
        }
        else {

            companies[company] = [];
            companies[company].push(id);
        }
    }

    let companiesKey = Object.keys(companies).sort((a, b) => a.localeCompare(b))

    for (const name of companiesKey) {

        console.log(name);

        for (const i of companies[name]) {

            console.log(`-- ${i}`);
        }
    }
}

companyEmployees([
    'SoftUni -> AA12345',
    'SoftUni -> BB12345',
    'Microsoft -> CC12345',
    'HP -> BB12345'
]);

companyEmployees([
    'SoftUni -> AA12345',
    'SoftUni -> CC12344',
    'Lenovo -> XX23456',
    'SoftUni -> AA12345',
    'Movement -> DD11111'
])

