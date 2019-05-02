using LearningHub.ApplicationCore.Interfaces;

namespace LearningHub.Infrastructure.Data
{
    public class LecturerRepository : BaseRepository, ILecturerRepository
    {
        public LecturerRepository(LearningHubContext dbContext) : base(dbContext)
        {
        }
    }
}
