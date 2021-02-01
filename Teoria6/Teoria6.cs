using System;
using System.Collections.Generic;
using System.Linq;
using Teoria6.Entities;

namespace Teoria6
{
   class Teoria6
   {
      static void Main(string[] args)
      {
         List<Product> list = new List<Product>();
         list.Add(new Product("Tv", 900.00));
         list.Add(new Product("Mouse", 50.00));
         list.Add(new Product("Tablet", 350.50));
         list.Add(new Product("HD Case", 80.90));

         //Sem Lambda
         //Func<Product, string> func = NameUpper;

        //Com Lamda
         Func<Product, string> func = p => p.Name.ToUpper();

         List<string> result = list.Select(func).ToList();

         foreach(string s in result)
         {
            Console.WriteLine(s);
         }
      }

      static string NameUpper(Product p)
      {
         return p.Name.ToUpper();
      }
   }
}