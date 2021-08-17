using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SchoolContext();
            var studentsWithSameName = context.Students
                                              .Where(s => s.Name == GetName())
                                              .ToList();

            var studentWithCourse = context.Students.Where(s => s.Name == GetName())
                                                    .Include(s => s.Course)
                                                    .ThenInclude(s => s.Teachers)
                                                    .Select(s => new { s.StudentId, s.Name, s.Course })
                                                    .FirstOrDefault();

            Console.WriteLine("Id: {0}, Name: {1}", studentWithCourse.StudentId, studentWithCourse.Name);

            foreach( var course in studentWithCourse.Course)
            {
                Console.WriteLine("\tCourseId: {0}, CourseName: {1}", course.CourseId, course.CourseName);
            }

        }

        public static string GetName()
        {
            return "Bill";
        }
    }
}
