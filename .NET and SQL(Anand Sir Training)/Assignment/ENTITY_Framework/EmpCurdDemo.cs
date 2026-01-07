using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Code_frist_Demo
{
    internal class EmpCurdDemo
    {

        Model1 db = new Model1();
        public void InsertEmployee()
        {
            Console.WriteLine("How many employees do you want to insert?");
            int count = int.Parse(Console.ReadLine());

            try
            {

                for (int i = 1; i <= count; i++)
                {
                    Console.WriteLine($"\nEnter details for Employee {i}");

                    Console.Write("EmpId: ");
                    string empId = Console.ReadLine();

                    Console.Write("Emp Name: ");
                    string empName = Console.ReadLine();

                    Console.Write("Department Name: ");
                    string deptName = Console.ReadLine();

                    Console.Write("Salary: ");
                    int salary = int.Parse(Console.ReadLine());

                    Console.Write("Year Of Joining: ");
                    int year = int.Parse(Console.ReadLine());

                    EmployeeEf emp = new EmployeeEf()
                    {
                        EmpId = empId,
                        EmpName =empName,
                        DepartmentName = deptName,
                        Salary = salary,
                        YearOfJoining = year

                    };

                    db.employees.Add(emp);
                    int rowAff = db.SaveChanges();
                    Console.WriteLine($"Records inserted: {rowAff}");
                }
            }
            catch
            {
                var res = db.GetValidationErrors();

                foreach(var item in res)
                {
                    if(item.ValidationErrors.Count>0)
                    {
                        foreach(var err in item.ValidationErrors)
                        {
                            Console.WriteLine(err.ErrorMessage);
                        }
                    }
                }

            }


        }

        public void DisplayAll()
        {
            var res = db.employees.ToList();
            foreach(var e in res)
            {
                Console.WriteLine($"{e.EmpId}\t{e.EmpName}\t{e.DepartmentName}\t{e.Salary}\t{e.YearOfJoining}");

            }
            Console.WriteLine();
        }

        public void SearchEmployeebyId()
        {
            Console.WriteLine("Enter EmpId: ");
            string id = Console.ReadLine();

            var emp=db.employees.FirstOrDefault(e => e.EmpId == id);

            if(emp==null)
            {
                Console.WriteLine("Employee Not found");
                return;
            }

            Console.WriteLine($"{emp.EmpId}\t{emp.EmpName}\t{emp.DepartmentName}\t{emp.Salary}\t{emp.YearOfJoining}");
        }

        public void UpdateSalary()
        {
            Console.WriteLine("Enter emp id: ");
            string id= Console.ReadLine();

            var emp = db.employees.FirstOrDefault(e => e.EmpId == id);

            if(emp==null)
            {
                Console.WriteLine("Employee Not Found");
                return;

            }

            Console.WriteLine("Enter new Salary:");
           emp.Salary=int.Parse(Console.ReadLine());
           int res= db.SaveChanges();
            Console.WriteLine($"No of rows affected:{res}");
            Console.WriteLine("Salary updated successfully");
        }

        public void DeleteEmp()
        {
            Console.WriteLine("Enter Empid to delete: ");
            string id = Console.ReadLine();

            var emp = db.employees.FirstOrDefault(e => e.EmpId == id);

            if(emp==null)
            {
                Console.WriteLine("Employees not found");
                return;
            }


            db.employees.Remove(emp);
            int res=db.SaveChanges();
            Console.WriteLine($"Rows Affected:{res}");
            Console.WriteLine("Employee deleted successfully.");
        }



    }
}
