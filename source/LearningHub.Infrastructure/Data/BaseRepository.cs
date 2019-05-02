using LearningHub.ApplicationCore.Entities;

namespace LearningHub.Infrastructure.Data
{
    public class BaseRepository
    {
        protected readonly LearningHubContext _dbContext;

        public BaseRepository(LearningHubContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
