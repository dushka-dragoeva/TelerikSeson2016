using System;

class BobbyAvokadoto
{
    static void Main()
    {
        uint head = uint.Parse(Console.ReadLine());
        uint combCount = uint.Parse(Console.ReadLine());
        uint bestComb = 0;
        int maxTheets = 0;

        for (int i = 0; i < combCount; i++)
        {
            uint currentComb = uint.Parse(Console.ReadLine());
            if (IsOverlaping(head, currentComb))
            {
                continue;
            }

            var teeths = CountOnes(currentComb);
            if (teeths > maxTheets)
            {
                maxTheets = teeths;
                bestComb = currentComb;
            }
        }

        Console.WriteLine(bestComb);
    }

    public static int CountOnes(uint number)
    {
        int count = 0;
        for (int i = 0; i < 32; i++)
        {
            if (GetBit(number, i) == 1)
            {
                count++;
            }

        }
        return count;
    }

    public static uint GetBit(uint number, int position)
    {
        uint numberAndMask = ((uint)1 << position) & number;
        uint bitValue = numberAndMask >> position;
        return bitValue;
    }

    public static bool IsOverlaping(uint n, uint m)
    {
        bool isOver = false;
        uint nm = n ^ m;
        for (int i = 0; i < 32; i++)
        {
            if (GetBit(n, i) == 1 && GetBit(nm, i) == 0)
            {
                isOver = true;
            }
        }
        return isOver;
    }
}
