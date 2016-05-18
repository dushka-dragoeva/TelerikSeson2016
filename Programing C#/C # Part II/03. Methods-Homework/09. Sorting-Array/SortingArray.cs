using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var length = int.Parse(Console.ReadLine());
        var arr = ConvertToArray(Console.ReadLine());
        Array.Sort(arr);
        Console.WriteLine(string.Join(" ", arr));
    }

    private static int[] ConvertToArray(string number)
    {
        int[] num = number
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        return num;
    }
}