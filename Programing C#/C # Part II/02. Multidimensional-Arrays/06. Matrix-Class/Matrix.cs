namespace _06.Matrix_Class
{
    using System;
    using System.Text;

    public class Matrix
    {
        private const string DiffrentDimention = "Both matrices must have same dimentions.";

        private int rows;
        private int cols;
        private int[,] matrix;

        public Matrix(int rowCount, int colCount)
        {
            this.Rows = rowCount;
            this.Cols = colCount;
            this.matrix = new int[rowCount, colCount];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("rows count", "The matrix must have at least one row.");
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("cols count", "The matrix must have at least one col.");
                }

                this.cols = value;
            }
        }

        public int this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }

            set
            {
                if (row < 0 || row > this.Rows || col < 0 || col > this.Cols)
                {
                    throw new IndexOutOfRangeException();
                }

                this.matrix[row, col] = value;
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Cols != b.Cols || a.Rows != b.Rows)
            {
                throw new Exception(DiffrentDimention);
            }

            Matrix result = new Matrix(a.Rows, a.Cols);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    result[row, col] = a[row, col] + b[row, col];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Cols != b.Cols || a.Rows != b.Rows)
            {
                throw new Exception(DiffrentDimention);
            }

            Matrix result = new Matrix(a.Rows, a.Cols);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    result[row, col] = a[row, col] - b[row, col];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
            {
                throw new Exception("First matrice cols count must be equal second matrice rows count.");
            }

            Matrix result = new Matrix(a.Rows, b.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    var temp = 0;
                    for (int i = 0; i < result.Cols; i++)
                    {
                        temp += a[row, i] * b[i, col];
                    }

                    result[row, col] = temp;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    result.Append(this.matrix[i, j] + "\t");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
