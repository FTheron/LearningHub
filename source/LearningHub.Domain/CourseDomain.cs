using LearningHub.Database.Course;
using LearningHub.Database.Database;
using LearningHub.Database.Lecturer;
using LearningHub.Database.Student;
using LearningHub.Model.Entities;
using LearningHub.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace LearningHub.Domain
{
    public class CourseDomain
    {
        public CourseDomain(IDatabaseUnitOfWork databaseUnitOfWork, IStudentRepository studentRepository, ICourseRepository courseRepository, ILecturerRepository lecturerRepository)
        {

            DatabaseUnitOfWork = databaseUnitOfWork;
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
            LecturerRepository = lecturerRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IStudentRepository StudentRepository { get; }

        private ICourseRepository CourseRepository { get; }

        private ILecturerRepository LecturerRepository { get; }

        public CourseDetail GetCourseDetail(long courseId)
        {
            CourseDetail courseDetail = new CourseDetail();
            CourseEntity courseEntity = CourseRepository.FirstOrDefault(x => x.CourseId == courseId);
            courseDetail.Name = courseEntity.Name;
            courseDetail.AgeDetail = new CourseAgeDetail()
            {
                AverageAge = StudentRepository.List().Where(x => x.CourseId == courseEntity.CourseId).Average(x => x.Age),
                MaximumAge = StudentRepository.List().Where(x => x.CourseId == courseEntity.CourseId).Max(x => x.Age),
                MinimumAge = StudentRepository.List().Where(x => x.CourseId == courseEntity.CourseId).Min(x => x.Age)
            };
            courseDetail.Capasity = courseEntity.MaxStudents;
            courseDetail.CurrentStudentCount = StudentRepository.Count(x => x.CourseId == courseEntity.CourseId);

            return courseDetail;
        }

        public CourseInfo GetCourseInfo(long courseId)
        {
            CourseInfo courseInfo = new CourseInfo();
            courseInfo.CourseDetail = GetCourseDetail(courseId);
            CourseEntity courseEntity = CourseRepository.FirstOrDefault(x => x.CourseId == courseId);
            courseInfo.Lecturer = LecturerRepository.FirstOrDefault(x => x.LecturerId == courseEntity.LecturerId).Name;
            var studentEntities = StudentRepository.List().Where(x => x.CourseId == courseId);
            var students = new List<Student>();
            foreach (var studentEntity in studentEntities)
            {
                students.Add(new Student { Name = studentEntity.Name, Age = studentEntity.Age });
            }
            courseInfo.Students = students;

            return courseInfo;
        }
    }
}
