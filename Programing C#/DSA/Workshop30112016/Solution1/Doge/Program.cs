using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doge
{
    class Program
    {
        static void Main(string[] args)
        {
            /*5 5 1
            2 3;1 1*/

            var dimentions = Console.ReadLine()
            .Split(' ');

            var rows = int.Parse( dimentions[0]);
            var cols =int.Parse( dimentions[1]);
            var backwards = int.Parse(dimentions[2]);

            var enemies = Console.ReadLine()
            .Split(';');

            long[,] matrix = new long[rows, cols];
            for (int i = 0; i < enemies.Length; i++)
            {
                var enemyDimensions = enemies[i].Split();
                var enemyRow = int.Parse(enemyDimensions[0]);
                var enemyCol = int.Parse(enemyDimensions[1]);

                matrix[enemyRow, enemyCol] = -1;
            }

            for (int i = 0; i < cols; i++)
            {
                if (matrix[0, i] != -1)
                {
                    matrix[0, i] = 1;
                }
                else
                {
                    break;
                }
            }

          //  PrintMatrix(matrix);

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, 0] != -1)
                {
                    matrix[i, 0] = 1;
                }
                else
                {
                    break;
                }
            }

            //  PrintMatrix(matrix);

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] != -1)
                    {
                        if (matrix[i - 1, j] != -1)
                        {
                            matrix[i, j] += matrix[i - 1, j];
                        }

                        if (matrix[i, j - 1] != -1)
                        {
                            matrix[i, j] += matrix[i, j - 1];
                        }
                    }
                }
            }

            Console.WriteLine(matrix[rows - 1, cols - 1]);

        }

        private static void PrintMatrix(long[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
