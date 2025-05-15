using BasicDBWebApp.Dtos;
using BasicDBWebApp.Models;

namespace BasicDBWebApp.Services
{
    public interface IStudentCourseService
    {
        Task<StudentCourseDto> GetStudentCourseByCourseNameAsync(GetStudentCourseByNameRequest req);
        Task<StudentCourseDto> GetStudentCourseByStudentNameAsync(GetStudentCourseByNameRequest req);
        Task<List<StudentCourseDto>> GetStudentCoursesAsync();
    }
}