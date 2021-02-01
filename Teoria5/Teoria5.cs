﻿using System;
using System.Collections.Generic;
using Teoria5.Entities;

namespace Teoria5
{
   class Teoria5
   {
      static void Main(string[] args)
      {
         List<Product> list = new List<Product>();
         list.Add(new Product("Tv", 900.00));
         list.Add(new Product("Mouse", 50.00));
         list.Add(new Product("Tablet", 350.50));
         list.Add(new Product("HD Case", 80.90));

         //Solução sem lambda
         //list.ForEach(UpdatePrice);

         //Solução com lambda
         Action<Product> act = p => { p.Price += p.Price * 0.1; };
         list.ForEach(act);

         foreach (Product p in list)
         {
            Console.WriteLine(p);
         }
      }

      static void UpdatePrice(Product p)
      {
         p.Price += p.Price * 0.1;
      }
   }
}