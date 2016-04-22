using System;

public class ForestRoad
{
    public static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        int heigdt = (2 * width) - 1;

        for (int row = 0; row < heigdt; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if ((row < width && col - row == 0) || (row >= width && col + row == heigdt - 1))
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }

            Console.WriteLine();
        }
    }
}