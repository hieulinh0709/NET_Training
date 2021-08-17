using System.Collections.Generic;

namespace CodeFirst
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
