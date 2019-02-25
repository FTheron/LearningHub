using DotNetCore.Repositories;
using LearningHub.Model.Entities;

namespace LearningHub.Database.Course
{
    public interface ICourseRepository : IRelationalRepository<CourseEntity> { }
}
