using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArithmeticalExpressions
{
    private static List<string> OutputExpression = new List<string>();
    private static List<string> OperatorStack = new List<string>();
    private static string[] OperatorKey = "+ - * / %".Split(' ');

    public static void Main()
    {
        // https://en.wikipedia.org/wiki/Shunting-yard_algorithm
        // Shunting Yard Algorithm
        // Step 1: Read the expression and iterate through the string
    }

}