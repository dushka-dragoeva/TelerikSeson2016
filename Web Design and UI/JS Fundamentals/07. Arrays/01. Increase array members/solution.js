function solve(args) {

    var output =[];
    var num = +args[0];
    for (var index = 0; index < num; index+=1) {
        output[index]=5*index;
        console.log(output[index]);
    }
// console.log(output);
}

solve([9]);