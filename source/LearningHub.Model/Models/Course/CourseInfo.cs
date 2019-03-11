using LearningHub.Model.Entities;
using System.Collections.Generic;

namespace LearningHub.Model.Models
{
    public class CourseInfo
    {
        public CourseDetail CourseDetail { get; set; }
        public string Lecturer { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
