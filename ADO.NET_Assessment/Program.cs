using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Assign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectedArch c = new ConnectedArch();
            //c.DisplayAllCourses();
            //c.AddStudent();
            // c.SearchStudent();
            //c.DisplayEnrollments();
            //c.UpdateGrade();
            c.GetCourseBySem();

            DisconnectedArch d = new DisconnectedArch();
            //d.DisconnectedEduTrack();
            // d.LoadDetails();
            //d.UpdateCredits();
            //d.AddCourse();
           // d.DeleteStudent();
            Console.ReadLine();
        }
    }
}
