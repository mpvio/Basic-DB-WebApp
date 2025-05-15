namespace BasicDBWebApp.Dtos
{
    public class StudentCourseDto
    {
        public Guid CourseID { get; set; }
        public Guid StudentID { get; set; }
        public string StudentName { get; set;} = string.Empty;
        public string CourseName { get; set; } = string.Empty;
    }
}
