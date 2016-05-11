using System;

class FillTheMatrix
{
    static void Main()
    {
        //•	Write a program that fills and prints a matrix of size (n, n) 

        // variant A

        Console.WriteLine("Enter a number");
        int n = int.Parse(Console.ReadLine());
        int[,] matrixA = new int[n, n];
        int item = 1;

        for (int row = 0; row < matrixA.GetLength(0); row++)
        {
            for (int col = 0; col < matrixA.GetLength(1); col++)
            {
                matrixA[row, col] = item;
                item++;
            }
        }
        for (int r = 0; r < matrixA.GetLength(0); r++)
        {
            for (int c = 0; c < matrixA.GetLength(1); c++)
            {
                Console.Write("{0,4} ", matrixA[c, r]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        // Variant B
        item = 1;

        int[,] matrixB = new int[n, n];

        for (int row = 0; row < matrixB.GetLength(0); row++)
        {
            if (row % 2 == 0)
            {
                for (int col = 0; col < matrixB.GetLength(1); col++)
                {
                    matrixB[row, col] = item;
                    item++;
                }
            }
            else
            {
                for (int colB = n - 1; colB >= 0; colB--)
                {
                    matrixB[row, colB] = item;
                    item++;
                }
            }
        }
        for (int r = 0; r < matrixB.GetLength(0); r++)
        {
            for (int c = 0; c < matrixB.GetLength(1); c++)
            {
                Console.Write("{0,4} ", matrixB[c, r]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        //Variant C
        item = 1;

        int[,] matrixC = new int[n, n];
        int rowC = n - 1;
        int colC = 0;
        int startRow = n - 1;
        int startCol = 0;


        while (item < n * n)
        {
            if (rowC == (n - 1) && colC < (n - 1))
            {
                if (item == 1)
                {
                    matrixC[colC, rowC] = item;
                }
                startRow--;
                startCol = 0;
                rowC = startRow;
                colC = startCol;
                item++;
                matrixC[colC, rowC] = item;

                while (rowC < (n - 1) && colC < (n - 1))
                {
                    rowC++;
                    colC++;
                    item++;
                    matrixC[colC, rowC] = item;
                }
            }
            if (rowC <= (n - 1) && colC == (n - 1))
            {
                startRow = 0;
                startCol++;
                rowC = startRow;
                colC = startCol;
                item++;
                matrixC[colC, rowC] = item;

                while (colC < (n - 1))
                {
                    colC++;
                    rowC++;
                    item++;
                    matrixC[colC, rowC] = item;
                }
            }
        }
        for (int c = 0; c < n; c++)
        {
            for (int r = 0; r < n; r++)
            {
                Console.Write("{0,4} ", matrixC[r, c]);
            }
            Console.WriteLine();
        }
    }
}
