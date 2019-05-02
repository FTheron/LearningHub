namespace LearningHub.ApplicationCore.Entities
{
    public class Course : BaseEntity
    {
        public long CourseId { get; set; }

        public string Name { get; set; }

        public long MaxStudents { get; set; }

        public long LecturerId { get; set; }

        public Lecturer Lecturer { get; set; }
    }
}
