using System;
using System.Collections.Generic;
using System.Linq;
using Teoria9.Entities;

namespace Teoria9
{
   class Teoria9
   {
      static void Main(string[] args)
      {
         Category c1 = new Category(1, "Tools", 2);
         Category c2 = new Category(2, "Computers", 1);
         Category c3 = new Category(3, "Eletronics", 1);

         List<Product> products = new List<Product>()
         {
            new Product(1, "Computer", 1100.0, c2),
            new Product(2, "Hammer", 90.0, c1),
            new Product(3, "TV", 1700.0, c3),
            new Product(4, "Notebook", 1300.0, c2),
            new Product(5, "Saw", 80.0, c1),
            new Product(6, "Tablet", 700.0, c2),
            new Product(7, "Camera", 700.0, c3),
            new Product(8, "Printer", 350.0, c3),
            new Product(9, "MacBook", 1800.0, c2),
            new Product(10, "Sound Bar", 700.0, c3),
            new Product(11, "Level", 70.0, c1),
         };

         IEnumerable<Product> r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
         Print("TIER 1 AND PRICE < 900", r1);

         IEnumerable<string> r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
         Print("NAMES OF PRODUCTS FROM TOOLS", r2);

         var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name});
         Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

         IEnumerable<Product> r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
         Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

         IEnumerable<Product> r5 = r4.Skip(2).Take(4);
         Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

         Product r6 = products.FirstOrDefault();
         Console.WriteLine("First or default test1: " + r6);
         Product r7 = products.Where(p => p.Price > 3000).FirstOrDefault();
         Console.WriteLine("First or default test2: " + r7);

         Product r8 = products.Where(p => p.Id == 3).SingleOrDefault();
         Console.WriteLine("\nSingle or default test1: " + r8);
         Product r9 = products.Where(p => p.Id == 30).SingleOrDefault();
         Console.WriteLine("Single or default test2: " + r9);

         double r10 = products.Max(p => p.Price);
         Console.WriteLine("\nMax price: " + r10);
         double r11 = products.Min(p => p.Price);
         Console.WriteLine("Min price: " + r11);
         double r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
         Console.WriteLine("Category 1 Sum prices: " + r12);
         double r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
         Console.WriteLine("Category 1 Average prices: " + r13);
         double r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
         Console.WriteLine("Category 5 Average prices: " + r14);
         double r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
         Console.WriteLine("Category 1 aggregate sum: " + r15);
         Console.WriteLine();

         var r16 = products.GroupBy(p => p.Category);
         foreach (IGrouping<Category, Product> group in r16)
         {
            Console.WriteLine("Category " + group.Key.Name + ":");

            foreach(Product p in group)
            {
               Console.WriteLine(p);
            }
            Console.WriteLine();
         }
      }

      static void Print<T>(string message, IEnumerable<T> collection)
      {
         Console.WriteLine(message);

         foreach (T obj in collection)
         {
            Console.WriteLine(obj);
         }

         Console.WriteLine();
      }
   }
}