using DotNetCore.EntityFrameworkCore;
using LearningHub.Database.Database;
using LearningHub.Model.Entities;

namespace LearningHub.Database.Lecturer
{
    public sealed class LecturerRepository : EntityFrameworkCoreRepository<LecturerEntity>, ILecturerRepository
    {
        public LecturerRepository(DatabaseContext context) : base(context) { }
    }
}
