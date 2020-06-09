using System;
using System.Collections.Generic;
using System.Linq;

namespace Snack
{
    public class Program
    {
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            List<Product> products = new List<Product>();
            Product.currency = "R$";
            products.Add(new Product(1, "Cachorro Quente", 4.00));
            products.Add(new Product(2, "X-Salada", 4.50));
            products.Add(new Product(3, "X-Bacon", 5.00));
            products.Add(new Product(4, "Torrada simples", 2.00));
            products.Add(new Product(5, "Refrigerante", 1.50));

            var input = Console.ReadLine().Split(' ');
            int code = int.Parse(input[0]);
            int count = int.Parse(input[1]);

            var product = products.Where(p => p.code == code).First();
            string total = Math.Round(product.price * count, 2).ToString();
            if (total.Split('.').Length == 1)
                total += ".00";
            else if (total.Split('.')[1].Length == 1)
                total += "0";
            Console.WriteLine("Total: {0} {1}", Product.currency, total);
            Console.ReadKey();
        }
    }

    public class Product
    {
        public readonly int code;
        public readonly string specification;
        public readonly double price;
        public static string currency;
        public Product(int code, string specification, double price)
        {
            this.code = code;
            this.specification = specification;
            this.price = price;
        }
    }
}
