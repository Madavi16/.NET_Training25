using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Student_details_ASSN
{
    public class Student
    {

        public string Name { get; set; } 
        public string Class { get; set; } = "12A";
        public int TotalMarks { get; set; } = 520;
        public string Gender { get; set; } = "Female";

        public override string ToString() => $"Name: {Name}\nClass: {Class}\nTotal Marks: {TotalMarks}\nGender: {Gender}";

    }

    public delegate void SimplePrinter(string message);

    public static class StudentExtensions
    {
        public static void PrintShort(this Student s)
        {
            if (s == null)
                WriteLine("No student found");
            else
            {
                WriteLine(s.ToString());
            }
        }
    }

    internal class Complete_Std_Details
    {
        //Student class with auto-property

        private Dictionary<int, Student> students = new Dictionary<int, Student>
        {
            [1] = new Student { Name = "Ravi", Class = "10A", TotalMarks = 450, Gender = "Male" },
            [2] = new Student { Name = "Sita", Class = "10B", TotalMarks = 470, Gender = "Female" },
            [3] = new Student { Name = "Rahul", Class = "Inter", TotalMarks = 290, Gender = "Male" }, // Low marks
            [4] = new Student { Name = "Anita", Class = "10C", TotalMarks = 510, Gender = "Femlae" },
            [5] = new Student { Name = "Chiru", Class = "Inter", TotalMarks = 550, Gender = "Male" }

        };

        private SimplePrinter printer = new SimplePrinter(WriteLine);

            public void ShowAllStudents()
            {
                try
                {
                    WriteLine("\n -----ALl STUDENTS----- ");
                    foreach (var s in students.Values)
                    {
                        WriteLine(s.ToString());
                    }
                }
                catch (Exception ex)
                {
                    WriteLine($"Error in ShowAllStudent: {ex.Message}");
                }
            }

            public async Task<Student> GetStudentAsync(int id = 0)
            {
                try
                {
                return await Task.Run(() =>
                {
                    if (id == 0)
                    {
                        WriteLine("No Id provided ->Returning default student detail values.");
                        return new Student
                        {
                            Name = "Mahe",
                            Class = "Inter",
                            TotalMarks = 540,
                            Gender = "Female"
                        };
                    }
                    // Student stu = new Student();

                    if (!students.TryGetValue(id, out Student stu))
                    {
                        throw new KeyNotFoundException("Student not found");
                    }


                    if (stu.TotalMarks < 300)
                    {
                        throw new InvalidOperationException("Mark less than 300");
                    }

                    return stu;



                }).ConfigureAwait(false);


                }

                catch (InvalidOperationException ex) when (ex.Message.Contains("Mark less than 300"))
                {
                await Task.Delay(100).ConfigureAwait(false);
                    WriteLine("Exception worked-> Student has low marks!");
                return new Student();
                }
                catch (KeyNotFoundException e)
                {
                await Task.Delay(100).ConfigureAwait(false);
                    WriteLine($"Student lookup error: {e.Message}");
                return new Student();
                }
                catch(Exception ex)
                {
                    await Task.Delay(100).ConfigureAwait(false);
                    WriteLine($"General Error: {ex.Message}");
                    return new Student();
                }

            }


            public void PrintStudentsParallel()
            {
                try
                {
                WriteLine("\n----- PARALLEL PRINT -----");
                System.Threading.Tasks.Parallel.ForEach(students.Values, student =>
                {
                    if (student==null)
                    {
                        WriteLine("[Parallel] student is null");

                    }
                    else
                    {
                        WriteLine($"[Parallel] {student.ToString()}"); 
                    }
                } );
                }
                catch (AggregateException agg)
                {
                    foreach(var e in agg.InnerExceptions) printer($"Parallel exception: {e.Message}");
                }
                catch (Exception ex)
                {
                    WriteLine($"Error in PrintStudentsParallel: {ex.Message}");
                }
            }
           public void GreetStudent(string name="Student", string message="Welcome")
           {
                printer($"{message} {name}"); 
           }
        
       public IEnumerable<Student> GetAllStudents () => students.Values;
    }
}
