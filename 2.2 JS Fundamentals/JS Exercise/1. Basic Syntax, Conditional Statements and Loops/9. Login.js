function checkLogin(arguments) {
    
    let user = arguments[0];

    for (let index = 1; index < arguments.length; index++) {
       
        let inputPassword = arguments[index].split('').reverse().join('');

        if (user === inputPassword) {
            
            console.log(`User ${user} logged in.`);
            break;
        }
        else{
            if (index < arguments.length - 1) {
                
                console.log('Incorrect password. Try again.');
            }
            else{
                console.log(`User ${user} blocked!`);
                
            }
        }
    }
}

checkLogin(['Acer','login','go','let me in','recA']);
console.log('');
checkLogin(['momo','omom']);
console.log('');
checkLogin(['sunny','rainy','cloudy','sunny','not sunny']);