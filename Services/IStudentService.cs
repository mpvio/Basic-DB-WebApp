using BasicDBWebApp.Dtos;
using BasicDBWebApp.Entities;
using BasicDBWebApp.Models;

namespace BasicDBWebApp.Services
{
    public interface IStudentService
    {
        Task<Guid> CreateStudentAsync(CreateStudentRequest request);
        Task<StudentDto> GetStudentByGuidAsync(GetStudentByGuidRequest request);
        Task<StudentDto> GetStudentByNameAsync(GetStudentByNameRequest request);
        Task<List<StudentDto>> GetStudentsAsync();
        Task<StudentCourseDto> SetStudentCourseAsync(SetStudentCourseRequest req);
        Task<StudentDto> SetStudentGradeAsync(SetStudentGradeRequest request);
    }
}