using BasicDBWebApp.Dtos;
using BasicDBWebApp.Entities;
using BasicDBWebApp.Models;

namespace BasicDBWebApp.Services
{
    public interface IGradeService
    {
        Task<Guid> CreateGradeAsync(CreateGradeRequest request);
        Task<GradeDto> GetGradeByIDAsync(GetGradeByGuidRequest request);
        Task<GradeDto> GetGradeByNameAsync(GetGradeByNameRequest request);
        Task<List<GradeDto>> GetGradesAsync();
    }
}