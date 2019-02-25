using DotNetCore.Repositories;
using LearningHub.Model.Entities;

namespace LearningHub.Database.Lecturer
{
    public interface ILecturerRepository : IRelationalRepository<LecturerEntity> { }
}
