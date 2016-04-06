using System;

public class Cube
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int rows = (2 * size) - 1;
        int cols = rows;
        char[,] cube = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                cube[row, col] = ' ';

                if (row < size)
                {
                    if (
                       (row == 0 && col >= size - 1)
                        || col == size - row - 1
                        || col == rows - 1 - row
                        || col == cols - 1
                        || (col < (cols - row) && row == size - 1))
                    {
                        cube[row, col] = ':';
                    }
                    else if (row > 1 && col >= cols - row && col < cols - 1)
                    {
                        cube[row, col] = 'X';
                    }
                    else if (
                        row > 0
                        && row < size - 1
                        && col > size - row - 1
                        && col < cols - row - 1)
                    {
                        cube[row, col] = '/';
                    }
                }
                else if (row >= size)
                {
                    if ((row == rows - 1 && col < size) || col == 0 || col == size - 1 || col == cols - row + size - 2)
                    {
                        cube[row, col] = ':';
                    }
                    else if (col < cols - row + size - 2 && col >= size)
                    {
                        cube[row, col] = 'X';
                    }
                }
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(cube[i, j]);
            }

            Console.WriteLine();
        }
    }
}