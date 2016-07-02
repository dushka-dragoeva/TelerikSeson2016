'use strict';

function solve(params) {

    let rows = parseInt(params[0]),
        cols = parseInt(params[1]);

    function Cell(row, col) {
        this.row = row;
        this.col = col;
    }
    let board = params.slice(2, rows + 2).reverse();

    let commandsNumber = params[2 + rows];
    let allCommands = params.slice(2 + rows + 1);

    for (var i = 0; i < commandsNumber; i += 1) {
        let currCom = allCommands[i].split(' ');
        let startCell = parsePosition(currCom[0]);
        let endCell = parsePosition(currCom[1]);
        let isMoveValid = true;
        let deltaR = 0, deltaC = 0, numberOfMoves = 0;

        if ((board[startCell.row][startCell.col] === 'Q') &&
            board[endCell.row][endCell.col] === '-' &&
            (startCell.row === endCell.row || startCell.col === endCell.col)) {

            // check if all cells between start and end are empty
            if (startCell.row !== endCell.row) {
                deltaR = startCell.row > endCell.row ? -1 : +1;
                numberOfMoves = Math.abs(startCell.row - endCell.row);
            }

            if (startCell.col !== endCell.col) {
                deltaC = startCell.col > endCell.col ? -1 : +1;
                numberOfMoves = Math.abs(startCell.col - endCell.col);
            }

            for (let c = 1; c < numberOfMoves; c += 1) {
                let nextRow = startCell.row + (c * deltaR);
                let nextCol = startCell.col + (c * deltaC);
                if (board[nextRow][nextCol] !== '-') {
                    isMoveValid = false;
                    break;
                }
            }
        }
        else if ((board[startCell.row][startCell.col] === 'Q') &&
            board[endCell.row][endCell.col] === '-' &&
            Math.abs(startCell.row - endCell.row) === Math.abs(startCell.col - endCell.col)) {

            // check all cells between start and end are empty
            deltaR = startCell.row > endCell.row ? -1 : +1;
            deltaC = startCell.col > endCell.col ? -1 : +1;
            numberOfMoves = Math.abs(startCell.col - endCell.col);

            for (let c = 1; c < numberOfMoves; c += 1) {
                let nextRow = startCell.row + (c * deltaR);
                let nextCol = startCell.col + (c * deltaC);
                if (board[nextRow][nextCol] !== '-') {
                    isMoveValid = false;
                    break;
                }
            }
        }
        else if (board[startCell.row][startCell.col] === 'K') {

            if (Math.abs(startCell.row - endCell.row) + Math.abs(startCell.col - endCell.col) !== 3) {
                //  console.log(i+' start ' + board[startCell.row][startCell.col]+' end ' +board[endCell.row][endCell.col]);
                isMoveValid = false;
            }
            else {
                isMoveValid = true;
            }
        }
        else {
            isMoveValid = false;
        }
        var res = isMoveValid ? 'yes' : 'no';

        console.log(res);

    //    console.log('==============================================');
    }

    function parsePosition(coord) {
        let cell = new Cell();
        cell.row = +coord[1] - 1;
        cell.col = coord[0].charCodeAt() - 'a'.charCodeAt();

        return cell;
    }
}

var test = ['3',
    '4',
    '--K-',
    'K--K',
    'Q--Q',
    '12',
    'd1 b3',
    'a1 a3',
    'c3 b2',
    'a1 c1',
    'a1 b2',
    'a1 c3',
    'a2 c1',
    'd2 b1',
    'b1 b2',
    'c3 a3',
    'a2 a3',
    'd1 d3'


];

solve(test);

