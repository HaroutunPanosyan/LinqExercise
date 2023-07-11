using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());
            //TODO: Print the Average of numbers
            Console.WriteLine(numbers.Average());
            //TODO: Order numbers in ascending order and print to the console
            var listedNums = numbers.OrderByDescending(x => x).Reverse().ToList();
            foreach (var number in listedNums)
            {
                Console.WriteLine(number);
            }
            //TODO: Order numbers in descending order and print to the console
            var descendingNums = numbers.OrderByDescending(x => x).ToList();
            foreach (var number in descendingNums)
            {
                Console.WriteLine(number);
            }
            //TODO: Print to the console only the numbers greater than 6
            var largerNums = numbers.Where(x => x > 6).ToList();
            foreach (var number in largerNums)
            {
                Console.WriteLine(number);
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var justNums = numbers.OrderByDescending(x => x).Where(x => x > 1 && x % 2 == 0).ToList();
            foreach (var number in justNums)
            {
                Console.WriteLine(number);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 33;
            var decNum = numbers.OrderByDescending(x => x).ToList();
            foreach (var number in decNum)
            {
                Console.WriteLine(number);
            }
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            // First Attempt:
            var c = employees.Where(x => x.FirstName.Contains('C')).ToList();
            c.OrderByDescending(x => x);
            c.Reverse();
            foreach (var employee in c)
            {
                Console.WriteLine(employee.FirstName);
            }
            var s = employees.Where(x => x.FirstName.Contains('S')).ToList();
            s.OrderByDescending(x => x);
            s.Reverse();
            foreach (var employee in s)
            {
                Console.WriteLine(employee.FirstName);
            }
            //----------------------------------------------------------
            // Second Attempt:
            var filteredNames =
                employees.Where(name => name.FirstName.StartsWith('C') || 
                name.FirstName.StartsWith('S')).OrderBy(name => name.FirstName);
            foreach (var name in filteredNames)
            {
                Console.WriteLine(name.FullName);
            }


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var age = employees.Where(empAge => empAge.Age > 26).OrderBy(empAge => empAge.Age).ThenBy(empAge => empAge.FirstName);
            foreach (var employee in age)
            {
                Console.WriteLine($"{employee.Age} | {employee.FullName}");
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var yoEAgeFilt = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"Sum: {yoEAgeFilt.Sum(emp => emp.YearsOfExperience)}");
            Console.WriteLine($"Avg: {yoEAgeFilt.Average(emp => emp.YearsOfExperience)}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jack", "Sparrow", 42, 18)).ToList();

            Console.WriteLine("All Employees after final addition: ");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FullName}, {employee.Age}, {employee.YearsOfExperience}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
