using System.Collections.Generic;

namespace LearningHub.Model.Entities
{
    public class LecturerEntity
    {
        public long LecturerId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CourseEntity> Courses { get; set; } = new HashSet<CourseEntity>();
    }
}
