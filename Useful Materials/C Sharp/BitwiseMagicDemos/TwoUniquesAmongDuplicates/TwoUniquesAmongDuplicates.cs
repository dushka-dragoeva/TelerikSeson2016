using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoUniquesAmongDuplicates
{
    class TwoUniquesAmongDuplicates
    {
        static void Main(string[] args)
        {
            int[] table = new int[32];
            int allXored = XorInputAndReadIntoTable(table);

            int resultA = 0;
            int resultB = 0;
            ComputeTwoUniquesFromTableAndAllXored(table, allXored, ref resultA, ref resultB);

            Console.WriteLine(resultA + " " + resultB);
        }

        private static void ComputeTwoUniquesFromTableAndAllXored(int[] table, int allXored, ref int resultA, ref int resultB)
        {
            int mask = 1;
            for (int offset = 0; offset < 31; offset++)
            {
                if ((allXored & (mask << offset)) != 0)
                {
                    resultA = allXored ^ table[offset];
                    resultB = allXored ^ resultA;
                    break;
                }
            }
        }

        private static int XorInputAndReadIntoTable(int[] table)
        {
            string inputLine = Console.ReadLine();

            int allXored = 0;
            while (inputLine != "end")
            {
                int number = int.Parse(inputLine);
                allXored ^= number;

                int mask = 1;
                for (int offset = 0; offset < 31; offset++)
                {
                    if ((number & (mask << offset)) != 0)
                    {
                        table[offset] ^= number;
                    }
                }

                inputLine = Console.ReadLine();
            }

            return allXored;
        }
    }
}
