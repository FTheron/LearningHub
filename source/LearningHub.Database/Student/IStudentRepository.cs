using DotNetCore.Repositories;
using LearningHub.Model.Entities;

namespace LearningHub.Database.Student
{
    public interface IStudentRepository : IRelationalRepository<StudentEntity> { }
}
