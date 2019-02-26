using LearningHub.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.Database.Database
{
    public sealed class DatabaseContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            LecturerEntity lecturer = new LecturerEntity()
            {
                LecturerId = 1,
                Name = "Professor Albus Dumbledore"
            };
            CourseEntity course = new CourseEntity()
            {
                CourseId = 1,
                Name = "CS50",
                LecturerId = 1,
                MaxStudents = 3
            };
            StudentEntity student = new StudentEntity()
            {
                StudentId = 1,
                Name = "Francois Theron",
                Age = 25,
                CourseId = 1
            };

            modelBuilder.Entity<LecturerEntity>().HasData(lecturer);
            modelBuilder.Entity<CourseEntity>().HasData(course);
            modelBuilder.Entity<StudentEntity>().HasData(student);
        }
    }
}
