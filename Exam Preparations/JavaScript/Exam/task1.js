'use strict';

function solve(args) {
    let heights = args[0].slice(0).split(' ').map(Number);

    let len = heights.length;
    let result;
    var sum = 0;
    var maxSum = Number.MIN_VALUE;
    var pickIndexes = [];
    pickIndexes.push(0);


    //  console.log(heights);

    for (var i = 1; i < len - 1; i += 1) {

        if (isPeak(heights[i - 1], heights[i], heights[i + 1])) {

            pickIndexes.push(i);

        }
    }
    pickIndexes.push(len - 1);
   // console.log(pickIndexes);

    for (var j = 0; j < pickIndexes.length-1; j += 1) {
        var temp = heights.slice(pickIndexes[j], pickIndexes[j + 1]+ 1);
       // console.log(pickIndexes[j]);
       // console.log(pickIndexes[j + 1]);
       // console.log(temp);
       //  console.log(heights);
       // console.log('============================');
       // temp=[];
       sum= temp.reduce(function(sum, number) {
            return sum + number;
        }, 0);
        // console.log(sum);
         maxSum=Math.max(maxSum,sum);

    }

    function isPeak(a, b, c) {

        if (b > a && b > c) {
            return true;
        } else {
            return false;
        }
    }

    console.log(maxSum);
}

var test = [
    "5 1 7 6 5 6 4 2 3 8"
];

solve(test);
