'use strict';

function solve(args) {

    var len = +args[0];
    var arr = args[1].split(' ').map(Number);
    var numToFind = +args[2];
    // console.log(arr);
    var counter = 0;

    for (var i = 0; i < len; i += 1) {
        if (arr[i] === numToFind) {

            counter += 1;
        }
    }
    console.log(counter);
}

var test = ['8', '28 6 21 6 -7856 73 73 -56', '73']

solve(test);