using System.Collections.Generic;

namespace LearningHub.Model.Entities
{
    public class CourseEntity
    {
        public long CourseId { get; set; }

        public string Name { get; set; }

        public long MaxStudents { get; set; }

        public long LecturerId { get; set; }
    }
}
