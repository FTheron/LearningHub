using LearningHub.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.Database.Database
{
    public sealed class DatabaseContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEntity>().HasData(new StudentEntity
            {
                StudentId = 1,
                Name = "Francois",
                Age = 25
            });
            modelBuilder.Entity<LecturerEntity>().HasData(new LecturerEntity
            {
                LecturerId = 1,
                Name = "Professor Albus Dumbledore"
            });
            modelBuilder.Entity<CourseEntity>().HasData(new CourseEntity
            {
                CourseId = 1,
                Name = "CS50"
            });
        }
    }
}
