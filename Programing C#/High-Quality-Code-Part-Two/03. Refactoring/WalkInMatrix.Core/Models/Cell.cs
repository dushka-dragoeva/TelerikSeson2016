using System;

namespace WalkInMatrix.Core.Models
{
    public class Cell
    {
        private int row;
        private int col;

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Row cannot be negative.");
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Col cannot be negative.");
                }

                this.col = value;
            }
        }
    }
}
