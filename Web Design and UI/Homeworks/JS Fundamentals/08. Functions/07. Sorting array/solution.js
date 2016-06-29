
'use strict';
function solve(input) {
    var n = +input[0],
    numbers = input[1].split(' ').map(Number);
    
    if (numbers.length > 1) {
        console.log(numbers.sort(function (x ,y)
        { return x - y;}
        ).join(' '));
    }
}

var test = ['6', '-26 -25 -28 31 2 27'];

solve(test);