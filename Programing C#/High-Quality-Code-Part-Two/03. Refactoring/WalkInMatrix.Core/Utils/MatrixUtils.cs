using System;
using WalkInMatrix.Core.Models;

namespace WalkInMatrix.Core.Utils
{
    public static class MatrixUtils
    {
        private const int DirectionsCount = 8;
        private static readonly int[] DeltaRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] DeltaCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public static bool AreAllNeighboursFilled(this int[,] matrix, int currentRow, int currentCol)
        {
            int upperRow = currentRow > 0 ? currentRow - 1 : currentRow;
            int lowerRow = currentRow < matrix.GetLength(0) - 1 ? currentRow + 1 : currentRow;
            int leftCol = currentCol > 0 ? currentCol - 1 : currentCol;
            int rightCol = currentCol < matrix.GetLength(1) - 1 ? currentCol + 1 : currentCol;

            for (int row = upperRow; row <= lowerRow; row++)
            {
                for (int col = leftCol; col <= rightCol; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static Cell GetStartPosition(this int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return new Cell(row, col);
                    }
                }
            }

            return null;
        }

        public static bool CanContinueInDirection(this int[,] matrix, int currentRow, int currentCol)
        {
            var canContinue = matrix.IsInRange(currentRow, currentCol) &&
                matrix[currentRow, currentCol] == 0;
        
            return canContinue;
        }

        public static Direction GetNextDirection(this int[,] matrix, Direction currentDirection, int currentRow, int currentCol)
        {
            for (int i = 0; i < DirectionsCount; i++)
            {
                var nextDirection = (Direction)(((int)currentDirection + i) % DirectionsCount);
                var nextRow = currentRow + GetRowDelta(nextDirection);
                var nextCol = currentCol + GetColDelta(nextDirection);

                if (matrix.CanContinueInDirection(nextRow, nextCol))
                {
                    return nextDirection;
                }
            }

            throw new InvalidOperationException("The matrix is filled.");
        }

        public static int GetRowDelta(Direction direction)
        {
            return DeltaRow[(int)direction];
        }

        public static int GetColDelta(Direction direction)
        {
            return DeltaCol[(int)direction];
        }

        private static bool IsInRange(this int[,] matrix, int currentRow, int currentCol)
        {
            bool rowIsInRange = currentRow >= 0 && currentRow < matrix.GetLength(0);
            bool colIsInRange = currentCol >= 0 && currentCol < matrix.GetLength(1);

            return rowIsInRange && colIsInRange;
        }
    }
}
