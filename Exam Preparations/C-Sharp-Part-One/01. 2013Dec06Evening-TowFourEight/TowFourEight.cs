using System;

public class TowFourEight
{
    public static void Main()
    {
        long a = long.Parse(Console.ReadLine());
        long sicretSymbolB = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());
        long result = 0;

        switch (sicretSymbolB)
        {
            case 2:
                result = a % c;
                break;
            case 4:
                result = a + c;
                break;
            case 8:
                result = a * c;
                break;
            default:
                result = 0;
                break;
        }

        long finalResult = 0;
        if (result % 4 == 0)
        {
            finalResult = result / 4;
            Console.WriteLine(finalResult);
        }
        else
        {
            finalResult = result % 4;
            Console.WriteLine(finalResult);
        }

        Console.WriteLine(result);
    }
}
