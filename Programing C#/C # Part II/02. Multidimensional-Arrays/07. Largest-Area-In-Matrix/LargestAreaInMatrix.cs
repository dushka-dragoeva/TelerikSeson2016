//// https://zeroreversesoft.wordpress.com/2013/02/17/searching-for-the-largest-area-of-equal-elements-in-a-matrix-using-bfsdfs-hybrid-algorithm/

using System;
using System.Linq;

public class LargestAreaInMatrix
{
    private static int largestArea = 0;
    private static int currentArea = 0;
    private static bool[,] visitedCells;
    private static int[,] matrix;
    private static int rows;
    private static int cols;

    public static void Main()
    {
        matrix = ReadMatrix();
        rows = matrix.GetLength(0);
        cols = matrix.GetLength(1);

        visitedCells = new bool[rows, cols]; // can be byteArray

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                currentArea = 0;
                ExploreNeighbourCells(matrix[row, col], row, col);
                largestArea = Math.Max(largestArea, currentArea);
            }
        }

        Console.WriteLine(largestArea);
    }

    public static void ExploreNeighbourCells(int number, int row, int col)
    {
        currentArea++;
        visitedCells[row, col] = true;

        //// check down
        if (row + 1 < rows)
        {
            if (matrix[row + 1, col] == number && !IsVisited(row + 1, col))
            {
                ExploreNeighbourCells(number, row + 1, col);
            }
        }

        //// check up
        if (row - 1 >= 0)
        {
            if (matrix[row - 1, col] == number && !IsVisited(row - 1, col))
            {
                ExploreNeighbourCells(number, row - 1, col);
            }
        }

        //// check right
        if (col + 1 < cols)
        {
            if (matrix[row, col + 1] == number && !IsVisited(row, col + 1))
            {
                ExploreNeighbourCells(number, row, col + 1);
            }
        }

        //// check left
        if (col - 1 >= 0)
        {
            if (matrix[row, col - 1] == number && !IsVisited(row, col - 1))
            {
                ExploreNeighbourCells(number, row, col - 1);
            }
        }
    }

    public static bool IsVisited(int row, int col)
    {
        return visitedCells[row, col];
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
}