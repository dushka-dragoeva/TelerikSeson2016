using Interpretor.Models;
using System;
using System.Collections;

namespace Interpretor
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            // Usually a tree 
            ArrayList list = new ArrayList();

            // Populate 'abstract syntax tree' 
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            // Interpret 
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            // Wait for user 
            Console.Read();

        }
    }
}
