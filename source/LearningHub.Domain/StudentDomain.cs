using LearningHub.Database.Course;
using LearningHub.Database.Database;
using LearningHub.Database.Student;
using LearningHub.Model.Entities;
using LearningHub.Model.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace LearningHub.Domain
{
    public class StudentDomain
    {
        public StudentDomain(IDatabaseUnitOfWork databaseUnitOfWork, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IStudentRepository StudentRepository { get; }

        private ICourseRepository CourseRepository { get; }

        public StudentEntity ConvertToStudentEntity(string addStudentModelString)
        {
            var addStudentModel = JsonConvert.DeserializeObject<AddStudentModel>(addStudentModelString);
            return new StudentEntity { Name = addStudentModel.Name, Age = addStudentModel.Age, CourseId = addStudentModel.CourseId };
        }

        public StudentEntity ConvertToStudentEntity(AddStudentModel addStudentModel)
        {
            return new StudentEntity { Name = addStudentModel.Name, Age = addStudentModel.Age, CourseId = addStudentModel.CourseId };
        }

        public async Task<string> ApplyBusinessRules(StudentEntity studentEntity)
        {
            var course = await CourseRepository.SelectAsync(studentEntity.CourseId);

            if (course is null)
                return "Course does not exist.";
            if (course.MaxStudents <= StudentRepository.Count(x => x.CourseId == studentEntity.CourseId))
                return "Course full. No more students are accepted.";

            return null;
        }
    }
}
