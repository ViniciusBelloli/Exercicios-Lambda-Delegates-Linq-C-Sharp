using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using Exercicio2.Entities;

namespace Exercicio2
{
   class Exercicio2
   {
      static void Main(string[] args)
      {
         Console.Write("Enter full file path: ");
         string path = Console.ReadLine();

         Console.Write("Enter salary: ");
         double filterSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

         List<Employee> list = new List<Employee>();

         try
         {
            using (StreamReader sr = File.OpenText(path))
            {
               while (!sr.EndOfStream)
               {
                  string[] fields = sr.ReadLine().Split(',');
                  string name = fields[0];
                  string email = fields[1];
                  double price = double.Parse(fields[2], CultureInfo.InvariantCulture);
                  list.Add(new Employee(name, email, price));
               }
            }

            var r1 = list.Where(p => p.Salary > filterSalary).OrderBy(p => p.Email).Select(p => p.Email);
            Console.WriteLine("Email of people whose salary is more than " + filterSalary.ToString("F2", CultureInfo.InvariantCulture) + ":");

            foreach (string s in r1)
            {
               Console.WriteLine(s);
            }

            var r2 = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + r2.ToString("F2", CultureInfo.InvariantCulture));
         }
         catch (IOException e)
         {
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
         }
      }
   }
}