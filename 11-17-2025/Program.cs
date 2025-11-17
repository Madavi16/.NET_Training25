using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Mangement_System
{

   public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get;}
        public int Experience { get; set; }

        public Employee(int empId, string name, string department, double salary, int experience)
        {
            EmpId = empId;
            Name = name;
            Department = department;
            Salary = salary;
            Experience = experience;
        }

        public override string ToString()
        {
            return $"ID: {EmpId}\nName: {Name}\nDepartment: {Department}\nSalary: {Salary}\nExperience: {Experience} years";
        }

    }

    internal class Program
    {
        public delegate void DisplayDelegate(List<Employee> employees);
        static void Main(string[] args)
        {
            Console.WriteLine("\n========= WELCOME TO EMPLOYEE MANAGEMENT SYSTEM ==========\n");
            List<Employee> employees = new List<Employee>
            {
                //Departments include IT,HR,Finance,Sales.
                new Employee(1, "Arun", "HR", 56000, 5),
                new Employee(2, "Boobesh", "IT", 80000, 7),
                new Employee(3, "Anand", "Finance", 59000, 6),
                new Employee(4, "David", "IT", 85000, 8),
                new Employee(5, "Elvin", "HR", 49000, 4),
                new Employee(6, "Fahad", "Sales", 59000, 5),
                new Employee(7, "Aravind", "Finance", 40000, 3),
                new Employee(8, "Harikrishnan", "Sales", 70000, 6),
                new Employee(9, "Priya", "IT", 90000, 9),
                new Employee(10, "Jaggu", "HR", 35000, 2)
            };

            DisplayDelegate displayDelegate = list =>
            {
                foreach (var emp in list)
                {
                    Console.WriteLine(emp);
                }
            };

            Console.WriteLine("\n========== ALL EMPLOYEES LIST ==========\n");

            displayDelegate(employees);

            Console.WriteLine("\n========== FILTERING DETAILS ==========\n");

            var highSalary = employees.FindAll(e => e.Salary > 50000);
            Console.WriteLine("Employees with Salary>50000: ");
            displayDelegate(highSalary);

            Console.WriteLine("\n -------------------------------------- \n");

            var findDept = employees.FindAll(e=>e.Department == "IT");
            Console.WriteLine("\nEmployees who works in IT Department: ");
            displayDelegate(findDept);

            Console.WriteLine("\n -------------------------------------- \n");

            var experience5 = employees.FindAll(e => e.Experience > 5);
            Console.WriteLine("\nEmployess with experience more than 5 years: ");
            displayDelegate(experience5);

            Console.WriteLine("\n -------------------------------------- \n");

            var nameStartsA=employees.FindAll(e => e.Name.StartsWith("A"));
            Console.WriteLine("\nEmployees whose name starts with A: ");
            displayDelegate(nameStartsA);

            Console.WriteLine("\n========== SORTING AND ORDERING OF EMPLOYEES ==========\n");

            var sortByName = new List<Employee>(employees);
            sortByName.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
            Console.WriteLine("Employees sorted by Name (A-Z): ");
            displayDelegate(sortByName);

            Console.WriteLine("\n -------------------------------------- \n");

            var sortBySalary=new List<Employee>(employees);
            sortBySalary.Sort((e1, e2) => e2.Salary.CompareTo(e1.Salary));
            Console.WriteLine("\nEmployess sorted by salary (High - Low): ");
            displayDelegate(sortBySalary);

            Console.WriteLine("\n -------------------------------------- \n");

            var sortByExperience =new List<Employee>(employees);
            sortByExperience.Sort((e1,e2)=>e1.Experience.CompareTo(e2.Experience));
            Console.WriteLine("\nEmployees sorted by Experience (Low - High): ");
            displayDelegate(sortByExperience);

            Console.WriteLine("\n========== PROMOTION EMPLOYESS LIST ==========\n");

            var promotionList= employees.FindAll(e=>e.Salary>60000 && e.Experience>5);
            displayDelegate(promotionList);

            Console.WriteLine("\n========== END OF EMPLOYEE MANAGEMENT SYSTEM ==========\n");
            Console.ReadLine();
        }
    }
}
