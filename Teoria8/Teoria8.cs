using System;
using System.Linq;
using System.Collections.Generic;

namespace Teoria8
{
   class Teoria8
   {
      static void Main(string[] args)
      {
         // Specify the data source
         int[] number = new int[] { 2, 3, 4, 5 };

         // Define the query expression
         IEnumerable <int> result = number.Where(x => x % 2 == 0).Select(x => x * 10);

         // Execute the query
         foreach(int x in result)
         {
            Console.WriteLine(x);
         }
      }
   }
}