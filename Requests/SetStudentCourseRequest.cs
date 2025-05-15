namespace BasicDBWebApp.Models
{
    public class SetStudentCourseRequest
    {
        public Guid CourseID { get; set; }
        public Guid StudentID { get; set; }
    }
}
