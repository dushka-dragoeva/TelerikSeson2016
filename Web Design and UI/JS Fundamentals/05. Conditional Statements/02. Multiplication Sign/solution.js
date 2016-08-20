'use strict'; 
function solve(args) {

    var isPositive = true;
    var productSign = "0";

    for (var i = 0; i < 3; i++) {
        var number = +args[i];

        if (number !== 0) {
            if (number < 0) {
                isPositive = (!isPositive);
            }

            productSign = isPositive ? '+' : '-';
        }
        else {
            productSign = '0';
            break;
        }
    }

    console.log(productSign);
}

solve([-3, -4, -7]);