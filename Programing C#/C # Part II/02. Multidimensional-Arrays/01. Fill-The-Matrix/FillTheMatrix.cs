using System;

public class FillTheMatrix
{
    public static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        char style = Console.ReadLine()[0];

        switch (style)
        {
            case 'a':
                PrintMatrix(FillMatrixStyleA(size));
                break;
            case 'b':
                PrintMatrix(FillMatrixStyleB(size));
                break;
            case 'c':
                PrintMatrix(FillMatrixStyleC(size));
                break;
            case 'd':
                PrintMatrix(FillMatrixStyleD(size));
                break;
        }
    }

    public static int[,] FillMatrixStyleA(int size)
    {
        var temp = 1;

        int[,] matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[j, i] = temp;
                temp++;
            }
        }

        return matrix;
    }

    public static int[,] FillMatrixStyleB(int size)
    {
        var temp = 1;
        int[,] matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            var col = size - 1;
            for (int j = 0; j < size; j++)
            {
                if (i % 2 == 0)
                {
                    matrix[j, i] = temp;
                }
                else
                {
                    matrix[col, i] = temp;
                    col--;
                }

                temp++;
            }
        }

        return matrix;
    }

    public static int[,] FillMatrixStyleC(int size)
    {
        int[,] matrix = new int[size, size];
        var temp = 1;

        for (int k = 0; k < 2 * size; k++)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i - j) == size - k)
                    {
                        matrix[i, j] = temp;
                        temp++;
                    }
                }
            }
        }

        return matrix;
    }

    public static int[,] FillMatrixStyleD(int size)
    {
        int[,] matrix = new int[size, size];
        int row = 0;
        int col = 0;
        var temp = 1;

        while (size > 0)
        {
            for (int i = col; i <= col + size - 1; i++)
            {
                matrix[i, row] = temp++;
            }

            for (int j = row + 1; j <= row + size - 1; j++)
            {
                matrix[col + size - 1, j] = temp++;
            }

            for (int i = col + size - 2; i >= col; i--)
            {
                matrix[i, row + size - 1] = temp++;
            }

            for (int i = row + size - 2; i >= row + 1; i--)
            {
                matrix[col, i] = temp++;
            }

            row = row + 1;
            col = col + 1;
            size = size - 2;
        }

        return matrix;
    }

    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j > 0)
                {
                    Console.Write(" ");
                }

                Console.Write("{0}", matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}