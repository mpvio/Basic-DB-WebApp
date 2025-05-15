using BasicDBWebApp.Dtos;
using BasicDBWebApp.Entities;
using BasicDBWebApp.Models;
using BasicDBWebApp.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace BasicDBWebApp.Services
{
    public class CourseService : ICourseService
    {
        private ApplicationDbContext _context;
        private ILogger<CourseService> _logger;

        public CourseService(
            ApplicationDbContext context,
            ILogger<CourseService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CourseDto> GetCourseByNameAsync(
            GetCourseByNameRequest req)
        {
            var course = await _context.Courses
                .Where(c => c.CourseName == req.Name)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                throw new FileNotFoundException(message: "Course Not Found");
            }

            return new CourseDto
            {
                CourseName = course.CourseName,
                CourseID = course.CourseID
            };
        }

        public async Task<CourseDto> GetCourseByGuidAsync(
            GetCourseByGuidRequest request)
        {
            var course = await _context.Courses
                .Where(c => c.CourseID == request.Guid)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                throw new FileNotFoundException(message: "Course Not Found");
            }

            return new CourseDto
            {
                CourseName = course.CourseName,
                CourseID = course.CourseID
            };
        }

        public async Task<List<CourseDto>> GetCoursesAsync()
        {
            var courses = await _context.Courses
                .ToListAsync();

            var coursesDto = new List<CourseDto>();

            foreach (var course in courses)
            {
                coursesDto.Add(new CourseDto
                {
                    CourseName = course.CourseName,
                    CourseID = course.CourseID
                });
            }

            return coursesDto;
        }

        public async Task<Guid> CreateCourseAsync(
            CreateCourseRequest req)
        {
            var course = new Course
            {
                CourseName = req.CourseName
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return course.CourseID;
        }
    }
}
