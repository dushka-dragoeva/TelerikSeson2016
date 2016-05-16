namespace _06.Matrix_Class
{
    using System;

    public class MatrixClass
    {
        private static string separator = new string('=', 60);

        public static void Main()
        {
            Matrix a = new Matrix(4, 6);
            Matrix b = new Matrix(4, 6);
            Matrix c = new Matrix(6, 2);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    a[i, j] = (1 * j) + (2 * i);
                    b[i, j] = (5 * j) + (i * 3);
                }
            }

            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Cols; j++)
                {
                    c[i, j] = (7 * j) + (2 * i);
                }
            }

            Console.WriteLine(a.ToString());
            Console.WriteLine(separator);
            Console.WriteLine(b.ToString());
            Console.WriteLine(separator);
            Console.WriteLine(c.ToString());
            Console.WriteLine(separator);

            Console.WriteLine((a + b).ToString());
            Console.WriteLine(separator);
            Console.WriteLine((a - b).ToString());
            Console.WriteLine(separator);
            Console.WriteLine((a * c).ToString());
            Console.WriteLine(separator);
            Console.WriteLine((b * c).ToString());
        }
    }
}