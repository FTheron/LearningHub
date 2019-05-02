using LearningHub.ApplicationCore.Interfaces;

namespace LearningHub.Infrastructure.Data
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public CourseRepository(LearningHubContext dbContext) : base(dbContext)
        {
        }
    }
}
