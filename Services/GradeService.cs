using BasicDBWebApp.Dtos;
using BasicDBWebApp.Entities;
using BasicDBWebApp.Models;
using BasicDBWebApp.MyDbContext;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BasicDBWebApp.Services
{
    public class GradeService : IGradeService
    {
        private ApplicationDbContext _context;
        private ILogger<GradeService> _logger;

        public GradeService(
            ApplicationDbContext context,
            ILogger<GradeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<GradeDto>> GetGradesAsync()
        {
            var grades = await _context.Grades
                .Include(g => g.Students)
                .ToListAsync();

            var gradesDto = new List<GradeDto>();

            foreach (var grade in grades)
            {
                gradesDto.Add(new GradeDto
                {
                    GradeID = grade.GradeID,
                    GradeName = grade.GradeName,
                    Students = grade.Students is not null ? grade.Students.Count() : 0
                });
            }

            return gradesDto;
        }

        public async Task<Guid> CreateGradeAsync(
            CreateGradeRequest request)
        {
            var grade = new Grade
            {
                GradeName = request.Name
            };

            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return grade.GradeID;
        }

        public async Task<GradeDto> GetGradeByNameAsync(
            GetGradeByNameRequest request)
        {
            var grade = await _context.Grades
                .Where(g => g.GradeName.Equals(request.GradeName))
                .Include(g => g.Students)
                .FirstOrDefaultAsync();

            if (grade is not null)
            {
                return new GradeDto
                {
                    GradeName = grade.GradeName,
                    GradeID = grade.GradeID,
                    Students = grade.Students is not null ? grade.Students.Count() : 0
                };
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public async Task<GradeDto> GetGradeByIDAsync(
            GetGradeByGuidRequest request)
        {
            var grade = await _context.Grades
                .Where(g => g.GradeID.Equals(request.Guid))
                .Include(g => g.Students)
                .FirstOrDefaultAsync();

            if (grade is not null)
            {
                return new GradeDto
                {
                    GradeName = grade.GradeName,
                    GradeID = grade.GradeID,
                    Students = grade.Students is not null ? grade.Students.Count() : 0
                };
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
