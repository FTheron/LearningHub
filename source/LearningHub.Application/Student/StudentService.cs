using DotNetCore.Objects;
using LearningHub.Database.Database;
using LearningHub.Database.Student;
using LearningHub.Model.Models;
using System.Threading.Tasks;

namespace LearningHub.Application.Student
{
    public sealed class StudentService : IStudentService
    {
        public StudentService(IDatabaseUnitOfWork databaseUnitOfWork, IStudentRepository studentRepository)
        {
            StudentRepository = studentRepository;
            DatabaseUnitOfWork = databaseUnitOfWork;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IStudentRepository StudentRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddStudentModel addUserModel)
        {
            // TODO

            return new SuccessDataResult<long>(1);
        }
    }
}
