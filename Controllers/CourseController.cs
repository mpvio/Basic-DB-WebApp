using BasicDBWebApp.Dtos;
using BasicDBWebApp.Models;
using BasicDBWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicDBWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private ILogger<CourseController> _logger;
        private ICourseService _service;

        public CourseController(
            ILogger<CourseController> logger, 
            ICourseService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("name/{name}")]
        public async Task<CourseDto> GetCourseByNameAsync(
            string name)
        {
            var req = new GetCourseByNameRequest { Name = name };
            return await _service.GetCourseByNameAsync(req);
        }

        [HttpGet("id/{id}")]
        public async Task<CourseDto> GetCourseByGuidAsync(
            Guid id)
        {
            var req = new GetCourseByGuidRequest { Guid = id };
            return await _service.GetCourseByGuidAsync(req);
        }

        [HttpGet]
        public async Task<List<CourseDto>> GetCoursesAsync()
        {
            return await _service.GetCoursesAsync();
        }

        [HttpPost("name/{name}")]
        public async Task<Guid> CreateCourseAsync(
            string name)
        {
            var req = new CreateCourseRequest { CourseName = name };
            return await _service.CreateCourseAsync(req);
        }
    }
}
