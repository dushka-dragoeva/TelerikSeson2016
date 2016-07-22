'use strict';

function solve(params) {

    const rows = parseInt(params[0]),
        cols = parseInt(params[1]);

    const board = params.slice(2, rows + 2);

    let moves = params.slice(2 + rows + 1)
        .map(moveString => {
            var parts = moveString.split(' ');
            return {
                'fromRow': getRowIndex(parts[0][1]),
                'fromCol': getColIndex(parts[0][0]),
                'toRow': getRowIndex(parts[1][1]),
                'toCol': getColIndex(parts[1][0])
            };
        });

    // console.log(moves);
    let counter = 1;
    moves.forEach(move => {
        let result = 'no';

        let piece = board[move.fromRow][move.fromCol];
        //  console.log(counter);
        //  console.log(piece);
        //   console.log('===============================');
        //  counter+=1;

        let nextPiece = board[move.toRow][move.toCol];

        if (isQueen(piece)) {
            if (isEmpty(nextPiece) && checkQueen(move)) {
                console.log('yes');
            } else {
                console.log('no');
            }

        } else if (isKnight(piece)) {
            if (isEmpty(nextPiece) && checkKnight(move)) {
                console.log('yes');
            } else {
                console.log('no');
            }
        }

        else {
            console.log('no');
        }


        // console.log(result);
    });

    function checkKnight(move) {
        const deltas = [[-2, 1], [-1, 2], [1, 2], [2, 1], [2, -1],
            [1, -2], [-1, -2], [-2, -1]];

        for (let delta of deltas) {
            let row = move.fromRow + delta[0];
            let col = move.fromCol + delta[1];

            if (move.toRow === row && move.toCol === col) {
                //  console.log(move.toRow === row);
                //  console.log(move.toCol === col);
                return true;
            }
        }
        return false;
    }

    function checkQueen(move) {
        let deltaRow = getDelta(move.fromRow, move.toRow);
        let deltaCol = getDelta(move.fromCol, move.toCol);

        let row = move.fromRow;
        let col = move.fromCol;

        while (true) {
            row += deltaRow;
            col += deltaCol;

            if(!board[row] || !board[row][col]){
                return false;
            }

            if (!isEmpty(board[row][col])) {
                return false;
            }
            if (move.toRow === row && move.toCol == col) {
                return true;
            }
        }

        // only return true + horse = 40 points
    }

    function getDelta(from, to) {
        return (from > to) ? -1
            : (from < to) ? +1
                : 0;
    }

    function isKnight(piece) {
        return piece === 'K';
    }

    function isQueen(piece) {
        return piece === 'Q';
    }

    function isEmpty(piece) {
        return piece === '-';
    }

    function getRowIndex(rowName) {
        return rows - rowName;
    }

    function getColIndex(colName) {
        return colName.charCodeAt(0) - 'a'.charCodeAt();
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

