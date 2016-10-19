
####Read int Matrix

 public static int[,] ReadMatrix()
    {
        var matrixSize = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray();

        int rows = matrixSize[0];
        int cols = matrixSize[1];
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var currentRow = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = currentRow[j];
            }
        }

        return matrix;
    }
	
#### Read string matrix

 public static string [,] ReadMatrix()
        {
            var matrixSize = Console.ReadLine().Split(' ')
               .Select(int.Parse)
               .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>x.ToString())
                .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            return matrix;	

###Print String MAtrix
  public static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j > 0)
                    {
                        Console.Write(" ");
                    }

                    Console.Write("{0}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
		
####Print int matrix
public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j > 0)
                {
                    Console.Write(" ");
                }

                Console.Write("{0}", matrix[i, j]);
            }

            Console.WriteLine();
        }
		
		 public static int[,] ReadMatrix()
    {
        var matrixSize = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray();

        int rows = matrixSize[0];
        int cols = matrixSize[1];
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var currentRow = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = currentRow[j];
            }
        }

        return matrix;
    }