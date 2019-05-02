namespace LearningHub.ApplicationCore.Entities
{
    public class Student : BaseEntity
    {
        public long StudentId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public long CourseId { get; set; }

        public Course Course { get; set; }
    }
}
