'use strict';

function solve(args) {
    var x = +args[0];
    var y = +args[1];

    var distance = Math.sqrt(x * x + y * y);

    var output = distance <= 2 ? "yes " + distance.toFixed(2) : "no " + distance.toFixed(2)

    console.log(output);
}
solve([-2,0]);