using BasicDBWebApp.Dtos;
using BasicDBWebApp.Entities;
using BasicDBWebApp.Models;
using BasicDBWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicDBWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private ILogger<StudentController> _logger;
        private IStudentService _service;

        public StudentController(
            ILogger<StudentController> logger,
            IStudentService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("name/{name}")]
        public async Task<StudentDto> GetStudentByNameAsync(
            string name)
        {
            var request = new GetStudentByNameRequest {  StudentName = name };
            return await _service.GetStudentByNameAsync(request);
        }

        [HttpGet("id/{id}")]
        public async Task<StudentDto> GetStudentByGuidAsync(
            Guid id)
        {
            var req = new GetStudentByGuidRequest { Id = id };
            return await _service.GetStudentByGuidAsync(req);
        }


        [HttpGet]
        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            return await _service.GetStudentsAsync();
        }

        [HttpPost("name/{name}/email/{email}")]
        public async Task<Guid> CreateStudent(
            string name,
            string email)
        {
            var request = new CreateStudentRequest { Name = name, Email = email };
            return await _service.CreateStudentAsync(request);
        }

        [HttpPut("grade/{gradeID}/student/{studentID}")]
        public async Task<StudentDto> SetStudentGradeAsync(
            Guid gradeID,
            Guid studentID)
        {
            var req = new SetStudentGradeRequest
            {
                GradeID = gradeID,
                StudentID = studentID
            };

            return await _service.SetStudentGradeAsync(req);
        }

        [HttpPut("course/{courseID}/student/{studentID}")]
        public async Task<StudentCourseDto> SetStudentCourseAsync(
            Guid courseID,
            Guid studentID)
        {
            var req = new SetStudentCourseRequest
            {
                CourseID = courseID,
                StudentID = studentID
            };

            return await _service.SetStudentCourseAsync(req);
        }
    }
}
