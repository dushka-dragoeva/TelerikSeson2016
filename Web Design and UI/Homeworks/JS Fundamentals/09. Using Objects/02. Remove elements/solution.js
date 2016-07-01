'use strict';
function solve(params) {


var arr= params.slice(0);
let elementtofind=arr[0];

function removeElement(arr,element) {
   // let len = arr.lenght;
     for (var i = 0; i < arr.length; i += 1) {
         if(arr[i]===element){
           arr.splice(i,1);
             --i;
            
         }
    }
    return arr;
}

arr= removeElement(arr, elementtofind);

//arr=arr.filtter();
console.log(arr.join('\n'));
}

var test =[
  '_h/_',
  '^54F#',
  'V',
  '^54F#',
  'Z285',
  'kv?tc`',
  '^54F#',
  '_h/_',
  'Z285',
  '_h/_',
  'kv?tc`',
  'Z285',
  '^54F#',
  'Z285',
  'Z285',
  '_h/_',
  '^54F#',
  'kv?tc`',
  'kv?tc`',
  'Z285'
];
solve(test);