
using DotNetCore.Objects;
using LearningHub.Model.Models;
using System.Threading.Tasks;

namespace LearningHub.Application.Student
{
    public interface IStudentService
    {
        Task<IDataResult<long>> Add(AddStudentModel addStudentModel);
        Task<IDataResult<long>> AddAsync(AddStudentModel addStudentModel);
    }
}
