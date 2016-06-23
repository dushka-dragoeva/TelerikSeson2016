function solve(args) {

    var hexValues = '0123456789ABCDEF';
    var numString = args[0].toUpperCase();
    var len = args[0].length;
    var sum = 0;

    for (var i = 0; i < len; i += 1) {
        var digit = hexValues.indexOf(numString[i]);
        sum = digit + sum * 16;
    }
    console.log(sum);
}
solve(['1ae3']);