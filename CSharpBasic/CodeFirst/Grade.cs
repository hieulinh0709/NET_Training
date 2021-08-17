using System.Collections.Generic;

namespace CodeFirst
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
