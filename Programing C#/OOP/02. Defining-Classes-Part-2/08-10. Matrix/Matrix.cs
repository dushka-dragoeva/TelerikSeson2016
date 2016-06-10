namespace _08_10.Matrix
{
    using System;
    using System.Text;

    public class Matrix<T>
          where T : struct, IComparable
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int inputRows, int inputCols)
        {
            this.Rows = inputRows;
            this.Cols = inputCols;
            this.matrix = new T[inputRows, inputCols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value > 0 && value < int.MaxValue)
                {
                    this.rows = value;
                }
                else
                {
                    throw new ArgumentException("Rows must be between 1 and  2,147,483,647!");
                }
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
                if (value > 0 && value < int.MaxValue)
                {
                    this.cols = value;
                }
                else
                {
                    throw new ArgumentException("Cols must be between 1 and  2,147,483,647!");
                }
            }
        }

        public T this[int inputRow, int inputCol]
        {
            get
            {
                if (inputRow < 0 || inputRow > this.Rows)
                {
                    throw new IndexOutOfRangeException($"Rows and Cols must be between 0 and {this.Rows - 1}!");
                }
                else if (inputCol < 0 || inputCol > this.Cols)
                {
                    throw new IndexOutOfRangeException($"Cols and Cols must be between 0 and {this.Cols - 1}!");
                }
                else
                {
                    return this.matrix[inputRow, inputCol];
                }
            }

            set
            {
                if (inputRow < 0 || inputRow > this.Rows)
                {
                    throw new IndexOutOfRangeException($"Rows and Cols must be between 0 and {this.Rows - 1}!");
                }
                else if (inputCol < 0 || inputCol > this.Cols)
                {
                    throw new IndexOutOfRangeException($"Cols and Cols must be between 0 and {this.Cols - 1}!");
                }
                else
                {
                    this.matrix[inputRow, inputCol] = value;
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            var result = new Matrix<T>(first.Rows, first.Cols);

            if (first.Rows == second.Rows && first.Cols == second.Cols)
            {
                for (int row = 0; row < first.Rows; row++)
                {
                    for (int col = 0; col < first.Cols; col++)
                    {
                        result[row, col] = (dynamic)first[row, col] + (dynamic)second[row, col];
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Both  matrix must be same size!");
            }
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            var result = new Matrix<T>(first.Rows, first.Cols);

            if (first.Rows == second.Rows && first.Cols == second.Cols)
            {
                for (int row = 0; row < first.Rows; row++)
                {
                    for (int col = 0; col < first.Cols; col++)
                    {
                        result[row, col] = (dynamic)first[row, col] - (dynamic)second[row, col];
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Both  matrix must be same size!");
            }
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            Matrix<T> result = new Matrix<T>(first.Rows, first.Rows);

            if (first.Rows == second.Cols)
            {
                for (int row = 0; row < result.Rows; row++)
                {
                    for (int col = 0; col < result.Cols; col++)
                    {
                        for (int i = 0; i < result.Cols; i++)
                        {
                            result[row, col] += (dynamic)first[row, i] * (dynamic)second[i, col];
                        }
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException(" The colums of first matrix must be equal to rows of second matrix!");
            }
        }

        public static bool operator true(Matrix<T> matrix)
        {
            return OverideBool(matrix);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return OverideBool(matrix);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    result.Append(this.matrix[row, col] + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        public void FillMatrix()
        {
            var generator = new Random();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.matrix[i, j] = (dynamic)generator.Next(-15, 100);
                }
            }
        }

        private static bool OverideBool(Matrix<T> matrix)
        {
            bool result = true;
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (matrix[row, col] == (dynamic)0)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
