'use strict';
function solve(args) {
   var width = +args[0];
   var height = +args[1]

var area = width*height;
var perimeter = 2*(width + height);
    console.log(area.toFixed(2) + " " +  perimeter.toFixed(2));
}

solve([5, 2.3]);