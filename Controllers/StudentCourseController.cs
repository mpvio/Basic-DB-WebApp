using BasicDBWebApp.Dtos;
using BasicDBWebApp.Models;
using BasicDBWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicDBWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentCourseController : ControllerBase
    {
        private ILogger<StudentCourseController> _logger;
        private IStudentCourseService _service;

        public StudentCourseController(
            ILogger<StudentCourseController> logger, 
            IStudentCourseService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<List<StudentCourseDto>> GetStudentCoursesAsync()
        {
            return await _service.GetStudentCoursesAsync();
        }

        [HttpGet("student/{name}")]
        public async Task<StudentCourseDto> GetStudentCourseStudentNameAsync(
            string name)
        {
            var req = new GetStudentCourseByNameRequest { Name = name };
            return await _service.GetStudentCourseByStudentNameAsync(req);
        }

        [HttpGet("course/{name}")]
        public async Task<StudentCourseDto> GetStudentCourseCourseNameAsync(
            string name)
        {
            var req = new GetStudentCourseByNameRequest { Name = name };
            return await _service.GetStudentCourseByCourseNameAsync(req);
        }
    }
}
