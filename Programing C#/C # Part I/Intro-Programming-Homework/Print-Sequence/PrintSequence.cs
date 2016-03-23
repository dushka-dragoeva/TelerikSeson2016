// Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
namespace Print_Sequence
{
    using System;

    public class PrintSequence
    {
        public static void Main()
        {
            /// for-loop, който ще ни позволи да обходим всички числа от 2 до 11 вкл
            /// i -  променлива от тип Integer, която ще управлява цикъла
            /// на всяка итерация i ще се увеличава с 1 (i++)
            for (int i = 2; i <= 11; i++)
            {
                // променлива от тип Integer, която ще използваме за отпечатване на резултата
                int result = i;
                /// % - деление с остатък, връща стойността на остатъка, т.е. ако е 1 значи 
                /// числото е нечетно и сменяме знака на i

                if (result % 2 == 1)
                {
                    result = -i;
                }

                Console.WriteLine(result);
            }
        }
    }
}
