using System;

public class PersianRugs
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        int rugSize = (2 * size) + 1;

        char[,] rug = new char[rugSize, rugSize];

        for (int row = 0; row < rugSize; row++)
        {
            for (int col = 0; col < rugSize; col++)
            {
                if (row == size && (col == size))
                {
                    rug[row, col] = 'X';
                }
                else if ((col == row)
                    || (row < size - distance - 1 && col == row + distance + 1)
                    || (row > size + distance + 1 && col == row - distance - 1))
                {
                    rug[row, col] = '\\';
                }
                else if ((col == rugSize - row - 1)
                     || (row < size - distance - 1 && col == rugSize - row - distance - 2)
                     || (row > size + distance + 1 && col == rugSize - row + distance))
                {
                    rug[row, col] = '/';
                }
                else if ((row < size - distance - 1 && col > row + distance + 1 && col < rugSize - row - distance - 2)
                    || (row > size + distance + 1 && col < row - distance - 1 && col > rugSize - row + distance))
                {
                    rug[row, col] = '.';
                }
                else if ((row <= size && ((col >= 0 && col < row) || col >= rugSize - row))
    || (row > size && ((col >= 0 && col < rugSize - row) || col > row)))
                {
                    rug[row, col] = '#';
                }
                else
                {
                    rug[row, col] = ' ';
                }
            }
        }

        for (int i = 0; i < rugSize; i++)
        {
            for (int j = 0; j < rugSize; j++)
            {
                Console.Write(rug[i, j]);
            }

            Console.WriteLine();
        }
    }
}