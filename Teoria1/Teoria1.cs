using System;
using System.Collections.Generic;
using Teoria1.Entities;

namespace Teoria1
{
   class Teoria1
   {
      static void Main(string[] args)
      {
         List<Product> list = new List<Product>();

         list.Add(new Product("TV", 900.00));
         list.Add(new Product("Notebook", 1200.00));
         list.Add(new Product("Tablet", 450.00));

         /*Fazendo com a interface Icomparable a classe produto
         fica aberta a manutenção caso precise alterar o modo
         de ordenação
          */

         //Usando lambda para resolver
         Comparison<Product> comp = (p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
         list.Sort(comp);

         foreach(Product p in list)
         {
            Console.WriteLine(p);
         }
      }

      //Exemplo de função para usar no tipo Comparison
      static int CompareProducts(Product p1, Product p2)
      {
         return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
      }
   }
}