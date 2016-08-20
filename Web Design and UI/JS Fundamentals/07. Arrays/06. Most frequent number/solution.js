function solve(args) {

     var input = args[0].split('\n'),
        n = input[0],
        numbers = input.slice(1),
        current = numbers[0],
        counter = 1,
        bestNum = 0;
    bestCounter = 0;

    numbers.sort();

    for (var i = 0; i < n; i += 1) {

        if (current === numbers[i + 1]) {
            counter++;
        }
        else {
            if (counter > +bestCounter) {
                bestCounter = counter;
                bestNum = numbers[i];
            }
            counter = 1;
        }
        current = numbers[i + 1];
    }
    console.log(bestNum + " (" + bestCounter + " times)");
}

solve([9]);