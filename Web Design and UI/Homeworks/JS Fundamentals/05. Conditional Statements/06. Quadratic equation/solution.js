'use strict';

function solve(args) {

    var discriminant, a, b, c, output, root, firstRoot, secondRoot, formatOutput;

    String.prototype.format = function () {
        var formatted = this;
        for (var arg in arguments) {
            formatted = formatted.replace("{" + arg + "}", arguments[arg]);
        }
        return formatted;
    };

    a = +args[0];
    b = +args[1];
    c = +args[2];
    discriminant = (b * b) - (4 * a * c);

    if (discriminant < 0) {
        output = "no real roots";
    }
    else if (discriminant === 0) {
        root = -b / (2 * a);
        output = "x1=x2={0}".format(root.toFixed(2));
    }
    else {
        firstRoot = ((-b + Math.sqrt(discriminant)) / (2 * a));
        secondRoot = ((-b - Math.sqrt(discriminant)) / (2 * a));
        formatOutput = "x1={0}; x2={1}";

        output = firstRoot < secondRoot ?
            formatOutput.format(firstRoot.toFixed(2), secondRoot.toFixed(2)):
            formatOutput.format(secondRoot.toFixed(2), firstRoot.toFixed(2));

    }
    console.log(output);
}

solve([-0.5,4,-6]);