function oddNumberElements(input) {

    let elements = [];

    for (let token of input.split(' ')) {

        token = token.toLowerCase();

        let indexElement = elements.findIndex(e => Object.keys(e)[0] == token);
        
        if (indexElement > -1) {

            elements[indexElement][token] ++;
        }
        else {
            
            let obj = { [token]: 1 };
            elements.push(obj);
        }
    }

    let oddElements = [];

    for (let i = 0; i < elements.length; i++) {

        if (Object.values(elements[i]) % 2 !== 0) {

            oddElements.push(Object.keys(elements[i])[0]);
        }
    }

    console.log(oddElements.join(' '));
}

oddNumberElements('Java C# Php PHP Java PhP 3 C# 3 1 5 C#')
//oddNumberElements('C# C#')