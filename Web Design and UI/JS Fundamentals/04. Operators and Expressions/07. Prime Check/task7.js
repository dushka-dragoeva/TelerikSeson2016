'use strict';

function solve(args) {
    var num = +args[0];
    var isPrime = true;
    var length = Math.sqrt(num)

    if (num <2) {
        isPrime = false;

    } else {
        for (var index = 2; index <=length; index += 1) {
            if (num % index===0) {
                isPrime = false;
                break;
            }
        }
    }
    
    console.log(isPrime);
}

solve([3.5]);
