using BasicDBWebApp.Dtos;
using BasicDBWebApp.Entities;
using BasicDBWebApp.Models;
using BasicDBWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicDBWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradeController : ControllerBase
    {
        private ILogger<GradeController> _logger;
        private IGradeService _service;

        public GradeController(
            IGradeService service,
            ILogger<GradeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<GradeDto>> GetGradesAsync()
        {
            return await _service.GetGradesAsync();
        }

        [HttpGet("name/{name}")]
        public async Task<GradeDto> GetGradeByNameAsync(
            string name)
        {
            var request = new GetGradeByNameRequest
            {
                GradeName = name
            };

            return await _service.GetGradeByNameAsync(request);
        }

        [HttpGet("id/{id}")]
        public async Task<GradeDto> GetGradeByIDAsync(
            Guid id)
        {
            var req = new GetGradeByGuidRequest { Guid = id };

            return await _service.GetGradeByIDAsync(req);
        }

        [HttpPost("name/{name}")]
        public async Task<Guid> CreateGradeAsync(
            string name)
        {
            var request = new CreateGradeRequest
            {
                Name = name
            };

            return await _service.CreateGradeAsync(request);
        }
    }
}
