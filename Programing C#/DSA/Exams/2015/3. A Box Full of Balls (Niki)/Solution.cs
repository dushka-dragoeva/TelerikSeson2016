using System;
using System.Collections.Generic;
using System.Linq;

public static class ABoxFullOfBalls
{
    public static void Main()
    {
        var turns = Console.ReadLine().Split(' ').Select(int.Parse);
        var aAndB = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var answer = CalculateNumberOfWins(turns, aAndB[0], aAndB[1]);
        Console.WriteLine(answer);
    }

    private static int CalculateNumberOfWins(IEnumerable<int> turns, int a, int b)
    {
        var isWinningCase = new bool[b + 101];
        for (var i = 0; i <= b; i++)
        {
            if (!isWinningCase[i])
            {
                foreach (var turn in turns)
                {
                    isWinningCase[i + turn] = true;
                }
            }
        }

        // Get all winning cases for games with [a...b] number of balls
        var numberOfGamesWithWin = isWinningCase.Where((isWin, k) => k >= a && k <= b && isWin).Count();
        return numberOfGamesWithWin;
    }
}
