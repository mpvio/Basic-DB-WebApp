namespace BasicDBWebApp.Entities
{
    public class StudentCourse
    {
        public Guid StudentID { get; set; }
        public Student Student { get; set; }
        public Guid CourseID { get; set; }
        public Course Course { get; set; }
    }
}
