using System;
using System.Linq;

public class MaximalSum
{
    public const int SquareSize = 3;

    public static void Main()
    {
        var matrix = ReadMatrix();

        var bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;

        for (int row = 0; row <= matrix.GetLength(0) - SquareSize; row++)
        {
            for (int col = 0; col <= matrix.GetLength(1) - SquareSize; col++)
            {
                var sum = CalculateSubmatrixSum(matrix, row, col, SquareSize);

                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        Console.WriteLine(bestSum);
    }

    public static int[,] ReadMatrix()
    {
        var matrixSize = Console.ReadLine().Split(' ')
           .Select(int.Parse)
           .ToArray();

        int rows = matrixSize[0];
        int cols = matrixSize[1];
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var currentRow = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = currentRow[j];
            }
        }

        return matrix;
    }

    private static int CalculateSubmatrixSum(int[,] matrix, int startRow, int startCol, int size)
    {
        int sum = 0;

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                sum += matrix[startRow + row, startCol + col];
            }
        }

        return sum;
    }
}
