
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Student_details_ASSN
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            WriteLine("Student Details App - Demo\n");
            var task = new Complete_Std_Details();

            WriteLine("\n=== Show All Students ===");
            task.ShowAllStudents();

            WriteLine("\n=== Print student in Prallel");
            task.PrintStudentsParallel();

            WriteLine("\n=== Get Student Async (ID=2)- expects low marks trigger ===");

            Student s1 = await task.GetStudentAsync(2);
            s1.PrintShort();
            WriteLine($"GetStudentAsync returned :{s1}");

            WriteLine("-------------------------------------------");
            WriteLine("\n--- Async fetch: Low-mark student (id = 3) ---");
            Student s3 = await task.GetStudentAsync(3);
            if (s3 != null && !string.IsNullOrWhiteSpace(s3.Name))
                s3.PrintShort();
            else
                WriteLine("Returned empty student due to low marks or error.");

          

            WriteLine($"\n=== GetStudentSync (no id)- default student ===");

            Student s2 = await task.GetStudentAsync();
            s2.PrintShort();

            WriteLine($"GetStudentSAsync returned: {s2}");

            WriteLine($"\n=== Greet student (named params) ===");
            task.GreetStudent(message: "Hello", name: "Chiranjeevi");

            WriteLine("\n ----- Iterate using GetAllStudents() -----");
            foreach(var st in task.GetAllStudents())
            {
                WriteLine($"*{st.Name} ({st.TotalMarks})");
            }

            WriteLine("\n=== Completed ===");

            ReadLine();
           
        }
    }
}
