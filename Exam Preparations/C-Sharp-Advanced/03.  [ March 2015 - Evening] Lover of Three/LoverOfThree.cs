using System;
using System.Linq;

public class LoverOfThree
{
    private const string UpRihgt = "up-right";
    private const string UpLeft = "up-left";
    private const string DownRight = "down-right";
    private const string DownLeft = "down-left";
    private const int LovedNumber = 3;

    private static int rows;
    private static int cols;
    private static int numberOfMoves;
    private static string[] directions;
    private static int[] moves;

    public static void Main(string[] args)
    {
        var input = Console.ReadLine();
        int[] arr = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        rows = arr[0];
        cols = arr[1];

        numberOfMoves = int.Parse(Console.ReadLine());

        directions = new string[numberOfMoves];
        moves = new int[numberOfMoves];

        for (int i = 0; i < numberOfMoves; i++)
        {
            var temp = Console.ReadLine()
                .Split(' ')
                .ToArray();

            directions[i] = temp[0];
            moves[i] = int.Parse(temp[1]);
        }

        var field = new bool[rows, cols];

        long sum = 0;
        var size = rows - 1;

        sum = Colect(ref field);

        Console.WriteLine(sum);
    }

    private static long Colect(ref bool[,] field)
    {
        string direction = string.Empty;
        long sum = 0;

        var pawnRow = rows - 1;
        var pawnCol = 0;
        var current = 0;

        for (int i = 0; i < numberOfMoves; i++)
        {
            direction = ChangeDirection(directions[i]);

            for (int m = 0; m < moves[i] - 1; m++)
            {
                if ((direction == UpRihgt && pawnRow > 0 && pawnCol < cols - 1) ||
                   (direction == UpLeft && pawnRow > 0 && pawnCol > 0) ||
                   (direction == DownRight && pawnRow < rows - 1 && pawnCol < cols - 1) ||
                   (direction == DownLeft && pawnRow < rows - 1 && pawnCol > 0))
                {
                    Move(ref pawnRow, ref pawnCol, direction);

                    if (!field[pawnRow, pawnCol])
                    {
                        current = LovedNumber * ((rows - 1) - (pawnRow - pawnCol));

                        sum += current;
                        field[pawnRow, pawnCol] = true;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        return sum;
    }

    private static void Move(ref int row, ref int col, string direction)
    {
        switch (direction)
        {
            case UpRihgt:
                row--;
                col++;
                break;
            case UpLeft:
                row--;
                col--;
                break;
            case DownRight:
                row++;
                col++;
                break;
            case DownLeft:
                row++;
                col--;
                break;
            default:
                throw new ArgumentException("Direction", "Value is not valid.");
        }
    }

    private static string ChangeDirection(string command)
    {
        var direction = string.Empty;
        if (command == "RU" || command == "UR")
        {
            direction = UpRihgt;
        }
        else if (command == "LU" || command == "UL")
        {
            direction = UpLeft;
        }
        else if (command == "RD" || command == "DR")
        {
            direction = DownRight;
        }
        else if (command == "DL" || command == "LD")
        {
            direction = DownLeft;
        }

        return direction;
    }
}
