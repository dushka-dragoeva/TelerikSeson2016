using System;
using System.Linq;
using System.Numerics;

public class BitShiftMatrix
{
    /// 1. Read Input
    /// 2. Deaclare a field/matrix R,C
    /// 3. For every move
    /// Calculate coordinates
    /// Go to col and collect everithing on the way and marked it
    /// Go to row and collect everithing on the way and marked it
    /// Do the same for all moves
    /// 4. Print Rezult
    public static void Main()
    {
        var rows = int.Parse(Console.ReadLine());
        var cols = int.Parse(Console.ReadLine());
        var movesNumber = int.Parse(Console.ReadLine());

        var moves = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        var colected = new bool[rows, cols];

        var pawnRow = rows - 1;
        var pawnCol = 0;

        BigInteger currentCellValue = 1;
        var coef = Math.Max(rows, cols);

        BigInteger sum = 0;

        foreach (var move in moves)
        {
            var nextRow = move / coef;
            var nextCol = move % coef;

            var deltaCol = pawnCol > nextCol ? -1 : 1;

            while (pawnCol != nextCol)
            {
                if (!colected[pawnRow, pawnCol])
                {
                    sum += currentCellValue;
                    colected[pawnRow, pawnCol] = true;
                }

                if (deltaCol == 1)
                {
                    currentCellValue *= 2;
                }
                else
                {
                    currentCellValue /= 2;
                }

                pawnCol += deltaCol;
            }

            // same for row
            var deltaRow = pawnRow > nextRow ? -1 : 1;

            while (pawnRow != nextRow)
            {
                if (!colected[pawnRow, pawnCol])
                {
                    sum += currentCellValue;
                    colected[pawnRow, pawnCol] = true;
                }

                if (deltaRow == -1)
                {
                    currentCellValue *= 2;
                }
                else
                {
                    currentCellValue /= 2;
                }

                pawnRow += deltaRow;
            }
        }

        if (!colected[pawnRow, pawnCol])
        {
            sum += currentCellValue;
            colected[pawnRow, pawnCol] = true;
        }

        Console.WriteLine(sum);
    }
}
