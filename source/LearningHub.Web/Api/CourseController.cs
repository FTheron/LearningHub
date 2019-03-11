using DotNetCore.AspNetCore;
using LearningHub.Application.Course;
using LearningHub.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningHub.Web.Api
{
    [ApiController]
    [RouteController]
    public class CourseController
    {
        public CourseController(ICourseService courseService)
        {
            CourseService = courseService;
        }

        private ICourseService CourseService;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CourseDetail>> GetList()
        {
            return await CourseService.GetCourseList();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<CourseInfo> GetDetail(int id)
        {
            return await CourseService.GetCourseDetail(id);
        }
    }
}
