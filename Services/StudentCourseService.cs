using BasicDBWebApp.Dtos;
using BasicDBWebApp.Models;
using BasicDBWebApp.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace BasicDBWebApp.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private ApplicationDbContext _context;
        private ILogger<StudentCourseService> _logger;

        public StudentCourseService(
            ApplicationDbContext context,
            ILogger<StudentCourseService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<StudentCourseDto>> GetStudentCoursesAsync()
        {
            var scs = await _context.StudentCourses
                .ToListAsync();

            if (scs == null)
            {
                throw new FileNotFoundException(message: "Student/ Courses Not Found.");
            }

            var scsDto = new List<StudentCourseDto>();

            foreach (var sc in scs)
            {
                scsDto.Add(new StudentCourseDto
                {
                    StudentID = sc.StudentID,
                    StudentName = sc.Student?.StudentName,
                    CourseID = sc.CourseID,
                    CourseName = sc.Course?.CourseName
                });
            }

            return scsDto;
        }

        public async Task<StudentCourseDto> GetStudentCourseByStudentNameAsync(
            GetStudentCourseByNameRequest req)
        {
            var sc = await _context.StudentCourses
                .Where(sc => sc.Student.StudentName.Equals(req.Name))
                .FirstOrDefaultAsync();

            if (sc == null)
            {
                throw new FileNotFoundException(message: "Student/ Course not Found.");
            }

            return new StudentCourseDto
            {
                CourseID = sc.CourseID,
                CourseName = sc.Course.CourseName,
                StudentID = sc.StudentID,
                StudentName = sc.Student.StudentName
            };
        }

        public async Task<StudentCourseDto> GetStudentCourseByCourseNameAsync(
            GetStudentCourseByNameRequest req)
        {
            var sc = await _context.StudentCourses
                .Where(sc => sc.Course.CourseName.Equals(req.Name))
                .FirstOrDefaultAsync();

            if (sc == null)
            {
                throw new FileNotFoundException(message: "Student/ Course not Found.");
            }

            return new StudentCourseDto
            {
                CourseID = sc.CourseID,
                CourseName = sc.Course.CourseName,
                StudentID = sc.StudentID,
                StudentName = sc.Student.StudentName
            };
        }
    }
}
