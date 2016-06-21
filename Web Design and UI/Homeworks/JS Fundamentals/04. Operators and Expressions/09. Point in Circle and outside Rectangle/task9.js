'use strict';

function solve(args) {
    var output;
    var pointX = +args[0];
    var pointY = +args[1];
    var centerX = 1;
    var centerY = 1;
    var radius = 1.5;
    var leftX = -1;
    var topY = 1;
    var rightX = 5;
    var bottomY = -1;

    var isWithinCircle = Math.pow(pointX - centerX, 2) +
        Math.pow(pointY - centerY, 2) <=
        radius * radius;
    var isOutOfRectangle = pointX < leftX ||
        rightX < pointX ||
        pointY < bottomY ||
        pointY > topY;

    output = "outside circle outside rectangle";

    if (isWithinCircle && isOutOfRectangle) {
        output = "inside circle outside rectangle";
    }
    else if ((isWithinCircle && !isOutOfRectangle)) {
        output = "inside circle inside rectangle";
    }
    else if (!isWithinCircle && !isOutOfRectangle) {
        output = "outside circle inside rectangle";
    }
    console.log(output);
}
solve([0, 1]);