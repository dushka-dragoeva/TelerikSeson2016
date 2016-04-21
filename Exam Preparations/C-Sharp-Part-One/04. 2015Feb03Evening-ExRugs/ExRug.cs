using System;

class ExRug
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int patternSize = int.Parse(Console.ReadLine());
        int rugSize = (2 * size) + 1;

        int middleRug = size;
        var middlePattern = patternSize / 2 + 1;

        char patternEdge = 'X';
        char leftDiagonal = '\\';
        char rightDiagonal = '/';
        char pattern = '#';
        char dot = '.';

        for (int row = 0; row < rugSize; row++)
        {
            for (int col = 0; col < rugSize; col++)
            {
                // print X
                if ((row == middleRug - middlePattern || row == middleRug + middlePattern) && col == middleRug ||
                   row == middleRug && (col == middleRug - middlePattern || col == middleRug + middlePattern))
                {
                    Console.Write(patternEdge);
                }
                // ptinl left diagonals
                else if (col - row ==  middlePattern && (row < middleRug - middlePattern || row > middleRug) ||
                    row - col ==middlePattern && (row<middleRug||row>middleRug+middlePattern))
                {
                    Console.Write(leftDiagonal);
                }
              //  print right diagonals
               else if (col + row == rugSize - 1 - middlePattern && (row < middleRug - middlePattern || row > middleRug)

                    || col + row == rugSize - 1 + middlePattern && (row < middleRug || row > middleRug + middlePattern))
                {
                    Console.Write(rightDiagonal);
                }
                else if ((row<middleRug-middlePattern && col-row>middlePattern &&col+row<rugSize-1-middlePattern)
                    || row>middleRug+middlePattern)
                {
                    Console.Write(dot);
                }
                else
                {
                    Console.Write(pattern);
                }

            }

            Console.WriteLine();
        }
    }
}