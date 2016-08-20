'use strict';

function solve(args) {

    var biggestNum, index;

    biggestNum = +args[0];

    for (index = 1; index < 5; index++) {
        if (+args[index] > biggestNum) {

            biggestNum = args[index];
        }
    }
    console.log(biggestNum);
}