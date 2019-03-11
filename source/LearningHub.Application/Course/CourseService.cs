using LearningHub.Database.Course;
using LearningHub.Database.Database;
using LearningHub.Database.Lecturer;
using LearningHub.Database.Student;
using LearningHub.Domain;
using LearningHub.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningHub.Application.Course
{
    public class CourseService : ICourseService
    {
        public CourseService(IDatabaseUnitOfWork databaseUnitOfWork, IStudentRepository studentRepository, ICourseRepository courseRepository, ILecturerRepository lecturerRepository)
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

        public async Task<IEnumerable<CourseDetail>> GetCourseList()
        {
            CourseDomain courseDomain = new CourseDomain(DatabaseUnitOfWork, StudentRepository, CourseRepository, LecturerRepository);

            List<CourseDetail> courseList = new List<CourseDetail>();

            var courses = await CourseRepository.ListAsync();
            foreach (var course in courses)
                courseList.Add(courseDomain.GetCourseDetail(course.CourseId));

            return courseList;
        }

        public async Task<CourseInfo> GetCourseDetail(int courseId)
        {
            CourseDomain courseDomain = new CourseDomain(DatabaseUnitOfWork, StudentRepository, CourseRepository, LecturerRepository);

            return courseDomain.GetCourseInfo(courseId);
        }


    }
}
