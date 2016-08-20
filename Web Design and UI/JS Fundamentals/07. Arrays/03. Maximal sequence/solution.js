function solve(args) {

    var arr = args[0].split('\n'),
        n = +arr[0],
        numbers = arr.slice(1),

        current = +numbers[0],
        sum = 1,
        best = 0;

    for (var i = 0; i < n; i += 1) {

        if (current === +numbers[i + 1]) {
            sum++;
        }
        else {
            if (sum > best) {
                best = sum;
            }
            sum = 1;
        }
        current = +numbers[i + 1];
    }

    console.log(best);
}

solve([9]);