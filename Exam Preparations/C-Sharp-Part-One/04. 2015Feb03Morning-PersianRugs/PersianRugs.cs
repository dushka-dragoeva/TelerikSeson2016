using System;

public class PersianRugs
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int distanseSmallerTriangle = int.Parse(Console.ReadLine());
        int rugSize = (2 * size) + 1;

        char[,] rug = new char[rugSize, rugSize];

        for (int row = 0; row < rugSize; row++)
        {
            for (int col = 0; col < rugSize; col++)
            {
                if (row >= 0 && row < size)
                {
                    if (col == row)
                    {
                        rug[row, col] = '\\';
                    }
                    else if (col == row + size)
                    {
                        rug[row, col] = '/';
                    }
                    else if (row > 0 && ((col > 0 && col < row) 
                        || col > rugSize - row ))
                    {
                        rug[row, col] = '#';
                    }
                    else
                    {
                        rug[row, col] = '*';
                    }
                }

                if (row == size)
                {
                    if (col == size)
                    {
                        rug[row, col] = 'X';
                    }
                    else
                    {
                        rug[row, col] = '#';
                    }
                }
                //else
                //{
                //    rug[row, col] = '*';
                //}
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

