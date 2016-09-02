/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            int width = 3 * n;
            int middle = n / 2;
            int vertMiddle = width / 2 ;
            int height = middle * 3 - 1;

            char[,] batman = new char[height,width];


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
                    if (row == middle - 1 && (col == vertMiddle-1 || col == vertMiddle+1 ))
                    {
                        batman[row, col] = symbol;
                    }
                    if ((row >= middle && row < 2 * middle - 1) && (col >= middle)&&(col<width-middle))
                    {
                        batman[row, col] = symbol;
                    }

                    if (row >= 2 * middle-1 && (row-col<height-vertMiddle && row+col<height+vertMiddle))
                    {
                        batman[row, col] = symbol;
                    }


                }

            }

            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    Console.Write(batman[i,k]);
                }

                Console.WriteLine();
            }


        }
    }
}
*/

using System;

namespace RefactorCShartFundamentsExam.Bathman
{
    public class Bathman
    {
        public static void Main()
        {
            int coeficient = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());

            var batman = FillMatrix(coeficient, symbol);
            Draw(batman);
        }

        private static char[,] FillMatrix(int coeficient, char symbol)
        {
            int bathmanWidth = 3 * coeficient;
            int earsPosition = bathmanWidth / 2;
            int height = (2 * (coeficient / 2)) + (coeficient / 3);
            int topPatternHeight = coeficient / 2;
            int middlePatternHeiht = coeficient / 3;

            char[,] batman = new char[height, bathmanWidth];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < bathmanWidth; col++)
                {
                    bool isTopPartten = (row < topPatternHeight
                        && (col - row) >= 0 &&
                       col < coeficient)
                        || (row < topPatternHeight
                        && col + row < bathmanWidth
                        && col >= 2 * coeficient);
                    bool isEarsPattern = row == topPatternHeight - 1 && 
                        (col == earsPosition - 1 || 
                        col == earsPosition + 1);
                    bool isMiddlePatterrn = row >= topPatternHeight 
                        && row < topPatternHeight + middlePatternHeiht 
                        && col >= topPatternHeight 
                        && col < bathmanWidth - topPatternHeight;
                    bool isBottomPattern = row >= (topPatternHeight + middlePatternHeiht) && 
                        (row - col < height - earsPosition && 
                        row + col < height + earsPosition);

                    batman[row, col] = ' ';

                    if (isTopPartten)
                    {
                        batman[row, col] = symbol;
                    }

                    if (isEarsPattern)
                    {
                        batman[row, col] = symbol;
                    }

                    if (isMiddlePatterrn)
                    {
                        batman[row, col] = symbol;
                    }

                    if (isBottomPattern)
                    {
                        batman[row, col] = symbol;
                    }
                }
            }

            return batman;
        }

        private static void Draw(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
