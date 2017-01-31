using System;
using System.Collections.Generic;
using OnlineMarket.Solution;
using System.Linq;

namespace OnlineMarket.Solution
{
    public class SuperMarket
    {
        HashSet<Product> products;
        Dictionary<double, SortedSet<Product>> byPrice;
        Dictionary<string, SortedSet<Product>> byType;
        SortedSet<double> prices;

        public SuperMarket()
        {
            this.products = new HashSet<Product>();
            this.byPrice = new Dictionary<double, SortedSet<Product>>();
            this.byType = new Dictionary<string, SortedSet<Product>>();
            this.prices = new SortedSet<double>();
        }

        public bool AddProduct(Product product)
        {
            if (this.products.Contains(product))
            {
                return false;
            }

            if (!(this.byPrice.ContainsKey(product.Price)))
            {
                this.byPrice[product.Price] = new SortedSet<Product>();
            }
            if (!(this.byType.ContainsKey(product.Type)))
            {
                this.byType[product.Type] = new SortedSet<Product>();
            }

            this.products.Add(product);
            this.byPrice[product.Price].Add(product);
            this.byType[product.Type].Add(product);
            this.prices.Add(product.Price);

            return true;
        }

        public IEnumerable<Product> FilterProducts(double from, double to)
        {
            var selectedPrices = this.prices.GetViewBetween(from, to);

            List<Product> products = new List<Product>();

            foreach (var price in selectedPrices)
            {
                if (products.Count >= 10)
                {
                    break;
                }
                foreach (var product in this.byPrice[price])
                {
                    if (products.Count >= 10) 
                    {
                        break;
                    }
                    products.Add(product);
                }
            }
            return products;
        }

        public IEnumerable<Product> FilterProducts(string type)
        {
            if (!(byType.ContainsKey(type))) 
            {
                return null;
            }
            return this.byType[type].Take(10);
        }
    }
}