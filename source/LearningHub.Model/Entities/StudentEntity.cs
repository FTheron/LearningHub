using System.Collections.Generic;

namespace LearningHub.Model.Entities
{
    public class StudentEntity
    {
        public long StudentId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public virtual CourseEntity Course { get; set; }
    }
}
