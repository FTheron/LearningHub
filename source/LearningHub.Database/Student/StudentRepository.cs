using DotNetCore.EntityFrameworkCore;
using LearningHub.Database.Database;
using LearningHub.Model.Entities;

namespace LearningHub.Database.Student
{
    public sealed class StudentRepository : EntityFrameworkCoreRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
