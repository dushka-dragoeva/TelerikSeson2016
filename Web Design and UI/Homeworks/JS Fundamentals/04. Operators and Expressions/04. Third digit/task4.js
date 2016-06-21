'use strict';
function solve(args) {
   var num = +args[0];
    var thirdDigit = (num/100|0)%10;

    if(thirdDigit===7){
         console.log('true');
    } else{
    console.log('false ' + thirdDigit);
    }
}

solve([706]);
solve([23706]);
solve([888306]);