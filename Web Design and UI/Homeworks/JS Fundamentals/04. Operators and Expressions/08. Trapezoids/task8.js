'use strict';

function solve(args) {
    var result;
    var a = +args[0];
    var b = +args[1];
    var h = +args[2];

    result = (a + b)*h/2;

    console.log(result.toFixed(7));
}