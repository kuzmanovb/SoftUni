function LowerOrUpper(char){
    let charCode = char.charCodeAt(0);

    if (charCode >= 65 && charCode <= 90) {
        return 'upper-case';
    }
    else if (charCode >= 97 && charCode <= 122) {
        return 'lower-case';
    }
}

console.log(LowerOrUpper('L'));
console.log(LowerOrUpper('f'));
console.log(LowerOrUpper(','));
