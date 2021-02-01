using System;
using Teoria2.Services;

namespace Teoria2
{
   delegate double BinaryNumericOperation(double n1, double n2);

   class Teoria2
   {
      static void Main(string[] args)
      {
         double a = 10;
         double b = 12;

         BinaryNumericOperation op = CalculationService.Sum;
         double result = op(a, b);

         Console.WriteLine(result);
      }
   }
}