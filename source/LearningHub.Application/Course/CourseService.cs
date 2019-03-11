using LearningHub.Database.Course;
using LearningHub.Database.Database;
using LearningHub.Database.Lecturer;
using LearningHub.Database.Student;
using LearningHub.Domain;
using LearningHub.Model.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningHub.Application.Course
{
    public class CourseService : ICourseService
    {
        private const int SecondsInCache = 5;
        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
        private IStudentRepository StudentRepository { get; }
        private ICourseRepository CourseRepository { get; }
        private ILecturerRepository LecturerRepository { get; }
        private IMemoryCache Cache { get; }

        public CourseService(IDatabaseUnitOfWork databaseUnitOfWork, IStudentRepository studentRepository, ICourseRepository courseRepository, ILecturerRepository lecturerRepository, IMemoryCache cache)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
            LecturerRepository = lecturerRepository;
            Cache = cache;
        }

        public async Task<IEnumerable<CourseDetail>> GetCourseList()
        {
            if (Cache.TryGetValue("CourseList", out List<CourseDetail> courseList))
                return courseList;

            CourseDomain courseDomain = new CourseDomain(DatabaseUnitOfWork, StudentRepository, CourseRepository, LecturerRepository);

            courseList = new List<CourseDetail>();
            var courses = await CourseRepository.ListAsync();
            foreach (var course in courses)
                courseList.Add(courseDomain.GetCourseDetail(course.CourseId));

            Cache.Set("CourseList", courseList, DateTime.Now.AddSeconds(SecondsInCache));
            return courseList;
        }

        public async Task<CourseInfo> GetCourseDetail(int courseId)
        {
            if (Cache.TryGetValue($"CourseDetail-{courseId}", out CourseInfo courseInfo))
                return courseInfo;
            
            CourseDomain courseDomain = new CourseDomain(DatabaseUnitOfWork, StudentRepository, CourseRepository, LecturerRepository);
            courseInfo = courseDomain.GetCourseInfo(courseId);

            Cache.Set($"CourseDetail-{courseId}", courseInfo, DateTime.Now.AddSeconds(SecondsInCache));
            return courseInfo;
        }
    }
}
