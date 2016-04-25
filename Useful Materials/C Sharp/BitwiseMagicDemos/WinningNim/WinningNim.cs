using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinningNim
{
    class WinningNim
    {
        static void Main(string[] args)
        {
            List<uint> heaps = Input();
            TryGetIntoLosingPosition(heaps);
            Console.WriteLine(String.Join(" ", heaps));
        }

        private static void TryGetIntoLosingPosition(List<uint> heaps)
        {
            uint nimSum = NimSum(heaps);
            if (nimSum != 0)
            {
                uint nimSumCopy = nimSum;
                int leftMostUpBitIndex = 0;
                while (nimSumCopy > 0)
                {
                    nimSumCopy = nimSumCopy >> 1;
                    leftMostUpBitIndex++;
                }

                leftMostUpBitIndex--;

                int nulledNumberInd = 0;
                for (int i = 0; i < heaps.Count; i++)
                {
                    if ((heaps[i] & ((uint)1 << leftMostUpBitIndex)) > 0)
                    {
                        heaps[i] = 0;
                        nulledNumberInd = i;
                        break;
                    }
                }

                uint nimSumAfterNulling = NimSum(heaps);
                heaps[nulledNumberInd] = nimSumAfterNulling;
            }
            else
            {
                Console.WriteLine("Lose");
            }
        }

        private static uint NimSum(List<uint> heaps)
        {
            uint nimSum = 0;
            for (int i = 0; i < heaps.Count; i++)
            {
                nimSum ^= heaps[i];
            }
            return nimSum;
        }

        private static List<uint> Input()
        {
            List<uint> heaps = new List<uint>();

            String stateLine = Console.ReadLine();

            String[] heapSizeStrings = stateLine.Split(' ');
            int heapsCount = heapSizeStrings.Length;

            for (int i = 0; i < heapsCount; i++)
            {
                heaps.Add(uint.Parse(heapSizeStrings[i]));
            }

            return heaps;
        }
    }
}
