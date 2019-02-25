using System.Collections.Generic;

namespace LearningHub.Model.Entities
{
    public class CourseEntity
    {
        public long CourseId { get; set; }

        public string Name { get; set; }

        public int MaxStudents { get; set; }

        public virtual LecturerEntity Lecturer { get; set; }

        public virtual ICollection<StudentEntity> Students { get; set; }
    }
}
