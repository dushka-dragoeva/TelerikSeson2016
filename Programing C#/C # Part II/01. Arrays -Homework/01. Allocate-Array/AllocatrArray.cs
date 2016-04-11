/// Write a program that allocates array of N integers, initializes each element by its index 
/// multiplied by 5 and the prints the obtained array on the console.
using System;

public class AllocatrArray
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            array[i] = 5 * i;
            Console.WriteLine(array[i]);
        }
    }
}
