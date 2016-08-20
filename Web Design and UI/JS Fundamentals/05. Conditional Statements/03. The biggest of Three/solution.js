'use strict';
function solve(args) {

    var numA = +args[0];
    var numB = +args[1];
    var numC = +args[2];

    var biggestNum = numA;

    if (numB > biggestNum) {
        if (numB > numC) {
            biggestNum = numB;
        }
        else {
            biggestNum = numC;
        }
    }
    else {
        if (numC > numA) {
            biggestNum = numC;
        }
    }

    console.log(biggestNum);
}

solve([-3, -4, -7]);