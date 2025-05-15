namespace BasicDBWebApp.Entities
{
    public class Student
    {
        public Guid StudentID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set;} = string.Empty;

        public Grade? Grade { get; set; }
        public Guid? GradeID { get; set;}
    }
}
