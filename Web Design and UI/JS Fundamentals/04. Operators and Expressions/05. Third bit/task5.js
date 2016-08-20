'use strict';

function solve(args) {
    var num = +args[0];
    var bit = ((1 << 3) & num) >> 3;
    console.log(bit);
}

solve([15]);


