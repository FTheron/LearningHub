namespace LearningHub.Model.Models
{
    public class CourseDetail
    {
        public string Name { get; set; }
        public CourseAgeDetail AgeDetail { get; set; }
        public int Capasity { get; set; }
        public int CurrentStudentCount { get; set; }
    }
}
