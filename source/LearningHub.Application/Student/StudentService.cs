using DotNetCore.Objects;
using LearningHub.Database.Course;
using LearningHub.Database.Database;
using LearningHub.Database.Student;
using LearningHub.Domain;
using LearningHub.Model.Models;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
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

        public async Task<IDataResult<long>> Add(AddStudentModel addStudentModel)
        {
            var validation = new AddStudentModelValidator().Valid(addStudentModel);

            if (!validation.Success)
                return new ErrorDataResult<long>(validation.Message);

            StudentDomain domain = new StudentDomain(DatabaseUnitOfWork, StudentRepository, CourseRepository);

            var student = domain.ConvertToStudentEntity(addStudentModel);
            string errorMessage = await domain.ApplyBusinessRules(student);

            if (!string.IsNullOrWhiteSpace(errorMessage))
                return new ErrorDataResult<long>(errorMessage);

            await StudentRepository.AddAsync(student);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(student.StudentId);
        }
        
        public async Task<IDataResult<long>> AddAsync(AddStudentModel addStudentModel)
        {
            var validation = new AddStudentModelValidator().Valid(addStudentModel);

            if (!validation.Success)
                return new ErrorDataResult<long>(validation.Message);

            // TODO: Add dependency injection.
            IQueueClient queueClient = new QueueClient(Environment.GetEnvironmentVariable("LearningHub_AzureServiceBus"), Environment.GetEnvironmentVariable("LearningHub_QueueName"));

            var encodedMessage = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(addStudentModel)));
            await queueClient.SendAsync(encodedMessage);

            return new SuccessDataResult<long>("Added to Processing Queue");
        }
    }
}
