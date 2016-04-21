using System;

public class CubeEvlogi
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int fieldSize = (2 * n) - 1;
        int mid = n - 1;

        char empty = ' ';
        char top = '/';
        char edge = ':';
        char side = 'X';

        for (int row = 0; row < fieldSize; row++)
        {
            for (int col = 0; col < fieldSize; col++)
            {
                if ((col == 0 && row >= mid) ||
                   (col == mid && row >= mid) ||
                   (col == fieldSize - 1 && row <= mid) ||
                   (col < mid && row == fieldSize - 1) ||
                   (col < mid && row == mid) ||
                   (col >= mid && row == 0) ||
                   /// diagonali
                   (col + row) == mid ||
                  ((col + row) == fieldSize - 1 && row < mid) ||
                   (col + row) == fieldSize - 1 + mid)
                {
                    Console.Write(edge);
                }
                else if (row < mid && (col + row > mid) && ((col + row) < fieldSize - 1))
                {
                    Console.Write(top);
                }
                else if ((col + row) > fieldSize - 1 && (col + row) < fieldSize - 1 + mid && col > mid)
                {
                    Console.Write(side);
                }
                else
                {
                    Console.Write(empty);
                }
            }

            Console.WriteLine();
        }
    }
}
