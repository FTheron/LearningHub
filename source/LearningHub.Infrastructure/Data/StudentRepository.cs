using LearningHub.ApplicationCore.Interfaces;

namespace LearningHub.Infrastructure.Data
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(LearningHubContext dbContext) : base(dbContext)
        {
        }
    }
}
