using BasicDBWebApp.Entities;

namespace BasicDBWebApp.Dtos
{
    public class StudentDto
    {
        public Guid StudentID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public Guid? GradeID { get; set; }
        public string? GradeName { get; set;} = string.Empty;
    }
}
