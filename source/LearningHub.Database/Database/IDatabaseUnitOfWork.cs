using System.Threading.Tasks;

namespace LearningHub.Database.Database
{
    public interface IDatabaseUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
