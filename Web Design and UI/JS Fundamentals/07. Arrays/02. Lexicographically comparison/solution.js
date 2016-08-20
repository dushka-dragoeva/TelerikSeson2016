function solve(args) {

    var arr = args[0].split('\n'),
        a = String(arr[0]),
        b = String(arr[1]);

    if (a > b) {
        console.log('>');
    }
    else if (a < b) {
        console.log('<');
    }
    else if (a === b) {

        console.log('=');
    }
}
