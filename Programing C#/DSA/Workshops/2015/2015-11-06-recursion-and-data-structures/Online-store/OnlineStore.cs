namespace DsaWorkshop11_06_2015
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;
    class Product
    {
        private string toStringCache;

        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(toStringCache))
            {
                this.toStringCache = string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("F2"));
            }

            return this.toStringCache;
        }
    }

    class OnlineStore
    {
        const string NoProductsFoundMessage = "No products found";
        static Dictionary<string, Bag<Product>> productsByName = new Dictionary<string, Bag<Product>>();
        static Dictionary<string, Bag<Product>> productsByProducer = new Dictionary<string, Bag<Product>>();
        static Dictionary<string, Bag<Product>> productsByNameAndProducer = new Dictionary<string, Bag<Product>>();
        static Dictionary<decimal, Bag<Product>> productsByPrice = new Dictionary<decimal, Bag<Product>>();

        static StringBuilder output = new StringBuilder();

        static void Main()
        {
            //Console.SetIn(new StreamReader("..\\..\\test.txt"));
            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine();
                var indexOfWhitespace = command.IndexOf(" ");
                var commandName = command.Substring(0, indexOfWhitespace);
                var commandParameters = command.Substring(indexOfWhitespace + 1).Split(';');

                if (commandName == "AddProduct")
                {
                    var productToAdd = new Product(commandParameters[0], decimal.Parse(commandParameters[1]), commandParameters[2]);
                    if (!productsByName.ContainsKey(productToAdd.Name))
                    {
                        productsByName[productToAdd.Name] = new Bag<Product>();
                    }

                    productsByName[productToAdd.Name].Add(productToAdd);

                    if (!productsByProducer.ContainsKey(productToAdd.Producer))
                    {
                        productsByProducer[productToAdd.Producer] = new Bag<Product>();
                    }

                    productsByProducer[productToAdd.Producer].Add(productToAdd);

                    var nameProducerKey = productToAdd.Name + ";" + productToAdd.Producer;
                    if (!productsByNameAndProducer.ContainsKey(nameProducerKey))
                    {
                        productsByNameAndProducer[nameProducerKey] = new Bag<Product>();
                    }

                    productsByNameAndProducer[nameProducerKey].Add(productToAdd);

                    if (!productsByPrice.ContainsKey(productToAdd.Price))
                    {
                        productsByPrice[productToAdd.Price] = new Bag<Product>();
                    }

                    productsByPrice[productToAdd.Price].Add(productToAdd);

                    output.AppendLine("Product added");
                }
                else if (commandName == "DeleteProducts")
                {
                    IEnumerable<Product> productsToDelete = new List<Product>();

                    if (commandParameters.Length == 1)
                    {
                        if (productsByProducer.ContainsKey(commandParameters[0]))
                        {
                            output.AppendLine(productsByProducer[commandParameters[0]].Count + " products deleted");

                            foreach (var item in productsByProducer[commandParameters[0]])
                            {
                                productsByName[item.Name].Remove(item);
                                productsByNameAndProducer[item.Name + ";" + item.Producer].Remove(item);
                                productsByPrice[item.Price].Remove(item);
                            }

                            productsByProducer.Remove(commandParameters[0]);
                        }
                        else
                        {
                            output.AppendLine(NoProductsFoundMessage);
                        }
                    }
                    else
                    {
                        var nameProducerKey = commandParameters[0] + ";" + commandParameters[1];
                        if (productsByNameAndProducer.ContainsKey(nameProducerKey))
                        {
                            output.AppendLine(productsByNameAndProducer[nameProducerKey].Count + " products deleted");

                            foreach (var product in productsByNameAndProducer[nameProducerKey])
                            {
                                productsByName[product.Name].Remove(product);
                                productsByPrice[product.Price].Remove(product);
                                productsByProducer[product.Producer].Remove(product);
                            }

                            productsByNameAndProducer.Remove(nameProducerKey);
                        }
                        else
                        {
                            output.AppendLine(NoProductsFoundMessage);
                        }
                    }
                }
                else if (commandName == "FindProductsByName")
                {
                    var products = new Bag<Product>();
                    if (productsByName.ContainsKey(commandParameters[0]))
                    {
                        products = productsByName[commandParameters[0]];
                    }

                    PrintProducts(products);

                }
                else if (commandName == "FindProductsByPriceRange")
                {
                    var startPrice = decimal.Parse(commandParameters[0]);
                    var endPrice = decimal.Parse(commandParameters[1]);
                    var products = productsByPrice.Where(x => x.Key >= startPrice && x.Key <= endPrice).SelectMany(x => x.Value);

                    PrintProducts(products);
                }
                else if (commandName == "FindProductsByProducer")
                {
                    var products = new Bag<Product>();

                    if (productsByProducer.ContainsKey(commandParameters[0]))
                    {
                        products = productsByProducer[commandParameters[0]];
                    }

                    PrintProducts(products);
                }
            }

            Console.WriteLine(output.ToString());
        }

        static void PrintProducts(IEnumerable<Product> products)
        {
            var ordered = products.OrderBy(x => x.ToString());

            if (products.Any())
            {
                foreach (var item in ordered)
                {
                    output.AppendLine(item.ToString());
                }
            }
            else
            {
                output.AppendLine(NoProductsFoundMessage);
            }
        }
    }
}
