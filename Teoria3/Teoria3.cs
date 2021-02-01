using System;
using Teoria3.Services;

namespace Teoria3
{
   delegate void BinaryNumericOperation(double n1, double n2);

   class Teoria3
   {
      static void Main(string[] args)
      {
         double a = 10;
         double b = 12;

         BinaryNumericOperation op = CalculationService.ShowSum;
         op += CalculationService.ShowMax;

         op.Invoke(a, b);
      }
   }
}