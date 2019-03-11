using LearningHub.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.Database.Database
{
    public sealed class DatabaseContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LecturerEntity>().HasData(new LecturerEntity()
            {
                LecturerId = 1,
                Name = "Mark Twain"
            }, new LecturerEntity()
            {
                LecturerId = 2,
                Name = "Hellen Keller"
            }, new LecturerEntity()
            {
                LecturerId = 3,
                Name = "Ralph Nader"
            }, new LecturerEntity()
            {
                LecturerId = 4,
                Name = "Beverley Hughes"
            }, new LecturerEntity()
            {
                LecturerId = 5,
                Name = "Ian Bradley"
            });

            modelBuilder.Entity<CourseEntity>().HasData(new CourseEntity()
            {
                CourseId = 1,
                Name = "Web Programming & Development",
                LecturerId = 1,
                MaxStudents = 3
            }, new CourseEntity()
            {
                CourseId = 2,
                Name = "Data Science",
                LecturerId = 2,
                MaxStudents = 5
            }, new CourseEntity()
            {
                CourseId = 3,
                Name = "DevOps",
                LecturerId = 3,
                MaxStudents = 10
            }, new CourseEntity()
            {
                CourseId = 4,
                Name = "SQT (Software Quality Testing) Automation",
                LecturerId = 4,
                MaxStudents = 10
            }, new CourseEntity()
            {
                CourseId = 5,
                Name = "Database Administration",
                LecturerId = 5,
                MaxStudents = 10
            });

            modelBuilder.Entity<StudentEntity>().HasData(new StudentEntity()
            {
                StudentId = 1,
                Name = "Francois Theron",
                Age = 25,
                CourseId = 1
            }, new StudentEntity()
            {
                StudentId = 2,
                Name = "Dennis Ritchie",
                Age = 30,
                CourseId = 1
            }, new StudentEntity()
            {
                StudentId = 3,
                Name = "Bjarne Stroustrup",
                Age = 21,
                CourseId = 2
            }, new StudentEntity()
            {
                StudentId = 4,
                Name = "James Gosling",
                Age = 23,
                CourseId = 2
            }, new StudentEntity()
            {
                StudentId = 5,
                Name = "Linus Torvalds",
                Age = 28,
                CourseId = 2
            }, new StudentEntity()
            {
                StudentId = 6,
                Name = "Anders Hejlsberg",
                Age = 19,
                CourseId = 3
            }, new StudentEntity()
            {
                StudentId = 7,
                Name = "Tim Berners-Lee",
                Age = 20,
                CourseId = 3
            }, new StudentEntity()
            {
                StudentId = 8,
                Name = "Brian Kernighan",
                Age = 27,
                CourseId = 4
            }, new StudentEntity()
            {
                StudentId = 9,
                Name = "Ken Thompson",
                Age = 26,
                CourseId = 4
            }, new StudentEntity()
            {
                StudentId = 10,
                Name = "Guido van Rossum",
                Age = 25,
                CourseId = 5
            }, new StudentEntity()
            {
                StudentId = 11,
                Name = "Donald Knuth",
                Age = 23,
                CourseId = 5
            });
        }
    }
}
