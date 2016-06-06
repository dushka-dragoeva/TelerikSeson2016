using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

        var input = Console.ReadLine();
        var cubeDimentions = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        var x = cubeDimentions[0];
        var y = cubeDimentions[1];
        var z = cubeDimentions[2];

        var rows = x + 1;
        var cols = 2 * (y + z);

        var visited = new bool[rows, cols];
        var redCommands = Console.ReadLine();
        var blueCommands = Console.ReadLine();

        var redStartRow = x / 2;
        var redStartCol = y / 2;

        var redRow = redStartRow;
        var redCol = redStartCol;

        var redDirection = 0;
        var hasRedCrashed = false;
        var redIndex = 0;

        var blueRow = x / 2;
        var blueCol = (y + z) + (y / 2);

        var blueDirection = 2;

        var hasBlueCrashed = false;
        var blueIndex = 0;


        /*directions
       0 => right
       1 => down
       2 => left
       3 => up */
        int[] deltaRows = { 0, 1, 0, -1 };
        int[] deltaCols = { 1, 0, -1, 0 };

        visited[redRow, redCol] = true;
        visited[blueRow, blueCol] = true;

        while (!hasRedCrashed &&
            !hasBlueCrashed &&
            redIndex < redCommands.Length
            && blueIndex < blueCommands.Length)
        {

            //// RED PLAYER
            /// въвеждаме променлива, която чете  текущата командата
            char redCommand = redCommands[redIndex];

            while (redCommand != 'M')
            {
                redDirection = ChangeDir(redDirection, redCommand);

                /// update red index
                ++redIndex;
                redCommand = redCommands[redIndex];
            }

            /// BLUE PALYER
            char blueCommand = blueCommands[blueIndex];

            while (blueCommand != 'M')
            {
                blueDirection = ChangeDir(blueDirection, blueCommand);
                ++blueIndex;
                blueCommand = blueCommands[blueIndex];
            }

            /// update  positions
            int nextRedRow = redRow + deltaRows[redDirection];
            int nextRedCol = redCol + deltaCols[redDirection];
            nextRedCol = (nextRedCol + cols) % cols; /// to chec
            redIndex++;

            int nextBlueRow = blueRow + deltaRows[blueDirection];
            int nextBlueCol = blueCol + deltaCols[blueDirection];
            nextBlueCol = (nextBlueCol + cols) % cols;
             blueIndex++;

            /// check if next position is valid
            if (nextRedRow < 0 || nextRedRow >= rows)
            {
                Console.WriteLine("OutRangeR");
                hasRedCrashed = true;
               //   redRow = nextRedRow;
               //   redCol = nextRedCol;
            }
            else if (visited[nextRedRow, nextRedCol]) /// OK
            {

                Console.WriteLine("VisitedR");
                hasRedCrashed = true;
                redRow = nextRedRow;
                redCol = nextRedCol;
            }

            if (nextBlueRow < 0 || nextBlueRow >= rows)
            {
                Console.WriteLine("OutRangeB");
                hasBlueCrashed = true;
                if (!hasRedCrashed)
                {
                    redRow = nextRedRow;
                    redCol = nextRedCol;
                }

            }
            else if (visited[nextBlueRow, nextBlueCol])
            {
                if (!hasRedCrashed)
                {

                    redRow = nextRedRow;
                    redCol = nextRedCol;
                }
            }

            if (nextRedRow == nextBlueRow && nextRedCol == nextBlueCol)
            {
                hasBlueCrashed = true;
                hasRedCrashed = true;
                redRow = nextRedRow;
                redCol = nextRedCol;
            }

            if (hasRedCrashed || hasBlueCrashed)
            {
                break;
            }
            else
            {
                redRow = nextRedRow;
                redCol = nextRedCol;
                blueRow = nextBlueRow;
                blueCol = nextBlueCol;

                visited[redRow, nextRedCol] = true;
                visited[nextBlueRow, nextBlueCol] = true;
            }
        }

        //if (hasRedCrashed && hasBlueCrashed)
        //{
        //    Console.WriteLine("DRAW");
        //}
        //else if (!hasRedCrashed &&
        //    !hasBlueCrashed &&
        //    redIndex == redCommands.Length - 1 &&
        //    blueIndex == blueCommands.Length - 1)
        //{
        //    Console.WriteLine("DRAW");
        //}
        if (hasRedCrashed)
        {
            Console.WriteLine("BLUE");
        }
        else if (hasBlueCrashed)
        {
            Console.WriteLine("RED");
        }
        else
        {
            Console.WriteLine("DRAW");
        }
        var distance = Math.Abs((redStartRow - redRow)) +
           Math.Abs(redStartCol - redCol);
        Console.WriteLine(distance);
        Console.WriteLine(redIndex); ;
        // PrintMatrix(visited);
    }

    private static int ChangeDir(int direction, char command)
    {
        if (command == 'L')
        {
            --direction;
        }
        else
        {
            ++direction;
        }

        return (direction + 4) % 4;
    }

    private static string ConvertMoves(string path)
    {
        var convertedPath = new StringBuilder();
        List<char> digits = new List<char>();

        foreach (var symbol in path)
        {
            if (char.IsDigit(symbol))
            {
                digits.Add(symbol);
            }
            else
            {
                if (digits.Count == 0)
                {
                    digits.Add('1');
                }
                digits.Reverse();

                int count = int.Parse(string.Join("", digits));
                convertedPath.Append(symbol, count);
                digits.Clear();
            }
        }

        // convertedPath.Replace("LM", "L");
        // convertedPath.Replace("RM", "R");

        return convertedPath.ToString().Trim();
    }

    private static void PrintMatrix(bool[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0} ", matrix[i, j] == true ? "1" : "0");
            }
            Console.WriteLine();
        }
    }
}