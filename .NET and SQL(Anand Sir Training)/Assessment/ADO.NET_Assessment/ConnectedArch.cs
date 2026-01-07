using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data;

namespace ADO.NET_Assign
{
    internal class ConnectedArch
    {
        private SqlConnection con;

        public ConnectedArch()
        {
            string connection = "Integrated Security = true;MultipleActiveResultSets=true; database = EduTrack; server =(localdb)\\MSSQLLocalDB";
            con = new SqlConnection(connection);
        }


        // 1st 2.1
        public void DisplayAllCourses()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Courses", con);
            SqlDataReader dr=cmd.ExecuteReader();
            WriteLine("\n====== Displaying All course details: \n");
            WriteLine("\nCourseId\tCourseName\tCredits\tSemester ");
            while(dr.Read())
            {
                WriteLine($"{dr["CourseId"]}\t{dr["CourseName"]}\t{dr["Credits"]}\t{dr["Semester"]}");
            }
            con.Close();
        }


        //2nd 2.2
        public void AddStudent()
        {
            WriteLine("Enter Full Name: ");
            string name = Console.ReadLine();

            WriteLine("Enter Email: ");
            string email= Console.ReadLine();

            WriteLine("Enter Department: ");
            string dept = Console.ReadLine();

            WriteLine("Enter year of study: ");
            int year = int .Parse(Console.ReadLine());

            con.Open();
            string query = $@"insert into Students (FullName,Email,Department,YearOfStudy)
                            Values(@name,@email,@dept,@year)";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("@name", name);
            SqlParameter p2 = new SqlParameter("@email", email);
            SqlParameter p3 = new SqlParameter("@dept", dept);
            SqlParameter p4 = new SqlParameter("@year", year);

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"Number of rows affected: {rows}");
            con.Close();
            
        }


        //3rd 2.3
        public void SearchStudent()
        {
            Console.WriteLine("Enter Department Name: ");
            string deptName = Console.ReadLine();

            con.Open();

            SqlCommand cmd = new SqlCommand("sp_SearchByDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@Dept", deptName);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Console.WriteLine($"{dr["StudentId"]}\t{dr["FullName"]}\t{dr["Email"]}\t{dr["YearOfStudy"]}");
            }
            con.Close();
        }

        //4th 2.4

        public void DisplayEnrollments()
        {
            Console.WriteLine("Enter student id: ");
            int stdId= int.Parse(Console.ReadLine());

            con.Open();

            string query = $@"select c.CourseName, c.Credits, e.EnrollDate, e.Grade
                               from Enrollments e
                                join Courses c on e.CourseId = c.CourseId
                                where e.StudentId = {stdId}";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlParameter p1 = new SqlParameter("@StudentId", stdId);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine($"Course Enrollment Details of Student with student Id [{stdId}]: ");
            while(dr.Read())
            {
                WriteLine($"{dr["CourseName"]}\t{dr["Credits"]}\t{dr["EnrollDate"]}\t{dr["Grade"]}");

            }

            con.Close();
        }

        //5th 2.5
        public void UpdateGrade()
        {
            WriteLine("Enter Enrollment Id: ");
            int enrollId = int .Parse( Console.ReadLine() );

            WriteLine("Enter Grade (A/B/C):");
            string grade = Console.ReadLine();

            con.Open();
            string query = $@"update Enrollments set Grade =@grade 
                                where EnrollmentId ={enrollId}";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("@EnrollmentId", enrollId);
            
            cmd.Parameters.Add(p1);
            cmd.Parameters.AddWithValue("@grade",grade);

            int rows = cmd.ExecuteNonQuery();
            WriteLine($"Number of rows Updated: {rows}");
            con.Close();
        }



        //Stored Procedure

        public void GetCourseBySem()
        {
            Console.WriteLine("Enter Semester: ");
            string sem = Console.ReadLine();

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GetCoursesBySemester", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@Semester", sem);
            cmd.Parameters.Add(p1);

            SqlDataReader dr=cmd.ExecuteReader();
            Console.WriteLine("Course details by semester: ");
            while(dr.Read())
            {
                Console.WriteLine($"{dr[0]}\t{dr[1]}\t{dr[2]}");
            }
            con.Close();

        }
    }
}
