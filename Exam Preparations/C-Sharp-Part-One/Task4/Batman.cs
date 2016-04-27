using System;

class Batman
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char symbol = char.Parse(Console.ReadLine());

        int width = 3 * n;
        int middle = n / 2;
        int height = 2 * middle + n / 3;
        int vertMiddle = width / 2;
        //int height = middle * 3 - 1;

        char[,] batman = new char[height, width];

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                batman[row, col] = ' ';

                if (row < middle && (col - row) >= 0 && col < n ||
                    row < middle && col + row < width && col >= 2 * n)

                {
                    batman[row, col] = symbol;
                }

                if (row == middle - 1 && (col == vertMiddle - 1 || col == vertMiddle + 1))
                {
                    batman[row, col] = symbol;
                }
                if ((row >= middle && row < middle+n/3) && (col >= middle) && (col < width - middle))
                {
                    batman[row, col] = symbol;
                }

                if (row >= middle+n/3&& (row - col < height - vertMiddle && row + col < height + vertMiddle))
                {
                    batman[row, col] = symbol;
                }
            }
        }

        for (int i = 0; i < height; i++)
        {
            for (int k = 0; k < width; k++)
            {
                Console.Write(batman[i, k]);
            }

            Console.WriteLine();
        }
    }
}