using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_frist_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // u can write a linq query even if the table or database is not exists.

            // we dont have any existing database by name sprotsdb and any table named ipl, eventhough i can write a query using this, 

            //CURDdemo ob = new CURDdemo();
            //ob.Insert();

            //Class1 c = new Class1();
            //c.InsertNewStudents();

            EmpCurdDemo e = new EmpCurdDemo();
            e.InsertEmployee();
            //e.DisplayAll();
            // e.SearchEmployeebyId();
            //e.UpdateSalary();
            //e.DeleteEmp();

            Console.ReadLine();
        }
    }
}
