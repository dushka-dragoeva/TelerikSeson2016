using System;

public class CubeThreeD
{
    public static void Main()
    {
        int cubeSize = int.Parse(Console.ReadLine());

        int matrixSize = (2 * cubeSize) - 1;
        char[,] cube = new char[matrixSize, matrixSize];

        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                if (row == 0 && col < cubeSize)
                {
                    cube[row, col] = ':';
                }
                else if (row > 0 && row < cubeSize - 1)
                {
                    if (col == 0 || col == cubeSize - 1 || col == cubeSize + row - 1)
                    {
                        cube[row, col] = ':';
                    }
                    else if (col >= cubeSize && col < cubeSize + row - 1)
                    {
                        cube[row, col] = '|';
                    }
                    else
                    {
                        cube[row, col] = ' ';
                    }
                }
                else if (row == cubeSize - 1)
                {
                    if (col >= cubeSize && col < cubeSize + row - 1)
                    {
                        cube[row, col] = '|';
                    }
                    else
                    {
                        cube[row, col] = ':';
                    }
                }
                else if (row >= cubeSize && row < matrixSize - 1)
                {
                    if (col == row - cubeSize + 1 || col == row || col == matrixSize - 1)
                    {
                        cube[row, col] = ':';
                    }
                                        else if (col > ((row - cubeSize) + 1) && col < row)
                    {
                        cube[row, col] = '-';
                    }
                    else if (col > row && col < matrixSize - 1)
                    {
                        cube[row, col] = '|';
                    }
                    else
                    {
                        cube[row, col] = ' ';
                    }
                }
                else if (row == matrixSize - 1 && col >= cubeSize - 1)
                {
                    cube[row, col] = ':';
                }
                else
                {
                    cube[row, col] = ' ';
                }
            }
        }

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                Console.Write(cube[i, j]);
            }

            Console.WriteLine();
        }
    }
}
