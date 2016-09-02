/*and

if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
{
   VisitCell();
}*/
using System;

namespace ControlFlowConditionalStatementsLoops.Task2
{
    public class CellValidator
    {
        public void ShouldVisitCell(int minX, int maxX, int minY, int maxY, int currentX, int currentY)
        {
            var shouldVisitCell = this.ShouldCellBeVisited(currentX, currentY);
            var isCellInRange = this.CheckIfCellIsInRange(minX, maxX, minY, maxY, currentX, currentY);

            if (isCellInRange && shouldVisitCell)
            {
                this.VisitCell();
            }
            else
            {
                throw new ArgumentException("The cell is out of range or should not be visited");
            }
        }

        private bool ShouldCellBeVisited(int currentX, int currentY)
        {
            throw new NotImplementedException();
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }

        private bool CheckIfCellIsInRange(int minX, int maxX, int minY, int maxY, int currentX, int currentY)
        {
            var isXCoordinateValid = minX < currentX && currentX < maxX;
            var isYCoordinateValid = minY < currentY && currentY < maxY;
            var isCellInRange = isXCoordinateValid && isYCoordinateValid;

            return isCellInRange;
        }
    }
}