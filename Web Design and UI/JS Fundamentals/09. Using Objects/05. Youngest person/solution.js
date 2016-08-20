'use strict';
function solve(params) {
    function Person(firstname, lastname, age) {

        this.firstname = firstname;
        this.lastname = lastname;
        this.age = age;
        // this.toString= function () {
        //     return `${result.firstname} ${result.lastname}`;
       // }
    }


    var arr = params.slice(0);
    var len = arr.length;
    var people = [];

    for (var i = 0; i < len; i += 3) {

        var p = new Person(arr[i], arr[i + 1], arr[i + 2]);
      //  console.log(p);
        people.push(p);
    }

    var result = people.sort(function (p1, p2) {
        return p1.age - p2.age;
    });

 //  console.log(result);
      console.log(result[0].firstname+' '+result[0].lastname);
}

var test = [
    'Gosho', 'Petrov', '32',
    'Bay', 'Ivan', '81',
    'John', 'Doe', '42'
];
solve(test);