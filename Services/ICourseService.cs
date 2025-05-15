using BasicDBWebApp.Dtos;
using BasicDBWebApp.Models;

namespace BasicDBWebApp.Services
{
    public interface ICourseService
    {
        Task<Guid> CreateCourseAsync(CreateCourseRequest req);
        Task<CourseDto> GetCourseByGuidAsync(GetCourseByGuidRequest request);
        Task<CourseDto> GetCourseByNameAsync(GetCourseByNameRequest req);
        Task<List<CourseDto>> GetCoursesAsync();
    }
}