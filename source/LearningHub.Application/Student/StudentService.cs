using DotNetCore.Objects;
using LearningHub.Database.Course;
using LearningHub.Database.Database;
using LearningHub.Database.Student;
using LearningHub.Model.Entities;
using LearningHub.Model.Models;
using System.Threading.Tasks;

namespace LearningHub.Application.Student
{
    public sealed class StudentService : IStudentService
    {
        public StudentService(IDatabaseUnitOfWork databaseUnitOfWork, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IStudentRepository StudentRepository { get; }

        private ICourseRepository CourseRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddStudentModel addUserModel)
        {
            var validation = new AddStudentModelValidator().Valid(addUserModel);

            if (!validation.Success)
                return new ErrorDataResult<long>(validation.Message);

            var course = await CourseRepository.SelectAsync(addUserModel.CourseId);
            
            if (course is null)
                return new ErrorDataResult<long>("Course does not exist.");
            if (course.MaxStudents <= StudentRepository.Count(x => x.CourseId == addUserModel.CourseId))
                return new ErrorDataResult<long>("Course full. No more students are accepted.");

            StudentEntity studentEntity = new StudentEntity { Name = addUserModel.Name, Age = addUserModel.Age, CourseId = addUserModel.CourseId };

            await StudentRepository.AddAsync(studentEntity);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(studentEntity.StudentId);
        }
    }
}
