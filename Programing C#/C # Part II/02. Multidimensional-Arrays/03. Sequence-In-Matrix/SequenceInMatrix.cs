using System;
using System.Linq;

public class SequenceInMatrix
{
    public static void Main(string[] args)
    {
        var matrix = ReadMatrix();
        var horizontalSubsequence = FindBestHorizontalSubsiquence(matrix);
        var vertivalSubsequence = FindBestVerticalSubsiquence(matrix);
        var rigthDiagonl = FindBestRightDiagonallSubsiquence(matrix);
        var leftDiagonal = FindBestLeftDiagonallSubsiquence(matrix);

        var bestSubsequence = Math.Max(Math.Max(horizontalSubsequence, vertivalSubsequence), Math.Max(leftDiagonal, rigthDiagonl));
       
        Console.WriteLine(bestSubsequence);
    }

    public static int FindBestHorizontalSubsiquence(string[,] matrix)
    {
        var bestSubsequence = 0;
        var currentSubsequence = 1;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                var a = matrix[row, col];
                var b = matrix[row, col + 1];

                if (matrix[row, col] == matrix[row, col + 1])
                {
                    currentSubsequence++;
                }
                else
                {
                    bestSubsequence = Math.Max(bestSubsequence, currentSubsequence);
                    currentSubsequence = 1;
                }
            }
        }

        //// in case best subsiquence include last column
        bestSubsequence = Math.Max(bestSubsequence, currentSubsequence);

        return bestSubsequence;
    }

    public static int FindBestVerticalSubsiquence(string[,] matrix)
    {
        var bestSubsequence = 0;
        var currentSubsequence = 1;

        for (int col = 0; col < matrix.GetLength(1); col++)

        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row, col] == matrix[row + 1, col])
                {
                    currentSubsequence++;
                }
                else
                {
                    bestSubsequence = Math.Max(bestSubsequence, currentSubsequence);
                    currentSubsequence = 1;
                }
            }
        }

        //// in case best subsiquence include last row
        bestSubsequence = Math.Max(bestSubsequence, currentSubsequence);

        return bestSubsequence;
    }

    public static int FindBestRightDiagonallSubsiquence(string[,] matrix)
    {
        var bestSubsequence = 0;
        var currentSubsequence = 1;
        var maxDiagonalLength = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                if (matrix[row, col] == matrix[row + 1, col + 1])
                {
                    currentSubsequence++;
                    var r = row + 1;
                    var c = col + 1;

                    while (r < maxDiagonalLength - 1 && c < matrix.GetLength(1) - 1)
                    {
                        if (matrix[r, c] == matrix[r + 1, c + 1])
                        {
                            currentSubsequence++;
                            r++;
                            c++;
                        }
                        else
                        {
                            bestSubsequence = Math.Max(bestSubsequence, currentSubsequence);
                            currentSubsequence = 1;
                            break;
                        }
                    }

                    bestSubsequence = Math.Max(bestSubsequence, currentSubsequence);
                    currentSubsequence = 1;
                }
            }
        }

        return bestSubsequence;
    }

    public static int FindBestLeftDiagonallSubsiquence(string[,] matrix)
    {
        var bestSubsequence = 0;
        var currentSubsequence = 1;
        var maxDiagonalLength = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == matrix[row + 1, col - 1])
                {
                    currentSubsequence++;
                    var r = row + 1;
                    var c = col - 1;
                    while (r < maxDiagonalLength - 1 && c > 0)
                    {
                        if (matrix[r, c] == matrix[r + 1, c - 1])
                        {
                            currentSubsequence++;
                            r++;
                            c--;
                        }
                        else
                        {
                            bestSubsequence = Math.Max(bestSubsequence, currentSubsequence);
                            currentSubsequence = 1;
                            break;
                        }
                    }

                    bestSubsequence = Math.Max(bestSubsequence, currentSubsequence);
                    currentSubsequence = 1;
                }
            }
        }

        return bestSubsequence;
    }

    public static string[,] ReadMatrix()
    {
        var matrixSize = Console.ReadLine().Split(' ')
           .Select(int.Parse)
           .ToArray();

        int rows = matrixSize[0];
        int cols = matrixSize[1];

        string[,] matrix = new string[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var currentRow = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToString())
            .ToArray();

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = currentRow[j];
            }
        }

        return matrix;
    }
}