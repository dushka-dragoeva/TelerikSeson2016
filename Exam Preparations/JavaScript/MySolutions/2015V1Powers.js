'use strict';

function solve(params) {
    var nk = params[0].split(' ').map(Number),
        s = params[1].split(' ').map(Number),
        result;

    if (nk[0] > 1) {

        for (var i = 0; i < nk[1]; i += 1) {
            var tranf = transformNumbers(s);
            s = tranf.slice(0);
            tranf = [];
        }

         result = s.reduce(function (sum, number) {
                return sum + number;
            }, 0);
    }
    else {
        result = s[0];
    }

    function transformNumbers(arr) {
        var len = arr.length;
        var transformedArr = [],
            temp;

        for (var i = 0; i < len; i += 1) {
            var prevIndex = (i - 1 + len) % len;
            var nextIndex = (i + 1) % len;

            if (arr[i] === 0) {

                temp = Math.abs(arr[prevIndex] - arr[nextIndex]);
            }
            else if (arr[i] === 1) {
                temp = arr[prevIndex] + arr[nextIndex];
            }
            else {
                if (arr[i] % 2 === 0) {

                    temp = arr[prevIndex] > arr[nextIndex] ? arr[prevIndex] : arr[nextIndex];
                }
                else {
                    temp = Math.min(arr[prevIndex], arr[nextIndex]);
                }
            }

            transformedArr.push(temp);
        }

        return transformedArr;
    }

    console.log(result);
}

var test = ['5 1', '9 0 2 4 1'];
var test2=['10 3','1 9 1 9 1 9 1 9 1 9'];
var test3=['10 10','0 1 2 3 4 5 6 7 8 9'];

console.log(solve(test3));


