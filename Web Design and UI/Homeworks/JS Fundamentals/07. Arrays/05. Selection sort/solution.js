function solve(args) {

    var input = args[0].split('\n'),
        n = +input[0],
        numbers = input.slice(1),
        min = numbers[0];

    for (var j = 0; j < n; j += 1) {
        min = numbers[j];
        for (var i = j; i < n; i += 1) {

            if (+numbers[i] < min) {
                min = +numbers[i];
                numbers[i] = +numbers[j];
                numbers[j] = min;
            }
        }
    }
    console.log(numbers.join('\n'));
}

