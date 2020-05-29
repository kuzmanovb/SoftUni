function passwordValidator(password) {

    let checkForTrue = true;

    if (password.length < 6 || password.length > 10) {

        console.log('Password must be between 6 and 10 characters');
        checkForTrue = false;
    }

    for (let i = 0; i < password.length; i++) {

        let code = password.charCodeAt(i);

        if ((code <= 47 || code >= 58) && (code <= 64 || code >= 91) && (code <= 96 || code >= 123)) {

            checkForTrue = false;
            console.log('Password must consist only of letters and digits');
            break;
        }
    }

    let countDigit = 0;

    for (let y = 0; y < password.length; y++) {

        let code = password.charCodeAt(y);

        if (code > 47 && code < 58) {
            countDigit++;
        }
    }

    if (countDigit < 2) {

        checkForTrue = false;
        console.log('Password must have at least 2 digits');
    }

    if (checkForTrue) {

        console.log('Password is valid');
    }
}


passwordValidator('logIn');
passwordValidator('MyPass123');
passwordValidator('Pa$s$s');
console.log();
passwordValidator('Paas1as')

