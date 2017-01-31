using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMarket.Solution
{
    class MainClass
    {
        const string ProductAddedSuccessFormat = "Ok: Product {0} added successfully";
        const string ProductAddedErrorFormat = "Error: Product {0} already exists";
        const string FilterSuccessFormat = "Ok: {0}";
        const string InvalidTypeErrorFormat = "Error: Type {0} does not exists";

        public static void Main(string[] args)
        {
            var market = new SuperMarket();
            while (true)
            {
                string input = Console.ReadLine();
                var command = Command.ParseCommand(input);
                switch (command.Type)
                {
                    case CommandType.Add: 
                        var product = Product.ParseProduct(command.Params);
                        var addResult = market.AddProduct(product);
                        string format;
                        if (addResult)
                        {
                            format = ProductAddedSuccessFormat;
                        }
                        else
                        {
                            format = ProductAddedErrorFormat;
                        }
                        Console.WriteLine(format, product.Name);
                        break;
                    case CommandType.FilterByPrice:
                        double from = 0;
                        double to = double.MaxValue;
                        var paramParts = command.Params.Split(' ');
                        int currentIndex = 0;
                        if (paramParts[currentIndex] == "from")
                        {
                            from = double.Parse(paramParts[currentIndex + 1]);
                            currentIndex += 2;
                        }
                        if (currentIndex < paramParts.Length && paramParts[currentIndex] == "to")
                        {
                            to = double.Parse(paramParts[currentIndex + 1]);
                        }
                        var result = market.FilterProducts(from, to);
                        Console.WriteLine(FilterSuccessFormat, string.Join(", ", result));
                        break;
                    case CommandType.FilterByType:
                        var filterByTypeResult = market.FilterProducts(command.Params);
                        if (filterByTypeResult == null)
                        {
                            Console.WriteLine(InvalidTypeErrorFormat, command.Params);
                        }
                        else
                        {
                            Console.WriteLine(FilterSuccessFormat, string.Join(", ", filterByTypeResult));
                        }
                        break;
                    case CommandType.End:
                        return;
                }
            }
        }
    }
}