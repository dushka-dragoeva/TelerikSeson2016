'use strict';

function solve(args) {

    function Cell(x, y) {
        this.x = x;
        this.y = y;
    }

    function Player(id, steps, direction) {
        this.id = id;
        this.steps = steps;
        this.direction = direction;
        //  this.command=command;

    }

    let rc = args[0].split(' ').map(Number);
    let rows = rc[0];
    let cols = rc[1];
    let derbs = args[1].split(';');
    let dLen = derbs.length;
    let derbsCells = [], row, col;

    for (var i = 0; i < dLen; i += 1) {
        row = +derbs[i][0];
        col = +derbs[i][2];
        var temp = new Cell(row, col);
        derbsCells.push(temp);
        //  console.log(temp);
    }

    let comCount = args[2];

    var field = [];
    var cells = [];

    for (var k = 0; k < rows; k++) {
        for (var l = 0; l < cols; l += 1) {
            var c = 'E';
            cells.push(c);
        }

        field.push(cells);
        cells = [];
    }

    for (let i = 0; i < 4; i += 1) {
        field[0][i] = i;
        field[4][cols - 4 + i] = 5 + i;
    }

    for (let i = 0; i < dLen; i += 1) {
        row = +derbs[i][0];
        col = +derbs[i][2];
        field[row][col] = 'X';

        //  console.log(temp);
    }
    // console.log(field);
    let allCommands = args.slice(3);
    //  console.log(allCommands);

    for (let i = 0; i < comCount; i += 1) {
        var player = parseComand(allCommands[i]);
        console.log(player);
        if (player.moves < 0) {
            // shoot
        }

        else {
            // move
        }

    }

    function parseComand(comand) {
        let temp = comand.split(' ');
        console.log(temp);

        var player = new Player();

        if (temp[0] === 'mv') {
           player = new Player(+temp[1],+temp[2],temp[3]);
 
        }
        else {
             player = new Player(+temp[1],-1,temp[2]);
  
        }

        return player;
    }


}

var test = [
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
];

solve(test);