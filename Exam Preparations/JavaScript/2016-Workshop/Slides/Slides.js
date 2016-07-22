'use strict';

function solve(params) {

    if (!String.prototype.trim) {
        String.prototype.trim = function () {
            return this.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, '');
        };
    }

    function Ball(width, heigth, debth) {
        this.width = width;
        this.heigth = heigth;
        this.debth = debth;
    }

    var directions = {
        L: -1,
        R: +1,
        B: +1,
        F: -1
    };

    var cubeDimentions = params[0].split(' ').map(Number);
    var width = cubeDimentions[0];
    var heigth = cubeDimentions[1];
    var debth = cubeDimentions[2];

    var cube = [];
    var cubeLayer = [];

    var cubeCells = params.slice(1, heigth + 1);
    var startPosititon = params
        .slice(heigth + 1)[0]
        .split(' ')
        .map(Number);
    var ball = new Ball(startPosititon[0], 0, startPosititon[1]);
 //  console.log('ball is initioalized');
  //  console.log(ball);


    // console.log(cubeCells);
    // console.log('====================================');

    for (var h = 0; h < heigth; h += 1) {
        var currentLayer = cubeCells[h].trim().split(' | ');
        // console.log(currentLayer);
        // console.log('====================================');

        for (var d = 0; d < debth; d += 1) {
            var index = currentLayer[d].trim().length - 2;

            var currentWidh = currentLayer[d]
                .replace('\(', '')
                .substring(0, index)
                .split('\)\(');
            // console.log(currentWidh);
            // console.log('====================================');
            cubeLayer.push(currentWidh);
        }
        cube.push(cubeLayer);
        cubeLayer = [];
    }
   // console.log(cube);

    while (true) {

        var currMove = cube[ball.heigth][ball.debth][ball.width].trim();
     //   console.log('start move ' + currMove);

        if (currMove === 'B' ) {
            console.log('No');
            console.log(ball.width + ' ' + ball.heigth + ' ' + ball.debth);
            break;
        } else {
            var newBall = Move(currMove, ball);

            if (newBall.width>= width || newBall.debth >=debth || newBall.width < 0 || newBall.debth < 0) {

                if (newBall.heigth >= heigth) {
                    console.log('Yes');
                    console.log(ball.width + ' ' + ball.heigth + ' ' + ball.debth);
                    break;
                } else {
                    console.log('No');
                    console.log(ball.width + ' ' + ball.heigth + ' ' + ball.debth);
                    break;
                }

            } else if (newBall.heigth === heigth) {
                console.log('Yes');
                console.log(ball.width + ' ' + ball.heigth + ' ' + ball.debth);
                break;
            } else {
                ball = newBall;
            //   console.log('ball after update');
              //  console.log(ball);
                newBall = new Ball();

               // console.log('====================================');
            }
        }
     //   console.log(currMove);
    }


    function Move(movement, ball) {

        var nextBall = new Ball();
        nextBall.width = ball.width;
        nextBall.heigth = ball.heigth;
        nextBall.debth = ball.debth;

        if (movement[0] === 'S') {
            nextBall.heigth += 1;
            var dir = movement.split(' ')[1];
            if (dir.length === 1) {
                if (dir === 'L' || dir === 'R') {
                    nextBall.width += directions[dir];

                } else {
                    //   console.log('curr dir ' + dir);
                    nextBall.debth += directions[dir];
                }
            }
            if (dir.length === 2) {

                nextBall.width += directions[dir[2]];
                nextBall.debth += directions[dir[1]];
            }
        }
        else if (movement[0] === 'E' && ball.heigth!=heigth-1) {
            nextBall.heigth += 1;
        }
        else if (movement[0] === 'T') {
            var coords = movement.trim().split(' ');
            //  console.log('teleport coords');
            //  console.log(coords);
            nextBall.width = + coords[1];
            nextBall.debth = +coords[2];
        }
        // else {
        //     /// TODO
        //     console.log('No');
        //     console.log(ball.width + ' ' + ball.heigth + ' ' + ball.debth);
        // }
        return nextBall;
    }

}

var test2 =['3 3 3',
'(S L)(E)(S L) | (S L)(B)(S L) | (B)(S F)(S L)', 
'(S B)(S R)(E) | (S B)(S F)(T 1 1)  | (S L)(S R)(B)',
'(S FL)(S FL)(B) | (S FL)(S FL)(S FR) | (S F)(S BR)(S FR)',
'1 0',
];


var test = [
    '3 3 3',
    '(S L)(E)(S L) | (S L)(E)(S L) | (B)(S F)(S L)',
    '(S B)(S F)(E) | (S B)(S F)(T 1 1)  | (S L)(S R)(B)',
    '(S FL)(S FL)(S FR) | (S FL)(S FL)(S FR) | (S F)(S BR)(S FR)',
    '1 1'
];

solve(test);