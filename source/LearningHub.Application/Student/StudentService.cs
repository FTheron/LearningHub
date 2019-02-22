using DotNetCore.Objects;
using LearningHub.Database.Database;
using LearningHub.Database.Student;
using LearningHub.Model.Entities;
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
            var validation = new AddStudentModelValidator().Valid(addUserModel);

            if (!validation.Success)
                return new ErrorDataResult<long>(validation.Message);

            // TODO: Move building of Entity
            StudentEntity studentEntity = new StudentEntity { Name = addUserModel.Name, Age = addUserModel.Age };

            await StudentRepository.AddAsync(studentEntity);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(studentEntity.StudentId);
        }
    }
}
