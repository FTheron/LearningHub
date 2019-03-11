namespace LearningHub.Model.Models
{
    public class CourseDetail
    {
        public string Name { get; set; }
        public CourseAgeDetail AgeDetail { get; set; }
        public long Capasity { get; set; }
        public long CurrentStudentCount { get; set; }
    }
}
