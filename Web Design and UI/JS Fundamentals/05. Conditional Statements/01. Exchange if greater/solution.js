'use strict';

function solve(args) {
    var numA = +args[0];
    var numB = +args[1];

    if (numA > numB) {
        var temp = numA;
        numA = numB;
        numB = temp;
    }

    console.log(numA + " " + numB);
} 