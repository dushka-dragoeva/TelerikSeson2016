using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
         //   254 488 & 61 / 771 24 | *394 3 428 | 141 171 & + | / 654 *
           var input = Console.ReadLine().Split(' ').ToArray();
           // Console.WriteLine(string.Join(", ",input));
            //  var result = 0;
            var result = new Stack<int>();
           // var number = 0;
            var a = 0;
            var b = 0;
            foreach (var symbol in input)
            {
                var number = 0;
                if (int.TryParse(symbol, out number))
                {
                    result.Push(number);
                }
                else
                {
                    switch (symbol)
                    {
                        case "+":
                            a = result.Pop();
                            b = result.Pop();
                            result.Push(a + b);
                            break;
                        case "-":
                            a = result.Pop();
                            b = result.Pop();
                            result.Push(b- a);
                            break;
                        case "*":
                            a = result.Pop();
                            b = result.Pop();
                            result.Push(b * a);
                            break;

                        case "/":
                            a = result.Pop();
                            b = result.Pop();
                            result.Push(b / a);
                            break;
                        case "&":
                            a = result.Pop();
                            b = result.Pop();
                            result.Push(b & a);
                            break;
                        case "|":
                            a = result.Pop();
                            b = result.Pop();
                            result.Push(b | a);
                            break;
                        case "^":
                            a = result.Pop();
                            b = result.Pop();
                            result.Push(b ^ a);
                            break;
                       
                    }
                }
            }

            Console.WriteLine(result.Peek());
        }
    }
}
