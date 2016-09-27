using System;
using System.Text;
using WalkInMatrix.Core.Utils;

namespace WalkInMatrix.Core.Models
{
    public class SquareMatrix
    {
        private const int MinSize = 1;
        private const int MaxSize = 100;

        private int size;
        private int[,] matrix;

        public SquareMatrix(int size)
        {
            this.Size = size;
            this.matrix = new int[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < SquareMatrix.MinSize || value > SquareMatrix.MaxSize)
                {
                    throw new ArgumentException($"Matrix size should be in range [{SquareMatrix.MinSize}; {SquareMatrix.MaxSize}]");
                }

                this.size = value;
            }
        }

        public int[,] Matrix
        {
            get
            {
                return (int[,])this.matrix.Clone();
            }
        }

        public void FillRotatingWalk()
        {
            var cell = this.matrix.GetStartPosition();
            var direction = Direction.DownRight;
            var deltaRow = MatrixUtils.GetRowDelta(direction);
            var deltaCol = MatrixUtils.GetColDelta(direction);
            var cellValue = 1;
            var isCellValueValid = cellValue <= this.Size * this.Size;

            while (isCellValueValid)
            {
                this.matrix[cell.Row, cell.Col] = cellValue;

                if (!this.matrix.CanContinueInDirection(cell.Row + deltaRow, cell.Col + deltaCol))
                {
                    bool allNeighboursAreFilled = false;

                    if (this.matrix.AreAllNeighboursFilled(cell.Row, cell.Col))
                    {
                        allNeighboursAreFilled = true;

                        cell = this.matrix.GetStartPosition();
                        if (cell == null)
                        {
                            break;
                        }

                        direction = Direction.DownRight;
                    }
                    else
                    {
                        direction = this.matrix.GetNextDirection(direction, cell.Row, cell.Col);
                    }

                    deltaRow = MatrixUtils.GetRowDelta(direction);
                    deltaCol = MatrixUtils.GetColDelta(direction);

                    if (allNeighboursAreFilled)
                    {
                        continue;
                    }
                }

                cell.Row += deltaRow;
                cell.Col += deltaCol;
                cellValue += 1;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    result.AppendFormat($"{this.matrix[row, col],-5}");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}