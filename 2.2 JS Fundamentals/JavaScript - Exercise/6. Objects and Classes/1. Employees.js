function employeesList(input) {

    let employees = [];

    for (const item of input) {

        let newObj = { name: item, personalNumber: item.length };
        employees.push(newObj);
    }

    for (const item of employees) {

        console.log(`Name: ${Object.values(item)[0]} -- Personal Number: ${Object.values(item)[1]}`);
    }
}

employeesList([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]
)