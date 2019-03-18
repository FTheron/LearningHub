using DotNetCore.EntityFrameworkCore;
using LearningHub.Database.Database;
using LearningHub.Model.Entities;

namespace LearningHub.Database.Course
{
    public sealed class CourseRepository : EntityFrameworkCoreRepository<CourseEntity>, ICourseRepository
    {
        public CourseRepository(DatabaseContext context) : base(context) { }
    }
}
