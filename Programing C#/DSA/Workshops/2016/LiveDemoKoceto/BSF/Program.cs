using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Zagotovka za namirane na koren na darvo da si napravia
 8

0-> 1,2,3
1->4 
2->-1 // no children
3-> 5
4-> 6
5-> 7
 6-> -1
 7->-1
     */
namespace BSF
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dependences = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                

                dependences[i] = Console.ReadLine().Split(' ')
                    .Select(x => int.Parse(x) - 1).ToList();
            }



        }
    }
}
