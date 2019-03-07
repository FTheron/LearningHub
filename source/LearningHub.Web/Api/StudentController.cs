using DotNetCore.AspNetCore;
using LearningHub.Application.Student;
using LearningHub.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningHub.Web.Api
{
    [ApiController]
    [RouteController]
    public class StudentController : ControllerBase
    {
        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        private IStudentService StudentService { get; }

        [AllowAnonymous]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(AddStudentModel addUserModel)
        {
            var result = await StudentService.Add(addUserModel);

            return new ActionIResult(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("AddAsync")]
        public async Task<IActionResult> AddAsync(AddStudentModel addUserModel)
        {
            var result = await StudentService.AddAsync(addUserModel);

            return new ActionIResult(result);
        }
    }
}
