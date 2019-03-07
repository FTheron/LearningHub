using DotNetCore.AspNetCore;
using LearningHub.Application.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningHub.Web.Api
{
    public class CourseController
    {
        public CourseController(ICourseService courseService)
        {
            CourseService = courseService;
        }

        private ICourseService CourseService;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await CourseService.GetCourseListAsync();

            return new ActionIResult(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var result = await CourseService.GetCourseDetail(id);

            return new ActionIResult(result);
        }
    }
}
