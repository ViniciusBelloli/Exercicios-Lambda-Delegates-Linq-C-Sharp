﻿using System.Globalization;

namespace Teoria7.Entities
{
   class Product
   {
      public string Name { get; set; }
      public double Price { get; set; }

      public Product(string name, double price)
      {
         Name = name;
         Price = price;
      }
   }
}