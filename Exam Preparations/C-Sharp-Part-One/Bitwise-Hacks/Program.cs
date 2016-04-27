using System;

    class Program
    {
        static void Main(string[] args)
        {

        int number = int.Parse(Console.ReadLine());

        int a = 5;
        int b = 56;
        Console.WriteLine("{0} {1}", a,b);
        a ^= b;
        b ^= a;
        a ^= b;
        Console.WriteLine("=====================");
        Console.WriteLine("{0} {1}", a, b);

        bool powerOfTow = (a&(a-1))==0;

        Console.WriteLine(powerOfTow);
    }
    }
