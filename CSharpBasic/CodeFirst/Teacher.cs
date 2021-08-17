using System.Collections.Generic;

namespace CodeFirst
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
