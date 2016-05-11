using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Fill_The_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimention = int.Parse(Console.ReadLine());
            // char fillStyle = Console.ReadLine()[0];
            FillMatrixStyleA(dimention);

            PrintMatrix(FillMatrixStyleB(dimention));
        }

        public static void PrintMatrix(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static int[,] FillMatrixStyleA(int dimention)
        {
            var temp = 1;

            int[,] matrix = new int[dimention, dimention];

            for (int i = 0; i < dimention; i++)
            {
                for (int j = 0; j < dimention; j++)
                {
                    matrix[j, i] = temp;
                    temp++;
                }
            }

            return matrix;
        }

        public static int[,] FillMatrixStyleB(int dimention)
        {
            var temp = 1;
            int[,] matrix = new int[dimention, dimention];

            for (int i = 0; i < dimention; i++)
            {
                for (int j = 0; j < dimention; j++)
                {
                    if (i % 2 == 0)
                    {
                        for (int col = 0; col <dimention; col++)
                        {
                            matrix[col, i] = temp;
                            temp++;
                        }
                       
                    }
                    else
                    {
                        for (int col = dimention - 1; col >= 0; col--)
                        {
                            matrix[col, i] = temp;
                            temp++;
                        }
                        // matrix[j, i] = temp;

                    }
                }
            }

            //for (int i = 0; i < dimention; i++)
            //{
            //    matrix[i, 0] = i + 1;

            //    for (int j = 1; j < dimention; j++)
            //    {
            //        if (j % 2 == 1)
            //        {
            //            matrix[i, j] =j* dimention+(dimention-i);
            //        }
            //        else
            //        {
            //            matrix[i, j] = (i + (j * dimention)) + 1;
            //        }
            //    }
            //}

            return matrix;
        }

        public static int[,] FillMatrixStyleC(int dimention)
        {
            int[,] matrix = new int[dimention, dimention];

            for (int i = 0; i < dimention; i++)
            {
                matrix[i, 0] = i * (dimention - i);
                for (int j = 1; j < dimention; j++)
                {
                    //  matrix[i, j] = i + dimention*j - dimention/j;

                }
            }

            return matrix;
        }
        public static void FillMatrixStyleD(int dimention)
        {
            int[,] matrix = new int[dimention, dimention];

            for (int i = 0; i < dimention; i++)
            {
                matrix[i, 0] = i + 1;
                for (int j = 1; j < dimention; j++)
                {
                    matrix[i, j] = (i + (j * dimention)) + 1;
                }
            }

            PrintMatrix(matrix);
        }

    }
}
