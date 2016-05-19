using System;

public class RandomNumbers
{
    public static void Main(string[] args)
    {
        Random numberGenerator = new Random();

        for (int i = 0; i < 10; i++)
        {
            var rand = numberGenerator.Next(100, 201);
            Console.WriteLine(rand);
        }
    }
}