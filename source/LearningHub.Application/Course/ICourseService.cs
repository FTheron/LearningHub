using DotNetCore.Objects;
using LearningHub.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningHub.Application.Course
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseInfo>> GetCourseListAsync();
        Task<IDataResult<CourseDetail>> GetCourseDetail(int courseId);
    }
}
