'use strict';


function solve(args) {

    String.prototype.format = function() {
    var formatted = this;
    for( var arg in arguments ) {
        formatted = formatted.replace("{" + arg + "}", arguments[arg]);
    }
    return formatted;
};


    var numA = +args[0];
    var numB = +args[1];
    var numC = +args[2];
    var output = "{0} {1} {2}";

    if (numA >= numB && numA >= numC) {
        if (numB >= numC) {

            console.log(output.format(numA, numB, numC));
        }
        else {
            console.log(output.format(numA, numC, numB));
        }
    }
    else if (numB >= numA && numB >= numC) {
        if (numA > numC) {

            console.log(output.format(numB, numA, numC));
        }
        else {
            console.log(output.format(numB, numC, numA));
        }
    }
    else if (numC >= numA && numC >= numB) {
        if (numA > numB) {

            console.log(output.format(numC, numA, numB));
        }
        else {
            console.log(output.format(numC, numB, numA));
        }
    }
}

solve([-33, -4, -7]);