using System;

class Program
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        int middle = width / 2;
        int dashRow = width - width / 4;
        int lastRow = middle + dashRow;

        for (int row = 0; row <= lastRow; row++)
        {
            //  Console.Write(row);
            for (int col = 0; col < width; col++)
            {
                if (row < dashRow)
                {
                    if (col + row == middle - 1 || col - row == middle || row + col == middle + width - 1 || row - col == middle)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }

                else if (row == dashRow)
                {
                    Console.Write('-');
                }
                else
                {
                    if (col + row <= width + dashRow && col >= middle)
                    {
                        Console.Write('/');
                    }
                    else if (row - col <= dashRow + 1 && col < middle)
                    {
                        Console.Write('\\');
                    }

                    else
                    {
                        Console.Write('.');
                    }
                }

            }

            Console.WriteLine();
        }
    }
}
