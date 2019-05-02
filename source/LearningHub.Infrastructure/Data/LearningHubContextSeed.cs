using LearningHub.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infrastructure.Data
{
    public class LearningHubContextSeed
    {
        public static async Task SeedAsync(LearningHubContext learningHubContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!learningHubContext.Lecturers.Any())
                {
                    learningHubContext.Lecturers.AddRange(
                        GetPreconfiguredLecturers());

                    await learningHubContext.SaveChangesAsync();
                }

                if (!learningHubContext.Courses.Any())
                {
                    learningHubContext.Courses.AddRange(
                        GetPreconfiguredCourses());

                    await learningHubContext.SaveChangesAsync();
                }

                if (!learningHubContext.Students.Any())
                {
                    learningHubContext.Students.AddRange(
                        GetPreconfiguredStudents());

                    await learningHubContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<LearningHubContext>();
                    log.LogError(ex.Message);
                    await SeedAsync(learningHubContext, loggerFactory, retryForAvailability);
                }
            }
        }

        private static IEnumerable<Lecturer> GetPreconfiguredLecturers()
        {
            return new List<Lecturer>
            {
                new Lecturer(){LecturerId = 1, Name = "Mark Twain"},
                new Lecturer(){LecturerId = 2, Name = "Hellen Keller"},
                new Lecturer(){LecturerId = 3, Name = "Ralph Nader"},
                new Lecturer(){LecturerId = 4, Name = "Beverley Hughes"},
                new Lecturer(){LecturerId = 5, Name = "Ian Bradley"}
            };
        }

        private static IEnumerable<Course> GetPreconfiguredCourses()
        {
            return new List<Course>()
            {
                new Course(){CourseId = 1, Name = "Web Programming & Development", LecturerId = 1, MaxStudents = 3},
                new Course(){CourseId = 2, Name = "Data Science", LecturerId = 1, MaxStudents = 5},
                new Course(){CourseId = 3, Name = "DevOps", LecturerId = 3, MaxStudents = 8},
                new Course(){CourseId = 4, Name = "SQT (Software Quality Testing) Automation", LecturerId = 4, MaxStudents = 10},
                new Course(){CourseId = 5, Name = "Database Administration", LecturerId = 5, MaxStudents = 10},
            };
        }

        private static IEnumerable<Student> GetPreconfiguredStudents()
        {
            return new List<Student>()
            {
                new Student() { StudentId = 1, Name = "Francois Theron", Age = 25, CourseId = 1 },
                new Student() { StudentId = 2, Name = "Dennis Ritchie", Age = 30, CourseId = 1 },
                new Student() { StudentId = 3, Name = "Bjarne Stroustrup", Age = 21, CourseId = 2 },
                new Student() { StudentId = 4, Name = "James Gosling", Age = 23, CourseId = 2 },
                new Student() { StudentId = 5, Name = "Linus Torvalds", Age = 28, CourseId = 2 },
                new Student() { StudentId = 6, Name = "Anders Hejlsberg", Age = 19, CourseId = 3 },
                new Student() { StudentId = 7, Name = "Tim Berners-Lee", Age = 20, CourseId = 3 },
                new Student() { StudentId = 8, Name = "Brian Kernighan", Age = 27, CourseId = 4 },
                new Student() { StudentId = 9, Name = "Ken Thompson", Age = 26, CourseId = 4 },
                new Student() { StudentId = 10, Name = "Guido van Rossum", Age = 25, CourseId = 5 },
                new Student() { StudentId = 11, Name = "Donald Knuth", Age = 23, CourseId = 5 }
            };
        }
    }
}
