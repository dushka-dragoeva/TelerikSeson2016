function solve(args) {

    var output =new Array();
    var num = +args[0];
    for (var index = 1; index <= num; index++) {
        output.push(index);
        
    }
console.log.apply(console,output);
}

solve([9]);