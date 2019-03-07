using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using LearningHub.Database.Course;
using LearningHub.Database.Database;
using LearningHub.Database.Student;
using LearningHub.Model.Models;

namespace LearningHub.Application.Course
{
    public class CourseService : ICourseService
    {
        public CourseService(IDatabaseUnitOfWork databaseUnitOfWork, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IStudentRepository StudentRepository { get; }

        private ICourseRepository CourseRepository { get; }
        
        public async Task<IEnumerable<CourseInfo>> GetCourseListAsync()
        {
            List<CourseInfo> courseList = new List<CourseInfo>();

            var s = await CourseRepository.ListAsync();

            return courseList;
        }

        public async Task<IDataResult<CourseDetail>> GetCourseDetail(int courseId)
        {
            throw new System.NotImplementedException();
        }

    }
}
