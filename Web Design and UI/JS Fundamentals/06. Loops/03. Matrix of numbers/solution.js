function solve(args) {

    var len = +args[0];
    var temp = 1;
    var output = '';

    for (var i = 0; i <len; i += 1) {
        temp = 1+i;
        for (var j = i; j < len + i; j += 1) {

            output = output.concat(temp.toString(), ' ');

            temp += 1;
        }
        console.log(output.trim(' '));
        output = '';
       
    }
}

solve([9]);
