using System;

class ExRug
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int hashTag = int.Parse(Console.ReadLine());
        int rugSize = (2 * size) + 1;

        var srartIndex = 0;
        var endIndex = rugSize - 1;
        var index = hashTag / 2 + 1;

        char[,] rug = new char[rugSize, rugSize];

        for (int row = 0; row < rugSize; row++)
        {
            for (int col = 0; col < rugSize; col++)
            {
                if (size < hashTag)
                {
                    rug[row, col] = '#';
                }
                else
                {
                    if ((col < index + row && col > row - index) ||
                        (col < rugSize - 1 - row + index && col > rugSize - 1 - index - row))

                    {
                        rug[row, col] = '#';
                    }

                    else if (((row < index || row > size) && col == index + row)
                        ||(row >size-index-1 && col==row-index))
                    {
                        rug[row, col] = '\\';
                    }
                    else if (row > size - index - 1)
                    {
                        
                    }
                    else
                    {
                        rug[row, col] = '.';
                    }
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