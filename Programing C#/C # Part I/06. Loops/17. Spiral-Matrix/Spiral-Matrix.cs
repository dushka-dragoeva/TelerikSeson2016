using System;

public class Program
{
    public static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int[,] spiralMatrix = new int[size, size];
        int row = 0;
        int col = 0;
        int maxRotations = size * size;
        string direction = "right";

        for (int i = 1; i <= maxRotations; i++)
        {
            if (direction == "right" && (col > size - 1 || spiralMatrix[row, col] != 0))
            {
                direction = "down";
                row++;
                col--;
            }

            if (direction == "down" && (row > (size - 1) || spiralMatrix[row, col] != 0))
            {
                direction = "left";
                row--;
                col--;
            }

            if (direction == "left" && (col < 0 || spiralMatrix[row, col] != 0))
            {
                direction = "up";
                row--;
                col++;
            }

            if (direction == "up" && (row < 0 || spiralMatrix[row, col] != 0))
            {
                direction = "right";
                row++;
                col++;
            }

            spiralMatrix[row, col] = i;

            if (direction == "right")
            {
                col++;
            }

            if (direction == "down")
            {
                row++;
            }

            if (direction == "left")
            {
                col--;
            }

            if (direction == "up")
            {
                row--;
            }
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write("{0} ", spiralMatrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}
